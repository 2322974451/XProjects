using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeIsFixedInCd : AIRunTimeNodeCondition
	{

		public AIRunTimeIsFixedInCd(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return entity.AI.IsFixedInCd;
		}
	}
}
