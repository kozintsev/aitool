////////////////////////////////////////////////////////////////////////////////
//
// ApplicationEvent  - ���������� ������� �� ����������
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
  public class ApplicationEvent : BaseEvent, ksKompasObjectNotify
  {
    public ApplicationEvent(object obj, bool selfAdvise)
      : base(obj, typeof(ksKompasObjectNotify).GUID,
      null, -1, null, selfAdvise) {}
		

    // koApplicatinDestroy - �������� ����������
    public bool ApplicationDestroy()
    {
      if (m_SelfAdvise )
      {
        string str = m_LibName + " --> ApplicationEvent.ApplicationDestroy";
        Global.Kompas.ksMessage(str);
      }
  
      // ������������
      TerminateEvents();
      return true;
    }


    // koBeginCloseAllDocument - ������ �������� ���� �������� ����������
    public bool BeginCloseAllDocument()
    {
      bool res = true;
      if (m_SelfAdvise )
      {
        string str = string.Empty;
        str = string.Format("{0} --> ApplicationEvent.BeginCloseAllDocument\n������� ���?", m_LibName);
        res = Global.Kompas.ksYesNo(str) == 1 ? true : false;
      }
      return res;
    }


    // koBeginCreate - ������ �������� ���������(�� ������� ������ ����)
    public bool BeginCreate(int docType)
    {
      bool res = true;
      if (m_SelfAdvise )
      {
        string str = string.Empty;
        str = string.Format("{0} --> ApplicationEvent.BeginCreate\ndocType = {1}\n", m_LibName, docType);
        str += "�� - ������� ������\n" +
          "��� - ��������� ����������� ������ �������� �����\n" +
          "������ - �� ��������� ����";
        int comm = Global.Kompas.ksYesNo(str);
        switch (comm) 
        {
          case 1: 
          {
            ksDocumentParam docParam = (ksDocumentParam)Global.Kompas.GetParamStruct((short)StructType2DEnum.ko_DocumentParam);
            docParam.Init();
            docParam.type =  (short)DocType.lt_DocSheetStandart;
            ksDocument2D doc = (ksDocument2D)Global.Kompas.Document2D();
            doc.ksCreateDocument(docParam);
            res = (doc.reference == 0);	// ���� �������� ������ ����������� ������ �� �����
            break;
          }	
          case -1:
            res = false;
            break;
        }
      }
      return res;
    }


    // koOpenDocumenBegin - ������ �������� ���������
    public bool BeginOpenDocument(string fileName)
    {
      if (m_SelfAdvise )
      {
        string str = m_LibName + " --> ApplicationEvent.BeginOpenDocumen\nfileName = " + fileName;
        return Global.Kompas.ksYesNo(str) == 1 ? true : false;
      }
      else
        return true;
    }


    // koBeginOpenFile - ������ �������� ���������(�� ������� ������ �����)
    public bool BeginOpenFile()
    {
      bool res = true;
      if (m_SelfAdvise )
      {
        string str = m_LibName + " --> ApplicationEvent.BeginOpenFile\n" + 
          "�� - ������� ������\n" + 
          "��� - ��������� ����������� ������ �������� �����\n" + 
          "������ - �� ��������� ����";
        int comm = Global.Kompas.ksYesNo(str);
        switch (comm) 
        {
          case 1: 
          {
            ksDocumentParam docParam = (ksDocumentParam)Global.Kompas.GetParamStruct((short)StructType2DEnum.ko_DocumentParam);
            docParam.Init();
            docParam.type = (short)DocType.lt_DocSheetStandart;
            ksDocument2D doc = (ksDocument2D)Global.Kompas.Document2D();
            res = !doc.ksCreateDocument(docParam);
            break;
          }	
          case -1:
            res = false;
            break;
        }
      }
      return res;
    }


    // koActiveDocument - ������������ �� ������ �������� ��������
    public bool ChangeActiveDocument(object newDoc, int docType)
    {
      if (m_SelfAdvise )
      {
        string str = string.Empty;
        str = string.Format("{0} --> ApplicationEvent.ChangeActiveDocument\nnewDoc = {1}\ndocType = {2}", m_LibName, newDoc, docType);
        Global.Kompas.ksMessage(str);
      }
      return true;
    }


    // koCreateDocument - �������� ������
    public bool CreateDocument(object newDoc, int docType)
    {
      if (m_SelfAdvise )
      {
        string str = string.Empty;
        str = string.Format("{0} --> ApplicationEvent.CreateDocument\nnewDoc = {1}\ndocType = {2}", m_LibName, newDoc, docType);
        Global.Kompas.ksMessage(str);
      }  
      return true;
    }


    // koOpenDocumen - �������� ������
    public bool OpenDocument(object newDoc, int docType)
    {
      if (m_SelfAdvise )
      {
        string str = string.Empty;
        str = string.Format("{0} --> ApplicationEvent.OpenDocumen\nnewDoc = {1}\ndocType = {2}", m_LibName, newDoc, docType);
        Global.Kompas.ksMessage(str);
      }  
      return true;
    }

    // koKeyDown - ������� ����������
    public bool KeyDown( ref int key, int flags, bool system )
    {
      return true;
    }

    // koKeyUp - ������� ����������
    public bool KeyUp( ref int key, int flags, bool system )
    {
      return true;
    }

    // koKeyPress - ������� ����������
    public bool KeyPress( ref int key, bool system )
    {
      return true;
    }

    public bool BeginReguestFiles( int type, ref object files )
    {
      return true;
    }
  }
}
