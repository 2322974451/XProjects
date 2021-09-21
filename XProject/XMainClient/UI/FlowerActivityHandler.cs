using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017E3 RID: 6115
	internal class FlowerActivityHandler : DlgHandlerBase
	{
		// Token: 0x170038B7 RID: 14519
		// (get) Token: 0x0600FD81 RID: 64897 RVA: 0x003B7070 File Offset: 0x003B5270
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/FlowerActivityFrame";
			}
		}

		// Token: 0x0600FD82 RID: 64898 RVA: 0x003B7088 File Offset: 0x003B5288
		protected override void Init()
		{
			base.Init();
			this.m_Tip1 = (base.PanelObject.transform.Find("Main/Tip1").GetComponent("XUILabel") as IXUILabel);
			this.m_Tip2 = (base.PanelObject.transform.Find("Main/Tip2").GetComponent("XUILabel") as IXUILabel);
			this.m_AwardRankCount = (base.PanelObject.transform.Find("Main/Items/RankNum").GetComponent("XUILabel") as IXUILabel);
			this.m_GoWeekRank = (base.PanelObject.transform.Find("Main/Btns/ViewRewardBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_AwardRoot = base.PanelObject.transform.Find("Main/Items");
			GameObject gameObject = base.PanelObject.transform.Find("Main/Items/Item").gameObject;
			this.m_ItemPool.SetupPool(this.m_AwardRoot.gameObject, gameObject, 7U, false);
		}

		// Token: 0x0600FD83 RID: 64899 RVA: 0x003B7198 File Offset: 0x003B5398
		protected override void OnShow()
		{
			base.OnShow();
			this.m_Tip1.SetText(XSingleton<XStringTable>.singleton.GetString("FLOWER_ACTIVITY_TIP1"));
			this.m_Tip2.SetText(XSingleton<XStringTable>.singleton.GetString("FLOWER_ACTIVITY_TIP3"));
			this.m_AwardRankCount.SetText(XSingleton<XStringTable>.singleton.GetString("FLOWER_ACTIVITY_AWARD_RANK"));
			this.SetAwardsInfo();
		}

		// Token: 0x0600FD84 RID: 64900 RVA: 0x003B7205 File Offset: 0x003B5405
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_GoWeekRank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoWeekRankClicked));
		}

		// Token: 0x0600FD85 RID: 64901 RVA: 0x003B7228 File Offset: 0x003B5428
		private bool OnGoWeekRankClicked(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Flower_Rank_Week, 0UL);
			return true;
		}

		// Token: 0x0600FD86 RID: 64902 RVA: 0x003B7250 File Offset: 0x003B5450
		private void SetAwardsInfo()
		{
			XFlowerRankDocument specificDocument = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
			SeqListRef<int> weekRankAward = specificDocument.GetWeekRankAward(1);
			this.m_ItemPool.ReturnAll(false);
			for (int i = 0; i < weekRankAward.Count; i++)
			{
				GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
				gameObject.transform.parent = this.m_AwardRoot;
				gameObject.name = i.ToString();
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3((float)(this.m_ItemPool.TplWidth * i), 0f, 0f);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)weekRankAward[i, 0]);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, weekRankAward[i, 0], weekRankAward[i, 1], false);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
		}

		// Token: 0x04006FCD RID: 28621
		private IXUILabel m_Tip1;

		// Token: 0x04006FCE RID: 28622
		private IXUILabel m_Tip2;

		// Token: 0x04006FCF RID: 28623
		private IXUILabel m_AwardRankCount;

		// Token: 0x04006FD0 RID: 28624
		private IXUIButton m_GoWeekRank;

		// Token: 0x04006FD1 RID: 28625
		private Transform m_AwardRoot;

		// Token: 0x04006FD2 RID: 28626
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
