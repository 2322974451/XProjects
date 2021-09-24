using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeSelectNonHartedList : AIRunTimeNodeAction
	{

		public AIRunTimeSelectNonHartedList(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
