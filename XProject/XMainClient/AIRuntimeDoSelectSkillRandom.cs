using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AD7 RID: 2775
	internal class AIRuntimeDoSelectSkillRandom : AIRunTimeNodeAction
	{
		// Token: 0x0600A5AD RID: 42413 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRuntimeDoSelectSkillRandom(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5AE RID: 42414 RVA: 0x001CE120 File Offset: 0x001CC320
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAISkill>.singleton.DoSelectRandom(entity);
		}
	}
}
