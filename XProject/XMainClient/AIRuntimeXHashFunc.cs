using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AA4 RID: 2724
	internal class AIRuntimeXHashFunc : AIRunTimeNodeAction
	{
		// Token: 0x0600A50D RID: 42253 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRuntimeXHashFunc(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A50E RID: 42254 RVA: 0x001CB4B8 File Offset: 0x001C96B8
		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
