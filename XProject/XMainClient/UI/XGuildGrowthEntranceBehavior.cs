using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XGuildGrowthEntranceBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this.BuilderBtn = (base.transform.Find("Bg/Rukou0/BuilderBtn").GetComponent("XUIButton") as IXUIButton);
			this.LabBtn = (base.transform.Find("Bg/Rukou1/LabBtn").GetComponent("XUIButton") as IXUIButton);
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIButton BuilderBtn;

		public IXUIButton LabBtn;

		public IXUIButton CloseBtn;
	}
}
