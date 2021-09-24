using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeBoolComparison : AIRunTimeNodeAction
	{

		public AIRunTimeBoolComparison(XmlElement node) : base(node)
		{
			this._bool_name1 = node.GetAttribute("Shared_Bool1Name");
			this._bool_value1 = (node.GetAttribute("bool1Value") != "0");
			this._bool_name2 = node.GetAttribute("Shared_Bool2Name");
			this._bool_value2 = (node.GetAttribute("bool2Value") != "0");
		}

		public override bool Update(XEntity entity)
		{
			bool boolByName = entity.AI.AIData.GetBoolByName(this._bool_name1, this._bool_value1);
			bool boolByName2 = entity.AI.AIData.GetBoolByName(this._bool_name2, this._bool_value2);
			return boolByName == boolByName2;
		}

		private string _bool_name1;

		private bool _bool_value1;

		private string _bool_name2;

		private bool _bool_value2;
	}
}
