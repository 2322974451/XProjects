using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A9B RID: 2715
	internal class AIRuntimeReceiveAIEvent : AIRunTimeNodeAction
	{
		// Token: 0x0600A4FE RID: 42238 RVA: 0x001CABC8 File Offset: 0x001C8DC8
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

		// Token: 0x0600A4FF RID: 42239 RVA: 0x001CAD30 File Offset: 0x001C8F30
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

		// Token: 0x04003C23 RID: 15395
		private bool _deprecate;

		// Token: 0x04003C24 RID: 15396
		private int _msg_type;

		// Token: 0x04003C25 RID: 15397
		private string _msg_str;

		// Token: 0x04003C26 RID: 15398
		private int _type_id;

		// Token: 0x04003C27 RID: 15399
		private string _type_id_name;

		// Token: 0x04003C28 RID: 15400
		private Vector3 _pos;

		// Token: 0x04003C29 RID: 15401
		private string _pos_name;

		// Token: 0x04003C2A RID: 15402
		private int _skill_template_id;

		// Token: 0x04003C2B RID: 15403
		private string _skill_template_id_name;

		// Token: 0x04003C2C RID: 15404
		private int _skill_id;

		// Token: 0x04003C2D RID: 15405
		private string _skill_id_name;

		// Token: 0x04003C2E RID: 15406
		private float _float_arg;

		// Token: 0x04003C2F RID: 15407
		private string _float_arg_name;

		// Token: 0x04003C30 RID: 15408
		private string _sender_uid;

		// Token: 0x04003C31 RID: 15409
		private string _sender_uid_name;
	}
}
