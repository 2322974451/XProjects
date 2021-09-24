using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	public class ChatGroupItem : MonoBehaviour
	{

		private void Awake()
		{
			this.m_lblName = (base.transform.FindChild("info/name").GetComponent("XUILabel") as IXUILabel);
			this.m_lblCnt = (base.transform.FindChild("info/cnt").GetComponent("XUILabel") as IXUILabel);
			this.m_lblDate = (base.transform.FindChild("info/time").GetComponent("XUILabel") as IXUILabel);
			this.m_lblRoleName = (base.transform.FindChild("info/role").GetComponent("XUILabel") as IXUILabel);
			this.m_lblChat = (base.transform.FindChild("info/chat").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_sprRedpoint = (base.transform.FindChild("redpoint").GetComponent("XUISprite") as IXUISprite);
			this.m_sprRoot = (base.transform.GetComponent("XUISprite") as IXUISprite);
		}

		public void Refresh(CBrifGroupInfo d)
		{
			this.data = d;
			this.m_lblName.SetText(d.name);
			DateTime msgtime = d.msgtime;
			TimeSpan timeSpan = DateTime.Now - msgtime;
			string text = string.Format("{0:D2}:{1:D2}:{2:D2}", msgtime.Hour, msgtime.Minute, msgtime.Second);
			bool flag = timeSpan.Days > 0;
			if (flag)
			{
				text = XStringDefineProxy.GetString("CHAT_DAY", new object[]
				{
					timeSpan.Days
				});
			}
			this.m_lblDate.SetText(text);
			this.m_lblCnt.SetText(XStringDefineProxy.GetString("CHAT_GROUP_MEMBER", new object[]
			{
				d.memberCnt.ToString()
			}));
			this.m_lblRoleName.SetText(d.rolename);
			this.m_lblChat.InputText = DlgBase<ChatEmotionView, ChatEmotionBehaviour>.singleton.OnParseEmotion(d.chat);
			this.m_sprRedpoint.SetVisible(false);
			this.m_sprRoot.ID = this.data.id;
			this.m_sprRoot.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClick));
		}

		public void OnItemClick(IXUISprite spr)
		{
			DlgBase<XChatView, XChatBehaviour>.singleton.ChatGroupId = spr.ID;
			DlgBase<XChatView, XChatBehaviour>.singleton.JumpToGroupChat(spr);
		}

		private CBrifGroupInfo data;

		public IXUILabel m_lblName;

		public IXUILabel m_lblCnt;

		public IXUILabel m_lblDate;

		public IXUILabel m_lblRoleName;

		public IXUILabelSymbol m_lblChat;

		public IXUISprite m_sprRedpoint;

		public IXUISprite m_sprRoot;
	}
}
