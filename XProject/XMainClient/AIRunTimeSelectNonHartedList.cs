using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AF7 RID: 2807
	internal class AIRunTimeSelectNonHartedList : AIRunTimeNodeAction
	{
		// Token: 0x0600A5E9 RID: 42473 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRunTimeSelectNonHartedList(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5EA RID: 42474 RVA: 0x001CF138 File Offset: 0x001CD338
		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
