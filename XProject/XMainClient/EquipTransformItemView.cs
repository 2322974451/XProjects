using System;
using UILib;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000CDC RID: 3292
	internal class EquipTransformItemView
	{
		// Token: 0x0600B88A RID: 47242 RVA: 0x00252C44 File Offset: 0x00250E44
		public void FindFrom(Transform trans)
		{
			bool flag = trans != null;
			if (flag)
			{
				Transform transform = trans.Find("EquipOn");
				bool flag2 = transform != null;
				if (flag2)
				{
					this.goEquipOn = transform.gameObject;
				}
				transform = trans.Find("ItemTpl");
				bool flag3 = transform != null;
				if (flag3)
				{
					this.goItem = transform.gameObject;
				}
				bool flag4 = this.goItem != null;
				if (flag4)
				{
					transform = transform.Find("Icon");
					bool flag5 = transform != null;
					if (flag5)
					{
						this.sprIcon = (transform.GetComponent("XUISprite") as IXUISprite);
					}
				}
				transform = trans.Find("FX_wm");
				bool flag6 = transform != null;
				if (flag6)
				{
					this.goFX_wm = transform.gameObject;
				}
				transform = trans.Find("FX_fwm");
				bool flag7 = transform != null;
				if (flag7)
				{
					this.goFX_fwm = transform.gameObject;
				}
				transform = trans.Find("Add");
				bool flag8 = transform != null;
				if (flag8)
				{
					this.goAdd = transform.gameObject;
				}
				transform = trans.Find("Num");
				bool flag9 = transform != null;
				if (flag9)
				{
					this.lbLevel = (transform.GetComponent("XUILabel") as IXUILabel);
				}
			}
		}

		// Token: 0x04004913 RID: 18707
		public IXUISprite sprIcon;

		// Token: 0x04004914 RID: 18708
		public IXUILabel lbLevel;

		// Token: 0x04004915 RID: 18709
		public GameObject goEquipOn;

		// Token: 0x04004916 RID: 18710
		public GameObject goItem;

		// Token: 0x04004917 RID: 18711
		public GameObject goFX_wm;

		// Token: 0x04004918 RID: 18712
		public GameObject goFX_fwm;

		// Token: 0x04004919 RID: 18713
		public GameObject goAdd;
	}
}
