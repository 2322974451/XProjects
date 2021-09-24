using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardRiftHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardTeamMysterious";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this._rift_doc = XDocuments.GetSpecificDocument<XRiftDocument>(XRiftDocument.uuID);
			this.InitUI();
		}

		private void InitUI()
		{
			for (int i = 0; i < 3; i++)
			{
				this.m_level_req[i] = (base.PanelObject.transform.Find(string.Format("Bg/StarsReq/Req{0}/Tip", i + 1)).GetComponent("XUILabel") as IXUILabel);
				this.m_level_req_done[i] = (base.PanelObject.transform.Find(string.Format("Bg/StarsReq/Req{0}/Done", i + 1)).GetComponent("XUISprite") as IXUISprite);
				this.m_stars[i] = base.PanelObject.transform.Find(string.Format("Bg/Stars/Star{0}", i + 1));
				this.m_star_fx[i] = base.PanelObject.transform.Find(string.Format("Bg/Stars/Star{0}/Fx", i + 1));
			}
			this.m_star_tween = (base.PanelObject.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_star_frame = base.PanelObject.transform.Find("Bg/Stars");
			this.m_BrokeRecord = base.transform.FindChild("BrokeRecord");
			this.m_lblRift = (base.transform.FindChild("Bg/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_lblBtm = (base.transform.FindChild("Bg/SealTip").GetComponent("XUILabel") as IXUILabel);
			this.m_ActivityRestart = (base.transform.FindChild("Bg/Restart").GetComponent("XUISprite") as IXUISprite);
			this.m_ActivityReturn = (base.transform.Find("Bg/Return").GetComponent("XUISprite") as IXUISprite);
			Transform transform = base.transform.FindChild("Bg/ItemList/ScrollView/Item");
			this.m_ActivityItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			this.m_snapshot = (base.PanelObject.transform.Find("Bg/Snapshot/Snapshot").GetComponent("UIDummy") as IUIDummy);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_ActivityRestart.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRestartClick));
			this.m_ActivityReturn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReturnClick));
		}

		private void OnRestartClick(IXUISprite sp)
		{
			bool flag = !this._doc.IsEndLevel;
			if (flag)
			{
				base.SetVisible(false);
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetVisiblePure(true);
				}
				string sceneBGM = XSingleton<XSceneMgr>.singleton.GetSceneBGM(XSingleton<XScene>.singleton.SceneID);
				XSingleton<XAudioMgr>.singleton.PlayBGM(sceneBGM);
				DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.SetFakeHide(false);
			}
			else
			{
				this._doc.SendLeaveScene();
			}
		}

		private void OnReturnClick(IXUISprite sp)
		{
			this._doc.SendLeaveScene();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowRiftFrame();
			this.ShowStarReq();
			bool flag = this._rift_doc != null;
			if (flag)
			{
				this._rift_doc.stop_timer = true;
			}
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

		public void ShowRiftFrame()
		{
			bool flag = this._doc.CurrentStage == SceneType.SCENE_RIFT;
			if (flag)
			{
				uint rank = this._doc.GerenalBattleData.Rank;
				this.m_BrokeRecord.gameObject.SetActive(this._doc.BrokeRecords);
				for (int i = 0; i < 3; i++)
				{
					bool flag2 = (long)i < (long)((ulong)rank);
					if (flag2)
					{
						this.m_stars[i].gameObject.SetActive(true);
						this.m_star_tween.SetTweenGroup(i + 1);
						this.m_star_tween.PlayTween(true, -1f);
						this.m_star_fx[i].gameObject.SetActive((long)i == (long)((ulong)(rank - 1U)));
					}
					else
					{
						this.m_stars[i].gameObject.SetActive(false);
						this.m_star_fx[i].gameObject.SetActive(false);
					}
				}
				this.m_star_frame.localPosition -= new Vector3(this.m_stars[0].localPosition.x * (3U - rank) / 2f, 0f);
				for (int j = 0; j < 3; j++)
				{
					this.m_level_req[j].SetVisible(false);
					this.m_level_req_done[j].SetVisible(false);
				}
				bool flag3 = this._doc.RiftResult.riftItemFlag == 1U;
				if (flag3)
				{
					this.m_lblBtm.SetText(XStringDefineProxy.GetString("ERR_RIFT_REWARD_TOGET"));
				}
				else
				{
					bool flag4 = this._doc.RiftResult.riftItemFlag == 2U;
					if (flag4)
					{
						this.m_lblBtm.SetText(XStringDefineProxy.GetString("ERR_RIFT_REWARD_TOGET"));
					}
					else
					{
						bool flag5 = this._doc.RiftResult.riftItemFlag == 3U;
						if (flag5)
						{
							this.m_lblBtm.SetText(XStringDefineProxy.GetString("ERR_RIFT_CREATER_LEAVE"));
						}
						else
						{
							this.m_lblBtm.SetText(XStringDefineProxy.GetString("ERR_RIFT_PASSAGAIN"));
						}
					}
				}
				int num = -2;
				int num2 = -1;
				bool flag6 = this._doc.RiftResult.riftFloor == (uint)num;
				if (flag6)
				{
					this.m_lblRift.SetText(XStringDefineProxy.GetString("ERR_RIFT_CREATER_LEAVE_CANNOT_LEVELUP"));
					this.m_ActivityRestart.SetVisible(true);
				}
				else
				{
					bool flag7 = this._doc.RiftResult.riftFloor == (uint)num2;
					if (flag7)
					{
						this.m_lblRift.SetText(XStringDefineProxy.GetString("ERR_RIFT_LEVELMAX"));
						this.m_ActivityRestart.SetVisible(false);
					}
					else
					{
						this.m_lblRift.SetText(XStringDefineProxy.GetString("ERR_RIFT_LEVELUP", new object[]
						{
							this._doc.RiftResult.riftFloor
						}));
						this.m_ActivityRestart.SetVisible(true);
					}
				}
				this.m_ActivityItemPool.FakeReturnAll();
				for (int k = 0; k < this._doc.Items.Count; k++)
				{
					GameObject gameObject = this.m_ActivityItemPool.FetchGameObject(true);
					IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)this._doc.Items[k].itemID;
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)this._doc.Items[k].itemID, (int)this._doc.Items[k].itemCount, false);
					gameObject.transform.localPosition = new Vector3(this.m_ActivityItemPool.TplPos.x + (float)(k * this.m_ActivityItemPool.TplWidth), this.m_ActivityItemPool.TplPos.y);
					bool isbind = this._doc.Items[k].isbind;
					if (isbind)
					{
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnBindItemClick));
					}
					else
					{
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
					}
				}
				XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, this.m_snapshot);
				float interval = XSingleton<X3DAvatarMgr>.singleton.SetMainAnimationGetLength(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.Disappear);
				this.m_show_time_token = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.KillDummyTimer), null);
				this.m_ActivityItemPool.ActualReturnAll(false);
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("error stage:" + this._doc.CurrentStage, null, null, null, null, null);
			}
		}

		private void KillDummyTimer(object sender)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_show_time_token);
			XSingleton<X3DAvatarMgr>.singleton.SetMainAnimation(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.AttackIdle);
		}

		private void ShowStarReq()
		{
			int num = 0;
			for (int i = 0; i < XLevelRewardDocument.Table.Table.Length; i++)
			{
				bool flag = XLevelRewardDocument.Table.Table[i].scendid == this._doc.CurrentScene;
				if (flag)
				{
					num = i;
					break;
				}
			}
			this.m_level_req[0].SetVisible(true);
			this.m_level_req[1].SetVisible(true);
			this.m_level_req[2].SetVisible(true);
			this.m_level_req[1].SetText(LevelRewardGerenalHandler.GetReqText(XLevelRewardDocument.Table.Table[num], 1));
			this.m_level_req[2].SetText(LevelRewardGerenalHandler.GetReqText(XLevelRewardDocument.Table.Table[num], 2));
			int num2 = 0;
			while (num2 < this._doc.GerenalBattleData.Stars.Count && num2 < 3)
			{
				bool flag2 = this._doc.GerenalBattleData.Stars[num2] == 1U;
				if (flag2)
				{
					this.m_level_req_done[num2].SetVisible(true);
				}
				else
				{
					this.m_level_req_done[num2].SetVisible(false);
				}
				num2++;
			}
		}

		private XLevelRewardDocument _doc = null;

		private XRiftDocument _rift_doc = null;

		private IXUILabel[] m_level_req = new IXUILabel[3];

		private IXUISprite[] m_level_req_done = new IXUISprite[3];

		private Transform m_star_frame;

		private Transform[] m_stars = new Transform[3];

		private IXUITweenTool m_star_tween;

		private Transform[] m_star_fx = new Transform[3];

		private XUIPool m_ActivityItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUISprite m_ActivityRestart;

		private IXUISprite m_ActivityReturn;

		private IXUILabel m_lblRift;

		private IXUILabel m_lblBtm;

		private IUIDummy m_snapshot;

		private Transform m_BrokeRecord;

		private uint m_show_time_token = 0U;
	}
}
