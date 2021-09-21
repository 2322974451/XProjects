using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x0200184F RID: 6223
	internal class PPTBehaviour : DlgBehaviourBase
	{
		// Token: 0x060102E7 RID: 66279 RVA: 0x003E2F5C File Offset: 0x003E115C
		private void Awake()
		{
			this.m_PPT = (base.transform.FindChild("Bg/PPT").GetComponent("XUILabel") as IXUILabel);
			this.m_IncreasePPT = (base.transform.FindChild("Bg/Delta/Inc").GetComponent("XUILabel") as IXUILabel);
			this.m_DecreasePPT = (base.transform.FindChild("Bg/Delta/Dec").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x040073E6 RID: 29670
		public IXUILabel m_PPT;

		// Token: 0x040073E7 RID: 29671
		public IXUILabel m_IncreasePPT;

		// Token: 0x040073E8 RID: 29672
		public IXUILabel m_DecreasePPT;
	}
}
