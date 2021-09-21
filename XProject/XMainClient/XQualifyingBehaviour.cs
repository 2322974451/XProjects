using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E51 RID: 3665
	internal class XQualifyingBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C489 RID: 50313 RVA: 0x002AF084 File Offset: 0x002AD284
		private void Awake()
		{
			this.m_Bg = base.transform.FindChild("Bg");
			this.m_Close = (this.m_Bg.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (this.m_Bg.FindChild("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_BattleRecordFrame = this.m_Bg.FindChild("BattleRecordFrame").gameObject;
			Transform transform = this.m_Bg.FindChild("Bg/Tabs/TabTpl");
			this.m_TabPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			this.m_UnOpen2V2 = (this.m_Bg.FindChild("Bg/2V2UnOpen").GetComponent("XUISprite") as IXUISprite);
			Transform transform2 = this.m_Bg.FindChild("Bg/BtnList");
			this.m_ShopBtn = (transform2.FindChild("ShopBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_RankBtn = (transform2.FindChild("RankBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_BattleRecordBtn = (transform2.FindChild("BattleRecordBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_TrainBtn = (transform2.FindChild("TrainingBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_PointRewardBtn = (transform2.Find("PointRewardBtn").GetComponent("XUITexture") as IXUITexture);
			this.m_PointRewardRedPoint = transform2.FindChild("PointRewardBtn/RedPoint");
			this.m_RankRewardBtn = (transform2.FindChild("RankRewardBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Match1V1Btn = (transform2.FindChild("Match1V1Btn").GetComponent("XUIButton") as IXUIButton);
			this.m_Match1V1BtnLabel = (transform2.FindChild("Match1V1Btn/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_Match2V2Btn = (transform2.FindChild("Match2V2Btn").GetComponent("XUIButton") as IXUIButton);
			this.m_Match2V2BtnLabel = (transform2.FindChild("Match2V2Btn/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_TeamBtn = (transform2.FindChild("TeamBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Message = this.m_Bg.FindChild("Bg/Message");
			this.m_TotalRecords = (this.m_Message.FindChild("Records/TotalRecords/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_WinRecord = (this.m_Message.FindChild("Records/Win/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_LoseRecord = (this.m_Message.FindChild("Records/Lose/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_WinRate = (this.m_Message.FindChild("Records/Rate/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_CurrentRank = (this.m_Message.FindChild("CurrentRank/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_RankEndTips = (this.m_Message.FindChild("Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_ChallengeFrame = this.m_Bg.FindChild("Bg/ChallengeFrame");
			this.m_Tier = (this.m_ChallengeFrame.Find("Tier").GetComponent("XUITexture") as IXUITexture);
			this.m_WinOfPoint = (this.m_ChallengeFrame.FindChild("WinOfPoint/Num").GetComponent("XUILabel") as IXUILabel);
			this.m_ChallengeTip = (this.m_ChallengeFrame.FindChild("Tip").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_ChallengeTipText = (this.m_ChallengeTip.gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel);
			this.m_FxFireworkGo = this.m_ChallengeFrame.FindChild("m_FxFirework").gameObject;
			this.m_FxFireworkGo.SetActive(false);
			this.m_RankWindow = new XQualifyingRankWindow(this.m_Bg.FindChild("RankFrame").gameObject);
			this.m_RankRewardWindow = new XQualifyingRankRewardWindow(this.m_Bg.FindChild("RankRewardFrame").gameObject);
			this.m_PointRewardWindow = new XQualifyingPointRewardWindow(this.m_Bg.FindChild("PointRewardFrame").gameObject);
		}

		// Token: 0x0400558E RID: 21902
		public IXUIButton m_Close;

		// Token: 0x0400558F RID: 21903
		public IXUIButton m_Help;

		// Token: 0x04005590 RID: 21904
		public XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005591 RID: 21905
		public IXUISprite m_UnOpen2V2;

		// Token: 0x04005592 RID: 21906
		public Transform m_Bg;

		// Token: 0x04005593 RID: 21907
		public IXUIButton m_ShopBtn;

		// Token: 0x04005594 RID: 21908
		public IXUIButton m_RankBtn;

		// Token: 0x04005595 RID: 21909
		public IXUIButton m_BattleRecordBtn;

		// Token: 0x04005596 RID: 21910
		public IXUIButton m_TrainBtn;

		// Token: 0x04005597 RID: 21911
		public IXUITexture m_PointRewardBtn;

		// Token: 0x04005598 RID: 21912
		public Transform m_PointRewardRedPoint;

		// Token: 0x04005599 RID: 21913
		public IXUIButton m_RankRewardBtn;

		// Token: 0x0400559A RID: 21914
		public IXUIButton m_Match1V1Btn;

		// Token: 0x0400559B RID: 21915
		public IXUILabel m_Match1V1BtnLabel;

		// Token: 0x0400559C RID: 21916
		public IXUIButton m_Match2V2Btn;

		// Token: 0x0400559D RID: 21917
		public IXUILabel m_Match2V2BtnLabel;

		// Token: 0x0400559E RID: 21918
		public IXUIButton m_TeamBtn;

		// Token: 0x0400559F RID: 21919
		public Transform m_Message;

		// Token: 0x040055A0 RID: 21920
		public IXUILabel m_TotalRecords;

		// Token: 0x040055A1 RID: 21921
		public IXUILabel m_WinRecord;

		// Token: 0x040055A2 RID: 21922
		public IXUILabel m_LoseRecord;

		// Token: 0x040055A3 RID: 21923
		public IXUILabel m_WinRate;

		// Token: 0x040055A4 RID: 21924
		public IXUILabel m_CurrentRank;

		// Token: 0x040055A5 RID: 21925
		public IXUILabel m_RankEndTips;

		// Token: 0x040055A6 RID: 21926
		public Transform m_ChallengeFrame;

		// Token: 0x040055A7 RID: 21927
		public IXUITexture m_Tier;

		// Token: 0x040055A8 RID: 21928
		public IXUILabel m_WinOfPoint;

		// Token: 0x040055A9 RID: 21929
		public XNumberTween m_NumberTween;

		// Token: 0x040055AA RID: 21930
		public IXUILabelSymbol m_ChallengeTip;

		// Token: 0x040055AB RID: 21931
		public IXUILabel m_ChallengeTipText;

		// Token: 0x040055AC RID: 21932
		public GameObject m_FxFireworkGo;

		// Token: 0x040055AD RID: 21933
		public XUIPool m_RankTabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040055AE RID: 21934
		public IXUICheckBox m_RankTypeAll;

		// Token: 0x040055AF RID: 21935
		public XQualifyingRankWindow m_RankWindow;

		// Token: 0x040055B0 RID: 21936
		public XQualifyingRankRewardWindow m_RankRewardWindow;

		// Token: 0x040055B1 RID: 21937
		public XQualifyingPointRewardWindow m_PointRewardWindow;

		// Token: 0x040055B2 RID: 21938
		public GameObject m_BattleRecordFrame;
	}
}
