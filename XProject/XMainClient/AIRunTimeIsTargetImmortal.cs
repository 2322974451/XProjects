using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000ABE RID: 2750
	internal class AIRunTimeIsTargetImmortal : AIRunTimeNodeCondition
	{
		// Token: 0x0600A578 RID: 42360 RVA: 0x001CC454 File Offset: 0x001CA654
		public AIRunTimeIsTargetImmortal(XmlElement node) : base(node)
		{
			this._target_name = node.GetAttribute("Shared_TargetName");
		}

		// Token: 0x0600A579 RID: 42361 RVA: 0x001CC470 File Offset: 0x001CA670
		public override bool Update(XEntity entity)
		{
			XGameObject xgameObjectByName = entity.AI.AIData.GetXGameObjectByName(this._target_name);
			bool flag = xgameObjectByName != null;
			return flag && XSingleton<XAIGeneralMgr>.singleton.IsTargetImmortal(xgameObjectByName.UID);
		}

		// Token: 0x04003C75 RID: 15477
		private string _target_name;
	}
}
