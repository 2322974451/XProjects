using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AA6 RID: 2726
	internal class AIRunTimeRandomEntityPos : AIRunTimeNodeAction
	{
		// Token: 0x0600A511 RID: 42257 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRunTimeRandomEntityPos(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A512 RID: 42258 RVA: 0x001CB4E0 File Offset: 0x001C96E0
		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
