using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AF6 RID: 2806
	internal class AIRunTimeSelectTargetBySkillCircle : AIRunTimeNodeAction
	{
		// Token: 0x0600A5E7 RID: 42471 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRunTimeSelectTargetBySkillCircle(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5E8 RID: 42472 RVA: 0x001CF118 File Offset: 0x001CD318
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAITarget>.singleton.SelectTargetBySkillCircle(entity);
		}
	}
}
