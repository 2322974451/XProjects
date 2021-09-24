using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRuntimeRemoveSceneBuff : AIRunTimeNodeAction
	{

		public AIRuntimeRemoveSceneBuff(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
