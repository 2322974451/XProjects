using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	internal class ReceiveEnergyPanelModelView
	{

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

		public IXUILabel m_lbNum;

		public IXUISprite m_sprFinish;

		public IXUISprite m_EnerySpr;

		public GameObject m_ItemGo;

		public IXUISprite m_ItemIcon;

		public IXUILabel m_ItemNumLab;
	}
}
