using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	public class ChatHistoryItem : MonoBehaviour
	{

		private void Awake()
		{
			this.m_symbol = (base.transform.FindChild("Content").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
		}

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

		public void OnClick()
		{
			DlgBase<ChatAssistView, ChatAssistBehaviour>.singleton.Close(this.mStr);
		}

		private const int LENGTH = 60;

		private IXUILabelSymbol m_symbol;

		private string mStr;
	}
}
