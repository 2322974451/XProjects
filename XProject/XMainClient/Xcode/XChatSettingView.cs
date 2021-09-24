using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XChatSettingView : DlgBase<XChatSettingView, XChatSettingBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/ChatSettingDlg";
			}
		}

		public XChatSettingView()
		{
			this.m_EnableChannel.Add(ChatChannelType.World);
			this.m_EnableChannel.Add(ChatChannelType.Guild);
			this.m_EnableChannel.Add(ChatChannelType.System);
			this.m_EnableChannel.Add(ChatChannelType.Team);
			this.m_EnableChannel.Add(ChatChannelType.Friends);
			this.m_EnableChannel.Add(ChatChannelType.Spectate);
		}

		public override int group
		{
			get
			{
				return 1;
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
			this._doc = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			this._doc.ChatSettingView = this;
			base.uiBehaviour.m_WorldChat.bChecked = true;
			base.uiBehaviour.m_GuildChat.bChecked = true;
			base.uiBehaviour.m_FriendsChat.bChecked = true;
			base.uiBehaviour.m_TeamChat.bChecked = true;
			base.uiBehaviour.m_SystemChat.bChecked = true;
		}

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

		protected override void OnUnload()
		{
			base.OnUnload();
			this._doc = null;
		}

		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

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

		private XChatDocument _doc = null;

		public List<ChatChannelType> m_EnableChannel = new List<ChatChannelType>();
	}
}
