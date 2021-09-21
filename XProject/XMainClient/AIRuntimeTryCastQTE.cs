using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000ADA RID: 2778
	internal class AIRuntimeTryCastQTE : AIRunTimeNodeAction
	{
		// Token: 0x0600A5B3 RID: 42419 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRuntimeTryCastQTE(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5B4 RID: 42420 RVA: 0x001CE1C8 File Offset: 0x001CC3C8
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAISkill>.singleton.CastQTESkill(entity);
		}
	}
}
