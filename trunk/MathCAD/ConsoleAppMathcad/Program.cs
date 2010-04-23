using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mathcad;

//
namespace ConsoleAppMathcad
{
    class Program
    {
        static void Main(string[] args)
        {
            IMathcadApplication mc = new Application();
            IMathcadWorksheets mwk = mc.Worksheets;
            IMathcadWorksheet ws = mwk.Open("c:\\Temp\\1.xmcd");

            ws.SetValue("A", 2);
            Console.WriteLine("A = 2");

            ws.SetValue("B", 2);
            Console.WriteLine("B = 2");

            ws.Recalculate();

            Console.WriteLine("C = A + B = {0}", (ws.GetValue("C") as INumericValue).Real);

            mc.Visible = true;

            mc.ActiveWorksheet.Close(Mathcad.MCSaveOption.mcDiscardChanges);
            mc.Quit(Mathcad.MCSaveOption.mcDiscardChanges);
            Console.ReadLine();
        }
    }
}
