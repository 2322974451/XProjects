using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeValueMP : AIRunTimeNodeCondition
	{

		public AIRunTimeValueMP(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
