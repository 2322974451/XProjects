using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeSetEnmity : AIRunTimeNodeAction
	{

		public AIRunTimeSetEnmity(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
