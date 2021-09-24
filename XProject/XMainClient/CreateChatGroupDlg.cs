using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	public class CreateChatGroupDlg : DlgBase<CreateChatGroupDlg, CreateChatGroupBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/ChatCreateDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 100;
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		public void SetCallBack(CreatechatGroupCall handle)
		{
			this.callback = handle;
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_OKButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoOK));
			base.uiBehaviour.m_sprClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.DoCancel));
		}

		private bool DoOK(IXUIButton go)
		{
			string text = base.uiBehaviour.m_Label.GetText();
			bool flag = this.callback != null && this.callback(text);
			if (flag)
			{
				this.SetVisible(false, true);
			}
			return true;
		}

		private void DoCancel(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

		private CreatechatGroupCall callback;
	}
}
