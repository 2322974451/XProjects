using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000A67 RID: 2663
	internal class XGuildGrowthEntranceView : DlgBase<XGuildGrowthEntranceView, XGuildGrowthEntranceBehavior>
	{
		// Token: 0x17002F2C RID: 12076
		// (get) Token: 0x0600A17F RID: 41343 RVA: 0x001B55D4 File Offset: 0x001B37D4
		public override string fileName
		{
			get
			{
				return "Guild/GuildGrowth/GuildGrowthEntranceDlg";
			}
		}

		// Token: 0x17002F2D RID: 12077
		// (get) Token: 0x0600A180 RID: 41344 RVA: 0x001B55EC File Offset: 0x001B37EC
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17002F2E RID: 12078
		// (get) Token: 0x0600A181 RID: 41345 RVA: 0x001B5600 File Offset: 0x001B3800
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17002F2F RID: 12079
		// (get) Token: 0x0600A182 RID: 41346 RVA: 0x001B5614 File Offset: 0x001B3814
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002F30 RID: 12080
		// (get) Token: 0x0600A183 RID: 41347 RVA: 0x001B5628 File Offset: 0x001B3828
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002F31 RID: 12081
		// (get) Token: 0x0600A184 RID: 41348 RVA: 0x001B563C File Offset: 0x001B383C
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600A185 RID: 41349 RVA: 0x001B564F File Offset: 0x001B384F
		protected override void Init()
		{
			this.InitProperties();
			this._doc = XDocuments.GetSpecificDocument<XGuildGrowthDocument>(XGuildGrowthDocument.uuID);
		}

		// Token: 0x0600A186 RID: 41350 RVA: 0x001B5669 File Offset: 0x001B3869
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600A187 RID: 41351 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void RegisterEvent()
		{
		}

		// Token: 0x0600A188 RID: 41352 RVA: 0x001B5673 File Offset: 0x001B3873
		protected override void OnShow()
		{
			base.OnShow();
		}

		// Token: 0x0600A189 RID: 41353 RVA: 0x001B567D File Offset: 0x001B387D
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600A18A RID: 41354 RVA: 0x001B5688 File Offset: 0x001B3888
		private void InitProperties()
		{
			base.uiBehaviour.BuilderBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickBuilderBtn));
			base.uiBehaviour.LabBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickLabBtn));
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
		}

		// Token: 0x0600A18B RID: 41355 RVA: 0x001B56F0 File Offset: 0x001B38F0
		private bool OnClose(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600A18C RID: 41356 RVA: 0x001B570C File Offset: 0x001B390C
		private bool OnClickLabBtn(IXUIButton button)
		{
			DlgBase<XGuildGrowthLabView, XGuildGrowthLabBehavior>.singleton.SetVisible(true, true);
			return true;
		}

		// Token: 0x0600A18D RID: 41357 RVA: 0x001B572C File Offset: 0x001B392C
		private bool OnClickBuilderBtn(IXUIButton button)
		{
			DlgBase<XGuildGrowthBuffView, XGuildGrowthBuffBehavior>.singleton.SetVisible(true, true);
			return true;
		}

		// Token: 0x04003A32 RID: 14898
		private XGuildGrowthDocument _doc;
	}
}
