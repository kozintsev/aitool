////////////////////////////////////////////////////////////////////////////////
//
// SelectMngEvent  - ���������� ������� �� ��������� �������������� ���������
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
using KAPITypes;

namespace Ascon.Uln
{
	public class SelectMngEvent : BaseEvent, ksSelectionMngNotify
	{
		public SelectMngEvent(object obj, object doc, bool selfAdvise)
			: base(obj, typeof(ksSelectionMngNotify).GUID, doc,
			-1, null, selfAdvise) {}

		// ksmSelect - ������ ������������
		public bool Select(object obj) 
		{ 
			if (m_SelfAdvise )
			{
				string str = string.Empty;
				str = string.Format("{0} --> Select\nobj = {0}", m_LibName, obj);
				str += "\n��� ��������� = " + GetDocName();
				Global.Kompas.ksMessage(str);
			}
			return true;
		}


		// ksmUnselect - ������ ���������������
		public bool Unselect(object obj)
		{
			if (m_SelfAdvise )
			{
				string str = string.Empty;
				str = string.Format("{0} --> Unselect\nobj = {1}", m_LibName, obj);
				str += "\n��� ��������� = " + GetDocName();
				Global.Kompas.ksMessage(str);
			}
			return true;
		}


		// ksmUnselectAll - ��� ������� ����������������
		public bool UnselectAll() 
		{
			if (m_SelfAdvise )
			{
				string str = m_LibName + " --> UnselectAll";
				str += "\n��� ��������� = " + GetDocName();
				Global.Kompas.ksMessage(str);
			}
			return true;
		}	
	}
}
