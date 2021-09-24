using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeRootNode : AIRunTimeNodeBase
	{

		public AIRunTimeRootNode(XmlElement node) : base(node)
		{
			this._child = null;
			this._type = NodeType.NODE_TYPE_ROOT;
			this._shared_data = new SharedData();
		}

		public override void AddChild(AIRunTimeNodeBase child)
		{
			this._child = child;
		}

		public override bool Update(XEntity entity)
		{
			return this._child.Update(entity);
		}

		public SharedData Data
		{
			get
			{
				return this._shared_data;
			}
		}

		private AIRunTimeNodeBase _child;

		private SharedData _shared_data;
	}
}
