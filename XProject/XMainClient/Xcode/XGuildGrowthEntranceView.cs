using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XGuildGrowthEntranceView : DlgBase<XGuildGrowthEntranceView, XGuildGrowthEntranceBehavior>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildGrowth/GuildGrowthEntranceDlg";
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
			this._doc = XDocuments.GetSpecificDocument<XGuildGrowthDocument>(XGuildGrowthDocument.uuID);
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
			base.OnShow();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		private void InitProperties()
		{
			base.uiBehaviour.BuilderBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickBuilderBtn));
			base.uiBehaviour.LabBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickLabBtn));
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClose));
		}

		private bool OnClose(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		private bool OnClickLabBtn(IXUIButton button)
		{
			DlgBase<XGuildGrowthLabView, XGuildGrowthLabBehavior>.singleton.SetVisible(true, true);
			return true;
		}

		private bool OnClickBuilderBtn(IXUIButton button)
		{
			DlgBase<XGuildGrowthBuffView, XGuildGrowthBuffBehavior>.singleton.SetVisible(true, true);
			return true;
		}

		private XGuildGrowthDocument _doc;
	}
}
