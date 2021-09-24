using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeIsOppoCastingSkill : AIRunTimeNodeCondition
	{

		public AIRunTimeIsOppoCastingSkill(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return entity.AI.IsOppoCastingSkill;
		}
	}
}
