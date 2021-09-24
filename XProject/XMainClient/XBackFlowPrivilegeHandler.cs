using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBackFlowPrivilegeHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Hall/BfPrivilegeHandler";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		private bool OnShowDetail(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.Xsys_Backflow_Privilege);
			return true;
		}

		private bool GotoShopping(IXUIButton button)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Welfare_GiftBag, 0UL);
			return true;
		}

		private bool GotoActivityTask(IXUIButton button)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Mall_BackFlowShop, 0UL);
			return true;
		}

		private IXUIButton _activityTaskBtn;

		private IXUIButton _buyReward;

		private IXUIButton _teamDetail;
	}
}
