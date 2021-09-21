using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000CC2 RID: 3266
	internal class ChatEmotionView : DlgBase<ChatEmotionView, ChatEmotionBehaviour>
	{
		// Token: 0x17003271 RID: 12913
		// (get) Token: 0x0600B771 RID: 46961 RVA: 0x00248548 File Offset: 0x00246748
		public override string fileName
		{
			get
			{
				return "Common/ChatEmotion";
			}
		}

		// Token: 0x17003272 RID: 12914
		// (get) Token: 0x0600B772 RID: 46962 RVA: 0x00248560 File Offset: 0x00246760
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B773 RID: 46963 RVA: 0x00248574 File Offset: 0x00246774
		protected override void Init()
		{
			base.Init();
			string[] array = new string[]
			{
				"z",
				"g",
				"f"
			};
			this.m_Emotion = "@2x";
			this.m_EmotionText = array[0];
			for (int i = 0; i < 24; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_ChatEmotionPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_ChatEmotionPool.TplPos.x + (float)(i % 6 * base.uiBehaviour.m_ChatEmotionPool.TplWidth), base.uiBehaviour.m_ChatEmotionPool.TplPos.y - (float)(i / 6 * base.uiBehaviour.m_ChatEmotionPool.TplHeight), base.uiBehaviour.m_ChatEmotionPool.TplPos.z);
				IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(string.Format("{0:D3}", i) + this.m_Emotion);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectEmotion));
				ixuisprite.ID = (ulong)((long)i);
			}
		}

		// Token: 0x0600B774 RID: 46964 RVA: 0x002486B9 File Offset: 0x002468B9
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_sprP.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.CloseEmotion));
		}

		// Token: 0x0600B775 RID: 46965 RVA: 0x002486E0 File Offset: 0x002468E0
		public void ShowChatEmotion(ChatSelectStringBack func, Vector3 pos, int pivot)
		{
			this._func = func;
			this.SetVisible(true, true);
			base.uiBehaviour.m_sprEmotion.gameObject.transform.localPosition = pos;
			this.SetPivot(pivot);
		}

		// Token: 0x0600B776 RID: 46966 RVA: 0x00248718 File Offset: 0x00246918
		public void SetPivot(int pivot)
		{
			bool flag = pivot == 0;
			if (flag)
			{
				this.m_uiBehaviour.m_sprEmotion.SetFlipVertical(false);
			}
			else
			{
				bool flag2 = pivot == 1;
				if (flag2)
				{
					this.m_uiBehaviour.m_sprEmotion.SetFlipHorizontal(true);
				}
				else
				{
					bool flag3 = pivot == 2;
					if (flag3)
					{
						this.m_uiBehaviour.m_sprEmotion.SetFlipVertical(true);
					}
				}
			}
		}

		// Token: 0x0600B777 RID: 46967 RVA: 0x00248778 File Offset: 0x00246978
		private void CloseEmotion(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x0600B778 RID: 46968 RVA: 0x00248784 File Offset: 0x00246984
		public void OnSelectEmotion(IXUISprite sp)
		{
			ulong id = sp.ID;
			string str = "/" + this.m_EmotionText + string.Format("{0:D2}", id);
			bool flag = this._func != null;
			if (flag)
			{
				this._func(str);
			}
			this.CloseEmotion(sp);
		}

		// Token: 0x0600B779 RID: 46969 RVA: 0x002487DC File Offset: 0x002469DC
		public string OnParseEmotion(string content)
		{
			this.emotion.Clear();
			for (int i = 0; i < content.Length; i++)
			{
				bool flag = content[i] == '/' && i + 4 <= content.Length;
				if (flag)
				{
					string s = content[i + 2].Equals('0') ? content.Substring(i + 3, 1) : content.Substring(i + 2, 2);
					int num = 0;
					bool flag2 = int.TryParse(s, out num);
					if (flag2)
					{
						bool flag3 = num < 24;
						if (flag3)
						{
							this.emotion.Add(content.Substring(i, 4));
						}
					}
				}
			}
			for (int j = 0; j < this.emotion.Count; j++)
			{
				string text = this.emotion[j];
				bool flag4 = text[1] == 'z' || text[1] == 'g' || text[1] == 'f';
				if (flag4)
				{
					string str = "@2x";
					string sprite = "0" + text.Substring(2, 2) + str;
					string newValue = XLabelSymbolHelper.FormatImage("Chat/Chat", sprite);
					content = content.Replace(text, newValue);
				}
			}
			return content;
		}

		// Token: 0x0600B77A RID: 46970 RVA: 0x00248938 File Offset: 0x00246B38
		public string OnRemoveEmotion(string content)
		{
			this.emotion.Clear();
			for (int i = 0; i < content.Length; i++)
			{
				bool flag = content[i] == '/' && i + 4 <= content.Length;
				if (flag)
				{
					string s = content[i + 2].Equals('0') ? content.Substring(i + 3, 1) : content.Substring(i + 2, 2);
					int num = 0;
					bool flag2 = int.TryParse(s, out num);
					if (flag2)
					{
						bool flag3 = num < 24;
						if (flag3)
						{
							this.emotion.Add(content.Substring(i, 4));
						}
					}
				}
			}
			for (int j = 0; j < this.emotion.Count; j++)
			{
				string text = this.emotion[j];
				bool flag4 = text[1] == 'z' || text[1] == 'g' || text[1] == 'f';
				if (flag4)
				{
					content = content.Replace(text, string.Empty);
				}
			}
			return content;
		}

		// Token: 0x04004810 RID: 18448
		private string m_Emotion = "fsbq_";

		// Token: 0x04004811 RID: 18449
		private string m_EmotionText = "z";

		// Token: 0x04004812 RID: 18450
		private const int CHAT_MAX_EMOTION_NUM = 24;

		// Token: 0x04004813 RID: 18451
		private ChatSelectStringBack _func = null;

		// Token: 0x04004814 RID: 18452
		private List<string> emotion = new List<string>();
	}
}
