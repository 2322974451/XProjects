using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeDoSelectSkillRandom : AIRunTimeNodeAction
	{

		public AIRuntimeDoSelectSkillRandom(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAISkill>.singleton.DoSelectRandom(entity);
		}
	}
}
