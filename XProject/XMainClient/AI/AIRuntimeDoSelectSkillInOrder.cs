using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeDoSelectSkillInOrder : AIRunTimeNodeAction
	{

		public AIRuntimeDoSelectSkillInOrder(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAISkill>.singleton.DoSelectInOrder(entity);
		}
	}
}
