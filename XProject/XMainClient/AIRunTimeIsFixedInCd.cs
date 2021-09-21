using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AB7 RID: 2743
	internal class AIRunTimeIsFixedInCd : AIRunTimeNodeCondition
	{
		// Token: 0x0600A56B RID: 42347 RVA: 0x001CC256 File Offset: 0x001CA456
		public AIRunTimeIsFixedInCd(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A56C RID: 42348 RVA: 0x001CC2E0 File Offset: 0x001CA4E0
		public override bool Update(XEntity entity)
		{
			return entity.AI.IsFixedInCd;
		}
	}
}
