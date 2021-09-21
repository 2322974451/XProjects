using System;
using System.Collections.Generic;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AC1 RID: 2753
	internal class AIRunTimeLogicNode : AIRunTimeNodeBase
	{
		// Token: 0x0600A580 RID: 42368 RVA: 0x001CC8A0 File Offset: 0x001CAAA0
		public AIRunTimeLogicNode(XmlElement node) : base(node)
		{
			this._type = NodeType.NODE_TYPE_LOGIC;
		}

		// Token: 0x0600A581 RID: 42369 RVA: 0x001CC8BD File Offset: 0x001CAABD
		public override void AddChild(AIRunTimeNodeBase child)
		{
			this._list_node.Add(child);
		}

		// Token: 0x04003C7E RID: 15486
		protected List<AIRunTimeNodeBase> _list_node = new List<AIRunTimeNodeBase>();
	}
}
