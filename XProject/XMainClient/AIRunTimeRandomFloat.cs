using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000ADF RID: 2783
	internal class AIRunTimeRandomFloat : AIRunTimeNodeAction
	{
		// Token: 0x0600A5B9 RID: 42425 RVA: 0x001CE21C File Offset: 0x001CC41C
		public AIRunTimeRandomFloat(XmlElement node) : base(node)
		{
			this._min_value = float.Parse(node.GetAttribute("minValue"));
			this._min_name = node.GetAttribute("Shared_MinName");
			this._max_value = float.Parse(node.GetAttribute("maxValue"));
			this._max_name = node.GetAttribute("Shared_MaxName");
			this._store_result_name = node.GetAttribute("Shared_StoredResultName");
		}

		// Token: 0x0600A5BA RID: 42426 RVA: 0x001CE294 File Offset: 0x001CC494
		public override bool Update(XEntity entity)
		{
			float floatByName = entity.AI.AIData.GetFloatByName(this._min_name, this._min_value);
			float floatByName2 = entity.AI.AIData.GetFloatByName(this._max_name, this._max_value);
			float para = XSingleton<XCommon>.singleton.RandomFloat(floatByName, floatByName2);
			entity.AI.AIData.SetFloatByName(this._store_result_name, para);
			return true;
		}

		// Token: 0x04003CC1 RID: 15553
		private float _min_value;

		// Token: 0x04003CC2 RID: 15554
		private string _min_name;

		// Token: 0x04003CC3 RID: 15555
		private float _max_value;

		// Token: 0x04003CC4 RID: 15556
		private string _max_name;

		// Token: 0x04003CC5 RID: 15557
		private string _store_result_name;
	}
}
