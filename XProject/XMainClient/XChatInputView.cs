using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000CCA RID: 3274
	internal class XChatInputView : DlgBase<XChatInputView, XChatInputBehaviour>
	{
		// Token: 0x17003273 RID: 12915
		// (get) Token: 0x0600B797 RID: 46999 RVA: 0x00249FCC File Offset: 0x002481CC
		public override string fileName
		{
			get
			{
				return "Common/ChatInput";
			}
		}

		// Token: 0x17003274 RID: 12916
		// (get) Token: 0x0600B798 RID: 47000 RVA: 0x00249FE4 File Offset: 0x002481E4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B799 RID: 47001 RVA: 0x00249FF7 File Offset: 0x002481F7
		public void ShowChatInput(ChatInputStringBack func)
		{
			this._func = func;
			this.SetVisible(true, true);
		}

		// Token: 0x0600B79A RID: 47002 RVA: 0x0024A00A File Offset: 0x0024820A
		protected override void Init()
		{
			base.Init();
			this._tips = XStringDefineProxy.GetString("ChatInput_DefaultTips");
		}

		// Token: 0x0600B79B RID: 47003 RVA: 0x0024A024 File Offset: 0x00248224
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_BlackBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCanCelBlackClick));
			base.uiBehaviour.m_SendBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSendBtnClick));
			base.uiBehaviour.m_btnChatpic.RegisterClickEventHandler(new ButtonClickEventHandler(this.OpenEmotion));
		}

		// Token: 0x0600B79C RID: 47004 RVA: 0x0024A090 File Offset: 0x00248290
		protected override void OnShow()
		{
			this.TextInit();
		}

		// Token: 0x0600B79D RID: 47005 RVA: 0x0024A09A File Offset: 0x0024829A
		protected override void OnHide()
		{
			this.inputType = ChatInputType.TEXT;
			this.SetInputType(this.inputType);
			base.OnHide();
		}

		// Token: 0x0600B79E RID: 47006 RVA: 0x0024A0B8 File Offset: 0x002482B8
		public void SetInputType(ChatInputType type)
		{
			this.inputType = type;
			base.uiBehaviour.m_btnChatpic.SetVisible(type == ChatInputType.EMOTION);
		}

		// Token: 0x0600B79F RID: 47007 RVA: 0x0024A0D7 File Offset: 0x002482D7
		public void SetCharacterLimit(int num)
		{
			base.uiBehaviour.m_TextInput.SetCharacterLimit(num);
		}

		// Token: 0x0600B7A0 RID: 47008 RVA: 0x0024A0EC File Offset: 0x002482EC
		private void OnCanCelBlackClick(IXUISprite iSp)
		{
			this.TextInit();
			this.SetVisible(false, true);
		}

		// Token: 0x0600B7A1 RID: 47009 RVA: 0x0024A100 File Offset: 0x00248300
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

		// Token: 0x0600B7A2 RID: 47010 RVA: 0x0024A145 File Offset: 0x00248345
		private void TextInit()
		{
			base.uiBehaviour.m_TextInput.SetText("");
			base.uiBehaviour.m_ShowLabel.SetText(this._tips);
		}

		// Token: 0x0600B7A3 RID: 47011 RVA: 0x0024A178 File Offset: 0x00248378
		private bool OpenEmotion(IXUIButton btn)
		{
			DlgBase<ChatEmotionView, ChatEmotionBehaviour>.singleton.ShowChatEmotion(new ChatSelectStringBack(this.OnSelectEmotion), new Vector3(16f, 143f, 0f), 0);
			return true;
		}

		// Token: 0x0600B7A4 RID: 47012 RVA: 0x0024A1B8 File Offset: 0x002483B8
		public void OnSelectEmotion(string motionstr)
		{
			string text = base.uiBehaviour.m_TextInput.GetText();
			text += motionstr;
			base.uiBehaviour.m_TextInput.SetText(text);
		}

		// Token: 0x04004842 RID: 18498
		private string _tips;

		// Token: 0x04004843 RID: 18499
		private ChatInputStringBack _func = null;

		// Token: 0x04004844 RID: 18500
		public ChatInputType inputType = ChatInputType.TEXT;
	}
}
