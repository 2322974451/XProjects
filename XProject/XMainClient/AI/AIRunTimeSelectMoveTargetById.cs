using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeSelectMoveTargetById : AIRunTimeNodeAction
	{

		public AIRunTimeSelectMoveTargetById(XmlElement node) : base(node)
		{
			this._object_id = int.Parse(node.GetAttribute("ObjectId"));
			this._target_name = node.GetAttribute("Shared_MoveTarget");
		}

		public override bool Update(XEntity entity)
		{
			XGameObject xgameObject = XSingleton<XAITarget>.singleton.SelectMoveTargetById(entity, this._object_id);
			bool flag = xgameObject == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				entity.AI.AIData.SetXGameObjectByName(this._target_name, xgameObject);
				result = true;
			}
			return result;
		}

		private int _object_id;

		private string _target_name;
	}
}
