using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A9C RID: 2716
	internal class AIRuntimeSendAIEvent : AIRunTimeNodeAction
	{
		// Token: 0x0600A500 RID: 42240 RVA: 0x001CAE74 File Offset: 0x001C9074
		public AIRuntimeSendAIEvent(XmlElement node) : base(node)
		{
			this._msg_to = int.Parse(node.GetAttribute("MsgTo"));
			this._msg_type = int.Parse(node.GetAttribute("MsgType"));
			this._entity_type_id = int.Parse(node.GetAttribute("EntityTypeId"));
			this._msg_str = node.GetAttribute("MsgStr");
			this._pos_name = node.GetAttribute("Shared_PosName");
			this._delay_time = float.Parse(node.GetAttribute("DelayTime"));
			string[] array = node.GetAttribute("Shared_PosmValue").Split(new char[]
			{
				':'
			});
			this._pos = new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
		}

		// Token: 0x0600A501 RID: 42241 RVA: 0x001CAF44 File Offset: 0x001C9144
		public override bool Update(XEntity entity)
		{
			Vector3 vector3ByName = entity.AI.AIData.GetVector3ByName(this._pos_name, this._pos);
			return XSingleton<XAIOtherActions>.singleton.SendAIEvent(entity, this._msg_to, this._msg_type, this._entity_type_id, this._msg_str, vector3ByName, this._delay_time);
		}

		// Token: 0x04003C32 RID: 15410
		private int _msg_to;

		// Token: 0x04003C33 RID: 15411
		private int _msg_type;

		// Token: 0x04003C34 RID: 15412
		private int _entity_type_id;

		// Token: 0x04003C35 RID: 15413
		private string _msg_str;

		// Token: 0x04003C36 RID: 15414
		private string _pos_name;

		// Token: 0x04003C37 RID: 15415
		private Vector3 _pos;

		// Token: 0x04003C38 RID: 15416
		private float _delay_time;
	}
}
