using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeNavToTarget : AIRunTimeNodeAction
	{

		public AIRuntimeNavToTarget(XmlElement node) : base(node)
		{
			this._target_name = node.GetAttribute("Shared_TargetName");
			this._nav_target_name = node.GetAttribute("Shared_NavTargetName");
			this._nav_pos_name = node.GetAttribute("Shared_NavPosName");
			string attribute = node.GetAttribute("Shared_NavPosmValue");
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
			this._nav_pos = new Vector3(num, num2, num3);
		}

		public override bool Update(XEntity entity)
		{
			XGameObject xgameObjectByName = entity.AI.AIData.GetXGameObjectByName(this._target_name);
			bool flag = xgameObjectByName == null;
			bool result;
			if (flag)
			{
				Transform transformByName = entity.AI.AIData.GetTransformByName(this._nav_target_name);
				bool flag2 = transformByName == null;
				if (flag2)
				{
					bool flag3 = string.IsNullOrEmpty(this._nav_pos_name);
					if (flag3)
					{
						bool flag4 = this._nav_pos == Vector3.zero;
						result = (!flag4 && XSingleton<XAIGeneralMgr>.singleton.ActionNav(entity.ID, this._nav_pos));
					}
					else
					{
						Vector3 vector3ByName = entity.AI.AIData.GetVector3ByName(this._nav_pos_name, Vector3.zero);
						result = XSingleton<XAIGeneralMgr>.singleton.ActionNav(entity.ID, vector3ByName);
					}
				}
				else
				{
					result = XSingleton<XAIGeneralMgr>.singleton.NavToTarget(entity.ID, transformByName.gameObject);
				}
			}
			else
			{
				result = XSingleton<XAIMove>.singleton.NavToTarget(entity, xgameObjectByName.Position, entity.AI.MoveSpeed);
			}
			return result;
		}

		private string _target_name;

		private string _nav_target_name;

		private Vector3 _nav_pos;

		private string _nav_pos_name;
	}
}
