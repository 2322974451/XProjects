using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AD0 RID: 2768
	internal class AIRuntimeActionRotate : AIRunTimeNodeAction
	{
		// Token: 0x0600A59E RID: 42398 RVA: 0x001CD448 File Offset: 0x001CB648
		public AIRuntimeActionRotate(XmlElement node) : base(node)
		{
			this._rot_degree = float.Parse(node.GetAttribute("RotDegree"));
			this._rot_speed = float.Parse(node.GetAttribute("RotSpeed"));
			this._rot_type = int.Parse(node.GetAttribute("RotType"));
		}

		// Token: 0x0600A59F RID: 42399 RVA: 0x001CD4A0 File Offset: 0x001CB6A0
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAIMove>.singleton.ActionRotate(entity, this._rot_degree, this._rot_speed, this._rot_type);
		}

		// Token: 0x04003C9F RID: 15519
		public float _rot_degree;

		// Token: 0x04003CA0 RID: 15520
		public float _rot_speed;

		// Token: 0x04003CA1 RID: 15521
		public int _rot_type;
	}
}
