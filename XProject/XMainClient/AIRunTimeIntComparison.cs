using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AE3 RID: 2787
	internal class AIRunTimeIntComparison : AIRunTimeNodeAction
	{
		// Token: 0x0600A5C1 RID: 42433 RVA: 0x001CE7E4 File Offset: 0x001CC9E4
		public AIRunTimeIntComparison(XmlElement node) : base(node)
		{
			this._comp_type = int.Parse(node.GetAttribute("type"));
			this._int_name1 = node.GetAttribute("Shared_Int1Name");
			this._int_value1 = int.Parse(node.GetAttribute("int1Value"));
			this._int_name2 = node.GetAttribute("Shared_Int2Name");
			this._int_value2 = int.Parse(node.GetAttribute("int2Value"));
		}

		// Token: 0x0600A5C2 RID: 42434 RVA: 0x001CE868 File Offset: 0x001CCA68
		public override bool Update(XEntity entity)
		{
			int intByName = entity.AI.AIData.GetIntByName(this._int_name1, this._int_value1);
			int intByName2 = entity.AI.AIData.GetIntByName(this._int_name2, this._int_value2);
			bool flag = this._comp_type == XFastEnumIntEqualityComparer<ComparisonType>.ToInt(ComparisonType.FCTYPE_LESS_THAN);
			bool result;
			if (flag)
			{
				result = (intByName < intByName2);
			}
			else
			{
				bool flag2 = this._comp_type == XFastEnumIntEqualityComparer<ComparisonType>.ToInt(ComparisonType.FCTYPE_LESS_OR_EQUAL_TO);
				if (flag2)
				{
					result = (intByName <= intByName2);
				}
				else
				{
					bool flag3 = this._comp_type == XFastEnumIntEqualityComparer<ComparisonType>.ToInt(ComparisonType.FCTYPE_EQUAL_TO);
					if (flag3)
					{
						result = (intByName == intByName2);
					}
					else
					{
						bool flag4 = this._comp_type == XFastEnumIntEqualityComparer<ComparisonType>.ToInt(ComparisonType.FCTYPE_NOT_EQUAL_TO);
						if (flag4)
						{
							result = (intByName != intByName2);
						}
						else
						{
							bool flag5 = this._comp_type == XFastEnumIntEqualityComparer<ComparisonType>.ToInt(ComparisonType.FCTYPE_GREATER_THAN);
							if (flag5)
							{
								result = (intByName > intByName2);
							}
							else
							{
								bool flag6 = this._comp_type == XFastEnumIntEqualityComparer<ComparisonType>.ToInt(ComparisonType.FCTYPE_GREATER_THAN_OR_EQUAL_TO);
								result = (flag6 && intByName >= intByName2);
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x04003CD7 RID: 15575
		private int _comp_type = 0;

		// Token: 0x04003CD8 RID: 15576
		private string _int_name1;

		// Token: 0x04003CD9 RID: 15577
		private int _int_value1;

		// Token: 0x04003CDA RID: 15578
		private string _int_name2;

		// Token: 0x04003CDB RID: 15579
		private int _int_value2;
	}
}
