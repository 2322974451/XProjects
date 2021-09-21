using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AE1 RID: 2785
	internal class AIRunTimeIntOperator : AIRunTimeNodeAction
	{
		// Token: 0x0600A5BD RID: 42429 RVA: 0x001CE4BC File Offset: 0x001CC6BC
		public AIRunTimeIntOperator(XmlElement node) : base(node)
		{
			this._operator_type = int.Parse(node.GetAttribute("type"));
			this._int_name1 = node.GetAttribute("Shared_Int1Name");
			this._int_value1 = int.Parse(node.GetAttribute("int1Value"));
			this._int_name2 = node.GetAttribute("Shared_Int2Name");
			this._int_value2 = int.Parse(node.GetAttribute("int2Value"));
			this._stored_result_name = node.GetAttribute("Shared_StoredResultName");
		}

		// Token: 0x0600A5BE RID: 42430 RVA: 0x001CE548 File Offset: 0x001CC748
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

		// Token: 0x04003CCC RID: 15564
		private int _operator_type;

		// Token: 0x04003CCD RID: 15565
		private string _int_name1;

		// Token: 0x04003CCE RID: 15566
		private int _int_value1;

		// Token: 0x04003CCF RID: 15567
		private string _int_name2;

		// Token: 0x04003CD0 RID: 15568
		private int _int_value2;

		// Token: 0x04003CD1 RID: 15569
		private string _stored_result_name;
	}
}
