using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeTargetQTEState : AIRunTimeNodeCondition
	{

		public AIRunTimeTargetQTEState(XmlElement node) : base(node)
		{
			this._target_name = node.GetAttribute("Shared_TargetName");
			this._qte_state = int.Parse(node.GetAttribute("QTEState"));
		}

		public override bool Update(XEntity entity)
		{
			XGameObject xgameObjectByName = entity.AI.AIData.GetXGameObjectByName(this._target_name);
			bool flag = xgameObjectByName != null;
			return flag && XSingleton<XAIGeneralMgr>.singleton.HasQTE(xgameObjectByName.UID, this._qte_state);
		}

		private string _target_name;

		private int _qte_state;
	}
}
