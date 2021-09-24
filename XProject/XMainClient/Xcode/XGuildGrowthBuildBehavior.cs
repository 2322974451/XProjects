using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XGuildGrowthBuildBehavior : DlgBehaviourBase
	{

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

		public IXUIButton CloseBtn;

		public IXUIButton HelpBtn;

		public Transform m_MyRankTs;

		public IXUIWrapContent m_RankWrapContent;

		public IXUIScrollView m_RankScrollView;

		public IXUILabel m_ProgressNum;

		public IXUIProgress m_Progress;

		public Transform Tag1;

		public IXUILabel Tag1Num;

		public IXUISprite Tag1Click;

		public Transform Tag2;

		public IXUILabel Tag2Num;

		public IXUISprite Tag2Click;

		public IXUILabel m_WeekNumShow;

		public float allDepth;

		public float startX;

		public IXUILabel HuntText;

		public IXUILabel DonateText;

		public IXUISprite HuntTips;

		public IXUISprite DonateTips;

		public IXUIButton HuntBtn;

		public IXUIButton DonateBtn;

		public IXUILabel HuntTimes;

		public IXUILabel DonateTimes;

		public GameObject HuntRedPoint;

		public GameObject DonateRedPoint;
	}
}
