using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class PPTBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_PPT = (base.transform.FindChild("Bg/PPT").GetComponent("XUILabel") as IXUILabel);
			this.m_IncreasePPT = (base.transform.FindChild("Bg/Delta/Inc").GetComponent("XUILabel") as IXUILabel);
			this.m_DecreasePPT = (base.transform.FindChild("Bg/Delta/Dec").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUILabel m_PPT;

		public IXUILabel m_IncreasePPT;

		public IXUILabel m_DecreasePPT;
	}
}
