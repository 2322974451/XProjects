using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AEC RID: 2796
	internal class AIRunTimeFindTargetByDist : AIRunTimeNodeAction
	{
		// Token: 0x0600A5D3 RID: 42451 RVA: 0x001CED78 File Offset: 0x001CCF78
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

		// Token: 0x0600A5D4 RID: 42452 RVA: 0x001CEE50 File Offset: 0x001CD050
		public override bool Update(XEntity entity)
		{
			float floatByName = entity.AI.AIData.GetFloatByName(this._distance_name, this._distance);
			return XSingleton<XAITarget>.singleton.FindTargetByDistance(entity, floatByName, this._filter_immortal, this._angle, this._delta, this._targettype);
		}

		// Token: 0x04003CF0 RID: 15600
		private string _distance_name;

		// Token: 0x04003CF1 RID: 15601
		private float _distance;

		// Token: 0x04003CF2 RID: 15602
		private bool _filter_immortal;

		// Token: 0x04003CF3 RID: 15603
		private float _angle;

		// Token: 0x04003CF4 RID: 15604
		private float _delta;

		// Token: 0x04003CF5 RID: 15605
		private int _targettype;
	}
}
