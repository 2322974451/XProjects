using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AD9 RID: 2777
	internal class AIRuntimeDoCastSkill : AIRunTimeNodeAction
	{
		// Token: 0x0600A5B1 RID: 42417 RVA: 0x001CE184 File Offset: 0x001CC384
		public AIRuntimeDoCastSkill(XmlElement node) : base(node)
		{
			this._target_name = node.GetAttribute("Shared_TargetName");
		}

		// Token: 0x0600A5B2 RID: 42418 RVA: 0x001CE1A0 File Offset: 0x001CC3A0
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAISkill>.singleton.DoCastSkill(entity, entity.AI.Target);
		}

		// Token: 0x04003CB2 RID: 15538
		private string _target_name;
	}
}
