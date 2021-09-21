using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000ADB RID: 2779
	internal class AIRuntimeCastDash : AIRunTimeNodeAction
	{
		// Token: 0x0600A5B5 RID: 42421 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRuntimeCastDash(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5B6 RID: 42422 RVA: 0x001CE1E8 File Offset: 0x001CC3E8
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAISkill>.singleton.CastDashSkill(entity);
		}
	}
}
