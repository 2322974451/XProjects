using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeNodeBase
	{

		public AIRunTimeNodeBase(XmlElement node)
		{
			this._type = NodeType.NODE_TYPE_BASE;
		}

		public virtual bool Update(XEntity entity)
		{
			return true;
		}

		public virtual void AddChild(AIRunTimeNodeBase child)
		{
		}

		public NodeType GetNodeType()
		{
			return this._type;
		}

		public virtual void Print()
		{
		}

		protected NodeType _type;
	}
}
