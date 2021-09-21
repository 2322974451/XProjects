using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000A64 RID: 2660
	internal class XGuildGrowthBuildBehavior : DlgBehaviourBase
	{
		// Token: 0x0600A155 RID: 41301 RVA: 0x001B4740 File Offset: 0x001B2940
		private void Awake()
		{
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.HelpBtn = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_MyRankTs = base.transform.Find("Bg/BuildRank/MyRank");
			this.m_RankWrapContent = (base.transform.Find("Bg/BuildRank/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_RankScrollView = (base.transform.Find("Bg/BuildRank/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_ProgressNum = (base.transform.Find("Bg/BossTexture/num").GetComponent("XUILabel") as IXUILabel);
			this.m_Progress = (base.transform.Find("Bg/BossTexture/Progress").GetComponent("XUIProgress") as IXUIProgress);
			this.Tag1 = base.transform.Find("Bg/BossTexture/Kd1");
			this.Tag1Num = (this.Tag1.transform.Find("Daytpl/num").GetComponent("XUILabel") as IXUILabel);
			this.Tag1Click = (this.Tag1.transform.Find("Daytpl").GetComponent("XUISprite") as IXUISprite);
			this.Tag2 = base.transform.Find("Bg/BossTexture/Kd2");
			this.Tag2Num = (this.Tag2.transform.Find("Daytpl/num").GetComponent("XUILabel") as IXUILabel);
			this.Tag2Click = (this.Tag2.transform.Find("Daytpl").GetComponent("XUISprite") as IXUISprite);
			this.allDepth = this.Tag2.localPosition.x - this.Tag1.localPosition.x;
			this.startX = this.Tag1.localPosition.x;
			this.m_WeekNumShow = (base.transform.Find("Bg/BossTexture/t").GetComponent("XUILabel") as IXUILabel);
			this.HuntText = (base.transform.Find("Bg/Go1/label").GetComponent("XUILabel") as IXUILabel);
			this.DonateText = (base.transform.Find("Bg/Go2/label").GetComponent("XUILabel") as IXUILabel);
			this.HuntTips = (base.transform.Find("Bg/Go1/Help").GetComponent("XUISprite") as IXUISprite);
			this.DonateTips = (base.transform.Find("Bg/Go2/Help").GetComponent("XUISprite") as IXUISprite);
			this.HuntBtn = (base.transform.Find("Bg/Go1/BtnEnter").GetComponent("XUIButton") as IXUIButton);
			this.DonateBtn = (base.transform.Find("Bg/Go2/BtnEnter").GetComponent("XUIButton") as IXUIButton);
			this.HuntTimes = (base.transform.Find("Bg/Go1/num").GetComponent("XUILabel") as IXUILabel);
			this.DonateTimes = (base.transform.Find("Bg/Go2/num").GetComponent("XUILabel") as IXUILabel);
			this.HuntRedPoint = this.HuntBtn.gameObject.transform.Find("RedPoint").gameObject;
			this.DonateRedPoint = this.DonateBtn.gameObject.transform.Find("RedPoint").gameObject;
		}

		// Token: 0x04003A16 RID: 14870
		public IXUIButton CloseBtn;

		// Token: 0x04003A17 RID: 14871
		public IXUIButton HelpBtn;

		// Token: 0x04003A18 RID: 14872
		public Transform m_MyRankTs;

		// Token: 0x04003A19 RID: 14873
		public IXUIWrapContent m_RankWrapContent;

		// Token: 0x04003A1A RID: 14874
		public IXUIScrollView m_RankScrollView;

		// Token: 0x04003A1B RID: 14875
		public IXUILabel m_ProgressNum;

		// Token: 0x04003A1C RID: 14876
		public IXUIProgress m_Progress;

		// Token: 0x04003A1D RID: 14877
		public Transform Tag1;

		// Token: 0x04003A1E RID: 14878
		public IXUILabel Tag1Num;

		// Token: 0x04003A1F RID: 14879
		public IXUISprite Tag1Click;

		// Token: 0x04003A20 RID: 14880
		public Transform Tag2;

		// Token: 0x04003A21 RID: 14881
		public IXUILabel Tag2Num;

		// Token: 0x04003A22 RID: 14882
		public IXUISprite Tag2Click;

		// Token: 0x04003A23 RID: 14883
		public IXUILabel m_WeekNumShow;

		// Token: 0x04003A24 RID: 14884
		public float allDepth;

		// Token: 0x04003A25 RID: 14885
		public float startX;

		// Token: 0x04003A26 RID: 14886
		public IXUILabel HuntText;

		// Token: 0x04003A27 RID: 14887
		public IXUILabel DonateText;

		// Token: 0x04003A28 RID: 14888
		public IXUISprite HuntTips;

		// Token: 0x04003A29 RID: 14889
		public IXUISprite DonateTips;

		// Token: 0x04003A2A RID: 14890
		public IXUIButton HuntBtn;

		// Token: 0x04003A2B RID: 14891
		public IXUIButton DonateBtn;

		// Token: 0x04003A2C RID: 14892
		public IXUILabel HuntTimes;

		// Token: 0x04003A2D RID: 14893
		public IXUILabel DonateTimes;

		// Token: 0x04003A2E RID: 14894
		public GameObject HuntRedPoint;

		// Token: 0x04003A2F RID: 14895
		public GameObject DonateRedPoint;
	}
}
