using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeFindTargetByHitLevel : AIRunTimeNodeAction
	{

		public AIRunTimeFindTargetByHitLevel(XmlElement node) : base(node)
		{
			string attribute = node.GetAttribute("FilterImmortal");
			int num = 0;
			int.TryParse(attribute, out num);
			this._filter_immortal = (num != 0);
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAITarget>.singleton.FindTargetByHitLevel(entity, this._filter_immortal);
		}

		private bool _filter_immortal;
	}
}
