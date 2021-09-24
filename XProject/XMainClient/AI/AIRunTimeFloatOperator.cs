using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeFloatOperator : AIRunTimeNodeAction
	{

		public AIRunTimeFloatOperator(XmlElement node) : base(node)
		{
			this._operator_type = int.Parse(node.GetAttribute("type"));
			this._float_name1 = node.GetAttribute("Shared_Float1Name");
			this._float_value1 = float.Parse(node.GetAttribute("float1Value"));
			this._float_name2 = node.GetAttribute("Shared_Float2Name");
			this._float_value2 = float.Parse(node.GetAttribute("float2Value"));
			this._stored_result_name = node.GetAttribute("Shared_StoredResultName");
		}

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

		private int _operator_type;

		private string _float_name1;

		private float _float_value1;

		private string _float_name2;

		private float _float_value2;

		private string _stored_result_name;
	}
}
