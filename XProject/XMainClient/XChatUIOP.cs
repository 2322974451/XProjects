using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XChatUIOP : XSingleton<XChatUIOP>
	{

		private XChatView m_ChatView
		{
			get
			{
				return DlgBase<XChatView, XChatBehaviour>.singleton;
			}
		}

		public Comparison<ChatFriendData> CompareNewMsgCb
		{
			get
			{
				bool flag = this.m_CompareNewMsg == null;
				if (flag)
				{
					this.m_CompareNewMsg = new Comparison<ChatFriendData>(this.CompareNewMsg);
				}
				return this.m_CompareNewMsg;
			}
		}

		public XChatDocument _doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			}
		}

		public ChatFriendData CurrChatFriendData
		{
			get
			{
				return this._doc.FindFriendData(this.m_ChatView.ChatFriendId);
			}
		}

		private int CompareNewMsg(ChatFriendData a, ChatFriendData b)
		{
			int num = b.msgtime.CompareTo(a.msgtime);
			int num2 = b.isOnline.CompareTo(a.isOnline);
			int num3 = b.degreelevel.CompareTo(a.degreelevel);
			bool flag = num != 0;
			int result;
			if (flag)
			{
				result = num;
			}
			else
			{
				bool flag2 = num2 != 0;
				if (flag2)
				{
					result = num2;
				}
				else
				{
					bool flag3 = num3 != 0;
					if (flag3)
					{
						result = num3;
					}
					else
					{
						result = b.roleid.CompareTo(a.roleid);
					}
				}
			}
			return result;
		}

		public void RefreshFriendChat(XFriendData friendData, bool refreshUI)
		{
			ChatFriendData chatFriendData = this._doc.FindFriendData(friendData.roleid);
			bool flag = chatFriendData != null;
			if (flag)
			{
				chatFriendData.isfriend = true;
			}
			else
			{
				chatFriendData = new ChatFriendData();
				chatFriendData.isfriend = true;
				chatFriendData.name = friendData.name;
				chatFriendData.powerpoint = friendData.powerpoint;
				chatFriendData.profession = friendData.profession;
				chatFriendData.roleid = friendData.roleid;
				chatFriendData.viplevel = friendData.viplevel;
				chatFriendData.online = friendData.online;
				chatFriendData.setid = friendData.setid;
				chatFriendData.msgtime = this._doc.GetFriendChatInfoTime(chatFriendData.roleid);
				this._doc.ChatFriendList.Add(chatFriendData);
			}
			if (refreshUI)
			{
				DlgBase<XChatView, XChatBehaviour>.singleton.RefreshFriendUI();
			}
		}

		public void RefreshAudioUI(ChatInfo info)
		{
			bool flag = !this.m_ChatView.IsVisible();
			if (!flag)
			{
				bool flag2 = info.mUIObject == null;
				if (!flag2)
				{
					Transform transform = info.mUIObject.transform.FindChild("sign");
					IXUISpriteAnimation ixuispriteAnimation = transform.GetComponent("XUISpriteAnimation") as IXUISpriteAnimation;
					ixuispriteAnimation.SetFrameRate(5);
					IXUISprite ixuisprite = info.mUIObject.transform.FindChild("redpoint").GetComponent("XUISprite") as IXUISprite;
					info.isUIShowed = true;
					ixuisprite.SetVisible(false);
					XSingleton<XTimerMgr>.singleton.SetTimer((float)info.AudioIntTime / 1000f, new XTimerMgr.ElapsedEventHandler(this.OnStopSignPlay), ixuispriteAnimation);
				}
			}
		}

		public void RefreshVoiceUI(ChatInfo info)
		{
			XRadioDocument specificDocument = XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
			specificDocument.MuteSounds(true);
			XSingleton<XChatIFlyMgr>.singleton.InsertAutoPlayList(info, false);
			this.RefreshAudioUI(info);
		}

		public void OnStopSignPlay(object ob)
		{
			IXUISpriteAnimation ixuispriteAnimation = (IXUISpriteAnimation)ob;
			bool flag = ixuispriteAnimation != null;
			if (flag)
			{
				ixuispriteAnimation.SetFrameRate(0);
				ixuispriteAnimation.Reset();
			}
		}

		public void OnStartPlayAudio(IXUISprite sp)
		{
			int id = (int)sp.ID;
			ChatInfo chatInfoById = this._doc.GetChatInfoById(id);
			bool flag = chatInfoById == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("chatinfo is null ", id.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				XSingleton<XChatIFlyMgr>.singleton.ClearPlayList();
				bool isAudioPlayed = chatInfoById.isAudioPlayed;
				if (isAudioPlayed)
				{
					this.RefreshVoiceUI(chatInfoById);
				}
				else
				{
					bool flag2 = chatInfoById.mChannelId == ChatChannelType.World || chatInfoById.mChannelId == ChatChannelType.Guild;
					if (flag2)
					{
						List<ChatInfo> chatInfoList = this._doc.GetChatInfoList(chatInfoById.mChannelId);
						List<ChatInfo> list = new List<ChatInfo>();
						for (int i = 0; i < chatInfoList.Count; i++)
						{
							bool flag3 = chatInfoList[i].mTime.CompareTo(chatInfoById.mTime) >= 0 && chatInfoList[i].isAudioChat && !chatInfoList[i].isAudioPlayed;
							if (flag3)
							{
								list.Add(chatInfoList[i]);
							}
						}
						XSingleton<XChatIFlyMgr>.singleton.AutoPlayAudioList = list;
						XSingleton<XChatIFlyMgr>.singleton.StartAutoPlay(true, true);
					}
					else
					{
						bool flag4 = chatInfoById.mChannelId == ChatChannelType.Friends;
						if (flag4)
						{
							List<ChatInfo> friendChatInfoList = this._doc.GetFriendChatInfoList(chatInfoById.mSenderId);
							List<ChatInfo> list2 = new List<ChatInfo>();
							for (int j = 0; j < friendChatInfoList.Count; j++)
							{
								bool flag5 = friendChatInfoList[j].mTime.CompareTo(chatInfoById.mTime) >= 0 && friendChatInfoList[j].isAudioChat && !friendChatInfoList[j].isAudioPlayed;
								if (flag5)
								{
									list2.Add(friendChatInfoList[j]);
								}
							}
							XSingleton<XChatIFlyMgr>.singleton.AutoPlayAudioList = list2;
							XSingleton<XChatIFlyMgr>.singleton.StartAutoPlay(true, true);
						}
					}
				}
			}
		}

		public bool OnSendFlowerClicked(IXUIButton btn)
		{
			int id = (int)btn.ID;
			ChatInfo chatInfoById = this._doc.GetChatInfoById(id);
			bool flag = chatInfoById == null;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("[OnSendFlowerClicked]chatinfo is null, " + id.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
				result = false;
			}
			else
			{
				DlgBase<XFlowerSendView, XFlowerSendBehaviour>.singleton.ShowBoard(chatInfoById.mSenderId, chatInfoById.mSenderName);
				result = true;
			}
			return result;
		}

		private Comparison<ChatFriendData> m_CompareNewMsg = null;
	}
}
