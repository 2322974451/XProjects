using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AEB RID: 2795
	internal class AIRunTimeResetTargets : AIRunTimeNodeAction
	{
		// Token: 0x0600A5D1 RID: 42449 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRunTimeResetTargets(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5D2 RID: 42450 RVA: 0x001CED58 File Offset: 0x001CCF58
		public override bool Update(XEntity entity)
		{
			XSingleton<XAITarget>.singleton.ResetTargets(entity);
			return true;
		}
	}
}
