using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeTargetByHatredList : AIRunTimeNodeAction
	{

		public AIRunTimeTargetByHatredList(XmlElement node) : base(node)
		{
			string attribute = node.GetAttribute("FilterImmortal");
			bool.TryParse(attribute, out this._filter_immortal);
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAITarget>.singleton.FindTargetByHartedList(entity, this._filter_immortal);
		}

		private bool _filter_immortal;
	}
}
