using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeFindNavPath : AIRunTimeNodeAction
	{

		public AIRunTimeFindNavPath(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAIMove>.singleton.FindNavPath(entity);
		}
	}
}
