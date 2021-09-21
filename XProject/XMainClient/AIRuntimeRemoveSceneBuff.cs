using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AA5 RID: 2725
	internal class AIRuntimeRemoveSceneBuff : AIRunTimeNodeAction
	{
		// Token: 0x0600A50F RID: 42255 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRuntimeRemoveSceneBuff(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A510 RID: 42256 RVA: 0x001CB4CC File Offset: 0x001C96CC
		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
