using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AF2 RID: 2802
	internal class AIRunTimeDetectEnimyInSight : AIRunTimeNodeAction
	{
		// Token: 0x0600A5DF RID: 42463 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRunTimeDetectEnimyInSight(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5E0 RID: 42464 RVA: 0x001CEFB4 File Offset: 0x001CD1B4
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAIDataRelated>.singleton.DetectEnimyInSight(entity);
		}
	}
}
