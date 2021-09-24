using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeRandomEntityPos : AIRunTimeNodeAction
	{

		public AIRunTimeRandomEntityPos(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
