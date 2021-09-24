using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeDoCastSkill : AIRunTimeNodeAction
	{

		public AIRuntimeDoCastSkill(XmlElement node) : base(node)
		{
			this._target_name = node.GetAttribute("Shared_TargetName");
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAISkill>.singleton.DoCastSkill(entity, entity.AI.Target);
		}

		private string _target_name;
	}
}
