using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeIsWander : AIRunTimeNodeCondition
	{

		public AIRunTimeIsWander(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return entity.AI.IsWander;
		}
	}
}
