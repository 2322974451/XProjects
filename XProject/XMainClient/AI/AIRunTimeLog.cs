using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeLog : AIRunTimeNodeAction
	{

		public AIRunTimeLog(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
