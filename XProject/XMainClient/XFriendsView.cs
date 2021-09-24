using System;
using System.Collections.Generic;
using KKSG;
using MiniJSON;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFriendsView : DlgBase<XFriendsView, XFriendsBehaviour>
	{

		public uint TodaySendLeft
		{
			get
			{
				return this.m_TodaySendLeft;
			}
		}

		public uint TodayReceiveLeft
		{
			get
			{
				return this.m_TodayReceiveLeft;
			}
		}

		public uint TodaySendCount
		{
			get
			{
				return XSingleton<XFriendsStaticData>.singleton.SendGiftMaxTimes - this.m_TodaySendLeft;
			}
		}

		public uint TodayReceiveCount
		{
			get
			{
				return XSingleton<XFriendsStaticData>.singleton.ReceiveGifMaxTimes - this.m_TodayReceiveLeft;
			}
		}

		public bool Redpoint
		{
			get
			{
				for (int i = 0; i < this.mRedpoint.Length; i++)
				{
					bool flag = this.mRedpoint[i];
					if (flag)
					{
						return true;
					}
				}
				return this.canSendGift;
			}
		}

		private int GetTabIndexInt(TabIndex index)
		{
			return XFastEnumIntEqualityComparer<TabIndex>.ToInt(index);
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/FriendsDlg";
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			this.m_FriendListTempView = new XPlayerInfoChildView();
			this.m_FriendsViewHintFrame = base.uiBehaviour.transform.Find("Bg/FriendHintFrame").gameObject;
			DlgHandlerBase.EnsureCreate<XFriendsViewHintHandler>(ref this.m_FriendsViewHintHandler, this.m_FriendsViewHintFrame, null, false);
			this.m_FriendsViewAddBlockFrame = base.uiBehaviour.transform.Find("Bg/FriendAddBlockFrame").gameObject;
			DlgHandlerBase.EnsureCreate<XFriendsViewAddBlockHandler>(ref this.m_FriendsViewAddBlockHandler, this.m_FriendsViewAddBlockFrame, null, false);
			this.m_FriendsViewReceiveGiftFrame = base.uiBehaviour.transform.Find("Bg/FriendGiftFrame").gameObject;
			DlgHandlerBase.EnsureCreate<XFriendsViewReceiveGiftHandler>(ref this.m_FriendsViewReceiveGiftHandler, this.m_FriendsViewReceiveGiftFrame, null, false);
			this.m_FriendsRankFrame = base.uiBehaviour.transform.Find("Bg/FriendsRank").gameObject;
			DlgHandlerBase.EnsureCreate<XFriendsRankHandler>(ref this.m_FriendsRankHandler, this.m_FriendsRankFrame, null, false);
			DlgHandlerBase.EnsureCreate<PartnerMainHandler>(ref this.m_partnerMainHandler, base.uiBehaviour.transform.Find("Bg"), false, this);
			DlgHandlerBase.EnsureCreate<FriendsWeddingHandler>(ref this.m_weddingMainHandler, base.uiBehaviour.transform.Find("Bg"), false, this);
			DlgHandlerBase.EnsureCreate<XMentorshipPupilsHandler>(ref this.m_mentorshipHandler, base.uiBehaviour.transform.Find("Bg"), false, this);
			DlgHandlerBase.EnsureCreate<XDragonPartnerHandler>(ref this.m_dragonPartnerHandler, base.uiBehaviour.transform.Find("Bg"), false, this);
			DlgHandlerBase.EnsureCreate<XDragonGuildMainHandler>(ref this.m_dragonGuildMainHandler, base.uiBehaviour.transform.Find("Bg"), false, this);
			DlgHandlerBase.EnsureCreate<XDragonGuildListHandler>(ref this.m_dragonGuildListHandler, base.uiBehaviour.transform.Find("Bg"), false, this);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClose));
			base.uiBehaviour.btnRight.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickButtonR));
			base.uiBehaviour.btnLeft.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickButtonL));
			base.uiBehaviour.btnHint.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCkickHint));
			base.uiBehaviour.FriendListWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._RankWrapFriendListUpdated));
		}

		protected override void OnShow()
		{
			base.OnShow();
			PtcC2M_FriendQueryReportNew ptcC2M_FriendQueryReportNew = new PtcC2M_FriendQueryReportNew();
			ptcC2M_FriendQueryReportNew.Data.op = FriendOpType.Friend_GiftInfo;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_FriendQueryReportNew);
			this.canSendGift = false;
			this.m_FriendListTitleHeight = (base.uiBehaviour.goFriendListTitle.transform.Find("T1").Find("P").GetComponent("XUISprite") as IXUISprite).spriteHeight;
			base.uiBehaviour.FriendTabPool.FakeReturnAll();
			int i = 0;
			while (i < XFriendsDocument.FriendsTabCount)
			{
				FriendSysConfigTable.RowData friendsTabItemByIndex = XFriendsDocument.GetFriendsTabItemByIndex(i);
				bool isOpen = friendsTabItemByIndex.IsOpen;
				if (isOpen)
				{
					TabIndex tabIndex = (TabIndex)(friendsTabItemByIndex.TabID - 1);
					bool flag = tabIndex == TabIndex.QQFriend && XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_QQ;
					if (!flag)
					{
						bool flag2 = tabIndex == TabIndex.WeChatFriend && XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_WeChat;
						if (!flag2)
						{
							bool flag3 = tabIndex == TabIndex.Mentorship && !XSingleton<XGameSysMgr>.singleton.IsSystemOpen(75);
							if (!flag3)
							{
								bool flag4 = tabIndex == TabIndex.Partner && !XSingleton<XGameSysMgr>.singleton.IsSystemOpen(700);
								if (!flag4)
								{
									bool flag5 = tabIndex == TabIndex.Wedding && !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Wedding);
									if (!flag5)
									{
										bool flag6 = tabIndex == TabIndex.DragonPartner && !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Activity_DragonNest);
										if (!flag6)
										{
											bool flag7 = tabIndex == TabIndex.DragonGuild && !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_GuildCollectSummon);
											if (!flag7)
											{
												GameObject gameObject = base.uiBehaviour.FriendTabPool.FetchGameObject(false);
												IXUICheckBox ixuicheckBox = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
												ixuicheckBox.ID = (ulong)((long)(friendsTabItemByIndex.TabID - 1));
												ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnClickTab));
												IXUISprite ixuisprite = gameObject.transform.Find("P").GetComponent("XUISprite") as IXUISprite;
												ixuisprite.spriteName = friendsTabItemByIndex.Icon;
												IXUILabel ixuilabel = gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel;
												ixuilabel.SetText(friendsTabItemByIndex.TabName);
												IXUILabel ixuilabel2 = gameObject.transform.Find("Selected/T").GetComponent("XUILabel") as IXUILabel;
												ixuilabel2.SetText(friendsTabItemByIndex.TabName);
												IXUISprite ixuisprite2 = gameObject.transform.Find("Selected/P").GetComponent("XUISprite") as IXUISprite;
												ixuisprite2.spriteName = friendsTabItemByIndex.Icon;
												bool flag8 = tabIndex == this.m_CurrentTabIndex;
												if (flag8)
												{
													bool bChecked = ixuicheckBox.bChecked;
													if (bChecked)
													{
														this.OnClickTab(ixuicheckBox);
													}
													else
													{
														ixuicheckBox.ForceSetFlag(true);
													}
												}
												else
												{
													ixuicheckBox.ForceSetFlag(false);
												}
												this.mRedpointUI[friendsTabItemByIndex.TabID - 1] = gameObject.transform.Find("RedPoint").gameObject;
											}
										}
									}
								}
							}
						}
					}
				}
				IL_314:
				i++;
				continue;
				goto IL_314;
			}
			base.uiBehaviour.FriendTabPool.ActualReturnAll(false);
			this.SetRedPoint(TabIndex.Mentorship, XMentorshipDocument.Doc.IsHasRedDot());
			this.SetTabRedpoint(TabIndex.Partner, XPartnerDocument.Doc.IsHadRedDot);
			this.UpdateRedpointUI();
			base.uiBehaviour.TabList.Refresh();
			this.RefreshFriendList(true);
			this.QueryRoleState();
			this._doc.ReqPlatFriendsRank();
		}

		protected override void OnHide()
		{
			base.OnHide();
			bool flag = this.m_CurrentTabIndex == TabIndex.Partner;
			if (flag)
			{
				this.m_partnerMainHandler.SetVisible(false);
			}
			bool flag2 = this.m_CurrentTabIndex == TabIndex.Mentorship;
			if (flag2)
			{
				this.MentorshipHandler.SetVisible(false);
			}
			bool flag3 = this.m_CurrentTabIndex == TabIndex.Wedding;
			if (flag3)
			{
				this.m_weddingMainHandler.SetVisible(false);
			}
			bool flag4 = this.m_FriendsRankHandler != null;
			if (flag4)
			{
				this.m_FriendsRankHandler.ClearPreTabTextures();
			}
			bool flag5 = this.m_CurrentTabIndex == TabIndex.DragonPartner;
			if (flag5)
			{
				this.m_dragonPartnerHandler.SetVisible(false);
			}
			bool flag6 = this.m_CurrentTabIndex == TabIndex.DragonGuild;
			if (flag6)
			{
				bool flag7 = this.m_dragonGuildMainHandler.IsVisible();
				if (flag7)
				{
					this.m_dragonGuildMainHandler.SetVisible(false);
				}
				bool flag8 = this.m_dragonGuildListHandler.IsVisible();
				if (flag8)
				{
					this.m_dragonGuildListHandler.SetVisible(false);
				}
			}
		}

		protected override void OnUnload()
		{
			this.m_FriendListTempView = null;
			this._doc = null;
			for (int i = 0; i < this.mRedpointUI.Length; i++)
			{
				this.mRedpointUI[i] = null;
			}
			DlgHandlerBase.EnsureUnload<XFriendsViewHintHandler>(ref this.m_FriendsViewHintHandler);
			this.m_FriendsViewHintFrame = null;
			DlgHandlerBase.EnsureUnload<XFriendsViewAddBlockHandler>(ref this.m_FriendsViewAddBlockHandler);
			this.m_FriendsViewAddBlockFrame = null;
			DlgHandlerBase.EnsureUnload<XFriendsViewReceiveGiftHandler>(ref this.m_FriendsViewReceiveGiftHandler);
			this.m_FriendsViewReceiveGiftFrame = null;
			DlgHandlerBase.EnsureUnload<XFriendsRankHandler>(ref this.m_FriendsRankHandler);
			this.m_FriendsRankHandler = null;
			base.uiBehaviour.FriendTabPool.ReturnAll(false);
			DlgHandlerBase.EnsureUnload<PartnerMainHandler>(ref this.m_partnerMainHandler);
			DlgHandlerBase.EnsureUnload<XMentorshipPupilsHandler>(ref this.m_mentorshipHandler);
			DlgHandlerBase.EnsureUnload<FriendsWeddingHandler>(ref this.m_weddingMainHandler);
			DlgHandlerBase.EnsureUnload<XDragonPartnerHandler>(ref this.m_dragonPartnerHandler);
			DlgHandlerBase.EnsureUnload<XDragonGuildMainHandler>(ref this.m_dragonGuildMainHandler);
			DlgHandlerBase.EnsureUnload<XDragonGuildListHandler>(ref this.m_dragonGuildListHandler);
			base.OnUnload();
		}

		public void OnRefreshPlatFriendsRank()
		{
			bool flag = !base.IsVisible() || this.m_FriendsRankHandler == null;
			if (!flag)
			{
				this.m_FriendsRankHandler.RefreshRankList();
			}
		}

		public void OnRefreshSendGiftState(PlatFriendRankInfo2Client info)
		{
			bool flag = !base.IsVisible() || this.m_FriendsRankHandler == null;
			if (!flag)
			{
				this.m_FriendsRankHandler.OnRefreshSendGiftState(info);
			}
		}

		public void NoticeFriend(string openID)
		{
			bool flag = !base.IsVisible() || this.m_FriendsRankHandler == null;
			if (!flag)
			{
				this.m_FriendsRankHandler.NoticeFriend(openID);
			}
		}

		public bool OnClickClose(IXUIButton sp)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		public void ShowTab(XSysDefine sys)
		{
			if (sys <= XSysDefine.XSys_Partner)
			{
				if (sys != XSysDefine.XSys_Mentorship)
				{
					if (sys == XSysDefine.XSys_Partner)
					{
						this.m_CurrentTabIndex = TabIndex.Partner;
					}
				}
				else
				{
					this.m_CurrentTabIndex = TabIndex.Mentorship;
				}
			}
			else if (sys != XSysDefine.XSys_Wedding)
			{
				if (sys == XSysDefine.XSys_GuildCollectSummon)
				{
					this.m_CurrentTabIndex = TabIndex.DragonGuild;
				}
			}
			else
			{
				this.m_CurrentTabIndex = TabIndex.Wedding;
			}
			this.SetVisible(true, true);
		}

		private void SetTabRedpoint(TabIndex index, bool redpoint)
		{
			int tabIndexInt = this.GetTabIndexInt(index);
			this.mRedpoint[tabIndexInt] = redpoint;
			bool flag = this.mRedpointUI[tabIndexInt] != null;
			if (flag)
			{
				this.mRedpointUI[tabIndexInt].SetActive(redpoint);
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Friends, true);
		}

		public void SetRedPoint(TabIndex index, bool repoint)
		{
			int tabIndexInt = this.GetTabIndexInt(index);
			bool flag = tabIndexInt < this.mRedpoint.Length;
			if (flag)
			{
				this.mRedpoint[tabIndexInt] = repoint;
			}
		}

		private bool OnClickTab(IXUICheckBox cbx)
		{
			bool bChecked = cbx.bChecked;
			if (bChecked)
			{
				this.m_CurrentTabIndex = (TabIndex)cbx.ID;
				this._ApplyTabData(this.m_CurrentTabIndex);
			}
			return true;
		}

		public void UpdateRedpointUI()
		{
			for (int i = 0; i < this.mRedpointUI.Length; i++)
			{
				bool flag = null != this.mRedpointUI[i];
				if (flag)
				{
					this.mRedpointUI[i].SetActive(this.mRedpoint[i]);
				}
			}
		}

		public void OnShowFriendDlg()
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
		}

		public XFriendData GetFriendDataById(ulong uid)
		{
			for (int i = 0; i < this.friendData.Count; i++)
			{
				bool flag = this.friendData[i].roleid == uid;
				if (flag)
				{
					return this.friendData[i];
				}
			}
			return null;
		}

		public XFriendData GetFriendDataByName(string name)
		{
			for (int i = 0; i < this.friendData.Count; i++)
			{
				bool flag = this.friendData[i].name == name;
				if (flag)
				{
					return this.friendData[i];
				}
			}
			return null;
		}

		public XFriendData GetBlockFriendDataById(ulong uid)
		{
			for (int i = 0; i < this.blockFriendData.Count; i++)
			{
				bool flag = this.blockFriendData[i].roleid == uid;
				if (flag)
				{
					return this.blockFriendData[i];
				}
			}
			return null;
		}

		public XFriendData GetBlockFriendDataByName(string name)
		{
			for (int i = 0; i < this.blockFriendData.Count; i++)
			{
				bool flag = this.blockFriendData[i].name == name;
				if (flag)
				{
					return this.blockFriendData[i];
				}
			}
			return null;
		}

		public List<XFriendData> GetFriendData()
		{
			return this.friendData;
		}

		public bool OnClickSendGiftToFriend(IXUIButton btn)
		{
			RpcC2M_FriendGiftOpNew rpcC2M_FriendGiftOpNew = new RpcC2M_FriendGiftOpNew();
			rpcC2M_FriendGiftOpNew.oArg.op = FriendOpType.Friend_SendGift;
			rpcC2M_FriendGiftOpNew.oArg.roleid.Add(btn.ID);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_FriendGiftOpNew);
			return true;
		}

		public bool OnClickReceiveGiftFromFriend(IXUIButton btn)
		{
			bool flag = this.m_TodayReceiveLeft > 0U;
			if (flag)
			{
				RpcC2M_FriendGiftOpNew rpcC2M_FriendGiftOpNew = new RpcC2M_FriendGiftOpNew();
				rpcC2M_FriendGiftOpNew.oArg.op = FriendOpType.Friend_TakeGift;
				rpcC2M_FriendGiftOpNew.oArg.roleid.Add(btn.ID);
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_FriendGiftOpNew);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_RECEIVE_ZERO_LEFT"), "fece00");
			}
			return true;
		}

		public bool OnClickSendGiftToFriendNotAvaliable(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XFriendsStaticData>.singleton.CannotSendGiftToFriendHintText, "fece00");
			return true;
		}

		public string GetFriendNameById(ulong uid)
		{
			for (int i = 0; i < this.friendData.Count; i++)
			{
				bool flag = this.friendData[i].roleid == uid;
				if (flag)
				{
					return this.friendData[i].name;
				}
			}
			return "";
		}

		public string GetBlockFriendNameById(ulong uid)
		{
			for (int i = 0; i < this.blockFriendData.Count; i++)
			{
				bool flag = this.blockFriendData[i].roleid == uid;
				if (flag)
				{
					return this.blockFriendData[i].name;
				}
			}
			return "";
		}

		private bool OnClickButtonR(IXUIButton sp)
		{
			TabIndex currentTabIndex = this.m_CurrentTabIndex;
			switch (currentTabIndex)
			{
			case TabIndex.ShowFriend:
				DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RandomFriend();
				return true;
			case TabIndex.ApplyFriend:
			{
				bool flag = this.applyData.Count > 0;
				if (flag)
				{
					RpcC2M_DoAddFriendNew rpcC2M_DoAddFriendNew = new RpcC2M_DoAddFriendNew();
					for (int i = 0; i < this.applyData.Count; i++)
					{
						rpcC2M_DoAddFriendNew.oArg.roleid.Add(this.applyData[i].roleid);
					}
					rpcC2M_DoAddFriendNew.oArg.op = FriendOpType.Friend_AgreeApply;
					XSingleton<XClientNetwork>.singleton.Send(rpcC2M_DoAddFriendNew);
				}
				return true;
			}
			case TabIndex.DragonPartner:
				break;
			case TabIndex.WeChatFriend:
				DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RandomFriend();
				return true;
			default:
				if (currentTabIndex == TabIndex.BlockFriend)
				{
					this.m_FriendsViewAddBlockHandler.SetVisible(true);
					return true;
				}
				break;
			}
			XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_UNKNOWN, "fece00");
			return true;
		}

		private bool OnClickButtonL(IXUIButton sp)
		{
			TabIndex currentTabIndex = this.m_CurrentTabIndex;
			if (currentTabIndex != TabIndex.ShowFriend)
			{
				if (currentTabIndex != TabIndex.ApplyFriend)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_UNKNOWN, "fece00");
				}
				else
				{
					bool flag = this.applyData.Count > 0;
					if (flag)
					{
						RpcC2M_DoAddFriendNew rpcC2M_DoAddFriendNew = new RpcC2M_DoAddFriendNew();
						for (int i = 0; i < this.applyData.Count; i++)
						{
							rpcC2M_DoAddFriendNew.oArg.roleid.Add(this.applyData[i].roleid);
						}
						rpcC2M_DoAddFriendNew.oArg.op = FriendOpType.Friend_IgnoreApply;
						XSingleton<XClientNetwork>.singleton.Send(rpcC2M_DoAddFriendNew);
					}
				}
			}
			else
			{
				bool flag2 = this.m_FriendsViewReceiveGiftHandler != null;
				if (flag2)
				{
					this.m_FriendsViewReceiveGiftHandler.SetVisible(true);
					this.m_FriendsViewReceiveGiftHandler.RefreshList(this.friendData);
				}
			}
			return true;
		}

		public bool OnClickAddQQFriends(IXUIButton sp)
		{
			ulong id = sp.ID;
			XFriendData friendDataById = this.GetFriendDataById(id);
			XSingleton<UiUtility>.singleton.OneKeyAddQQFriend(friendDataById.openID, friendDataById.nickName);
			return true;
		}

		public bool OnClickChatFriend(IXUIButton sp)
		{
			ulong id = sp.ID;
			bool flag = this.GetBlockFriendDataById(id) != null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_BLOCK_HINT_TEXT"), "fece00");
			}
			else
			{
				XFriendData friendDataById = this.GetFriendDataById(id);
				bool flag2 = friendDataById != null;
				if (flag2)
				{
					ChatFriendData chatFriendData = new ChatFriendData();
					chatFriendData.name = friendDataById.name;
					chatFriendData.roleid = friendDataById.roleid;
					chatFriendData.powerpoint = friendDataById.powerpoint;
					chatFriendData.profession = friendDataById.profession;
					chatFriendData.viplevel = friendDataById.viplevel;
					chatFriendData.isfriend = true;
					chatFriendData.setid = friendDataById.setid;
					chatFriendData.msgtime = DateTime.Now;
					DlgBase<XChatView, XChatBehaviour>.singleton.PrivateChatTo(chatFriendData);
				}
			}
			return true;
		}

		private bool OnClickAgreeApply(IXUIButton sp)
		{
			bool flag = this.GetFriendDataById(sp.ID) != null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_ALREADY_FRIENDS"), "fece00");
			}
			RpcC2M_DoAddFriendNew rpcC2M_DoAddFriendNew = new RpcC2M_DoAddFriendNew();
			rpcC2M_DoAddFriendNew.oArg.roleid.Add(sp.ID);
			rpcC2M_DoAddFriendNew.oArg.op = FriendOpType.Friend_AgreeApply;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_DoAddFriendNew);
			return true;
		}

		public void OnApply(DoAddFriendArg oArg, DoAddFriendRes oRes)
		{
			FriendOpType op = oArg.op;
			if (op != FriendOpType.Friend_AgreeApply)
			{
				if (op == FriendOpType.Friend_IgnoreApply)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_SUCCESS"), "fece00");
				}
			}
			else
			{
				bool flag = oRes.errorcode == ErrorCode.ERR_SUCCESS;
				if (flag)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("RRIENDS_APPLY_AGREE"), "fece00");
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
			}
		}

		private bool OnClickIgnoreApply(IXUIButton sp)
		{
			bool flag = this.GetFriendDataById(sp.ID) != null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_ALREADY_FRIENDS"), "fece00");
			}
			RpcC2M_DoAddFriendNew rpcC2M_DoAddFriendNew = new RpcC2M_DoAddFriendNew();
			rpcC2M_DoAddFriendNew.oArg.roleid.Add(sp.ID);
			rpcC2M_DoAddFriendNew.oArg.op = FriendOpType.Friend_IgnoreApply;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_DoAddFriendNew);
			return true;
		}

		private bool OnCkickHint(IXUIButton sp)
		{
			this.m_FriendsViewHintHandler.SetVisible(true);
			return true;
		}

		private bool DoDeleteFriend(IXUIButton sp)
		{
			this.RemoveFriend(sp.ID);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		public bool OnClickDeleteFriend(IXUIButton sp)
		{
			bool flag = TabIndex.BlockFriend == this.m_CurrentTabIndex;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_BLOCK_HINT_TEXT"), "fece00");
			}
			else
			{
				bool flag2 = this.m_CurrentTabIndex == TabIndex.ShowFriend;
				if (flag2)
				{
					DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.Load();
					DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.m_OKButton.ID = sp.ID;
					XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("FRIENDS_DELETE"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.DoDeleteFriend));
				}
			}
			return true;
		}

		public bool OnRemoveBlockFriend(IXUIButton sp)
		{
			ulong id = sp.ID;
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RemoveBlockFriend(id);
			return true;
		}

		private void OnClickFriendItemPanel(IXUISprite sp)
		{
			ulong id = sp.ID;
			XCharacterCommonMenuDocument.ReqCharacterMenuInfo(id, false);
		}

		public void AddFriendById(ulong id)
		{
			bool flag = id == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_NOT_ADD_SELF"), "fece00");
			}
			else
			{
				RpcC2M_AddFriendNew rpcC2M_AddFriendNew = new RpcC2M_AddFriendNew();
				rpcC2M_AddFriendNew.oArg.friendroleid = id;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_AddFriendNew);
			}
		}

		public void AddFriendByName(string name)
		{
			RpcC2M_AddFriendNew rpcC2M_AddFriendNew = new RpcC2M_AddFriendNew();
			rpcC2M_AddFriendNew.oArg.name = name;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_AddFriendNew);
		}

		public void AddFriendRes(ErrorCode code, ulong uid)
		{
			bool flag = code == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_APPLY_SUCC"), "fece00");
				DlgBase<XFriendsSearchView, XFriendsSearchBehaviour>.singleton.FriendAdded();
			}
			else
			{
				bool flag2 = code == ErrorCode.ERR_FRIEND_REPEATED;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_ALREADY_FRIENDS"), "fece00");
				}
				else
				{
					bool flag3 = code == ErrorCode.ERR_ADDFRIEND_DUMMYROLE;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowErrorCode(code);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(code, "fece00");
					}
				}
			}
		}

		private bool IsNewFirend(XFriendData data)
		{
			for (int i = 0; i < this.friendData.Count; i++)
			{
				bool flag = this.friendData[i].roleid == data.roleid;
				if (flag)
				{
					return false;
				}
			}
			return true;
		}

		public void OnFriendOpNotify(PtcM2C_FriendOpNtfNew roPtc)
		{
			switch (roPtc.Data.op)
			{
			case FriendOpType.Friend_FriendAll:
				this.friendData.Clear();
				for (int i = 0; i < roPtc.Data.friendlist.Count; i++)
				{
					Friend2Client friend2Client = roPtc.Data.friendlist[i];
					XFriendData xfriendData = this.GenerateFriendInfo(friend2Client);
					this.friendData.Add(xfriendData);
					XSingleton<XChatVoiceManager>.singleton.AddSpriteYuYinId(friend2Client.name + "_" + friend2Client.roleid.ToString(), xfriendData.audioid);
				}
				this.QueryRoleState();
				this.CheckGiftSendReceiveState();
				break;
			case FriendOpType.Friend_ApplyAll:
			{
				this.applyData.Clear();
				for (int j = 0; j < roPtc.Data.applylist.Count; j++)
				{
					Friend2Client friend2Client2 = roPtc.Data.applylist[j];
					XFriendData item = this.GenerateFriendInfo(friend2Client2);
					this.applyData.Add(item);
				}
				bool flag = base.IsVisible();
				if (flag)
				{
					this.RefreshFriendList(false);
				}
				this.SetTabRedpoint(TabIndex.ApplyFriend, this.applyData.Count > 0);
				break;
			}
			case FriendOpType.Friend_FriendAdd:
			{
				for (int k = 0; k < roPtc.Data.friendlist.Count; k++)
				{
					Friend2Client friend2Client3 = roPtc.Data.friendlist[k];
					XFriendData xfriendData2 = this.GenerateFriendInfo(friend2Client3);
					bool flag2 = this.IsNewFirend(xfriendData2);
					this.friendData.Add(xfriendData2);
					DlgBase<XChatView, XChatBehaviour>.singleton.ChatDoc.RemoveStranger(friend2Client3.roleid);
					bool flag3 = flag2;
					if (flag3)
					{
						DlgBase<XChatView, XChatBehaviour>.singleton.UIOP.RefreshFriendChat(xfriendData2, false);
					}
					XSingleton<XChatVoiceManager>.singleton.AddSpriteYuYinId(xfriendData2.name + "_" + xfriendData2.roleid.ToString(), xfriendData2.audioid);
				}
				this.SortFriendData();
				bool flag4 = base.IsVisible();
				if (flag4)
				{
					this.RefreshFriendList(false);
					bool flag5 = this.m_FriendsViewReceiveGiftHandler != null && this.m_FriendsViewReceiveGiftHandler.IsVisible();
					if (flag5)
					{
						this.m_FriendsViewReceiveGiftHandler.RefreshList(this.friendData);
					}
				}
				this.CheckGiftSendReceiveState();
				break;
			}
			case FriendOpType.Friend_FriendDelete:
			{
				for (int l = 0; l < this.friendData.Count; l++)
				{
					bool flag6 = false;
					int num = 0;
					while (roPtc.Data.deletelist.Count > 0 && num < roPtc.Data.deletelist.Count)
					{
						bool flag7 = roPtc.Data.deletelist[num] == this.friendData[l].roleid;
						if (flag7)
						{
							flag6 = true;
							int index = roPtc.Data.deletelist.Count - 1;
							roPtc.Data.deletelist[num] = roPtc.Data.deletelist[index];
							roPtc.Data.deletelist.RemoveAt(index);
							break;
						}
						num++;
					}
					bool flag8 = flag6;
					if (flag8)
					{
						int index2 = this.friendData.Count - 1;
						this.friendData[l--] = this.friendData[index2];
						this.friendData.RemoveAt(index2);
					}
				}
				this.SortFriendData();
				bool flag9 = base.IsVisible();
				if (flag9)
				{
					this.RefreshFriendList(false);
					bool flag10 = this.m_FriendsViewReceiveGiftHandler != null && this.m_FriendsViewReceiveGiftHandler.IsVisible();
					if (flag10)
					{
						this.m_FriendsViewReceiveGiftHandler.RefreshList(this.friendData);
					}
				}
				this.CheckGiftSendReceiveState();
				break;
			}
			case FriendOpType.Friend_ApplyAdd:
			{
				for (int m = 0; m < roPtc.Data.applylist.Count; m++)
				{
					Friend2Client friend2Client4 = roPtc.Data.applylist[m];
					XFriendData item2 = this.GenerateFriendInfo(friend2Client4);
					this.applyData.Add(item2);
				}
				bool flag11 = base.IsVisible();
				if (flag11)
				{
					this.RefreshFriendList(false);
					bool flag12 = this.m_FriendsViewReceiveGiftHandler != null && this.m_FriendsViewReceiveGiftHandler.IsVisible();
					if (flag12)
					{
						this.m_FriendsViewReceiveGiftHandler.RefreshList(this.friendData);
					}
				}
				this.SetTabRedpoint(TabIndex.ApplyFriend, this.applyData.Count > 0);
				break;
			}
			case FriendOpType.Friend_ApplyDelete:
			{
				for (int n = 0; n < this.applyData.Count; n++)
				{
					bool flag13 = false;
					int num2 = 0;
					while (roPtc.Data.deleteapplylist.Count > 0 && num2 < roPtc.Data.deleteapplylist.Count)
					{
						bool flag14 = roPtc.Data.deleteapplylist[num2] == this.applyData[n].roleid;
						if (flag14)
						{
							flag13 = true;
							int index3 = roPtc.Data.deleteapplylist.Count - 1;
							roPtc.Data.deleteapplylist[num2] = roPtc.Data.deleteapplylist[index3];
							roPtc.Data.deleteapplylist.RemoveAt(index3);
							break;
						}
						num2++;
					}
					bool flag15 = flag13;
					if (flag15)
					{
						int index4 = this.applyData.Count - 1;
						this.applyData[n--] = this.applyData[index4];
						this.applyData.RemoveAt(index4);
					}
				}
				bool flag16 = base.IsVisible();
				if (flag16)
				{
					this.RefreshFriendList(false);
					bool flag17 = this.m_FriendsViewReceiveGiftHandler != null && this.m_FriendsViewReceiveGiftHandler.IsVisible();
					if (flag17)
					{
						this.m_FriendsViewReceiveGiftHandler.RefreshList(this.friendData);
					}
				}
				this.SetTabRedpoint(TabIndex.ApplyFriend, this.applyData.Count > 0);
				break;
			}
			case FriendOpType.Friend_ReveiveGift:
			{
				for (int num3 = 0; num3 < roPtc.Data.senderid.Count; num3++)
				{
					XFriendData friendDataById = this.GetFriendDataById(roPtc.Data.senderid[num3]);
					bool flag18 = friendDataById != null;
					if (flag18)
					{
						friendDataById.receiveAll += 1U;
						friendDataById.receiveGiftState = (uint)XFastEnumIntEqualityComparer<FriendGiftReceive>.ToInt(FriendGiftReceive.FriendGift_Received);
						friendDataById.receivetime = roPtc.Data.receivedtime[num3];
					}
				}
				bool flag19 = base.IsVisible() && this.m_FriendsViewReceiveGiftHandler != null && this.m_FriendsViewReceiveGiftHandler.IsVisible();
				if (flag19)
				{
					this.m_FriendsViewReceiveGiftHandler.RefreshList(this.friendData);
				}
				this.CheckGiftSendReceiveState();
				break;
			}
			case FriendOpType.Friend_GiftInfo:
				this.m_TodaySendLeft = roPtc.Data.giftcount.SendLeft;
				this.m_TodayReceiveLeft = roPtc.Data.giftcount.ReceiveLeft;
				break;
			}
		}

		private bool _CheckHasGiftToSend()
		{
			this.canSendGift = false;
			uint num = (uint)XFastEnumIntEqualityComparer<FriendGiftSend>.ToInt(FriendGiftSend.FriendGift_Sended);
			for (int i = 0; i < this.friendData.Count; i++)
			{
				bool flag = this.friendData[i].degreeDay >= XSingleton<XFriendsStaticData>.singleton.SendGiftMinDegree && this.friendData[i].sendGiftState != num;
				if (flag)
				{
					this.canSendGift = true;
					break;
				}
			}
			return this.canSendGift;
		}

		private void CheckGiftSendReceiveState()
		{
			bool flag = this._CheckHasGiftToSend();
			bool flag2 = this._CheckHasGiftCanReceive();
			this.SetTabRedpoint(TabIndex.ShowFriend, flag || flag2);
			this.RefreshGiftBtnRedPoint();
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Friends, true);
		}

		public void OnFriendGiftOp(FriendGiftOpArg oArg, FriendGiftOpRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				FriendOpType op = oArg.op;
				if (op != FriendOpType.Friend_SendGift)
				{
					if (op == FriendOpType.Friend_TakeGift)
					{
						this.m_TodayReceiveLeft -= 1U;
						bool flag2 = oArg.roleid != null && oArg.roleid.Count > 0;
						if (flag2)
						{
							XFriendData friendDataById = this.GetFriendDataById(oArg.roleid[0]);
							bool flag3 = friendDataById != null;
							if (flag3)
							{
								friendDataById.receiveGiftState = (uint)XFastEnumIntEqualityComparer<FriendGiftReceive>.ToInt(FriendGiftReceive.FriendGift_ReceiveTaken);
								List<uint> list = new List<uint>();
								list.Add((uint)XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FRIEND_GIFT));
								List<uint> list2 = new List<uint>();
								list2.Add(1U);
								XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XFriendsStaticData>.singleton.GiftSuccessfullyReceiveHintText, this.m_TodayReceiveLeft), "fece00");
							}
							bool flag4 = base.IsVisible() && base.uiBehaviour != null && base.uiBehaviour.FriendListWrapContent != null && this.friendData != null;
							if (flag4)
							{
								base.uiBehaviour.FriendListWrapContent.SetContentCount(this.friendData.Count, false);
							}
							bool flag5 = base.IsVisible() && this.m_FriendsViewReceiveGiftHandler != null && this.m_FriendsViewReceiveGiftHandler.IsVisible();
							if (flag5)
							{
								this.m_FriendsViewReceiveGiftHandler.RefreshList();
							}
							this.CheckGiftSendReceiveState();
							this.ReceiveGiftReply(friendDataById);
						}
					}
				}
				else
				{
					this.m_TodaySendLeft -= 1U;
					bool flag6 = oArg.roleid != null && oArg.roleid.Count > 0;
					if (flag6)
					{
						XFriendData friendDataById2 = this.GetFriendDataById(oArg.roleid[0]);
						bool flag7 = friendDataById2 != null;
						if (flag7)
						{
							friendDataById2.sendGiftState = (uint)XFastEnumIntEqualityComparer<FriendGiftSend>.ToInt(FriendGiftSend.FriendGift_Sended);
							XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XFriendsStaticData>.singleton.GiftSuccessfullySentHintText, this.m_TodaySendLeft), "fece00");
							this.CheckGiftSendReceiveState();
						}
						bool flag8 = base.IsVisible() && this.m_CurrentTabIndex == TabIndex.ShowFriend;
						if (flag8)
						{
							bool flag9 = base.uiBehaviour != null && base.uiBehaviour.FriendListWrapContent != null && this.friendData != null;
							if (flag9)
							{
								base.uiBehaviour.FriendListWrapContent.SetContentCount(this.friendData.Count, false);
							}
						}
						bool flag10 = base.IsVisible() && this.m_FriendsViewReceiveGiftHandler != null && this.m_FriendsViewReceiveGiftHandler.IsVisible();
						if (flag10)
						{
							this.m_FriendsViewReceiveGiftHandler.RefreshList();
						}
					}
				}
			}
		}

		private void ReceiveGiftReply(XFriendData _data)
		{
			ChatInfo chatInfo = new ChatInfo();
			chatInfo.mTime = DateTime.Now;
			chatInfo.isSelfSender = true;
			chatInfo.mReceiverName = _data.name;
			chatInfo.mReceiverId = _data.roleid;
			chatInfo.mReciverPowerPoint = _data.powerpoint;
			chatInfo.mRecieverProfession = _data.profession;
			chatInfo.mReceiverVip = _data.viplevel;
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			specificDocument.AddChatinfo2FriendList(chatInfo);
			DlgBase<XChatView, XChatBehaviour>.singleton.SendExternalFriendChat(XStringDefineProxy.GetString("FRIENDS_RECEIVE_THX"), chatInfo, 0UL, 0f, null);
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_RECEIVE_THX_SEND"), "fece00");
		}

		public void RemoveFriend(ulong id)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.Load();
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.m_OKButton.ID = id;
			XFriendData friendDataById = this.GetFriendDataById(id);
			bool flag = friendDataById != null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("FRIENDS_DELETE", new object[]
				{
					friendDataById.name
				}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.DoDeleteFriendByID));
			}
			else
			{
				this.DoDeleteFriendByID(DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.m_OKButton);
			}
		}

		private bool DoDeleteFriendByID(IXUIButton btn)
		{
			XFriendData friendDataById = this.GetFriendDataById(btn.ID);
			bool flag = friendDataById != null;
			if (flag)
			{
				this.m_DeleteFriendName = friendDataById.name;
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			bool flag2 = this.OnRemoveFriendSucc != null;
			if (flag2)
			{
				this.OnRemoveFriendSucc();
			}
			ulong id = btn.ID;
			RpcC2M_RemoveFriendNew rpcC2M_RemoveFriendNew = new RpcC2M_RemoveFriendNew();
			rpcC2M_RemoveFriendNew.oArg.friendroleid = id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_RemoveFriendNew);
			return true;
		}

		public void RemoveFriendRes(ErrorCode code, ulong roleid)
		{
			for (int i = 0; i < this.friendData.Count; i++)
			{
				bool flag = this.friendData[i].roleid == roleid;
				if (flag)
				{
					DlgBase<XChatView, XChatBehaviour>.singleton.ChatDoc.AddStranger(roleid);
					this.friendData.RemoveAt(i);
					break;
				}
			}
			this.RefreshFriendList(false);
			bool flag2 = this.m_DeleteFriendName != "";
			if (flag2)
			{
				bool flag3 = code == ErrorCode.ERR_SUCCESS;
				if (flag3)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_DEL_SUCC") + this.m_DeleteFriendName, "fece00");
				}
				this.m_DeleteFriendName = "";
			}
			DlgBase<XChatView, XChatBehaviour>.singleton.ChatDoc.RemoveFriend(roleid);
		}

		public void UpdateFriendInfo(ulong uid, uint daydegree, uint alldegree)
		{
			XFriendData friendDataById = this.GetFriendDataById(uid);
			bool flag = friendDataById != null;
			if (flag)
			{
				uint deltaDay = daydegree - friendDataById.degreeDay;
				uint deltaAll = alldegree - friendDataById.degreeAll;
				friendDataById.degreeDay = daydegree;
				friendDataById.degreeAll = alldegree;
				this.CheckGiftSendReceiveState();
				bool flag2 = base.IsVisible() && this.m_CurrentTabIndex == TabIndex.ShowFriend;
				if (flag2)
				{
					bool flag3 = null != friendDataById.friendgo;
					if (flag3)
					{
						this._UpdateFriendDegreeUI(friendDataById.friendgo.transform, friendDataById, deltaDay, deltaAll);
						this._UpdateFriendSendGiftUI(friendDataById.friendgo.transform, friendDataById);
					}
					else
					{
						base.uiBehaviour.FriendListWrapContent.SetContentCount(this.friendData.Count, false);
					}
				}
			}
		}

		public void QueryRoleState()
		{
			PtcC2M_RoleStateReportNew ptcC2M_RoleStateReportNew = new PtcC2M_RoleStateReportNew();
			for (int i = 0; i < this.friendData.Count; i++)
			{
				ptcC2M_RoleStateReportNew.Data.roleid.Add(this.friendData[i].roleid);
			}
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			for (int j = 0; j < specificDocument.ChatFriendList.Count; j++)
			{
				ChatFriendData chatFriendData = specificDocument.ChatFriendList[j];
				bool flag = !ptcC2M_RoleStateReportNew.Data.roleid.Contains(chatFriendData.roleid);
				if (flag)
				{
					ptcC2M_RoleStateReportNew.Data.roleid.Add(chatFriendData.roleid);
				}
			}
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_RoleStateReportNew);
		}

		public void SortFriendData()
		{
			this.friendData.Sort(new Comparison<XFriendData>(this.CompareFriendData));
		}

		public void QueryRoleStateRes(RoleStateNtf rolestate)
		{
			for (int i = 0; i < this.friendData.Count; i++)
			{
				for (int j = 0; j < rolestate.roleid.Count; j++)
				{
					bool flag = rolestate.roleid[j] == this.friendData[i].roleid;
					if (flag)
					{
						this.friendData[i].online = rolestate.state[j];
						this.friendData[i].lastlogin = rolestate.timelastlogin[j];
					}
				}
			}
			this.SortFriendData();
			this.RefreshFriendList(false);
			bool flag2 = base.IsVisible() && this.m_FriendsViewReceiveGiftHandler != null && this.m_FriendsViewReceiveGiftHandler.IsVisible();
			if (flag2)
			{
				this.m_FriendsViewReceiveGiftHandler.RefreshList(this.friendData);
			}
			XFriendListEventArgs @event = XEventPool<XFriendListEventArgs>.GetEvent();
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		private int CompareOfflineTime(uint lastLogin1, uint lastLogin2)
		{
			int num = 0;
			int num2 = 0;
			int value = 0;
			int num3 = 0;
			this.GetOfflineTime((int)lastLogin1, out num, out num2);
			this.GetOfflineTime((int)lastLogin2, out value, out num3);
			bool flag = num2 == num3;
			int result;
			if (flag)
			{
				result = num.CompareTo(value);
			}
			else
			{
				result = num2.CompareTo(num3);
			}
			return result;
		}

		private void GetOfflineTime(int lastlogin, out int number, out int unit)
		{
			bool flag = lastlogin < 60;
			if (flag)
			{
				number = 1;
				unit = 1;
			}
			else
			{
				bool flag2 = lastlogin < 3600;
				if (flag2)
				{
					number = lastlogin / 60;
					unit = 1;
				}
				else
				{
					bool flag3 = lastlogin < 86400;
					if (flag3)
					{
						number = lastlogin / 3600;
						unit = 2;
					}
					else
					{
						bool flag4 = lastlogin < 2678400;
						if (flag4)
						{
							number = lastlogin / 86400;
							unit = 3;
						}
						else
						{
							number = lastlogin / 2592000;
							unit = 4;
						}
					}
				}
			}
		}

		private int CompareFriendData(XFriendData a, XFriendData b)
		{
			bool flag = a.online == 0U && b.online == 0U;
			if (flag)
			{
				int num = this.CompareOfflineTime(a.lastlogin, b.lastlogin);
				bool flag2 = num != 0;
				if (flag2)
				{
					return num;
				}
			}
			else
			{
				bool flag3 = a.online == 0U || b.online == 0U;
				if (flag3)
				{
					return b.online.CompareTo(a.online);
				}
			}
			bool flag4 = b.degreeAll != a.degreeAll;
			int result;
			if (flag4)
			{
				result = b.degreeAll.CompareTo(a.degreeAll);
			}
			else
			{
				bool flag5 = b.level != a.level;
				if (flag5)
				{
					result = b.level.CompareTo(a.level);
				}
				else
				{
					bool flag6 = b.powerpoint != a.powerpoint;
					if (flag6)
					{
						result = b.powerpoint.CompareTo(a.powerpoint);
					}
					else
					{
						result = b.name.CompareTo(a.name);
					}
				}
			}
			return result;
		}

		public int CompareFriendGiftData(XFriendData a, XFriendData b)
		{
			return b.receiveAll.CompareTo(a.receiveAll);
		}

		public void ShowFriends(bool refreshChatUI = false)
		{
			this.m_RefreshFriendChatUI = refreshChatUI;
			this._ApplyTabData(TabIndex.ApplyFriend);
		}

		private int _SetTabNumLabel(TabIndex tab)
		{
			TabIndex currentTabIndex = this.m_CurrentTabIndex;
			int num;
			if (currentTabIndex != TabIndex.ShowFriend)
			{
				if (currentTabIndex != TabIndex.ApplyFriend)
				{
					if (currentTabIndex != TabIndex.BlockFriend)
					{
						num = 0;
					}
					else
					{
						num = this.blockFriendData.Count;
						base.uiBehaviour.goFriendListBrockZero.SetActive(num <= 0);
					}
				}
				else
				{
					num = this.applyData.Count;
				}
			}
			else
			{
				num = this.friendData.Count;
				base.uiBehaviour.goFriendListZero.SetActive(num <= 0);
			}
			FriendSysConfigTable.RowData friendsTabItemByID = XFriendsDocument.GetFriendsTabItemByID(this.GetTabIndexInt(this.m_CurrentTabIndex) + 1);
			int num2 = num;
			bool flag = this.m_CurrentTabIndex == TabIndex.ApplyFriend;
			if (flag)
			{
				num2 = this.friendData.Count;
			}
			base.uiBehaviour.lbFriendsNum.SetText(string.Format(XSingleton<XFriendsStaticData>.singleton.CommonCountTotalFmt, num2, friendsTabItemByID.NumLimit));
			return num;
		}

		private void _ApplyTabData(TabIndex tab)
		{
			bool flag = base.IsVisible();
			bool flag2 = flag;
			if (flag2)
			{
				base.uiBehaviour.btnHint.SetVisible(this.m_CurrentTabIndex == TabIndex.ShowFriend);
				bool flag3 = this.m_CurrentTabIndex == TabIndex.ShowFriend;
				if (flag3)
				{
					base.uiBehaviour.goFriendListTitle.SetActive(true);
				}
				else
				{
					base.uiBehaviour.goFriendListTitle.SetActive(false);
				}
				this.MentorshipHandler.SetVisible(this.m_CurrentTabIndex == TabIndex.Mentorship);
				this.m_FriendsRankHandler.SetVisible(TabIndex.WeChatFriend == this.m_CurrentTabIndex || TabIndex.QQFriend == this.m_CurrentTabIndex);
				bool flag4 = this.m_partnerMainHandler.IsVisible() && TabIndex.Partner != this.m_CurrentTabIndex;
				if (flag4)
				{
					this.m_partnerMainHandler.SetVisible(false);
				}
				this.m_weddingMainHandler.SetVisible(TabIndex.Wedding == this.m_CurrentTabIndex);
				bool flag5 = this.m_dragonPartnerHandler.IsVisible() && TabIndex.DragonPartner != this.m_CurrentTabIndex;
				if (flag5)
				{
					this.m_dragonPartnerHandler.SetVisible(false);
				}
				bool flag6 = this.m_dragonGuildListHandler.IsVisible() && TabIndex.DragonGuild != this.m_CurrentTabIndex;
				if (flag6)
				{
					this.m_dragonGuildListHandler.SetVisible(false);
				}
				bool flag7 = this.m_dragonGuildMainHandler.IsVisible() && TabIndex.DragonGuild != this.m_CurrentTabIndex;
				if (flag7)
				{
					this.m_dragonGuildMainHandler.SetVisible(false);
				}
				base.uiBehaviour.content.gameObject.SetActive(TabIndex.WeChatFriend != this.m_CurrentTabIndex && TabIndex.QQFriend != this.m_CurrentTabIndex);
				base.uiBehaviour.goFriendListZero.SetActive(false);
				base.uiBehaviour.goFriendListBrockZero.SetActive(false);
				FriendSysConfigTable.RowData friendsTabItemByID = XFriendsDocument.GetFriendsTabItemByID(this.GetTabIndexInt(this.m_CurrentTabIndex) + 1);
				base.uiBehaviour.btnLeft.SetVisible(friendsTabItemByID.LButtonLabel.Length > 0);
				base.uiBehaviour.lbButtonL.SetText(friendsTabItemByID.LButtonLabel);
				base.uiBehaviour.btnRight.SetVisible(friendsTabItemByID.RButtonLabel.Length > 0);
				base.uiBehaviour.lbButtonR.SetText(friendsTabItemByID.RButtonLabel);
				base.uiBehaviour.lbFriendsNumLabel.SetText(friendsTabItemByID.NumLabel);
				base.uiBehaviour.lbFriendsNumLabel.SetVisible(friendsTabItemByID.NumLabel.Length > 0);
				base.uiBehaviour.lbFriendsNum.SetVisible(friendsTabItemByID.NumLabel.Length > 0);
				this._SetTabNumLabel(this.m_CurrentTabIndex);
				this.CheckGiftSendReceiveState();
			}
			bool flag8 = flag;
			if (flag8)
			{
				this.RefreshFriendList(false);
			}
			switch (tab)
			{
			case TabIndex.ShowFriend:
			{
				PtcC2M_FriendQueryReportNew ptcC2M_FriendQueryReportNew = new PtcC2M_FriendQueryReportNew();
				ptcC2M_FriendQueryReportNew.Data.op = FriendOpType.Friend_FriendAll;
				XSingleton<XClientNetwork>.singleton.Send(ptcC2M_FriendQueryReportNew);
				break;
			}
			case TabIndex.ApplyFriend:
			{
				PtcC2M_FriendQueryReportNew ptcC2M_FriendQueryReportNew2 = new PtcC2M_FriendQueryReportNew();
				ptcC2M_FriendQueryReportNew2.Data.op = FriendOpType.Friend_ApplyAll;
				XSingleton<XClientNetwork>.singleton.Send(ptcC2M_FriendQueryReportNew2);
				break;
			}
			case TabIndex.DragonPartner:
			{
				bool flag9 = this.m_dragonPartnerHandler != null && !this.m_dragonPartnerHandler.IsVisible();
				if (flag9)
				{
					this.m_dragonPartnerHandler.SetVisible(true);
				}
				break;
			}
			case TabIndex.Partner:
			{
				bool flag10 = this.m_partnerMainHandler != null && !this.m_partnerMainHandler.IsVisible();
				if (flag10)
				{
					this.m_partnerMainHandler.SetVisible(true);
				}
				break;
			}
			case TabIndex.Mentorship:
			{
				bool flag11 = this.MentorshipHandler != null && !this.MentorshipHandler.IsVisible();
				if (flag11)
				{
					this.MentorshipHandler.SetVisible(true);
				}
				break;
			}
			case TabIndex.Wedding:
			{
				bool flag12 = this.m_weddingMainHandler != null && !this.m_weddingMainHandler.IsVisible();
				if (flag12)
				{
					this.m_weddingMainHandler.SetVisible(true);
				}
				break;
			}
			case TabIndex.DragonGuild:
			{
				bool flag13 = XDragonGuildDocument.Doc.IsInDragonGuild();
				if (flag13)
				{
					this.m_dragonGuildMainHandler.SetVisible(false);
					this.m_dragonGuildMainHandler.SetVisible(true);
					bool flag14 = this.m_dragonGuildListHandler.IsVisible();
					if (flag14)
					{
						this.m_dragonGuildListHandler.SetVisible(false);
					}
				}
				else
				{
					this.m_dragonGuildListHandler.SetVisible(true);
					bool flag15 = this.m_dragonGuildMainHandler.IsVisible();
					if (flag15)
					{
						this.m_dragonGuildMainHandler.SetVisible(false);
					}
				}
				break;
			}
			}
		}

		private XFriendData GenerateFriendInfo(Friend2Client friend2Client)
		{
			return new XFriendData
			{
				name = friend2Client.name,
				lastlogin = friend2Client.lastlogin,
				level = friend2Client.level,
				powerpoint = friend2Client.powerpoint,
				profession = friend2Client.profession,
				roleid = friend2Client.roleid,
				viplevel = friend2Client.viplevel,
				audioid = (int)friend2Client.audioid,
				setid = ((friend2Client.pre != null) ? friend2Client.pre.setid : new List<uint>()),
				online = 0U,
				degreeDay = friend2Client.daydegree,
				degreeAll = friend2Client.alldegree,
				receiveGiftState = friend2Client.receivegiftstate,
				sendGiftState = friend2Client.sendgiftstate,
				uid = friend2Client.nickid,
				titleID = friend2Client.titleid,
				receiveAll = friend2Client.receiveall,
				guildname = friend2Client.guildname,
				receivetime = friend2Client.receivetime,
				paymemberid = friend2Client.paymemberid,
				openID = friend2Client.openid,
				nickName = friend2Client.nickname
			};
		}

		public bool IsMyFriend(ulong uid)
		{
			for (int i = 0; i < this.friendData.Count; i++)
			{
				bool flag = this.friendData[i].roleid == uid;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public uint GetFriendDegreeAll(ulong uid)
		{
			for (int i = 0; i < this.friendData.Count; i++)
			{
				bool flag = this.friendData[i].roleid == uid;
				if (flag)
				{
					return this.friendData[i].degreeAll;
				}
			}
			return 0U;
		}

		public bool IsBlock(ulong uid)
		{
			for (int i = 0; i < this.blockFriendData.Count; i++)
			{
				bool flag = this.blockFriendData[i].roleid == uid;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public void RefreshFriendList(bool reset = false)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				int num = this._SetTabNumLabel(this.m_CurrentTabIndex);
				base.uiBehaviour.FriendListWrapContent.SetContentCount(num, false);
				if (reset)
				{
					base.uiBehaviour.FriendListScrollView.ResetPosition();
				}
			}
		}

		public void SetTencentImage(IXUITexture texture)
		{
			bool flag = texture == null;
			if (!flag)
			{
				texture.gameObject.SetActive(false);
			}
		}

		public void RandomFriend()
		{
			RpcC2M_RandomFriendWaitListNew rpc = new RpcC2M_RandomFriendWaitListNew();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void RandomFriendRes(RandomFriendWaitListRes waitList)
		{
			bool flag = DlgBase<XFriendsSearchView, XFriendsSearchBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XFriendsSearchView, XFriendsSearchBehaviour>.singleton.OnRefreshRandomFriend(waitList);
			}
			else
			{
				DlgBase<XFriendsSearchView, XFriendsSearchBehaviour>.singleton.ShowBoard(waitList);
			}
		}

		private bool DoAddBlockFriendByID(IXUIButton btn)
		{
			RpcC2M_AddBlackListNew rpcC2M_AddBlackListNew = new RpcC2M_AddBlackListNew();
			rpcC2M_AddBlackListNew.oArg.otherroleid = btn.ID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_AddBlackListNew);
			bool flag = this.OnAddBlockSucc != null;
			if (flag)
			{
				this.OnAddBlockSucc();
			}
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private bool DoAddBlockFriendByName(IXUIButton btn)
		{
			RpcC2M_AddBlackListNew rpcC2M_AddBlackListNew = new RpcC2M_AddBlackListNew();
			rpcC2M_AddBlackListNew.oArg.name = btn.gameObject.name;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_AddBlackListNew);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		public void AddBlockFriend(ulong uid)
		{
			bool flag = uid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_CAN_NOT_BAN_SELF"), "fece00");
			}
			else
			{
				bool flag2 = this.GetBlockFriendDataById(uid) != null;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_ALREADY_BAN"), "fece00");
				}
				else
				{
					DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.Load();
					DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.m_OKButton.ID = uid;
					XFriendData friendDataById = this.GetFriendDataById(uid);
					bool flag3 = friendDataById != null;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("FRIENDS_BLOCK", new object[]
						{
							friendDataById.name
						}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.DoAddBlockFriendByID));
					}
					else
					{
						this.DoAddBlockFriendByID(DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.m_OKButton);
					}
				}
			}
		}

		public void AddBlockFriend(string name)
		{
			bool flag = name == XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_CAN_NOT_BAN_SELF"), "fece00");
			}
			else
			{
				bool flag2 = this.GetBlockFriendDataByName(name) != null;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_ALREADY_BAN"), "fece00");
				}
				else
				{
					DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.Load();
					DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.m_OKButton.gameObject.name = name;
					XFriendData friendDataByName = this.GetFriendDataByName(name);
					bool flag3 = friendDataByName != null;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("FRIENDS_BLOCK", new object[]
						{
							friendDataByName.name
						}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.DoAddBlockFriendByName));
					}
					else
					{
						this.DoAddBlockFriendByName(DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.uiBehaviour.m_OKButton);
					}
				}
			}
		}

		public void AddBlockFriendRes(Friend2Client black)
		{
			XFriendData item = this.GenerateFriendInfo(black);
			this.blockFriendData.Add(item);
			XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("FRIENDS_BAN_SUCC"), black.name), "fece00");
			DlgBase<XChatView, XChatBehaviour>.singleton.ChatDoc.RemoveFriend(black.roleid);
			for (int i = 0; i < this.friendData.Count; i++)
			{
				bool flag = this.friendData[i].roleid == black.roleid;
				if (flag)
				{
					this.friendData.RemoveAt(i);
					break;
				}
			}
			this.RefreshUI();
		}

		public void RefreshBlockFriendData(BlackListNtf blacklist)
		{
			this.blockFriendData.Clear();
			for (int i = 0; i < blacklist.blacklist.Count; i++)
			{
				Friend2Client friend2Client = blacklist.blacklist[i];
				XFriendData item = this.GenerateFriendInfo(friend2Client);
				this.blockFriendData.Add(item);
			}
		}

		public void RefreshUI()
		{
			this.RefreshFriendList(false);
		}

		public void RemoveBlockFriend(ulong uid)
		{
			RpcC2M_RemoveBlackListNew rpcC2M_RemoveBlackListNew = new RpcC2M_RemoveBlackListNew();
			rpcC2M_RemoveBlackListNew.oArg.otherroleid = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_RemoveBlackListNew);
		}

		public void RemoveBlockFriendRes(ErrorCode code, ulong roleid)
		{
			bool flag = code == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				for (int i = 0; i < this.blockFriendData.Count; i++)
				{
					bool flag2 = this.blockFriendData[i].roleid == roleid;
					if (flag2)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("FRIENDS_DIS_BAN"), this.blockFriendData[i].name), "fece00");
						this.blockFriendData.RemoveAt(i);
						break;
					}
				}
				this.RefreshFriendList(false);
			}
		}

		public override void StackRefresh()
		{
			this.RefreshUI();
			bool flag = this.m_CurrentTabIndex == TabIndex.Mentorship;
			if (flag)
			{
				XMentorshipDocument.Doc.SendMentorshipInfoReq();
			}
		}

		private void _UpdateFriendSendGiftUI(Transform t, XFriendData friendInfo)
		{
			bool flag = friendInfo.degreeDay > XSingleton<XFriendsStaticData>.singleton.SendGiftMinDegree;
			if (flag)
			{
				friendInfo.degreeDay = XSingleton<XFriendsStaticData>.singleton.SendGiftMinDegree;
			}
			Transform transform = t.Find("send");
			Transform transform2 = t.Find("sent");
			uint num = (uint)XFastEnumIntEqualityComparer<FriendGiftSend>.ToInt(FriendGiftSend.FriendGift_Sended);
			bool flag2 = friendInfo.sendGiftState == num;
			if (flag2)
			{
				transform2.gameObject.SetActive(true);
				transform.gameObject.SetActive(false);
			}
			else
			{
				transform2.gameObject.SetActive(false);
				transform.gameObject.SetActive(true);
				IXUIButton ixuibutton = transform.GetComponent("XUIButton") as IXUIButton;
				ixuibutton.ID = friendInfo.roleid;
				bool flag3 = friendInfo.degreeDay < XSingleton<XFriendsStaticData>.singleton.SendGiftMinDegree;
				if (flag3)
				{
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickSendGiftToFriendNotAvaliable));
				}
				else
				{
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickSendGiftToFriend));
				}
				Transform transform3 = transform.Find("fx");
				Transform transform4 = transform.Find("Progress");
				Transform transform5 = transform.Find("RedPoint");
				IXUILabel ixuilabel = transform.Find("V").GetComponent("XUILabel") as IXUILabel;
				bool flag4 = friendInfo.degreeDay < XSingleton<XFriendsStaticData>.singleton.SendGiftMinDegree;
				if (flag4)
				{
					transform3.gameObject.SetActive(false);
					transform4.gameObject.SetActive(true);
					transform5.gameObject.SetActive(false);
					ixuilabel.SetText(string.Format(XSingleton<XFriendsStaticData>.singleton.CommonCountTotalFmt, friendInfo.degreeDay, XSingleton<XFriendsStaticData>.singleton.SendGiftMinDegree));
					IXUIProgress ixuiprogress = transform4.GetComponent("XUIProgress") as IXUIProgress;
					ixuiprogress.value = friendInfo.degreeDay / XSingleton<XFriendsStaticData>.singleton.SendGiftMinDegree;
				}
				else
				{
					ixuilabel.SetText(string.Empty);
					transform3.gameObject.SetActive(true);
					transform4.gameObject.SetActive(false);
					transform5.gameObject.SetActive(true);
				}
			}
		}

		private void _UpdateFriendDegreeUI(Transform t, XFriendData data, uint deltaDay, uint deltaAll)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				Transform transform = t.Find("hgd");
				bool flag2 = this.m_CurrentTabIndex == TabIndex.ShowFriend;
				if (flag2)
				{
					transform.gameObject.SetActive(true);
					IXUILabel ixuilabel = transform.Find("Level").GetComponent("XUILabel") as IXUILabel;
					bool flag3 = data.degreeAll < XSingleton<XFriendsStaticData>.singleton.MaxFriendlyEvaluation;
					if (flag3)
					{
						ixuilabel.SetText(data.degreeAll.ToString());
					}
					else
					{
						ixuilabel.SetText("MAX");
					}
					IXUISprite ixuisprite = ixuilabel.gameObject.transform.Find("Mark").GetComponent("XUISprite") as IXUISprite;
					float num = data.degreeAll;
					num /= XSingleton<XFriendsStaticData>.singleton.MaxFriendlyEvaluation;
					ixuisprite.SetFillAmount(1f - num);
					ixuisprite.ID = (ulong)data.degreeAll;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickDegreeHeart));
					bool flag4 = deltaAll > 0U;
					if (flag4)
					{
						Transform transform2 = transform.Find("Add");
						transform2.gameObject.SetActive(true);
						IXUILabel ixuilabel2 = transform2.GetComponent("XUILabel") as IXUILabel;
						ixuilabel2.SetText(deltaAll.ToString());
						bool activeSelf = t.gameObject.activeSelf;
						if (activeSelf)
						{
							IXUITweenTool ixuitweenTool = transform2.GetComponent("XUIPlayTween") as IXUITweenTool;
							bool flag5 = ixuitweenTool != null;
							if (flag5)
							{
								ixuitweenTool.SetTweenGroup(1);
								ixuitweenTool.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnAddTweenFinishEventHandler));
								ixuitweenTool.StopTweenExceptGroup(ixuitweenTool.TweenGroup);
								ixuitweenTool.PlayTween(true, -1f);
							}
						}
					}
				}
				else
				{
					transform.gameObject.SetActive(false);
				}
			}
		}

		public void OnClickDegreeHeart(IXUISprite spr)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIENDS_DEGREE_HINT_TEXT_FMT", new object[]
			{
				spr.ID
			}), "fece00");
		}

		public void UpdateFriendOnlineState(Transform trans, uint online, uint lastlogin)
		{
			GameObject gameObject = trans.Find("Online").gameObject;
			gameObject.SetActive(this.m_CurrentTabIndex == TabIndex.ShowFriend && online > 0U);
			IXUILabel ixuilabel = trans.Find("Offline").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(string.Empty);
		}

		public XMentorshipPupilsHandler MentorshipHandler
		{
			get
			{
				return this.m_mentorshipHandler;
			}
			set
			{
				this.m_mentorshipHandler = value;
			}
		}

		private void OnAddTweenFinishEventHandler(IXUITweenTool tween)
		{
			tween.gameObject.SetActive(false);
		}

		private void _RankWrapFriendListUpdated(Transform t, int i)
		{
			XPlayerInfoChildView friendListTempView = this.m_FriendListTempView;
			friendListTempView.FindFrom(t);
			IXUITexture tencentImage = t.Find("tencent").GetComponent("XUITexture") as IXUITexture;
			this.SetTencentImage(tencentImage);
			Transform transform = t.Find("recover");
			Transform transform2 = t.Find("send");
			Transform transform3 = t.Find("sent");
			Transform transform4 = t.Find("chat");
			Transform transform5 = t.Find("agree");
			Transform transform6 = t.Find("ignore");
			Transform transform7 = t.Find("BtnAddFriend");
			transform.gameObject.SetActive(TabIndex.BlockFriend == this.m_CurrentTabIndex);
			transform2.gameObject.SetActive(this.m_CurrentTabIndex == TabIndex.ShowFriend);
			transform3.gameObject.SetActive(this.m_CurrentTabIndex == TabIndex.ShowFriend);
			transform4.gameObject.SetActive(this.m_CurrentTabIndex == TabIndex.ShowFriend);
			transform5.gameObject.SetActive(TabIndex.ApplyFriend == this.m_CurrentTabIndex);
			transform6.gameObject.SetActive(TabIndex.ApplyFriend == this.m_CurrentTabIndex);
			transform7.gameObject.SetActive(false);
			XFriendData xfriendData = null;
			bool flag = TabIndex.BlockFriend == this.m_CurrentTabIndex;
			if (flag)
			{
				bool flag2 = i >= 0 && i < this.blockFriendData.Count;
				if (flag2)
				{
					xfriendData = this.blockFriendData[i];
					IXUIButton ixuibutton = transform.GetComponent("XUIButton") as IXUIButton;
					ixuibutton.ID = xfriendData.roleid;
					ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRemoveBlockFriend));
				}
			}
			else
			{
				bool flag3 = this.m_CurrentTabIndex == TabIndex.ShowFriend;
				if (flag3)
				{
					bool flag4 = i >= 0 && i < this.friendData.Count;
					if (flag4)
					{
						xfriendData = this.friendData[i];
						this._UpdateFriendSendGiftUI(t, xfriendData);
						IXUIButton ixuibutton2 = transform4.FindChild("btn").GetComponent("XUIButton") as IXUIButton;
						ixuibutton2.SetVisible(true);
						ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickChatFriend));
						ixuibutton2.ID = xfriendData.roleid;
						transform7.gameObject.SetActive(XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ && !this._doc.IsQQFriend(xfriendData.openID));
						IXUIButton ixuibutton3 = transform7.GetComponent("XUIButton") as IXUIButton;
						ixuibutton3.ID = xfriendData.roleid;
						ixuibutton3.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickAddQQFriends));
					}
				}
				else
				{
					bool flag5 = TabIndex.ApplyFriend == this.m_CurrentTabIndex;
					if (flag5)
					{
						bool flag6 = i >= 0 && i < this.applyData.Count;
						if (flag6)
						{
							xfriendData = this.applyData[i];
							IXUIButton ixuibutton4 = transform5.GetComponent("XUIButton") as IXUIButton;
							ixuibutton4.ID = xfriendData.roleid;
							ixuibutton4.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickAgreeApply));
							IXUIButton ixuibutton5 = transform6.GetComponent("XUIButton") as IXUIButton;
							ixuibutton5.ID = xfriendData.roleid;
							ixuibutton5.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickIgnoreApply));
						}
					}
				}
			}
			bool flag7 = xfriendData == null;
			if (!flag7)
			{
				IXUISprite spr = t.FindChild("AvatarFrame").GetComponent("XUISprite") as IXUISprite;
				XSingleton<UiUtility>.singleton.ParseHeadIcon(xfriendData.setid, spr);
				this._UpdateFriendDegreeUI(t, xfriendData, 0U, 0U);
				IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = xfriendData.roleid;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickFriendItemPanel));
				this.UpdateFriendOnlineState(transform4, xfriendData.online, xfriendData.lastlogin);
				int profession = (int)xfriendData.profession;
				IXUISprite ixuisprite2 = t.Find("ProfIcon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(profession));
				friendListTempView.uidLab.SetVisible(false);
				friendListTempView.sprHead.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2(profession));
				friendListTempView.lbName.InputText = XSingleton<XCommon>.singleton.StringCombine(XTitleDocument.GetTitleWithFormat(xfriendData.titleID, xfriendData.name), XWelfareDocument.GetMemberPrivilegeIconString(xfriendData.paymemberid), XRechargeDocument.GetVIPIconString(xfriendData.viplevel));
				friendListTempView.lbLevel.SetText(xfriendData.level.ToString());
				friendListTempView.lbPPT.SetText(xfriendData.powerpoint.ToString());
				friendListTempView.SetGuildName(xfriendData.guildname);
				xfriendData.friendgo = t.gameObject;
			}
		}

		private bool _CheckHasGiftCanReceive()
		{
			this.m_HasGiftCanReceive = false;
			bool visible = false;
			uint num = (uint)XFastEnumIntEqualityComparer<FriendGiftReceive>.ToInt(FriendGiftReceive.FriendGift_Received);
			uint num2 = (uint)XFastEnumIntEqualityComparer<FriendGiftReceive>.ToInt(FriendGiftReceive.FriendGift_ReceiveNone);
			for (int i = 0; i < this.friendData.Count; i++)
			{
				bool flag = num == this.friendData[i].receiveGiftState;
				if (flag)
				{
					this.m_HasGiftCanReceive = true;
				}
				bool flag2 = num2 != this.friendData[i].receiveGiftState;
				if (flag2)
				{
					visible = true;
				}
			}
			bool flag3 = base.IsVisible();
			if (flag3)
			{
				bool flag4 = this.m_CurrentTabIndex == TabIndex.ShowFriend;
				if (flag4)
				{
					base.uiBehaviour.btnLeft.SetVisible(visible);
				}
			}
			return this.m_HasGiftCanReceive && XSingleton<XFriendsStaticData>.singleton.ReceiveGifMaxTimes > 0U && DlgBase<XFriendsView, XFriendsBehaviour>.singleton.TodayReceiveCount < XSingleton<XFriendsStaticData>.singleton.ReceiveGifMaxTimes;
		}

		private void RefreshGiftBtnRedPoint()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = !base.uiBehaviour.btnLeft.IsVisible();
				if (!flag2)
				{
					IXUISprite ixuisprite = base.uiBehaviour.btnLeft.gameObject.transform.FindChild("RedPoint").GetComponent("XUISprite") as IXUISprite;
					bool flag3 = this.m_CurrentTabIndex == TabIndex.ShowFriend;
					if (flag3)
					{
						bool active = this.m_HasGiftCanReceive && XSingleton<XFriendsStaticData>.singleton.ReceiveGifMaxTimes > 0U && DlgBase<XFriendsView, XFriendsBehaviour>.singleton.TodayReceiveCount < XSingleton<XFriendsStaticData>.singleton.ReceiveGifMaxTimes;
						ixuisprite.gameObject.SetActive(active);
					}
					else
					{
						ixuisprite.gameObject.SetActive(false);
					}
				}
			}
		}

		public void RefreshDragonGuildPage()
		{
			bool flag = (this.m_dragonGuildListHandler != null && this.m_dragonGuildListHandler.IsVisible()) || (this.m_dragonGuildMainHandler != null && this.m_dragonGuildMainHandler.IsVisible());
			if (flag)
			{
				this._ApplyTabData(TabIndex.DragonGuild);
			}
		}

		public void NoticeFriendShare(string openID, XFriendsView.ShareType tpye)
		{
			this.m_noticeFriendOpenID = openID;
			bool flag = tpye == XFriendsView.ShareType.PK;
			if (flag)
			{
				this.m_title = string.Format(XSingleton<XStringTable>.singleton.GetString("PLAT_FRIEND_PK_TITLE"), new object[0]);
				this.m_description = string.Format(XSingleton<XStringTable>.singleton.GetString("PLAT_FRIEND_PK_SUMMARY"), new object[0]);
				this.m_gameTag = "MSG_SHARE_FRIEND_PVP";
			}
			else
			{
				bool flag2 = tpye == XFriendsView.ShareType.Invite;
				if (!flag2)
				{
					return;
				}
				this.m_title = string.Format(XSingleton<XStringTable>.singleton.GetString("PLAT_FRIEND_INVITE_TITLE"), new object[0]);
				this.m_description = string.Format(XSingleton<XStringTable>.singleton.GetString("PLAT_FRIEND_INVITE_SUMMARY"), new object[0]);
				this.m_gameTag = "MSG_INVITE";
			}
			string label = "";
			bool flag3 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ;
			if (flag3)
			{
				label = XSingleton<XStringTable>.singleton.GetString("FRIEND_SEND_PLAT_FRIEND_TIP_QQ");
			}
			else
			{
				bool flag4 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat;
				if (flag4)
				{
					label = XSingleton<XStringTable>.singleton.GetString("FRIEND_SEND_PLAT_FRIEND_TIP_WX");
				}
			}
			XSingleton<UiUtility>.singleton.ShowModalDialog(label, XStringDefineProxy.GetString("FRIEND_SEND_PLAT_FRIEND_OK2"), XStringDefineProxy.GetString("FRIEND_SEND_PLAT_FRIEND_CANCEL"), new ButtonClickEventHandler(this.OnEnsureNoticeFriendPk));
		}

		private bool OnEnsureNoticeFriendPk(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			bool flag = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ;
			if (flag)
			{
				this.SharePkToQQFriend();
			}
			else
			{
				bool flag2 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat;
				if (flag2)
				{
					this.SharePkToWXFriend();
				}
			}
			return true;
		}

		private void SharePkToQQFriend()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["act"] = 1;
			dictionary["openId"] = this.m_noticeFriendOpenID;
			dictionary["title"] = this.m_title;
			dictionary["summary"] = this.m_description;
			dictionary["targetUrl"] = string.Format(XSingleton<XStringTable>.singleton.GetString("PLAT_FRIEND_PK_TARGET_URLQQ"), new object[0]);
			dictionary["imageUrl"] = string.Format(XSingleton<XStringTable>.singleton.GetString("PLAT_FRIEND_PK_IMAGE_URLQQ"), new object[0]);
			dictionary["previewText"] = string.Format(XSingleton<XStringTable>.singleton.GetString("PLAT_FRIEND_PK_PREVIEW_URLQQ"), new object[0]);
			dictionary["gameTag"] = this.m_gameTag;
			string text = Json.Serialize(dictionary);
			XSingleton<XDebug>.singleton.AddLog("SharePkToQQFriend paramStr = " + text, null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("share_send_to_friend_qq", text);
		}

		private void SharePkToWXFriend()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary["openId"] = this.m_noticeFriendOpenID;
			dictionary["title"] = this.m_title;
			dictionary["description"] = this.m_description;
			dictionary["thumbMediaId"] = "";
			dictionary["mediaTagName"] = this.m_gameTag;
			dictionary["messageExt"] = "ShareWithWeixin";
			string text = Json.Serialize(dictionary);
			XSingleton<XDebug>.singleton.AddLog("SharePkToWXFriend paramStr = " + text, null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendExtDara("share_send_to_friend_wx", text);
		}

		public Action OnAddBlockSucc;

		public Action OnRemoveFriendSucc;

		private bool m_RefreshFriendChatUI;

		private bool m_HasGiftCanReceive = false;

		private uint m_TodaySendLeft;

		private uint m_TodayReceiveLeft;

		private bool canSendGift = false;

		private bool[] mRedpoint = new bool[10];

		private GameObject[] mRedpointUI = new GameObject[10];

		private TabIndex m_CurrentTabIndex = TabIndex.ShowFriend;

		private int m_FriendListTitleHeight;

		private XFriendsDocument _doc = null;

		public List<XFriendData> friendData = new List<XFriendData>();

		public List<XFriendData> blockFriendData = new List<XFriendData>();

		public List<XFriendData> applyData = new List<XFriendData>();

		private string m_DeleteFriendName = "";

		private XPlayerInfoChildView m_FriendListTempView;

		private XFriendsViewHintHandler m_FriendsViewHintHandler;

		private GameObject m_FriendsViewHintFrame;

		private XFriendsViewAddBlockHandler m_FriendsViewAddBlockHandler;

		private GameObject m_FriendsViewAddBlockFrame;

		private XFriendsViewReceiveGiftHandler m_FriendsViewReceiveGiftHandler;

		private GameObject m_FriendsViewReceiveGiftFrame;

		private XFriendsRankHandler m_FriendsRankHandler;

		private GameObject m_FriendsRankFrame;

		private PartnerMainHandler m_partnerMainHandler;

		private FriendsWeddingHandler m_weddingMainHandler;

		private XMentorshipPupilsHandler m_mentorshipHandler;

		private XDragonPartnerHandler m_dragonPartnerHandler;

		private XDragonGuildListHandler m_dragonGuildListHandler;

		private XDragonGuildMainHandler m_dragonGuildMainHandler;

		private string m_noticeFriendOpenID;

		private string m_title;

		private string m_description;

		private string m_gameTag;

		public enum ShareType
		{

			PK = 1,

			Invite
		}
	}
}
