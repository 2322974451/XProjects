using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000CC0 RID: 3264
	public class ChatHistoryItem : MonoBehaviour
	{
		// Token: 0x0600B769 RID: 46953 RVA: 0x00248448 File Offset: 0x00246648
		private void Awake()
		{
			this.m_symbol = (base.transform.FindChild("Content").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
		}

		// Token: 0x0600B76A RID: 46954 RVA: 0x00248470 File Offset: 0x00246670
		public void Refresh(string chat)
		{
			this.mStr = chat;
			string text = DlgBase<ChatEmotionView, ChatEmotionBehaviour>.singleton.OnParseEmotion(chat);
			int num = text.IndexOf("im=Chat");
			bool flag = num > -1 && num < 12;
			int num2 = 21;
			int num3 = flag ? 30 : 12;
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = text.Length > num3 && text.Length > num + num2;
				if (flag3)
				{
					text = text.Substring(0, num + num2) + "...";
				}
			}
			else
			{
				bool flag4 = text.Length >= num3 - 3;
				if (flag4)
				{
					text = text.Substring(0, num3 - 3) + "...";
				}
			}
			this.m_symbol.InputText = text;
		}

		// Token: 0x0600B76B RID: 46955 RVA: 0x00248532 File Offset: 0x00246732
		public void OnClick()
		{
			DlgBase<ChatAssistView, ChatAssistBehaviour>.singleton.Close(this.mStr);
		}

		// Token: 0x0400480D RID: 18445
		private const int LENGTH = 60;

		// Token: 0x0400480E RID: 18446
		private IXUILabelSymbol m_symbol;

		// Token: 0x0400480F RID: 18447
		private string mStr;
	}
}
