using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XGuildGrowthDonateView : DlgBase<XGuildGrowthDonateView, XGuildGrowthDonateBehavior>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildGrowth/GuildGrowthDonate";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
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

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this.InitProperties();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
		}

		protected override void OnShow()
		{
		}

		private void InitProperties()
		{
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
			base.uiBehaviour.RecordBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickedRecordBtn));
			base.uiBehaviour.WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.OnInitWrapContent));
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnUpdateWrapContent));
			base.uiBehaviour.RecordWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnUpdateRecordWrapContent));
		}

		private void OnUpdateRecordWrapContent(Transform itemTransform, int index)
		{
		}

		private bool OnClickedRecordBtn(IXUIButton button)
		{
			return true;
		}

		private void OnUpdateWrapContent(Transform itemTransform, int index)
		{
		}

		private void OnInitWrapContent(Transform itemTransform, int index)
		{
		}

		private bool OnClose(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}
	}
}
