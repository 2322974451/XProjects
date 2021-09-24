using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeTryCastQTE : AIRunTimeNodeAction
	{

		public AIRuntimeTryCastQTE(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAISkill>.singleton.CastQTESkill(entity);
		}
	}
}
