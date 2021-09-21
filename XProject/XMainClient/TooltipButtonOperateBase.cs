using System;

namespace XMainClient
{
	// Token: 0x02000E7B RID: 3707
	internal abstract class TooltipButtonOperateBase
	{
		// Token: 0x0600C66F RID: 50799
		public abstract string GetButtonText();

		// Token: 0x0600C670 RID: 50800
		public abstract bool HasRedPoint(XItem item);

		// Token: 0x0600C671 RID: 50801
		public abstract bool IsButtonVisible(XItem item);

		// Token: 0x0600C672 RID: 50802 RVA: 0x002BEED8 File Offset: 0x002BD0D8
		public virtual void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			this.mainItemUID = mainUID;
			this.compareItemUID = compareUID;
		}

		// Token: 0x0400570F RID: 22287
		protected ulong compareItemUID;

		// Token: 0x04005710 RID: 22288
		protected ulong mainItemUID;
	}
}
