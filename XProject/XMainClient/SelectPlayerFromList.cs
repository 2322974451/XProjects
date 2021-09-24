using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class SelectPlayerFromList : AIRunTimeNodeAction
	{

		public SelectPlayerFromList(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAITarget>.singleton.ResetHartedList(entity);
		}
	}
}
