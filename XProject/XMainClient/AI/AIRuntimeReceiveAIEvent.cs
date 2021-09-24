using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeReceiveAIEvent : AIRunTimeNodeAction
	{

		public AIRuntimeReceiveAIEvent(XmlElement node) : base(node)
		{
			this._msg_type = int.Parse(node.GetAttribute("MsgType"));
			this._msg_str = node.GetAttribute("Shared_MsgStrName");
			this._deprecate = (node.GetAttribute("Deprecate") != "0");
			this._type_id = int.Parse(node.GetAttribute("Shared_TypeIdmValue"));
			this._type_id_name = node.GetAttribute("Shared_TypeIdName");
			string[] array = node.GetAttribute("Shared_PosmValue").Split(new char[]
			{
				':'
			});
			this._pos = new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
			this._pos_name = node.GetAttribute("Shared_PosName");
			this._skill_template_id = int.Parse(node.GetAttribute("Shared_SkillTemplateIdmValue"));
			this._skill_template_id_name = node.GetAttribute("Shared_SkillTemplateIdName");
			this._skill_id = int.Parse(node.GetAttribute("Shared_SkillIdmValue"));
			this._skill_id_name = node.GetAttribute("Shared_SkillIdName");
			this._float_arg = float.Parse(node.GetAttribute("Shared_FloatArgmValue"));
			this._float_arg_name = node.GetAttribute("Shared_FloatArgName");
			this._sender_uid = node.GetAttribute("Shared_SenderUIDmValue");
			this._sender_uid_name = node.GetAttribute("Shared_SenderUIDName");
		}

		public override bool Update(XEntity entity)
		{
			string text = XSingleton<XAIOtherActions>.singleton.ReceiveAIEvent(entity, this._msg_type, this._deprecate);
			bool flag = string.IsNullOrEmpty(text);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				string[] array = text.Split(new char[]
				{
					' '
				});
				entity.AI.AIData.SetStringByName(this._msg_str, array[0]);
				bool flag2 = !string.IsNullOrEmpty(this._type_id_name);
				if (flag2)
				{
					entity.AI.AIData.SetIntByName(this._type_id_name, int.Parse(array[1]));
				}
				bool flag3 = !string.IsNullOrEmpty(this._pos_name);
				if (flag3)
				{
					entity.AI.AIData.SetVector3ByName(this._pos_name, new Vector3(float.Parse(array[2]), float.Parse(array[3]), float.Parse(array[4])));
				}
				bool flag4 = !string.IsNullOrEmpty(this._skill_id_name);
				if (flag4)
				{
					entity.AI.AIData.SetIntByName(this._skill_id_name, int.Parse(array[5]));
				}
				bool flag5 = !string.IsNullOrEmpty(this._sender_uid_name);
				if (flag5)
				{
					entity.AI.AIData.SetStringByName(this._sender_uid_name, array[6]);
				}
				result = true;
			}
			return result;
		}

		private bool _deprecate;

		private int _msg_type;

		private string _msg_str;

		private int _type_id;

		private string _type_id_name;

		private Vector3 _pos;

		private string _pos_name;

		private int _skill_template_id;

		private string _skill_template_id_name;

		private int _skill_id;

		private string _skill_id_name;

		private float _float_arg;

		private string _float_arg_name;

		private string _sender_uid;

		private string _sender_uid_name;
	}
}
