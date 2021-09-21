using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001762 RID: 5986
	public class GuildInheritProcessBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600F731 RID: 63281 RVA: 0x00383414 File Offset: 0x00381614
		private void Awake()
		{
			this.mProcessSlider = (base.transform.FindChild("Bg/Process").GetComponent("XUISlider") as IXUISlider);
			this.mProcessLabel = (base.transform.FindChild("Bg/ProcessLabel").GetComponent("XUILabel") as IXUILabel);
			this.mContentLabel = (base.transform.FindChild("Bg/Content").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04006B7B RID: 27515
		protected internal IXUISlider mProcessSlider;

		// Token: 0x04006B7C RID: 27516
		protected internal IXUILabel mProcessLabel;

		// Token: 0x04006B7D RID: 27517
		protected internal IXUILabel mContentLabel;
	}
}
