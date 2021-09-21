using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000ABC RID: 2748
	internal class AIRunTimeTargetQTEState : AIRunTimeNodeCondition
	{
		// Token: 0x0600A575 RID: 42357 RVA: 0x001CC3D4 File Offset: 0x001CA5D4
		public AIRunTimeTargetQTEState(XmlElement node) : base(node)
		{
			this._target_name = node.GetAttribute("Shared_TargetName");
			this._qte_state = int.Parse(node.GetAttribute("QTEState"));
		}

		// Token: 0x0600A576 RID: 42358 RVA: 0x001CC408 File Offset: 0x001CA608
		public override bool Update(XEntity entity)
		{
			XGameObject xgameObjectByName = entity.AI.AIData.GetXGameObjectByName(this._target_name);
			bool flag = xgameObjectByName != null;
			return flag && XSingleton<XAIGeneralMgr>.singleton.HasQTE(xgameObjectByName.UID, this._qte_state);
		}

		// Token: 0x04003C73 RID: 15475
		private string _target_name;

		// Token: 0x04003C74 RID: 15476
		private int _qte_state;
	}
}
