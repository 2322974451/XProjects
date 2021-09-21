using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AB2 RID: 2738
	internal class AIRunTimeValueMP : AIRunTimeNodeCondition
	{
		// Token: 0x0600A561 RID: 42337 RVA: 0x001CC256 File Offset: 0x001CA456
		public AIRunTimeValueMP(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A562 RID: 42338 RVA: 0x001CC264 File Offset: 0x001CA464
		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
