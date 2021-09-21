using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AEF RID: 2799
	internal class AIRunTimeFindNavPath : AIRunTimeNodeAction
	{
		// Token: 0x0600A5D9 RID: 42457 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRunTimeFindNavPath(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5DA RID: 42458 RVA: 0x001CEF54 File Offset: 0x001CD154
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAIMove>.singleton.FindNavPath(entity);
		}
	}
}
