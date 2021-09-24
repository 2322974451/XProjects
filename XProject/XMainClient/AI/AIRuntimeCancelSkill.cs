using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRuntimeCancelSkill : AIRunTimeNodeAction
	{

		public AIRuntimeCancelSkill(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
