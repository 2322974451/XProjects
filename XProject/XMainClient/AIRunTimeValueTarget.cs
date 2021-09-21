using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AAF RID: 2735
	internal class AIRunTimeValueTarget : AIRunTimeNodeCondition
	{
		// Token: 0x0600A55B RID: 42331 RVA: 0x001CC08F File Offset: 0x001CA28F
		public AIRunTimeValueTarget(XmlElement node) : base(node)
		{
			this._shared_target_name = node.GetAttribute("Shared_TargetName");
		}

		// Token: 0x0600A55C RID: 42332 RVA: 0x001CC0AC File Offset: 0x001CA2AC
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

		// Token: 0x04003C6C RID: 15468
		private string _shared_target_name;
	}
}
