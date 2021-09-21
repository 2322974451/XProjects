using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000CC6 RID: 3270
	public class ChatSystemItem : MonoBehaviour
	{
		// Token: 0x0600B78E RID: 46990 RVA: 0x00249DD0 File Offset: 0x00247FD0
		private void Awake()
		{
			this.m_sprRoot = (base.GetComponent("XUISprite") as IXUISprite);
			this.m_transTitle = base.transform.FindChild("title");
			this.m_symContent = (base.transform.FindChild("title/content").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_lblContent = (this.m_symContent.gameObject.GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600B78F RID: 46991 RVA: 0x00249E50 File Offset: 0x00248050
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

		// Token: 0x04004834 RID: 18484
		private IXUILabelSymbol m_symContent;

		// Token: 0x04004835 RID: 18485
		private ChatInfo mChatInfo;

		// Token: 0x04004836 RID: 18486
		private IXUISprite m_sprRoot;

		// Token: 0x04004837 RID: 18487
		private IXUILabel m_lblContent;

		// Token: 0x04004838 RID: 18488
		private Transform m_transTitle;
	}
}
