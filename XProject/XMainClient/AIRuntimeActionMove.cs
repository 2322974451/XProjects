using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000ACD RID: 2765
	internal class AIRuntimeActionMove : AIRunTimeNodeAction
	{
		// Token: 0x0600A598 RID: 42392 RVA: 0x001CCC2F File Offset: 0x001CAE2F
		public AIRuntimeActionMove(XmlElement node) : base(node)
		{
			this._move_dir = node.GetAttribute("Shared_MoveDirName");
			this._move_dest = node.GetAttribute("Shared_MoveDestName");
			this._move_speed = node.GetAttribute("Shared_MoveSpeedName");
		}

		// Token: 0x0600A599 RID: 42393 RVA: 0x001CCC70 File Offset: 0x001CAE70
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

		// Token: 0x04003C8C RID: 15500
		private string _move_dir;

		// Token: 0x04003C8D RID: 15501
		private string _move_dest;

		// Token: 0x04003C8E RID: 15502
		private string _move_speed;
	}
}
