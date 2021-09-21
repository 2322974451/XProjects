using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A78 RID: 2680
	internal class XGuildMemberDocument : XDocComponent
	{
		// Token: 0x17002F80 RID: 12160
		// (get) Token: 0x0600A2F3 RID: 41715 RVA: 0x001BD0D0 File Offset: 0x001BB2D0
		public override uint ID
		{
			get
			{
				return XGuildMemberDocument.uuID;
			}
		}

		// Token: 0x17002F81 RID: 12161
		// (get) Token: 0x0600A2F4 RID: 41716 RVA: 0x001BD0E7 File Offset: 0x001BB2E7
		// (set) Token: 0x0600A2F5 RID: 41717 RVA: 0x001BD0EF File Offset: 0x001BB2EF
		public XGuildMembersView GuildMembersView { get; set; }

		// Token: 0x17002F82 RID: 12162
		// (get) Token: 0x0600A2F6 RID: 41718 RVA: 0x001BD0F8 File Offset: 0x001BB2F8
		public List<XGuildMember> MemberList
		{
			get
			{
				return this.m_MemberList;
			}
		}

		// Token: 0x17002F83 RID: 12163
		// (get) Token: 0x0600A2F7 RID: 41719 RVA: 0x001BD110 File Offset: 0x001BB310
		// (set) Token: 0x0600A2F8 RID: 41720 RVA: 0x001BD128 File Offset: 0x001BB328
		public GuildMemberSortType SortType
		{
			get
			{
				return this.m_SortType;
			}
			set
			{
				bool flag = this.m_SortType != value;
				if (flag)
				{
					this.m_Direction = XGuildMemberBasicInfo.DefaultSortDirection[XFastEnumIntEqualityComparer<GuildMemberSortType>.ToInt(value)];
				}
				else
				{
					this.m_Direction = -this.m_Direction;
				}
				this.m_SortType = value;
			}
		}

		// Token: 0x17002F84 RID: 12164
		// (get) Token: 0x0600A2F9 RID: 41721 RVA: 0x001BD170 File Offset: 0x001BB370
		public int SortDirection
		{
			get
			{
				return this.m_Direction;
			}
		}

		// Token: 0x17002F85 RID: 12165
		// (get) Token: 0x0600A2FA RID: 41722 RVA: 0x001BD188 File Offset: 0x001BB388
		public uint MaxFatigue
		{
			get
			{
				return this.m_FatigueMax;
			}
		}

		// Token: 0x17002F86 RID: 12166
		// (get) Token: 0x0600A2FB RID: 41723 RVA: 0x001BD1A0 File Offset: 0x001BB3A0
		public uint FetchedFatigue
		{
			get
			{
				return this.m_FatigueFetched;
			}
		}

		// Token: 0x0600A2FD RID: 41725 RVA: 0x001BD1CF File Offset: 0x001BB3CF
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.REDPOINT_FATIGUE_COUNT = XSingleton<XGlobalConfig>.singleton.GetInt("GuildFatigueRedPointCount");
		}

		// Token: 0x0600A2FE RID: 41726 RVA: 0x001BD1EF File Offset: 0x001BB3EF
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_GuildPositionChanged, new XComponent.XEventHandler(this.OnPositionChanged));
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnInGuildStateChanged));
		}

		// Token: 0x0600A2FF RID: 41727 RVA: 0x001BD224 File Offset: 0x001BB424
		protected bool OnPositionChanged(XEventArgs args)
		{
			bool flag = this.GuildMembersView != null && this.GuildMembersView.IsVisible();
			if (flag)
			{
				XGuildPositionChangedEventArgs xguildPositionChangedEventArgs = args as XGuildPositionChangedEventArgs;
				ulong entityID = XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
				for (int i = 0; i < this.m_MemberList.Count; i++)
				{
					bool flag2 = this.m_MemberList[i].uid == entityID;
					if (flag2)
					{
						this.m_MemberList[i].position = xguildPositionChangedEventArgs.position;
						this.GuildMembersView.Refresh();
						break;
					}
				}
			}
			return true;
		}

		// Token: 0x0600A300 RID: 41728 RVA: 0x001BD2D0 File Offset: 0x001BB4D0
		public bool CheckGuildInheritUids(ulong uid)
		{
			return this.m_GuildInheritUids.Contains(uid);
		}

		// Token: 0x0600A301 RID: 41729 RVA: 0x001BD2F0 File Offset: 0x001BB4F0
		protected bool OnInGuildStateChanged(XEventArgs args)
		{
			XInGuildStateChangedEventArgs xinGuildStateChangedEventArgs = args as XInGuildStateChangedEventArgs;
			bool flag = !xinGuildStateChangedEventArgs.bIsEnter;
			if (flag)
			{
				XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_GuildHall_Member, false);
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildHall_Member, true);
			}
			return true;
		}

		// Token: 0x0600A302 RID: 41730 RVA: 0x001BD33C File Offset: 0x001BB53C
		public void ReqMemberList()
		{
			RpcC2M_AskGuildMembers rpc = new RpcC2M_AskGuildMembers();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600A303 RID: 41731 RVA: 0x001BD35C File Offset: 0x001BB55C
		public void onGetMemberList(GuildMemberRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				this.m_GuildInheritUids.Clear();
				this.m_GuildInheritUids.AddRange(oRes.guildinheritid);
				int num = oRes.members.Count - this.m_MemberList.Count;
				for (int i = 0; i < num; i++)
				{
					XGuildMember item = new XGuildMember();
					this.m_MemberList.Add(item);
				}
				bool flag2 = num < 0;
				if (flag2)
				{
					this.m_MemberList.RemoveRange(this.m_MemberList.Count + num, -num);
				}
				for (int j = 0; j < oRes.members.Count; j++)
				{
					bool flag3 = oRes.members[j] == null;
					if (!flag3)
					{
						this.m_MemberList[j].Set(oRes.members[j]);
						this.m_MemberList[j].isInherit = this.CheckGuildInheritUids(oRes.members[j].roleid);
					}
				}
				this.m_FatigueMax = oRes.FatigueMax;
				this.m_FatigueFetched = oRes.recvFatigue;
				XSingleton<XDebug>.singleton.AddGreenLog("m_GuildInheritUids", oRes.guildinheritid.Count.ToString(), null, null, null, null);
				bool flag4 = this.GuildMembersView != null && this.GuildMembersView.IsVisible();
				if (flag4)
				{
					this.GuildMembersView.RefreshFatigue();
					this.SortAndShow();
				}
				this.RefreshRedPointState();
				XGuildMemberListEventArgs @event = XEventPool<XGuildMemberListEventArgs>.GetEvent();
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x0600A304 RID: 41732 RVA: 0x001BD538 File Offset: 0x001BB738
		public void SortAndShow()
		{
			XGuildMemberBasicInfo.playerID = XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
			XGuildMemberBasicInfo.dir = this.m_Direction;
			XGuildMemberBasicInfo.sortType = this.m_SortType;
			CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
			Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(XSingleton<XGlobalConfig>.singleton.GetValue("Culture"));
			this.m_MemberList.Sort();
			Thread.CurrentThread.CurrentCulture = currentCulture;
			bool flag = this.GuildMembersView != null && this.GuildMembersView.IsVisible();
			if (flag)
			{
				this.GuildMembersView.RefreshAll(true);
			}
		}

		// Token: 0x0600A305 RID: 41733 RVA: 0x001BD5E0 File Offset: 0x001BB7E0
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.GuildMembersView != null && this.GuildMembersView.IsVisible();
			if (flag)
			{
				this.ReqMemberList();
			}
		}

		// Token: 0x0600A306 RID: 41734 RVA: 0x001BD610 File Offset: 0x001BB810
		public void ReqChangePosition(ulong uid, bool bIncrease)
		{
			GuildPosition guildPosition = GuildPosition.GPOS_COUNT;
			for (int i = 0; i < this.m_MemberList.Count; i++)
			{
				bool flag = this.m_MemberList[i].uid == uid;
				if (flag)
				{
					guildPosition = this.m_MemberList[i].position;
					break;
				}
			}
			bool flag2 = guildPosition == GuildPosition.GPOS_COUNT;
			if (!flag2)
			{
				RpcC2M_ChangeMemberPositionNew rpcC2M_ChangeMemberPositionNew = new RpcC2M_ChangeMemberPositionNew();
				rpcC2M_ChangeMemberPositionNew.oArg.roleid = uid;
				rpcC2M_ChangeMemberPositionNew.oArg.position = (bIncrease ? XGuildDocument.GuildPP.GetHigherPosition(guildPosition) : XGuildDocument.GuildPP.GetLowerPosition(guildPosition));
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ChangeMemberPositionNew);
			}
		}

		// Token: 0x0600A307 RID: 41735 RVA: 0x001BD6C0 File Offset: 0x001BB8C0
		public GuildPosition GetMemberPosition(ulong memberID)
		{
			GuildPosition result = GuildPosition.GPOS_COUNT;
			for (int i = 0; i < this.m_MemberList.Count; i++)
			{
				bool flag = this.m_MemberList[i].uid == memberID;
				if (flag)
				{
					result = this.m_MemberList[i].position;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600A308 RID: 41736 RVA: 0x001BD720 File Offset: 0x001BB920
		public void ReqChangePosition(ulong uid, GuildPosition toPosition)
		{
			RpcC2M_ChangeMemberPositionNew rpcC2M_ChangeMemberPositionNew = new RpcC2M_ChangeMemberPositionNew();
			rpcC2M_ChangeMemberPositionNew.oArg.roleid = uid;
			rpcC2M_ChangeMemberPositionNew.oArg.position = XFastEnumIntEqualityComparer<GuildPosition>.ToInt(toPosition);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ChangeMemberPositionNew);
		}

		// Token: 0x0600A309 RID: 41737 RVA: 0x001BD760 File Offset: 0x001BB960
		public void OnChangePosition(ChangeGuildPositionArg oArg, ChangeGuildPositionRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				for (int i = 0; i < this.m_MemberList.Count; i++)
				{
					bool flag2 = this.m_MemberList[i].uid == oArg.roleid;
					if (flag2)
					{
						this.m_MemberList[i].position = (GuildPosition)oArg.position;
						bool flag3 = this.GuildMembersView != null && this.GuildMembersView.IsVisible();
						if (flag3)
						{
							this.GuildMembersView.Refresh();
						}
						break;
					}
				}
			}
		}

		// Token: 0x0600A30A RID: 41738 RVA: 0x001BD814 File Offset: 0x001BBA14
		public void ReqKickAss(ulong uid)
		{
			RpcC2M_LeaveFromGuild rpcC2M_LeaveFromGuild = new RpcC2M_LeaveFromGuild();
			rpcC2M_LeaveFromGuild.oArg.roleID = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_LeaveFromGuild);
		}

		// Token: 0x0600A30B RID: 41739 RVA: 0x001BD844 File Offset: 0x001BBA44
		public void OnKickAss(LeaveGuildArg oArg, LeaveGuildRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				for (int i = 0; i < this.m_MemberList.Count; i++)
				{
					bool flag2 = this.m_MemberList[i].uid == oArg.roleID;
					if (flag2)
					{
						this.m_MemberList.RemoveAt(i);
						XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
						specificDocument.BasicData.memberCount -= 1U;
						bool flag3 = this.GuildMembersView != null && this.GuildMembersView.IsVisible();
						if (flag3)
						{
							this.GuildMembersView.RefreshAll(false);
						}
						break;
					}
				}
			}
		}

		// Token: 0x0600A30C RID: 41740 RVA: 0x001BD910 File Offset: 0x001BBB10
		public void RefreshRedPointState()
		{
			bool flag = (ulong)(this.MaxFatigue - this.FetchedFatigue) < (ulong)((long)this.REDPOINT_FATIGUE_COUNT);
			if (flag)
			{
				XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_GuildHall_Member, false);
			}
			else
			{
				int num = 0;
				for (int i = 0; i < this.m_MemberList.Count; i++)
				{
					bool flag2 = this.m_MemberList[i].fetchState == FetchState.FS_CAN_FETCH;
					if (flag2)
					{
						num++;
					}
				}
				XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_GuildHall_Member, num >= this.REDPOINT_FATIGUE_COUNT);
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildHall_Member, true);
		}

		// Token: 0x0600A30D RID: 41741 RVA: 0x001BD9BC File Offset: 0x001BBBBC
		public void ReqSendFatigue(int index)
		{
			RpcC2M_GuildFatigueOPNew rpcC2M_GuildFatigueOPNew = new RpcC2M_GuildFatigueOPNew();
			bool flag = index < 0 || index >= this.m_MemberList.Count;
			if (!flag)
			{
				rpcC2M_GuildFatigueOPNew.oArg.targetID = this.m_MemberList[index].uid;
				rpcC2M_GuildFatigueOPNew.oArg.optype = 0;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildFatigueOPNew);
			}
		}

		// Token: 0x0600A30E RID: 41742 RVA: 0x001BDA24 File Offset: 0x001BBC24
		public void ReqOneKeySendFatigue()
		{
			RpcC2M_GuildFatigueOPNew rpcC2M_GuildFatigueOPNew = new RpcC2M_GuildFatigueOPNew();
			rpcC2M_GuildFatigueOPNew.oArg.targetID = 0UL;
			rpcC2M_GuildFatigueOPNew.oArg.optype = 0;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildFatigueOPNew);
		}

		// Token: 0x0600A30F RID: 41743 RVA: 0x001BDA60 File Offset: 0x001BBC60
		public void ReqReceiveFatigue(int index)
		{
			RpcC2M_GuildFatigueOPNew rpcC2M_GuildFatigueOPNew = new RpcC2M_GuildFatigueOPNew();
			bool flag = index < 0 || index >= this.m_MemberList.Count;
			if (!flag)
			{
				rpcC2M_GuildFatigueOPNew.oArg.targetID = this.m_MemberList[index].uid;
				rpcC2M_GuildFatigueOPNew.oArg.optype = 1;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildFatigueOPNew);
			}
		}

		// Token: 0x0600A310 RID: 41744 RVA: 0x001BDAC8 File Offset: 0x001BBCC8
		public void ReqOneKeyReceiveFatigue()
		{
			RpcC2M_GuildFatigueOPNew rpcC2M_GuildFatigueOPNew = new RpcC2M_GuildFatigueOPNew();
			rpcC2M_GuildFatigueOPNew.oArg.targetID = 0UL;
			rpcC2M_GuildFatigueOPNew.oArg.optype = 1;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildFatigueOPNew);
		}

		// Token: 0x0600A311 RID: 41745 RVA: 0x001BDB04 File Offset: 0x001BBD04
		public void OnOperateFatigue(GuildFatigueArg oArg, GuildFatigueRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				bool flag2 = oRes.totalrecv > 0;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FATIGUE_RECEIVED", new object[]
					{
						oRes.totalrecv
					}), "fece00");
				}
				bool flag3 = oRes.totalsend > 0;
				if (flag3)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FATIGUE_SENT", new object[]
					{
						oRes.totalsend
					}), "fece00");
				}
				bool flag4 = oArg.targetID == 0UL;
				if (flag4)
				{
					bool flag5 = oArg.optype == 0;
					if (flag5)
					{
						for (int i = 0; i < this.m_MemberList.Count; i++)
						{
							this.m_MemberList[i].canSend = false;
						}
					}
					else
					{
						this.ReqMemberList();
					}
				}
				else
				{
					for (int j = 0; j < this.m_MemberList.Count; j++)
					{
						bool flag6 = this.m_MemberList[j].uid == oArg.targetID;
						if (flag6)
						{
							bool flag7 = oArg.optype == 0;
							if (flag7)
							{
								this.m_MemberList[j].canSend = false;
							}
							else
							{
								bool flag8 = this.m_MemberList[j].fetchState == FetchState.FS_CAN_FETCH;
								if (flag8)
								{
									this.m_MemberList[j].fetchState = FetchState.FS_FETCHED;
								}
								this.m_FatigueFetched += 1U;
								bool flag9 = this.GuildMembersView != null && this.GuildMembersView.IsVisible();
								if (flag9)
								{
									this.GuildMembersView.RefreshFatigue();
								}
							}
							break;
						}
					}
				}
				bool flag10 = this.GuildMembersView != null && this.GuildMembersView.IsVisible();
				if (flag10)
				{
					this.GuildMembersView.Refresh();
				}
				this.RefreshRedPointState();
			}
		}

		// Token: 0x0600A312 RID: 41746 RVA: 0x001BDD24 File Offset: 0x001BBF24
		public void RefreshMemberTaskScore(ulong roleid, uint score)
		{
			for (int i = 0; i < this.MemberList.Count; i++)
			{
				bool flag = this.MemberList[i].uid == roleid;
				if (flag)
				{
					this.MemberList[i].taskScore = score;
					break;
				}
			}
		}

		// Token: 0x04003ADE RID: 15070
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildMemberDocument");

		// Token: 0x04003AE0 RID: 15072
		private List<XGuildMember> m_MemberList = new List<XGuildMember>();

		// Token: 0x04003AE1 RID: 15073
		private List<ulong> m_GuildInheritUids = new List<ulong>();

		// Token: 0x04003AE2 RID: 15074
		private GuildMemberSortType m_SortType = GuildMemberSortType.GMST_CONTRIBUTION;

		// Token: 0x04003AE3 RID: 15075
		private int m_Direction = -1;

		// Token: 0x04003AE4 RID: 15076
		private uint m_FatigueMax;

		// Token: 0x04003AE5 RID: 15077
		private uint m_FatigueFetched;

		// Token: 0x04003AE6 RID: 15078
		private int REDPOINT_FATIGUE_COUNT = 20;
	}
}
