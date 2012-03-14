////////////////////////////////////////////////////////////////////////////////
//
// Document3DEvent - обработчик событий от 3D документа
//
////////////////////////////////////////////////////////////////////////////////

//#define __LIGHT_VERSION__
#if (__LIGHT_VERSION__)
	using Kompas6LTAPI5;
#else
	using Kompas6API5;
#endif

using System;
using Kompas6Constants;
using Kompas6Constants3D;
using KAPITypes;

namespace Ascon.Uln
{
	public class Document3DEvent : BaseEvent, ksDocument3DNotify
	{
		public Document3DEvent(object obj, object doc, bool selfAdvise)
			: base(obj, typeof(ksDocument3DNotify).GUID, doc,
			-1, null, selfAdvise) {}

		// d3BeginRebuild - Начало перестроения модели
		public bool BeginRebuild()
		{ 
			if (m_SelfAdvise)
			{
				string str = m_LibName + " --> BeginRebuild";
				str += "\nИмя документа = " + GetDocName();
				return Global.Kompas.ksYesNo(str) == 1 ? true : false;
			}
			else
				return true;
		}


		// d3Rebuild - Модель перестроена
		public bool Rebuild()
		{   
			if (m_SelfAdvise)
			{
				string str = m_LibName + " --> Rebuild";
				str += "\nИмя документа = " + GetDocName();
				Global.Kompas.ksMessage(str);
			}
			return true;
		}


		// d3BeginChoiceMaterial - Начало выбора материала
		public bool BeginChoiceMaterial()
		{
			bool res = false;
			if (m_SelfAdvise)
			{
				string str = m_LibName + " --> BeginChoiceMaterial";
				str += "\nИмя документа = " + GetDocName();
				res = Global.Kompas.ksYesNo(str) == 1 ? true : false;

				if (!res)
				{   
					ksDocument3D doc3D = (ksDocument3D)m_Doc;
					if (doc3D != null) 
					{  
						ksPart partObj = (ksPart)doc3D.GetPart((int)Part_Type.pTop_Part);
						partObj.SetMaterial("Material", 36.6);
						partObj.Update();
					}
				}
			}
			return res;
		}


		// d3СhoiceMaterial - Закончен выбор материала
		public bool ChoiceMaterial(string material, double density)
		{
			if (m_SelfAdvise)
			{
				string str = string.Empty;
				str = string.Format("{0} --> ChoiceMaterial\nmaterial = {1}\ndensity = {2}", m_LibName, material, density);
				str += "\nИмя документа = " + GetDocName();
				Global.Kompas.ksMessage(str);
			}
			return true;
		}


		// d3BeginChoiceMarking - Начало выбора обозначения
		public bool BeginChoiceMarking()
		{
			bool res = false;
			if (m_SelfAdvise)
			{
				string str = m_LibName + " --> BeginChoiceMarking";
				str += "\nИмя документа = " + GetDocName();
				res = Global.Kompas.ksYesNo(str) == 1 ? true : false;

				if (!res)
				{   
					ksDocument3D doc3D = (ksDocument3D)m_Doc;
					if (doc3D != null) 
					{  
						ksPart partObj = (ksPart)doc3D.GetPart((int)Part_Type.pTop_Part);
						partObj.marking = "Marking";
						partObj.Update();
					}
				}
			}
			return res;
		}


		// d3СhoiceMarking - Закончен выбор обозначения
		public bool ChoiceMarking(string marking)
		{
			if (m_SelfAdvise)
			{
				string str = string.Empty;
				str = string.Format("{0} --> ChoiceMarking\nmarking = {1}", m_LibName, marking);
				str += "\nИмя документа = " + GetDocName();
				Global.Kompas.ksMessage(str);
			}
			return true;
		}


		// d3BeginSetPartFromFile - Начало установки компонента в сборку (до диалога выбора имени)
		public bool BeginSetPartFromFile()
		{
			if (m_SelfAdvise)
			{
				string str = m_LibName + " --> BeginSetPartFromFile";
				str += "\nИмя документа = " + GetDocName();
				return Global.Kompas.ksYesNo(str) == 1 ? true : false;
			}
			return true;
		}


		// d3BeginCreatePartFromFile - Начало создания компонента в сборке (до диалога выбора имени)
		public bool BeginCreatePartFromFile(bool part, entity plane)
		{
			if (m_SelfAdvise)
			{
				string str = m_LibName + " --> BeginCreatePartFromFile";
				str += "\nИмя документа = " + GetDocName();
				return Global.Kompas.ksYesNo(str) == 1 ? true : false;
			}
			return true;
		}
	}
}
