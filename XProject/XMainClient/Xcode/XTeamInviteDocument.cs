using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamInviteDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XTeamInviteDocument.uuID;
			}
		}

		public List<XTeamInviteListData>[] InviteLists
		{
			get
			{
				return this.m_InviteLists;
			}
		}

		public List<XTeamInviteData> InvitedList
		{
			get
			{
				return this.m_InvitedList;
			}
		}

		public int InvitedCount
		{
			get
			{
				return this.m_InvitedCount;
			}
			set
			{
				this.m_InvitedCount = value;
				bool flag = this.m_InvitedCount < 0;
				if (flag)
				{
					this.m_InvitedCount = 0;
				}
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_Team_Invited, true);
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			for (int i = 0; i < XTeamInviteDocument.INVITE_TYPE_COUNT; i++)
			{
				this.m_InviteLists[i] = new List<XTeamInviteListData>();
			}
			this.InvitedCount = 0;
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			for (int i = 0; i < XTeamInviteDocument.INVITE_TYPE_COUNT; i++)
			{
				for (int j = 0; j < this.m_InviteLists[i].Count; j++)
				{
					this.m_InviteLists[i][j].Recycle();
				}
				this.m_InviteLists[i].Clear();
			}
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_Team_Invited, true);
			}
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_JoinTeam, new XComponent.XEventHandler(this._OnJoinTeam));
		}

		private bool _OnJoinTeam(XEventArgs e)
		{
			this._ClearInvitedList();
			this.InvitedCount = 0;
			return true;
		}

		public void ReqInviteList()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			RpcC2G_TeamInviteListReq rpcC2G_TeamInviteListReq = new RpcC2G_TeamInviteListReq();
			rpcC2G_TeamInviteListReq.oArg.expid = (int)specificDocument.currentDungeonID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TeamInviteListReq);
		}

		public void OnGetInviteList(TeamInviteRes oRes)
		{
			XPartnerDocument specificDocument = XDocuments.GetSpecificDocument<XPartnerDocument>(XPartnerDocument.uuID);
			for (int i = 0; i < XTeamInviteDocument.INVITE_TYPE_COUNT; i++)
			{
				bool flag = i == 3;
				if (!flag)
				{
					for (int j = 0; j < this.m_InviteLists[i].Count; j++)
					{
						this.m_InviteLists[i][j].Recycle();
					}
					this.m_InviteLists[i].Clear();
				}
			}
			Dictionary<ulong, XTeamInviteListData> dictionary = new Dictionary<ulong, XTeamInviteListData>();
			for (int k = 0; k < oRes.guild.Count; k++)
			{
				XTeamInviteListData data = XDataPool<XTeamInviteListData>.GetData();
				data.SetData(oRes.guild[k], false, true, XDragonGuildDocument.Doc.IsMyDragonGuildMember(oRes.guild[k].roledragonguildid));
				this.m_InviteLists[2].Add(data);
				dictionary[data.uid] = data;
			}
			for (int l = 0; l < oRes.friend.Count; l++)
			{
				XTeamInviteListData data2;
				bool flag2 = !dictionary.TryGetValue(oRes.friend[l].userID, out data2);
				if (flag2)
				{
					data2 = XDataPool<XTeamInviteListData>.GetData();
					data2.SetData(oRes.friend[l], true, false, XDragonGuildDocument.Doc.IsMyDragonGuildMember(oRes.friend[l].roledragonguildid));
				}
				else
				{
					data2.relation.Append(XTeamRelation.Relation.TR_FRIEND, true);
					bool flag3 = XDragonGuildDocument.Doc.IsMyDragonGuildMember(oRes.friend[l].roledragonguildid);
					if (flag3)
					{
						data2.relation.Append(XTeamRelation.Relation.TR_PARTNER, true);
					}
				}
				this.m_InviteLists[1].Add(data2);
			}
			for (int m = 1; m < XTeamInviteDocument.INVITE_TYPE_COUNT; m++)
			{
				this.m_InviteLists[m].Sort();
			}
			dictionary.Clear();
			int num = 0;
			int num2 = 0;
			while (num < this.m_InviteLists[2].Count && num2 < 3 && this.m_InviteLists[0].Count < 6)
			{
				XTeamInviteListData xteamInviteListData = this.m_InviteLists[2][num];
				bool flag4 = xteamInviteListData.state > XTeamInviteListData.InviteState.IS_IDLE;
				if (!flag4)
				{
					this.m_InviteLists[0].Add(xteamInviteListData);
					dictionary[xteamInviteListData.uid] = xteamInviteListData;
					num2++;
				}
				num++;
			}
			int num3 = 0;
			int num4 = 0;
			while (num3 < this.m_InviteLists[1].Count && num4 < 3 && this.m_InviteLists[0].Count < 6)
			{
				XTeamInviteListData xteamInviteListData2 = this.m_InviteLists[1][num3];
				bool flag5 = xteamInviteListData2.state > XTeamInviteListData.InviteState.IS_IDLE;
				if (!flag5)
				{
					bool flag6 = dictionary.ContainsKey(xteamInviteListData2.uid);
					if (!flag6)
					{
						this.m_InviteLists[0].Add(xteamInviteListData2);
						num4++;
					}
				}
				num3++;
			}
			int num5 = 0;
			while (num5 < oRes.rec.Count && this.m_InviteLists[0].Count < 6)
			{
				XTeamInviteListData data3 = XDataPool<XTeamInviteListData>.GetData();
				data3.SetData(oRes.rec[num5], false, false, XDragonGuildDocument.Doc.IsMyDragonGuildMember(oRes.rec[num5].roledragonguildid));
				this.m_InviteLists[0].Add(data3);
				num5++;
			}
			this.m_InviteLists[0].Sort();
			bool flag7 = this.InviteHandler != null && this.InviteHandler.IsVisible();
			if (flag7)
			{
				this.InviteHandler.LocalServerRefresh();
			}
		}

		public bool OnGetInvitePlatList(ReqPlatFriendRankListRes oRes)
		{
			bool flag = this.InviteHandler != null && this.InviteHandler.IsVisible();
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("[InvitePlatFriend]OnGetInvitePlatListRefreshFriendsCount:" + oRes.platFriends.Count, null, null, null, null, null, XDebugColor.XDebug_None);
				for (int i = 0; i < this.m_InviteLists[3].Count; i++)
				{
					this.m_InviteLists[3][i].Recycle();
				}
				this.m_InviteLists[3].Clear();
				for (int j = 0; j < oRes.platFriends.Count; j++)
				{
					bool flag2 = oRes.platFriends[j].platfriendBaseInfo.openid == XSingleton<XClientNetwork>.singleton.OpenID;
					if (!flag2)
					{
						XTeamInviteListData data = XDataPool<XTeamInviteListData>.GetData();
						data.SetData(oRes.platFriends[j]);
						this.m_InviteLists[3].Add(data);
					}
				}
				this.InviteHandler.Refresh();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public void ReqIgnoreAll()
		{
			RpcC2M_InvHistoryC2MReq rpcC2M_InvHistoryC2MReq = new RpcC2M_InvHistoryC2MReq();
			rpcC2M_InvHistoryC2MReq.oArg.type = InvHReqType.INVH_UNF_IGNORE_ALL;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvHistoryC2MReq);
		}

		public void ReqDeny()
		{
			RpcC2M_InvHistoryC2MReq rpcC2M_InvHistoryC2MReq = new RpcC2M_InvHistoryC2MReq();
			rpcC2M_InvHistoryC2MReq.oArg.type = InvHReqType.INVH_REFUSE_FORNOW;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvHistoryC2MReq);
		}

		public void ReqInvitedList()
		{
			RpcC2M_InvHistoryC2MReq rpcC2M_InvHistoryC2MReq = new RpcC2M_InvHistoryC2MReq();
			rpcC2M_InvHistoryC2MReq.oArg.type = InvHReqType.INVH_REQ_UNF_LIST;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvHistoryC2MReq);
		}

		public void OnInvHistoryReq(InvHistoryArg oArg, InvHistoryRes oRes)
		{
			bool flag = oRes.ret > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ret, "fece00");
			}
			else
			{
				InvHReqType type = oArg.type;
				if (type != InvHReqType.INVH_REQ_UNF_LIST)
				{
					if (type - InvHReqType.INVH_UNF_IGNORE_ALL <= 1)
					{
						this.InvitedCount = 0;
					}
				}
				else
				{
					this._ClearInvitedList();
					for (int i = 0; i < oRes.invUnfH.Count; i++)
					{
						XTeamInviteData data = XDataPool<XTeamInviteData>.GetData();
						data.SetData(oRes.invUnfH[i]);
						this.m_InvitedList.Add(data);
					}
					this.InvitedCount = this.m_InvitedList.Count;
					bool flag2 = this.InvitedView != null && this.InvitedView.IsVisible();
					if (flag2)
					{
						this.InvitedView.RefreshPage();
					}
				}
			}
		}

		private void _ClearInvitedList()
		{
			for (int i = 0; i < this.m_InvitedList.Count; i++)
			{
				this.m_InvitedList[i].Recycle();
			}
			this.m_InvitedList.Clear();
		}

		public void ReqTeamInviteAck(bool bAgree, uint id)
		{
			PtcC2M_TeamInviteAckC2M ptcC2M_TeamInviteAckC2M = new PtcC2M_TeamInviteAckC2M();
			ptcC2M_TeamInviteAckC2M.Data.accept = bAgree;
			ptcC2M_TeamInviteAckC2M.Data.inviteid = id;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_TeamInviteAckC2M);
		}

		public void OnInviteComing(TeamInvite inviteData)
		{
			int invitedCount = this.InvitedCount + 1;
			this.InvitedCount = invitedCount;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("TeamInviteDocument");

		private static readonly int INVITE_TYPE_COUNT = 4;

		private List<XTeamInviteListData>[] m_InviteLists = new List<XTeamInviteListData>[XTeamInviteDocument.INVITE_TYPE_COUNT];

		private List<XTeamInviteData> m_InvitedList = new List<XTeamInviteData>();

		public int m_InvitedCount;

		public XTeamInviteView InviteHandler = null;

		public XTeamInvitedListView InvitedView = null;
	}
}
