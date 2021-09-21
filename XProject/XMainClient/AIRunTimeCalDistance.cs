using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AF8 RID: 2808
	internal class AIRunTimeCalDistance : AIRunTimeNodeAction
	{
		// Token: 0x0600A5EB RID: 42475 RVA: 0x001CF14C File Offset: 0x001CD34C
		public AIRunTimeCalDistance(XmlElement node) : base(node)
		{
			this._target_name = node.GetAttribute("Shared_ObjectName");
			this._distance = float.Parse(node.GetAttribute("Shared_DistancemValue"));
			this._distance_name = node.GetAttribute("Shared_DistanceName");
			this._dest_name = node.GetAttribute("Shared_DestPointName");
			string attribute = node.GetAttribute("Shared_DestPointmValue");
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
			this._dest_point = new Vector3(num, num2, num3);
		}

		// Token: 0x0600A5EC RID: 42476 RVA: 0x001CF210 File Offset: 0x001CD410
		public override bool Update(XEntity entity)
		{
			XGameObject xgameObjectByName = entity.AI.AIData.GetXGameObjectByName(this._target_name);
			bool flag = xgameObjectByName != null;
			float magnitude;
			if (flag)
			{
				magnitude = (entity.EngineObject.Position - xgameObjectByName.Position).magnitude;
			}
			else
			{
				magnitude = (entity.EngineObject.Position - this._dest_point).magnitude;
			}
			entity.AI.AIData.SetFloatByName(this._distance_name, magnitude);
			return true;
		}

		// Token: 0x04003CFC RID: 15612
		private string _target_name;

		// Token: 0x04003CFD RID: 15613
		private float _distance;

		// Token: 0x04003CFE RID: 15614
		private string _distance_name;

		// Token: 0x04003CFF RID: 15615
		private Vector3 _dest_point;

		// Token: 0x04003D00 RID: 15616
		private string _dest_name;
	}
}
