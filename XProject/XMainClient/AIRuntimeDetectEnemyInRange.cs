using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AA3 RID: 2723
	internal class AIRuntimeDetectEnemyInRange : AIRunTimeNodeAction
	{
		// Token: 0x0600A50B RID: 42251 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRuntimeDetectEnemyInRange(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A50C RID: 42252 RVA: 0x001CB4A4 File Offset: 0x001C96A4
		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
