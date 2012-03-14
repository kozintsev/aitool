////////////////////////////////////////////////////////////////////////////////
//
// StampEvent  - ���������� ������� ������
//
//////////////////////////////////////////////////////////////////////////////////

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
	public class StampEvent : BaseEvent, ksStampNotify
	{
		public StampEvent(object obj, object doc, bool selfAdvise)
			: base(obj, typeof(ksStampNotify).GUID, doc,
			-1, null, selfAdvise) {}

		// kdBeginEditStamp - ������ �������������� ������
		public bool BeginEditStamp()
		{
			if (m_SelfAdvise )
			{
				string str = m_LibName + " --> BeginEditStamp";
				str += "\n��� ��������� = " + GetDocName();
				return Global.Kompas.ksYesNo(str) == 1 ? true : false;
			}
			return true;
		}


		// kdEndEditStamp - ���������� �������������� ������
		public bool EndEditStamp(bool editResult)
		{
			if (m_SelfAdvise )
			{
				string str = string.Empty;
				str = string.Format("{0} --> EndEditStamp\neditResult = {1}", m_LibName, editResult ? "true" : "false");
				str += "\n��� ��������� = " + GetDocName();
				Global.Kompas.ksMessage(str);
			}
			return true;  
		}


		// kdStampCellDblClick - �������� �� ������
		public bool StampCellDblClick(int number)
		{
			if (m_SelfAdvise )
			{
				string str = string.Empty;
				str = string.Format("{0} --> StampCellDblClick\nnumber = {1}", m_LibName, number);
				str += "\n��� ��������� = " + GetDocName();
				return Global.Kompas.ksYesNo(str) == 1 ? true : false;
			}
			return true; 
		}


		// kdStampCellBeginEdit - ������ �������������� ������ ������
		public bool StampCellBeginEdit(int number)
		{
			if (m_SelfAdvise )
			{
				string str = string.Empty;
				str = string.Format("{0} --> StampCellBeginEdit\nnumber = {1}", m_LibName, number);
				str += "\n��� ��������� = " + GetDocName();
				return Global.Kompas.ksYesNo(str) == 1 ? true : false;
			}
			return true; 
		}	

    // kdStampCellBeginEdit - ������ �������������� ������ ������
    public bool StampBeginClearCells(object numbers)
    {
      return true; 
    }	
	}
}
