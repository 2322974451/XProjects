using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeRotateToTarget : AIRunTimeNodeAction
	{

		public AIRuntimeRotateToTarget(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAIMove>.singleton.RotateToTarget(entity);
		}
	}
}
