using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DED RID: 3565
	internal abstract class XAttrItem : XItem
	{
		// Token: 0x0600C109 RID: 49417 RVA: 0x0028E3A8 File Offset: 0x0028C5A8
		public IEnumerable<XItemChangeAttr> BasicAttr()
		{
			return this.changeAttr;
		}

		// Token: 0x0600C10A RID: 49418 RVA: 0x0028E3C0 File Offset: 0x0028C5C0
		public override void Init()
		{
			base.Init();
			this.changeAttr.Clear();
		}

		// Token: 0x0600C10B RID: 49419 RVA: 0x0028E3D8 File Offset: 0x0028C5D8
		public override uint GetPPT(XAttributes attributes = null)
		{
			double num = 0.0;
			for (int i = 0; i < this.changeAttr.Count; i++)
			{
				num += XSingleton<XPowerPointCalculator>.singleton.GetPPT(this.changeAttr[i], attributes, -1);
			}
			return (uint)num;
		}

		// Token: 0x04005128 RID: 20776
		public List<XItemChangeAttr> changeAttr = new List<XItemChangeAttr>();
	}
}
