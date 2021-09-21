using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000DE2 RID: 3554
	internal struct XReinforceInfo
	{
		// Token: 0x0600C0DA RID: 49370 RVA: 0x0028D9A8 File Offset: 0x0028BBA8
		public void Init()
		{
			bool flag = this.ReinforceAttr == null;
			if (flag)
			{
				this.ReinforceAttr = new List<XItemChangeAttr>();
			}
			else
			{
				this.ReinforceAttr.Clear();
			}
			this.ReinforceLevel = 0U;
		}

		// Token: 0x0600C0DB RID: 49371 RVA: 0x0028D9E8 File Offset: 0x0028BBE8
		public void Clone(ref XReinforceInfo other)
		{
			this.Init();
			this.ReinforceLevel = other.ReinforceLevel;
			bool flag = other.ReinforceAttr != null;
			if (flag)
			{
				for (int i = 0; i < other.ReinforceAttr.Count; i++)
				{
					this.ReinforceAttr.Add(other.ReinforceAttr[i]);
				}
			}
		}

		// Token: 0x04005104 RID: 20740
		public uint ReinforceLevel;

		// Token: 0x04005105 RID: 20741
		public List<XItemChangeAttr> ReinforceAttr;
	}
}
