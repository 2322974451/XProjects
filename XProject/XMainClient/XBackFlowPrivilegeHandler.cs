using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A1C RID: 2588
	internal class XBackFlowPrivilegeHandler : DlgHandlerBase
	{
		// Token: 0x17002EBB RID: 11963
		// (get) Token: 0x06009E41 RID: 40513 RVA: 0x0019EF28 File Offset: 0x0019D128
		protected override string FileName
		{
			get
			{
				return "Hall/BfPrivilegeHandler";
			}
		}

		// Token: 0x06009E42 RID: 40514 RVA: 0x0019EF40 File Offset: 0x0019D140
		protected override void Init()
		{
			base.Init();
			this._activityTaskBtn = (base.transform.Find("bg/ActivityTask/BtnGo").GetComponent("XUIButton") as IXUIButton);
			this._activityTaskBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.GotoActivityTask));
			this._buyReward = (base.transform.Find("bg/DoubleReward/BtnGo").GetComponent("XUIButton") as IXUIButton);
			this._buyReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.GotoShopping));
			this._teamDetail = (base.transform.Find("bg/TeamReward/BtnGo").GetComponent("XUIButton") as IXUIButton);
			this._teamDetail.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowDetail));
		}

		// Token: 0x06009E43 RID: 40515 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x06009E44 RID: 40516 RVA: 0x0019F00C File Offset: 0x0019D20C
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x06009E45 RID: 40517 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x06009E46 RID: 40518 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x06009E47 RID: 40519 RVA: 0x0019F018 File Offset: 0x0019D218
		private bool OnShowDetail(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.Xsys_Backflow_Privilege);
			return true;
		}

		// Token: 0x06009E48 RID: 40520 RVA: 0x0019F03C File Offset: 0x0019D23C
		private bool GotoShopping(IXUIButton button)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Welfare_GiftBag, 0UL);
			return true;
		}

		// Token: 0x06009E49 RID: 40521 RVA: 0x0019F064 File Offset: 0x0019D264
		private bool GotoActivityTask(IXUIButton button)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Mall_BackFlowShop, 0UL);
			return true;
		}

		// Token: 0x04003816 RID: 14358
		private IXUIButton _activityTaskBtn;

		// Token: 0x04003817 RID: 14359
		private IXUIButton _buyReward;

		// Token: 0x04003818 RID: 14360
		private IXUIButton _teamDetail;
	}
}
