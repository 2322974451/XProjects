using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AE9 RID: 2793
	internal class AIRunTimeSetInt : AIRunTimeNodeAction
	{
		// Token: 0x0600A5CD RID: 42445 RVA: 0x001CEC68 File Offset: 0x001CCE68
		public AIRunTimeSetInt(XmlElement node) : base(node)
		{
			this._value_name = node.GetAttribute("Shared_ValueName");
			this._value = int.Parse(node.GetAttribute("value"));
			this._store_name = node.GetAttribute("Shared_StoredResultName");
		}

		// Token: 0x0600A5CE RID: 42446 RVA: 0x001CECB8 File Offset: 0x001CCEB8
		public override bool Update(XEntity entity)
		{
			int intByName = entity.AI.AIData.GetIntByName(this._value_name, this._value);
			entity.AI.AIData.SetIntByName(this._store_name, intByName);
			return true;
		}

		// Token: 0x04003CEB RID: 15595
		private string _value_name;

		// Token: 0x04003CEC RID: 15596
		private int _value;

		// Token: 0x04003CED RID: 15597
		private string _store_name;
	}
}
