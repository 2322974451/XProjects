using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AD3 RID: 2771
	internal class AIRuntimeMoveStratage : AIRunTimeNodeAction
	{
		// Token: 0x0600A5A4 RID: 42404 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRuntimeMoveStratage(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5A5 RID: 42405 RVA: 0x001CD558 File Offset: 0x001CB758
		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
