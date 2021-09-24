using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeDecorationNode : AIRunTimeNodeBase
	{

		public AIRunTimeDecorationNode(XmlElement node) : base(node)
		{
			this._type = NodeType.NODE_TYPE_DECORATION;
		}

		public override void AddChild(AIRunTimeNodeBase child)
		{
			this._child_node = child;
		}

		protected AIRunTimeNodeBase _child_node = null;
	}
}
