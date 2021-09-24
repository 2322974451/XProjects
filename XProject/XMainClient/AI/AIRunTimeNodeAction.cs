using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeNodeAction : AIRunTimeNodeBase
	{

		public AIRunTimeNodeAction(XmlElement node) : base(node)
		{
			this._type = NodeType.NODE_TYPE_ACTION;
		}
	}
}
