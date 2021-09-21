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
	// Token: 0x020009D5 RID: 2517
	internal class XMainInterfaceDocument : XDocComponent
	{
		// Token: 0x17002DCC RID: 11724
		// (get) Token: 0x06009928 RID: 39208 RVA: 0x0017D784 File Offset: 0x0017B984
		public override uint ID
		{
			get
			{
				return XMainInterfaceDocument.uuID;
			}
		}

		// Token: 0x17002DCD RID: 11725
		// (get) Token: 0x06009929 RID: 39209 RVA: 0x0017D79C File Offset: 0x0017B99C
		public GameCommunityTable GameCommunityReader
		{
			get
			{
				return XMainInterfaceDocument._gameCommunityReader;
			}
		}

		// Token: 0x17002DCE RID: 11726
		// (get) Token: 0x0600992A RID: 39210 RVA: 0x0017D7B4 File Offset: 0x0017B9B4
		// (set) Token: 0x0600992B RID: 39211 RVA: 0x0017D7CC File Offset: 0x0017B9CC
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

		// Token: 0x17002DCF RID: 11727
		// (get) Token: 0x0600992C RID: 39212 RVA: 0x0017D7D8 File Offset: 0x0017B9D8
		// (set) Token: 0x0600992D RID: 39213 RVA: 0x0017D7F0 File Offset: 0x0017B9F0
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

		// Token: 0x17002DD0 RID: 11728
		// (get) Token: 0x0600992E RID: 39214 RVA: 0x0017D7FC File Offset: 0x0017B9FC
		// (set) Token: 0x0600992F RID: 39215 RVA: 0x0017D814 File Offset: 0x0017BA14
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

		// Token: 0x17002DD1 RID: 11729
		// (get) Token: 0x06009930 RID: 39216 RVA: 0x0017D820 File Offset: 0x0017BA20
		// (set) Token: 0x06009931 RID: 39217 RVA: 0x0017D838 File Offset: 0x0017BA38
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

		// Token: 0x17002DD2 RID: 11730
		// (get) Token: 0x06009932 RID: 39218 RVA: 0x0017D844 File Offset: 0x0017BA44
		// (set) Token: 0x06009933 RID: 39219 RVA: 0x0017D85C File Offset: 0x0017BA5C
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

		// Token: 0x17002DD3 RID: 11731
		// (set) Token: 0x06009934 RID: 39220 RVA: 0x0017D866 File Offset: 0x0017BA66
		public bool GameAnnouncement
		{
			set
			{
				this._game_announcement = value;
			}
		}

		// Token: 0x17002DD4 RID: 11732
		// (get) Token: 0x06009935 RID: 39221 RVA: 0x0017D870 File Offset: 0x0017BA70
		// (set) Token: 0x06009936 RID: 39222 RVA: 0x0017D888 File Offset: 0x0017BA88
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

		// Token: 0x06009937 RID: 39223 RVA: 0x0017D894 File Offset: 0x0017BA94
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

		// Token: 0x06009938 RID: 39224 RVA: 0x0017D929 File Offset: 0x0017BB29
		public static void Execute(OnLoadedCallback callback = null)
		{
			XMainInterfaceDocument.AsyncLoader.AddTask("Table/GameCommunity", XMainInterfaceDocument._gameCommunityReader, false);
			XMainInterfaceDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009939 RID: 39225 RVA: 0x0017D950 File Offset: 0x0017BB50
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

		// Token: 0x0600993A RID: 39226 RVA: 0x0017DA50 File Offset: 0x0017BC50
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

		// Token: 0x0600993B RID: 39227 RVA: 0x0017DAAC File Offset: 0x0017BCAC
		private bool _OnLeaveTeam(XEventArgs e)
		{
			bool flag = this._view != null;
			if (flag)
			{
				this._view._TaskNaviHandler.SetTeamMemberCount(0);
			}
			return true;
		}

		// Token: 0x0600993C RID: 39228 RVA: 0x0017DAE0 File Offset: 0x0017BCE0
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

		// Token: 0x0600993D RID: 39229 RVA: 0x0017DB20 File Offset: 0x0017BD20
		protected bool OnGuildLevelChanged(XEventArgs e)
		{
			bool flag = this.View != null && this.View.IsVisible();
			if (flag)
			{
				this.View.OnGuildSysChange();
			}
			return true;
		}

		// Token: 0x0600993E RID: 39230 RVA: 0x0017DB5C File Offset: 0x0017BD5C
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

		// Token: 0x0600993F RID: 39231 RVA: 0x0017DB9C File Offset: 0x0017BD9C
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

		// Token: 0x06009940 RID: 39232 RVA: 0x0017DC66 File Offset: 0x0017BE66
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

		// Token: 0x06009941 RID: 39233 RVA: 0x0017DC7C File Offset: 0x0017BE7C
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

		// Token: 0x06009942 RID: 39234 RVA: 0x0017DD48 File Offset: 0x0017BF48
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

		// Token: 0x06009943 RID: 39235 RVA: 0x0017DE20 File Offset: 0x0017C020
		public void OnSysOpen()
		{
			bool flag = this._view != null;
			if (flag)
			{
				this._view.RefreshSysAnnounce();
			}
		}

		// Token: 0x06009944 RID: 39236 RVA: 0x0017DE48 File Offset: 0x0017C048
		public void OnSysChange()
		{
			bool flag = this._view != null;
			if (flag)
			{
				this._view.OnMainSysChange();
			}
		}

		// Token: 0x06009945 RID: 39237 RVA: 0x0017DE70 File Offset: 0x0017C070
		public void RefreshVirtualItem(int itemID)
		{
			DlgBase<TitanbarView, TitanBarBehaviour>.singleton.TryRefresh(itemID);
			bool flag = this._view == null || !this._view.IsVisible();
			if (!flag)
			{
				this._view.RefreshMoneyInfo(itemID, false);
			}
		}

		// Token: 0x06009946 RID: 39238 RVA: 0x0017DEB8 File Offset: 0x0017C0B8
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

		// Token: 0x06009947 RID: 39239 RVA: 0x0017DFF0 File Offset: 0x0017C1F0
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

		// Token: 0x06009948 RID: 39240 RVA: 0x0017E07C File Offset: 0x0017C27C
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

		// Token: 0x06009949 RID: 39241 RVA: 0x0017E138 File Offset: 0x0017C338
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

		// Token: 0x0600994A RID: 39242 RVA: 0x0017E1EC File Offset: 0x0017C3EC
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

		// Token: 0x0600994B RID: 39243 RVA: 0x0017E280 File Offset: 0x0017C480
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

		// Token: 0x0600994C RID: 39244 RVA: 0x0017E2E4 File Offset: 0x0017C4E4
		public int GetPlayerPPT()
		{
			XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
			XPlayerAttributes xplayerAttributes = player.Attributes as XPlayerAttributes;
			return (int)xplayerAttributes.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
		}

		// Token: 0x0600994D RID: 39245 RVA: 0x0017E31C File Offset: 0x0017C51C
		public ulong GetPlayerGold()
		{
			return XSingleton<XGame>.singleton.Doc.XBagDoc.GetVirtualItemCount(ItemEnum.GOLD);
		}

		// Token: 0x0600994E RID: 39246 RVA: 0x0017E344 File Offset: 0x0017C544
		public ulong GetPlayerDC()
		{
			return XSingleton<XGame>.singleton.Doc.XBagDoc.GetVirtualItemCount(ItemEnum.DRAGON_COIN);
		}

		// Token: 0x0600994F RID: 39247 RVA: 0x0017E36C File Offset: 0x0017C56C
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

		// Token: 0x06009950 RID: 39248 RVA: 0x0017E41C File Offset: 0x0017C61C
		public void SetBlockItemsChange(bool bBlock)
		{
			this.VirtualItemEventBlocker.bBlockReceiver = bBlock;
			this.AddItemEventBlocker.bBlockReceiver = bBlock;
			this.RemoveItemEventBlocker.bBlockReceiver = bBlock;
			this.ItemNumChangedEventBlocker.bBlockReceiver = bBlock;
		}

		// Token: 0x06009951 RID: 39249 RVA: 0x0017E454 File Offset: 0x0017C654
		public void SetVoiceBtnAppear(uint type)
		{
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.OnVoiceBtnAppear(type);
			}
		}

		// Token: 0x06009952 RID: 39250 RVA: 0x0017E480 File Offset: 0x0017C680
		public bool OnPlayerLevelChange(XEventArgs arg)
		{
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.OnSingleSysChange(XSysDefine.XSys_SystemAnnounce, true);
			return true;
		}

		// Token: 0x06009953 RID: 39251 RVA: 0x0017E4A4 File Offset: 0x0017C6A4
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

		// Token: 0x06009954 RID: 39252 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04003481 RID: 13441
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MainInterfaceDocument");

		// Token: 0x04003482 RID: 13442
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003483 RID: 13443
		private static GameCommunityTable _gameCommunityReader = new GameCommunityTable();

		// Token: 0x04003484 RID: 13444
		private XMainInterface _view = null;

		// Token: 0x04003485 RID: 13445
		public XEventBlocker<XAttrChangeEventArgs> AttrEventBlocker = new XEventBlocker<XAttrChangeEventArgs>();

		// Token: 0x04003486 RID: 13446
		public XEventBlocker<XVirtualItemChangedEventArgs> VirtualItemEventBlocker = new XEventBlocker<XVirtualItemChangedEventArgs>();

		// Token: 0x04003487 RID: 13447
		public XEventBlocker<XAddItemEventArgs> AddItemEventBlocker = new XEventBlocker<XAddItemEventArgs>();

		// Token: 0x04003488 RID: 13448
		public XEventBlocker<XRemoveItemEventArgs> RemoveItemEventBlocker = new XEventBlocker<XRemoveItemEventArgs>();

		// Token: 0x04003489 RID: 13449
		public XEventBlocker<XItemNumChangedEventArgs> ItemNumChangedEventBlocker = new XEventBlocker<XItemNumChangedEventArgs>();

		// Token: 0x0400348A RID: 13450
		private XMainInterfaceDocument.GetFps _get_fps_state = XMainInterfaceDocument.GetFps.wait;

		// Token: 0x0400348B RID: 13451
		private float _fps_start_time = 0f;

		// Token: 0x0400348C RID: 13452
		private float _peak_fps = 0f;

		// Token: 0x0400348D RID: 13453
		private int _fps_count = 0;

		// Token: 0x0400348E RID: 13454
		private bool _game_announcement = false;

		// Token: 0x0400348F RID: 13455
		public bool ShowWebView = false;

		// Token: 0x04003490 RID: 13456
		private bool _backFlow = false;

		// Token: 0x02001983 RID: 6531
		public enum GetFps
		{
			// Token: 0x04007EC4 RID: 32452
			wait,
			// Token: 0x04007EC5 RID: 32453
			start,
			// Token: 0x04007EC6 RID: 32454
			running,
			// Token: 0x04007EC7 RID: 32455
			stop
		}
	}
}
