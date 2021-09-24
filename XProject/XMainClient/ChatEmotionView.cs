using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class ChatEmotionView : DlgBase<ChatEmotionView, ChatEmotionBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/ChatEmotion";
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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_sprP.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.CloseEmotion));
		}

		public void ShowChatEmotion(ChatSelectStringBack func, Vector3 pos, int pivot)
		{
			this._func = func;
			this.SetVisible(true, true);
			base.uiBehaviour.m_sprEmotion.gameObject.transform.localPosition = pos;
			this.SetPivot(pivot);
		}

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

		private void CloseEmotion(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

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

		private string m_Emotion = "fsbq_";

		private string m_EmotionText = "z";

		private const int CHAT_MAX_EMOTION_NUM = 24;

		private ChatSelectStringBack _func = null;

		private List<string> emotion = new List<string>();
	}
}
