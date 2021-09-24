using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRuntimeDetectEnemyInRange : AIRunTimeNodeAction
	{

		public AIRuntimeDetectEnemyInRange(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
