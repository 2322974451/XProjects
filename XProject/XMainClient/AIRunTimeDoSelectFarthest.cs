using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AF1 RID: 2801
	internal class AIRunTimeDoSelectFarthest : AIRunTimeNodeAction
	{
		// Token: 0x0600A5DD RID: 42461 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRunTimeDoSelectFarthest(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5DE RID: 42462 RVA: 0x001CEF94 File Offset: 0x001CD194
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAITarget>.singleton.DoSelectFarthest(entity);
		}
	}
}
