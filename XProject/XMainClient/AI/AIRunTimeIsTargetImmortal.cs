using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeIsTargetImmortal : AIRunTimeNodeCondition
	{

		public AIRunTimeIsTargetImmortal(XmlElement node) : base(node)
		{
			this._target_name = node.GetAttribute("Shared_TargetName");
		}

		public override bool Update(XEntity entity)
		{
			XGameObject xgameObjectByName = entity.AI.AIData.GetXGameObjectByName(this._target_name);
			bool flag = xgameObjectByName != null;
			return flag && XSingleton<XAIGeneralMgr>.singleton.IsTargetImmortal(xgameObjectByName.UID);
		}

		private string _target_name;
	}
}
