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

	internal class XGuildDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildDocument.uuID;
			}
		}

		public static string GetPortraitName(int index)
		{
			return "ghicon_" + index.ToString();
		}

		public static XGuildConfig GuildConfig
		{
			get
			{
				return XGuildDocument._GuildConfig;
			}
		}

		public static XGuildPP GuildPP
		{
			get
			{
				return XGuildDocument._GuildPP;
			}
		}

		public static bool InGuild
		{
			get
			{
				XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				return specificDocument.bInGuild;
			}
		}

		public XGuildBasicData BasicData
		{
			get
			{
				return this.m_BasicData;
			}
		}

		public ulong UID
		{
			get
			{
				return this.m_BasicData.uid;
			}
		}

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

		public bool SetLevel(uint newLevel)
		{
			bool result = this.m_BasicData.level != 0U && this.m_BasicData.level != newLevel && this.m_BasicData.uid > 0UL;
			this.m_BasicData.level = newLevel;
			return result;
		}

		public bool SetPosition(GuildPosition newPos)
		{
			bool result = this.m_Position != GuildPosition.GPOS_COUNT && this.m_Position != newPos && this.m_BasicData.uid > 0UL;
			this.m_Position = newPos;
			return result;
		}

		public Guildintroduce.RowData GetIntroduce(string helpName)
		{
			return XGuildDocument.m_IntroduceTable.GetByHelpName(helpName);
		}

		public GuildPosition Position
		{
			get
			{
				return this.m_Position;
			}
		}

		public uint Level
		{
			get
			{
				return this.m_BasicData.level;
			}
		}

		public uint CurSkillUpCount
		{
			get
			{
				return 0U;
			}
		}

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

		public string PortraitSprite
		{
			get
			{
				return XGuildDocument.GetPortraitName(this.m_BasicData.portraitIndex);
			}
		}

		public uint CurrentCanUseExp
		{
			get
			{
				return 0U;
			}
		}

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildDocument.AsyncLoader.AddTask("Table/GuildPermission", XGuildDocument.m_PermissionTable, false);
			XGuildDocument.AsyncLoader.AddTask("Table/GuildConfig", XGuildDocument.m_ConfigTable, false);
			XGuildDocument.AsyncLoader.AddTask("Table/GuildIntroduce", XGuildDocument.m_IntroduceTable, false);
			XGuildDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._bInited = false;
			this.m_Position = GuildPosition.GPOS_COUNT;
			this.m_BasicData.uid = 0UL;
			this.m_BasicData.level = 0U;
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnInGuildStateChanged));
			base.RegisterEvent(XEventDefine.XEvent_GuildPositionChanged, new XComponent.XEventHandler(this.OnGuildPositionChanged));
		}

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

		protected bool OnGuildPositionChanged(XEventArgs args)
		{
			XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("GUILD_POSITION_CHANGED", new object[]
			{
				XGuildDocument.GuildPP.GetPositionName(this.m_Position, false)
			}), XStringDefineProxy.GetString(XStringDefine.COMMON_OK));
			return true;
		}

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

		public static void OnTableLoaded()
		{
			XGuildDocument.GuildPP.InitTable(XGuildDocument.m_PermissionTable);
			XGuildDocument.GuildConfig.Init(XGuildDocument.m_ConfigTable);
		}

		public bool bInGuild
		{
			get
			{
				return this.UID > 0UL;
			}
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

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

		public bool IHavePermission(GuildPermission pem)
		{
			return XGuildDocument.GuildPP.HasPermission(this.m_Position, pem);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static GuildPermissionTable m_PermissionTable = new GuildPermissionTable();

		private static GuildConfigTable m_ConfigTable = new GuildConfigTable();

		private static Guildintroduce m_IntroduceTable = new Guildintroduce();

		private static XGuildConfig _GuildConfig = new XGuildConfig();

		private static XGuildPP _GuildPP = new XGuildPP();

		private XGuildBasicData m_BasicData = new XGuildBasicData();

		private bool _bInited = false;

		private GuildPosition m_Position;

		private float m_fEnterTime = 0f;

		public GuildBindStatus qqGroupBindStatus;

		public string qqGroupName;
	}
}
