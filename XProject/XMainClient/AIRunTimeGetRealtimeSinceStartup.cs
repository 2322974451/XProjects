using System;
using System.Xml;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000AEA RID: 2794
	internal class AIRunTimeGetRealtimeSinceStartup : AIRunTimeNodeAction
	{
		// Token: 0x0600A5CF RID: 42447 RVA: 0x001CED00 File Offset: 0x001CCF00
		public AIRunTimeGetRealtimeSinceStartup(XmlElement node) : base(node)
		{
			this._store_res_name = node.GetAttribute("Shared_FloatstoreResultName");
		}

		// Token: 0x0600A5D0 RID: 42448 RVA: 0x001CED1C File Offset: 0x001CCF1C
		public override bool Update(XEntity entity)
		{
			this._store_res = Time.realtimeSinceStartup;
			entity.AI.AIData.SetFloatByName(this._store_res_name, this._store_res);
			return true;
		}

		// Token: 0x04003CEE RID: 15598
		private string _store_res_name;

		// Token: 0x04003CEF RID: 15599
		private float _store_res;
	}
}
