using System;
using System.Xml;
using UnityEngine;

namespace XMainClient
{

	internal class AIRunTimeGetRealtimeSinceStartup : AIRunTimeNodeAction
	{

		public AIRunTimeGetRealtimeSinceStartup(XmlElement node) : base(node)
		{
			this._store_res_name = node.GetAttribute("Shared_FloatstoreResultName");
		}

		public override bool Update(XEntity entity)
		{
			this._store_res = Time.realtimeSinceStartup;
			entity.AI.AIData.SetFloatByName(this._store_res_name, this._store_res);
			return true;
		}

		private string _store_res_name;

		private float _store_res;
	}
}
