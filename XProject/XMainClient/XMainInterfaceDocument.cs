using System;
using System.Collections;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XMainInterfaceDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XMainInterfaceDocument.uuID;
			}
		}

		public GameCommunityTable GameCommunityReader
		{
			get
			{
				return XMainInterfaceDocument._gameCommunityReader;
			}
		}

		public XMainInterface View
		{
			get
			{
				return this._view;
			}
			set
			{
				this._view = value;
			}
		}

		public XMainInterfaceDocument.GetFps GetFpsState
		{
			get
			{
				return this._get_fps_state;
			}
			set
			{
				this._get_fps_state = value;
			}
		}

		public float FpsStartTime
		{
			get
			{
				return this._fps_start_time;
			}
			set
			{
				this._fps_start_time = value;
			}
		}

		public float PeakFps
		{
			get
			{
				return this._peak_fps;
			}
			set
			{
				this._peak_fps = value;
			}
		}

		public int FpsCount
		{
			get
			{
				return this._fps_count;
			}
			set
			{
				this._fps_count = value;
			}
		}

		public bool GameAnnouncement
		{
			set
			{
				this._game_announcement = value;
			}
		}

		public bool BackFlow
		{
			get
			{
				return this._backFlow;
			}
			set
			{
				this._backFlow = value;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.AttrEventBlocker.EventHandler = new XEventBlocker<XAttrChangeEventArgs>.XEventHandler(this.OnAttributeChange);
			this.VirtualItemEventBlocker.EventHandler = new XEventBlocker<XVirtualItemChangedEventArgs>.XEventHandler(this.OnVirtualItemChanged);
			this.AddItemEventBlocker.EventHandler = new XEventBlocker<XAddItemEventArgs>.XEventHandler(this.OnAddItem);
			this.RemoveItemEventBlocker.EventHandler = new XEventBlocker<XRemoveItemEventArgs>.XEventHandler(this.OnRemoveItem);
			this.ItemNumChangedEventBlocker.EventHandler = new XEventBlocker<XItemNumChangedEventArgs>.XEventHandler(this.OnItemNumChanged);
			this._get_fps_state = XMainInterfaceDocument.GetFps.start;
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XMainInterfaceDocument.AsyncLoader.AddTask("Table/GameCommunity", XMainInterfaceDocument._gameCommunityReader, false);
			XMainInterfaceDocument.AsyncLoader.Execute(callback);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AttributeChange, new XComponent.XEventHandler(this.OnAttributeChange));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnVirtualItemChanged));
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.RegisterEvent(XEventDefine.XEvent_RemoveItem, new XComponent.XEventHandler(this.OnRemoveItem));
			base.RegisterEvent(XEventDefine.XEvent_ItemNumChanged, new XComponent.XEventHandler(this.OnItemNumChanged));
			base.RegisterEvent(XEventDefine.XEvent_GuildLevelChanged, new XComponent.XEventHandler(this.OnGuildLevelChanged));
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnInGuildStateChanged));
			base.RegisterEvent(XEventDefine.XEvent_TeamMemberCountChanged, new XComponent.XEventHandler(this._OnMemberCountChanged));
			base.RegisterEvent(XEventDefine.XEvent_JoinTeam, new XComponent.XEventHandler(this._OnJoinTeam));
			base.RegisterEvent(XEventDefine.XEvent_LeaveTeam, new XComponent.XEventHandler(this._OnLeaveTeam));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		private bool _OnJoinTeam(XEventArgs e)
		{
			bool flag = this._view != null;
			if (flag)
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				bool bInTeam = specificDocument.bInTeam;
				if (bInTeam)
				{
					this._view._TaskNaviHandler.SetTeamMemberCount(specificDocument.MyTeam.members.Count);
				}
			}
			return true;
		}

		private bool _OnLeaveTeam(XEventArgs e)
		{
			bool flag = this._view != null;
			if (flag)
			{
				this._view._TaskNaviHandler.SetTeamMemberCount(0);
			}
			return true;
		}

		private bool _OnMemberCountChanged(XEventArgs arg)
		{
			XTeamMemberCountChangedEventArgs xteamMemberCountChangedEventArgs = arg as XTeamMemberCountChangedEventArgs;
			bool flag = this._view != null;
			if (flag)
			{
				this._view._TaskNaviHandler.SetTeamMemberCount((int)xteamMemberCountChangedEventArgs.newCount);
			}
			return true;
		}

		protected bool OnGuildLevelChanged(XEventArgs e)
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.OnGuildSysChange();
			}
			return true;
		}

		protected bool OnInGuildStateChanged(XEventArgs e)
		{
			XInGuildStateChangedEventArgs xinGuildStateChangedEventArgs = e as XInGuildStateChangedEventArgs;
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.OnGuildSysChange();
			}
			return true;
		}

		protected bool OnAttributeChange(XEventArgs e)
		{
			bool flag = this._view != null && this._view.IsVisible();
			if (flag)
			{
				XAttrChangeEventArgs xattrChangeEventArgs = e as XAttrChangeEventArgs;
				bool bBlockReceiver = this.AttrEventBlocker.bBlockReceiver;
				if (bBlockReceiver)
				{
					XAttrChangeEventArgs @event = XEventPool<XAttrChangeEventArgs>.GetEvent();
					@event.AttrKey = xattrChangeEventArgs.AttrKey;
					@event.DeltaValue = xattrChangeEventArgs.DeltaValue;
					this.AttrEventBlocker.AddEvent(@event);
					return true;
				}
				XAttributeDefine attrKey = xattrChangeEventArgs.AttrKey;
				if (attrKey == XAttributeDefine.XAttr_POWER_POINT_Basic)
				{
					bool flag2 = this._view.IsVisible();
					if (flag2)
					{
						this._view.SetPowerpoint((int)xattrChangeEventArgs.DeltaValue);
					}
					DlgBase<CapacityDownDlg, CapacityBehaviour>.singleton.UpdatePPT((int)xattrChangeEventArgs.DeltaValue);
				}
			}
			return true;
		}

		private IEnumerator LoadWebViewConfig(string url)
		{
			WWW www = new WWW(url);
			yield return www;
			while (!www.isDone)
			{
				yield return www;
			}
			bool flag = !string.IsNullOrEmpty(www.error);
			if (flag)
			{
				this.ShowWebView = false;
				www.Dispose();
				yield break;
			}
			bool flag2 = www.text.Contains("true");
			if (flag2)
			{
				this.ShowWebView = true;
			}
			else
			{
				this.ShowWebView = false;
			}
			www.Dispose();
			www = null;
			yield break;
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = !this._game_announcement && XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowPatface();
				this._game_announcement = true;
			}
			else
			{
				bool flag2 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
				if (flag2)
				{
					XSingleton<XPandoraSDKDocument>.singleton.CheckPandoraPLPanel();
				}
			}
			bool flag3 = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag3)
			{
				XSingleton<XUICacheMgr>.singleton.TryShowCache();
			}
			bool flag4 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag4)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.MulActTipsToken = XSingleton<XTimerMgr>.singleton.SetTimer(5f, new XTimerMgr.ElapsedEventHandler(DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetMultiActivityTips), null);
			}
		}

		public override void OnLeaveScene()
		{
			base.OnEnterScene();
			this.AttrEventBlocker.ClearEvents();
			this.VirtualItemEventBlocker.ClearEvents();
			this.AddItemEventBlocker.ClearEvents();
			this.RemoveItemEventBlocker.ClearEvents();
			this.ItemNumChangedEventBlocker.ClearEvents();
			bool flag = this._get_fps_state == XMainInterfaceDocument.GetFps.running;
			if (flag)
			{
				float num = (float)this._fps_count / (Time.realtimeSinceStartup - this._fps_start_time);
				XSingleton<XDebug>.singleton.AddLog("TestinLog-Event>>>> ID Times, Key Average Fps, Value ", num.ToString(), null, null, null, null, XDebugColor.XDebug_None);
				XSingleton<XDebug>.singleton.AddLog("TestinLog-Event>>>> ID Times, Key Peak Fps, Value ", this._peak_fps.ToString(), null, null, null, null, XDebugColor.XDebug_None);
				this._get_fps_state = XMainInterfaceDocument.GetFps.stop;
			}
			XSingleton<XDebug>.singleton.AddGreenLog("OnLeaveScene", null, null, null, null, null);
			XSingleton<XPandoraSDKDocument>.singleton.CloseAllPandoraPanel();
		}

		public void OnSysOpen()
		{
			bool flag = this._view != null;
			if (flag)
			{
				this._view.RefreshSysAnnounce();
			}
		}

		public void OnSysChange()
		{
			bool flag = this._view != null;
			if (flag)
			{
				this._view.OnMainSysChange();
			}
		}

		public void RefreshVirtualItem(int itemID)
		{
			DlgBase<TitanbarView, TitanBarBehaviour>.singleton.TryRefresh(itemID);
			bool flag = this._view == null || !this._view.IsVisible();
			if (!flag)
			{
				this._view.RefreshMoneyInfo(itemID, false);
			}
		}

		public void OnLoadWebViewConfig()
		{
			int num = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HideWebView"));
			bool flag = num == 1;
			if (!flag)
			{
				string openID = XSingleton<XLoginDocument>.singleton.OpenID;
				uint serverID = XSingleton<XClientNetwork>.singleton.ServerID;
				RuntimePlatform platform = Application.platform;
				string text;
				if (platform != (RuntimePlatform)8)
				{
					if (platform != (RuntimePlatform)11)
					{
						text = "2";
					}
					else
					{
						text = "1";
					}
				}
				else
				{
					text = "0";
				}
				bool flag2 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ;
				string text2;
				if (flag2)
				{
					text2 = "2";
				}
				else
				{
					bool flag3 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat;
					if (flag3)
					{
						text2 = "1";
					}
					else
					{
						bool flag4 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_Guest;
						if (flag4)
						{
							return;
						}
						text2 = "0";
					}
				}
				string text3 = string.Format(XSingleton<XGlobalConfig>.singleton.GetValue("WebviewGray"), new object[]
				{
					openID,
					text2,
					text,
					serverID
				});
				XSingleton<XDebug>.singleton.AddLog("Req url: ", text3, null, null, null, null, XDebugColor.XDebug_None);
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.uiBehaviour.StartCoroutine(this.LoadWebViewConfig(text3));
			}
		}

		protected bool OnVirtualItemChanged(XEventArgs args)
		{
			XVirtualItemChangedEventArgs xvirtualItemChangedEventArgs = args as XVirtualItemChangedEventArgs;
			bool bBlockReceiver = this.VirtualItemEventBlocker.bBlockReceiver;
			bool result;
			if (bBlockReceiver)
			{
				this.VirtualItemEventBlocker.AddEvent(xvirtualItemChangedEventArgs.Clone() as XVirtualItemChangedEventArgs);
				result = true;
			}
			else
			{
				DlgBase<TitanbarView, TitanBarBehaviour>.singleton.TryRefresh(xvirtualItemChangedEventArgs.itemID);
				bool flag = this._view == null || !this._view.IsVisible();
				if (flag)
				{
					result = false;
				}
				else
				{
					this._view.RefreshMoneyInfo(xvirtualItemChangedEventArgs.itemID, true);
					result = true;
				}
			}
			return result;
		}

		protected bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			bool bBlockReceiver = this.AddItemEventBlocker.bBlockReceiver;
			bool result;
			if (bBlockReceiver)
			{
				this.AddItemEventBlocker.AddEvent(xaddItemEventArgs.Clone() as XAddItemEventArgs);
				result = true;
			}
			else
			{
				for (int i = 0; i < xaddItemEventArgs.items.Count; i++)
				{
					DlgBase<TitanbarView, TitanBarBehaviour>.singleton.TryRefresh(xaddItemEventArgs.items[i].itemID);
					bool flag = this._view != null && this._view.IsVisible();
					if (flag)
					{
						this._view.RefreshMoneyInfo(xaddItemEventArgs.items[i].itemID, true);
					}
				}
				result = true;
			}
			return result;
		}

		protected bool OnRemoveItem(XEventArgs args)
		{
			XRemoveItemEventArgs xremoveItemEventArgs = args as XRemoveItemEventArgs;
			bool bBlockReceiver = this.RemoveItemEventBlocker.bBlockReceiver;
			bool result;
			if (bBlockReceiver)
			{
				this.RemoveItemEventBlocker.AddEvent(xremoveItemEventArgs.Clone() as XRemoveItemEventArgs);
				result = true;
			}
			else
			{
				DlgBase<TitanbarView, TitanBarBehaviour>.singleton.TryRefresh(xremoveItemEventArgs.ids);
				bool flag = this._view == null || !this._view.IsVisible();
				if (flag)
				{
					result = true;
				}
				else
				{
					for (int i = 0; i < xremoveItemEventArgs.ids.Count; i++)
					{
						this._view.RefreshMoneyInfo(xremoveItemEventArgs.ids[i], true);
					}
					result = true;
				}
			}
			return result;
		}

		protected bool OnItemNumChanged(XEventArgs args)
		{
			XItemNumChangedEventArgs xitemNumChangedEventArgs = args as XItemNumChangedEventArgs;
			bool bBlockReceiver = this.ItemNumChangedEventBlocker.bBlockReceiver;
			bool result;
			if (bBlockReceiver)
			{
				this.ItemNumChangedEventBlocker.AddEvent(xitemNumChangedEventArgs.Clone() as XItemNumChangedEventArgs);
				result = true;
			}
			else
			{
				DlgBase<TitanbarView, TitanBarBehaviour>.singleton.TryRefresh(xitemNumChangedEventArgs.item.itemID);
				bool flag = this._view == null || !this._view.IsVisible();
				if (flag)
				{
					result = true;
				}
				else
				{
					this._view.RefreshMoneyInfo(xitemNumChangedEventArgs.item.itemID, true);
					result = true;
				}
			}
			return result;
		}

		public void Present()
		{
			this.OnTopUIRefreshed(null);
			this._view.SetupBaseInfo(XSingleton<XEntityMgr>.singleton.Player.Attributes);
			DlgBase<CapacityDownDlg, CapacityBehaviour>.singleton.InitPPT();
			this._view.InitRedPointsWhenShow();
			bool needTutorail = XSingleton<XTutorialMgr>.singleton.NeedTutorail;
			if (needTutorail)
			{
				XSingleton<XTutorialMgr>.singleton.ReExecuteCurrentCmd();
			}
		}

		public int GetPlayerPPT()
		{
			XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
			XPlayerAttributes xplayerAttributes = player.Attributes as XPlayerAttributes;
			return (int)xplayerAttributes.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
		}

		public ulong GetPlayerGold()
		{
			return XSingleton<XGame>.singleton.Doc.XBagDoc.GetVirtualItemCount(ItemEnum.GOLD);
		}

		public ulong GetPlayerDC()
		{
			return XSingleton<XGame>.singleton.Doc.XBagDoc.GetVirtualItemCount(ItemEnum.DRAGON_COIN);
		}

		public void OnTopUIRefreshed(IXUIDlg dlg)
		{
			bool flag = dlg == null;
			if (flag)
			{
				bool flag2 = DlgBase<TitanbarView, TitanBarBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<TitanbarView, TitanBarBehaviour>.singleton.SetVisible(false, true);
				}
			}
			else
			{
				int[] titanBarItems = dlg.GetTitanBarItems();
				bool flag3 = titanBarItems != null;
				if (flag3)
				{
					DlgBase<TitanbarView, TitanBarBehaviour>.singleton.SetVisible(true, true);
					DlgBase<TitanbarView, TitanBarBehaviour>.singleton.SetTitanItems(titanBarItems);
				}
				else
				{
					bool hideMainMenu = dlg.hideMainMenu;
					if (hideMainMenu)
					{
						DlgBase<TitanbarView, TitanBarBehaviour>.singleton.SetVisible(true, true);
						DlgBase<TitanbarView, TitanBarBehaviour>.singleton.SetTitanItems((XSysDefine)dlg.sysid);
					}
					else
					{
						bool flag4 = DlgBase<TitanbarView, TitanBarBehaviour>.singleton.IsVisible();
						if (flag4)
						{
							DlgBase<TitanbarView, TitanBarBehaviour>.singleton.SetVisible(false, true);
						}
					}
				}
			}
		}

		public void SetBlockItemsChange(bool bBlock)
		{
			this.VirtualItemEventBlocker.bBlockReceiver = bBlock;
			this.AddItemEventBlocker.bBlockReceiver = bBlock;
			this.RemoveItemEventBlocker.bBlockReceiver = bBlock;
			this.ItemNumChangedEventBlocker.bBlockReceiver = bBlock;
		}

		public void SetVoiceBtnAppear(uint type)
		{
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.OnVoiceBtnAppear(type);
			}
		}

		public bool OnPlayerLevelChange(XEventArgs arg)
		{
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.OnSingleSysChange(XSysDefine.XSys_SystemAnnounce, true);
			return true;
		}

		public void OnHallIconNtfGet(HallIconPara data)
		{
			XSingleton<XDebug>.singleton.AddGreenLog(string.Concat(new object[]
			{
				"IconID: ",
				data.systemid,
				"\nHallIcon.state: ",
				data.state
			}), null, null, null, null, null);
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpen(data.systemid);
			if (!flag)
			{
				XSysDefine systemid = (XSysDefine)data.systemid;
				if (systemid <= XSysDefine.XSys_Rank_WorldBoss)
				{
					if (systemid <= XSysDefine.XSys_GuildMine)
					{
						if (systemid == XSysDefine.XSys_Spectate)
						{
							XSpectateDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
							specificDocument.SetMainInterfaceBtnState(data.state == HallIconState.HICONS_BEGIN, data.liveInfo);
							return;
						}
						if (systemid == XSysDefine.XSys_GuildMine)
						{
							XGuildMineEntranceDocument specificDocument2 = XDocuments.GetSpecificDocument<XGuildMineEntranceDocument>(XGuildMineEntranceDocument.uuID);
							specificDocument2.SetMainInterfaceBtnState(data.state == HallIconState.HICONS_BEGIN);
							return;
						}
					}
					else
					{
						if (systemid == XSysDefine.XSys_CrossGVG)
						{
							XCrossGVGDocument specificDocument3 = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
							specificDocument3.SetMainInterfaceBtnState(data.state == HallIconState.HICONS_BEGIN);
							return;
						}
						if (systemid == XSysDefine.XSys_Rank_WorldBoss)
						{
							XWorldBossDocument specificDocument4 = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
							specificDocument4.SetMainInterfaceBtnState(data.state == HallIconState.HICONS_BEGIN);
							return;
						}
					}
				}
				else if (systemid <= XSysDefine.XSys_MulActivity_SkyArenaEnd)
				{
					switch (systemid)
					{
					case XSysDefine.XSys_Activity_CaptainPVP:
					{
						XCaptainPVPDocument specificDocument5 = XDocuments.GetSpecificDocument<XCaptainPVPDocument>(XCaptainPVPDocument.uuID);
						specificDocument5.SetMainInterfaceBtnState(data.state == HallIconState.HICONS_BEGIN);
						return;
					}
					case XSysDefine.XSys_Activity_GoddessTrial:
					case XSysDefine.XSys_Activity_TeamTowerSingle:
						break;
					case XSysDefine.XSys_BigMelee:
					{
						XBigMeleeEntranceDocument specificDocument6 = XDocuments.GetSpecificDocument<XBigMeleeEntranceDocument>(XBigMeleeEntranceDocument.uuID);
						specificDocument6.SetMainInterfaceBtnState(data.state == HallIconState.HICONS_BEGIN);
						return;
					}
					case XSysDefine.XSys_BigMeleeEnd:
					{
						XBigMeleeEntranceDocument specificDocument7 = XDocuments.GetSpecificDocument<XBigMeleeEntranceDocument>(XBigMeleeEntranceDocument.uuID);
						specificDocument7.SetMainInterfaceBtnStateEnd(data.state == HallIconState.HICONS_BEGIN);
						return;
					}
					case XSysDefine.XSys_Battlefield:
						XBattleFieldEntranceDocument.Doc.SetMainInterfaceBtnState(data.state == HallIconState.HICONS_BEGIN);
						return;
					default:
						switch (systemid)
						{
						case XSysDefine.XSys_MulActivity_SkyArena:
							XSkyArenaEntranceDocument.Doc.SetMainInterfaceBtnState(data.state == HallIconState.HICONS_BEGIN);
							return;
						case XSysDefine.XSys_MulActivity_Race:
							DlgBase<RaceEntranceView, RaceEntranceBehaviour>.singleton.SetMainInterfaceBtnState(data.state == HallIconState.HICONS_BEGIN);
							return;
						case XSysDefine.XSys_MulActivity_WeekendParty:
						{
							XWeekendPartyDocument specificDocument8 = XDocuments.GetSpecificDocument<XWeekendPartyDocument>(XWeekendPartyDocument.uuID);
							specificDocument8.SetMainInterfaceBtnState(data.state == HallIconState.HICONS_BEGIN);
							return;
						}
						case XSysDefine.XSys_MulActivity_SkyArenaEnd:
							XSkyArenaEntranceDocument.Doc.SetMainInterfaceBtnStateEnd(data.state == HallIconState.HICONS_BEGIN);
							return;
						}
						break;
					}
				}
				else
				{
					if (systemid == XSysDefine.XSys_TeamLeague)
					{
						XFreeTeamVersusLeagueDocument specificDocument9 = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
						specificDocument9.SetMainInterfaceBtnState(data.state == HallIconState.HICONS_BEGIN);
						return;
					}
					if (systemid == XSysDefine.XSys_GuildMineEnd)
					{
						XGuildMineEntranceDocument specificDocument10 = XDocuments.GetSpecificDocument<XGuildMineEntranceDocument>(XGuildMineEntranceDocument.uuID);
						specificDocument10.SetMainInterfaceBtnStateEnd(data.state == HallIconState.HICONS_BEGIN);
						return;
					}
					if (systemid == XSysDefine.XSys_GuildCollect)
					{
						XGuildCollectDocument specificDocument11 = XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID);
						bool flag2 = data.state == HallIconState.HICONS_BEGIN;
						specificDocument11.SetMainInterfaceBtnState(flag2 && XSingleton<XScene>.singleton.SceneType != SceneType.SCENE_GUILD_HALL);
						return;
					}
				}
				XSingleton<XDebug>.singleton.AddErrorLog("Undefine system id from HallIconNtf. system = ", ((XSysDefine)data.systemid).ToString(), null, null, null, null);
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MainInterfaceDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static GameCommunityTable _gameCommunityReader = new GameCommunityTable();

		private XMainInterface _view = null;

		public XEventBlocker<XAttrChangeEventArgs> AttrEventBlocker = new XEventBlocker<XAttrChangeEventArgs>();

		public XEventBlocker<XVirtualItemChangedEventArgs> VirtualItemEventBlocker = new XEventBlocker<XVirtualItemChangedEventArgs>();

		public XEventBlocker<XAddItemEventArgs> AddItemEventBlocker = new XEventBlocker<XAddItemEventArgs>();

		public XEventBlocker<XRemoveItemEventArgs> RemoveItemEventBlocker = new XEventBlocker<XRemoveItemEventArgs>();

		public XEventBlocker<XItemNumChangedEventArgs> ItemNumChangedEventBlocker = new XEventBlocker<XItemNumChangedEventArgs>();

		private XMainInterfaceDocument.GetFps _get_fps_state = XMainInterfaceDocument.GetFps.wait;

		private float _fps_start_time = 0f;

		private float _peak_fps = 0f;

		private int _fps_count = 0;

		private bool _game_announcement = false;

		public bool ShowWebView = false;

		private bool _backFlow = false;

		public enum GetFps
		{

			wait,

			start,

			running,

			stop
		}
	}
}
