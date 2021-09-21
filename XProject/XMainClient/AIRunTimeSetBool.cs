using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AE6 RID: 2790
	internal class AIRunTimeSetBool : AIRunTimeNodeAction
	{
		// Token: 0x0600A5C7 RID: 42439 RVA: 0x001CEA10 File Offset: 0x001CCC10
		public AIRunTimeSetBool(XmlElement node) : base(node)
		{
			this._value_name = node.GetAttribute("Shared_ValueName");
			this._value = (node.GetAttribute("value") != "0");
			this._store_name = node.GetAttribute("Shared_StoredResultName");
		}

		// Token: 0x0600A5C8 RID: 42440 RVA: 0x001CEA64 File Offset: 0x001CCC64
		public override bool Update(XEntity entity)
		{
			bool boolByName = entity.AI.AIData.GetBoolByName(this._value_name, this._value);
			entity.AI.AIData.SetBoolByName(this._store_name, boolByName);
			return true;
		}

		// Token: 0x04003CDF RID: 15583
		private string _value_name;

		// Token: 0x04003CE0 RID: 15584
		private bool _value;

		// Token: 0x04003CE1 RID: 15585
		private string _store_name;
	}
}
