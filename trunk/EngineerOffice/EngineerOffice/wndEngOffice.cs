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
using System.Runtime.InteropServices;
using System.Text;
using Kompas6Constants;
using KAPITypes;
namespace Ascon.Uln
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class wndEngOffice
    {
        private PropertyManager propMng;
        private PropertyEdit nEdit;
        public ProjectManager hatchPar;
        private PropertyUserControl userCtrl;
        
        public bool ShowWndEngOffice()
        {
            PropertyTab tab;
            PropertyControls ctrls;
            
            if (Global.KompasApp == null)
                return false;

            if (propMng == null)
            {
                propMng = Global.KompasApp.CreatePropertyManager(true);
                propMng.ButtonClick += new ksPropertyManagerNotify_ButtonClickEventHandler(propMng_ButtonClick);
                propMng.ControlCommand += new ksPropertyManagerNotify_ControlCommandEventHandler(propMng_ControlCommand);
                propMng.Layout = PropertyManagerLayout.pmAlignRight;
                propMng.SetGabaritRect(20, 20, 200, 200);
                propMng.Caption = "Engeenir Office";
                propMng.SpecToolbar = SpecPropertyToolBarEnum.pnEmpty;
                tab = propMng.PropertyTabs.Add("Engeenir Office");
                ctrls = tab.PropertyControls;

                userCtrl = (PropertyUserControl)ctrls.Add(ControlTypeEnum.ksControlUser);
                userCtrl.SetOCXControl("Ascon.Uln.ProjectManager");
                userCtrl.Id = 10011;
                userCtrl.Name = "&Project Manager";
                //268; 256
                userCtrl.Width = 268;
                userCtrl.Height = 256;
                userCtrl.CreateOCX += new ksPropertyUserControlNotify_CreateOCXEventHandler(userCtrl_CreateOCX);
                userCtrl.DestroyOCX += new ksPropertyUserControlNotify_DestroyOCXEventHandler(userCtrl_DestroyOCX);
                
                propMng.ShowTabs();
                propMng.Visible = true;
                return true;
            }
            return false;
        }

        bool propMng_ControlCommand(IPropertyControl Control, int ButtonID)
        {
            throw new NotImplementedException();
        }

        bool propMng_ButtonClick(int ButtonID)
        {
            throw new NotImplementedException();
        }
        
        bool userCtrl_DestroyOCX()
        {
            hatchPar = null;
            return true;
        }

        bool userCtrl_CreateOCX(object IOcx)
        {
            hatchPar = (ProjectManager)IOcx;
            return true;
        }
        
    }
}
