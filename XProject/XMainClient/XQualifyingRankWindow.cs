using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E53 RID: 3667
	internal class XQualifyingRankWindow
	{
		// Token: 0x0600C48E RID: 50318 RVA: 0x002AF6A0 File Offset: 0x002AD8A0
		public XQualifyingRankWindow(GameObject go)
		{
			this.m_Go = go;
			this.m_Close = (go.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_RolePool.SetupPool(go.transform.Find("Bg/Bg/ScrollView").gameObject, go.transform.Find("Bg/Bg/ScrollView/RoleTpl").gameObject, 100U, false);
			this.m_ScrollView = (go.transform.Find("Bg/Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_TabTpl = go.transform.Find("Tabs/TabTpl").gameObject;
		}

		// Token: 0x0600C48F RID: 50319 RVA: 0x002AF76F File Offset: 0x002AD96F
		public void SetVisible(bool v)
		{
			this.m_Go.SetActive(v);
		}

		// Token: 0x1700346C RID: 13420
		// (get) Token: 0x0600C490 RID: 50320 RVA: 0x002AF780 File Offset: 0x002AD980
		public bool IsVisible
		{
			get
			{
				return this.m_Go.activeSelf;
			}
		}

		// Token: 0x040055B9 RID: 21945
		public GameObject m_Go;

		// Token: 0x040055BA RID: 21946
		public XUIPool m_RolePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040055BB RID: 21947
		public IXUIButton m_Close;

		// Token: 0x040055BC RID: 21948
		public IXUIScrollView m_ScrollView;

		// Token: 0x040055BD RID: 21949
		public GameObject m_TabTpl;
	}
}
