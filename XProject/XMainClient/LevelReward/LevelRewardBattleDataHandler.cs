using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class LevelRewardBattleDataHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardBattleDataFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
		}

		private void InitUI()
		{
			this.m_close = (base.PanelObject.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_watch = (base.PanelObject.transform.Find("Watch").GetComponent("XUILabel") as IXUILabel);
			this.m_like = (base.PanelObject.transform.Find("Like").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.PanelObject.transform.Find("Panel/MemberTpl");
			this.m_battle_data_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
			this.m_time = (base.PanelObject.transform.Find("Time").GetComponent("XUILabel") as IXUILabel);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		private bool OnCloseClicked(IXUIButton sp)
		{
			base.SetVisible(false);
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.OnShowUI();
		}

		private void OnShowUI()
		{
			bool flag = XSpectateSceneDocument.WhetherWathchNumShow((int)this.doc.WatchCount, (int)this.doc.LikeCount, (int)this.doc.CurrentStage);
			if (flag)
			{
				this.m_watch.SetVisible(true);
				this.m_like.SetVisible(true);
				this.m_watch.SetText(this.doc.WatchCount.ToString());
				this.m_like.SetText(this.doc.LikeCount.ToString());
			}
			else
			{
				this.m_watch.SetVisible(false);
				this.m_like.SetVisible(false);
			}
			this.m_battle_data_pool.FakeReturnAll();
			float num = this.m_battle_data_pool.TplPos.y;
			for (int i = 0; i < this.doc.BattleDataList.Count; i++)
			{
				GameObject gameObject = this.m_battle_data_pool.FetchGameObject(false);
				this.SetupBattleData(gameObject, this.doc.BattleDataList[i]);
				gameObject.transform.localPosition = new Vector3(this.m_battle_data_pool.TplPos.x, num);
				num -= (float)this.m_battle_data_pool.TplHeight;
			}
			this.m_battle_data_pool.ActualReturnAll(false);
			this.m_time.SetText(string.Format("{0} {1}", XStringDefineProxy.GetString("LEVEL_FINISH_TIME"), XSingleton<UiUtility>.singleton.TimeFormatString(this.doc.LevelFinishTime, 2, 3, 4, false, true)));
		}

		private void SetupBattleData(GameObject go, XLevelRewardDocument.BattleData data)
		{
			IXUISprite ixuisprite = go.transform.Find("Detail/Avatar").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = go.transform.Find("Detail/Name").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite2 = go.transform.Find("Detail/Leader").GetComponent("XUISprite") as IXUISprite;
			Transform[] array = new Transform[3];
			for (int i = 0; i < 3; i++)
			{
				array[i] = go.transform.Find(string.Format("Stars/Star{0}", i + 1));
			}
			IXUILabel ixuilabel2 = go.transform.Find("DamageTotal").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = go.transform.Find("DamagePercent").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel4 = go.transform.Find("HealTotal").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel5 = go.transform.Find("DeathCount").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel6 = go.transform.Find("MaxCombo").GetComponent("XUILabel") as IXUILabel;
			ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon(data.ProfID));
			ixuilabel.SetText(data.Name);
			ixuisprite2.SetVisible(data.isLeader);
			for (int j = 0; j < 3; j++)
			{
				array[j].gameObject.SetActive((long)j < (long)((ulong)data.Rank));
			}
			ixuilabel2.SetText(data.DamageTotal.ToString());
			ixuilabel3.SetText(string.Format("{0}%", data.DamagePercent.ToString("0.0")));
			ixuilabel4.SetText(data.HealTotal.ToString());
			ixuilabel5.SetText(data.DeathCount.ToString());
			ixuilabel6.SetText(data.ComboCount.ToString());
		}

		private XLevelRewardDocument doc = null;

		private IXUIButton m_close;

		private XUIPool m_battle_data_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUILabel m_watch;

		private IXUILabel m_like;

		private IXUILabel m_time;
	}
}
