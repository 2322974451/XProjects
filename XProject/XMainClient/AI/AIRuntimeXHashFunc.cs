using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRuntimeXHashFunc : AIRunTimeNodeAction
	{

		public AIRuntimeXHashFunc(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
