using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001891 RID: 6289
	internal class BattleWorldBossHandler : DlgHandlerBase, IWorldBossBattleView
	{
		// Token: 0x060105DC RID: 67036 RVA: 0x003FB95C File Offset: 0x003F9B5C
		protected override void Init()
		{
			base.Init();
			this._DamageRankBtn = (base.PanelObject.transform.FindChild("DamageRankBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_encourageInfos = new EncourageShowInfo[2];
			this.m_encourageInfos[0] = new EncourageShowInfo(base.PanelObject.transform.FindChild("EncourageBtn0"), base.PanelObject.transform.FindChild("GuildBossbuff"), 0);
			this.m_encourageInfos[1] = new EncourageShowInfo(base.PanelObject.transform.FindChild("EncourageBtn1"), base.PanelObject.transform.FindChild("GuildBossbuff1"), 1);
			this._EncouragePanel = base.PanelObject.transform.FindChild("EncourageMenu").gameObject;
			this._DoEncourage = (this._EncouragePanel.transform.FindChild("Do").GetComponent("XUIButton") as IXUIButton);
			this._EncourageClose = (this._EncouragePanel.transform.FindChild("Close").GetComponent("XUISprite") as IXUISprite);
			this._CurrentEncourageEffect = (this._EncouragePanel.transform.FindChild("CurrentEffect").GetComponent("XUILabel") as IXUILabel);
			this._CurrentEncourageEffectTween = (this._EncouragePanel.transform.FindChild("CurrentEffect").GetComponent("XUIPlayTween") as IXUITweenTool);
			this._CurrentEncourageTitle = (this._EncouragePanel.transform.FindChild("CurrentTitle").GetComponent("XUILabel") as IXUILabel);
			this._CurrentEncourageType = (this._EncouragePanel.transform.FindChild("CurrentType").GetComponent("XUILabel") as IXUILabel);
			this._EncourageEffect = (this._EncouragePanel.transform.FindChild("Effect").GetComponent("XUILabel") as IXUILabel);
			this._EncourageMoneyCost = (this._EncouragePanel.transform.FindChild("Do/MoneyCost").GetComponent("XUILabel") as IXUILabel);
			this._RankPanel = base.PanelObject.transform.FindChild("WorldBossRankPanel").gameObject;
			this._AutoRevivePanel = base.PanelObject.transform.FindChild("AutoRevivePanel").gameObject;
			this._AutoReviveLeftTime = (this._AutoRevivePanel.transform.FindChild("LeftTime").GetComponent("XUILabel") as IXUILabel);
			this._ReviveCost = (this._AutoRevivePanel.transform.FindChild("DoRightnow/MoneyCost").GetComponent("XUILabel") as IXUILabel);
			this._ReviveCostIcon = (this._AutoRevivePanel.transform.FindChild("DoRightnow/MoneyCost/Icon").GetComponent("XUISprite") as IXUISprite);
			this._DoRevive = (this._AutoRevivePanel.transform.FindChild("DoRightnow").GetComponent("XUIButton") as IXUIButton);
			this.m_EncourageFrameTween = (this._EncouragePanel.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_RankFrameTween = (this._RankPanel.GetComponent("XUIPlayTween") as IXUITweenTool);
			DlgHandlerBase.EnsureCreate<XWorldBossDamageRankHandler>(ref this._RankHandler, this._RankPanel, null, true);
			this._EncouragePanel.SetActive(false);
			this._AutoRevivePanel.SetActive(false);
			this._RankHandler.SetVisible(false);
			this._SetupRank();
		}

		// Token: 0x060105DD RID: 67037 RVA: 0x003FBCE8 File Offset: 0x003F9EE8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			for (int i = 0; i < this.m_encourageInfos.Length; i++)
			{
				this.m_encourageInfos[i].RegisterCourageClick(new ButtonClickEventHandler(this._OnEncouragePanelClicked));
			}
			this._DamageRankBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnDamageRankClicked));
			this._DoEncourage.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnEncourageDoClicked));
			this._EncourageClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnEncourageCloseClicked));
			this._DoRevive.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnReviveDoClicked));
			this.m_RankFrameTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this._OnTweenFinishEventHandler));
		}

		// Token: 0x060105DE RID: 67038 RVA: 0x003FBDA8 File Offset: 0x003F9FA8
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this._RankHandler != null && this._RankHandler.active;
			if (flag)
			{
				this._RankHandler.OnUpdate();
			}
			bool activeInHierarchy = this._AutoRevivePanel.activeInHierarchy;
			if (activeInHierarchy)
			{
				this.m_AutoReviveLeftTime.Update();
				int num = (int)this.m_AutoReviveLeftTime.LeftTime;
				bool flag2 = num != this.m_nAutoReviveLeftTime;
				if (flag2)
				{
					this.m_nAutoReviveLeftTime = num;
					this._AutoReviveLeftTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString(this.m_nAutoReviveLeftTime, 2, 3, 4, false, true));
				}
			}
		}

		// Token: 0x060105DF RID: 67039 RVA: 0x003FBE48 File Offset: 0x003FA048
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XWorldBossDamageRankHandler>(ref this._RankHandler);
			for (int i = 0; i < this.m_encourageInfos.Length; i++)
			{
				bool flag = this.m_encourageInfos[i] != null;
				if (flag)
				{
					this.m_encourageInfos[i].OnDispose();
				}
				this.m_encourageInfos[i] = null;
			}
			this.m_encourageInfos = null;
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			SceneType sceneType2 = sceneType;
			if (sceneType2 != SceneType.SCENE_WORLDBOSS)
			{
				if (sceneType2 == SceneType.SCENE_GUILD_BOSS)
				{
					XGuildDragonDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
					specificDocument.BattleHandler = null;
				}
			}
			else
			{
				XWorldBossDocument specificDocument2 = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
				specificDocument2.BattleHandler = null;
			}
			this.BattleSource = null;
			bool flag2 = this._LeaveSceneToken > 0U;
			if (flag2)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._LeaveSceneToken);
				this._LeaveSceneToken = 0U;
			}
			base.OnUnload();
		}

		// Token: 0x060105E0 RID: 67040 RVA: 0x003FBF30 File Offset: 0x003FA130
		private void _SetupRank()
		{
			List<RankeType> list = new List<RankeType>();
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			SceneType sceneType2 = sceneType;
			if (sceneType2 != SceneType.SCENE_WORLDBOSS)
			{
				if (sceneType2 == SceneType.SCENE_GUILD_BOSS)
				{
					XGuildDragonDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
					this.BattleSource = specificDocument;
					this._RankHandler.RankSource = specificDocument;
					specificDocument.BattleHandler = this;
					specificDocument.RankHandler = this._RankHandler;
					list.Add(RankeType.GuildBossRoleRank);
					this.m_encourageInfos[0].Valid = true;
					this.m_encourageInfos[0].attr_string = "GuildBossAddAttr";
					this.m_encourageInfos[0].cost_string = "GuildBossConsume";
					this.m_encourageInfos[0].encourage_type = "GUILDBOSS_ENCOURAGE_TYPE";
					this.m_encourageInfos[0].encourage_title = "GUILDBOSS_ENCOURAGE_TITLE";
					this.m_encourageInfos[0].encourage_effect = "GUILDBOSS_ENCOURAGE_EFFECT";
					this.m_encourageInfos[0].BattleSource = specificDocument;
					this.m_encourageInfos[0].ReqEncourage = new Action(specificDocument.ReqEncourage);
					this.m_encourageInfos[1].Valid = false;
				}
			}
			else
			{
				XWorldBossDocument specificDocument2 = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
				this.BattleSource = specificDocument2;
				this._RankHandler.RankSource = specificDocument2;
				specificDocument2.BattleHandler = this;
				specificDocument2.RankHandler = this._RankHandler;
				list.Add(RankeType.WorldBossDamageRank);
				list.Add(RankeType.WorldBossGuildRank);
				this.m_encourageInfos[0].Valid = true;
				this.m_encourageInfos[0].attr_string = "WorldBossAddAttr";
				this.m_encourageInfos[0].cost_string = "WorldBossConsume";
				this.m_encourageInfos[0].encourage_type = "WORLDBOSS_ENCOURAGE_TYPE";
				this.m_encourageInfos[0].encourage_title = "WORLDBOSS_ENCOURAGE_TITLE";
				this.m_encourageInfos[0].encourage_effect = "WORLDBOSS_ENCOURAGE_EFFECT";
				this.m_encourageInfos[0].ReqEncourage = new Action(specificDocument2.ReqEncourage);
				this.m_encourageInfos[0].BattleSource = specificDocument2;
				XGuildDocument specificDocument3 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				bool bInGuild = specificDocument3.bInGuild;
				if (bInGuild)
				{
					this.m_encourageInfos[1].Valid = true;
					this.m_encourageInfos[1].attr_string = "WorldBossGuildAddAttr";
					this.m_encourageInfos[1].cost_string = "WorldBossGuildConsume";
					this.m_encourageInfos[1].encourage_type = "GUILDBOSS_ENCOURAGE_TYPE";
					this.m_encourageInfos[1].encourage_title = "GUILDBOSS_ENCOURAGE_TITLE";
					this.m_encourageInfos[1].encourage_effect = "GUILDBOSS_ENCOURAGE_EFFECT";
					this.m_encourageInfos[1].ReqEncourage = new Action(specificDocument2.ReqEncourageTwo);
					this.m_encourageInfos[1].BattleSource = specificDocument2;
					list.Add(RankeType.WorldBossGuildRoleRank);
				}
				else
				{
					this.m_encourageInfos[1].Valid = false;
				}
			}
			this._RankHandler.SetupRanks(list, true);
		}

		// Token: 0x060105E1 RID: 67041 RVA: 0x003FC1FC File Offset: 0x003FA3FC
		protected override void OnShow()
		{
			base.OnShow();
			this.ReqBattleInfo();
			this._OnDamageRankClicked(this._DamageRankBtn);
		}

		// Token: 0x060105E2 RID: 67042 RVA: 0x003FC21C File Offset: 0x003FA41C
		private void ReqBattleInfo()
		{
			this.BattleSource.ReqBattleInfo();
			XSingleton<XTimerMgr>.singleton.KillTimer(this._GetBattleInfoToken);
			this._GetBattleInfoToken = XSingleton<XTimerMgr>.singleton.SetTimer(10f, new XTimerMgr.ElapsedEventHandler(this.ReqBattleInfoTimer), null);
		}

		// Token: 0x060105E3 RID: 67043 RVA: 0x003FC269 File Offset: 0x003FA469
		private void ReqBattleInfoTimer(object o)
		{
			this.ReqBattleInfo();
		}

		// Token: 0x060105E4 RID: 67044 RVA: 0x003FC274 File Offset: 0x003FA474
		protected override void OnHide()
		{
			bool flag = this._LeaveSceneToken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._LeaveSceneToken);
				this._LeaveSceneToken = 0U;
			}
			base.OnHide();
		}

		// Token: 0x060105E5 RID: 67045 RVA: 0x003FC2B0 File Offset: 0x003FA4B0
		public void RefreshAllEnacourage()
		{
			bool flag = this.m_encourageInfos == null;
			if (!flag)
			{
				int i = 0;
				int num = this.m_encourageInfos.Length;
				while (i < num)
				{
					EncourageShowInfo encourageShowInfo = this.m_encourageInfos[i];
					bool flag2 = encourageShowInfo == null || !encourageShowInfo.Valid;
					if (flag2)
					{
						break;
					}
					this.RefreshEncourage(i);
					i++;
				}
			}
		}

		// Token: 0x060105E6 RID: 67046 RVA: 0x003FC312 File Offset: 0x003FA512
		public void RefreshEncourage()
		{
			this.RefreshEncourage(this._SelectIndex);
		}

		// Token: 0x060105E7 RID: 67047 RVA: 0x003FC324 File Offset: 0x003FA524
		public void RefreshEncourage(int index)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				EncourageShowInfo encourageShowInfo = this.m_encourageInfos[index];
				bool flag2 = encourageShowInfo == null || !encourageShowInfo.Valid;
				if (!flag2)
				{
					string[] array = XSingleton<XGlobalConfig>.singleton.GetValue(encourageShowInfo.attr_string).Split(XGlobalConfig.ListSeparator);
					string[] array2 = array[0].Split(XGlobalConfig.SequenceSeparator);
					int num = int.Parse(array2[1]);
					encourageShowInfo.SetEncourageValue(num);
					bool flag3 = index == this._SelectIndex;
					if (flag3)
					{
						this._EncourageEffect.SetText(XStringDefineProxy.GetString(encourageShowInfo.encourage_effect, new object[]
						{
							num
						}));
						this._CurrentEncourageTitle.SetText(XStringDefineProxy.GetString(encourageShowInfo.encourage_title));
						this._CurrentEncourageType.SetText(XStringDefineProxy.GetString(encourageShowInfo.encourage_type));
						this._CurrentEncourageEffect.SetText(string.Format("{0}%", (long)num * (long)((ulong)encourageShowInfo.EncourageCount)));
						this._CurrentEncourageEffectTween.ResetTween(true);
						this._CurrentEncourageEffectTween.PlayTween(true, 0.5f);
						CostInfo costInfo = XSingleton<XTakeCostMgr>.singleton.QueryCost(encourageShowInfo.cost_string, (int)encourageShowInfo.EncourageCount);
						this._EncourageMoneyCost.SetText(costInfo.count.ToString());
					}
				}
			}
		}

		// Token: 0x060105E8 RID: 67048 RVA: 0x003FC480 File Offset: 0x003FA680
		private bool _OnEncouragePanelClicked(IXUIButton btn)
		{
			this._SelectIndex = (int)btn.ID;
			XSingleton<XDebug>.singleton.AddGreenLog("_OnEncouragePanelClicked" + this._SelectIndex.ToString(), null, null, null, null, null);
			this.RefreshEncourage();
			this.m_EncourageFrameTween.PlayTween(true, -1f);
			return true;
		}

		// Token: 0x060105E9 RID: 67049 RVA: 0x003FC4E0 File Offset: 0x003FA6E0
		private bool _OnDamageRankClicked(IXUIButton btn)
		{
			bool flag = !base.IsVisible();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				IXUISprite ixuisprite = btn.gameObject.GetComponent("XUISprite") as IXUISprite;
				bool flag2 = ixuisprite == null || this._RankHandler == null || this.m_RankFrameTween == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = !this._RankHandler.active;
					if (flag3)
					{
						this._RankHandler.SetVisible(true);
						this.m_RankFrameTween.PlayTween(true, -1f);
						ixuisprite.SetFlipHorizontal(true);
					}
					else
					{
						this.m_RankFrameTween.PlayTween(false, -1f);
						ixuisprite.SetFlipHorizontal(false);
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060105EA RID: 67050 RVA: 0x003FC598 File Offset: 0x003FA798
		private void _OnTweenFinishEventHandler(IXUITweenTool tween)
		{
			bool flag = !tween.bPlayForward && this._RankHandler != null;
			if (flag)
			{
				this._RankHandler.SetVisible(false);
			}
		}

		// Token: 0x060105EB RID: 67051 RVA: 0x003FC5CB File Offset: 0x003FA7CB
		private void _OnEncourageCloseClicked(IXUISprite iSp)
		{
			this._EncouragePanel.SetActive(false);
		}

		// Token: 0x060105EC RID: 67052 RVA: 0x003FC5DC File Offset: 0x003FA7DC
		private bool _OnEncourageDoClicked(IXUIButton btn)
		{
			EncourageShowInfo encourageShowInfo = this.m_encourageInfos[this._SelectIndex];
			bool flag = encourageShowInfo == null || encourageShowInfo.ReqEncourage == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				CostInfo costInfo = XSingleton<XTakeCostMgr>.singleton.QueryCost(encourageShowInfo.cost_string, (int)encourageShowInfo.EncourageCount);
				ulong itemCount = XBagDocument.BagDoc.GetItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DRAGON_COIN));
				bool flag2 = (ulong)costInfo.count > itemCount;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_AUCT_DRAGONCOINLESS"), "fece00");
				}
				else
				{
					encourageShowInfo.ReqEncourage();
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060105ED RID: 67053 RVA: 0x003FC67C File Offset: 0x003FA87C
		public void SetLeftTime(uint leftTime)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.SetLeftTime(leftTime, -1);
			}
			bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
			if (flag2)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetLeftTime(leftTime);
			}
		}

		// Token: 0x060105EE RID: 67054 RVA: 0x003FC6C0 File Offset: 0x003FA8C0
		private bool _OnReviveDoClicked(IXUIButton btn)
		{
			RpcC2G_Revive rpcC2G_Revive = new RpcC2G_Revive();
			rpcC2G_Revive.oArg.selectBuff = 0U;
			rpcC2G_Revive.oArg.type = ReviveType.ReviveItem;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_Revive);
			return true;
		}

		// Token: 0x060105EF RID: 67055 RVA: 0x003FC700 File Offset: 0x003FA900
		public void SetAutoRevive(int leftTime, uint cost, uint costType)
		{
			bool flag = leftTime <= 0;
			if (!flag)
			{
				this._AutoRevivePanel.SetActive(true);
				this.m_AutoReviveLeftTime.LeftTime = (float)leftTime;
				this._AutoReviveLeftTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString(leftTime, 2, 3, 4, false, true));
				this._ReviveCost.SetText(cost.ToString());
				string itemSmallIcon = XBagDocument.GetItemSmallIcon((int)costType, 0U);
				this._ReviveCostIcon.SetSprite(itemSmallIcon);
			}
		}

		// Token: 0x060105F0 RID: 67056 RVA: 0x003FC77A File Offset: 0x003FA97A
		public void HideAutoRevive()
		{
			this._AutoRevivePanel.SetActive(false);
		}

		// Token: 0x060105F1 RID: 67057 RVA: 0x003FC78C File Offset: 0x003FA98C
		public void OnLeaveSceneCountDown(uint time)
		{
			this._LeaveSceneTime = time;
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("WORLDBOSS_LEAVE_SCENE_TIP"), "fece00");
			XSingleton<XTimerMgr>.singleton.KillTimer(this._LeaveSceneToken);
			this._LeaveSceneToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.ShowLeaveSceneTip), null);
		}

		// Token: 0x060105F2 RID: 67058 RVA: 0x003FC7F4 File Offset: 0x003FA9F4
		private void ShowLeaveSceneTip(object o)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(this._LeaveSceneTime.ToString(), "fece00");
			this._LeaveSceneTime -= 1U;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._LeaveSceneToken);
			this._LeaveSceneToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.ShowLeaveSceneTip), null);
			bool flag = this._LeaveSceneTime <= 0U && this._LeaveSceneToken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._LeaveSceneToken);
				this._LeaveSceneToken = 0U;
			}
		}

		// Token: 0x04007605 RID: 30213
		private IXUIButton _DamageRankBtn;

		// Token: 0x04007606 RID: 30214
		private GameObject _EncouragePanel;

		// Token: 0x04007607 RID: 30215
		private IXUIButton _DoEncourage;

		// Token: 0x04007608 RID: 30216
		private IXUISprite _EncourageClose;

		// Token: 0x04007609 RID: 30217
		private IXUILabel _CurrentEncourageEffect;

		// Token: 0x0400760A RID: 30218
		private IXUILabel _CurrentEncourageTitle;

		// Token: 0x0400760B RID: 30219
		private IXUILabel _CurrentEncourageType;

		// Token: 0x0400760C RID: 30220
		private IXUILabel _EncourageEffect;

		// Token: 0x0400760D RID: 30221
		private IXUILabel _EncourageMoneyCost;

		// Token: 0x0400760E RID: 30222
		private IXUITweenTool _CurrentEncourageEffectTween;

		// Token: 0x0400760F RID: 30223
		private GameObject _RankPanel;

		// Token: 0x04007610 RID: 30224
		private GameObject _AutoRevivePanel;

		// Token: 0x04007611 RID: 30225
		private IXUILabel _AutoReviveLeftTime;

		// Token: 0x04007612 RID: 30226
		private IXUILabel _ReviveCost;

		// Token: 0x04007613 RID: 30227
		private IXUISprite _ReviveCostIcon;

		// Token: 0x04007614 RID: 30228
		private IXUIButton _DoRevive;

		// Token: 0x04007615 RID: 30229
		public IXUITweenTool m_EncourageFrameTween;

		// Token: 0x04007616 RID: 30230
		public IXUITweenTool m_RankFrameTween;

		// Token: 0x04007617 RID: 30231
		private XWorldBossDamageRankHandler _RankHandler;

		// Token: 0x04007618 RID: 30232
		public IWorldBossBattleSource BattleSource;

		// Token: 0x04007619 RID: 30233
		private XElapseTimer m_AutoReviveLeftTime = new XElapseTimer();

		// Token: 0x0400761A RID: 30234
		private int m_nAutoReviveLeftTime;

		// Token: 0x0400761B RID: 30235
		private uint _GetBattleInfoToken;

		// Token: 0x0400761C RID: 30236
		private EncourageShowInfo[] m_encourageInfos;

		// Token: 0x0400761D RID: 30237
		private uint _LeaveSceneToken = 0U;

		// Token: 0x0400761E RID: 30238
		private uint _LeaveSceneTime = 0U;

		// Token: 0x0400761F RID: 30239
		private int _SelectIndex = 0;
	}
}
