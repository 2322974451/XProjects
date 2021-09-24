using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeSetInt : AIRunTimeNodeAction
	{

		public AIRunTimeSetInt(XmlElement node) : base(node)
		{
			this._value_name = node.GetAttribute("Shared_ValueName");
			this._value = int.Parse(node.GetAttribute("value"));
			this._store_name = node.GetAttribute("Shared_StoredResultName");
		}

		public override bool Update(XEntity entity)
		{
			int intByName = entity.AI.AIData.GetIntByName(this._value_name, this._value);
			entity.AI.AIData.SetIntByName(this._store_name, intByName);
			return true;
		}

		private string _value_name;

		private int _value;

		private string _store_name;
	}
}
