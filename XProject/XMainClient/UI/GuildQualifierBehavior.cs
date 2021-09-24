using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildQualifierBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Go = (base.transform.FindChild("Bg/Frame/Go").GetComponent("XUIButton") as IXUIButton);
			this.m_RankScrollView = (base.transform.FindChild("Bg/Rank/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_RankWrapContent = (base.transform.FindChild("Bg/Rank/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_FrameScrollView = (base.transform.FindChild("Bg/Frame/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_FrameWrapContent = (base.transform.FindChild("Bg/Frame/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_SelfRankWrapItem = base.transform.FindChild("Bg/Rank/RankTpl");
			this.m_EmptyRank = (base.transform.FindChild("Bg/Rank/EmptyRank").GetComponent("XUILabel") as IXUILabel);
			this.m_SelectAll = (base.transform.FindChild("Bg/Rank/Select/All").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_SelectSelf = (base.transform.FindChild("Bg/Rank/Select/Self").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Time = (base.transform.FindChild("Bg/Frame/Title/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_Rule = (base.transform.FindChild("Bg/Frame/Title/Rule").GetComponent("XUILabel") as IXUILabel);
			this.m_Content = (base.transform.FindChild("Bg/Frame/content").GetComponent("XUILabel") as IXUILabel);
			this.m_unJoin = base.transform.FindChild("Bg/EmptyRank");
			this.m_Rank = base.transform.FindChild("Bg/Rank");
			this.m_Frame = base.transform.FindChild("Bg/Frame");
			this.m_RewardList = base.transform.FindChild("Bg/Frame/Reward");
			Transform transform = base.transform.FindChild("Bg/Frame/Reward/item");
			this.m_RewardPool.SetupPool(transform.parent.parent.gameObject, transform.gameObject, 3U, true);
		}

		public IXUIButton m_Close;

		public IXUIButton m_Go;

		public IXUIScrollView m_RankScrollView;

		public IXUIWrapContent m_RankWrapContent;

		public IXUIScrollView m_FrameScrollView;

		public IXUIWrapContent m_FrameWrapContent;

		public IXUILabel m_Time;

		public IXUILabel m_Rule;

		public IXUILabel m_Content;

		public IXUILabel m_EmptyRank;

		public Transform m_SelfRankWrapItem;

		public IXUICheckBox m_SelectAll;

		public IXUICheckBox m_SelectSelf;

		public Transform m_RewardList;

		public XUIPool m_FrameItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public Transform m_unJoin;

		public Transform m_Rank;

		public Transform m_Frame;
	}
}
