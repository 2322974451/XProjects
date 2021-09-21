using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000ABA RID: 2746
	internal class AIRunTimeIsFighting : AIRunTimeNodeCondition
	{
		// Token: 0x0600A571 RID: 42353 RVA: 0x001CC256 File Offset: 0x001CA456
		public AIRunTimeIsFighting(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A572 RID: 42354 RVA: 0x001CC340 File Offset: 0x001CA540
		public override bool Update(XEntity entity)
		{
			return entity.AI.IsFighting;
		}
	}
}
