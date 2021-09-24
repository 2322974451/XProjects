using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeIsFighting : AIRunTimeNodeCondition
	{

		public AIRunTimeIsFighting(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return entity.AI.IsFighting;
		}
	}
}
