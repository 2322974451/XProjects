using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E52 RID: 3666
	internal class XQualifyingPointRewardWindow
	{
		// Token: 0x0600C48B RID: 50315 RVA: 0x002AF548 File Offset: 0x002AD748
		public XQualifyingPointRewardWindow(GameObject go)
		{
			this.m_Go = go;
			this.m_Close = (go.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_RewardPool.SetupPool(go.transform.Find("Bg/Bg/ScrollView").gameObject, go.transform.Find("Bg/Bg/ScrollView/RewardTpl").gameObject, 20U, false);
			this.m_ItemPool.SetupPool(go.transform.FindChild("Bg/Bg/ScrollView").gameObject, go.transform.FindChild("Bg/Bg/ScrollView/Item").gameObject, 50U, false);
			this.m_ScrollView = (go.transform.Find("Bg/Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_CurrentPoint = (go.transform.Find("Bg/CurrentPoint/Text").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600C48C RID: 50316 RVA: 0x002AF66F File Offset: 0x002AD86F
		public void SetVisible(bool v)
		{
			this.m_Go.SetActive(v);
		}

		// Token: 0x1700346B RID: 13419
		// (get) Token: 0x0600C48D RID: 50317 RVA: 0x002AF680 File Offset: 0x002AD880
		public bool IsVisible
		{
			get
			{
				return this.m_Go.activeSelf;
			}
		}

		// Token: 0x040055B3 RID: 21939
		public GameObject m_Go;

		// Token: 0x040055B4 RID: 21940
		public XUIPool m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040055B5 RID: 21941
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040055B6 RID: 21942
		public IXUIButton m_Close;

		// Token: 0x040055B7 RID: 21943
		public IXUIScrollView m_ScrollView;

		// Token: 0x040055B8 RID: 21944
		public IXUILabel m_CurrentPoint;
	}
}
