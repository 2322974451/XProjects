using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AB5 RID: 2741
	internal class AIRunTimeIsOppoCastingSkill : AIRunTimeNodeCondition
	{
		// Token: 0x0600A567 RID: 42343 RVA: 0x001CC256 File Offset: 0x001CA456
		public AIRunTimeIsOppoCastingSkill(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A568 RID: 42344 RVA: 0x001CC2A0 File Offset: 0x001CA4A0
		public override bool Update(XEntity entity)
		{
			return entity.AI.IsOppoCastingSkill;
		}
	}
}
