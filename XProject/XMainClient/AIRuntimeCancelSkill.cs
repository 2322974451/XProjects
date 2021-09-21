using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000ADC RID: 2780
	internal class AIRuntimeCancelSkill : AIRunTimeNodeAction
	{
		// Token: 0x0600A5B7 RID: 42423 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRuntimeCancelSkill(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5B8 RID: 42424 RVA: 0x001CE208 File Offset: 0x001CC408
		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
