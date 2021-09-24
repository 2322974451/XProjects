using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeValueDistance : AIRunTimeNodeCondition
	{

		public AIRunTimeValueDistance(XmlElement node) : base(node)
		{
			this._target_name = node.GetAttribute("Shared_TargetName");
			this._distance_name = node.GetAttribute("Shared_MaxDistanceName");
			this._distance = float.Parse(node.GetAttribute("Shared_MaxDistancemValue"));
		}

		public override bool Update(XEntity entity)
		{
			XGameObject xgameObjectByName = entity.AI.AIData.GetXGameObjectByName(this._target_name);
			float floatByName = entity.AI.AIData.GetFloatByName(this._distance_name, this._distance);
			bool flag = xgameObjectByName != null;
			return flag && (entity.EngineObject.Position - xgameObjectByName.Position).magnitude <= floatByName;
		}

		private string _target_name;

		private string _distance_name;

		private float _distance = 0f;
	}
}
