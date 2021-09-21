using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009AB RID: 2475
	internal class XFriendsDocument : XDocComponent
	{
		// Token: 0x17002D37 RID: 11575
		// (get) Token: 0x060095CB RID: 38347 RVA: 0x00168390 File Offset: 0x00166590
		public override uint ID
		{
			get
			{
				return XFriendsDocument.uuID;
			}
		}

		// Token: 0x17002D38 RID: 11576
		// (get) Token: 0x060095CC RID: 38348 RVA: 0x001683A8 File Offset: 0x001665A8
		public static XFriendsDocument Doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			}
		}

		// Token: 0x17002D39 RID: 11577
		// (get) Token: 0x060095CD RID: 38349 RVA: 0x001683C4 File Offset: 0x001665C4
		public List<PlatFriendRankInfo2Client> PlatFriendsRankList
		{
			get
			{
				return this.m_listPlatFriendsRank;
			}
		}

		// Token: 0x17002D3A RID: 11578
		// (get) Token: 0x060095CE RID: 38350 RVA: 0x001683DC File Offset: 0x001665DC
		public PlatFriendRankInfo2Client SelfPlatRankInfo
		{
			get
			{
				return this.m_selfPlatRank;
			}
		}

		// Token: 0x17002D3B RID: 11579
		// (get) Token: 0x060095CF RID: 38351 RVA: 0x001683F4 File Offset: 0x001665F4
		public Dictionary<string, QQVipType> FriendsVipInfo
		{
			get
			{
				return this._FriendsVipInfo;
			}
		}

		// Token: 0x17002D3C RID: 11580
		// (get) Token: 0x060095D0 RID: 38352 RVA: 0x0016840C File Offset: 0x0016660C
		public static int FriendsTabCount
		{
			get
			{
				return XFriendsDocument._FriendSysTable.Table.Length;
			}
		}

		// Token: 0x060095D1 RID: 38353 RVA: 0x0016842C File Offset: 0x0016662C
		public static FriendSysConfigTable.RowData GetFriendsTabItemByID(int id)
		{
			return XFriendsDocument._FriendSysTable.GetByTabID(id);
		}

		// Token: 0x060095D2 RID: 38354 RVA: 0x0016844C File Offset: 0x0016664C
		public static FriendSysConfigTable.RowData GetFriendsTabItemByIndex(int index)
		{
			return XFriendsDocument._FriendSysTable.Table[index];
		}

		// Token: 0x060095D3 RID: 38355 RVA: 0x0016846A File Offset: 0x0016666A
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.syncFriendsData = false;
			XSingleton<XFriendsStaticData>.singleton.Init();
		}

		// Token: 0x060095D4 RID: 38356 RVA: 0x00168487 File Offset: 0x00166687
		public static void Execute(OnLoadedCallback callback = null)
		{
			XFriendsDocument.AsyncLoader.AddTask("Table/Friend", XFriendsDocument._FriendTable, false);
			XFriendsDocument.AsyncLoader.AddTask("Table/FriendSystemConfig", XFriendsDocument._FriendSysTable, false);
			XFriendsDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060095D5 RID: 38357 RVA: 0x001684C4 File Offset: 0x001666C4
		public FriendTable.RowData[] GetFriendLevelDatas()
		{
			return XFriendsDocument._FriendTable.Table;
		}

		// Token: 0x060095D6 RID: 38358 RVA: 0x001684E0 File Offset: 0x001666E0
		public FriendTable.RowData GetFriendLevelData(uint level)
		{
			for (int i = 0; i < XFriendsDocument._FriendTable.Table.Length; i++)
			{
				bool flag = XFriendsDocument._FriendTable.Table[i].level == level;
				if (flag)
				{
					return XFriendsDocument._FriendTable.Table[i];
				}
			}
			return null;
		}

		// Token: 0x060095D7 RID: 38359 RVA: 0x00168537 File Offset: 0x00166737
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.ReqFriendsInfo();
		}

		// Token: 0x060095D8 RID: 38360 RVA: 0x00168541 File Offset: 0x00166741
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this.entertimer = 0;
			this._FriendsVipInfo.Clear();
		}

		// Token: 0x060095D9 RID: 38361 RVA: 0x00168560 File Offset: 0x00166760
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			XSingleton<XFriendsStaticData>.singleton.Init();
			this.ReqFriendsInfo();
			this.entertimer++;
			XChatDocument specificDocument = XDocuments.GetSpecificDocument<XChatDocument>(XChatDocument.uuID);
			bool flag = specificDocument != null && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				specificDocument.SendOfflineMsg();
			}
		}

		// Token: 0x060095DA RID: 38362 RVA: 0x001685C3 File Offset: 0x001667C3
		public void SDKQueryFriends()
		{
			XSingleton<XDebug>.singleton.AddLog("XFriendsDocument SDKQueryFriends", null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("QueryFriends", "");
		}

		// Token: 0x060095DB RID: 38363 RVA: 0x001685F8 File Offset: 0x001667F8
		public void ReqFriendsInfo()
		{
			PtcC2M_FriendQueryReportNew ptcC2M_FriendQueryReportNew = new PtcC2M_FriendQueryReportNew();
			ptcC2M_FriendQueryReportNew.Data.op = FriendOpType.Friend_ApplyAll;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_FriendQueryReportNew);
			PtcC2M_FriendQueryReportNew ptcC2M_FriendQueryReportNew2 = new PtcC2M_FriendQueryReportNew();
			ptcC2M_FriendQueryReportNew2.Data.op = FriendOpType.Friend_FriendAll;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_FriendQueryReportNew2);
			PtcC2M_BlackListReportNew proto = new PtcC2M_BlackListReportNew();
			XSingleton<XClientNetwork>.singleton.Send(proto);
		}

		// Token: 0x060095DC RID: 38364 RVA: 0x00168658 File Offset: 0x00166858
		public void SyncPlatFriendsInfo()
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall;
			if (!flag)
			{
				bool flag2 = this.syncFriendsData;
				if (!flag2)
				{
					XSingleton<XDebug>.singleton.AddLog("FriendsRank SyncPlatFriendsInfo", null, null, null, null, null, XDebugColor.XDebug_None);
					PtcC2M_SyncPlatFriend2MS ptcC2M_SyncPlatFriend2MS = new PtcC2M_SyncPlatFriend2MS();
					bool flag3 = XSingleton<PDatabase>.singleton.friendsInfo != null;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddLog("FriendsRank friendsCount = " + XSingleton<PDatabase>.singleton.friendsInfo.data.Length, null, null, null, null, null, XDebugColor.XDebug_None);
						int @int = XSingleton<XGlobalConfig>.singleton.GetInt("SyncPlatFriendsCount");
						XSingleton<XDebug>.singleton.AddLog("FriendsRank SyncPlatFriendsCount = " + @int, null, null, null, null, null, XDebugColor.XDebug_None);
						for (int i = 0; i < XSingleton<PDatabase>.singleton.friendsInfo.data.Length; i++)
						{
							bool flag4 = i < @int;
							if (!flag4)
							{
								break;
							}
							FriendInfo.Data data = XSingleton<PDatabase>.singleton.friendsInfo.data[i];
							PlatFriend platFriend = new PlatFriend();
							platFriend.openid = data.openId;
							platFriend.nickname = data.nickName;
							platFriend.bigpic = data.pictureLarge;
							platFriend.midpic = "";
							platFriend.smallpic = "";
							ptcC2M_SyncPlatFriend2MS.Data.friendInfo.Add(platFriend);
						}
						XSingleton<XDebug>.singleton.AddLog("FriendsRank SendCount = " + ptcC2M_SyncPlatFriend2MS.Data.friendInfo.Count, null, null, null, null, null, XDebugColor.XDebug_None);
					}
					bool flag5 = XSingleton<PDatabase>.singleton.playerInfo != null;
					if (flag5)
					{
						PlatFriend platFriend2 = new PlatFriend();
						platFriend2.openid = XSingleton<XLoginDocument>.singleton.OpenID;
						platFriend2.nickname = XSingleton<PDatabase>.singleton.playerInfo.data.nickName;
						platFriend2.bigpic = XSingleton<PDatabase>.singleton.playerInfo.data.pictureLarge;
						platFriend2.midpic = XSingleton<PDatabase>.singleton.playerInfo.data.pictureMiddle;
						platFriend2.smallpic = XSingleton<PDatabase>.singleton.playerInfo.data.pictureSmall;
						ptcC2M_SyncPlatFriend2MS.Data.selfInfo = platFriend2;
						XSingleton<XDebug>.singleton.AddLog("FriendsRank SyncPlatFriendsInfo self openid = " + platFriend2.openid, null, null, null, null, null, XDebugColor.XDebug_None);
					}
					this.syncFriendsData = true;
					XSingleton<XClientNetwork>.singleton.Send(ptcC2M_SyncPlatFriend2MS);
				}
			}
		}

		// Token: 0x060095DD RID: 38365 RVA: 0x001688F8 File Offset: 0x00166AF8
		public bool IsQQFriend(string openID)
		{
			bool flag = XSingleton<PDatabase>.singleton.friendsInfo != null;
			if (flag)
			{
				for (int i = 0; i < XSingleton<PDatabase>.singleton.friendsInfo.data.Length; i++)
				{
					bool flag2 = XSingleton<PDatabase>.singleton.friendsInfo.data[i].openId == openID;
					if (flag2)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060095DE RID: 38366 RVA: 0x0016896C File Offset: 0x00166B6C
		public void ReqPlatFriendsRank()
		{
			XSingleton<XDebug>.singleton.AddLog("FriendsRank ReqPlatFriendsRank", null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2M_ReqPlatFriendRankList rpc = new RpcC2M_ReqPlatFriendRankList();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x060095DF RID: 38367 RVA: 0x001689A4 File Offset: 0x00166BA4
		public void SendGift2PlatFriend(string openID)
		{
			XSingleton<XDebug>.singleton.AddLog("FriendsRank SendGift2PlatFriend openid = " + openID, null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2M_SendGift2PlatFriend rpcC2M_SendGift2PlatFriend = new RpcC2M_SendGift2PlatFriend();
			rpcC2M_SendGift2PlatFriend.oArg.openid = openID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_SendGift2PlatFriend);
		}

		// Token: 0x060095E0 RID: 38368 RVA: 0x001689F0 File Offset: 0x00166BF0
		public void SendPk2PlatFriend(string openID)
		{
			XSingleton<XDebug>.singleton.AddLog("FriendsRank SendPk2PlatFriend openid = " + openID, null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2M_InvFightReqAll rpcC2M_InvFightReqAll = new RpcC2M_InvFightReqAll();
			rpcC2M_InvFightReqAll.oArg.reqtype = InvFightReqType.IFRT_INV_ONE;
			rpcC2M_InvFightReqAll.oArg.iscross = true;
			rpcC2M_InvFightReqAll.oArg.account = openID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvFightReqAll);
		}

		// Token: 0x060095E1 RID: 38369 RVA: 0x00168A54 File Offset: 0x00166C54
		public void OnSendGift2PlatFriend(SendGift2PlatFriendArg oArg, SendGift2PlatFriendRes oRes)
		{
			XSingleton<XDebug>.singleton.AddLog("FriendsRank OnSendGift2PlatFriend", null, null, null, null, null, XDebugColor.XDebug_None);
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.error);
			}
			else
			{
				string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("SendPlatFriendGift", XGlobalConfig.SequenceSeparator);
				bool flag2 = andSeparateValue.Length == 2;
				if (flag2)
				{
					string text = XSingleton<UiUtility>.singleton.ChooseProfString(XBagDocument.GetItemConf(int.Parse(andSeparateValue[0])).ItemName, 0U);
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FRIEND_SEND_PLAT_FRIEND", new object[]
					{
						andSeparateValue[1],
						text
					}), "fece00");
				}
				for (int i = 0; i < this.m_listPlatFriendsRank.Count; i++)
				{
					bool flag3 = this.m_listPlatFriendsRank[i].platfriendBaseInfo.openid == oArg.openid;
					if (flag3)
					{
						this.m_listPlatFriendsRank[i].hasGiveGift = true;
						DlgBase<XFriendsView, XFriendsBehaviour>.singleton.OnRefreshSendGiftState(this.m_listPlatFriendsRank[i]);
						break;
					}
				}
				bool flag4 = XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_Guest && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Friends_Gift_Share);
				if (flag4)
				{
					DlgBase<XFriendsView, XFriendsBehaviour>.singleton.NoticeFriend(oArg.openid);
				}
			}
		}

		// Token: 0x060095E2 RID: 38370 RVA: 0x00168BB4 File Offset: 0x00166DB4
		public void OnReqPlatFriendsRank(ReqPlatFriendRankListArg oArg, ReqPlatFriendRankListRes oRes)
		{
			XSingleton<XDebug>.singleton.AddLog("FriendsRank OnReqPlatFriendsRank", null, null, null, null, null, XDebugColor.XDebug_None);
			bool flag = oRes.error > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.error);
			}
			else
			{
				XTeamInviteDocument specificDocument = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
				bool flag2 = specificDocument.OnGetInvitePlatList(oRes);
				if (!flag2)
				{
					this.m_listPlatFriendsRank = oRes.platFriends;
					this.m_selfPlatRank = oRes.selfInfo;
					XSingleton<XDebug>.singleton.AddLog("OnReqPlatFriendsRank count= " + oRes.platFriends.Count, null, null, null, null, null, XDebugColor.XDebug_None);
					bool flag3 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_QQVIP);
					if (flag3)
					{
						this.ReqQQFriendsVipInfo(oRes.platFriends);
					}
					else
					{
						DlgBase<XFriendsView, XFriendsBehaviour>.singleton.OnRefreshPlatFriendsRank();
					}
				}
			}
		}

		// Token: 0x060095E3 RID: 38371 RVA: 0x00168C9C File Offset: 0x00166E9C
		public void ReqQQFriendsVipInfo(List<PlatFriendRankInfo2Client> platFriendList)
		{
			RpcC2G_QueryQQFriendsVipInfo rpcC2G_QueryQQFriendsVipInfo = new RpcC2G_QueryQQFriendsVipInfo();
			rpcC2G_QueryQQFriendsVipInfo.oArg.token = XSingleton<XLoginDocument>.singleton.TokenCache;
			rpcC2G_QueryQQFriendsVipInfo.oArg.friendopenids.Clear();
			List<string> list = new List<string>();
			for (int i = 0; i < platFriendList.Count; i++)
			{
				rpcC2G_QueryQQFriendsVipInfo.oArg.friendopenids.Add(platFriendList[i].platfriendBaseInfo.openid);
			}
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_QueryQQFriendsVipInfo);
		}

		// Token: 0x060095E4 RID: 38372 RVA: 0x00168D24 File Offset: 0x00166F24
		public void OnGetQQFriendsVipInfo(QueryQQFriendsVipInfoArg oArg, QueryQQFriendsVipInfoRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				this._FriendsVipInfo.Clear();
				for (int i = 0; i < oRes.info.Count; i++)
				{
					QQVipType value = QQVipType.None;
					string openid = oRes.info[i].openid;
					bool is_svip = oRes.info[i].is_svip;
					if (is_svip)
					{
						value = QQVipType.SVip;
					}
					else
					{
						bool is_vip = oRes.info[i].is_vip;
						if (is_vip)
						{
							value = QQVipType.Vip;
						}
					}
					this._FriendsVipInfo[openid] = value;
				}
				DlgBase<XFriendsView, XFriendsBehaviour>.singleton.OnRefreshPlatFriendsRank();
			}
		}

		// Token: 0x060095E5 RID: 38373 RVA: 0x00168DE6 File Offset: 0x00166FE6
		public void OnFriendGiftOp(FriendGiftOpArg oArg, FriendGiftOpRes oRes)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.OnFriendGiftOp(oArg, oRes);
		}

		// Token: 0x060095E6 RID: 38374 RVA: 0x00168DF6 File Offset: 0x00166FF6
		public void OnApply(DoAddFriendArg oArg, DoAddFriendRes oRes)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.OnApply(oArg, oRes);
		}

		// Token: 0x060095E7 RID: 38375 RVA: 0x00168E06 File Offset: 0x00167006
		public void AddFriendRes(ErrorCode code, ulong uid)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendRes(code, uid);
		}

		// Token: 0x060095E8 RID: 38376 RVA: 0x00168E18 File Offset: 0x00167018
		public void OnFriendOpNotify(PtcM2C_FriendOpNtfNew roPtc)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.OnFriendOpNotify(roPtc);
			XFriendInfoChange @event = XEventPool<XFriendInfoChange>.GetEvent();
			@event.opType = roPtc.Data.op;
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x060095E9 RID: 38377 RVA: 0x00168E66 File Offset: 0x00167066
		public void RemoveFriendRes(ErrorCode code, ulong roleid)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RemoveFriendRes(code, roleid);
		}

		// Token: 0x060095EA RID: 38378 RVA: 0x00168E76 File Offset: 0x00167076
		public void UpdateFriendInfo(ulong uid, uint daydegree, uint alldegree)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.UpdateFriendInfo(uid, daydegree, alldegree);
		}

		// Token: 0x060095EB RID: 38379 RVA: 0x00168E87 File Offset: 0x00167087
		public void QueryRoleStateRes(RoleStateNtf rolestate)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.QueryRoleStateRes(rolestate);
		}

		// Token: 0x060095EC RID: 38380 RVA: 0x00168E96 File Offset: 0x00167096
		public void RandomFriendRes(RandomFriendWaitListRes waitList)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RandomFriendRes(waitList);
		}

		// Token: 0x060095ED RID: 38381 RVA: 0x00168EA5 File Offset: 0x001670A5
		public void AddBlockFriendRes(Friend2Client black)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddBlockFriendRes(black);
		}

		// Token: 0x060095EE RID: 38382 RVA: 0x00168EB4 File Offset: 0x001670B4
		public void RefreshBlockFriendData(BlackListNtf blacklist)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RefreshBlockFriendData(blacklist);
		}

		// Token: 0x060095EF RID: 38383 RVA: 0x00168EC3 File Offset: 0x001670C3
		public void RemoveBlockFriendRes(ErrorCode code, ulong roleid)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RemoveBlockFriendRes(code, roleid);
		}

		// Token: 0x040032E3 RID: 13027
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XFriendsDocument");

		// Token: 0x040032E4 RID: 13028
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040032E5 RID: 13029
		private static FriendTable _FriendTable = new FriendTable();

		// Token: 0x040032E6 RID: 13030
		private static FriendSysConfigTable _FriendSysTable = new FriendSysConfigTable();

		// Token: 0x040032E7 RID: 13031
		private List<PlatFriendRankInfo2Client> m_listPlatFriendsRank = null;

		// Token: 0x040032E8 RID: 13032
		private PlatFriendRankInfo2Client m_selfPlatRank = null;

		// Token: 0x040032E9 RID: 13033
		private Dictionary<string, QQVipType> _FriendsVipInfo = new Dictionary<string, QQVipType>();

		// Token: 0x040032EA RID: 13034
		private bool syncFriendsData = false;

		// Token: 0x040032EB RID: 13035
		private int entertimer = 0;
	}
}
