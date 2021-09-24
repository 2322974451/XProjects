using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ChatAssistView : DlgBase<ChatAssistView, ChatAssistBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/ChatAssistDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
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
				gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_ChatEmotionPool.TplPos.x + (float)(i % 8 * (base.uiBehaviour.m_ChatEmotionPool.TplWidth + 2)), base.uiBehaviour.m_ChatEmotionPool.TplPos.y - (float)(i / 8 * (base.uiBehaviour.m_ChatEmotionPool.TplHeight + 4)), base.uiBehaviour.m_ChatEmotionPool.TplPos.z);
				IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(string.Format("{0:D3}", i) + this.m_Emotion);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectEmotion));
				ixuisprite.ID = (ulong)((long)i);
			}
			GameObject tpl = base.uiBehaviour.m_loophistoryView.GetTpl();
			bool flag = tpl != null && tpl.GetComponent<ChatHistoryItem>() == null;
			if (flag)
			{
				tpl.AddComponent<ChatHistoryItem>();
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnEmotion.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEmotionClick));
			base.uiBehaviour.m_btnHistory.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHistoryClick));
			base.uiBehaviour.m_sprBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClosePanel));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.transform.localPosition = new Vector3(-292f, -84f, 0f);
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public void Close(string str)
		{
			bool flag = this.m_func != null;
			if (flag)
			{
				this.m_func(str);
			}
			this.SetVisible(false, true);
		}

		public void Show(ChatInputStringBack func, ChatAssetType type)
		{
			this.SetVisible(true, true);
			this.assetType = type;
			this.m_func = func;
			this.Toggle(type);
		}

		private bool OnEmotionClick(IXUIButton btn)
		{
			this.Toggle(ChatAssetType.EMOTION);
			return true;
		}

		private bool OnHistoryClick(IXUIButton btn)
		{
			this.Toggle(ChatAssetType.HISTOTY);
			return true;
		}

		private void Toggle(ChatAssetType type)
		{
			base.uiBehaviour.m_objEmotion.SetActive(type == ChatAssetType.EMOTION);
			base.uiBehaviour.m_objHistory.SetActive(type == ChatAssetType.HISTOTY);
			this.SetTabActive(base.uiBehaviour.m_btnEmotion.gameObject, type == ChatAssetType.EMOTION);
			this.SetTabActive(base.uiBehaviour.m_btnHistory.gameObject, type == ChatAssetType.HISTOTY);
			bool flag = type == ChatAssetType.HISTOTY;
			if (flag)
			{
				this.RefreshHistoryList();
			}
		}

		private void SetTabActive(GameObject go, bool active)
		{
			GameObject gameObject = go.transform.Find("InActivated").gameObject;
			GameObject gameObject2 = go.transform.Find("Activated").gameObject;
			gameObject.SetActive(!active);
			gameObject2.SetActive(active);
		}

		private void OnSelectEmotion(IXUISprite sp)
		{
			ulong id = sp.ID;
			string str = "/" + this.m_EmotionText + string.Format("{0:D2}", id);
			bool flag = this.m_func != null;
			if (flag)
			{
				this.m_func(str);
			}
			this.SetVisible(false, true);
		}

		private void RefreshHistoryList()
		{
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			List<string> recentSendmsg = specificDocument.recentSendmsg;
			List<LoopItemData> list = new List<LoopItemData>();
			for (int i = recentSendmsg.Count - 1; i >= 0; i--)
			{
				RecentMsg recentMsg = new RecentMsg();
				recentMsg.content = recentSendmsg[i];
				recentMsg.LoopID = XSingleton<XCommon>.singleton.XHash(recentMsg.content);
				list.Add(recentMsg);
			}
			base.uiBehaviour.m_loophistoryView.Init(list, new DelegateHandler(this.RefreshHistoryItem), null, 0, false);
		}

		private void RefreshHistoryItem(ILoopItemObject item, LoopItemData data)
		{
			RecentMsg recentMsg = data as RecentMsg;
			bool flag = recentMsg != null;
			if (flag)
			{
				item.GetObj().GetComponent<ChatHistoryItem>().Refresh(recentMsg.content);
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("history info is null", null, null, null, null, null);
			}
		}

		private void ClosePanel(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

		private ChatInputStringBack m_func = null;

		public ChatAssetType assetType = ChatAssetType.EMOTION;

		private string m_Emotion = "fsbq_";

		private string m_EmotionText = "z";

		private const int CHAT_MAX_EMOTION_NUM = 24;
	}
}
