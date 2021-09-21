using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E89 RID: 3721
	internal class XVoiceQABehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C6BE RID: 50878 RVA: 0x002C0074 File Offset: 0x002BE274
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Title = (base.transform.Find("Bg/Title").GetComponent("XUILabel") as IXUILabel);
			this.m_Start = base.transform.Find("Bg/Desc/start").gameObject;
			this.m_Ongoing = base.transform.Find("Bg/Desc/ing").gameObject;
			this.m_End = base.transform.Find("Bg/Desc/end").gameObject;
			this.m_AutoPlay = (base.transform.Find("Bg/Desc/AutoPlay").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_ExitVoiceQA = (base.transform.Find("Bg/Desc/end/exit").GetComponent("XUIButton") as IXUIButton);
			this.m_NextQuestion = (base.transform.Find("Bg/Desc/ing/next").GetComponent("XUIButton") as IXUIButton);
			this.m_QuesNum = (this.m_Ongoing.GetComponent("XUILabel") as IXUILabel);
			this.m_QuesDesc = (this.m_Ongoing.transform.Find("question").GetComponent("XUILabel") as IXUILabel);
			this.m_Right = base.transform.Find("Bg/Desc/ing/right").gameObject;
			this.m_Reward = (base.transform.Find("Bg/Desc/ing/message/reward/item").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_SpeakBtn = (base.transform.Find("Bg/Speak").GetComponent("XUIButton") as IXUIButton);
			this.m_Input = (base.transform.Find("Bg/Input").GetComponent("XUIButton") as IXUIButton);
			this.m_SingleGo = base.transform.Find("Bg/Single").gameObject;
			this.m_SingleSrcollView = (this.m_SingleGo.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_SingleWrapContent = (this.m_SingleSrcollView.gameObject.transform.Find("WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_MultipleGo = base.transform.Find("Bg/Multiple").gameObject;
			this.m_MultiSrollView = (this.m_MultipleGo.transform.Find("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_MultiWrapContent = (this.m_MultiSrollView.gameObject.transform.Find("WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_RankScrollView = (this.m_MultipleGo.transform.Find("ScoreRank/rank/allRank").GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform = this.m_MultipleGo.transform.Find("ScoreRank/rank/allRank/itemTpl");
			this.m_RankPool.SetupPool(transform.parent.gameObject, transform.gameObject, XVoiceQABehaviour.RANKSHOWNUMBER, false);
		}

		// Token: 0x0400571A RID: 22298
		private static readonly uint RANKSHOWNUMBER = 20U;

		// Token: 0x0400571B RID: 22299
		public IXUIButton m_Close;

		// Token: 0x0400571C RID: 22300
		public GameObject m_SingleGo;

		// Token: 0x0400571D RID: 22301
		public IXUIScrollView m_SingleSrcollView;

		// Token: 0x0400571E RID: 22302
		public IXUIWrapContent m_SingleWrapContent;

		// Token: 0x0400571F RID: 22303
		public GameObject m_MultipleGo;

		// Token: 0x04005720 RID: 22304
		public IXUIScrollView m_MultiSrollView;

		// Token: 0x04005721 RID: 22305
		public IXUIWrapContent m_MultiWrapContent;

		// Token: 0x04005722 RID: 22306
		public XUIPool m_RankPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005723 RID: 22307
		public IXUILabel m_Title;

		// Token: 0x04005724 RID: 22308
		public GameObject m_Start;

		// Token: 0x04005725 RID: 22309
		public GameObject m_Ongoing;

		// Token: 0x04005726 RID: 22310
		public GameObject m_End;

		// Token: 0x04005727 RID: 22311
		public IXUILabel m_QuesNum;

		// Token: 0x04005728 RID: 22312
		public IXUILabel m_QuesDesc;

		// Token: 0x04005729 RID: 22313
		public IXUICheckBox m_AutoPlay;

		// Token: 0x0400572A RID: 22314
		public IXUIButton m_ExitVoiceQA;

		// Token: 0x0400572B RID: 22315
		public IXUIButton m_NextQuestion;

		// Token: 0x0400572C RID: 22316
		public GameObject m_Right;

		// Token: 0x0400572D RID: 22317
		public IXUILabelSymbol m_Reward;

		// Token: 0x0400572E RID: 22318
		public IXUIScrollView m_RankScrollView;

		// Token: 0x0400572F RID: 22319
		public IXUIButton m_Input;

		// Token: 0x04005730 RID: 22320
		public IXUIButton m_SpeakBtn;
	}
}
