using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AD1 RID: 2769
	internal class AIRuntimeRotateToTarget : AIRunTimeNodeAction
	{
		// Token: 0x0600A5A0 RID: 42400 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRuntimeRotateToTarget(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5A1 RID: 42401 RVA: 0x001CD4D0 File Offset: 0x001CB6D0
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAIMove>.singleton.RotateToTarget(entity);
		}
	}
}
