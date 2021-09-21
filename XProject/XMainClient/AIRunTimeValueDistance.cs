using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AB0 RID: 2736
	internal class AIRunTimeValueDistance : AIRunTimeNodeCondition
	{
		// Token: 0x0600A55D RID: 42333 RVA: 0x001CC11C File Offset: 0x001CA31C
		public AIRunTimeValueDistance(XmlElement node) : base(node)
		{
			this._target_name = node.GetAttribute("Shared_TargetName");
			this._distance_name = node.GetAttribute("Shared_MaxDistanceName");
			this._distance = float.Parse(node.GetAttribute("Shared_MaxDistancemValue"));
		}

		// Token: 0x0600A55E RID: 42334 RVA: 0x001CC178 File Offset: 0x001CA378
		public override bool Update(XEntity entity)
		{
			XGameObject xgameObjectByName = entity.AI.AIData.GetXGameObjectByName(this._target_name);
			float floatByName = entity.AI.AIData.GetFloatByName(this._distance_name, this._distance);
			bool flag = xgameObjectByName != null;
			return flag && (entity.EngineObject.Position - xgameObjectByName.Position).magnitude <= floatByName;
		}

		// Token: 0x04003C6D RID: 15469
		private string _target_name;

		// Token: 0x04003C6E RID: 15470
		private string _distance_name;

		// Token: 0x04003C6F RID: 15471
		private float _distance = 0f;
	}
}
