using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A88 RID: 2696
	internal class XTeamInviteDocument : XDocComponent
	{
		// Token: 0x17002FB5 RID: 12213
		// (get) Token: 0x0600A413 RID: 42003 RVA: 0x001C4A30 File Offset: 0x001C2C30
		public override uint ID
		{
			get
			{
				return XTeamInviteDocument.uuID;
			}
		}

		// Token: 0x17002FB6 RID: 12214
		// (get) Token: 0x0600A414 RID: 42004 RVA: 0x001C4A48 File Offset: 0x001C2C48
		public List<XTeamInviteListData>[] InviteLists
		{
			get
			{
				return this.m_InviteLists;
			}
		}

		// Token: 0x17002FB7 RID: 12215
		// (get) Token: 0x0600A415 RID: 42005 RVA: 0x001C4A60 File Offset: 0x001C2C60
		public List<XTeamInviteData> InvitedList
		{
			get
			{
				return this.m_InvitedList;
			}
		}

		// Token: 0x17002FB8 RID: 12216
		// (get) Token: 0x0600A416 RID: 42006 RVA: 0x001C4A78 File Offset: 0x001C2C78
		// (set) Token: 0x0600A417 RID: 42007 RVA: 0x001C4A90 File Offset: 0x001C2C90
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

		// Token: 0x0600A418 RID: 42008 RVA: 0x001C4ACC File Offset: 0x001C2CCC
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			for (int i = 0; i < XTeamInviteDocument.INVITE_TYPE_COUNT; i++)
			{
				this.m_InviteLists[i] = new List<XTeamInviteListData>();
			}
			this.InvitedCount = 0;
		}

		// Token: 0x0600A419 RID: 42009 RVA: 0x001C4B10 File Offset: 0x001C2D10
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

		// Token: 0x0600A41A RID: 42010 RVA: 0x001C4B7C File Offset: 0x001C2D7C
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_Team_Invited, true);
			}
		}

		// Token: 0x0600A41B RID: 42011 RVA: 0x001C4BBA File Offset: 0x001C2DBA
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_JoinTeam, new XComponent.XEventHandler(this._OnJoinTeam));
		}

		// Token: 0x0600A41C RID: 42012 RVA: 0x001C4BDC File Offset: 0x001C2DDC
		private bool _OnJoinTeam(XEventArgs e)
		{
			this._ClearInvitedList();
			this.InvitedCount = 0;
			return true;
		}

		// Token: 0x0600A41D RID: 42013 RVA: 0x001C4C00 File Offset: 0x001C2E00
		public void ReqInviteList()
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			RpcC2G_TeamInviteListReq rpcC2G_TeamInviteListReq = new RpcC2G_TeamInviteListReq();
			rpcC2G_TeamInviteListReq.oArg.expid = (int)specificDocument.currentDungeonID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TeamInviteListReq);
		}

		// Token: 0x0600A41E RID: 42014 RVA: 0x001C4C40 File Offset: 0x001C2E40
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

		// Token: 0x0600A41F RID: 42015 RVA: 0x001C5020 File Offset: 0x001C3220
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

		// Token: 0x0600A420 RID: 42016 RVA: 0x001C5148 File Offset: 0x001C3348
		public void ReqIgnoreAll()
		{
			RpcC2M_InvHistoryC2MReq rpcC2M_InvHistoryC2MReq = new RpcC2M_InvHistoryC2MReq();
			rpcC2M_InvHistoryC2MReq.oArg.type = InvHReqType.INVH_UNF_IGNORE_ALL;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvHistoryC2MReq);
		}

		// Token: 0x0600A421 RID: 42017 RVA: 0x001C5178 File Offset: 0x001C3378
		public void ReqDeny()
		{
			RpcC2M_InvHistoryC2MReq rpcC2M_InvHistoryC2MReq = new RpcC2M_InvHistoryC2MReq();
			rpcC2M_InvHistoryC2MReq.oArg.type = InvHReqType.INVH_REFUSE_FORNOW;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvHistoryC2MReq);
		}

		// Token: 0x0600A422 RID: 42018 RVA: 0x001C51A8 File Offset: 0x001C33A8
		public void ReqInvitedList()
		{
			RpcC2M_InvHistoryC2MReq rpcC2M_InvHistoryC2MReq = new RpcC2M_InvHistoryC2MReq();
			rpcC2M_InvHistoryC2MReq.oArg.type = InvHReqType.INVH_REQ_UNF_LIST;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_InvHistoryC2MReq);
		}

		// Token: 0x0600A423 RID: 42019 RVA: 0x001C51D8 File Offset: 0x001C33D8
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

		// Token: 0x0600A424 RID: 42020 RVA: 0x001C52C0 File Offset: 0x001C34C0
		private void _ClearInvitedList()
		{
			for (int i = 0; i < this.m_InvitedList.Count; i++)
			{
				this.m_InvitedList[i].Recycle();
			}
			this.m_InvitedList.Clear();
		}

		// Token: 0x0600A425 RID: 42021 RVA: 0x001C5308 File Offset: 0x001C3508
		public void ReqTeamInviteAck(bool bAgree, uint id)
		{
			PtcC2M_TeamInviteAckC2M ptcC2M_TeamInviteAckC2M = new PtcC2M_TeamInviteAckC2M();
			ptcC2M_TeamInviteAckC2M.Data.accept = bAgree;
			ptcC2M_TeamInviteAckC2M.Data.inviteid = id;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2M_TeamInviteAckC2M);
		}

		// Token: 0x0600A426 RID: 42022 RVA: 0x001C5344 File Offset: 0x001C3544
		public void OnInviteComing(TeamInvite inviteData)
		{
			int invitedCount = this.InvitedCount + 1;
			this.InvitedCount = invitedCount;
		}

		// Token: 0x0600A427 RID: 42023 RVA: 0x001C5366 File Offset: 0x001C3566
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04003B90 RID: 15248
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("TeamInviteDocument");

		// Token: 0x04003B91 RID: 15249
		private static readonly int INVITE_TYPE_COUNT = 4;

		// Token: 0x04003B92 RID: 15250
		private List<XTeamInviteListData>[] m_InviteLists = new List<XTeamInviteListData>[XTeamInviteDocument.INVITE_TYPE_COUNT];

		// Token: 0x04003B93 RID: 15251
		private List<XTeamInviteData> m_InvitedList = new List<XTeamInviteData>();

		// Token: 0x04003B94 RID: 15252
		public int m_InvitedCount;

		// Token: 0x04003B95 RID: 15253
		public XTeamInviteView InviteHandler = null;

		// Token: 0x04003B96 RID: 15254
		public XTeamInvitedListView InvitedView = null;
	}
}
