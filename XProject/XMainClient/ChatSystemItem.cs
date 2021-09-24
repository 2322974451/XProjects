using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	public class ChatSystemItem : MonoBehaviour
	{

		private void Awake()
		{
			this.m_sprRoot = (base.GetComponent("XUISprite") as IXUISprite);
			this.m_transTitle = base.transform.FindChild("title");
			this.m_symContent = (base.transform.FindChild("title/content").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_lblContent = (this.m_symContent.gameObject.GetComponent("XUILabel") as IXUILabel);
		}

		public void Refresh(ChatInfo info)
		{
			this.mChatInfo = info;
			this.m_symContent.InputText = DlgBase<ChatEmotionView, ChatEmotionBehaviour>.singleton.OnParseEmotion(info.mContent);
			XLabelSymbolHelper.RegisterHyperLinkClicks(this.m_symContent);
			this.m_sprRoot.spriteHeight = 56 + this.m_lblContent.spriteHeight;
			int spriteHeight = this.m_sprRoot.spriteHeight;
			float num = (float)spriteHeight / 2f - 23f;
			this.m_transTitle.localPosition = new Vector3(-180f, num, 0f);
		}

		private IXUILabelSymbol m_symContent;

		private ChatInfo mChatInfo;

		private IXUISprite m_sprRoot;

		private IXUILabel m_lblContent;

		private Transform m_transTitle;
	}
}
