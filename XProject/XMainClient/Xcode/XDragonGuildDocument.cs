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

	internal class XDragonGuildDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XDragonGuildDocument.uuID;
			}
		}

		public static XDragonGuildDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XDragonGuildDocument.uuID) as XDragonGuildDocument;
			}
		}

		public static DragonGuildTable DragonGuildBuffTable
		{
			get
			{
				return XDragonGuildDocument.m_pDragonGuildTable;
			}
		}

		public static string GetPortraitName(int index)
		{
			return "ghicon_" + index.ToString();
		}

		public DragonGuildIntroduce.RowData GetIntroduce(string helpName)
		{
			return XDragonGuildDocument.m_IntroduceTable.GetByHelpName(helpName);
		}

		public static XDragonGuildPP DragonGuildPP
		{
			get
			{
				return XDragonGuildDocument._DragonGuildPP;
			}
		}

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

		public bool IsInDragonGuild()
		{
			return this.m_pBaseData.uid > 0UL;
		}

		public XDragonGuildBaseData BaseData
		{
			get
			{
				return this.m_pBaseData;
			}
		}

		public List<DragonGuildShopRecord> ShopRecordList
		{
			get
			{
				return this.m_shopRecordList;
			}
		}

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

		public bool IsHadRedDot
		{
			get
			{
				bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_GuildCollectSummon);
				return !flag && (this.m_bIsHadRecordRedPoint | this.IsHadLivenessRedPoint);
			}
		}

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

		public int SortDirection
		{
			get
			{
				return this.m_Direction;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XDragonGuildDocument.AsyncLoader.AddTask("Table/DragonGuildPermission", XDragonGuildDocument.m_PermissionTable, false);
			XDragonGuildDocument.AsyncLoader.AddTask("Table/DragonGuildConfig", XDragonGuildDocument.m_ConfigTable, false);
			XDragonGuildDocument.AsyncLoader.AddTask("Table/DragonGuildLiveness", XDragonGuildDocument.m_dragonguildlivenessTab, false);
			XDragonGuildDocument.AsyncLoader.AddTask("Table/DragonGuildIntroduce", XDragonGuildDocument.m_IntroduceTable, false);
			XDragonGuildDocument.AsyncLoader.AddTask("Table/DragonGuild", XDragonGuildDocument.m_pDragonGuildTable, false);
			XDragonGuildDocument.AsyncLoader.Execute(callback);
		}

		public static void OnTableLoaded()
		{
			XDragonGuildDocument.DragonGuildLivenessData = new DragonGuildLiveness(XDragonGuildDocument.m_dragonguildlivenessTab);
			XDragonGuildDocument.DragonGuildPP.InitTable(XDragonGuildDocument.m_PermissionTable);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._bInited = false;
			this.m_Position = DragonGuildPosition.DGPOS_COUNT;
			this.m_pBaseData.uid = 0UL;
			this.m_pBaseData.level = 0U;
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public List<XDragonGuildMember> MemberList
		{
			get
			{
				return this.m_MemberList;
			}
		}

		public bool IsMyDragonGuildMember(ulong dragonguilduid)
		{
			bool flag = !this.IsInDragonGuild();
			return !flag && this.m_pBaseData.uid == dragonguilduid;
		}

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

		public void ReqChangePosition(ulong uid, DragonGuildPosition toPosition)
		{
			RpcC2M_ChangeDragonGuildPosition rpcC2M_ChangeDragonGuildPosition = new RpcC2M_ChangeDragonGuildPosition();
			rpcC2M_ChangeDragonGuildPosition.oArg.roleid = uid;
			rpcC2M_ChangeDragonGuildPosition.oArg.position = (uint)XFastEnumIntEqualityComparer<DragonGuildPosition>.ToInt(toPosition);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_ChangeDragonGuildPosition);
		}

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

		public void ReqMemberList()
		{
			RpcC2M_AskDragonGuildMembers rpc = new RpcC2M_AskDragonGuildMembers();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public ulong UID
		{
			get
			{
				return this.m_pBaseData.uid;
			}
		}

		public bool SetID(ulong id)
		{
			bool result = !this._bInited || this.m_pBaseData.uid != id;
			this.m_pBaseData.uid = id;
			return result;
		}

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

		public bool SetLevel(uint newLevel)
		{
			bool result = this.m_pBaseData.level != 0U && this.m_pBaseData.level != newLevel && this.m_pBaseData.uid > 0UL;
			this.m_pBaseData.level = newLevel;
			return result;
		}

		public bool IsMaxLevel()
		{
			return (long)XDragonGuildDocument.m_ConfigTable.Table.Length == (long)((ulong)this.m_pBaseData.level);
		}

		public bool SetPosition(DragonGuildPosition newPos)
		{
			bool result = this.m_Position != DragonGuildPosition.DGPOS_COUNT && this.m_Position != newPos && this.m_pBaseData.uid > 0UL;
			this.m_Position = newPos;
			return result;
		}

		public DragonGuildPosition Position
		{
			get
			{
				return this.m_Position;
			}
		}

		public bool SetTotalPPT(ulong newTotalPPT)
		{
			bool result = newTotalPPT != 0UL && newTotalPPT != this.m_pBaseData.totalPPT && this.m_pBaseData.uid > 0UL;
			this.m_pBaseData.totalPPT = newTotalPPT;
			return result;
		}

		public bool IHavePermission(DragonGuildPermission pem)
		{
			return XDragonGuildDocument.DragonGuildPP.HasPermission(this.m_Position, pem);
		}

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

		private void OnDragonGuildInfoChange()
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshLabelInfo();
			}
		}

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

		public void ReqLeaveDragonGuild()
		{
			RpcC2M_LeaveFromDragonGuild rpcC2M_LeaveFromDragonGuild = new RpcC2M_LeaveFromDragonGuild();
			rpcC2M_LeaveFromDragonGuild.oArg.roleid = XSingleton<XEntityMgr>.singleton.Player.Attributes.EntityID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_LeaveFromDragonGuild);
		}

		public void ReqKickAss(ulong uid)
		{
			RpcC2M_LeaveFromDragonGuild rpcC2M_LeaveFromDragonGuild = new RpcC2M_LeaveFromDragonGuild();
			rpcC2M_LeaveFromDragonGuild.oArg.roleid = uid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_LeaveFromDragonGuild);
		}

		public void ReqShopRecords()
		{
			RpcC2M_GetDragonGuildShopRecord rpc = new RpcC2M_GetDragonGuildShopRecord();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void OnLeaveDragonGuild(LeaveDragonGuildRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
		}

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

		public void OnNameChange(string name)
		{
			this.BaseData.dragonGuildName = name;
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshLabelInfo();
			}
		}

		internal void RefreshWXGroupBtn()
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.RefreshWXGroupBtn();
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XDragonGuildDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static DragonGuildLiveness DragonGuildLivenessData = null;

		private static DragonGuildPermissionTable m_PermissionTable = new DragonGuildPermissionTable();

		private static DragonGuildConfigTable m_ConfigTable = new DragonGuildConfigTable();

		private static DragonGuildLivenessTable m_dragonguildlivenessTab = new DragonGuildLivenessTable();

		private static DragonGuildIntroduce m_IntroduceTable = new DragonGuildIntroduce();

		private static DragonGuildTable m_pDragonGuildTable = new DragonGuildTable();

		private static XDragonGuildPP _DragonGuildPP = new XDragonGuildPP();

		private uint m_curDragonGuildLevel = 0U;

		public DragonGuildShopRecordsHandler ShopRecordsHandler;

		private XDragonGuildBaseData m_pBaseData = new XDragonGuildBaseData();

		public XDragonGuildMainHandler View;

		private List<DragonGuildShopRecord> m_shopRecordList = new List<DragonGuildShopRecord>();

		private bool m_bIsHadLivenessRedPoint = false;

		private bool m_bIsHadRecordRedPoint = false;

		private DragonGuildMemberSortType m_SortType = DragonGuildMemberSortType.DGMST_ACTIVE;

		private int m_Direction = -1;

		private List<ulong> m_GuildInheritUids = new List<ulong>();

		private List<XDragonGuildMember> m_MemberList = new List<XDragonGuildMember>();

		private bool _bInited = false;

		private DragonGuildPosition m_Position;

		public GuildBindStatus qqGroupBindStatus;

		public string qqGroupName;
	}
}
