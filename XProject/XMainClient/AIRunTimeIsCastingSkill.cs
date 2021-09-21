using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AB9 RID: 2745
	internal class AIRunTimeIsCastingSkill : AIRunTimeNodeCondition
	{
		// Token: 0x0600A56F RID: 42351 RVA: 0x001CC256 File Offset: 0x001CA456
		public AIRunTimeIsCastingSkill(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A570 RID: 42352 RVA: 0x001CC320 File Offset: 0x001CA520
		public override bool Update(XEntity entity)
		{
			return entity.AI.IsCastingSkill;
		}
	}
}
