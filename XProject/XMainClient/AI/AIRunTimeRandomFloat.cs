using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeRandomFloat : AIRunTimeNodeAction
	{

		public AIRunTimeRandomFloat(XmlElement node) : base(node)
		{
			this._min_value = float.Parse(node.GetAttribute("minValue"));
			this._min_name = node.GetAttribute("Shared_MinName");
			this._max_value = float.Parse(node.GetAttribute("maxValue"));
			this._max_name = node.GetAttribute("Shared_MaxName");
			this._store_result_name = node.GetAttribute("Shared_StoredResultName");
		}

		public override bool Update(XEntity entity)
		{
			float floatByName = entity.AI.AIData.GetFloatByName(this._min_name, this._min_value);
			float floatByName2 = entity.AI.AIData.GetFloatByName(this._max_name, this._max_value);
			float para = XSingleton<XCommon>.singleton.RandomFloat(floatByName, floatByName2);
			entity.AI.AIData.SetFloatByName(this._store_result_name, para);
			return true;
		}

		private float _min_value;

		private string _min_name;

		private float _max_value;

		private string _max_name;

		private string _store_result_name;
	}
}
