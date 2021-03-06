using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeInverter : AIRunTimeDecorationNode
	{

		public AIRunTimeInverter(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			bool flag = this._child_node != null;
			return flag && !this._child_node.Update(entity);
		}
	}
}
