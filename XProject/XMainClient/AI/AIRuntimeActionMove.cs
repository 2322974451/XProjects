using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeActionMove : AIRunTimeNodeAction
	{

		public AIRuntimeActionMove(XmlElement node) : base(node)
		{
			this._move_dir = node.GetAttribute("Shared_MoveDirName");
			this._move_dest = node.GetAttribute("Shared_MoveDestName");
			this._move_speed = node.GetAttribute("Shared_MoveSpeedName");
		}

		public override bool Update(XEntity entity)
		{
			Vector3 vector = entity.AI.AIData.GetVector3ByName(this._move_dir, Vector3.zero);
			Vector3 vector2 = entity.AI.AIData.GetVector3ByName(this._move_dest, Vector3.zero);
			bool flag = vector == Vector3.zero;
			if (flag)
			{
				vector = (vector2 - entity.EngineObject.Position).normalized;
				vector.Set(vector.x, 0f, vector.z);
			}
			bool flag2 = vector2 == Vector3.zero;
			if (flag2)
			{
				vector2 = entity.EngineObject.Position + vector.normalized * 50f;
			}
			float floatByName = entity.AI.AIData.GetFloatByName(this._move_speed, 0f);
			return XSingleton<XAIMove>.singleton.ActionMove(entity, vector, vector2, floatByName);
		}

		private string _move_dir;

		private string _move_dest;

		private string _move_speed;
	}
}
