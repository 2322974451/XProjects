using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class GuildDragonChallengeResultView : DlgBase<GuildDragonChallengeResultView, GuildDragonChallengeResultBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/Comcotinue";
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

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
			this._Doc._GuildDragonChallengeResultView = this;
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_ReturnBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReturn));
		}

		private void OnReturn(IXUISprite sp)
		{
			this._Doc.ReqQutiScene();
		}

		private XGuildDragonDocument _Doc;
	}
}
