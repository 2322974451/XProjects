using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeRandomSelectorNode : AIRunTimeLogicNode
	{

		public AIRunTimeRandomSelectorNode(XmlElement node) : base(node)
		{
			this._random_index = new AIRunTimeRandomIndex();
		}

		public override void AddChild(AIRunTimeNodeBase child)
		{
			base.AddChild(child);
			this._random_index.AppendIndex();
		}

		public override bool Update(XEntity entity)
		{
			this._random_index.Rand();
			for (int i = 0; i < this._list_node.Count; i++)
			{
				bool flag = this._list_node[this._random_index[i]].Update(entity);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		protected AIRunTimeRandomIndex _random_index = null;
	}
}
