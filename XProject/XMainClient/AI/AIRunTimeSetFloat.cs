using System;
using System.Xml;

namespace XMainClient
{

	internal class AIRunTimeSetFloat : AIRunTimeNodeAction
	{

		public AIRunTimeSetFloat(XmlElement node) : base(node)
		{
			this._value_name = node.GetAttribute("Shared_ValueName");
			this._value = float.Parse(node.GetAttribute("value"));
			this._store_name = node.GetAttribute("Shared_StoredResultName");
		}

		public override bool Update(XEntity entity)
		{
			float floatByName = entity.AI.AIData.GetFloatByName(this._value_name, this._value);
			entity.AI.AIData.SetFloatByName(this._store_name, floatByName);
			return true;
		}

		private string _value_name;

		private float _value;

		private string _store_name;
	}
}
