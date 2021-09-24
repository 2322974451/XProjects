using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeFloatComparison : AIRunTimeNodeAction
	{

		public AIRunTimeFloatComparison(XmlElement node) : base(node)
		{
			this._float_name1 = node.GetAttribute("Shared_Float1Name");
			this._float_value1 = float.Parse(node.GetAttribute("float1Value"));
			this._float_name2 = node.GetAttribute("Shared_Float2Name");
			this._float_value2 = float.Parse(node.GetAttribute("float2Value"));
			this._comp_type = int.Parse(node.GetAttribute("type"));
		}

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

		private int _comp_type;

		private string _float_name1;

		private float _float_value1;

		private string _float_name2;

		private float _float_value2;
	}
}
