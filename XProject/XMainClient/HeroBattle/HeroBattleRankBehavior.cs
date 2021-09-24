using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class HeroBattleRankBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_OutOfRank = base.transform.Find("Bg/MyRankFrame/QualifyList/OutOfRange").gameObject;
			this.m_MyRankTs = base.transform.Find("Bg/MyRankFrame/QualifyList/Tpl");
			this.m_RankWrapContent = (base.transform.Find("Bg/Panel/QualifyList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_RankScrollView = (base.transform.Find("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIWrapContent m_RankWrapContent;

		public IXUIScrollView m_RankScrollView;

		public Transform m_MyRankTs;

		public GameObject m_OutOfRank;

		public IXUIButton m_CloseBtn;
	}
}
