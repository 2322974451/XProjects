using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeValueTarget : AIRunTimeNodeCondition
	{

		public AIRunTimeValueTarget(XmlElement node) : base(node)
		{
			this._shared_target_name = node.GetAttribute("Shared_TargetName");
		}

		public override bool Update(XEntity entity)
		{
			XGameObject xgameObjectByName = entity.AI.AIData.GetXGameObjectByName(this._shared_target_name);
			XEntity xentity = null;
			bool flag = xgameObjectByName != null;
			if (flag)
			{
				xentity = XSingleton<XEntityMgr>.singleton.GetEntity(xgameObjectByName.UID);
			}
			bool flag2 = xgameObjectByName != null && xentity != null && XEntity.ValideEntity(xentity);
			bool result;
			if (flag2)
			{
				result = true;
			}
			else
			{
				entity.AI.SetTarget(null);
				result = false;
			}
			return result;
		}

		private string _shared_target_name;
	}
}
