using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BCF RID: 3023
	public class ChatGroupItem : MonoBehaviour
	{
		// Token: 0x0600AC52 RID: 44114 RVA: 0x001FB100 File Offset: 0x001F9300
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

		// Token: 0x0600AC53 RID: 44115 RVA: 0x001FB208 File Offset: 0x001F9408
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

		// Token: 0x0600AC54 RID: 44116 RVA: 0x001FB340 File Offset: 0x001F9540
		public void OnItemClick(IXUISprite spr)
		{
			DlgBase<XChatView, XChatBehaviour>.singleton.ChatGroupId = spr.ID;
			DlgBase<XChatView, XChatBehaviour>.singleton.JumpToGroupChat(spr);
		}

		// Token: 0x040040E2 RID: 16610
		private CBrifGroupInfo data;

		// Token: 0x040040E3 RID: 16611
		public IXUILabel m_lblName;

		// Token: 0x040040E4 RID: 16612
		public IXUILabel m_lblCnt;

		// Token: 0x040040E5 RID: 16613
		public IXUILabel m_lblDate;

		// Token: 0x040040E6 RID: 16614
		public IXUILabel m_lblRoleName;

		// Token: 0x040040E7 RID: 16615
		public IXUILabelSymbol m_lblChat;

		// Token: 0x040040E8 RID: 16616
		public IXUISprite m_sprRedpoint;

		// Token: 0x040040E9 RID: 16617
		public IXUISprite m_sprRoot;
	}
}
