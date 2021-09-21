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
	// Token: 0x02001857 RID: 6231
	internal class SpectateSceneView : DlgBase<SpectateSceneView, SpectateSceneBehaviour>
	{
		// Token: 0x17003975 RID: 14709
		// (get) Token: 0x06010332 RID: 66354 RVA: 0x003E55EC File Offset: 0x003E37EC
		public XSpectateTeamMonitorHandler SpectateTeamMonitor
		{
			get
			{
				return (base.uiBehaviour == null) ? null : base.uiBehaviour.m_SpectateTeamMonitor;
			}
		}

		// Token: 0x17003976 RID: 14710
		// (get) Token: 0x06010333 RID: 66355 RVA: 0x003E561C File Offset: 0x003E381C
		public BattleIndicateHandler IndicateHandler
		{
			get
			{
				return (base.uiBehaviour == null) ? null : base.uiBehaviour.m_IndicateHandler;
			}
		}

		// Token: 0x17003977 RID: 14711
		// (get) Token: 0x06010334 RID: 66356 RVA: 0x003E564C File Offset: 0x003E384C
		public XBattleEnemyInfoHandler EnemyInfoHandler
		{
			get
			{
				return (base.uiBehaviour == null) ? null : base.uiBehaviour.m_EnemyInfoHandler;
			}
		}

		// Token: 0x17003978 RID: 14712
		// (get) Token: 0x06010335 RID: 66357 RVA: 0x003E567C File Offset: 0x003E387C
		public BattleTargetHandler BattleTargetHandler
		{
			get
			{
				return (base.uiBehaviour == null) ? null : base.uiBehaviour.m_BattleTargetHandler;
			}
		}

		// Token: 0x17003979 RID: 14713
		// (get) Token: 0x06010336 RID: 66358 RVA: 0x003E56AC File Offset: 0x003E38AC
		public SpectateHandler SpectateHandler
		{
			get
			{
				return (base.uiBehaviour == null) ? null : base.uiBehaviour.m_SpectateHandler;
			}
		}

		// Token: 0x1700397A RID: 14714
		// (get) Token: 0x06010337 RID: 66359 RVA: 0x003E56DC File Offset: 0x003E38DC
		public IXUILabel LeftTime
		{
			get
			{
				return (base.uiBehaviour == null) ? null : base.uiBehaviour.m_LeftTime;
			}
		}

		// Token: 0x1700397B RID: 14715
		// (get) Token: 0x06010338 RID: 66360 RVA: 0x003E570C File Offset: 0x003E390C
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

		// Token: 0x1700397C RID: 14716
		// (get) Token: 0x06010339 RID: 66361 RVA: 0x003E574C File Offset: 0x003E394C
		public override string fileName
		{
			get
			{
				return "Battle/BattleViewDlg";
			}
		}

		// Token: 0x1700397D RID: 14717
		// (get) Token: 0x0601033A RID: 66362 RVA: 0x003E5764 File Offset: 0x003E3964
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700397E RID: 14718
		// (get) Token: 0x0601033B RID: 66363 RVA: 0x003E5778 File Offset: 0x003E3978
		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0601033C RID: 66364 RVA: 0x003E578C File Offset: 0x003E398C
		public SpectateSceneView()
		{
			this._showSingleNoticeCb = new XTimerMgr.ElapsedEventHandler(this.ShowSingleNotice);
			this._endBigNoticeCb = new XTimerMgr.ElapsedEventHandler(this.EndBigNotice);
			this._onSwitchToTeamChatCb = new XTimerMgr.ElapsedEventHandler(this.OnSwitchToTeamChat);
			this._hideBattleChatUICb = new XTimerMgr.ElapsedEventHandler(this.HideBattleChatUI);
			this._fYellow = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HP_Yellow"));
			this._fRed = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("HP_Red"));
		}

		// Token: 0x0601033D RID: 66365 RVA: 0x003E5978 File Offset: 0x003E3B78
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

		// Token: 0x0601033E RID: 66366 RVA: 0x003E5B00 File Offset: 0x003E3D00
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

		// Token: 0x0601033F RID: 66367 RVA: 0x003E5B60 File Offset: 0x003E3D60
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

		// Token: 0x06010340 RID: 66368 RVA: 0x003E5C5D File Offset: 0x003E3E5D
		protected override void OnLoad()
		{
			base.OnLoad();
			DlgHandlerBase.EnsureCreate<XYuyinView>(ref this._yuyinHandler, base.uiBehaviour.transform, true, this);
		}

		// Token: 0x06010341 RID: 66369 RVA: 0x003E5C80 File Offset: 0x003E3E80
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

		// Token: 0x06010342 RID: 66370 RVA: 0x003E5EC8 File Offset: 0x003E40C8
		private void ShowBarrge()
		{
			bool openBarrage = DlgBase<BarrageDlg, BarrageBehaviour>.singleton.openBarrage;
			DlgBase<BarrageDlg, BarrageBehaviour>.singleton.SetVisible(openBarrage, true);
			base.uiBehaviour.m_barrageClose.SetVisible(openBarrage);
			base.uiBehaviour.m_barrageOpen.SetVisible(!openBarrage);
		}

		// Token: 0x06010343 RID: 66371 RVA: 0x003E5F15 File Offset: 0x003E4115
		private void InitView()
		{
			this.SetView(XSingleton<XOperationData>.singleton.OperationMode);
		}

		// Token: 0x06010344 RID: 66372 RVA: 0x003E5F2C File Offset: 0x003E412C
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

		// Token: 0x06010345 RID: 66373 RVA: 0x003E6020 File Offset: 0x003E4220
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

		// Token: 0x06010346 RID: 66374 RVA: 0x003E6080 File Offset: 0x003E4280
		protected override void OnHide()
		{
			DlgBase<BroadMiniDlg, BroadcastMiniBehaviour>.singleton.Show(false);
			DlgBase<RadioDlg, RadioBehaviour>.singleton.Show(false);
			DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetVisible(false, true);
		}

		// Token: 0x06010347 RID: 66375 RVA: 0x003E60A8 File Offset: 0x003E42A8
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

		// Token: 0x06010348 RID: 66376 RVA: 0x003E6140 File Offset: 0x003E4340
		private void LoadYuyin()
		{
			YuyinIconType type = YuyinIconType.SPECTATE;
			bool flag = this._yuyinHandler != null;
			if (flag)
			{
				this._yuyinHandler.Refresh(type);
			}
		}

		// Token: 0x06010349 RID: 66377 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void SetEnemyRoleInfo(string name, uint level)
		{
		}

		// Token: 0x0601034A RID: 66378 RVA: 0x003E616C File Offset: 0x003E436C
		public void RefreshYuyin(ulong uid)
		{
			bool flag = this._yuyinHandler != null;
			if (flag)
			{
				this._yuyinHandler.Refresh(YuyinIconType.SPECTATE);
			}
		}

		// Token: 0x0601034B RID: 66379 RVA: 0x003E6198 File Offset: 0x003E4398
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

		// Token: 0x0601034C RID: 66380 RVA: 0x003E6274 File Offset: 0x003E4474
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

		// Token: 0x0601034D RID: 66381 RVA: 0x003E63C3 File Offset: 0x003E45C3
		private void UpdateWifi()
		{
			XSingleton<UiUtility>.singleton.UpdateWifi(null, this.m_uiBehaviour.m_sprwifi);
		}

		// Token: 0x0601034E RID: 66382 RVA: 0x003E63DD File Offset: 0x003E45DD
		private void RefreshPing()
		{
			XSingleton<UiUtility>.singleton.RefreshPing(base.uiBehaviour.m_lblTime, base.uiBehaviour.m_sliderBattery, base.uiBehaviour.m_lblFree);
		}

		// Token: 0x0601034F RID: 66383 RVA: 0x003E640C File Offset: 0x003E460C
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

		// Token: 0x06010350 RID: 66384 RVA: 0x003E6520 File Offset: 0x003E4720
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

		// Token: 0x06010351 RID: 66385 RVA: 0x003E65D0 File Offset: 0x003E47D0
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

		// Token: 0x06010352 RID: 66386 RVA: 0x003E6698 File Offset: 0x003E4898
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

		// Token: 0x06010353 RID: 66387 RVA: 0x003E66E8 File Offset: 0x003E48E8
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

		// Token: 0x06010354 RID: 66388 RVA: 0x003E67C0 File Offset: 0x003E49C0
		protected void EndBigNotice(object o)
		{
			bool flag = this._big_notice != null;
			if (flag)
			{
				XResourceLoaderMgr.SafeDestroy(ref this._big_notice, true);
				XSingleton<XLevelScriptMgr>.singleton.ExecuteNextCmd();
			}
		}

		// Token: 0x06010355 RID: 66389 RVA: 0x003E67F8 File Offset: 0x003E49F8
		public void SetLeftTime(uint seconds)
		{
			base.uiBehaviour.m_LeftTime.SetVisible(true);
			this.leftTimeCounter.SetLeftTime(seconds, -1);
			base.uiBehaviour.m_WarTime.SetVisible(false);
		}

		// Token: 0x06010356 RID: 66390 RVA: 0x003E682F File Offset: 0x003E4A2F
		public void SetTimeRecord()
		{
			base.uiBehaviour.m_WarTime.SetVisible(true);
			this.timeConnter.SetForward(1);
			this.timeConnter.SetLeftTime(0.01f, -1);
		}

		// Token: 0x06010357 RID: 66391 RVA: 0x003E6864 File Offset: 0x003E4A64
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

		// Token: 0x06010358 RID: 66392 RVA: 0x003E68DD File Offset: 0x003E4ADD
		private void UpdateLeftTime()
		{
			this.leftTimeCounter.Update();
		}

		// Token: 0x06010359 RID: 66393 RVA: 0x003E68EC File Offset: 0x003E4AEC
		private void UpdateTime()
		{
			this.timeConnter.Update();
		}

		// Token: 0x0601035A RID: 66394 RVA: 0x003E68FC File Offset: 0x003E4AFC
		public bool OnShowChatDlg(IXUIButton sp)
		{
			DlgBase<XChatView, XChatBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, this._onSwitchToTeamChatCb, null);
			return true;
		}

		// Token: 0x0601035B RID: 66395 RVA: 0x003E6933 File Offset: 0x003E4B33
		public void OnSwitchToTeamChat(object obj)
		{
			DlgBase<XChatView, XChatBehaviour>.singleton.SelectChatTeam();
		}

		// Token: 0x0601035C RID: 66396 RVA: 0x003E6944 File Offset: 0x003E4B44
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

		// Token: 0x0601035D RID: 66397 RVA: 0x003E6990 File Offset: 0x003E4B90
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

		// Token: 0x0601035E RID: 66398 RVA: 0x003E6A4C File Offset: 0x003E4C4C
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

		// Token: 0x0601035F RID: 66399 RVA: 0x003E6AA8 File Offset: 0x003E4CA8
		public bool OnCommandBtnClick(IXUIButton btn)
		{
			return true;
		}

		// Token: 0x06010360 RID: 66400 RVA: 0x003E6ABC File Offset: 0x003E4CBC
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

		// Token: 0x06010361 RID: 66401 RVA: 0x003E6B1C File Offset: 0x003E4D1C
		public void ShowBattleVoice(ChatVoiceInfo info)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.m_ChatLabelCd = XSingleton<XTimerMgr>.singleton.SetTimer((float)info.voiceTime + 2f, this._hideBattleChatUICb, info);
			}
		}

		// Token: 0x06010362 RID: 66402 RVA: 0x003E6B5D File Offset: 0x003E4D5D
		public void HideBattleChatUI(object info)
		{
			this.m_ChatLabelCd = 0U;
		}

		// Token: 0x06010363 RID: 66403 RVA: 0x003E6B68 File Offset: 0x003E4D68
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

		// Token: 0x06010364 RID: 66404 RVA: 0x003E6C2C File Offset: 0x003E4E2C
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

		// Token: 0x06010365 RID: 66405 RVA: 0x003E6C94 File Offset: 0x003E4E94
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

		// Token: 0x06010366 RID: 66406 RVA: 0x003E6CFC File Offset: 0x003E4EFC
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

		// Token: 0x06010367 RID: 66407 RVA: 0x003E6DA8 File Offset: 0x003E4FA8
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

		// Token: 0x06010368 RID: 66408 RVA: 0x003E6E24 File Offset: 0x003E5024
		public void ShowStrengthPresevedBar(XEntity entity)
		{
			base.uiBehaviour.m_StrengthPresevedBar.SetVisible(true);
			this._strength_preseved_entity = entity;
			this._total_strength_preseved = (float)this._strength_preseved_entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentXULI_Basic);
			this._current_strength_preseved = this._total_strength_preseved;
			this.RefreshStrengthPresevedBar();
		}

		// Token: 0x06010369 RID: 66409 RVA: 0x003E6E77 File Offset: 0x003E5077
		public void HideStrengthPresevedBar()
		{
			base.uiBehaviour.m_StrengthPresevedBar.SetVisible(false);
			this._strength_preseved_entity = null;
			this._total_strength_preseved = 1f;
			this._current_strength_preseved = 0f;
		}

		// Token: 0x0601036A RID: 66410 RVA: 0x003E6EA9 File Offset: 0x003E50A9
		public void RefreshStrengthPresevedBar()
		{
			this._current_strength_preseved = (float)this._strength_preseved_entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentXULI_Basic);
			base.uiBehaviour.m_StrengthPresevedBar.value = this._strength_preseved_precent;
		}

		// Token: 0x0601036B RID: 66411 RVA: 0x003E6EDC File Offset: 0x003E50DC
		public bool OnViewClick(IXUIButton sp)
		{
			this.SetView((XOperationMode)sp.ID);
			return true;
		}

		// Token: 0x0601036C RID: 66412 RVA: 0x003E6F00 File Offset: 0x003E5100
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

		// Token: 0x0601036D RID: 66413 RVA: 0x003E6F74 File Offset: 0x003E5174
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

		// Token: 0x0601036E RID: 66414 RVA: 0x003E756C File Offset: 0x003E576C
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

		// Token: 0x0601036F RID: 66415 RVA: 0x003E7A90 File Offset: 0x003E5C90
		public void ShowBackToMainCityTips()
		{
			string @string = XStringDefineProxy.GetString("ERR_WATCH_LIVEISOVER");
			string string2 = XStringDefineProxy.GetString("Spectate_Goon");
			string string3 = XStringDefineProxy.GetString("LEVEL_REWARD_RETURN");
			XSingleton<UiUtility>.singleton.ShowModalDialog(@string, string2, string3, new ButtonClickEventHandler(this.OnGoOnBtnClick), new ButtonClickEventHandler(this.OnBackToMainCityBtnClick), false, XTempTipDefine.OD_START, 251);
		}

		// Token: 0x06010370 RID: 66416 RVA: 0x003E7AEC File Offset: 0x003E5CEC
		private bool OnBackToMainCityBtnClick(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this._doc.LevelScene();
			return true;
		}

		// Token: 0x06010371 RID: 66417 RVA: 0x003E7B18 File Offset: 0x003E5D18
		private bool OnGoOnBtnClick(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			DlgBase<SpectateView, SpectateBehaviour>.singleton.SetVisible(true, true);
			return true;
		}

		// Token: 0x06010372 RID: 66418 RVA: 0x003E7B48 File Offset: 0x003E5D48
		public float GetLeftTime()
		{
			return this.leftTimeCounter.GetFloatLeftTime();
		}

		// Token: 0x0400742F RID: 29743
		public static uint _pool_size = 5U;

		// Token: 0x04007430 RID: 29744
		private XPlayerAttributes _attrComp = null;

		// Token: 0x04007431 RID: 29745
		private float NoticeTime = 0f;

		// Token: 0x04007432 RID: 29746
		private Color32 _hp_green = new Color32(46, 203, 0, byte.MaxValue);

		// Token: 0x04007433 RID: 29747
		private Color32 _hp_yellow = new Color32(byte.MaxValue, 249, 32, byte.MaxValue);

		// Token: 0x04007434 RID: 29748
		private Color32 _hp_red = new Color32(byte.MaxValue, 39, 39, byte.MaxValue);

		// Token: 0x04007435 RID: 29749
		private Vector2 m_DragDistance = Vector2.zero;

		// Token: 0x04007436 RID: 29750
		private bool m_CancelRecord = false;

		// Token: 0x04007437 RID: 29751
		private bool m_IsRecording = false;

		// Token: 0x04007438 RID: 29752
		private uint m_ChatLabelCd = 0U;

		// Token: 0x04007439 RID: 29753
		public XOptionsBattleHandler m_XOptionBattleHandler = null;

		// Token: 0x0400743A RID: 29754
		private BattleCaptainPVPHandler m_BattleCaptainPVPHandler = null;

		// Token: 0x0400743B RID: 29755
		public HeroBattleHandler _HeroBattleHandler = null;

		// Token: 0x0400743C RID: 29756
		private SceneType sceneType;

		// Token: 0x0400743D RID: 29757
		private XLeftTimeCounter leftTimeCounter;

		// Token: 0x0400743E RID: 29758
		private XLeftTimeCounter timeConnter;

		// Token: 0x0400743F RID: 29759
		private float _last_check_time = 0f;

		// Token: 0x04007440 RID: 29760
		private IPlatform _platform = null;

		// Token: 0x04007441 RID: 29761
		private List<string> _notice_collection = new List<string>();

		// Token: 0x04007442 RID: 29762
		private float _notice_duration = 0f;

		// Token: 0x04007443 RID: 29763
		private float _notice_pertime = 1f;

		// Token: 0x04007444 RID: 29764
		private List<ComboBuff> _combo_buff_list = new List<ComboBuff>();

		// Token: 0x04007445 RID: 29765
		private Vector2 _yuyin_init_pos = Vector2.zero;

		// Token: 0x04007446 RID: 29766
		private Vector2 _yuyin_offset = new Vector2(65f, 0f);

		// Token: 0x04007447 RID: 29767
		private XSpectateSceneDocument _doc;

		// Token: 0x04007448 RID: 29768
		private uint time_token = 0U;

		// Token: 0x04007449 RID: 29769
		private XEntity _strength_preseved_entity = null;

		// Token: 0x0400744A RID: 29770
		private float _total_strength_preseved = 1f;

		// Token: 0x0400744B RID: 29771
		private float _current_strength_preseved = 0f;

		// Token: 0x0400744C RID: 29772
		private XTimerMgr.ElapsedEventHandler _showSingleNoticeCb = null;

		// Token: 0x0400744D RID: 29773
		private XTimerMgr.ElapsedEventHandler _endBigNoticeCb = null;

		// Token: 0x0400744E RID: 29774
		private XTimerMgr.ElapsedEventHandler _onSwitchToTeamChatCb = null;

		// Token: 0x0400744F RID: 29775
		private XTimerMgr.ElapsedEventHandler _hideBattleChatUICb = null;

		// Token: 0x04007450 RID: 29776
		private float _fYellow = 0f;

		// Token: 0x04007451 RID: 29777
		private float _fRed = 0f;

		// Token: 0x04007452 RID: 29778
		private XSwitchSight m_SwitchSight;

		// Token: 0x04007453 RID: 29779
		public XYuyinView _yuyinHandler;

		// Token: 0x04007454 RID: 29780
		private float lastPingTime = -60f;

		// Token: 0x04007455 RID: 29781
		private GameObject _big_notice = null;
	}
}
