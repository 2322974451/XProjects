using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E82 RID: 3714
	internal class TooltipButtonOperateRecycle : TooltipButtonOperateBase
	{
		// Token: 0x0600C696 RID: 50838 RVA: 0x002BF5FA File Offset: 0x002BD7FA
		public TooltipButtonOperateRecycle(XSysDefine sys)
		{
			this.m_Sys = sys;
		}

		// Token: 0x0600C697 RID: 50839 RVA: 0x002BF60C File Offset: 0x002BD80C
		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("DECOMPOSE");
		}

		// Token: 0x0600C698 RID: 50840 RVA: 0x002BF628 File Offset: 0x002BD828
		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		// Token: 0x0600C699 RID: 50841 RVA: 0x002BF63C File Offset: 0x002BD83C
		public override bool IsButtonVisible(XItem item)
		{
			bool flag = XSingleton<TooltipParam>.singleton.bShowTakeOutBtn || XSingleton<TooltipParam>.singleton.bShowPutInBtn;
			return !flag && (XSingleton<XGameSysMgr>.singleton.IsSystemOpened(this.m_Sys) && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Recycle_Equip)) && item.itemConf.IsCanRecycle == 1;
		}

		// Token: 0x0600C69A RID: 50842 RVA: 0x002BF6A4 File Offset: 0x002BD8A4
		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			DlgBase<RecycleSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Recycle_Equip);
			XRecycleItemDocument specificDocument = XDocuments.GetSpecificDocument<XRecycleItemDocument>(XRecycleItemDocument.uuID);
			specificDocument.ToggleItemSelect(mainUID);
		}

		// Token: 0x04005711 RID: 22289
		protected XSysDefine m_Sys;
	}
}
