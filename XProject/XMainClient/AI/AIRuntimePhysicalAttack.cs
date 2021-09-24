using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimePhysicalAttack : AIRunTimeNodeAction
	{

		public AIRuntimePhysicalAttack(XmlElement node) : base(node)
		{
			this._target_name = node.GetAttribute("Shared_TargetName");
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAISkill>.singleton.TryCastPhysicalSkill(entity, entity.AI.Target);
		}

		private string _target_name;
	}
}
