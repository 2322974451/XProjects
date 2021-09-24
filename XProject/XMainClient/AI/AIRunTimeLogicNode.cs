using System;
using System.Collections.Generic;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeLogicNode : AIRunTimeNodeBase
	{

		public AIRunTimeLogicNode(XmlElement node) : base(node)
		{
			this._type = NodeType.NODE_TYPE_LOGIC;
		}

		public override void AddChild(AIRunTimeNodeBase child)
		{
			this._list_node.Add(child);
		}

		protected List<AIRunTimeNodeBase> _list_node = new List<AIRunTimeNodeBase>();
	}
}
