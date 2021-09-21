using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000ABB RID: 2747
	internal class AIRunTimeIsQTEState : AIRunTimeNodeCondition
	{
		// Token: 0x0600A573 RID: 42355 RVA: 0x001CC360 File Offset: 0x001CA560
		public AIRunTimeIsQTEState(XmlElement node) : base(node)
		{
			bool flag = node.GetAttribute("QTEState") != "";
			if (flag)
			{
				this._qte_state = int.Parse(node.GetAttribute("QTEState"));
			}
		}

		// Token: 0x0600A574 RID: 42356 RVA: 0x001CC3AC File Offset: 0x001CA5AC
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAIGeneralMgr>.singleton.HasQTE(entity.ID, this._qte_state);
		}

		// Token: 0x04003C72 RID: 15474
		private int _qte_state = 0;
	}
}
