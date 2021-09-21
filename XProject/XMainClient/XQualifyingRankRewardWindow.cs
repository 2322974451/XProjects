using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E54 RID: 3668
	internal class XQualifyingRankRewardWindow
	{
		// Token: 0x0600C491 RID: 50321 RVA: 0x002AF7A0 File Offset: 0x002AD9A0
		public XQualifyingRankRewardWindow(GameObject go)
		{
			this.m_Go = go;
			this.m_Close = (go.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_RewardPool.SetupPool(go.transform.Find("Bg/Bg/ScrollView").gameObject, go.transform.Find("Bg/Bg/ScrollView/RewardTpl").gameObject, 20U, false);
			this.m_ItemPool.SetupPool(go.transform.FindChild("Bg/Bg/ScrollView/").gameObject, go.transform.FindChild("Bg/Bg/ScrollView/Item").gameObject, 50U, false);
			this.m_ScrollView = (go.transform.Find("Bg/Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_RankNum = (go.transform.Find("Bg/BestRank/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_RewardLeftTime = (go.transform.Find("Bg/LeftTime").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600C492 RID: 50322 RVA: 0x002AF8EC File Offset: 0x002ADAEC
		public void SetVisible(bool v)
		{
			this.m_Go.SetActive(v);
		}

		// Token: 0x1700346D RID: 13421
		// (get) Token: 0x0600C493 RID: 50323 RVA: 0x002AF8FC File Offset: 0x002ADAFC
		public bool IsVisible
		{
			get
			{
				return this.m_Go.activeSelf;
			}
		}

		// Token: 0x040055BE RID: 21950
		public GameObject m_Go;

		// Token: 0x040055BF RID: 21951
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040055C0 RID: 21952
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040055C1 RID: 21953
		public IXUIButton m_Close;

		// Token: 0x040055C2 RID: 21954
		public IXUIScrollView m_ScrollView;

		// Token: 0x040055C3 RID: 21955
		public IXUILabel m_RankNum;

		// Token: 0x040055C4 RID: 21956
		public IXUILabel m_RewardLeftTime;
	}
}
