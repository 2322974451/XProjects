using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CBF RID: 3263
	internal class ChatAssistView : DlgBase<ChatAssistView, ChatAssistBehaviour>
	{
		// Token: 0x1700326E RID: 12910
		// (get) Token: 0x0600B757 RID: 46935 RVA: 0x00247F00 File Offset: 0x00246100
		public override string fileName
		{
			get
			{
				return "GameSystem/ChatAssistDlg";
			}
		}

		// Token: 0x1700326F RID: 12911
		// (get) Token: 0x0600B758 RID: 46936 RVA: 0x00247F18 File Offset: 0x00246118
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003270 RID: 12912
		// (get) Token: 0x0600B759 RID: 46937 RVA: 0x00247F2C File Offset: 0x0024612C
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600B75A RID: 46938 RVA: 0x00247F40 File Offset: 0x00246140
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

		// Token: 0x0600B75B RID: 46939 RVA: 0x002480C8 File Offset: 0x002462C8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnEmotion.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEmotionClick));
			base.uiBehaviour.m_btnHistory.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHistoryClick));
			base.uiBehaviour.m_sprBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClosePanel));
		}

		// Token: 0x0600B75C RID: 46940 RVA: 0x00248134 File Offset: 0x00246334
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.transform.localPosition = new Vector3(-292f, -84f, 0f);
		}

		// Token: 0x0600B75D RID: 46941 RVA: 0x00248163 File Offset: 0x00246363
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B75E RID: 46942 RVA: 0x00248170 File Offset: 0x00246370
		public void Close(string str)
		{
			bool flag = this.m_func != null;
			if (flag)
			{
				this.m_func(str);
			}
			this.SetVisible(false, true);
		}

		// Token: 0x0600B75F RID: 46943 RVA: 0x002481A1 File Offset: 0x002463A1
		public void Show(ChatInputStringBack func, ChatAssetType type)
		{
			this.SetVisible(true, true);
			this.assetType = type;
			this.m_func = func;
			this.Toggle(type);
		}

		// Token: 0x0600B760 RID: 46944 RVA: 0x002481C4 File Offset: 0x002463C4
		private bool OnEmotionClick(IXUIButton btn)
		{
			this.Toggle(ChatAssetType.EMOTION);
			return true;
		}

		// Token: 0x0600B761 RID: 46945 RVA: 0x002481E0 File Offset: 0x002463E0
		private bool OnHistoryClick(IXUIButton btn)
		{
			this.Toggle(ChatAssetType.HISTOTY);
			return true;
		}

		// Token: 0x0600B762 RID: 46946 RVA: 0x002481FC File Offset: 0x002463FC
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

		// Token: 0x0600B763 RID: 46947 RVA: 0x0024827C File Offset: 0x0024647C
		private void SetTabActive(GameObject go, bool active)
		{
			GameObject gameObject = go.transform.Find("InActivated").gameObject;
			GameObject gameObject2 = go.transform.Find("Activated").gameObject;
			gameObject.SetActive(!active);
			gameObject2.SetActive(active);
		}

		// Token: 0x0600B764 RID: 46948 RVA: 0x002482CC File Offset: 0x002464CC
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

		// Token: 0x0600B765 RID: 46949 RVA: 0x00248328 File Offset: 0x00246528
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

		// Token: 0x0600B766 RID: 46950 RVA: 0x002483C4 File Offset: 0x002465C4
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

		// Token: 0x0600B767 RID: 46951 RVA: 0x0024840F File Offset: 0x0024660F
		private void ClosePanel(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x04004808 RID: 18440
		private ChatInputStringBack m_func = null;

		// Token: 0x04004809 RID: 18441
		public ChatAssetType assetType = ChatAssetType.EMOTION;

		// Token: 0x0400480A RID: 18442
		private string m_Emotion = "fsbq_";

		// Token: 0x0400480B RID: 18443
		private string m_EmotionText = "z";

		// Token: 0x0400480C RID: 18444
		private const int CHAT_MAX_EMOTION_NUM = 24;
	}
}
