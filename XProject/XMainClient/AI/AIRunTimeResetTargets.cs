using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeResetTargets : AIRunTimeNodeAction
	{

		public AIRunTimeResetTargets(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			XSingleton<XAITarget>.singleton.ResetTargets(entity);
			return true;
		}
	}
}
