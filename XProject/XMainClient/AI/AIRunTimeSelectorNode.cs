﻿using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeSelectorNode : AIRunTimeLogicNode
	{

		public AIRunTimeSelectorNode(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			for (int i = 0; i < this._list_node.Count; i++)
			{
				bool flag = this._list_node[i].Update(entity);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}
	}
}
