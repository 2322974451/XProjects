using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading;
using KKSG;
using MiniJSON;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000900 RID: 2304
	internal class XDragonGuildDocument : XDocComponent
	{
		// Token: 0x17002B42 RID: 11074
		// (get) Token: 0x06008B38 RID: 35640 RVA: 0x0012969C File Offset: 0x0012789C
		public override uint ID
		{
			get
			{
				return XDragonGuildDocument.uuID;
			}
		}

		// Token: 0x17002B43 RID: 11075
		// (get) Token: 0x06008B39 RID: 35641 RVA: 0x001296B4 File Offset: 0x001278B4
		public static XDragonGuildDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XDragonGuildDocument.uuID) as XDragonGuildDocument;
			}
		}

		// Token: 0x17002B44 RID: 11076
		// (get) Token: 0x06008B3A RID: 35642 RVA: 0x001296E0 File Offset: 0x001278E0
		public static DragonGuildTable DragonGuildBuffTable
		{
			get
			{
				return XDragonGuildDocument.m_pDragonGuildTable;
			}
		}

		// Token: 0x06008B3B RID: 35643 RVA: 0x001296F8 File Offset: 0x001278F8
		public static string GetPortraitName(int index)
		{
			return "ghicon_" + index.ToString();
		}

		// Token: 0x06008B3C RID: 35644 RVA: 0x0012971C File Offset: 0x0012791C
		public DragonGuildIntroduce.RowData GetIntroduce(string helpName)
		{
			return XDragonGuildDocument.m_IntroduceTable.GetByHelpName(helpName);
		}

		// Token: 0x17002B45 RID: 11077
		// (get) Token: 0x06008B3D RID: 35645 RVA: 0x0012973C File Offset: 0x0012793C
		public static XDragonGuildPP DragonGuildPP
		{
			get
			{
				return XDragonGuildDocument._DragonGuildPP;
			}
		}

		// Token: 0x17002B46 RID: 11078
		// (get) Token: 0x06008B3E RID: 35646 RVA: 0x00129754 File Offset: 0x00127954
		// (set) Token: 0x06008B3F RID: 35647 RVA: 0x0012976C File Offset: 0x0012796C
		public uint CurDragonGuildLevel
		{
			get
			{
				return this.m_curDragonGuildLevel;
			}
			set
			{
				this.m_curDragonGuildLevel = value;
			}
		}

		// Token: 0x06008B40 RID: 35648 RVA: 0x00129778 File Offset: 0x00127978
		public bool IsInDragonGuild()
		{
			return this.m_pBaseData.uid > 0UL;
		}

		// Token: 0x17002B47 RID: 11079
		// (get) Token: 0x06008B41 RID: 35649 RVA: 0x0012979C File Offset: 0x0012799C
		public XDragonGuildBaseData BaseData
		{
			get
			{
				return this.m_pBaseData;
			}
		}

		// Token: 0x17002B48 RID: 11080
		// (get) Token: 0x06008B42 RID: 35650 RVA: 0x001297B4 File Offset: 0x001279B4
		public List<DragonGuildShopRecord> ShopRecordList
		{
			get
			{
				return this.m_shopRecordList;
			}
		}

		// Token: 0x17002B49 RID: 11081
		// (get) Token: 0x06008B43 RID: 35651 RVA: 0x001297CC File Offset: 0x001279CC
		// (set) Token: 0x06008B44 RID: 35652 RVA: 0x001297E4 File Offset: 0x001279E4
		public bool IsHadLivenessRedPoint
		{
			get
			{
				return this.m_bIsHadLivenessRedPoint;
			}
			set
			{
				bool flag = this.m_bIsHadLivenessRedPoint != value;
				if (flag)
				{
					this.m_bIsHadLivenessRedPoint = value;
					DlgBase<XFriendsView, XFriendsBehaviour>.singleton.SetRedPoint(TabIndex.DragonGuild, this.IsHadRedDot);
					bool flag2 = this.View != null && this.View.IsVisible();
					if (flag2)
					{
						this.View.RefreshUIRedPoint();
					}
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Friends, true);
					bool flag3 = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsVisible();
					if (flag3)
					{
						DlgBase<XFriendsView, XFriendsBehaviour>.singleton.UpdateRedpointUI();
					}
				}
			}
		}

		// Token: 0x17002B4A RID: 11082
		// (get) Token: 0x06008B45 RID: 35653 RVA: 0x0012986C File Offset: 0x00127A6C
		// (set) Token: 0x06008B46 RID: 35654 RVA: 0x00129884 File Offset: 0x00127A84
		public bool IsHadRecordRedPoint
		{
			get
			{
				return this.m_bIsHadRecordRedPoint;
			}
			set
			{
				bool flag = this.m_bIsHadRecordRedPoint != value;
				if (flag)
				{
					this.m_bIsHadRecordRedPoint = value;
					DlgBase<XFriendsView, XFriendsBehaviour>.singleton.SetRedPoint(TabIndex.DragonGuild, this.IsHadRedDot);
					bool flag2 = this.View != null && this.View.IsVisible();
					if (flag2)
					{
						this.View.RefreshUIRedPoint();
					}
					XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Friends, true);
					bool flag3 = DlgBase<XFriendsView, XFriendsBehaviour>.singleton.IsVisible();
					if (flag3)
					{
						DlgBase<XFriendsView, XFriendsBehaviour>.singleton.UpdateRedpointUI();
					}
				}
			}
		}

		// Token: 0x17002B4B RID: 11083
		// (get) Token: 0x06008B47 RID: 35655 RVA: 0x0012990C File Offset: 0x00127B0C
		public bool IsHadRedDot
		{
			get
			{
				bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_GuildCollectSummon);
				return !flag && (this.m_bIsHadRecordRedPoint | this.IsHadLivenessRedPoint);
			}
		}

		// Token: 0x17002B4C RID: 11084
		// (get) Token: 0x06008B48 RID: 35656 RVA: 0x00129948 File Offset: 0x00127B48
		// (set) Token: 0x06008B49 RID: 35657 RVA: 0x00129960 File Offset: 0x00127B60
		public DragonGuildMemberSortType SortType
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
					this.m_Direction = XDragonGuildMember.DefaultSortDirection[XFastEnumIntEqualityComparer<DragonGuildMemberSortType>.ToInt(value)];
				}
				else
				{
					this.m_Direction = -this.m_Direction;
				}
				this.m_SortType = value;
			}
		}

		// Token: 0x17002B4D RID: 11085
		// (get) Token: 0x06008B4A RID: 35658 RVA: 0x001299A8 File Offset: 0x00127BA8
		public int SortDirection
		{
			get
			{
				return this.m_Direction;
			}
		}

		// Token: 0x06008B4B RID: 35659 RVA: 0x001299C0 File Offset: 0x00127BC0
		public static void Execute(OnLoadedCallback callback = null)
		{
			XDragonGuildDocument.AsyncLoader.AddTask("Table/DragonGuildPermission", XDragonGuildDocument.m_PermissionTable, false);
			XDragonGuildDocument.AsyncLoader.AddTask("Table/DragonGuildConfig", XDragonGuildDocument.m_ConfigTable, false);
			XDragonGuildDocument.AsyncLoader.AddTask("Table/DragonGuildLiveness", XDragonGuildDocument.m_dragonguildlivenessTab, false);
			XDragonGuildDocument.AsyncLoader.AddTask("Table/DragonGuildIntroduce", XDragonGuildDocument.m_IntroduceTable, false);
			XDragonGuildDocument.AsyncLoader.AddTask("Table/DragonGuild", XDragonGuildDocument.m_pDragonGuildTable, false);
			XDragonGuildDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008B4C RID: 35660 RVA: 0x00129A48 File Offset: 0x00127C48
		public static void OnTableLoaded()
		{
			XDragonGuildDocument.DragonGuildLivenessData = new DragonGuildLiveness(XDragonGuildDocument.m_dragonguildlivenessTab);
			XDragonGuildDocument.DragonGuildPP.InitTable(XDragonGuildDocument.m_PermissionTable);
		}

		// Token: 0x06008B4D RID: 35661 RVA: 0x00129A6A File Offset: 0x00127C6A
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._bInited = false;
			this.m_Position = DragonGuildPosition.DGPOS_COUNT;
			this.m_pBaseData.uid = 0UL;
			this.m_pBaseData.level = 0U;
		}

		// Token: 0x06008B4E RID: 35662 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x17002B4E RID: 11086
		// (get) Token: 0x06008B4F RID: 35663 RVA: 0x00129A9C File Offset: 0x00127C9C
		public List<XDragonGuildMember> MemberList
		{
			get
			{
				return this.m_MemberList;
			}
		}

		// Token: 0x06008B50 RID: 35664 RVA: 0x00129AB4 File Offset: 0x00127CB4
		public bool IsMyDragonGuildMember(ulong dragonguilduid)
		{
			bool flag = !this.IsInDragonGuild();
			return !flag && this.m_pBaseData.uid == dragonguilduid;
		}

		// Token: 0x06008B51 RID: 35665 RVA: 0x00129AE8 File Offset: 0x00127CE8
		public void SortAndShow()
		{
			XDragonGuildMember.playerID = XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
			XDragonGuildMember.dir = this.m_Direction;
			XDragonGuildMember.sortType = this.m_SortType;
			CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
			Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(XSingleton<XGlobalConfig>.singleton.GetValue("Culture"));
			this.m_MemberList.Sort();
			Thread.CurrentThread.CurrentCulture = currentCulture;
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshMemberList(true);
			}
		}

		// Token: 0x06008B52 RID: 35666 RVA: 0x00129B90 File Offset: 0x00127D90
		public DragonGuildPosition GetMemberPosition(ulong memberID)
		{
			DragonGuildPosition result = DragonGuildPosition.DGPOS_COUNT;
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

		// Token: 0x06008B53 RID: 35667 RVA: 0x00129BF0 File Offset: 0x00127DF0
		public void ReqChangePosition(ulong uid, DragonGuildPosition toPosition)
		{
			RpcC2M_ChangeDragonGuildPosition rpcC2M_ChangeDragonGuildPosition = new RpcC2M_ChangeDragonGuildPosition();
			rpcC2M_ChangeDragonGuildPosition.oArg.roleid = uid;
			rpcC2M_ChangeDragonGuildPosition.oArg.position = (uint)XFastEnumIntEqualityComparer<DragonGuildPosition>.ToInt(toPosition);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ChangeDragonGuildPosition);
		}

		// Token: 0x06008B54 RID: 35668 RVA: 0x00129C30 File Offset: 0x00127E30
		public void OnChangePosition(ChangeDragonGuildPositionArg oArg, ChangeDragonGuildPositionRes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_DG_NOT_IN_SAME;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("DRAGON_GUILD_MEMBER_LEAVE"), "fece00");
				this.ReqMemberList();
			}
			else
			{
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
				}
				else
				{
					for (int i = 0; i < this.m_MemberList.Count; i++)
					{
						bool flag3 = this.m_MemberList[i].uid == oArg.roleid;
						if (flag3)
						{
							this.m_MemberList[i].position = (DragonGuildPosition)oArg.position;
							bool flag4 = this.View != null && this.View.IsVisible();
							if (flag4)
							{
								this.View.RefreshPage();
							}
							break;
						}
					}
				}
			}
		}

		// Token: 0x06008B55 RID: 35669 RVA: 0x00129D20 File Offset: 0x00127F20
		public void ReqMemberList()
		{
			RpcC2M_AskDragonGuildMembers rpc = new RpcC2M_AskDragonGuildMembers();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008B56 RID: 35670 RVA: 0x00129D40 File Offset: 0x00127F40
		public void OnGetMemberList(DragonGuildMemberRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				this.m_GuildInheritUids.Clear();
				int num = oRes.members.Count - this.m_MemberList.Count;
				for (int i = 0; i < num; i++)
				{
					XDragonGuildMember item = new XDragonGuildMember();
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
						XDragonGuildMember xdragonGuildMember = this.m_MemberList[j];
						bool flag4 = xdragonGuildMember.position == DragonGuildPosition.DGPOS_LEADER;
						if (flag4)
						{
							this.m_pBaseData.leaderName = xdragonGuildMember.name;
							this.m_pBaseData.leaderuid = xdragonGuildMember.uid;
						}
					}
				}
				this.m_pBaseData.memberCount = (uint)this.m_MemberList.Count;
				bool flag5 = this.View != null && this.View.IsVisible();
				if (flag5)
				{
					this.View.RefreshPage();
					this.SortAndShow();
				}
				XGuildMemberListEventArgs @event = XEventPool<XGuildMemberListEventArgs>.GetEvent();
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x06008B57 RID: 35671 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x17002B4F RID: 11087
		// (get) Token: 0x06008B58 RID: 35672 RVA: 0x00129EF8 File Offset: 0x001280F8
		public ulong UID
		{
			get
			{
				return this.m_pBaseData.uid;
			}
		}

		// Token: 0x06008B59 RID: 35673 RVA: 0x00129F18 File Offset: 0x00128118
		public bool SetID(ulong id)
		{
			bool result = !this._bInited || this.m_pBaseData.uid != id;
			this.m_pBaseData.uid = id;
			return result;
		}

		// Token: 0x06008B5A RID: 35674 RVA: 0x00129F54 File Offset: 0x00128154
		public uint GetMaxExp()
		{
			bool flag = this.BaseData.level > 0U && (ulong)this.BaseData.level <= (ulong)((long)XDragonGuildDocument.m_ConfigTable.Table.Length);
			uint result;
			if (flag)
			{
				result = XDragonGuildDocument.m_ConfigTable.Table[(int)(this.BaseData.level - 1U)].DragonGuildExpNeed;
			}
			else
			{
				result = 1U;
			}
			return result;
		}

		// Token: 0x06008B5B RID: 35675 RVA: 0x00129FBC File Offset: 0x001281BC
		public uint GetMaxMemberCount()
		{
			bool flag = this.BaseData.level > 0U && (ulong)this.BaseData.level <= (ulong)((long)XDragonGuildDocument.m_ConfigTable.Table.Length);
			uint result;
			if (flag)
			{
				result = XDragonGuildDocument.m_ConfigTable.Table[(int)(this.BaseData.level - 1U)].DragonGuildNumber;
			}
			else
			{
				result = 1U;
			}
			return result;
		}

		// Token: 0x06008B5C RID: 35676 RVA: 0x0012A024 File Offset: 0x00128224
		public bool SetLevel(uint newLevel)
		{
			bool result = this.m_pBaseData.level != 0U && this.m_pBaseData.level != newLevel && this.m_pBaseData.uid > 0UL;
			this.m_pBaseData.level = newLevel;
			return result;
		}

		// Token: 0x06008B5D RID: 35677 RVA: 0x0012A074 File Offset: 0x00128274
		public bool IsMaxLevel()
		{
			return (long)XDragonGuildDocument.m_ConfigTable.Table.Length == (long)((ulong)this.m_pBaseData.level);
		}

		// Token: 0x06008B5E RID: 35678 RVA: 0x0012A0A4 File Offset: 0x001282A4
		public bool SetPosition(DragonGuildPosition newPos)
		{
			bool result = this.m_Position != DragonGuildPosition.DGPOS_COUNT && this.m_Position != newPos && this.m_pBaseData.uid > 0UL;
			this.m_Position = newPos;
			return result;
		}

		// Token: 0x17002B50 RID: 11088
		// (get) Token: 0x06008B5F RID: 35679 RVA: 0x0012A0E4 File Offset: 0x001282E4
		public DragonGuildPosition Position
		{
			get
			{
				return this.m_Position;
			}
		}

		// Token: 0x06008B60 RID: 35680 RVA: 0x0012A0FC File Offset: 0x001282FC
		public bool SetTotalPPT(ulong newTotalPPT)
		{
			bool result = newTotalPPT != 0UL && newTotalPPT != this.m_pBaseData.totalPPT && this.m_pBaseData.uid > 0UL;
			this.m_pBaseData.totalPPT = newTotalPPT;
			return result;
		}

		// Token: 0x06008B61 RID: 35681 RVA: 0x0012A140 File Offset: 0x00128340
		public bool IHavePermission(DragonGuildPermission pem)
		{
			return XDragonGuildDocument.DragonGuildPP.HasPermission(this.m_Position, pem);
		}

		// Token: 0x06008B62 RID: 35682 RVA: 0x0012A164 File Offset: 0x00128364
		public bool CheckPermission(DragonGuildPermission pem)
		{
			bool flag = !this.IsInDragonGuild();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.IHavePermission(pem);
				if (flag2)
				{
					result = true;
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_DG_NO_PERMISSION, "fece00");
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06008B63 RID: 35683 RVA: 0x0012A1AC File Offset: 0x001283AC
		public void InitData(PtcM2C_LoginDragonGuildInfo data)
		{
			bool flag = this.SetID(data.Data.dgid);
			bool flag2 = this.SetPosition((DragonGuildPosition)data.Data.position);
			bool flag3 = this.SetLevel(data.Data.level);
			this.m_pBaseData.dragonGuildName = data.Data.name;
			bool flag4 = this.SetTotalPPT(data.Data.totalPPT);
			this.m_pBaseData.memberCount = data.Data.memberCount;
			this.m_pBaseData.maxMemberCount = this.GetMaxMemberCount();
			this.m_pBaseData.curexp = data.Data.exp;
			bool flag5 = data.Data.mapId == 0U;
			if (flag5)
			{
				this.m_pBaseData.sceneName = XStringDefineProxy.GetString("DRAGON_GUILD_NO_PASS_SCENE");
			}
			else
			{
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(data.Data.mapId);
				bool flag6 = sceneData != null;
				if (flag6)
				{
					this.m_pBaseData.sceneName = sceneData.Comment;
				}
				else
				{
					this.m_pBaseData.sceneName = XStringDefineProxy.GetString("DRAGON_GUILD_NO_PASS_SCENE");
					XSingleton<XDebug>.singleton.AddErrorLog2("XDragonGuildRankInfo|can't finde scene id=", new object[]
					{
						data.Data.mapId
					});
				}
			}
			this.m_pBaseData.sceneCnt = data.Data.mapCnt;
			this.QueryWXGroup();
			this.QueryQQGroup();
			bool flag7 = flag;
			if (flag7)
			{
				this.OnInDragonGuildStateChanged(this.IsInDragonGuild());
			}
			bool flag8 = flag2;
			if (flag8)
			{
				this.OnDragonGuildPositionChange();
			}
			bool flag9 = flag3 || flag4;
			if (flag9)
			{
				this.OnDragonGuildInfoChange();
			}
			XDragonGuildInfoChange @event = XEventPool<XDragonGuildInfoChange>.GetEvent();
			@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			XDragonGuildInfoChange event2 = XEventPool<XDragonGuildInfoChange>.GetEvent();
			event2.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(event2);
			this._bInited = true;
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.SetRedPoint(TabIndex.DragonGuild, this.IsHadRedDot);
		}

		// Token: 0x06008B64 RID: 35684 RVA: 0x0012A3C4 File Offset: 0x001285C4
		private void OnDragonGuildInfoChange()
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshLabelInfo();
			}
		}

		// Token: 0x06008B65 RID: 35685 RVA: 0x0012A3FC File Offset: 0x001285FC
		private void OnDragonGuildLevelChange()
		{
			uint level = this.m_pBaseData.level;
			for (int i = 0; i < XDragonGuildDocument.m_ConfigTable.Table.Length; i++)
			{
				DragonGuildConfigTable.RowData rowData = XDragonGuildDocument.m_ConfigTable.Table[i];
				bool flag = rowData.DragonGuildLevel == this.m_pBaseData.level;
				if (flag)
				{
					this.BaseData.maxMemberCount = rowData.DragonGuildNumber;
				}
			}
			bool flag2 = this.View != null && this.View.IsVisible();
			if (flag2)
			{
				this.View.RefreshLabelInfo();
			}
		}

		// Token: 0x06008B66 RID: 35686 RVA: 0x0012A498 File Offset: 0x00128698
		protected void OnInDragonGuildStateChanged(bool bIsEnter)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.RefreshDragonGuildPage();
			bool flag = !this._bInited;
			if (!flag)
			{
				bool flag2 = !bIsEnter;
				if (flag2)
				{
					this.IsHadLivenessRedPoint = false;
					this.IsHadRecordRedPoint = false;
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DRAGON_GUILD_EXIT_GUILD"), "fece00");
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DRAGON_GUILD_JOIN_GUILD"), "fece00");
				}
			}
		}

		// Token: 0x06008B67 RID: 35687 RVA: 0x0012A514 File Offset: 0x00128714
		protected void OnDragonGuildPositionChange()
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				ulong entityID = XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
				for (int i = 0; i < this.m_MemberList.Count; i++)
				{
					bool flag2 = this.m_MemberList[i].uid == entityID;
					if (flag2)
					{
						this.m_MemberList[i].position = this.m_Position;
						this.View.RefreshPage();
						break;
					}
				}
			}
			bool flag3 = DlgBase<XDragonGuildApproveDlg, XDragonGuildApproveBehaviour>.singleton.IsVisible() && !this.IHavePermission(DragonGuildPermission.DGEM_APPROVAL);
			if (flag3)
			{
				DlgBase<XDragonGuildApproveDlg, XDragonGuildApproveBehaviour>.singleton.SetVisible(false, true);
			}
		}

		// Token: 0x06008B68 RID: 35688 RVA: 0x0012A5E0 File Offset: 0x001287E0
		public void QueryWXGroup()
		{
			bool flag = XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_WeChat || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_DragonGuild_Bind_Group);
			if (!flag)
			{
				XSingleton<PDatabase>.singleton.wxGroupCallbackType = WXGroupCallBackType.DragonGuild;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["unionID"] = this.UID.ToString();
				dictionary["openIdList"] = XSingleton<XLoginDocument>.singleton.OpenID;
				string param = Json.Serialize(dictionary);
				XSingleton<XUpdater.XUpdater>.singleton.XPlatform.QueryWXGroup(param);
			}
		}

		// Token: 0x06008B69 RID: 35689 RVA: 0x0012A670 File Offset: 0x00128870
		public void QueryQQGroup()
		{
			bool flag = XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_QQ || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_DragonGuild_Bind_Group);
			if (!flag)
			{
				RpcC2M_GetDragonGuildBindInfo rpcC2M_GetDragonGuildBindInfo = new RpcC2M_GetDragonGuildBindInfo();
				rpcC2M_GetDragonGuildBindInfo.oArg.token = XSingleton<XLoginDocument>.singleton.TokenCache;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetDragonGuildBindInfo);
				XSingleton<XDebug>.singleton.AddLog("[QQGroup QueryQQGroup]token:" + XSingleton<XLoginDocument>.singleton.TokenCache, null, null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		// Token: 0x06008B6A RID: 35690 RVA: 0x0012A6F4 File Offset: 0x001288F4
		public void OnGetQQGroupBindInfo(GetDragonGuildBindInfoArg oArg, GetDragonGuildBindInfoRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (!flag)
			{
				this.qqGroupBindStatus = oRes.bind_status;
				this.qqGroupName = oRes.group_name;
				bool flag2 = this.View != null && this.View.IsVisible();
				if (flag2)
				{
					this.View.RefreshQQGroupBtn();
				}
			}
		}

		// Token: 0x06008B6B RID: 35691 RVA: 0x0012A754 File Offset: 0x00128954
		public void BindQQGroup()
		{
			bool flag = XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_QQ || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_DragonGuild_Bind_Group);
			if (!flag)
			{
				RpcC2M_DragonGuildBindGroupReq rpcC2M_DragonGuildBindGroupReq = new RpcC2M_DragonGuildBindGroupReq();
				rpcC2M_DragonGuildBindGroupReq.oArg.token = XSingleton<XLoginDocument>.singleton.TokenCache;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_DragonGuildBindGroupReq);
				XSingleton<XDebug>.singleton.AddLog("[QQGroup BindQQGroup]token:" + XSingleton<XLoginDocument>.singleton.TokenCache, null, null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		// Token: 0x06008B6C RID: 35692 RVA: 0x0012A7D8 File Offset: 0x001289D8
		public void OnBindQQGroup(DragonGuildBindReq oArg, DragonGuildBindRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.result);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("DRAGON_GUILD_BIN_QQ_GROUP_SUC"), "fece00");
				this.qqGroupName = oRes.group_name;
				this.qqGroupBindStatus = GuildBindStatus.GBS_Owner;
				bool flag2 = DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.RefreshQQGroupBtn();
				}
			}
		}

		// Token: 0x06008B6D RID: 35693 RVA: 0x0012A854 File Offset: 0x00128A54
		public void JoinQQGroup()
		{
			bool flag = XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_QQ || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_DragonGuild_Bind_Group);
			if (!flag)
			{
				RpcC2M_DragonGuildJoinBindGroup rpcC2M_DragonGuildJoinBindGroup = new RpcC2M_DragonGuildJoinBindGroup();
				rpcC2M_DragonGuildJoinBindGroup.oArg.token = XSingleton<XLoginDocument>.singleton.TokenCache;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_DragonGuildJoinBindGroup);
				XSingleton<XDebug>.singleton.AddLog("[QQGroup JoinQQGroup]token:" + XSingleton<XLoginDocument>.singleton.TokenCache, null, null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		// Token: 0x06008B6E RID: 35694 RVA: 0x0012A8D8 File Offset: 0x00128AD8
		public void OnJoinBindQQGroup(DragonGuildJoinBindGroupArg oArg, DragonGuildJoinBindGroupRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.result);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("DRAGON_GUILD_JOIN_QQ_GROUP_SUC"), "fece00");
				this.qqGroupBindStatus = GuildBindStatus.GBS_Member;
				bool flag2 = this.View != null && this.View.IsVisible();
				if (flag2)
				{
					this.View.RefreshQQGroupBtn();
				}
			}
		}

		// Token: 0x06008B6F RID: 35695 RVA: 0x0012A958 File Offset: 0x00128B58
		public void UnbindQQGroup()
		{
			bool flag = XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_QQ || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_DragonGuild_Bind_Group);
			if (!flag)
			{
				RpcC2M_DragonGuildUnBindGroup rpcC2M_DragonGuildUnBindGroup = new RpcC2M_DragonGuildUnBindGroup();
				rpcC2M_DragonGuildUnBindGroup.oArg.token = XSingleton<XLoginDocument>.singleton.TokenCache;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_DragonGuildUnBindGroup);
				XSingleton<XDebug>.singleton.AddLog("[QQGroup UnbindQQGroup]token:" + XSingleton<XLoginDocument>.singleton.TokenCache, null, null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		// Token: 0x06008B70 RID: 35696 RVA: 0x0012A9DC File Offset: 0x00128BDC
		public void OnUnbindQQGroup(DragonGuildUnBindGroupArg oArg, DragonGuildUnBindGroupRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.result);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("DRAGON_GUILD_UNBIND_QQ_GROUP_SUC"), "fece00");
				this.qqGroupBindStatus = GuildBindStatus.GBS_NotBind;
				bool flag2 = this.View != null && this.View.IsVisible();
				if (flag2)
				{
					this.View.RefreshQQGroupBtn();
				}
			}
		}

		// Token: 0x06008B71 RID: 35697 RVA: 0x0012AA5C File Offset: 0x00128C5C
		public void ReqLeaveDragonGuild()
		{
			RpcC2M_LeaveFromDragonGuild rpcC2M_LeaveFromDragonGuild = new RpcC2M_LeaveFromDragonGuild();
			rpcC2M_LeaveFromDragonGuild.oArg.roleid = XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_LeaveFromDragonGuild);
		}

		// Token: 0x06008B72 RID: 35698 RVA: 0x0012AA9C File Offset: 0x00128C9C
		public void ReqKickAss(ulong uid)
		{
			RpcC2M_LeaveFromDragonGuild rpcC2M_LeaveFromDragonGuild = new RpcC2M_LeaveFromDragonGuild();
			rpcC2M_LeaveFromDragonGuild.oArg.roleid = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_LeaveFromDragonGuild);
		}

		// Token: 0x06008B73 RID: 35699 RVA: 0x0012AACC File Offset: 0x00128CCC
		public void ReqShopRecords()
		{
			RpcC2M_GetDragonGuildShopRecord rpc = new RpcC2M_GetDragonGuildShopRecord();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008B74 RID: 35700 RVA: 0x0012AAEC File Offset: 0x00128CEC
		public void OnLeaveDragonGuild(LeaveDragonGuildRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

		// Token: 0x06008B75 RID: 35701 RVA: 0x0012AB20 File Offset: 0x00128D20
		public void OnKickAss(LeaveDragonGuildArg oArg, LeaveDragonGuildRes oRes)
		{
			bool flag = oRes.result != ErrorCode.ERR_SUCCESS && oRes.result != ErrorCode.ERR_DG_NOT_IN_SAME;
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
						this.m_MemberList.RemoveAt(i);
						this.BaseData.memberCount = (uint)this.m_MemberList.Count;
						bool flag3 = this.View != null && this.View.IsVisible();
						if (flag3)
						{
							this.View.RefreshMemberList(false);
							this.View.RefreshLabelInfo();
						}
						break;
					}
				}
			}
		}

		// Token: 0x06008B76 RID: 35702 RVA: 0x0012AC04 File Offset: 0x00128E04
		public void OnGetShopRecordBack(GetDragonGuildShopRecordRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.result > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					}
					else
					{
						this.m_shopRecordList.Clear();
						for (int i = 0; i < oRes.record.Count; i++)
						{
							this.m_shopRecordList.Add(new DragonGuildShopRecord(oRes.record[i]));
						}
						bool flag4 = this.ShopRecordsHandler != null && this.ShopRecordsHandler.IsVisible();
						if (flag4)
						{
							this.ShopRecordsHandler.FillContent();
						}
					}
				}
			}
		}

		// Token: 0x06008B77 RID: 35703 RVA: 0x0012AD00 File Offset: 0x00128F00
		public static void OnDragonGuildHyperLinkClick(string param)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall;
			if (!flag)
			{
				string text = "";
				bool flag2 = XLabelSymbolHelper.ParseDragonGuildParam(param, ref text);
				if (flag2)
				{
					bool flag3 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_GuildCollectSummon);
					if (flag3)
					{
						bool flag4 = XDragonGuildDocument.Doc.IsInDragonGuild();
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_DG_ALREADY_IN_DG"), "fece00");
						}
						else
						{
							XDragonGuildListDocument.Doc.ReqSearch(text);
							DlgBase<XFriendsView, XFriendsBehaviour>.singleton.ShowTab(XSysDefine.XSys_GuildCollectSummon);
						}
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DRAGON_GUILD_LOG_CANNOT_JOIN"), "fece00");
					}
				}
			}
		}

		// Token: 0x06008B78 RID: 35704 RVA: 0x0012ADC4 File Offset: 0x00128FC4
		public void OnNameChange(string name)
		{
			this.BaseData.dragonGuildName = name;
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshLabelInfo();
			}
		}

		// Token: 0x06008B79 RID: 35705 RVA: 0x0012AE08 File Offset: 0x00129008
		internal void RefreshWXGroupBtn()
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshWXGroupBtn();
			}
		}

		// Token: 0x04002C82 RID: 11394
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XDragonGuildDocument");

		// Token: 0x04002C83 RID: 11395
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002C84 RID: 11396
		public static DragonGuildLiveness DragonGuildLivenessData = null;

		// Token: 0x04002C85 RID: 11397
		private static DragonGuildPermissionTable m_PermissionTable = new DragonGuildPermissionTable();

		// Token: 0x04002C86 RID: 11398
		private static DragonGuildConfigTable m_ConfigTable = new DragonGuildConfigTable();

		// Token: 0x04002C87 RID: 11399
		private static DragonGuildLivenessTable m_dragonguildlivenessTab = new DragonGuildLivenessTable();

		// Token: 0x04002C88 RID: 11400
		private static DragonGuildIntroduce m_IntroduceTable = new DragonGuildIntroduce();

		// Token: 0x04002C89 RID: 11401
		private static DragonGuildTable m_pDragonGuildTable = new DragonGuildTable();

		// Token: 0x04002C8A RID: 11402
		private static XDragonGuildPP _DragonGuildPP = new XDragonGuildPP();

		// Token: 0x04002C8B RID: 11403
		private uint m_curDragonGuildLevel = 0U;

		// Token: 0x04002C8C RID: 11404
		public DragonGuildShopRecordsHandler ShopRecordsHandler;

		// Token: 0x04002C8D RID: 11405
		private XDragonGuildBaseData m_pBaseData = new XDragonGuildBaseData();

		// Token: 0x04002C8E RID: 11406
		public XDragonGuildMainHandler View;

		// Token: 0x04002C8F RID: 11407
		private List<DragonGuildShopRecord> m_shopRecordList = new List<DragonGuildShopRecord>();

		// Token: 0x04002C90 RID: 11408
		private bool m_bIsHadLivenessRedPoint = false;

		// Token: 0x04002C91 RID: 11409
		private bool m_bIsHadRecordRedPoint = false;

		// Token: 0x04002C92 RID: 11410
		private DragonGuildMemberSortType m_SortType = DragonGuildMemberSortType.DGMST_ACTIVE;

		// Token: 0x04002C93 RID: 11411
		private int m_Direction = -1;

		// Token: 0x04002C94 RID: 11412
		private List<ulong> m_GuildInheritUids = new List<ulong>();

		// Token: 0x04002C95 RID: 11413
		private List<XDragonGuildMember> m_MemberList = new List<XDragonGuildMember>();

		// Token: 0x04002C96 RID: 11414
		private bool _bInited = false;

		// Token: 0x04002C97 RID: 11415
		private DragonGuildPosition m_Position;

		// Token: 0x04002C98 RID: 11416
		public GuildBindStatus qqGroupBindStatus;

		// Token: 0x04002C99 RID: 11417
		public string qqGroupName;
	}
}
