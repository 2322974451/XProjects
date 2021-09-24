using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeSendAIEvent : AIRunTimeNodeAction
	{

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

		public override bool Update(XEntity entity)
		{
			Vector3 vector3ByName = entity.AI.AIData.GetVector3ByName(this._pos_name, this._pos);
			return XSingleton<XAIOtherActions>.singleton.SendAIEvent(entity, this._msg_to, this._msg_type, this._entity_type_id, this._msg_str, vector3ByName, this._delay_time);
		}

		private int _msg_to;

		private int _msg_type;

		private int _entity_type_id;

		private string _msg_str;

		private string _pos_name;

		private Vector3 _pos;

		private float _delay_time;
	}
}
