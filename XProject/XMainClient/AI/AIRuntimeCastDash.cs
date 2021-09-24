using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeCastDash : AIRunTimeNodeAction
	{

		public AIRuntimeCastDash(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAISkill>.singleton.CastDashSkill(entity);
		}
	}
}
