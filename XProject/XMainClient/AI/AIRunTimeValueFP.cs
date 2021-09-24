using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeValueFP : AIRunTimeNodeCondition
	{

		public AIRunTimeValueFP(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
