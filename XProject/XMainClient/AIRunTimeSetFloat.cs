using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AE4 RID: 2788
	internal class AIRunTimeSetFloat : AIRunTimeNodeAction
	{
		// Token: 0x0600A5C3 RID: 42435 RVA: 0x001CE964 File Offset: 0x001CCB64
		public AIRunTimeSetFloat(XmlElement node) : base(node)
		{
			this._value_name = node.GetAttribute("Shared_ValueName");
			this._value = float.Parse(node.GetAttribute("value"));
			this._store_name = node.GetAttribute("Shared_StoredResultName");
		}

		// Token: 0x0600A5C4 RID: 42436 RVA: 0x001CE9B4 File Offset: 0x001CCBB4
		public override bool Update(XEntity entity)
		{
			float floatByName = entity.AI.AIData.GetFloatByName(this._value_name, this._value);
			entity.AI.AIData.SetFloatByName(this._store_name, floatByName);
			return true;
		}

		// Token: 0x04003CDC RID: 15580
		private string _value_name;

		// Token: 0x04003CDD RID: 15581
		private float _value;

		// Token: 0x04003CDE RID: 15582
		private string _store_name;
	}
}
