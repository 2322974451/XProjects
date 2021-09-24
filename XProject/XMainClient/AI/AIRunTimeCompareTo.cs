using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeCompareTo : AIRunTimeNodeAction
	{

		public AIRunTimeCompareTo(XmlElement node) : base(node)
		{
			this._first_string_name = node.GetAttribute("Shared_FirstStringName");
			this._first_string_value = node.GetAttribute("firstString");
			this._second_string_name = node.GetAttribute("Shared_SecondStringName");
			this._second_string_value = node.GetAttribute("secondString");
			this._store_result_name = node.GetAttribute("Shared_ResultName");
		}

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

		private string _first_string_name;

		private string _first_string_value;

		private string _second_string_name;

		private string _second_string_value;

		private string _store_result_name;
	}
}
