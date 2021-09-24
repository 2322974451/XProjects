using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeIsHurtOppo : AIRunTimeNodeCondition
	{

		public AIRunTimeIsHurtOppo(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return entity.AI.IsHurtOppo;
		}
	}
}
