using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeReturnSuccess : AIRunTimeDecorationNode
	{

		public AIRunTimeReturnSuccess(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			bool flag = this._child_node != null;
			if (flag)
			{
				this._child_node.Update(entity);
			}
			return true;
		}
	}
}
