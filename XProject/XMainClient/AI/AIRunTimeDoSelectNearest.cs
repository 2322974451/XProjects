using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeDoSelectNearest : AIRunTimeNodeAction
	{

		public AIRunTimeDoSelectNearest(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAITarget>.singleton.DoSelectNearest(entity);
		}
	}
}
