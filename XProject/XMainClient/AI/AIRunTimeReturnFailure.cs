using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeReturnFailure : AIRunTimeDecorationNode
	{

		public AIRunTimeReturnFailure(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			bool flag = this._child_node != null;
			if (flag)
			{
				this._child_node.Update(entity);
			}
			return false;
		}
	}
}
