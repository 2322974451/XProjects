using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeValueHP : AIRunTimeNodeCondition
	{

		public AIRunTimeValueHP(XmlElement node) : base(node)
		{
			this._max_hp = int.Parse(node.GetAttribute("MaxPercent"));
			this._min_hp = int.Parse(node.GetAttribute("MinPercent"));
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAIGeneralMgr>.singleton.IsHPValue(entity.ID, this._min_hp, this._max_hp);
		}

		private int _max_hp;

		private int _min_hp;
	}
}
