using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AD8 RID: 2776
	internal class AIRuntimePhysicalAttack : AIRunTimeNodeAction
	{
		// Token: 0x0600A5AF RID: 42415 RVA: 0x001CE13D File Offset: 0x001CC33D
		public AIRuntimePhysicalAttack(XmlElement node) : base(node)
		{
			this._target_name = node.GetAttribute("Shared_TargetName");
		}

		// Token: 0x0600A5B0 RID: 42416 RVA: 0x001CE15C File Offset: 0x001CC35C
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAISkill>.singleton.TryCastPhysicalSkill(entity, entity.AI.Target);
		}

		// Token: 0x04003CB1 RID: 15537
		private string _target_name;
	}
}
