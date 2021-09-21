using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AE7 RID: 2791
	internal class AIRunTimeBoolComparison : AIRunTimeNodeAction
	{
		// Token: 0x0600A5C9 RID: 42441 RVA: 0x001CEAAC File Offset: 0x001CCCAC
		public AIRunTimeBoolComparison(XmlElement node) : base(node)
		{
			this._bool_name1 = node.GetAttribute("Shared_Bool1Name");
			this._bool_value1 = (node.GetAttribute("bool1Value") != "0");
			this._bool_name2 = node.GetAttribute("Shared_Bool2Name");
			this._bool_value2 = (node.GetAttribute("bool2Value") != "0");
		}

		// Token: 0x0600A5CA RID: 42442 RVA: 0x001CEB1C File Offset: 0x001CCD1C
		public override bool Update(XEntity entity)
		{
			bool boolByName = entity.AI.AIData.GetBoolByName(this._bool_name1, this._bool_value1);
			bool boolByName2 = entity.AI.AIData.GetBoolByName(this._bool_name2, this._bool_value2);
			return boolByName == boolByName2;
		}

		// Token: 0x04003CE2 RID: 15586
		private string _bool_name1;

		// Token: 0x04003CE3 RID: 15587
		private bool _bool_value1;

		// Token: 0x04003CE4 RID: 15588
		private string _bool_name2;

		// Token: 0x04003CE5 RID: 15589
		private bool _bool_value2;
	}
}
