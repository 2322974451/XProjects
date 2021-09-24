using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeSelectTargetBySkillCircle : AIRunTimeNodeAction
	{

		public AIRunTimeSelectTargetBySkillCircle(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAITarget>.singleton.SelectTargetBySkillCircle(entity);
		}
	}
}
