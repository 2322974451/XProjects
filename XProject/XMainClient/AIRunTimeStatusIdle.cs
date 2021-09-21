using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AB4 RID: 2740
	internal class AIRunTimeStatusIdle : AIRunTimeNodeCondition
	{
		// Token: 0x0600A565 RID: 42341 RVA: 0x001CC256 File Offset: 0x001CA456
		public AIRunTimeStatusIdle(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A566 RID: 42342 RVA: 0x001CC28C File Offset: 0x001CA48C
		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
