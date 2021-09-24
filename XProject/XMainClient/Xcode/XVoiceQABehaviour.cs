using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XVoiceQABehaviour : DlgBehaviourBase
	{

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

		private static readonly uint RANKSHOWNUMBER = 20U;

		public IXUIButton m_Close;

		public GameObject m_SingleGo;

		public IXUIScrollView m_SingleSrcollView;

		public IXUIWrapContent m_SingleWrapContent;

		public GameObject m_MultipleGo;

		public IXUIScrollView m_MultiSrollView;

		public IXUIWrapContent m_MultiWrapContent;

		public XUIPool m_RankPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_Title;

		public GameObject m_Start;

		public GameObject m_Ongoing;

		public GameObject m_End;

		public IXUILabel m_QuesNum;

		public IXUILabel m_QuesDesc;

		public IXUICheckBox m_AutoPlay;

		public IXUIButton m_ExitVoiceQA;

		public IXUIButton m_NextQuestion;

		public GameObject m_Right;

		public IXUILabelSymbol m_Reward;

		public IXUIScrollView m_RankScrollView;

		public IXUIButton m_Input;

		public IXUIButton m_SpeakBtn;
	}
}
