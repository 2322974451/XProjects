using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateRecycle : TooltipButtonOperateBase
	{

		public TooltipButtonOperateRecycle(XSysDefine sys)
		{
			this.m_Sys = sys;
		}

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("DECOMPOSE");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		public override bool IsButtonVisible(XItem item)
		{
			bool flag = XSingleton<TooltipParam>.singleton.bShowTakeOutBtn || XSingleton<TooltipParam>.singleton.bShowPutInBtn;
			return !flag && (XSingleton<XGameSysMgr>.singleton.IsSystemOpened(this.m_Sys) && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Recycle_Equip)) && item.itemConf.IsCanRecycle == 1;
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			DlgBase<RecycleSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Recycle_Equip);
			XRecycleItemDocument specificDocument = XDocuments.GetSpecificDocument<XRecycleItemDocument>(XRecycleItemDocument.uuID);
			specificDocument.ToggleItemSelect(mainUID);
		}

		protected XSysDefine m_Sys;
	}
}
