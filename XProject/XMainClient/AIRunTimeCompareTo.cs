using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AE8 RID: 2792
	internal class AIRunTimeCompareTo : AIRunTimeNodeAction
	{
		// Token: 0x0600A5CB RID: 42443 RVA: 0x001CEB6C File Offset: 0x001CCD6C
		public AIRunTimeCompareTo(XmlElement node) : base(node)
		{
			this._first_string_name = node.GetAttribute("Shared_FirstStringName");
			this._first_string_value = node.GetAttribute("firstString");
			this._second_string_name = node.GetAttribute("Shared_SecondStringName");
			this._second_string_value = node.GetAttribute("secondString");
			this._store_result_name = node.GetAttribute("Shared_ResultName");
		}

		// Token: 0x0600A5CC RID: 42444 RVA: 0x001CEBD8 File Offset: 0x001CCDD8
		public override bool Update(XEntity entity)
		{
			string stringByName = entity.AI.AIData.GetStringByName(this._first_string_name, this._first_string_value);
			string stringByName2 = entity.AI.AIData.GetStringByName(this._second_string_name, this._second_string_value);
			int num = stringByName.CompareTo(stringByName2);
			bool flag = num > 0;
			int para;
			if (flag)
			{
				para = 1;
			}
			else
			{
				bool flag2 = num < 0;
				if (flag2)
				{
					para = -1;
				}
				else
				{
					para = 0;
				}
			}
			entity.AI.AIData.SetIntByName(this._store_result_name, para);
			return true;
		}

		// Token: 0x04003CE6 RID: 15590
		private string _first_string_name;

		// Token: 0x04003CE7 RID: 15591
		private string _first_string_value;

		// Token: 0x04003CE8 RID: 15592
		private string _second_string_name;

		// Token: 0x04003CE9 RID: 15593
		private string _second_string_value;

		// Token: 0x04003CEA RID: 15594
		private string _store_result_name;
	}
}
