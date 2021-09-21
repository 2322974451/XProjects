using System;
using System.Collections.Generic;
using KKSG;
using MiniJSON;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A71 RID: 2673
	internal class XGuildDocument : XDocComponent
	{
		// Token: 0x17002F62 RID: 12130
		// (get) Token: 0x0600A274 RID: 41588 RVA: 0x001BABF8 File Offset: 0x001B8DF8
		public override uint ID
		{
			get
			{
				return XGuildDocument.uuID;
			}
		}

		// Token: 0x0600A275 RID: 41589 RVA: 0x001BAC10 File Offset: 0x001B8E10
		public static string GetPortraitName(int index)
		{
			return "ghicon_" + index.ToString();
		}

		// Token: 0x17002F63 RID: 12131
		// (get) Token: 0x0600A276 RID: 41590 RVA: 0x001BAC34 File Offset: 0x001B8E34
		public static XGuildConfig GuildConfig
		{
			get
			{
				return XGuildDocument._GuildConfig;
			}
		}

		// Token: 0x17002F64 RID: 12132
		// (get) Token: 0x0600A277 RID: 41591 RVA: 0x001BAC4C File Offset: 0x001B8E4C
		public static XGuildPP GuildPP
		{
			get
			{
				return XGuildDocument._GuildPP;
			}
		}

		// Token: 0x17002F65 RID: 12133
		// (get) Token: 0x0600A278 RID: 41592 RVA: 0x001BAC64 File Offset: 0x001B8E64
		public static bool InGuild
		{
			get
			{
				XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				return specificDocument.bInGuild;
			}
		}

		// Token: 0x17002F66 RID: 12134
		// (get) Token: 0x0600A279 RID: 41593 RVA: 0x001BAC88 File Offset: 0x001B8E88
		public XGuildBasicData BasicData
		{
			get
			{
				return this.m_BasicData;
			}
		}

		// Token: 0x17002F67 RID: 12135
		// (get) Token: 0x0600A27A RID: 41594 RVA: 0x001BACA0 File Offset: 0x001B8EA0
		public ulong UID
		{
			get
			{
				return this.m_BasicData.uid;
			}
		}

		// Token: 0x0600A27B RID: 41595 RVA: 0x001BACC0 File Offset: 0x001B8EC0
		public bool SetID(ulong id)
		{
			bool flag = !this._bInited || this.m_BasicData.uid != id;
			this.m_BasicData.uid = id;
			bool flag2 = flag;
			if (flag2)
			{
				bool bInGuild = this.bInGuild;
				if (bInGuild)
				{
					try
					{
					}
					catch
					{
					}
				}
			}
			return flag;
		}

		// Token: 0x0600A27C RID: 41596 RVA: 0x001BAD28 File Offset: 0x001B8F28
		public bool SetLevel(uint newLevel)
		{
			bool result = this.m_BasicData.level != 0U && this.m_BasicData.level != newLevel && this.m_BasicData.uid > 0UL;
			this.m_BasicData.level = newLevel;
			return result;
		}

		// Token: 0x0600A27D RID: 41597 RVA: 0x001BAD78 File Offset: 0x001B8F78
		public bool SetPosition(GuildPosition newPos)
		{
			bool result = this.m_Position != GuildPosition.GPOS_COUNT && this.m_Position != newPos && this.m_BasicData.uid > 0UL;
			this.m_Position = newPos;
			return result;
		}

		// Token: 0x0600A27E RID: 41598 RVA: 0x001BADB8 File Offset: 0x001B8FB8
		public Guildintroduce.RowData GetIntroduce(string helpName)
		{
			return XGuildDocument.m_IntroduceTable.GetByHelpName(helpName);
		}

		// Token: 0x17002F68 RID: 12136
		// (get) Token: 0x0600A27F RID: 41599 RVA: 0x001BADD8 File Offset: 0x001B8FD8
		public GuildPosition Position
		{
			get
			{
				return this.m_Position;
			}
		}

		// Token: 0x17002F69 RID: 12137
		// (get) Token: 0x0600A280 RID: 41600 RVA: 0x001BADF0 File Offset: 0x001B8FF0
		public uint Level
		{
			get
			{
				return this.m_BasicData.level;
			}
		}

		// Token: 0x17002F6A RID: 12138
		// (get) Token: 0x0600A281 RID: 41601 RVA: 0x001BAE10 File Offset: 0x001B9010
		public uint CurSkillUpCount
		{
			get
			{
				return 0U;
			}
		}

		// Token: 0x17002F6B RID: 12139
		// (get) Token: 0x0600A282 RID: 41602 RVA: 0x001BAE24 File Offset: 0x001B9024
		public uint MaxSkillUpCount
		{
			get
			{
				bool flag = !this.bInGuild;
				uint result;
				if (flag)
				{
					result = 0U;
				}
				else
				{
					result = XGuildDocument.GuildConfig.GetDataByLevel(this.Level).StudySkillTimes;
				}
				return result;
			}
		}

		// Token: 0x17002F6C RID: 12140
		// (get) Token: 0x0600A283 RID: 41603 RVA: 0x001BAE5C File Offset: 0x001B905C
		public string PortraitSprite
		{
			get
			{
				return XGuildDocument.GetPortraitName(this.m_BasicData.portraitIndex);
			}
		}

		// Token: 0x17002F6D RID: 12141
		// (get) Token: 0x0600A284 RID: 41604 RVA: 0x001BAE80 File Offset: 0x001B9080
		public uint CurrentCanUseExp
		{
			get
			{
				return 0U;
			}
		}

		// Token: 0x17002F6E RID: 12142
		// (get) Token: 0x0600A285 RID: 41605 RVA: 0x001BAE94 File Offset: 0x001B9094
		public uint CurrentTotalExp
		{
			get
			{
				bool flag = !this.bInGuild;
				uint result;
				if (flag)
				{
					result = 0U;
				}
				else
				{
					result = XGuildDocument.GuildConfig.GetBaseExp(this.Level) + this.m_BasicData.exp;
				}
				return result;
			}
		}

		// Token: 0x17002F6F RID: 12143
		// (get) Token: 0x0600A286 RID: 41606 RVA: 0x001BAED4 File Offset: 0x001B90D4
		public uint CurrentLevelTotalExp
		{
			get
			{
				bool flag = !this.bInGuild;
				uint result;
				if (flag)
				{
					result = 0U;
				}
				else
				{
					result = XGuildDocument.GuildConfig.GetBaseExp(this.Level) + this.m_BasicData.exp;
				}
				return result;
			}
		}

		// Token: 0x0600A287 RID: 41607 RVA: 0x001BAF14 File Offset: 0x001B9114
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildDocument.AsyncLoader.AddTask("Table/GuildPermission", XGuildDocument.m_PermissionTable, false);
			XGuildDocument.AsyncLoader.AddTask("Table/GuildConfig", XGuildDocument.m_ConfigTable, false);
			XGuildDocument.AsyncLoader.AddTask("Table/GuildIntroduce", XGuildDocument.m_IntroduceTable, false);
			XGuildDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600A288 RID: 41608 RVA: 0x001BAF70 File Offset: 0x001B9170
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._bInited = false;
			this.m_Position = GuildPosition.GPOS_COUNT;
			this.m_BasicData.uid = 0UL;
			this.m_BasicData.level = 0U;
		}

		// Token: 0x0600A289 RID: 41609 RVA: 0x001BAFA2 File Offset: 0x001B91A2
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnInGuildStateChanged));
			base.RegisterEvent(XEventDefine.XEvent_GuildPositionChanged, new XComponent.XEventHandler(this.OnGuildPositionChanged));
		}

		// Token: 0x0600A28A RID: 41610 RVA: 0x001BAFD8 File Offset: 0x001B91D8
		protected bool OnInGuildStateChanged(XEventArgs args)
		{
			XInGuildStateChangedEventArgs xinGuildStateChangedEventArgs = args as XInGuildStateChangedEventArgs;
			bool bRoleInit = xinGuildStateChangedEventArgs.bRoleInit;
			bool result;
			if (bRoleInit)
			{
				result = true;
			}
			else
			{
				bool flag = !xinGuildStateChangedEventArgs.bIsEnter;
				if (flag)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_EXIT_GUILD"), "fece00");
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_JOIN_GUILD"), "fece00");
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600A28B RID: 41611 RVA: 0x001BB048 File Offset: 0x001B9248
		protected bool OnGuildPositionChanged(XEventArgs args)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("GUILD_POSITION_CHANGED", new object[]
			{
				XGuildDocument.GuildPP.GetPositionName(this.m_Position, false)
			}), XStringDefineProxy.GetString(XStringDefine.COMMON_OK));
			return true;
		}

		// Token: 0x0600A28C RID: 41612 RVA: 0x001BB090 File Offset: 0x001B9290
		public void InitData(PtcM2C_LoginGuildInfo data)
		{
			bool flag = this.SetID(data.Data.gid);
			bool flag2 = this.SetPosition((GuildPosition)data.Data.position);
			this.m_BasicData.portraitIndex = (int)data.Data.icon;
			bool flag3 = this.SetLevel((uint)data.Data.level);
			this.m_BasicData.guildName = data.Data.name;
			this.QueryWXGroup();
			this.QueryQQGroup();
			bool flag4 = flag;
			if (flag4)
			{
				XInGuildStateChangedEventArgs @event = XEventPool<XInGuildStateChangedEventArgs>.GetEvent();
				@event.bIsEnter = this.bInGuild;
				@event.bRoleInit = !this._bInited;
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
			bool flag5 = flag2;
			if (flag5)
			{
				XGuildPositionChangedEventArgs event2 = XEventPool<XGuildPositionChangedEventArgs>.GetEvent();
				event2.position = this.m_Position;
				event2.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(event2);
			}
			bool flag6 = flag3;
			if (flag6)
			{
				XGuildLevelChangedEventArgs event3 = XEventPool<XGuildLevelChangedEventArgs>.GetEvent();
				event3.level = this.m_BasicData.level;
				event3.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(event3);
			}
			XGuildInfoChange event4 = XEventPool<XGuildInfoChange>.GetEvent();
			event4.Firer = XSingleton<XEntityMgr>.singleton.Player;
			XSingleton<XEventMgr>.singleton.FireEvent(event4);
			XGuildInfoChange event5 = XEventPool<XGuildInfoChange>.GetEvent();
			event5.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(event5);
			this._bInited = true;
		}

		// Token: 0x0600A28D RID: 41613 RVA: 0x001BB22C File Offset: 0x001B942C
		public static void OnTableLoaded()
		{
			XGuildDocument.GuildPP.InitTable(XGuildDocument.m_PermissionTable);
			XGuildDocument.GuildConfig.Init(XGuildDocument.m_ConfigTable);
		}

		// Token: 0x17002F70 RID: 12144
		// (get) Token: 0x0600A28E RID: 41614 RVA: 0x001BB250 File Offset: 0x001B9450
		public bool bInGuild
		{
			get
			{
				return this.UID > 0UL;
			}
		}

		// Token: 0x0600A28F RID: 41615 RVA: 0x001BB26C File Offset: 0x001B946C
		private bool _CanEnter()
		{
			float time = Time.time;
			bool flag = time - this.m_fEnterTime > 3f;
			bool result;
			if (flag)
			{
				this.m_fEnterTime = time;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600A290 RID: 41616 RVA: 0x001BB2A4 File Offset: 0x001B94A4
		public GuildSceneState TryEnterGuildScene()
		{
			bool bInGuild = this.bInGuild;
			GuildSceneState result;
			if (bInGuild)
			{
				SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
				bool flag = sceneType == SceneType.SCENE_GUILD_HALL;
				if (flag)
				{
					result = GuildSceneState.GSS_InGuildScene;
				}
				else
				{
					bool flag2 = !this._CanEnter();
					if (flag2)
					{
						result = GuildSceneState.GSS_NotGuildScene;
					}
					else
					{
						HomePlantDocument.Doc.GardenId = this.UID;
						PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
						ptcC2G_EnterSceneReq.Data.sceneID = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("GuildHallSceneID");
						ptcC2G_EnterSceneReq.Data.roleID = this.UID;
						XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
						result = GuildSceneState.GSS_NotGuildScene;
					}
				}
			}
			else
			{
				bool flag3 = !DlgBase<XGuildListView, XGuildListBehaviour>.singleton.IsVisible();
				if (flag3)
				{
					DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				}
				result = GuildSceneState.GSS_NoPermission;
			}
			return result;
		}

		// Token: 0x0600A291 RID: 41617 RVA: 0x001BB370 File Offset: 0x001B9570
		public void TryShowGuildHallUI()
		{
			bool bInGuild = this.bInGuild;
			if (bInGuild)
			{
				DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
			else
			{
				bool flag = !DlgBase<XGuildListView, XGuildListBehaviour>.singleton.IsVisible();
				if (flag)
				{
					DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				}
			}
		}

		// Token: 0x0600A292 RID: 41618 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600A293 RID: 41619 RVA: 0x001BB3B8 File Offset: 0x001B95B8
		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GUILD_HALL;
			if (flag)
			{
				HomePlantDocument doc = HomePlantDocument.Doc;
				doc.ClearFarmInfo();
				doc.HomeSprite.ClearInfo();
				HomePlantDocument.Doc.GardenId = this.UID;
				doc.FetchPlantInfo(0U);
			}
			base.OnEnterSceneFinally();
		}

		// Token: 0x0600A294 RID: 41620 RVA: 0x001BB414 File Offset: 0x001B9614
		public bool IHavePermission(GuildPermission pem)
		{
			return XGuildDocument.GuildPP.HasPermission(this.m_Position, pem);
		}

		// Token: 0x0600A295 RID: 41621 RVA: 0x001BB438 File Offset: 0x001B9638
		public bool CheckPermission(GuildPermission pem)
		{
			bool flag = !this.CheckInGuild();
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
					XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_GUILD_NO_PERMISSION, "fece00");
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600A296 RID: 41622 RVA: 0x001BB480 File Offset: 0x001B9680
		public bool CheckUnlockLevel(XSysDefine sys)
		{
			bool flag = !this.CheckInGuild();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				uint unlockLevel = XGuildDocument.GuildConfig.GetUnlockLevel(sys);
				bool flag2 = this.Level >= unlockLevel;
				if (flag2)
				{
					result = true;
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("OPEN_AT_GUILD_LEVEL", new object[]
					{
						unlockLevel
					}), "fece00");
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600A297 RID: 41623 RVA: 0x001BB4F0 File Offset: 0x001B96F0
		public bool IsSysUnlocked(XSysDefine sys)
		{
			bool flag = !this.bInGuild;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				uint unlockLevel = XGuildDocument.GuildConfig.GetUnlockLevel(sys);
				bool flag2 = this.Level >= unlockLevel;
				result = flag2;
			}
			return result;
		}

		// Token: 0x0600A298 RID: 41624 RVA: 0x001BB534 File Offset: 0x001B9734
		public bool CheckInGuild()
		{
			bool bInGuild = this.bInGuild;
			bool result;
			if (bInGuild)
			{
				result = true;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_GUILD_NOT_IN_GUILD, "fece00");
				result = false;
			}
			return result;
		}

		// Token: 0x0600A299 RID: 41625 RVA: 0x001BB568 File Offset: 0x001B9768
		public static void OnGuildHyperLinkClick(string param)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall;
			if (!flag)
			{
				ulong id = 0UL;
				bool flag2 = XLabelSymbolHelper.ParseGuildParam(param, ref id);
				if (flag2)
				{
					bool flag3 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Guild);
					if (flag3)
					{
						XGuildViewDocument specificDocument = XDocuments.GetSpecificDocument<XGuildViewDocument>(XGuildViewDocument.uuID);
						specificDocument.View(id);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_LOG_CANNOT_JOIN"), "fece00");
					}
				}
			}
		}

		// Token: 0x0600A29A RID: 41626 RVA: 0x001BB5E8 File Offset: 0x001B97E8
		public void QueryWXGroup()
		{
			bool flag = XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_WeChat || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Guild_Bind_Group);
			if (!flag)
			{
				XSingleton<PDatabase>.singleton.wxGroupCallbackType = WXGroupCallBackType.Guild;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["unionID"] = this.UID.ToString();
				dictionary["openIdList"] = XSingleton<XLoginDocument>.singleton.OpenID;
				string param = Json.Serialize(dictionary);
				XSingleton<XUpdater.XUpdater>.singleton.XPlatform.QueryWXGroup(param);
			}
		}

		// Token: 0x0600A29B RID: 41627 RVA: 0x001BB678 File Offset: 0x001B9878
		public void QueryQQGroup()
		{
			bool flag = XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_QQ || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Guild_Bind_Group);
			if (!flag)
			{
				RpcC2M_GetGuildBindInfo rpcC2M_GetGuildBindInfo = new RpcC2M_GetGuildBindInfo();
				rpcC2M_GetGuildBindInfo.oArg.token = XSingleton<XLoginDocument>.singleton.TokenCache;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GetGuildBindInfo);
				XSingleton<XDebug>.singleton.AddLog("[QQGroup QueryQQGroup]token:" + XSingleton<XLoginDocument>.singleton.TokenCache, null, null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		// Token: 0x0600A29C RID: 41628 RVA: 0x001BB6FC File Offset: 0x001B98FC
		public void OnGetQQGroupBindInfo(GetGuildBindInfoReq oArg, GetGuildBindInfoRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (!flag)
			{
				this.qqGroupBindStatus = oRes.bind_status;
				this.qqGroupName = oRes.group_name;
				bool flag2 = DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.RefreshQQGroupBtn();
				}
			}
		}

		// Token: 0x0600A29D RID: 41629 RVA: 0x001BB750 File Offset: 0x001B9950
		public void BindQQGroup()
		{
			bool flag = XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_QQ || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Guild_Bind_Group);
			if (!flag)
			{
				RpcC2M_GuildBindGroup rpcC2M_GuildBindGroup = new RpcC2M_GuildBindGroup();
				rpcC2M_GuildBindGroup.oArg.token = XSingleton<XLoginDocument>.singleton.TokenCache;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildBindGroup);
				XSingleton<XDebug>.singleton.AddLog("[QQGroup BindQQGroup]token:" + XSingleton<XLoginDocument>.singleton.TokenCache, null, null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		// Token: 0x0600A29E RID: 41630 RVA: 0x001BB7D4 File Offset: 0x001B99D4
		public void OnBindQQGroup(GuildBindGroupReq oArg, GuildBindGroupRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.result);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("GUILD_BIN_QQ_GROUP_SUC"), "fece00");
				this.qqGroupName = oRes.group_name;
				this.qqGroupBindStatus = GuildBindStatus.GBS_Owner;
				bool flag2 = DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.RefreshQQGroupBtn();
				}
			}
		}

		// Token: 0x0600A29F RID: 41631 RVA: 0x001BB850 File Offset: 0x001B9A50
		public void JoinQQGroup()
		{
			bool flag = XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_QQ || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Guild_Bind_Group);
			if (!flag)
			{
				RpcC2M_GuildJoinBindGroup rpcC2M_GuildJoinBindGroup = new RpcC2M_GuildJoinBindGroup();
				rpcC2M_GuildJoinBindGroup.oArg.token = XSingleton<XLoginDocument>.singleton.TokenCache;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildJoinBindGroup);
				XSingleton<XDebug>.singleton.AddLog("[QQGroup JoinQQGroup]token:" + XSingleton<XLoginDocument>.singleton.TokenCache, null, null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		// Token: 0x0600A2A0 RID: 41632 RVA: 0x001BB8D4 File Offset: 0x001B9AD4
		public void OnJoinBindQQGroup(GuildJoinBindGroupReq oArg, GuildJoinBindGroupRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.result);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("GUILD_JOIN_QQ_GROUP_SUC"), "fece00");
				this.qqGroupBindStatus = GuildBindStatus.GBS_Member;
				bool flag2 = DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.RefreshQQGroupBtn();
				}
			}
		}

		// Token: 0x0600A2A1 RID: 41633 RVA: 0x001BB944 File Offset: 0x001B9B44
		public void UnbindQQGroup()
		{
			bool flag = XSingleton<XLoginDocument>.singleton.Channel != XAuthorizationChannel.XAuthorization_QQ || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Guild_Bind_Group);
			if (!flag)
			{
				RpcC2M_GuildUnBindGroup rpcC2M_GuildUnBindGroup = new RpcC2M_GuildUnBindGroup();
				rpcC2M_GuildUnBindGroup.oArg.token = XSingleton<XLoginDocument>.singleton.TokenCache;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GuildUnBindGroup);
				XSingleton<XDebug>.singleton.AddLog("[QQGroup UnbindQQGroup]token:" + XSingleton<XLoginDocument>.singleton.TokenCache, null, null, null, null, null, XDebugColor.XDebug_None);
			}
		}

		// Token: 0x0600A2A2 RID: 41634 RVA: 0x001BB9C8 File Offset: 0x001B9BC8
		public void OnUnbindQQGroup(GuildUnBindGroupReq oArg, GuildUnBindGroupRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.result);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("GUILD_UNBIND_QQ_GROUP_SUC"), "fece00");
				this.qqGroupBindStatus = GuildBindStatus.GBS_NotBind;
				bool flag2 = DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.RefreshQQGroupBtn();
				}
			}
		}

		// Token: 0x04003AAA RID: 15018
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildDocument");

		// Token: 0x04003AAB RID: 15019
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003AAC RID: 15020
		private static GuildPermissionTable m_PermissionTable = new GuildPermissionTable();

		// Token: 0x04003AAD RID: 15021
		private static GuildConfigTable m_ConfigTable = new GuildConfigTable();

		// Token: 0x04003AAE RID: 15022
		private static Guildintroduce m_IntroduceTable = new Guildintroduce();

		// Token: 0x04003AAF RID: 15023
		private static XGuildConfig _GuildConfig = new XGuildConfig();

		// Token: 0x04003AB0 RID: 15024
		private static XGuildPP _GuildPP = new XGuildPP();

		// Token: 0x04003AB1 RID: 15025
		private XGuildBasicData m_BasicData = new XGuildBasicData();

		// Token: 0x04003AB2 RID: 15026
		private bool _bInited = false;

		// Token: 0x04003AB3 RID: 15027
		private GuildPosition m_Position;

		// Token: 0x04003AB4 RID: 15028
		private float m_fEnterTime = 0f;

		// Token: 0x04003AB5 RID: 15029
		public GuildBindStatus qqGroupBindStatus;

		// Token: 0x04003AB6 RID: 15030
		public string qqGroupName;
	}
}
