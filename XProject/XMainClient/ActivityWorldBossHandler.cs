using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EF5 RID: 3829
	internal class ActivityWorldBossHandler : DlgHandlerBase
	{
		// Token: 0x0600CB37 RID: 52023 RVA: 0x002E4330 File Offset: 0x002E2530
		protected override void Init()
		{
			base.Init();
			this._GoBattle = (base.PanelObject.transform.Find("GoBattle").GetComponent("XUIButton") as IXUIButton);
			this._DamageRank = (base.PanelObject.transform.Find("DamageRank").GetComponent("XUIButton") as IXUIButton);
			this.m_DamageRankPanel = base.PanelObject.transform.FindChild("DamageRankPanel").gameObject;
			this._LeftTime = (base.PanelObject.transform.Find("LeftTime/Value").GetComponent("XUILabel") as IXUILabel);
			this._StartTime = (base.PanelObject.transform.Find("StartTime/Value").GetComponent("XUILabel") as IXUILabel);
			this._DamageRankTween = (this.m_DamageRankPanel.GetComponent("XUIPlayTween") as IXUITweenTool);
			this._doc = XDocuments.GetSpecificDocument<XWorldBossDocument>(XWorldBossDocument.uuID);
			this._doc.ActivityWorldBossView = this;
			DlgHandlerBase.EnsureCreate<XWorldBossDamageRankHandler>(ref this._DamageRankHandler, this.m_DamageRankPanel, null, true);
			List<RankeType> list = new List<RankeType>();
			list.Add(RankeType.WorldBossDamageRank);
			this._DamageRankHandler.SetupRanks(list, false);
			this._DamageRankHandler.RankSource = this._doc;
			this._doc.RankHandler = this._DamageRankHandler;
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("WorldBossEnterTime").Split(XGlobalConfig.ListSeparator);
			bool flag = array.Length != 4;
			if (flag)
			{
				this._StartTime.SetText("");
			}
			else
			{
				this._StartTime.SetText(string.Format("{0:D2}:{1:D2} ~ {2:D2}:{3:D2}", new object[]
				{
					uint.Parse(array[0]),
					uint.Parse(array[1]),
					uint.Parse(array[2]),
					uint.Parse(array[3])
				}));
			}
		}

		// Token: 0x0600CB38 RID: 52024 RVA: 0x002E452C File Offset: 0x002E272C
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._GoBattle.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBattleClicked));
			this._DamageRank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDamageRankClicked));
		}

		// Token: 0x0600CB39 RID: 52025 RVA: 0x002E4566 File Offset: 0x002E2766
		protected override void OnShow()
		{
			base.OnShow();
			this.ShowDropList();
			this._LeftTime.SetVisible(false);
			this._doc.ReqWorldBossState();
			this.m_DamageRankPanel.SetActive(false);
		}

		// Token: 0x0600CB3A RID: 52026 RVA: 0x002E459D File Offset: 0x002E279D
		public override void OnUnload()
		{
			this._doc.ActivityWorldBossView = null;
			this._DamageRankHandler.RankSource = null;
			this._doc.RankHandler = null;
			DlgHandlerBase.EnsureUnload<XWorldBossDamageRankHandler>(ref this._DamageRankHandler);
			base.OnUnload();
		}

		// Token: 0x0600CB3B RID: 52027 RVA: 0x002E45D7 File Offset: 0x002E27D7
		public override void OnUpdate()
		{
			base.OnUpdate();
			this._fLeftTime.Update();
			this._RefreshTime();
		}

		// Token: 0x0600CB3C RID: 52028 RVA: 0x002E45F4 File Offset: 0x002E27F4
		private void _RefreshTime()
		{
			uint totalSecond = (uint)this._fLeftTime.LeftTime;
			this._LeftTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)totalSecond, 3, 3, 4, false, true));
		}

		// Token: 0x0600CB3D RID: 52029 RVA: 0x002E462C File Offset: 0x002E282C
		public void ShowDropList()
		{
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this._doc.GetWorldBossSceneID());
			bool flag = sceneData.ViewableDropList != null;
			if (flag)
			{
				int num = Math.Min(sceneData.ViewableDropList.Length, ActivityWorldBossHandler.REWARD_COUNT);
				int i;
				for (i = 0; i < num; i++)
				{
					GameObject gameObject = base.PanelObject.transform.FindChild("DropFrame/Item" + i).gameObject;
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, sceneData.ViewableDropList[i], 0, false);
					IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)((long)sceneData.ViewableDropList[i]);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
				while (i < ActivityWorldBossHandler.REWARD_COUNT)
				{
					GameObject gameObject2 = base.PanelObject.transform.FindChild("DropFrame/Item" + i).gameObject;
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, 0, 0, false);
					i++;
				}
			}
		}

		// Token: 0x0600CB3E RID: 52030 RVA: 0x002E476F File Offset: 0x002E296F
		public void SetLeftTime(float time)
		{
			this._fLeftTime.LeftTime = time;
			this._LeftTime.SetVisible(true);
			this._RefreshTime();
		}

		// Token: 0x0600CB3F RID: 52031 RVA: 0x002E4794 File Offset: 0x002E2994
		protected bool OnBattleClicked(IXUIButton go)
		{
			bool flag = XTeamDocument.GoSingleBattleBeforeNeed(new ButtonClickEventHandler(this.OnBattleClicked), go);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._doc.ReqEnterWorldBossScene();
				result = true;
			}
			return result;
		}

		// Token: 0x0600CB40 RID: 52032 RVA: 0x002E47D0 File Offset: 0x002E29D0
		protected bool OnDamageRankClicked(IXUIButton go)
		{
			this._DamageRankHandler.SetVisible(true);
			this._DamageRankTween.PlayTween(true, -1f);
			return true;
		}

		// Token: 0x0600CB41 RID: 52033 RVA: 0x002E4804 File Offset: 0x002E2A04
		protected bool OnHeroPalaceClicked(IXUIButton go)
		{
			return true;
		}

		// Token: 0x040059D8 RID: 23000
		private XWorldBossDocument _doc;

		// Token: 0x040059D9 RID: 23001
		private IXUIButton _GoBattle;

		// Token: 0x040059DA RID: 23002
		private IXUIButton _DamageRank;

		// Token: 0x040059DB RID: 23003
		private GameObject m_DamageRankPanel;

		// Token: 0x040059DC RID: 23004
		private IXUILabel _LeftTime;

		// Token: 0x040059DD RID: 23005
		private IXUILabel _StartTime;

		// Token: 0x040059DE RID: 23006
		public static readonly int REWARD_COUNT = 3;

		// Token: 0x040059DF RID: 23007
		private XElapseTimer _fLeftTime = new XElapseTimer();

		// Token: 0x040059E0 RID: 23008
		private XWorldBossDamageRankHandler _DamageRankHandler;

		// Token: 0x040059E1 RID: 23009
		private IXUITweenTool _DamageRankTween;
	}
}
