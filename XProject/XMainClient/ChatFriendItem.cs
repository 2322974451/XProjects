using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CC4 RID: 3268
	public class ChatFriendItem : MonoBehaviour
	{
		// Token: 0x0600B77E RID: 46974 RVA: 0x00248B4C File Offset: 0x00246D4C
		private void Awake()
		{
			this.m_sprRoot = (base.GetComponent("XUISprite") as IXUISprite);
			this.m_sprHead = (base.transform.FindChild("headboard/head").GetComponent("XUISprite") as IXUISprite);
			this.m_sprFrame = (base.transform.FindChild("headboard/head/AvatarFrame").GetComponent("XUISprite") as IXUISprite);
			this.m_sprRedpoint = (base.transform.FindChild("msg/redpoint").GetComponent("XUISprite") as IXUISprite);
			this.m_lblName = (base.transform.FindChild("info/name").GetComponent("XUILabel") as IXUILabel);
			this.m_lblMsg = (base.transform.FindChild("info/lv").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_sprRelation = (base.transform.FindChild("relation").GetComponent("XUISprite") as IXUISprite);
			this.m_sprChat = (base.transform.Find("msg").GetComponent("XUISprite") as IXUISprite);
			this.m_sprHeadColl = (base.transform.FindChild("headboard").GetComponent("XUISprite") as IXUISprite);
			this.m_sprDel = (base.transform.FindChild("Del").GetComponent("XUISprite") as IXUISprite);
			this.m_sprChat.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChatClick));
		}

		// Token: 0x0600B77F RID: 46975 RVA: 0x00248CD8 File Offset: 0x00246ED8
		public void Refresh(ChatFriendData data)
		{
			this.mFriendData = data;
			this.m_lblName.SetText(data.name);
			string text = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)data.profession);
			bool flag = text == "";
			if (flag)
			{
				text = "TXicon_01";
			}
			this.m_sprHead.SetSprite(text);
			this.m_sprRelation.SetVisible(this.mFriendData.isfriend);
			this.m_sprRelation.SetSprite(this.GetRelation());
			this.m_lblMsg.InputText = this.GetRecentChatInfo(data.roleid);
			this.m_sprRedpoint.SetVisible(DlgBase<XChatView, XChatBehaviour>.singleton.HasRedpointMsg(data.roleid));
			this.m_sprHeadColl.ID = data.roleid;
			this.m_sprHeadColl.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickFriendHead));
			this.m_sprDel.ID = data.roleid;
			this.m_sprDel.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnDeleteChat));
			XSingleton<UiUtility>.singleton.ParseHeadIcon(data.setid, this.m_sprFrame);
		}

		// Token: 0x0600B780 RID: 46976 RVA: 0x00248DFC File Offset: 0x00246FFC
		private string GetRecentChatInfo(ulong roleid)
		{
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			List<ChatInfo> friendChatInfoList = specificDocument.GetFriendChatInfoList(roleid);
			bool flag = friendChatInfoList == null || friendChatInfoList.Count <= 0;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				string mContent = friendChatInfoList[friendChatInfoList.Count - 1].mContent;
				string text = DlgBase<ChatEmotionView, ChatEmotionBehaviour>.singleton.OnParseEmotion(mContent);
				int num = text.IndexOf("im=Chat");
				bool flag2 = num > -1 && num < 12;
				int num2 = 21;
				int num3 = flag2 ? 30 : 12;
				bool flag3 = flag2;
				if (flag3)
				{
					bool flag4 = text.Length > num3 && text.Length > num + num2;
					if (flag4)
					{
						text = text.Substring(0, num + num2) + "...";
					}
				}
				else
				{
					bool flag5 = text.Length >= num3 - 3;
					if (flag5)
					{
						text = text.Substring(0, num3 - 3) + "...";
					}
				}
				result = text;
			}
			return result;
		}

		// Token: 0x0600B781 RID: 46977 RVA: 0x00248F08 File Offset: 0x00247108
		private string GetRelation()
		{
			bool isfriend = this.mFriendData.isfriend;
			string result;
			if (isfriend)
			{
				result = "tag_friend";
			}
			else
			{
				result = "tag_guild";
			}
			return result;
		}

		// Token: 0x0600B782 RID: 46978 RVA: 0x00248F38 File Offset: 0x00247138
		private void OnChatClick(IXUISprite spr)
		{
			spr.ID = this.mFriendData.roleid;
			bool flag = DlgBase<XChatView, XChatBehaviour>.singleton.HasRedpointMsg(spr.ID);
			bool flag2 = flag;
			if (flag2)
			{
				PtcC2M_OpenPrivateChatNtf ptcC2M_OpenPrivateChatNtf = new PtcC2M_OpenPrivateChatNtf();
				ptcC2M_OpenPrivateChatNtf.Data.roleid = spr.ID;
				XSingleton<XClientNetwork>.singleton.Send(ptcC2M_OpenPrivateChatNtf);
			}
			DlgBase<XChatView, XChatBehaviour>.singleton.JumpToChats(spr);
		}

		// Token: 0x0600B783 RID: 46979 RVA: 0x00248FA0 File Offset: 0x002471A0
		private void OnDeleteChat(IXUISprite spr)
		{
			DlgBase<XChatView, XChatBehaviour>.singleton.OnSendClearFriend(spr.ID);
		}

		// Token: 0x0600B784 RID: 46980 RVA: 0x00248FB4 File Offset: 0x002471B4
		private void OnClickFriendHead(IXUISprite sp)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				DlgBase<XChatView, XChatBehaviour>.singleton.ChatFriendId = this.mFriendData.roleid;
				XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
				ChatFriendData chatFriendData = specificDocument.FindFriendData(sp.ID);
				bool flag2 = chatFriendData != null;
				if (flag2)
				{
					XCharacterCommonMenuDocument.ReqCharacterMenuInfo(chatFriendData.roleid, false);
				}
			}
		}

		// Token: 0x04004819 RID: 18457
		private ChatFriendData mFriendData;

		// Token: 0x0400481A RID: 18458
		public IXUISprite m_sprRoot;

		// Token: 0x0400481B RID: 18459
		public IXUILabel m_lblName;

		// Token: 0x0400481C RID: 18460
		public IXUISprite m_sprHead;

		// Token: 0x0400481D RID: 18461
		public IXUISprite m_sprFrame;

		// Token: 0x0400481E RID: 18462
		public IXUILabelSymbol m_lblMsg;

		// Token: 0x0400481F RID: 18463
		public IXUISprite m_sprRelation;

		// Token: 0x04004820 RID: 18464
		public IXUISprite m_sprChat;

		// Token: 0x04004821 RID: 18465
		public IXUISprite m_sprRedpoint;

		// Token: 0x04004822 RID: 18466
		public IXUISprite m_sprHeadColl;

		// Token: 0x04004823 RID: 18467
		public IXUISprite m_sprDel;
	}
}
