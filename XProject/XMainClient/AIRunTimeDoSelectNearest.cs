using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AF0 RID: 2800
	internal class AIRunTimeDoSelectNearest : AIRunTimeNodeAction
	{
		// Token: 0x0600A5DB RID: 42459 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRunTimeDoSelectNearest(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5DC RID: 42460 RVA: 0x001CEF74 File Offset: 0x001CD174
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAITarget>.singleton.DoSelectNearest(entity);
		}
	}
}
