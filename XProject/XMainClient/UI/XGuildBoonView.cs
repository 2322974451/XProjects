using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildBoonView : DlgBase<XGuildBoonView, XGuildBoonBehaviour>
	{

		static XGuildBoonView()
		{
			XGuildBoonView._BoonBg.Add(XSysDefine.XSys_GuildBoon_RedPacket, "gh_btn_ghhb");
			XGuildBoonView._BoonBg.Add(XSysDefine.XSys_GuildBoon_Shop, "gh_btn_ghsd");
			XGuildBoonView._BoonBg.Add(XSysDefine.XSys_GuildBoon_Salay, "gh_btn_ghhyd");
		}

		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildBoonDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.Refresh();
			base.uiBehaviour.m_ScrollView.ResetPosition();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.Refresh();
		}

		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		public void Refresh()
		{
		}

		public void RefreshRedPoints()
		{
			this.redpointMgr.UpdateRedPointUI();
		}

		private void OnBoonClick(IXUITexture sp)
		{
			switch ((int)sp.ID)
			{
			case 830:
				DlgBase<XGuildSignRedPackageView, XGuildSignRedPackageBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				break;
			case 831:
				DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Guild, 0UL);
				break;
			case 833:
				DlgBase<GuildSalayDlg, GuildSalayBehavior>.singleton.SetVisibleWithAnimation(true, null);
				break;
			}
		}

		private static Dictionary<XSysDefine, string> _BoonBg = new Dictionary<XSysDefine, string>(default(XFastEnumIntEqualityComparer<XSysDefine>));

		private XSubSysRedPointMgr redpointMgr = new XSubSysRedPointMgr();
	}
}
