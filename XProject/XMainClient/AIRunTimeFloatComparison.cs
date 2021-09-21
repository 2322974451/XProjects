using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AE2 RID: 2786
	internal class AIRunTimeFloatComparison : AIRunTimeNodeAction
	{
		// Token: 0x0600A5BF RID: 42431 RVA: 0x001CE66C File Offset: 0x001CC86C
		public AIRunTimeFloatComparison(XmlElement node) : base(node)
		{
			this._float_name1 = node.GetAttribute("Shared_Float1Name");
			this._float_value1 = float.Parse(node.GetAttribute("float1Value"));
			this._float_name2 = node.GetAttribute("Shared_Float2Name");
			this._float_value2 = float.Parse(node.GetAttribute("float2Value"));
			this._comp_type = int.Parse(node.GetAttribute("type"));
		}

		// Token: 0x0600A5C0 RID: 42432 RVA: 0x001CE6E8 File Offset: 0x001CC8E8
		public override bool Update(XEntity entity)
		{
			float floatByName = entity.AI.AIData.GetFloatByName(this._float_name1, this._float_value1);
			float floatByName2 = entity.AI.AIData.GetFloatByName(this._float_name2, this._float_value2);
			bool flag = this._comp_type == XFastEnumIntEqualityComparer<ComparisonType>.ToInt(ComparisonType.FCTYPE_LESS_THAN);
			bool result;
			if (flag)
			{
				result = (floatByName < floatByName2);
			}
			else
			{
				bool flag2 = this._comp_type == XFastEnumIntEqualityComparer<ComparisonType>.ToInt(ComparisonType.FCTYPE_LESS_OR_EQUAL_TO);
				if (flag2)
				{
					result = (floatByName <= floatByName2);
				}
				else
				{
					bool flag3 = this._comp_type == XFastEnumIntEqualityComparer<ComparisonType>.ToInt(ComparisonType.FCTYPE_EQUAL_TO);
					if (flag3)
					{
						result = (floatByName == floatByName2);
					}
					else
					{
						bool flag4 = this._comp_type == XFastEnumIntEqualityComparer<ComparisonType>.ToInt(ComparisonType.FCTYPE_NOT_EQUAL_TO);
						if (flag4)
						{
							result = (floatByName != floatByName2);
						}
						else
						{
							bool flag5 = this._comp_type == XFastEnumIntEqualityComparer<ComparisonType>.ToInt(ComparisonType.FCTYPE_GREATER_THAN);
							if (flag5)
							{
								result = (floatByName > floatByName2);
							}
							else
							{
								bool flag6 = this._comp_type == XFastEnumIntEqualityComparer<ComparisonType>.ToInt(ComparisonType.FCTYPE_GREATER_THAN_OR_EQUAL_TO);
								result = (flag6 && floatByName >= floatByName2);
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x04003CD2 RID: 15570
		private int _comp_type;

		// Token: 0x04003CD3 RID: 15571
		private string _float_name1;

		// Token: 0x04003CD4 RID: 15572
		private float _float_value1;

		// Token: 0x04003CD5 RID: 15573
		private string _float_name2;

		// Token: 0x04003CD6 RID: 15574
		private float _float_value2;
	}
}
