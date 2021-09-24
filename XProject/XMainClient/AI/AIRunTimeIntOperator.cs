using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeIntOperator : AIRunTimeNodeAction
	{

		public AIRunTimeIntOperator(XmlElement node) : base(node)
		{
			this._operator_type = int.Parse(node.GetAttribute("type"));
			this._int_name1 = node.GetAttribute("Shared_Int1Name");
			this._int_value1 = int.Parse(node.GetAttribute("int1Value"));
			this._int_name2 = node.GetAttribute("Shared_Int2Name");
			this._int_value2 = int.Parse(node.GetAttribute("int2Value"));
			this._stored_result_name = node.GetAttribute("Shared_StoredResultName");
		}

		public override bool Update(XEntity entity)
		{
			int intByName = entity.AI.AIData.GetIntByName(this._int_name1, this._int_value1);
			int intByName2 = entity.AI.AIData.GetIntByName(this._int_name2, this._int_value2);
			int para = 0;
			bool flag = this._operator_type == XFastEnumIntEqualityComparer<FloatOperatorType>.ToInt(FloatOperatorType.FOTYPE_ADD);
			if (flag)
			{
				para = intByName + intByName2;
			}
			else
			{
				bool flag2 = this._operator_type == XFastEnumIntEqualityComparer<FloatOperatorType>.ToInt(FloatOperatorType.FOTYPE_SUBTRACT);
				if (flag2)
				{
					para = intByName - intByName2;
				}
				else
				{
					bool flag3 = this._operator_type == XFastEnumIntEqualityComparer<FloatOperatorType>.ToInt(FloatOperatorType.FOTYPE_MULTIPLY);
					if (flag3)
					{
						para = intByName * intByName2;
					}
					else
					{
						bool flag4 = this._operator_type == XFastEnumIntEqualityComparer<FloatOperatorType>.ToInt(FloatOperatorType.FOTYPE_DIVIDE);
						if (flag4)
						{
							bool flag5 = (float)intByName2 != 0f;
							if (flag5)
							{
								para = intByName / intByName2;
							}
							else
							{
								bool flag6 = this._operator_type == XFastEnumIntEqualityComparer<FloatOperatorType>.ToInt(FloatOperatorType.FOTYPE_MIN);
								if (flag6)
								{
									para = ((intByName < intByName2) ? intByName : intByName2);
								}
								else
								{
									bool flag7 = this._operator_type == XFastEnumIntEqualityComparer<FloatOperatorType>.ToInt(FloatOperatorType.FOTYPE_MAX);
									if (flag7)
									{
										para = ((intByName > intByName2) ? intByName : intByName2);
									}
								}
							}
						}
					}
				}
			}
			entity.AI.AIData.SetIntByName(this._stored_result_name, para);
			return true;
		}

		private int _operator_type;

		private string _int_name1;

		private int _int_value1;

		private string _int_name2;

		private int _int_value2;

		private string _stored_result_name;
	}
}
