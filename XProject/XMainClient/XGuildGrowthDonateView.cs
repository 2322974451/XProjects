using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000A66 RID: 2662
	internal class XGuildGrowthDonateView : DlgBase<XGuildGrowthDonateView, XGuildGrowthDonateBehavior>
	{
		// Token: 0x17002F26 RID: 12070
		// (get) Token: 0x0600A16E RID: 41326 RVA: 0x001B5468 File Offset: 0x001B3668
		public override string fileName
		{
			get
			{
				return "Guild/GuildGrowth/GuildGrowthDonate";
			}
		}

		// Token: 0x17002F27 RID: 12071
		// (get) Token: 0x0600A16F RID: 41327 RVA: 0x001B5480 File Offset: 0x001B3680
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17002F28 RID: 12072
		// (get) Token: 0x0600A170 RID: 41328 RVA: 0x001B5494 File Offset: 0x001B3694
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17002F29 RID: 12073
		// (get) Token: 0x0600A171 RID: 41329 RVA: 0x001B54A8 File Offset: 0x001B36A8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002F2A RID: 12074
		// (get) Token: 0x0600A172 RID: 41330 RVA: 0x001B54BC File Offset: 0x001B36BC
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002F2B RID: 12075
		// (get) Token: 0x0600A173 RID: 41331 RVA: 0x001B54D0 File Offset: 0x001B36D0
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600A174 RID: 41332 RVA: 0x001B54E3 File Offset: 0x001B36E3
		protected override void Init()
		{
			this.InitProperties();
		}

		// Token: 0x0600A175 RID: 41333 RVA: 0x001B54ED File Offset: 0x001B36ED
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600A176 RID: 41334 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void RegisterEvent()
		{
		}

		// Token: 0x0600A177 RID: 41335 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnShow()
		{
		}

		// Token: 0x0600A178 RID: 41336 RVA: 0x001B54F8 File Offset: 0x001B36F8
		private void InitProperties()
		{
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
			base.uiBehaviour.RecordBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickedRecordBtn));
			base.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.OnInitWrapContent));
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnUpdateWrapContent));
			base.uiBehaviour.RecordWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnUpdateRecordWrapContent));
		}

		// Token: 0x0600A179 RID: 41337 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void OnUpdateRecordWrapContent(Transform itemTransform, int index)
		{
		}

		// Token: 0x0600A17A RID: 41338 RVA: 0x001B5598 File Offset: 0x001B3798
		private bool OnClickedRecordBtn(IXUIButton button)
		{
			return true;
		}

		// Token: 0x0600A17B RID: 41339 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void OnUpdateWrapContent(Transform itemTransform, int index)
		{
		}

		// Token: 0x0600A17C RID: 41340 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void OnInitWrapContent(Transform itemTransform, int index)
		{
		}

		// Token: 0x0600A17D RID: 41341 RVA: 0x001B55AC File Offset: 0x001B37AC
		private bool OnClose(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}
	}
}
