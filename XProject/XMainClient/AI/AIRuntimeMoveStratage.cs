using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRuntimeMoveStratage : AIRunTimeNodeAction
	{

		public AIRuntimeMoveStratage(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
