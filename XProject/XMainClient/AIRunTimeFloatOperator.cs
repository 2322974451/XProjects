using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AE0 RID: 2784
	internal class AIRunTimeFloatOperator : AIRunTimeNodeAction
	{
		// Token: 0x0600A5BB RID: 42427 RVA: 0x001CE308 File Offset: 0x001CC508
		public AIRunTimeFloatOperator(XmlElement node) : base(node)
		{
			this._operator_type = int.Parse(node.GetAttribute("type"));
			this._float_name1 = node.GetAttribute("Shared_Float1Name");
			this._float_value1 = float.Parse(node.GetAttribute("float1Value"));
			this._float_name2 = node.GetAttribute("Shared_Float2Name");
			this._float_value2 = float.Parse(node.GetAttribute("float2Value"));
			this._stored_result_name = node.GetAttribute("Shared_StoredResultName");
		}

		// Token: 0x0600A5BC RID: 42428 RVA: 0x001CE394 File Offset: 0x001CC594
		public override bool Update(XEntity entity)
		{
			float floatByName = entity.AI.AIData.GetFloatByName(this._float_name1, this._float_value1);
			float floatByName2 = entity.AI.AIData.GetFloatByName(this._float_name2, this._float_value2);
			float para = 0f;
			bool flag = this._operator_type == XFastEnumIntEqualityComparer<FloatOperatorType>.ToInt(FloatOperatorType.FOTYPE_ADD);
			if (flag)
			{
				para = floatByName + floatByName2;
			}
			else
			{
				bool flag2 = this._operator_type == XFastEnumIntEqualityComparer<FloatOperatorType>.ToInt(FloatOperatorType.FOTYPE_SUBTRACT);
				if (flag2)
				{
					para = floatByName - floatByName2;
				}
				else
				{
					bool flag3 = this._operator_type == XFastEnumIntEqualityComparer<FloatOperatorType>.ToInt(FloatOperatorType.FOTYPE_MULTIPLY);
					if (flag3)
					{
						para = floatByName * floatByName2;
					}
					else
					{
						bool flag4 = this._operator_type == XFastEnumIntEqualityComparer<FloatOperatorType>.ToInt(FloatOperatorType.FOTYPE_DIVIDE);
						if (flag4)
						{
							bool flag5 = floatByName2 != 0f;
							if (flag5)
							{
								para = floatByName / floatByName2;
							}
						}
						else
						{
							bool flag6 = this._operator_type == XFastEnumIntEqualityComparer<FloatOperatorType>.ToInt(FloatOperatorType.FOTYPE_MIN);
							if (flag6)
							{
								para = ((floatByName < floatByName2) ? floatByName : floatByName2);
							}
							else
							{
								bool flag7 = this._operator_type == XFastEnumIntEqualityComparer<FloatOperatorType>.ToInt(FloatOperatorType.FOTYPE_MAX);
								if (flag7)
								{
									para = ((floatByName > floatByName2) ? floatByName : floatByName2);
								}
							}
						}
					}
				}
			}
			entity.AI.AIData.SetFloatByName(this._stored_result_name, para);
			return true;
		}

		// Token: 0x04003CC6 RID: 15558
		private int _operator_type;

		// Token: 0x04003CC7 RID: 15559
		private string _float_name1;

		// Token: 0x04003CC8 RID: 15560
		private float _float_value1;

		// Token: 0x04003CC9 RID: 15561
		private string _float_name2;

		// Token: 0x04003CCA RID: 15562
		private float _float_value2;

		// Token: 0x04003CCB RID: 15563
		private string _stored_result_name;
	}
}
