using System;
using UILib;
using UnityEngine;

namespace XMainClient
{

	internal class EquipTransformItemView
	{

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

		public IXUISprite sprIcon;

		public IXUILabel lbLevel;

		public GameObject goEquipOn;

		public GameObject goItem;

		public GameObject goFX_wm;

		public GameObject goFX_fwm;

		public GameObject goAdd;
	}
}
