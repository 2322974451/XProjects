using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001740 RID: 5952
	internal class XTeamLeagueBattlePrepareView : DlgBase<XTeamLeagueBattlePrepareView, XTeamLeagueBattlePrepareBehaviour>
	{
		// Token: 0x170037E3 RID: 14307
		// (get) Token: 0x0600F615 RID: 62997 RVA: 0x0037BA6C File Offset: 0x00379C6C
		public override string fileName
		{
			get
			{
				return "Battle/TeamLeagueBattleDlg";
			}
		}

		// Token: 0x170037E4 RID: 14308
		// (get) Token: 0x0600F616 RID: 62998 RVA: 0x0037BA84 File Offset: 0x00379C84
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170037E5 RID: 14309
		// (get) Token: 0x0600F617 RID: 62999 RVA: 0x0037BA98 File Offset: 0x00379C98
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F618 RID: 63000 RVA: 0x0037BAAB File Offset: 0x00379CAB
		protected override void Init()
		{
			base.Init();
			this._BattleDoc = XDocuments.GetSpecificDocument<XTeamLeagueBattleDocument>(XTeamLeagueBattleDocument.uuID);
			this._BaseDoc = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
		}

		// Token: 0x0600F619 RID: 63001 RVA: 0x0037BAD8 File Offset: 0x00379CD8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_UpBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnUp));
			base.uiBehaviour.m_DownBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnDown));
			base.uiBehaviour.m_BlueViewSwitch.ID = 0UL;
			base.uiBehaviour.m_BlueViewSwitch.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnLeftToogle));
			base.uiBehaviour.m_RedViewSwitch.ID = 0UL;
			base.uiBehaviour.m_RedViewSwitch.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRightToogle));
		}

		// Token: 0x0600F61A RID: 63002 RVA: 0x0037BB87 File Offset: 0x00379D87
		private void OnUp(IXUISprite btn)
		{
			this._BattleDoc.ReqBattle(LeagueBattleReadyOper.LBReady_Up);
		}

		// Token: 0x0600F61B RID: 63003 RVA: 0x0037BB97 File Offset: 0x00379D97
		private void OnDown(IXUISprite btn)
		{
			this._BattleDoc.ReqBattle(LeagueBattleReadyOper.LBReady_Down);
		}

		// Token: 0x0600F61C RID: 63004 RVA: 0x0037BBA8 File Offset: 0x00379DA8
		private void OnLeftToogle(IXUISprite btn)
		{
			int num = (int)btn.ID;
			base.uiBehaviour.m_BlueViewTween.SetTweenGroup(num);
			base.uiBehaviour.m_BlueViewTween.PlayTween(true, -1f);
			base.uiBehaviour.m_UpDownTween.SetTweenGroup(num);
			base.uiBehaviour.m_UpDownTween.PlayTween(true, -1f);
			btn.ID = (ulong)((num == 0) ? 1L : 0L);
		}

		// Token: 0x0600F61D RID: 63005 RVA: 0x0037BC20 File Offset: 0x00379E20
		private void OnRightToogle(IXUISprite btn)
		{
			int num = (int)btn.ID;
			base.uiBehaviour.m_RedViewTween.SetTweenGroup(num);
			base.uiBehaviour.m_RedViewTween.PlayTween(true, -1f);
			btn.ID = (ulong)((num == 0) ? 1L : 0L);
		}

		// Token: 0x0600F61E RID: 63006 RVA: 0x0037BC6E File Offset: 0x00379E6E
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshTeamName();
		}

		// Token: 0x0600F61F RID: 63007 RVA: 0x0037BC80 File Offset: 0x00379E80
		private void RefreshTeamName()
		{
			bool flag = this._BattleDoc.LoadingInfoBlue != null;
			if (flag)
			{
				IXUILabel ixuilabel = base.uiBehaviour.m_BlueView.Find("Title1").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(this._BattleDoc.LoadingInfoBlue.name);
			}
			bool flag2 = this._BattleDoc.LoadingInfoRed != null;
			if (flag2)
			{
				IXUILabel ixuilabel2 = base.uiBehaviour.m_RedView.Find("Title1").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(this._BattleDoc.LoadingInfoRed.name);
			}
		}

		// Token: 0x0600F620 RID: 63008 RVA: 0x0037BD2E File Offset: 0x00379F2E
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600F621 RID: 63009 RVA: 0x0037BD38 File Offset: 0x00379F38
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<LevelRewardTeamLeagueSmallHandler>(ref this.SmallRewardHandler);
			DlgHandlerBase.EnsureUnload<LevelRewardTeamLeagueBigHandler>(ref this.BigRewardHandler);
			base.OnUnload();
		}

		// Token: 0x0600F622 RID: 63010 RVA: 0x0037BD5C File Offset: 0x00379F5C
		public void ResetCommonUI(bool show = true)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.SetVisible(show);
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.SetVisible(show);
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.LeftTimeLabel.SetVisible(show);
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.SetVisible(false);
			}
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (bSpectator)
			{
				bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.LeftTime.SetVisible(show);
				}
			}
		}

		// Token: 0x0600F623 RID: 63011 RVA: 0x0037BE00 File Offset: 0x0037A000
		private void RefreshKillInfo()
		{
			IXUILabel ixuilabel = base.uiBehaviour.m_BlueInfo.FindChild("Kill").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = base.uiBehaviour.m_RedInfo.FindChild("Kill").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = base.uiBehaviour.m_BlueInfo.FindChild("Damage").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel4 = base.uiBehaviour.m_RedInfo.FindChild("Damage").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(this._BattleDoc.BlueCanBattleNum.ToString());
			ixuilabel2.SetText(this._BattleDoc.RedCanBattleNum.ToString());
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(this._BattleDoc.BluePKingRoleID);
			XEntity entity2 = XSingleton<XEntityMgr>.singleton.GetEntity(this._BattleDoc.RedPKingRoleID);
			bool flag = entity != null;
			if (flag)
			{
				double attr = entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
				double attr2 = entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
				double num = (attr == 0.0) ? 0.0 : (attr2 / attr);
				ixuilabel3.SetText(string.Format("{0:N2}%", num * 100.0));
			}
			else
			{
				ixuilabel4.SetText("0%");
			}
			bool flag2 = entity2 != null;
			if (flag2)
			{
				double attr3 = entity2.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
				double attr4 = entity2.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
				double num2 = (attr3 == 0.0) ? 0.0 : (attr4 / attr3);
				ixuilabel4.SetText(string.Format("{0:N2}%", num2 * 100.0));
			}
			else
			{
				ixuilabel4.SetText("0%");
			}
		}

		// Token: 0x0600F624 RID: 63012 RVA: 0x0037C000 File Offset: 0x0037A200
		public void RefreshBattleBaseInfo()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.SetBattleList(base.uiBehaviour.m_BlueView, this._BattleDoc.BattleBaseInfoBlue, 0);
				this.SetBattleList(base.uiBehaviour.m_RedView, this._BattleDoc.BattleBaseInfoRed, 1);
				this.RefreshKillInfo();
			}
		}

		// Token: 0x0600F625 RID: 63013 RVA: 0x0037C060 File Offset: 0x0037A260
		private void SetBattleList(Transform view, LeagueBattleOneTeam battleTeamBaseInfo, int index)
		{
			bool flag = battleTeamBaseInfo == null;
			if (!flag)
			{
				IXUILabel ixuilabel = view.Find("Title1").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(battleTeamBaseInfo.name);
				base.uiBehaviour.m_MemberPool[index].FakeReturnAll();
				for (int i = 0; i < battleTeamBaseInfo.members.Count; i++)
				{
					GameObject gameObject = base.uiBehaviour.m_MemberPool[index].FetchGameObject(false);
					gameObject.transform.parent = base.uiBehaviour.m_MemberList[index].gameObject.transform;
					IXUILabel ixuilabel2 = gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel3 = gameObject.transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
					Transform transform = gameObject.transform.Find("Battle");
					Transform transform2 = gameObject.transform.Find("Die");
					ixuilabel2.SetText(battleTeamBaseInfo.members[i].basedata.name);
					ixuilabel3.SetText(battleTeamBaseInfo.members[i].index.ToString());
					transform.gameObject.SetActive(battleTeamBaseInfo.members[i].state == LeagueBattleRoleState.LBRoleState_Fighting);
					transform2.gameObject.SetActive(battleTeamBaseInfo.members[i].state == LeagueBattleRoleState.LBRoleState_Failed);
					ixuilabel3.gameObject.SetActive(battleTeamBaseInfo.members[i].state != LeagueBattleRoleState.LBRoleState_Failed && battleTeamBaseInfo.members[i].state != LeagueBattleRoleState.LBRoleState_Fighting);
					ixuilabel2.SetColor(Color.white);
					bool flag2 = battleTeamBaseInfo.members[i].basedata.roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag2)
					{
						ixuilabel2.SetText(string.Format("[{0}]{1}[-]", XSingleton<XGlobalConfig>.singleton.GetValue("PKSelfNameColor"), battleTeamBaseInfo.members[i].basedata.name));
					}
					bool flag3 = battleTeamBaseInfo.members[i].state == LeagueBattleRoleState.LBRoleState_Failed;
					if (flag3)
					{
						ixuilabel2.SetColor(Color.gray);
					}
				}
				base.uiBehaviour.m_MemberPool[index].ActualReturnAll(false);
				base.uiBehaviour.m_MemberList[index].Refresh();
			}
		}

		// Token: 0x0600F626 RID: 63014 RVA: 0x0037C2F4 File Offset: 0x0037A4F4
		public void RefreshBattleState()
		{
			LeagueBattleFightState battleState = this._BattleDoc.BattleState;
			if (battleState != LeagueBattleFightState.LBFight_Wait)
			{
				if (battleState == LeagueBattleFightState.LBFight_Fight)
				{
					base.uiBehaviour.m_Info.SetActive(true);
					base.uiBehaviour.m_LeftTimeTip.gameObject.SetActive(false);
					base.uiBehaviour.m_ListView.SetActive(this._BattleDoc.IsInTeamLeague);
					bool flag = this._BattleDoc.IsInTeamLeague && this._BattleDoc.IsInBattleTeamLeague && this._BattleDoc.SelfBattleState == LeagueBattleRoleState.LBRoleState_Fighting;
					if (flag)
					{
						base.uiBehaviour.m_BlueView.gameObject.SetActive(true);
						base.uiBehaviour.m_RedView.gameObject.SetActive(false);
						base.uiBehaviour.m_UpBtn.gameObject.SetActive(false);
						base.uiBehaviour.m_DownBtn.gameObject.SetActive(false);
					}
					else
					{
						bool isInTeamLeague = this._BattleDoc.IsInTeamLeague;
						if (isInTeamLeague)
						{
							base.uiBehaviour.m_BlueView.gameObject.SetActive(true);
							base.uiBehaviour.m_RedView.gameObject.SetActive(false);
							base.uiBehaviour.m_UpBtn.gameObject.SetActive(!this._BattleDoc.IsInBattleTeamLeague);
							base.uiBehaviour.m_DownBtn.gameObject.SetActive(this._BattleDoc.IsInBattleTeamLeague);
						}
						else
						{
							base.uiBehaviour.m_BlueView.gameObject.SetActive(false);
							base.uiBehaviour.m_RedView.gameObject.SetActive(false);
							base.uiBehaviour.m_UpBtn.gameObject.SetActive(false);
							base.uiBehaviour.m_DownBtn.gameObject.SetActive(false);
						}
					}
				}
			}
			else
			{
				base.uiBehaviour.m_Info.SetActive(false);
				base.uiBehaviour.m_LeftTimeTip.gameObject.SetActive(true);
				base.uiBehaviour.m_LeftTimeTip.SetText(XSingleton<XStringTable>.singleton.GetString("GUILD_ARENA_READY"));
				base.uiBehaviour.m_ListView.SetActive(this._BattleDoc.IsInTeamLeague);
				base.uiBehaviour.m_BlueView.gameObject.SetActive(true);
				base.uiBehaviour.m_RedView.gameObject.SetActive(false);
				bool flag2 = this._BattleDoc.IsInTeamLeague && this._BattleDoc.IsInBattleTeamLeague;
				if (flag2)
				{
					base.uiBehaviour.m_UpBtn.gameObject.SetActive(false);
					base.uiBehaviour.m_DownBtn.gameObject.SetActive(true);
				}
				else
				{
					bool flag3 = this._BattleDoc.IsInTeamLeague && !this._BattleDoc.IsInBattleTeamLeague;
					if (flag3)
					{
						base.uiBehaviour.m_UpBtn.gameObject.SetActive(true);
						base.uiBehaviour.m_DownBtn.gameObject.SetActive(false);
					}
					else
					{
						base.uiBehaviour.m_UpBtn.gameObject.SetActive(false);
						base.uiBehaviour.m_DownBtn.gameObject.SetActive(false);
					}
				}
			}
		}

		// Token: 0x0600F627 RID: 63015 RVA: 0x0037C654 File Offset: 0x0037A854
		public void RefreahCountTime(uint time)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime(time, -1);
			}
			bool flag2 = XSingleton<XScene>.singleton.bSpectator && DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag2)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetLeftTime(time);
			}
		}

		// Token: 0x0600F628 RID: 63016 RVA: 0x0037C6B7 File Offset: 0x0037A8B7
		public override void OnUpdate()
		{
			this.RefreshKillInfo();
		}

		// Token: 0x0600F629 RID: 63017 RVA: 0x0037C6C4 File Offset: 0x0037A8C4
		public void PlaySmallReward(LeagueBattleOneResultNtf data)
		{
			bool flag = this.SmallRewardHandler == null;
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgHandlerBase.EnsureCreate<LevelRewardTeamLeagueSmallHandler>(ref this.SmallRewardHandler, DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_canvas, true, this);
				}
				bool flag3 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag3)
				{
					DlgHandlerBase.EnsureCreate<LevelRewardTeamLeagueSmallHandler>(ref this.SmallRewardHandler, DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.uiBehaviour.m_canvas, true, this);
				}
			}
			bool flag4 = this.SmallRewardHandler != null;
			if (flag4)
			{
				this.SmallRewardHandler.SetRewardData(data);
			}
		}

		// Token: 0x0600F62A RID: 63018 RVA: 0x0037C754 File Offset: 0x0037A954
		public void PlayBigReward(LeagueBattleResultNtf data)
		{
			this.CloseSmallReward();
			bool flag = this.BigRewardHandler == null;
			if (flag)
			{
				bool flag2 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgHandlerBase.EnsureCreate<LevelRewardTeamLeagueBigHandler>(ref this.BigRewardHandler, DlgBase<BattleMain, BattleMainBehaviour>.singleton.uiBehaviour.m_canvas, true, this);
				}
				bool flag3 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag3)
				{
					DlgHandlerBase.EnsureCreate<LevelRewardTeamLeagueBigHandler>(ref this.BigRewardHandler, DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.uiBehaviour.m_canvas, true, this);
				}
			}
			bool flag4 = this.BigRewardHandler != null;
			if (flag4)
			{
				this.BigRewardHandler.SetRewardData(data);
			}
		}

		// Token: 0x0600F62B RID: 63019 RVA: 0x0037C7E8 File Offset: 0x0037A9E8
		public void CloseSmallReward()
		{
			bool flag = this.SmallRewardHandler != null;
			if (flag)
			{
				this.SmallRewardHandler.CloseTween();
			}
		}

		// Token: 0x04006AC6 RID: 27334
		private XTeamLeagueBattleDocument _BattleDoc;

		// Token: 0x04006AC7 RID: 27335
		private XFreeTeamVersusLeagueDocument _BaseDoc;

		// Token: 0x04006AC8 RID: 27336
		public LevelRewardTeamLeagueSmallHandler SmallRewardHandler = null;

		// Token: 0x04006AC9 RID: 27337
		public LevelRewardTeamLeagueBigHandler BigRewardHandler = null;
	}
}
