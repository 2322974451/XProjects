using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AF3 RID: 2803
	internal class AIRunTimeSelectMoveTargetById : AIRunTimeNodeAction
	{
		// Token: 0x0600A5E1 RID: 42465 RVA: 0x001CEFD1 File Offset: 0x001CD1D1
		public AIRunTimeSelectMoveTargetById(XmlElement node) : base(node)
		{
			this._object_id = int.Parse(node.GetAttribute("ObjectId"));
			this._target_name = node.GetAttribute("Shared_MoveTarget");
		}

		// Token: 0x0600A5E2 RID: 42466 RVA: 0x001CF004 File Offset: 0x001CD204
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

		// Token: 0x04003CF8 RID: 15608
		private int _object_id;

		// Token: 0x04003CF9 RID: 15609
		private string _target_name;
	}
}
