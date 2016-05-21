using System;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.Net.PeerToPeer;
using System.ServiceModel;
using System.Configuration;

namespace P2P
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private P2PService _localService;
        private ServiceHost _host;
        private PeerName _peerName;
        private PeerNameRegistration _peerNameRegistration;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Получение конфигурационной информации из app.config
            var port = ConfigurationManager.AppSettings["port"];
            var username = ConfigurationManager.AppSettings["username"];
            string serviceUrl = null;
            StatusPort.Content = "Порт: " + port;
            StatusUsername.Content = "Имя пользователя: " + username;
            // Установка заголовка окна
            Title = string.Format("P2P приложение - {0}", username);
            //  Получение URL-адреса службы с использованием адресаIPv4 
            //  и порта из конфигурационного файла
            foreach (var address in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    serviceUrl = string.Format("net.tcp://{0}:{1}/P2PService", address, port);
                    break;
                }
            }
            // Выполнение проверки, не является ли адрес null
            if (serviceUrl == null)
            {
                // Отображение ошибки и завершение работы приложения
                MessageBox.Show(this, "Не удается определить адрес конечной точки WCF.", "Networking Error",
                    MessageBoxButton.OK, MessageBoxImage.Stop);
                Application.Current.Shutdown();
                return;
            }
            // Регистрация и запуск службы WCF
            _localService = new P2PService(this, username);
            _host = new ServiceHost(_localService, new Uri(serviceUrl));
            var binding = new NetTcpBinding
            {
                Security = {Mode = SecurityMode.None}
            };
            _host.AddServiceEndpoint(typeof(IP2PService), binding, serviceUrl);
            try
            {
                _host.Open();
            }
            catch (AddressAlreadyInUseException)
            {
                // Отображение ошибки и завершение работы приложения
                MessageBox.Show(this, "Не удается начать прослушивание, порт занят.", "WCF Error",
                   MessageBoxButton.OK, MessageBoxImage.Stop);
                Application.Current.Shutdown();
                return;
            }
            // Создание имени равноправного участника (пира)
            _peerName = new PeerName("P2P Sample", PeerNameType.Unsecured);
            // Подготовка процесса регистрации имени равноправного участника в локальном облаке
            _peerNameRegistration = new PeerNameRegistration(_peerName, int.Parse(port))
            {
                Cloud = Cloud.AllLinkLocal
            };
            // Запуск процесса регистрации
            _peerNameRegistration.Start();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Остановка регистрации
            _peerNameRegistration.Stop();
            // Остановка WCF-сервиса
            _host.Close();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            // Создание распознавателя и добавление обработчиков событий
            var resolver = new PeerNameResolver();
            resolver.ResolveProgressChanged += resolver_ResolveProgressChanged;
            resolver.ResolveCompleted += resolver_ResolveCompleted;

            // Подготовка к добавлению новых пиров
            PeerList.Items.Clear();
            RefreshButton.IsEnabled = false;

            // Преобразование незащищенных имен пиров асинхронным образом
            resolver.ResolveAsync(new PeerName("0.P2P Sample"), 1);
        }

        void resolver_ResolveCompleted(object sender, ResolveCompletedEventArgs e)
        {
            // Сообщение об ошибке, если в облаке не найдены пиры
            if (PeerList.Items.Count == 0)
            {
                PeerList.Items.Add(
                   new PeerEntry
                   {
                       DisplayString = "Пиры не найдены.",
                       ButtonsEnabled = false
                   });
            }
            // Повторно включаем кнопку "обновить"
            RefreshButton.IsEnabled = true;
        }

        void resolver_ResolveProgressChanged(object sender, ResolveProgressChangedEventArgs e)
        {
            var peer = e.PeerNameRecord;

            foreach (var ep in peer.EndPointCollection)
            {
                if (ep.Address.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork) continue;
                try
                {
                    var endpointUrl = string.Format("net.tcp://{0}:{1}/P2PService", ep.Address, ep.Port);
                    var binding = new NetTcpBinding();
                    binding.Security.Mode = SecurityMode.None;
                    var serviceProxy = ChannelFactory<IP2PService>.CreateChannel(
                        binding, new EndpointAddress(endpointUrl));
                    PeerList.Items.Add(
                        new PeerEntry
                        {
                            PeerName = peer.PeerName,
                            ServiceProxy = serviceProxy,
                            DisplayString = serviceProxy.GetName(),
                            ButtonsEnabled = true
                        });
                }
                catch (EndpointNotFoundException)
                {
                    PeerList.Items.Add(
                        new PeerEntry
                        {
                            PeerName = peer.PeerName,
                            DisplayString = "Неизвестный пир",
                            ButtonsEnabled = false
                        });
                }
            }
        }

        private void PeerList_Click(object sender, RoutedEventArgs e)
        {
            // Убедимся, что пользователь щелкнул по кнопке с именем MessageButton
            if (((Button) e.OriginalSource).Name != "MessageButton") return;
            // Получение пира и прокси, для отправки сообщения
            var peerEntry = ((Button)e.OriginalSource).DataContext as PeerEntry;
            if (peerEntry == null || peerEntry.ServiceProxy == null) return;
            try
            {
                if (string.IsNullOrEmpty(MsgBox.Text)) return;
                MyListBox.Items.Add("Сообщение от Вас: " + MsgBox.Text);
                peerEntry.ServiceProxy.SendMessage(MsgBox.Text, ConfigurationManager.AppSettings["username"]);
                MsgBox.Text = string.Empty;
            }
            catch (CommunicationException exception)
            {
                MessageBox.Show(this, exception.Message, @"Error!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        internal void DisplayMessage(string message, string from)
        {
            // Показать полученное сообщение (вызывается из службы WCF)
            MyListBox.Items.Add("Сообщение от " + from + ": " + message);
            //MessageBox.Show(this, message, string.Format("Сообщение от {0}", from),
            //    MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void PeerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
