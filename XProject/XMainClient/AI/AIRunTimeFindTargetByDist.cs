using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeFindTargetByDist : AIRunTimeNodeAction
	{

		public AIRunTimeFindTargetByDist(XmlElement node) : base(node)
		{
			this._distance_name = node.GetAttribute("Shared_DistanceName");
			this._distance = float.Parse(node.GetAttribute("Shared_DistancemValue"));
			string attribute = node.GetAttribute("FilterImmortal");
			string attribute2 = node.GetAttribute("TargetType");
			string attribute3 = node.GetAttribute("Angle");
			bool flag = !float.TryParse(attribute3, out this._angle);
			if (flag)
			{
				this._angle = 180f;
			}
			string attribute4 = node.GetAttribute("Delta");
			bool flag2 = !float.TryParse(attribute4, out this._delta);
			if (flag2)
			{
				this._delta = 0f;
			}
			bool.TryParse(attribute, out this._filter_immortal);
			bool flag3 = !int.TryParse(attribute2, out this._targettype);
			if (flag3)
			{
				this._targettype = 0;
			}
		}

		public override bool Update(XEntity entity)
		{
			float floatByName = entity.AI.AIData.GetFloatByName(this._distance_name, this._distance);
			return XSingleton<XAITarget>.singleton.FindTargetByDistance(entity, floatByName, this._filter_immortal, this._angle, this._delta, this._targettype);
		}

		private string _distance_name;

		private float _distance;

		private bool _filter_immortal;

		private float _angle;

		private float _delta;

		private int _targettype;
	}
}
