using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeNodeCondition : AIRunTimeNodeBase
	{

		public AIRunTimeNodeCondition(XmlElement node) : base(node)
		{
			this._type = NodeType.NODE_TYPE_CONDITION;
		}

		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
