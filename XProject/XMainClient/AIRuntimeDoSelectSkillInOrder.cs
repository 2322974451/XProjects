using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AD6 RID: 2774
	internal class AIRuntimeDoSelectSkillInOrder : AIRunTimeNodeAction
	{
		// Token: 0x0600A5AB RID: 42411 RVA: 0x001CB338 File Offset: 0x001C9538
		public AIRuntimeDoSelectSkillInOrder(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A5AC RID: 42412 RVA: 0x001CE100 File Offset: 0x001CC300
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAISkill>.singleton.DoSelectInOrder(entity);
		}
	}
}
