using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XWeddingCostBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.DrawItem = base.transform.Find("ItemTpl").gameObject;
			this.TipLabel = (base.transform.Find("Tip").GetComponent("XUILabel") as IXUILabel);
			this.SecondTitle = (base.transform.Find("Bg/Tip").GetComponent("XUILabel") as IXUILabel);
			this.TitleLabel = (base.transform.Find("Title").GetComponent("XUILabel") as IXUILabel);
			this.CostTip = (base.transform.Find("CostTip").GetComponent("XUILabel") as IXUILabel);
			this.NumLabel = (base.transform.Find("TipNum").GetComponent("XUILabel") as IXUILabel);
			this.Close = (base.transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.OkBtn = (base.transform.Find("SureBtn").GetComponent("XUIButton") as IXUIButton);
			this.Cancel = (base.transform.Find("Cancel").GetComponent("XUIButton") as IXUIButton);
		}

		public GameObject DrawItem = null;

		public IXUILabel TitleLabel = null;

		public IXUILabel SecondTitle = null;

		public IXUILabel TipLabel = null;

		public IXUILabel CostTip = null;

		public IXUILabel NumLabel = null;

		public IXUIButton Close;

		public IXUIButton OkBtn;

		public IXUIButton Cancel;
	}
}
