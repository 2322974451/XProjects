using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeStatusIdle : AIRunTimeNodeCondition
	{

		public AIRunTimeStatusIdle(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
