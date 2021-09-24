using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeIntComparison : AIRunTimeNodeAction
	{

		public AIRunTimeIntComparison(XmlElement node) : base(node)
		{
			this._comp_type = int.Parse(node.GetAttribute("type"));
			this._int_name1 = node.GetAttribute("Shared_Int1Name");
			this._int_value1 = int.Parse(node.GetAttribute("int1Value"));
			this._int_name2 = node.GetAttribute("Shared_Int2Name");
			this._int_value2 = int.Parse(node.GetAttribute("int2Value"));
		}

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

		private int _comp_type = 0;

		private string _int_name1;

		private int _int_value1;

		private string _int_name2;

		private int _int_value2;
	}
}
