using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeCalDistance : AIRunTimeNodeAction
	{

		public AIRunTimeCalDistance(XmlElement node) : base(node)
		{
			this._target_name = node.GetAttribute("Shared_ObjectName");
			this._distance = float.Parse(node.GetAttribute("Shared_DistancemValue"));
			this._distance_name = node.GetAttribute("Shared_DistanceName");
			this._dest_name = node.GetAttribute("Shared_DestPointName");
			string attribute = node.GetAttribute("Shared_DestPointmValue");
			float num = float.Parse(attribute.Split(new char[]
			{
				':'
			})[0]);
			float num2 = float.Parse(attribute.Split(new char[]
			{
				':'
			})[1]);
			float num3 = float.Parse(attribute.Split(new char[]
			{
				':'
			})[2]);
			this._dest_point = new Vector3(num, num2, num3);
		}

		public override bool Update(XEntity entity)
		{
			XGameObject xgameObjectByName = entity.AI.AIData.GetXGameObjectByName(this._target_name);
			bool flag = xgameObjectByName != null;
			float magnitude;
			if (flag)
			{
				magnitude = (entity.EngineObject.Position - xgameObjectByName.Position).magnitude;
			}
			else
			{
				magnitude = (entity.EngineObject.Position - this._dest_point).magnitude;
			}
			entity.AI.AIData.SetFloatByName(this._distance_name, magnitude);
			return true;
		}

		private string _target_name;

		private float _distance;

		private string _distance_name;

		private Vector3 _dest_point;

		private string _dest_name;
	}
}
