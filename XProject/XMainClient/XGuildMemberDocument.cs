using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildMemberDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildMemberDocument.uuID;
			}
		}

		public XGuildMembersView GuildMembersView { get; set; }

		public List<XGuildMember> MemberList
		{
			get
			{
				return this.m_MemberList;
			}
		}

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

		public int SortDirection
		{
			get
			{
				return this.m_Direction;
			}
		}

		public uint MaxFatigue
		{
			get
			{
				return this.m_FatigueMax;
			}
		}

		public uint FetchedFatigue
		{
			get
			{
				return this.m_FatigueFetched;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.REDPOINT_FATIGUE_COUNT = XSingleton<XGlobalConfig>.singleton.GetInt("GuildFatigueRedPointCount");
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_GuildPositionChanged, new XComponent.XEventHandler(this.OnPositionChanged));
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnInGuildStateChanged));
		}

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

		public bool CheckGuildInheritUids(ulong uid)
		{
			return this.m_GuildInheritUids.Contains(uid);
		}

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

		public void ReqMemberList()
		{
			RpcC2M_AskGuildMembers rpc = new RpcC2M_AskGuildMembers();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.GuildMembersView != null && this.GuildMembersView.IsVisible();
			if (flag)
			{
				this.ReqMemberList();
			}
		}

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

		public void ReqChangePosition(ulong uid, GuildPosition toPosition)
		{
			RpcC2M_ChangeMemberPositionNew rpcC2M_ChangeMemberPositionNew = new RpcC2M_ChangeMemberPositionNew();
			rpcC2M_ChangeMemberPositionNew.oArg.roleid = uid;
			rpcC2M_ChangeMemberPositionNew.oArg.position = XFastEnumIntEqualityComparer<GuildPosition>.ToInt(toPosition);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ChangeMemberPositionNew);
		}

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

		public void ReqKickAss(ulong uid)
		{
			RpcC2M_LeaveFromGuild rpcC2M_LeaveFromGuild = new RpcC2M_LeaveFromGuild();
			rpcC2M_LeaveFromGuild.oArg.roleID = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_LeaveFromGuild);
		}

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

		public void ReqOneKeySendFatigue()
		{
			RpcC2M_GuildFatigueOPNew rpcC2M_GuildFatigueOPNew = new RpcC2M_GuildFatigueOPNew();
			rpcC2M_GuildFatigueOPNew.oArg.targetID = 0UL;
			rpcC2M_GuildFatigueOPNew.oArg.optype = 0;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildFatigueOPNew);
		}

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

		public void ReqOneKeyReceiveFatigue()
		{
			RpcC2M_GuildFatigueOPNew rpcC2M_GuildFatigueOPNew = new RpcC2M_GuildFatigueOPNew();
			rpcC2M_GuildFatigueOPNew.oArg.targetID = 0UL;
			rpcC2M_GuildFatigueOPNew.oArg.optype = 1;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildFatigueOPNew);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildMemberDocument");

		private List<XGuildMember> m_MemberList = new List<XGuildMember>();

		private List<ulong> m_GuildInheritUids = new List<ulong>();

		private GuildMemberSortType m_SortType = GuildMemberSortType.GMST_CONTRIBUTION;

		private int m_Direction = -1;

		private uint m_FatigueMax;

		private uint m_FatigueFetched;

		private int REDPOINT_FATIGUE_COUNT = 20;
	}
}
