using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFriendsDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XFriendsDocument.uuID;
			}
		}

		public static XFriendsDocument Doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XFriendsDocument>(XFriendsDocument.uuID);
			}
		}

		public List<PlatFriendRankInfo2Client> PlatFriendsRankList
		{
			get
			{
				return this.m_listPlatFriendsRank;
			}
		}

		public PlatFriendRankInfo2Client SelfPlatRankInfo
		{
			get
			{
				return this.m_selfPlatRank;
			}
		}

		public Dictionary<string, QQVipType> FriendsVipInfo
		{
			get
			{
				return this._FriendsVipInfo;
			}
		}

		public static int FriendsTabCount
		{
			get
			{
				return XFriendsDocument._FriendSysTable.Table.Length;
			}
		}

		public static FriendSysConfigTable.RowData GetFriendsTabItemByID(int id)
		{
			return XFriendsDocument._FriendSysTable.GetByTabID(id);
		}

		public static FriendSysConfigTable.RowData GetFriendsTabItemByIndex(int index)
		{
			return XFriendsDocument._FriendSysTable.Table[index];
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.syncFriendsData = false;
			XSingleton<XFriendsStaticData>.singleton.Init();
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XFriendsDocument.AsyncLoader.AddTask("Table/Friend", XFriendsDocument._FriendTable, false);
			XFriendsDocument.AsyncLoader.AddTask("Table/FriendSystemConfig", XFriendsDocument._FriendSysTable, false);
			XFriendsDocument.AsyncLoader.Execute(callback);
		}

		public FriendTable.RowData[] GetFriendLevelDatas()
		{
			return XFriendsDocument._FriendTable.Table;
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.ReqFriendsInfo();
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this.entertimer = 0;
			this._FriendsVipInfo.Clear();
		}

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

		public void SDKQueryFriends()
		{
			XSingleton<XDebug>.singleton.AddLog("XFriendsDocument SDKQueryFriends", null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SendGameExData("QueryFriends", "");
		}

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

		public void ReqPlatFriendsRank()
		{
			XSingleton<XDebug>.singleton.AddLog("FriendsRank ReqPlatFriendsRank", null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2M_ReqPlatFriendRankList rpc = new RpcC2M_ReqPlatFriendRankList();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void SendGift2PlatFriend(string openID)
		{
			XSingleton<XDebug>.singleton.AddLog("FriendsRank SendGift2PlatFriend openid = " + openID, null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2M_SendGift2PlatFriend rpcC2M_SendGift2PlatFriend = new RpcC2M_SendGift2PlatFriend();
			rpcC2M_SendGift2PlatFriend.oArg.openid = openID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_SendGift2PlatFriend);
		}

		public void SendPk2PlatFriend(string openID)
		{
			XSingleton<XDebug>.singleton.AddLog("FriendsRank SendPk2PlatFriend openid = " + openID, null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2M_InvFightReqAll rpcC2M_InvFightReqAll = new RpcC2M_InvFightReqAll();
			rpcC2M_InvFightReqAll.oArg.reqtype = InvFightReqType.IFRT_INV_ONE;
			rpcC2M_InvFightReqAll.oArg.iscross = true;
			rpcC2M_InvFightReqAll.oArg.account = openID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvFightReqAll);
		}

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

		public void OnFriendGiftOp(FriendGiftOpArg oArg, FriendGiftOpRes oRes)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.OnFriendGiftOp(oArg, oRes);
		}

		public void OnApply(DoAddFriendArg oArg, DoAddFriendRes oRes)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.OnApply(oArg, oRes);
		}

		public void AddFriendRes(ErrorCode code, ulong uid)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendRes(code, uid);
		}

		public void OnFriendOpNotify(PtcM2C_FriendOpNtfNew roPtc)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.OnFriendOpNotify(roPtc);
			XFriendInfoChange @event = XEventPool<XFriendInfoChange>.GetEvent();
			@event.opType = roPtc.Data.op;
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		public void RemoveFriendRes(ErrorCode code, ulong roleid)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RemoveFriendRes(code, roleid);
		}

		public void UpdateFriendInfo(ulong uid, uint daydegree, uint alldegree)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.UpdateFriendInfo(uid, daydegree, alldegree);
		}

		public void QueryRoleStateRes(RoleStateNtf rolestate)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.QueryRoleStateRes(rolestate);
		}

		public void RandomFriendRes(RandomFriendWaitListRes waitList)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RandomFriendRes(waitList);
		}

		public void AddBlockFriendRes(Friend2Client black)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddBlockFriendRes(black);
		}

		public void RefreshBlockFriendData(BlackListNtf blacklist)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RefreshBlockFriendData(blacklist);
		}

		public void RemoveBlockFriendRes(ErrorCode code, ulong roleid)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RemoveBlockFriendRes(code, roleid);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XFriendsDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static FriendTable _FriendTable = new FriendTable();

		private static FriendSysConfigTable _FriendSysTable = new FriendSysConfigTable();

		private List<PlatFriendRankInfo2Client> m_listPlatFriendsRank = null;

		private PlatFriendRankInfo2Client m_selfPlatRank = null;

		private Dictionary<string, QQVipType> _FriendsVipInfo = new Dictionary<string, QQVipType>();

		private bool syncFriendsData = false;

		private int entertimer = 0;
	}
}
