using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200189B RID: 6299
	internal class XGuildBoonView : DlgBase<XGuildBoonView, XGuildBoonBehaviour>
	{
		// Token: 0x0601065C RID: 67164 RVA: 0x003FFE18 File Offset: 0x003FE018
		static XGuildBoonView()
		{
			XGuildBoonView._BoonBg.Add(XSysDefine.XSys_GuildBoon_RedPacket, "gh_btn_ghhb");
			XGuildBoonView._BoonBg.Add(XSysDefine.XSys_GuildBoon_Shop, "gh_btn_ghsd");
			XGuildBoonView._BoonBg.Add(XSysDefine.XSys_GuildBoon_Salay, "gh_btn_ghhyd");
		}

		// Token: 0x170039ED RID: 14829
		// (get) Token: 0x0601065D RID: 67165 RVA: 0x003FFE80 File Offset: 0x003FE080
		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildBoonDlg";
			}
		}

		// Token: 0x170039EE RID: 14830
		// (get) Token: 0x0601065E RID: 67166 RVA: 0x003FFE98 File Offset: 0x003FE098
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170039EF RID: 14831
		// (get) Token: 0x0601065F RID: 67167 RVA: 0x003FFEAC File Offset: 0x003FE0AC
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170039F0 RID: 14832
		// (get) Token: 0x06010660 RID: 67168 RVA: 0x003FFEC0 File Offset: 0x003FE0C0
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170039F1 RID: 14833
		// (get) Token: 0x06010661 RID: 67169 RVA: 0x003FFED4 File Offset: 0x003FE0D4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010662 RID: 67170 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void Init()
		{
		}

		// Token: 0x06010663 RID: 67171 RVA: 0x003FFEE7 File Offset: 0x003FE0E7
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x06010664 RID: 67172 RVA: 0x003FFEF1 File Offset: 0x003FE0F1
		protected override void OnShow()
		{
			base.OnShow();
			this.Refresh();
			base.uiBehaviour.m_ScrollView.ResetPosition();
		}

		// Token: 0x06010665 RID: 67173 RVA: 0x003FFF13 File Offset: 0x003FE113
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		// Token: 0x06010666 RID: 67174 RVA: 0x003FFF3A File Offset: 0x003FE13A
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.Refresh();
		}

		// Token: 0x06010667 RID: 67175 RVA: 0x003FFF4C File Offset: 0x003FE14C
		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x06010668 RID: 67176 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void Refresh()
		{
		}

		// Token: 0x06010669 RID: 67177 RVA: 0x003FFF68 File Offset: 0x003FE168
		public void RefreshRedPoints()
		{
			this.redpointMgr.UpdateRedPointUI();
		}

		// Token: 0x0601066A RID: 67178 RVA: 0x003FFF78 File Offset: 0x003FE178
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

		// Token: 0x04007660 RID: 30304
		private static Dictionary<XSysDefine, string> _BoonBg = new Dictionary<XSysDefine, string>(default(XFastEnumIntEqualityComparer<XSysDefine>));

		// Token: 0x04007661 RID: 30305
		private XSubSysRedPointMgr redpointMgr = new XSubSysRedPointMgr();
	}
}
