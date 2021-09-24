using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class SpectateSceneView : DlgBase<SpectateSceneView, SpectateSceneBehaviour>
	{

		public XSpectateTeamMonitorHandler SpectateTeamMonitor
		{
			get
			{
				return (base.uiBehaviour == null) ? null : base.uiBehaviour.m_SpectateTeamMonitor;
			}
		}

		public BattleIndicateHandler IndicateHandler
		{
			get
			{
				return (base.uiBehaviour == null) ? null : base.uiBehaviour.m_IndicateHandler;
			}
		}

		public XBattleEnemyInfoHandler EnemyInfoHandler
		{
			get
			{
				return (base.uiBehaviour == null) ? null : base.uiBehaviour.m_EnemyInfoHandler;
			}
		}

		public BattleTargetHandler BattleTargetHandler
		{
			get
			{
				return (base.uiBehaviour == null) ? null : base.uiBehaviour.m_BattleTargetHandler;
			}
		}

		public SpectateHandler SpectateHandler
		{
			get
			{
				return (base.uiBehaviour == null) ? null : base.uiBehaviour.m_SpectateHandler;
			}
		}

		public IXUILabel LeftTime
		{
			get
			{
				return (base.uiBehaviour == null) ? null : base.uiBehaviour.m_LeftTime;
			}
		}

		private float _strength_preseved_precent
		{
			get
			{
				bool flag = this._current_strength_preseved > this._total_strength_preseved;
				if (flag)
				{
					this._total_strength_preseved = this._current_strength_preseved;
				}
				return this._current_strength_preseved / this._total_strength_preseved;
			}
		}

		public override string fileName
		{
			get
			{
				return "Battle/BattleViewDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		public SpectateSceneView()
		{
			this._showSingleNoticeCb = new XTimerMgr.ElapsedEventHandler(this.ShowSingleNotice);
			this._endBigNoticeCb = new XTimerMgr.ElapsedEventHandler(this.EndBigNotice);
			this._onSwitchToTeamChatCb = new XTimerMgr.ElapsedEventHandler(this.OnSwitchToTeamChat);
			this._hideBattleChatUICb = new XTimerMgr.ElapsedEventHandler(this.HideBattleChatUI);
			this._fYellow = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HP_Yellow"));
			this._fRed = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HP_Red"));
		}

		protected override void Init()
		{
			this._platform = XSingleton<XUpdater.XUpdater>.singleton.XPlatform;
			this._doc = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
			this._doc._SpectateSceneView = this;
			this._doc.LeftTeamMonitorData.Clear();
			this._doc.RightTeamMonitorData.Clear();
			this._attrComp = (XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes);
			this.leftTimeCounter = new XLeftTimeCounter(base.uiBehaviour.m_LeftTime, true);
			this.timeConnter = new XLeftTimeCounter(base.uiBehaviour.m_WarTime, false);
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("ComboBuff");
			string[] array = value.Split(XGlobalConfig.AllSeparators);
			for (int i = 0; i < array.Length; i += 3)
			{
				ComboBuff comboBuff = new ComboBuff();
				comboBuff.combo = int.Parse(array[i]);
				comboBuff.buffID = int.Parse(array[i + 1]);
				comboBuff.buffLevel = int.Parse(array[i + 2]);
				BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData(comboBuff.buffID, comboBuff.buffLevel);
				bool flag = buffData != null;
				if (flag)
				{
					comboBuff.buffName = buffData.BuffName;
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("ComboBuff: Buff data not found: [{0} {1}]", comboBuff.buffID, comboBuff.buffLevel), null, null, null, null, null);
				}
				this._combo_buff_list.Add(comboBuff);
			}
			this.SetupHandler();
		}

		private void SetupHandler()
		{
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			if (sceneType != SceneType.SCENE_PVP)
			{
				if (sceneType == SceneType.SCENE_HEROBATTLE)
				{
					DlgHandlerBase.EnsureCreate<HeroBattleHandler>(ref this._HeroBattleHandler, base.uiBehaviour.m_canvas, true, this);
				}
			}
			else
			{
				DlgHandlerBase.EnsureCreate<BattleCaptainPVPHandler>(ref this.m_BattleCaptainPVPHandler, base.uiBehaviour.m_canvas, true, this);
			}
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_pause.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPauseClick));
			this.m_SwitchSight = new XSwitchSight(new ButtonClickEventHandler(this.OnViewClick), base.uiBehaviour.m_25D, base.uiBehaviour.m_3D, base.uiBehaviour.m_3DFree);
			base.uiBehaviour.m_Sight.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSightClick));
			base.uiBehaviour.m_barrageOpen.ID = 1UL;
			base.uiBehaviour.m_barrageOpen.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBarrageClick));
			base.uiBehaviour.m_barrageClose.ID = 0UL;
			base.uiBehaviour.m_barrageClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBarrageClick));
			base.uiBehaviour.m_btnShare.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShareClick));
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			DlgHandlerBase.EnsureCreate<XYuyinView>(ref this._yuyinHandler, base.uiBehaviour.transform, true, this);
		}

		protected override void OnShow()
		{
			this.lastPingTime = -60f;
			XPlayerAttributes xplayerAttributes = XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes;
			DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.Show(true);
			DlgBase<RadioDlg, RadioBehaviour>.singleton.Show(true);
			base.uiBehaviour.m_SightSelect.gameObject.SetActive(false);
			int num = XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.Profession);
			base.uiBehaviour.m_IndicateHandler.SetVisible(true);
			base.uiBehaviour.m_SceneName.SetText(XSingleton<XScene>.singleton.SceneData.Comment);
			this.SetTimeRecord();
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
			this.sceneType = (SceneType)sceneData.type;
			SceneType sceneType = this.sceneType;
			if (sceneType <= SceneType.SCENE_ABYSSS)
			{
				if (sceneType != SceneType.SCENE_BATTLE)
				{
					switch (sceneType)
					{
					case SceneType.SCENE_PK:
					{
						XQualifyingDocument specificDocument = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
						bool flag = specificDocument.PkInfoList.Count > 0;
						if (flag)
						{
							this.SetEnemyRoleInfo(specificDocument.PkInfoList[0].brief.roleName, specificDocument.PkInfoList[0].brief.roleLevel);
						}
						break;
					}
					}
				}
			}
			else if (sceneType != SceneType.SCENE_TOWER)
			{
				if (sceneType != SceneType.SCENE_LEAGUE_BATTLE)
				{
				}
			}
			SceneType sceneType2 = this.sceneType;
			if (sceneType2 != SceneType.SCENE_ARENA && sceneType2 != SceneType.SCENE_PK)
			{
				this.EnemyInfoHandler.InitBoss();
			}
			else
			{
				this.EnemyInfoHandler.InitRole();
			}
			this.SpectateTeamMonitor.InitWhenShowMainUI();
			bool flag2 = XSingleton<XScene>.singleton.SceneID != 100U && XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= 10U;
			if (flag2)
			{
				ShowSettingArgs showSettingArgs = new ShowSettingArgs();
				showSettingArgs.position = 3;
				showSettingArgs.showsettings = false;
				showSettingArgs.enablebackclick = true;
				DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.ShowChatMiniUI(showSettingArgs);
			}
			base.uiBehaviour.m_StrengthPresevedBar.SetVisible(this._doc.ShowStrengthPresevedBar);
			this.LoadYuyin();
			this.InitView();
			this.ShowBarrge();
		}

		private void ShowBarrge()
		{
			bool openBarrage = DlgBase<BarrageDlg, BarrageBehaviour>.singleton.openBarrage;
			DlgBase<BarrageDlg, BarrageBehaviour>.singleton.SetVisible(openBarrage, true);
			base.uiBehaviour.m_barrageClose.SetVisible(openBarrage);
			base.uiBehaviour.m_barrageOpen.SetVisible(!openBarrage);
		}

		private void InitView()
		{
			this.SetView(XSingleton<XOperationData>.singleton.OperationMode);
		}

		public void SetView(XOperationMode mode)
		{
			switch (mode)
			{
			case XOperationMode.X25D:
				base.uiBehaviour.m_SightPic.SetSprite("l_zdicon_1_1");
				base.uiBehaviour.m_SelectPic.SetSprite("l_zdicon_1_1");
				break;
			case XOperationMode.X3D:
				base.uiBehaviour.m_SightPic.SetSprite("l_zdicon_1_0");
				base.uiBehaviour.m_SelectPic.SetSprite("l_zdicon_1_0");
				break;
			case XOperationMode.X3D_Free:
				base.uiBehaviour.m_SightPic.SetSprite("l_zdicon_1_2");
				base.uiBehaviour.m_SelectPic.SetSprite("l_zdicon_1_2");
				break;
			}
			base.uiBehaviour.m_SightPic.MakePixelPerfect();
			base.uiBehaviour.m_SelectPic.MakePixelPerfect();
			base.uiBehaviour.m_SightSelect.gameObject.SetActive(false);
		}

		public bool OnSightClick(IXUIButton sp)
		{
			bool activeSelf = base.uiBehaviour.m_SightSelect.gameObject.activeSelf;
			if (activeSelf)
			{
				base.uiBehaviour.m_SightSelect.gameObject.SetActive(false);
			}
			else
			{
				base.uiBehaviour.m_SightSelect.gameObject.SetActive(true);
			}
			return true;
		}

		protected override void OnHide()
		{
			DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.Show(false);
			DlgBase<RadioDlg, RadioBehaviour>.singleton.Show(false);
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetVisible(false, true);
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XOptionsBattleHandler>(ref this.m_XOptionBattleHandler);
			DlgHandlerBase.EnsureUnload<BattleCaptainPVPHandler>(ref this.m_BattleCaptainPVPHandler);
			DlgHandlerBase.EnsureUnload<HeroBattleHandler>(ref this._HeroBattleHandler);
			base.uiBehaviour.m_IndicateHandler.OnUnload();
			base.uiBehaviour.m_SpectateTeamMonitor.OnUnload();
			base.uiBehaviour.m_SpectateHandler.OnUnload();
			base.uiBehaviour.m_EnemyInfoHandler.OnUnload();
			DlgHandlerBase.EnsureUnload<XYuyinView>(ref this._yuyinHandler);
			this._doc._SpectateSceneView = null;
			base.OnUnload();
		}

		private void LoadYuyin()
		{
			YuyinIconType type = YuyinIconType.SPECTATE;
			bool flag = this._yuyinHandler != null;
			if (flag)
			{
				this._yuyinHandler.Refresh(type);
			}
		}

		private void SetEnemyRoleInfo(string name, uint level)
		{
		}

		public void RefreshYuyin(ulong uid)
		{
			bool flag = this._yuyinHandler != null;
			if (flag)
			{
				this._yuyinHandler.Refresh(YuyinIconType.SPECTATE);
			}
		}

		private bool OnPauseClick(IXUIButton go)
		{
			bool flag = !base.IsLoaded();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
				bool flag2 = sceneData != null;
				if (flag2)
				{
					bool canPause = sceneData.CanPause;
					if (canPause)
					{
						XSingleton<XShell>.singleton.Pause = true;
					}
				}
				bool flag3 = this.m_XOptionBattleHandler == null;
				if (flag3)
				{
					bool flag4 = base.uiBehaviour != null;
					if (flag4)
					{
						DlgHandlerBase.EnsureCreate<XOptionsBattleHandler>(ref this.m_XOptionBattleHandler, base.uiBehaviour.m_canvas, true, DlgBase<BattleMain, BattleMainBehaviour>.singleton);
					}
				}
				bool flag5 = this.m_XOptionBattleHandler != null && !this.m_XOptionBattleHandler.IsVisible();
				if (flag5)
				{
					this.m_XOptionBattleHandler.ShowUI();
				}
				this.sceneType = XSingleton<XScene>.singleton.SceneType;
				result = true;
			}
			return result;
		}

		public override void OnUpdate()
		{
			bool flag = !XSingleton<XTimerMgr>.singleton.NeedFixedUpdate;
			if (!flag)
			{
				base.OnUpdate();
				this.UpdateFPS();
				this.UpdateWifi();
				base.uiBehaviour.m_IndicateHandler.OnUpdate();
				bool flag2 = Time.time - this._last_check_time > 5f;
				if (flag2)
				{
					this._last_check_time = Time.time;
					this._doc.SendCheckTime();
				}
				this.UpdateTime();
				this.UpdateLeftTime();
				bool flag3 = Time.unscaledTime - this.lastPingTime > 60f || this.lastPingTime < 0f;
				if (flag3)
				{
					this.RefreshPing();
					this.lastPingTime = Time.unscaledTime;
				}
				bool flag4 = this.NoticeTime > 0f;
				if (flag4)
				{
					bool flag5 = Time.time - this.NoticeTime > this._notice_duration;
					if (flag5)
					{
						base.uiBehaviour.m_NoticeFrame.transform.localPosition = XGameUI.Far_Far_Away;
						this.NoticeTime = 0f;
					}
				}
				this.SpectateTeamMonitor.OnUpdate();
				this.EnemyInfoHandler.OnUpdate();
				bool flag6 = base.uiBehaviour.m_StrengthPresevedBar.IsVisible();
				if (flag6)
				{
					this.RefreshStrengthPresevedBar();
				}
			}
		}

		private void UpdateWifi()
		{
			XSingleton<UiUtility>.singleton.UpdateWifi(null, this.m_uiBehaviour.m_sprwifi);
		}

		private void RefreshPing()
		{
			XSingleton<UiUtility>.singleton.RefreshPing(base.uiBehaviour.m_lblTime, base.uiBehaviour.m_sliderBattery, base.uiBehaviour.m_lblFree);
		}

		public void UpdateFPS()
		{
			bool flag = !this._platform.IsPublish();
			if (flag)
			{
				bool showBuildLog = XSingleton<XGame>.singleton.ShowBuildLog;
				if (showBuildLog)
				{
					string syncModeString = XSingleton<XGame>.singleton.GetSyncModeString();
					base.uiBehaviour.m_fps.SetText(string.Concat(new object[]
					{
						"Build:",
						XLinkTimeStamp.BuildDateTime.ToString(),
						"\n",
						XSingleton<XGame>.singleton.Fps.ToString("F1"),
						syncModeString,
						XSingleton<XClientNetwork>.singleton.ServerIP,
						"\nSend:",
						XSingleton<XClientNetwork>.singleton.SendBytes,
						" Recv:",
						XSingleton<XClientNetwork>.singleton.RecvBytes,
						" delay:",
						XSingleton<XServerTimeMgr>.singleton.GetDelay()
					}));
				}
				else
				{
					base.uiBehaviour.m_fps.SetText("");
				}
			}
		}

		public void ShowNotice(string text, float duration, float pertime = 1f)
		{
			this._notice_collection.Clear();
			bool flag = string.IsNullOrEmpty(text);
			if (!flag)
			{
				string[] array = text.Split(XGlobalConfig.ListSeparator);
				for (int i = 0; i < array.Length; i++)
				{
					this._notice_collection.Add(array[i]);
				}
				this._notice_duration = duration;
				this._notice_pertime = pertime;
				bool flag2 = this.time_token > 0U;
				if (flag2)
				{
					XSingleton<XTimerMgr>.singleton.KillTimer(this.time_token);
					this.time_token = 0U;
				}
				bool flag3 = this._notice_collection.Count > 0;
				if (flag3)
				{
					this.ShowSingleNotice(0);
				}
			}
		}

		protected void ShowSingleNotice(object o)
		{
			int num = (int)o;
			bool flag = num < this._notice_collection.Count;
			if (flag)
			{
				string text = this._notice_collection[num];
				base.uiBehaviour.m_Notice.SetText(text);
				base.uiBehaviour.m_NoticeFrame.transform.localPosition = base.uiBehaviour.m_NoticePos;
				this.NoticeTime = Time.time;
				this.time_token = XSingleton<XTimerMgr>.singleton.SetTimer(this._notice_pertime, this._showSingleNoticeCb, num + 1);
				bool flag2 = num == this._notice_collection.Count - 1;
				if (flag2)
				{
					XSingleton<XLevelScriptMgr>.singleton.ExecuteNextCmd();
					this._notice_collection.Clear();
				}
			}
		}

		public void StopNotice()
		{
			bool flag = this.time_token > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this.time_token);
				this.time_token = 0U;
			}
			base.uiBehaviour.m_NoticeFrame.transform.localPosition = XGameUI.Far_Far_Away;
		}

		public void ShowBigNotice(string text)
		{
			this._big_notice = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("UI/Common/TutorialButtomText", true, false) as GameObject);
			this._big_notice.transform.parent = XSingleton<XGameUI>.singleton.UIRoot;
			this._big_notice.transform.localPosition = Vector3.zero;
			this._big_notice.transform.localScale = Vector3.one;
			IXUILabel ixuilabel = this._big_notice.transform.FindChild("TutorialText").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(text);
			IXUITweenTool ixuitweenTool = this._big_notice.GetComponent("XUIPlayTween") as IXUITweenTool;
			ixuitweenTool.PlayTween(true, -1f);
			XSingleton<XTimerMgr>.singleton.SetTimer(5f, this._endBigNoticeCb, null);
		}

		protected void EndBigNotice(object o)
		{
			bool flag = this._big_notice != null;
			if (flag)
			{
				XResourceLoaderMgr.SafeDestroy(ref this._big_notice, true);
				XSingleton<XLevelScriptMgr>.singleton.ExecuteNextCmd();
			}
		}

		public void SetLeftTime(uint seconds)
		{
			base.uiBehaviour.m_LeftTime.SetVisible(true);
			this.leftTimeCounter.SetLeftTime(seconds, -1);
			base.uiBehaviour.m_WarTime.SetVisible(false);
		}

		public void SetTimeRecord()
		{
			base.uiBehaviour.m_WarTime.SetVisible(true);
			this.timeConnter.SetForward(1);
			this.timeConnter.SetLeftTime(0.01f, -1);
		}

		public void ResetLeftTime(int seconds)
		{
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
			bool flag = sceneData.TimeCounter == null || sceneData.TimeCounter.Length < 1;
			if (flag)
			{
				this.timeConnter.SetLeftTime((float)seconds, -1);
			}
			else
			{
				bool flag2 = sceneData.TimeCounter[0] == 1;
				if (flag2)
				{
					this.leftTimeCounter.SetLeftTime((float)((int)sceneData.TimeCounter[1] - seconds), -1);
				}
			}
		}

		private void UpdateLeftTime()
		{
			this.leftTimeCounter.Update();
		}

		private void UpdateTime()
		{
			this.timeConnter.Update();
		}

		public bool OnShowChatDlg(IXUIButton sp)
		{
			DlgBase<XChatView, XChatBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, this._onSwitchToTeamChatCb, null);
			return true;
		}

		public void OnSwitchToTeamChat(object obj)
		{
			DlgBase<XChatView, XChatBehaviour>.singleton.SelectChatTeam();
		}

		public void OnVoiceButtonDrag(IXUIButton sp, Vector2 delta)
		{
			this.m_DragDistance += delta;
			bool flag = this.m_DragDistance.magnitude >= 100f;
			if (flag)
			{
				this.m_CancelRecord = true;
			}
			else
			{
				this.m_CancelRecord = false;
			}
		}

		public void OnVoiceButton(IXUIButton sp, bool state)
		{
			if (state)
			{
				XSingleton<XDebug>.singleton.AddLog("Press down", null, null, null, null, null, XDebugColor.XDebug_None);
				this.m_DragDistance = Vector2.zero;
				this.m_IsRecording = true;
				bool useApollo = XChatDocument.UseApollo;
				if (useApollo)
				{
					XSingleton<XChatApolloMgr>.singleton.StartRecord(VoiceUsage.CHAT, null);
				}
				else
				{
					XSingleton<XChatIFlyMgr>.singleton.StartRecord(VoiceUsage.CHAT, null);
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddLog("Press up", null, null, null, null, null, XDebugColor.XDebug_None);
				this.m_IsRecording = false;
				DlgBase<XChatView, XChatBehaviour>.singleton.SetActiveChannel(ChatChannelType.Team);
				bool useApollo2 = XChatDocument.UseApollo;
				if (useApollo2)
				{
					XSingleton<XChatApolloMgr>.singleton.StopRecord(this.m_CancelRecord);
				}
				else
				{
					XSingleton<XChatIFlyMgr>.singleton.StopRecord(this.m_CancelRecord);
				}
			}
		}

		public void OnStopVoiceRecord()
		{
			bool isRecording = this.m_IsRecording;
			if (isRecording)
			{
				DlgBase<XChatView, XChatBehaviour>.singleton.SetActiveChannel(ChatChannelType.Team);
				bool useApollo = XChatDocument.UseApollo;
				if (useApollo)
				{
					XSingleton<XChatApolloMgr>.singleton.StopRecord(this.m_CancelRecord);
				}
				else
				{
					XSingleton<XChatIFlyMgr>.singleton.StopRecord(this.m_CancelRecord);
				}
				this.m_IsRecording = false;
			}
		}

		public bool OnCommandBtnClick(IXUIButton btn)
		{
			return true;
		}

		private void OnAutoPlayTip(IXUISprite go)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_ARENA;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemNoticeTip(XStringDefineProxy.GetString("ArenaAutoFight"));
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemNoticeTip(string.Format(XStringDefineProxy.GetString("AutoFightOpenLevel"), XSingleton<XGlobalConfig>.singleton.GetValue("AutoPlayUnlockLevel")));
			}
		}

		public void ShowBattleVoice(ChatVoiceInfo info)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.m_ChatLabelCd = XSingleton<XTimerMgr>.singleton.SetTimer((float)info.voiceTime + 2f, this._hideBattleChatUICb, info);
			}
		}

		public void HideBattleChatUI(object info)
		{
			this.m_ChatLabelCd = 0U;
		}

		public void ShowCountDownFrame(bool status)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				base.uiBehaviour.m_CountDownFrame.gameObject.SetActive(true);
				base.uiBehaviour.m_CountDownTimeFrame.gameObject.SetActive(status);
				base.uiBehaviour.m_CountDownBeginFrame.gameObject.SetActive(!status);
				(base.uiBehaviour.m_CountDownTimeFrame.gameObject.GetComponent("XUIPlayTween") as IXUITweenTool).PlayTween(status, -1f);
				(base.uiBehaviour.m_CountDownBeginFrame.gameObject.GetComponent("XUIPlayTween") as IXUITweenTool).PlayTween(!status, -1f);
			}
		}

		public void OnPlaySuperarmorFx(XEntity enemy, bool bBroken)
		{
			for (int i = 0; i < this.EnemyInfoHandler.EnemyList.Count; i++)
			{
				bool flag = this.EnemyInfoHandler.EnemyList[i].Entity == enemy;
				if (flag)
				{
					this.EnemyInfoHandler.EnemyList[i].SetSuperArmorState(bBroken);
					break;
				}
			}
		}

		public void OnStopSuperarmorFx(XEntity enemy)
		{
			for (int i = 0; i < this.EnemyInfoHandler.EnemyList.Count; i++)
			{
				bool flag = this.EnemyInfoHandler.EnemyList[i].Entity == enemy;
				if (flag)
				{
					this.EnemyInfoHandler.EnemyList[i].StopSuperArmorFx();
					break;
				}
			}
		}

		public void OnProjectDamage(ProjectDamageResult damage, XEntity entity)
		{
			for (int i = 0; i < this.EnemyInfoHandler.EnemyList.Count; i++)
			{
				bool flag = this.EnemyInfoHandler.EnemyList[i].Entity == entity;
				if (flag)
				{
					bool flag2 = XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.WatchTo != null && damage.Caster == XSingleton<XEntityMgr>.singleton.Player.WatchTo.ID;
					if (flag2)
					{
						this.EnemyInfoHandler.EnemyList[i].OnBeHit(damage);
					}
					break;
				}
			}
		}

		public void SetupSpeedFx(XEntity enemy, bool enable, Color c)
		{
			for (int i = 0; i < this.EnemyInfoHandler.EnemyList.Count; i++)
			{
				bool flag = this.EnemyInfoHandler.EnemyList[i].Entity == enemy;
				if (flag)
				{
					IXUISprite uiSuperArmorSpeedFx = this.EnemyInfoHandler.EnemyList[i].m_uiSuperArmorSpeedFx;
					uiSuperArmorSpeedFx.gameObject.SetActive(enable);
					uiSuperArmorSpeedFx.SetColor(c);
					break;
				}
			}
		}

		public void ShowStrengthPresevedBar(XEntity entity)
		{
			base.uiBehaviour.m_StrengthPresevedBar.SetVisible(true);
			this._strength_preseved_entity = entity;
			this._total_strength_preseved = (float)this._strength_preseved_entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentXULI_Basic);
			this._current_strength_preseved = this._total_strength_preseved;
			this.RefreshStrengthPresevedBar();
		}

		public void HideStrengthPresevedBar()
		{
			base.uiBehaviour.m_StrengthPresevedBar.SetVisible(false);
			this._strength_preseved_entity = null;
			this._total_strength_preseved = 1f;
			this._current_strength_preseved = 0f;
		}

		public void RefreshStrengthPresevedBar()
		{
			this._current_strength_preseved = (float)this._strength_preseved_entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentXULI_Basic);
			base.uiBehaviour.m_StrengthPresevedBar.value = this._strength_preseved_precent;
		}

		public bool OnViewClick(IXUIButton sp)
		{
			this.SetView((XOperationMode)sp.ID);
			return true;
		}

		public bool OnBarrageClick(IXUIButton btn)
		{
			int num = (int)btn.ID;
			bool flag = num == 1;
			base.uiBehaviour.m_barrageOpen.SetVisible(!flag);
			base.uiBehaviour.m_barrageClose.SetVisible(flag);
			DlgBase<BarrageDlg, BarrageBehaviour>.singleton.openBarrage = flag;
			bool flag2 = !flag;
			if (flag2)
			{
				DlgBase<BarrageDlg, BarrageBehaviour>.singleton.ClearAll();
			}
			DlgBase<BarrageDlg, BarrageBehaviour>.singleton.SetVisible(flag, true);
			return true;
		}

		public bool OnShareClick(IXUIButton btn)
		{
			XSpectateDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
			LiveType liveTypeBySceneType = XSpectateDocument.GetLiveTypeBySceneType(XSingleton<XScene>.singleton.SceneType);
			XSingleton<XDebug>.singleton.AddLog("Share btn click, live type is: " + liveTypeBySceneType, null, null, null, null, null, XDebugColor.XDebug_None);
			uint num = (uint)XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(ChatChannelType.World);
			XInvitationDocument specificDocument2 = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
			XSpectateSceneDocument specificDocument3 = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
			uint liveID = specificDocument3.liveRecordInfo.liveID;
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.DoOpenChatWindow(null);
			bool flag = liveTypeBySceneType == LiveType.LIVE_PVP;
			if (flag)
			{
				int tianTiLevel = specificDocument3.liveRecordInfo.tianTiLevel;
				string name = specificDocument3.liveRecordInfo.nameInfos[0].roleInfo.name;
				string name2 = specificDocument3.liveRecordInfo.nameInfos[1].roleInfo.name;
				DlgBase<XChatView, XChatBehaviour>.singleton.RegistLinkSend(specificDocument2.GetSpectateLinkString(100002U, new object[]
				{
					tianTiLevel,
					name,
					name2
				}), new Action(this.OnChatSend));
			}
			else
			{
				bool flag2 = liveTypeBySceneType == LiveType.LIVE_NEST;
				if (flag2)
				{
					string title = specificDocument.GetTitle(specificDocument3.liveRecordInfo);
					DlgBase<XChatView, XChatBehaviour>.singleton.RegistLinkSend(specificDocument2.GetSpectateLinkString(100003U, new object[]
					{
						title
					}), new Action(this.OnChatSend));
				}
				else
				{
					bool flag3 = liveTypeBySceneType == LiveType.LIVE_PROTECTCAPTAIN;
					if (flag3)
					{
						List<LiveNameInfo> nameInfos = specificDocument3.liveRecordInfo.nameInfos;
						string teamLeaderName = nameInfos[0].teamLeaderName;
						string teamLeaderName2 = nameInfos[1].teamLeaderName;
						for (int i = 0; i < nameInfos.Count; i++)
						{
							bool isLeft = nameInfos[i].isLeft;
							if (isLeft)
							{
								bool flag4 = nameInfos[i].teamLeaderName != "";
								if (flag4)
								{
									teamLeaderName = nameInfos[i].teamLeaderName;
								}
							}
							else
							{
								bool flag5 = nameInfos[i].teamLeaderName != "";
								if (flag5)
								{
									teamLeaderName2 = nameInfos[i].teamLeaderName;
								}
							}
						}
						DlgBase<XChatView, XChatBehaviour>.singleton.RegistLinkSend(specificDocument2.GetSpectateLinkString(100004U, new object[]
						{
							teamLeaderName,
							teamLeaderName2
						}), new Action(this.OnChatSend));
					}
					else
					{
						bool flag6 = liveTypeBySceneType == LiveType.LIVE_GUILDBATTLE;
						if (flag6)
						{
							string guildName = specificDocument3.liveRecordInfo.nameInfos[0].guildName;
							string guildName2 = specificDocument3.liveRecordInfo.nameInfos[1].guildName;
							DlgBase<XChatView, XChatBehaviour>.singleton.RegistLinkSend(specificDocument2.GetSpectateLinkString(100005U, new object[]
							{
								guildName,
								guildName2
							}), new Action(this.OnChatSend));
						}
						else
						{
							bool flag7 = liveTypeBySceneType == LiveType.LIVE_DRAGON;
							if (flag7)
							{
								string title2 = specificDocument.GetTitle(specificDocument3.liveRecordInfo);
								DlgBase<XChatView, XChatBehaviour>.singleton.RegistLinkSend(specificDocument2.GetSpectateLinkString(100006U, new object[]
								{
									title2
								}), new Action(this.OnChatSend));
							}
							else
							{
								bool flag8 = liveTypeBySceneType == LiveType.LIVE_HEROBATTLE;
								if (flag8)
								{
									string title3 = specificDocument.GetTitle(specificDocument3.liveRecordInfo);
									DlgBase<XChatView, XChatBehaviour>.singleton.RegistLinkSend(specificDocument2.GetSpectateLinkString(100008U, new object[]
									{
										title3
									}), new Action(this.OnChatSend));
								}
								else
								{
									bool flag9 = liveTypeBySceneType == LiveType.LIVE_LEAGUEBATTLE;
									if (flag9)
									{
										string teamName = specificDocument3.liveRecordInfo.nameInfos[0].teamName;
										string teamName2 = specificDocument3.liveRecordInfo.nameInfos[1].teamName;
										DlgBase<XChatView, XChatBehaviour>.singleton.RegistLinkSend(specificDocument2.GetSpectateLinkString(100009U, new object[]
										{
											teamName,
											teamName2
										}), new Action(this.OnChatSend));
									}
									else
									{
										bool flag10 = liveTypeBySceneType == LiveType.LIVE_PVP2;
										if (flag10)
										{
											string text = "";
											string text2 = "";
											for (int j = 0; j < specificDocument3.liveRecordInfo.nameInfos.Count; j++)
											{
												bool flag11 = specificDocument3.liveRecordInfo.nameInfos[j].teamLeaderName != "";
												if (flag11)
												{
													bool isLeft2 = specificDocument3.liveRecordInfo.nameInfos[j].isLeft;
													if (isLeft2)
													{
														text = specificDocument3.liveRecordInfo.nameInfos[j].teamLeaderName;
													}
													else
													{
														text2 = specificDocument3.liveRecordInfo.nameInfos[j].teamLeaderName;
													}
												}
											}
											DlgBase<XChatView, XChatBehaviour>.singleton.RegistLinkSend(specificDocument2.GetSpectateLinkString(100010U, new object[]
											{
												text,
												text2
											}), new Action(this.OnChatSend));
										}
										else
										{
											bool flag12 = liveTypeBySceneType == LiveType.LIVE_CUSTOMPK;
											if (flag12)
											{
												string name3 = specificDocument3.liveRecordInfo.nameInfos[0].roleInfo.name;
												string name4 = specificDocument3.liveRecordInfo.nameInfos[1].roleInfo.name;
												DlgBase<XChatView, XChatBehaviour>.singleton.RegistLinkSend(specificDocument2.GetSpectateLinkString(100011U, new object[]
												{
													name3,
													name4
												}), new Action(this.OnChatSend));
											}
											else
											{
												bool flag13 = liveTypeBySceneType == LiveType.LIVE_CROSSGVG;
												if (flag13)
												{
													string guildName3 = specificDocument3.liveRecordInfo.nameInfos[0].guildName;
													string guildName4 = specificDocument3.liveRecordInfo.nameInfos[1].guildName;
													DlgBase<XChatView, XChatBehaviour>.singleton.RegistLinkSend(specificDocument2.GetSpectateLinkString(100013U, new object[]
													{
														guildName3,
														guildName4
													}), new Action(this.OnChatSend));
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return true;
		}

		private void OnChatSend()
		{
			XSpectateDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
			LiveType liveTypeBySceneType = XSpectateDocument.GetLiveTypeBySceneType(XSingleton<XScene>.singleton.SceneType);
			XSingleton<XDebug>.singleton.AddLog("Share btn click, live type is:" + liveTypeBySceneType, null, null, null, null, null, XDebugColor.XDebug_None);
			uint num = (uint)XFastEnumIntEqualityComparer<ChatChannelType>.ToInt(ChatChannelType.World);
			XInvitationDocument specificDocument2 = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
			XSpectateSceneDocument specificDocument3 = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
			uint liveID = specificDocument3.liveRecordInfo.liveID;
			bool flag = liveTypeBySceneType == LiveType.LIVE_PVP;
			if (flag)
			{
				int tianTiLevel = specificDocument3.liveRecordInfo.tianTiLevel;
				string name = specificDocument3.liveRecordInfo.nameInfos[0].roleInfo.name;
				string name2 = specificDocument3.liveRecordInfo.nameInfos[1].roleInfo.name;
				specificDocument2.SendSpectateInvitation(100002U, liveID, liveTypeBySceneType, new object[]
				{
					tianTiLevel,
					name,
					name2
				});
			}
			else
			{
				bool flag2 = liveTypeBySceneType == LiveType.LIVE_NEST;
				if (flag2)
				{
					string title = specificDocument.GetTitle(specificDocument3.liveRecordInfo);
					specificDocument2.SendSpectateInvitation(100003U, liveID, liveTypeBySceneType, new object[]
					{
						title
					});
				}
				else
				{
					bool flag3 = liveTypeBySceneType == LiveType.LIVE_PROTECTCAPTAIN;
					if (flag3)
					{
						List<LiveNameInfo> nameInfos = specificDocument3.liveRecordInfo.nameInfos;
						string teamLeaderName = nameInfos[0].teamLeaderName;
						string teamLeaderName2 = nameInfos[1].teamLeaderName;
						for (int i = 0; i < nameInfos.Count; i++)
						{
							bool isLeft = nameInfos[i].isLeft;
							if (isLeft)
							{
								bool flag4 = nameInfos[i].teamLeaderName != "";
								if (flag4)
								{
									teamLeaderName = nameInfos[i].teamLeaderName;
								}
							}
							else
							{
								bool flag5 = nameInfos[i].teamLeaderName != "";
								if (flag5)
								{
									teamLeaderName2 = nameInfos[i].teamLeaderName;
								}
							}
						}
						specificDocument2.SendSpectateInvitation(100004U, liveID, liveTypeBySceneType, new object[]
						{
							teamLeaderName,
							teamLeaderName2
						});
					}
					else
					{
						bool flag6 = liveTypeBySceneType == LiveType.LIVE_GUILDBATTLE;
						if (flag6)
						{
							string guildName = specificDocument3.liveRecordInfo.nameInfos[0].guildName;
							string guildName2 = specificDocument3.liveRecordInfo.nameInfos[1].guildName;
							specificDocument2.SendSpectateInvitation(100005U, liveID, liveTypeBySceneType, new object[]
							{
								guildName,
								guildName2
							});
						}
						else
						{
							bool flag7 = liveTypeBySceneType == LiveType.LIVE_DRAGON;
							if (flag7)
							{
								string title2 = specificDocument.GetTitle(specificDocument3.liveRecordInfo);
								specificDocument2.SendSpectateInvitation(100006U, liveID, liveTypeBySceneType, new object[]
								{
									title2
								});
							}
							else
							{
								bool flag8 = liveTypeBySceneType == LiveType.LIVE_HEROBATTLE;
								if (flag8)
								{
									string title3 = specificDocument.GetTitle(specificDocument3.liveRecordInfo);
									specificDocument2.SendSpectateInvitation(100008U, liveID, liveTypeBySceneType, new object[]
									{
										title3
									});
								}
								else
								{
									bool flag9 = liveTypeBySceneType == LiveType.LIVE_LEAGUEBATTLE;
									if (flag9)
									{
										string teamName = specificDocument3.liveRecordInfo.nameInfos[0].teamName;
										string teamName2 = specificDocument3.liveRecordInfo.nameInfos[1].teamName;
										specificDocument2.SendSpectateInvitation(100009U, liveID, liveTypeBySceneType, new object[]
										{
											teamName,
											teamName2
										});
									}
									else
									{
										bool flag10 = liveTypeBySceneType == LiveType.LIVE_PVP2;
										if (flag10)
										{
											string text = "";
											string text2 = "";
											for (int j = 0; j < specificDocument3.liveRecordInfo.nameInfos.Count; j++)
											{
												bool flag11 = specificDocument3.liveRecordInfo.nameInfos[j].teamLeaderName != "";
												if (flag11)
												{
													bool isLeft2 = specificDocument3.liveRecordInfo.nameInfos[j].isLeft;
													if (isLeft2)
													{
														text = specificDocument3.liveRecordInfo.nameInfos[j].teamLeaderName;
													}
													else
													{
														text2 = specificDocument3.liveRecordInfo.nameInfos[j].teamLeaderName;
													}
												}
											}
											specificDocument2.SendSpectateInvitation(100010U, liveID, liveTypeBySceneType, new object[]
											{
												text,
												text2
											});
										}
										else
										{
											bool flag12 = liveTypeBySceneType == LiveType.LIVE_CUSTOMPK;
											if (flag12)
											{
												string name3 = specificDocument3.liveRecordInfo.nameInfos[0].roleInfo.name;
												string name4 = specificDocument3.liveRecordInfo.nameInfos[1].roleInfo.name;
												specificDocument2.SendSpectateInvitation(100011U, liveID, liveTypeBySceneType, new object[]
												{
													name3,
													name4
												});
											}
											else
											{
												bool flag13 = liveTypeBySceneType == LiveType.LIVE_CROSSGVG;
												if (flag13)
												{
													string guildName3 = specificDocument3.liveRecordInfo.nameInfos[0].guildName;
													string guildName4 = specificDocument3.liveRecordInfo.nameInfos[1].guildName;
													specificDocument2.SendSpectateInvitation(100013U, liveID, liveTypeBySceneType, new object[]
													{
														guildName3,
														guildName4
													});
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		public void ShowBackToMainCityTips()
		{
			string @string = XStringDefineProxy.GetString("ERR_WATCH_LIVEISOVER");
			string string2 = XStringDefineProxy.GetString("Spectate_Goon");
			string string3 = XStringDefineProxy.GetString("LEVEL_REWARD_RETURN");
			XSingleton<UiUtility>.singleton.ShowModalDialog(@string, string2, string3, new ButtonClickEventHandler(this.OnGoOnBtnClick), new ButtonClickEventHandler(this.OnBackToMainCityBtnClick), false, XTempTipDefine.OD_START, 251);
		}

		private bool OnBackToMainCityBtnClick(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this._doc.LevelScene();
			return true;
		}

		private bool OnGoOnBtnClick(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			DlgBase<SpectateView, SpectateBehaviour>.singleton.SetVisible(true, true);
			return true;
		}

		public float GetLeftTime()
		{
			return this.leftTimeCounter.GetFloatLeftTime();
		}

		public static uint _pool_size = 5U;

		private XPlayerAttributes _attrComp = null;

		private float NoticeTime = 0f;

		private Color32 _hp_green = new Color32(46, 203, 0, byte.MaxValue);

		private Color32 _hp_yellow = new Color32(byte.MaxValue, 249, 32, byte.MaxValue);

		private Color32 _hp_red = new Color32(byte.MaxValue, 39, 39, byte.MaxValue);

		private Vector2 m_DragDistance = Vector2.zero;

		private bool m_CancelRecord = false;

		private bool m_IsRecording = false;

		private uint m_ChatLabelCd = 0U;

		public XOptionsBattleHandler m_XOptionBattleHandler = null;

		private BattleCaptainPVPHandler m_BattleCaptainPVPHandler = null;

		public HeroBattleHandler _HeroBattleHandler = null;

		private SceneType sceneType;

		private XLeftTimeCounter leftTimeCounter;

		private XLeftTimeCounter timeConnter;

		private float _last_check_time = 0f;

		private IPlatform _platform = null;

		private List<string> _notice_collection = new List<string>();

		private float _notice_duration = 0f;

		private float _notice_pertime = 1f;

		private List<ComboBuff> _combo_buff_list = new List<ComboBuff>();

		private Vector2 _yuyin_init_pos = Vector2.zero;

		private Vector2 _yuyin_offset = new Vector2(65f, 0f);

		private XSpectateSceneDocument _doc;

		private uint time_token = 0U;

		private XEntity _strength_preseved_entity = null;

		private float _total_strength_preseved = 1f;

		private float _current_strength_preseved = 0f;

		private XTimerMgr.ElapsedEventHandler _showSingleNoticeCb = null;

		private XTimerMgr.ElapsedEventHandler _endBigNoticeCb = null;

		private XTimerMgr.ElapsedEventHandler _onSwitchToTeamChatCb = null;

		private XTimerMgr.ElapsedEventHandler _hideBattleChatUICb = null;

		private float _fYellow = 0f;

		private float _fRed = 0f;

		private XSwitchSight m_SwitchSight;

		public XYuyinView _yuyinHandler;

		private float lastPingTime = -60f;

		private GameObject _big_notice = null;
	}
}
