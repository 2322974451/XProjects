using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200176A RID: 5994
	internal class GuildQualifierBehavior : DlgBehaviourBase
	{
		// Token: 0x0600F772 RID: 63346 RVA: 0x00385354 File Offset: 0x00383554
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

		// Token: 0x04006BB9 RID: 27577
		public IXUIButton m_Close;

		// Token: 0x04006BBA RID: 27578
		public IXUIButton m_Go;

		// Token: 0x04006BBB RID: 27579
		public IXUIScrollView m_RankScrollView;

		// Token: 0x04006BBC RID: 27580
		public IXUIWrapContent m_RankWrapContent;

		// Token: 0x04006BBD RID: 27581
		public IXUIScrollView m_FrameScrollView;

		// Token: 0x04006BBE RID: 27582
		public IXUIWrapContent m_FrameWrapContent;

		// Token: 0x04006BBF RID: 27583
		public IXUILabel m_Time;

		// Token: 0x04006BC0 RID: 27584
		public IXUILabel m_Rule;

		// Token: 0x04006BC1 RID: 27585
		public IXUILabel m_Content;

		// Token: 0x04006BC2 RID: 27586
		public IXUILabel m_EmptyRank;

		// Token: 0x04006BC3 RID: 27587
		public Transform m_SelfRankWrapItem;

		// Token: 0x04006BC4 RID: 27588
		public IXUICheckBox m_SelectAll;

		// Token: 0x04006BC5 RID: 27589
		public IXUICheckBox m_SelectSelf;

		// Token: 0x04006BC6 RID: 27590
		public Transform m_RewardList;

		// Token: 0x04006BC7 RID: 27591
		public XUIPool m_FrameItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006BC8 RID: 27592
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006BC9 RID: 27593
		public Transform m_unJoin;

		// Token: 0x04006BCA RID: 27594
		public Transform m_Rank;

		// Token: 0x04006BCB RID: 27595
		public Transform m_Frame;
	}
}
