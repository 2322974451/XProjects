using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeIsCastingSkill : AIRunTimeNodeCondition
	{

		public AIRunTimeIsCastingSkill(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return entity.AI.IsCastingSkill;
		}
	}
}
