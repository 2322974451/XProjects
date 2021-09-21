using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AA7 RID: 2727
	internal class AIRunTimeSetEnmity : AIRunTimeNodeAction
	{
		// Token: 0x0600A513 RID: 42259 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRunTimeSetEnmity(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A514 RID: 42260 RVA: 0x001CB4F4 File Offset: 0x001C96F4
		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
