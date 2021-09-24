using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardActivityHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardActivityFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
		}

		private void InitUI()
		{
			this.m_ActivityNormalFrame = base.transform.FindChild("Normal");
			this.m_ActivityContinue = (base.transform.FindChild("Continue").GetComponent("XUISprite") as IXUISprite);
			this.m_ActivityRestart = (base.transform.Find("Restart").GetComponent("XUISprite") as IXUISprite);
			Transform transform = base.transform.FindChild("Normal/ItemList/ScrollView/Item");
			this.m_ActivityItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this.m_BrokeRecord = base.transform.FindChild("Normal/Detail/BrokeRecord");
			for (int i = 0; i < 3; i++)
			{
				this.m_ActivityMsg[i] = (base.transform.FindChild(string.Format("Normal/Detail/Msg{0}", i + 1)).GetComponent("XUILabel") as IXUILabel);
			}
			this.m_snapshot = (base.PanelObject.transform.Find("Snapshot/Snapshot").GetComponent("UIDummy") as IUIDummy);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_ActivityContinue.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnContinueClick));
			this.m_ActivityRestart.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRestartClick));
		}

		private void OnContinueClick(IXUISprite sp)
		{
			this._doc.SendLeaveScene();
		}

		private void OnRestartClick(IXUISprite sp)
		{
			this._doc.ReEnterLevel();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowActivityFrame();
		}

		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_show_time_token);
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
			base.OnHide();
		}

		public override void OnUnload()
		{
			XSingleton<X3DAvatarMgr>.singleton.OnUIUnloadMainDummy(this.m_snapshot);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_show_time_token);
			base.OnUnload();
		}

		public void ShowActivityFrame()
		{
			this.m_ActivityMsg[0].SetVisible(true);
			this.m_ActivityMsg[1].SetVisible(true);
			this.m_ActivityMsg[2].SetVisible(true);
			SceneType currentStage = this._doc.CurrentStage;
			if (currentStage == SceneType.SCENE_BOSSRUSH || currentStage == SceneType.SCENE_TOWER)
			{
				this.m_ActivityNormalFrame.gameObject.SetActive(true);
				this.m_ActivityItemPool.FakeReturnAll();
				for (int i = 0; i < this._doc.Items.Count; i++)
				{
					GameObject gameObject = this.m_ActivityItemPool.FetchGameObject(true);
					IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)this._doc.Items[i].itemID;
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)this._doc.Items[i].itemID, (int)this._doc.Items[i].itemCount, false);
					gameObject.transform.localPosition = new Vector3(this.m_ActivityItemPool.TplPos.x + (float)(i * this.m_ActivityItemPool.TplWidth), this.m_ActivityItemPool.TplPos.y);
					bool isbind = this._doc.Items[i].isbind;
					if (isbind)
					{
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnBindItemClick));
					}
					else
					{
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
					}
				}
				this.m_BrokeRecord.gameObject.SetActive(this._doc.BrokeRecords);
				this.m_ActivityRestart.SetVisible(false);
				XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, this.m_snapshot);
				float interval = XSingleton<X3DAvatarMgr>.singleton.SetMainAnimationGetLength(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.Disappear);
				this.m_show_time_token = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.KillDummyTimer), null);
				SceneType currentStage2 = this._doc.CurrentStage;
				if (currentStage2 != SceneType.SCENE_BOSSRUSH)
				{
					if (currentStage2 != SceneType.SCENE_TOWER)
					{
						this.m_ActivityMsg[0].SetText("");
						this.m_ActivityMsg[1].SetText(XStringDefineProxy.GetString("SMALLMONSTER_RANK", new object[]
						{
							this._doc.SmallMonsterRank
						}));
						this.m_ActivityMsg[2].SetText("");
						this.m_ActivityMsg[0].SetVisible(false);
						this.m_ActivityMsg[2].SetVisible(false);
					}
					else
					{
						SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
						string text = "";
						bool flag = sceneData != null;
						if (flag)
						{
							text = XStringDefineProxy.GetString("TOWER_PPT", new object[]
							{
								sceneData.RecommendPower
							});
						}
						this.m_ActivityMsg[0].SetText(XStringDefineProxy.GetString("TOWER_WAVE", new object[]
						{
							this._doc.TowerFloor
						}));
						this.m_ActivityMsg[1].SetText(text);
						this.m_ActivityMsg[2].SetText(XStringDefineProxy.GetString("TOWER_TIME", new object[]
						{
							XSingleton<UiUtility>.singleton.TimeFormatString(this._doc.LevelFinishTime, 2, 3, 4, false, true)
						}));
						this.m_ActivityRestart.SetVisible(true);
					}
				}
				else
				{
					XBossBushDocument xbossBushDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XBossBushDocument.uuID) as XBossBushDocument;
					UnitAppearance cacheServerMonster = XSingleton<XLevelSpawnMgr>.singleton.GetCacheServerMonster(1U);
					this.m_ActivityMsg[0].SetText(XStringDefineProxy.GetString("FINISH_WAVE", new object[]
					{
						Mathf.Min(DlgBase<BossRushDlg, BossRushBehavior>.singleton.isWin ? xbossBushDocument.respData.currank : (xbossBushDocument.respData.currank - 1), XSingleton<XGlobalConfig>.singleton.GetInt("BossRushMaxWave"))
					}));
					this.m_ActivityMsg[1].SetText(XStringDefineProxy.GetString("BOSSRUSH_NAME", new object[]
					{
						xbossBushDocument.entityRow.Name
					}));
					this.m_ActivityMsg[2].SetText("");
					this.m_ActivityMsg[2].SetVisible(false);
				}
				this.m_ActivityItemPool.ActualReturnAll(false);
			}
		}

		private void KillDummyTimer(object sender)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_show_time_token);
			XSingleton<X3DAvatarMgr>.singleton.SetMainAnimation(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.AttackIdle);
		}

		private XLevelRewardDocument _doc = null;

		private Transform m_ActivityNormalFrame;

		private XUIPool m_ActivityItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUISprite m_ActivityContinue;

		private IXUISprite m_ActivityRestart;

		private Transform m_BrokeRecord;

		private IXUILabel[] m_ActivityMsg = new IXUILabel[3];

		private IUIDummy m_snapshot;

		private uint m_show_time_token = 0U;
	}
}
