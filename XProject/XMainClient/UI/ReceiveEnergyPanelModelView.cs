using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x02001710 RID: 5904
	internal class ReceiveEnergyPanelModelView
	{
		// Token: 0x0600F3BC RID: 62396 RVA: 0x00367320 File Offset: 0x00365520
		public void FindFrom(Transform t)
		{
			bool flag = null == t;
			if (!flag)
			{
				this.m_lbNum = (t.GetComponent("XUILabel") as IXUILabel);
				this.m_sprFinish = (t.Find("F").GetComponent("XUISprite") as IXUISprite);
				this.m_EnerySpr = (t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite);
				Transform transform = t.FindChild("Item");
				bool flag2 = transform != null;
				if (flag2)
				{
					this.m_ItemGo = transform.gameObject;
					this.m_ItemNumLab = (transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel);
					this.m_ItemIcon = (transform.FindChild("Icon1").GetComponent("XUISprite") as IXUISprite);
				}
			}
		}

		// Token: 0x040068A2 RID: 26786
		public IXUILabel m_lbNum;

		// Token: 0x040068A3 RID: 26787
		public IXUISprite m_sprFinish;

		// Token: 0x040068A4 RID: 26788
		public IXUISprite m_EnerySpr;

		// Token: 0x040068A5 RID: 26789
		public GameObject m_ItemGo;

		// Token: 0x040068A6 RID: 26790
		public IXUISprite m_ItemIcon;

		// Token: 0x040068A7 RID: 26791
		public IXUILabel m_ItemNumLab;
	}
}
