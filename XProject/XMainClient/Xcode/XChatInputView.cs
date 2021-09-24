using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XChatInputView : DlgBase<XChatInputView, XChatInputBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/ChatInput";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public void ShowChatInput(ChatInputStringBack func)
		{
			this._func = func;
			this.SetVisible(true, true);
		}

		protected override void Init()
		{
			base.Init();
			this._tips = XStringDefineProxy.GetString("ChatInput_DefaultTips");
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_BlackBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCanCelBlackClick));
			base.uiBehaviour.m_SendBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSendBtnClick));
			base.uiBehaviour.m_btnChatpic.RegisterClickEventHandler(new ButtonClickEventHandler(this.OpenEmotion));
		}

		protected override void OnShow()
		{
			this.TextInit();
		}

		protected override void OnHide()
		{
			this.inputType = ChatInputType.TEXT;
			this.SetInputType(this.inputType);
			base.OnHide();
		}

		public void SetInputType(ChatInputType type)
		{
			this.inputType = type;
			base.uiBehaviour.m_btnChatpic.SetVisible(type == ChatInputType.EMOTION);
		}

		public void SetCharacterLimit(int num)
		{
			base.uiBehaviour.m_TextInput.SetCharacterLimit(num);
		}

		private void OnCanCelBlackClick(IXUISprite iSp)
		{
			this.TextInit();
			this.SetVisible(false, true);
		}

		private bool OnSendBtnClick(IXUIButton btn)
		{
			bool flag = this._func != null;
			if (flag)
			{
				this._func(base.uiBehaviour.m_TextInput.GetText());
			}
			this.SetVisible(false, true);
			return true;
		}

		private void TextInit()
		{
			base.uiBehaviour.m_TextInput.SetText("");
			base.uiBehaviour.m_ShowLabel.SetText(this._tips);
		}

		private bool OpenEmotion(IXUIButton btn)
		{
			DlgBase<ChatEmotionView, ChatEmotionBehaviour>.singleton.ShowChatEmotion(new ChatSelectStringBack(this.OnSelectEmotion), new Vector3(16f, 143f, 0f), 0);
			return true;
		}

		public void OnSelectEmotion(string motionstr)
		{
			string text = base.uiBehaviour.m_TextInput.GetText();
			text += motionstr;
			base.uiBehaviour.m_TextInput.SetText(text);
		}

		private string _tips;

		private ChatInputStringBack _func = null;

		public ChatInputType inputType = ChatInputType.TEXT;
	}
}
