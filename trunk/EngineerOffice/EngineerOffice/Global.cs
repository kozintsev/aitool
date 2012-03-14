//#define __LIGHT_VERSION__
#if (__LIGHT_VERSION__)
	using Kompas6LTAPI5;
	using KompasLTAPI7
#else
using Kompas6API5;
using KompasAPI7;
#endif

using System;
using System.Collections;

namespace Ascon.Uln
{
	public class Global
	{
		private static ArrayList eventList = new ArrayList();
		public static ArrayList EventList
		{
			get
			{
				return eventList;
			}
			set
			{
				eventList = value;
			}
		}

		private static KompasObject kompas;
		public static KompasObject Kompas
		{
			get
			{
				return kompas;
			}
			set
			{
				kompas = value;
			}
		}

        private static _Application kompasApp;
        public static _Application KompasApp
        {
            get
            {
                return kompasApp;
            }
            set
            {
                kompasApp = value;
            }
        }
	}
}
