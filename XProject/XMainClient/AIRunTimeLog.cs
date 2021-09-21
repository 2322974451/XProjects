using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AE5 RID: 2789
	internal class AIRunTimeLog : AIRunTimeNodeAction
	{
		// Token: 0x0600A5C5 RID: 42437 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRunTimeLog(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5C6 RID: 42438 RVA: 0x001CE9FC File Offset: 0x001CCBFC
		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
