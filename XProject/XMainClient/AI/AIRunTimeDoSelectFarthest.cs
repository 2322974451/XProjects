using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeDoSelectFarthest : AIRunTimeNodeAction
	{

		public AIRunTimeDoSelectFarthest(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAITarget>.singleton.DoSelectFarthest(entity);
		}
	}
}
