using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeSetBool : AIRunTimeNodeAction
	{

		public AIRunTimeSetBool(XmlElement node) : base(node)
		{
			this._value_name = node.GetAttribute("Shared_ValueName");
			this._value = (node.GetAttribute("value") != "0");
			this._store_name = node.GetAttribute("Shared_StoredResultName");
		}

		public override bool Update(XEntity entity)
		{
			bool boolByName = entity.AI.AIData.GetBoolByName(this._value_name, this._value);
			entity.AI.AIData.SetBoolByName(this._store_name, boolByName);
			return true;
		}

		private string _value_name;

		private bool _value;

		private string _store_name;
	}
}
