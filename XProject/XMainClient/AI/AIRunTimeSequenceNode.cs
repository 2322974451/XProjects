using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeSequenceNode : AIRunTimeLogicNode
	{

		public AIRunTimeSequenceNode(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			for (int i = 0; i < this._list_node.Count; i++)
			{
				bool flag = !this._list_node[i].Update(entity);
				if (flag)
				{
					return false;
				}
			}
			return true;
		}
	}
}
