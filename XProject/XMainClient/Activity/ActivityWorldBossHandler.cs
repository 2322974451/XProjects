using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ActivityWorldBossHandler : DlgHandlerBase
	{

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._GoBattle.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBattleClicked));
			this._DamageRank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDamageRankClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowDropList();
			this._LeftTime.SetVisible(false);
			this._doc.ReqWorldBossState();
			this.m_DamageRankPanel.SetActive(false);
		}

		public override void OnUnload()
		{
			this._doc.ActivityWorldBossView = null;
			this._DamageRankHandler.RankSource = null;
			this._doc.RankHandler = null;
			DlgHandlerBase.EnsureUnload<XWorldBossDamageRankHandler>(ref this._DamageRankHandler);
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this._fLeftTime.Update();
			this._RefreshTime();
		}

		private void _RefreshTime()
		{
			uint totalSecond = (uint)this._fLeftTime.LeftTime;
			this._LeftTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)totalSecond, 3, 3, 4, false, true));
		}

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

		public void SetLeftTime(float time)
		{
			this._fLeftTime.LeftTime = time;
			this._LeftTime.SetVisible(true);
			this._RefreshTime();
		}

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

		protected bool OnDamageRankClicked(IXUIButton go)
		{
			this._DamageRankHandler.SetVisible(true);
			this._DamageRankTween.PlayTween(true, -1f);
			return true;
		}

		protected bool OnHeroPalaceClicked(IXUIButton go)
		{
			return true;
		}

		private XWorldBossDocument _doc;

		private IXUIButton _GoBattle;

		private IXUIButton _DamageRank;

		private GameObject m_DamageRankPanel;

		private IXUILabel _LeftTime;

		private IXUILabel _StartTime;

		public static readonly int REWARD_COUNT = 3;

		private XElapseTimer _fLeftTime = new XElapseTimer();

		private XWorldBossDamageRankHandler _DamageRankHandler;

		private IXUITweenTool _DamageRankTween;
	}
}
