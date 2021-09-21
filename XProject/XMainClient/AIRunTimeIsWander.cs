using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AB8 RID: 2744
	internal class AIRunTimeIsWander : AIRunTimeNodeCondition
	{
		// Token: 0x0600A56D RID: 42349 RVA: 0x001CC256 File Offset: 0x001CA456
		public AIRunTimeIsWander(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A56E RID: 42350 RVA: 0x001CC300 File Offset: 0x001CA500
		public override bool Update(XEntity entity)
		{
			return entity.AI.IsWander;
		}
	}
}
