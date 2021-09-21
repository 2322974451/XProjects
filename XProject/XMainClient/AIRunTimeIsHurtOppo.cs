using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AB6 RID: 2742
	internal class AIRunTimeIsHurtOppo : AIRunTimeNodeCondition
	{
		// Token: 0x0600A569 RID: 42345 RVA: 0x001CC256 File Offset: 0x001CA456
		public AIRunTimeIsHurtOppo(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A56A RID: 42346 RVA: 0x001CC2C0 File Offset: 0x001CA4C0
		public override bool Update(XEntity entity)
		{
			return entity.AI.IsHurtOppo;
		}
	}
}
