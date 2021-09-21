using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B9D RID: 2973
	internal class LevelRewardBattleDataHandler : DlgHandlerBase
	{
		// Token: 0x17003042 RID: 12354
		// (get) Token: 0x0600AA92 RID: 43666 RVA: 0x001E9918 File Offset: 0x001E7B18
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardBattleDataFrame";
			}
		}

		// Token: 0x0600AA93 RID: 43667 RVA: 0x001E992F File Offset: 0x001E7B2F
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
		}

		// Token: 0x0600AA94 RID: 43668 RVA: 0x001E9950 File Offset: 0x001E7B50
		private void InitUI()
		{
			this.m_close = (base.PanelObject.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_watch = (base.PanelObject.transform.Find("Watch").GetComponent("XUILabel") as IXUILabel);
			this.m_like = (base.PanelObject.transform.Find("Like").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.PanelObject.transform.Find("Panel/MemberTpl");
			this.m_battle_data_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
			this.m_time = (base.PanelObject.transform.Find("Time").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600AA95 RID: 43669 RVA: 0x001E9A3B File Offset: 0x001E7C3B
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600AA96 RID: 43670 RVA: 0x001E9A60 File Offset: 0x001E7C60
		private bool OnCloseClicked(IXUIButton sp)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x0600AA97 RID: 43671 RVA: 0x001E9A7B File Offset: 0x001E7C7B
		protected override void OnShow()
		{
			base.OnShow();
			this.OnShowUI();
		}

		// Token: 0x0600AA98 RID: 43672 RVA: 0x001E9A8C File Offset: 0x001E7C8C
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

		// Token: 0x0600AA99 RID: 43673 RVA: 0x001E9C20 File Offset: 0x001E7E20
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

		// Token: 0x04003F5C RID: 16220
		private XLevelRewardDocument doc = null;

		// Token: 0x04003F5D RID: 16221
		private IXUIButton m_close;

		// Token: 0x04003F5E RID: 16222
		private XUIPool m_battle_data_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04003F5F RID: 16223
		private IXUILabel m_watch;

		// Token: 0x04003F60 RID: 16224
		private IXUILabel m_like;

		// Token: 0x04003F61 RID: 16225
		private IXUILabel m_time;
	}
}
