//#define __LIGHT_VERSION__
#if (__LIGHT_VERSION__)
	using Kompas6LTAPI5;
	using KompasLTAPI7
#else
using Kompas6API5;
using KompasAPI7;
#endif

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Reflection;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using KAPITypes;
using Kompas6Constants;

using reference = System.Int32;

namespace Ascon.Uln
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class EngineerOffice
    {
        #region Private fields
        KompasObject kompas;
        #endregion
        

        // Имя библиотеки
        [return: MarshalAs(UnmanagedType.BStr)]
        public string GetLibraryName()
        {
            return "Engeenir Office - офис инженера";
        }

        [return: MarshalAs(UnmanagedType.BStr)] public string ExternalMenuItem(short number, ref short itemType, ref short command)
		{
            string result = string.Empty;
            itemType = 1; // "MENUITEM"
            switch (number)
            {
                case 1:
                    result = "Engineer Office";
                    command = 1;
                    break;
                case 2:
                    command = -1;
                    itemType = 3; // "ENDMENU"
                    break;
            }
            return result;
		}

        public void ExternalRunCommand([In] short command, [In] short mode, [In, MarshalAs(UnmanagedType.IDispatch)] object kompas_)
        {
            kompas = (KompasObject)kompas_;
            Global.Kompas = kompas;
            Global.KompasApp = (_Application)Global.Kompas.ksGetApplication7();
            
            
            switch (command)
            {
                case 1:
                    // при вызове команды Engineer Office создаём новый контрол
                    // на панели компаса
                    MessageBox.Show("aaaaa1");
                    wndEngOffice engOffice = new wndEngOffice();
                    engOffice.ShowWndEngOffice();
                    //GaykaObj gayka = new GaykaObj();
                    //gayka.Draw();
                    break;
                
            }


        }

        public bool LibInterfaceNotifyEntry(object application)
        {
            bool result = true;
            if (Global.Kompas == null && application != null)
            {
                Global.Kompas = (KompasObject)application;
            }
            if (Global.Kompas != null)
            {
                // Обработчик событий приложения КОМПАС


                Kompas6API5.ksKompasObjectNotify_Event kompasNotify = (Kompas6API5.ksKompasObjectNotify_Event)application;
                
                ApplicationEvent aplEvent = new ApplicationEvent(application, false);


                // Подписка на события приложения КОМПАС
                aplEvent.Advise();
            }
            return result;
        }

        #region Реализаця интерфейса IDisposable
        public void Dispose()
        {
            if (kompas != null)
            {
                Marshal.ReleaseComObject(Global.Kompas);
                GC.SuppressFinalize(Global.Kompas);
                kompas = null;
            }
        }
        #endregion

        #region COM Registration
        // Эта функция выполняется при регистрации класса для COM
        // Она добавляет в ветку реестра компонента раздел Kompas_Library,
        // который сигнализирует о том, что класс является приложением Компас,
        // а также заменяет имя InprocServer32 на полное, с указанием пути.
        // Все это делается для того, чтобы иметь возможность подключить
        // библиотеку на вкладке ActiveX.
        [ComRegisterFunction]
        public static void RegisterKompasLib(Type t)
        {
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                string keyName = @"SOFTWARE\Classes\CLSID\{" + t.GUID.ToString() + "}";
                regKey = regKey.OpenSubKey(keyName, true);
                regKey.CreateSubKey("Kompas_Library");
                regKey = regKey.OpenSubKey("InprocServer32", true);
                regKey.SetValue(null, System.Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\mscoree.dll");
                regKey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("При регистрации класса для COM-Interop произошла ошибка:\n{0}", ex));
            }
        }

        // Эта функция удаляет раздел Kompas_Library из реестра
        [ComUnregisterFunction]
        public static void UnregisterKompasLib(Type t)
        {
            RegistryKey regKey = Registry.LocalMachine;
            string keyName = @"SOFTWARE\Classes\CLSID\{" + t.GUID.ToString() + "}";
            RegistryKey subKey = regKey.OpenSubKey(keyName, true);
            subKey.DeleteSubKey("Kompas_Library");
            subKey.Close();
        }
        #endregion
    }
}
