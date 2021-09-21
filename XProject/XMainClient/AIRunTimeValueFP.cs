using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AB3 RID: 2739
	internal class AIRunTimeValueFP : AIRunTimeNodeCondition
	{
		// Token: 0x0600A563 RID: 42339 RVA: 0x001CC256 File Offset: 0x001CA456
		public AIRunTimeValueFP(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A564 RID: 42340 RVA: 0x001CC278 File Offset: 0x001CA478
		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
