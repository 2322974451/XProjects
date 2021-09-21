using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000E22 RID: 3618
	internal class XChatSettingView : DlgBase<XChatSettingView, XChatSettingBehaviour>
	{
		// Token: 0x17003411 RID: 13329
		// (get) Token: 0x0600C26F RID: 49775 RVA: 0x0029D1F0 File Offset: 0x0029B3F0
		public override string fileName
		{
			get
			{
				return "GameSystem/ChatSettingDlg";
			}
		}

		// Token: 0x0600C270 RID: 49776 RVA: 0x0029D208 File Offset: 0x0029B408
		public XChatSettingView()
		{
			this.m_EnableChannel.Add(ChatChannelType.World);
			this.m_EnableChannel.Add(ChatChannelType.Guild);
			this.m_EnableChannel.Add(ChatChannelType.System);
			this.m_EnableChannel.Add(ChatChannelType.Team);
			this.m_EnableChannel.Add(ChatChannelType.Friends);
			this.m_EnableChannel.Add(ChatChannelType.Spectate);
		}

		// Token: 0x17003412 RID: 13330
		// (get) Token: 0x0600C271 RID: 49777 RVA: 0x0029D280 File Offset: 0x0029B480
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003413 RID: 13331
		// (get) Token: 0x0600C272 RID: 49778 RVA: 0x0029D294 File Offset: 0x0029B494
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C273 RID: 49779 RVA: 0x0029D2A8 File Offset: 0x0029B4A8
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			this._doc.ChatSettingView = this;
			base.uiBehaviour.m_WorldChat.bChecked = true;
			base.uiBehaviour.m_GuildChat.bChecked = true;
			base.uiBehaviour.m_FriendsChat.bChecked = true;
			base.uiBehaviour.m_TeamChat.bChecked = true;
			base.uiBehaviour.m_SystemChat.bChecked = true;
		}

		// Token: 0x0600C274 RID: 49780 RVA: 0x0029D330 File Offset: 0x0029B530
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_WorldChat.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCheckChannel));
			base.uiBehaviour.m_GuildChat.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCheckChannel));
			base.uiBehaviour.m_FriendsChat.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCheckChannel));
			base.uiBehaviour.m_TeamChat.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCheckChannel));
			base.uiBehaviour.m_SystemChat.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnCheckChannel));
			base.uiBehaviour.m_BackClick.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600C275 RID: 49781 RVA: 0x0029D409 File Offset: 0x0029B609
		protected override void OnUnload()
		{
			base.OnUnload();
			this._doc = null;
		}

		// Token: 0x0600C276 RID: 49782 RVA: 0x0029D41C File Offset: 0x0029B61C
		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600C277 RID: 49783 RVA: 0x0029D438 File Offset: 0x0029B638
		public bool IsChannelEnable(ChatChannelType type)
		{
			for (int i = 0; i < this.m_EnableChannel.Count; i++)
			{
				bool flag = this.m_EnableChannel[i] == type;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600C278 RID: 49784 RVA: 0x0029D47C File Offset: 0x0029B67C
		public bool OnCheckChannel(IXUICheckBox cb)
		{
			ChatChannelType chatChannelType = (ChatChannelType)cb.ID;
			bool bChecked = cb.bChecked;
			if (bChecked)
			{
				bool flag = false;
				for (int i = 0; i < this.m_EnableChannel.Count; i++)
				{
					bool flag2 = this.m_EnableChannel[i] == chatChannelType;
					if (flag2)
					{
						flag = true;
					}
				}
				bool flag3 = !flag;
				if (flag3)
				{
					this.m_EnableChannel.Add(chatChannelType);
				}
			}
			else
			{
				for (int j = 0; j < this.m_EnableChannel.Count; j++)
				{
					bool flag4 = this.m_EnableChannel[j] == chatChannelType;
					if (flag4)
					{
						this.m_EnableChannel.RemoveAt(j);
						break;
					}
				}
			}
			return true;
		}

		// Token: 0x04005374 RID: 21364
		private XChatDocument _doc = null;

		// Token: 0x04005375 RID: 21365
		public List<ChatChannelType> m_EnableChannel = new List<ChatChannelType>();
	}
}
