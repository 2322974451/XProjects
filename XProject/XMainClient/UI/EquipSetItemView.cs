using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	internal class EquipSetItemView : EquipSetItemBaseView
	{

		public override void FindFrom(Transform t)
		{
			bool flag = null != t;
			if (flag)
			{
				base.FindFrom(t);
				this.goItem1 = t.Find("Item1").gameObject;
				this.lbItemCount1 = (this.goItem1.transform.Find("FCount").GetComponent("XUILabel") as IXUILabel);
				this.goItem2 = t.Find("Item2").gameObject;
				this.lbItemCount2 = (this.goItem2.transform.Find("FCount").GetComponent("XUILabel") as IXUILabel);
				this.goItem3 = t.Find("Item3").gameObject;
				this.lbItemCount3 = (this.goItem3.transform.Find("FCount").GetComponent("XUILabel") as IXUILabel);
				this.goItem4 = t.Find("Item4").gameObject;
				this.lbItemCount4 = (this.goItem4.transform.Find("FCount").GetComponent("XUILabel") as IXUILabel);
				this.btnCreate = (t.Find("Create").GetComponent("XUIButton") as IXUIButton);
				this.lbCost = (this.btnCreate.gameObject.transform.Find("V").GetComponent("XUILabel") as IXUILabel);
				this.goRedpoint = this.btnCreate.gameObject.transform.Find("RedPoint").gameObject;
			}
		}

		public GameObject goItem1;

		public GameObject goItem2;

		public GameObject goItem3;

		public GameObject goItem4;

		public IXUILabel lbItemCount1;

		public IXUILabel lbItemCount2;

		public IXUILabel lbItemCount3;

		public IXUILabel lbItemCount4;

		public IXUIButton btnCreate;

		public IXUILabel lbCost;

		public GameObject goRedpoint;
	}
}
