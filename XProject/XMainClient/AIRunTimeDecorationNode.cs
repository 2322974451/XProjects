using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AC6 RID: 2758
	internal class AIRunTimeDecorationNode : AIRunTimeNodeBase
	{
		// Token: 0x0600A58C RID: 42380 RVA: 0x001CCA98 File Offset: 0x001CAC98
		public AIRunTimeDecorationNode(XmlElement node) : base(node)
		{
			this._type = NodeType.NODE_TYPE_DECORATION;
		}

		// Token: 0x0600A58D RID: 42381 RVA: 0x001CCAB1 File Offset: 0x001CACB1
		public override void AddChild(AIRunTimeNodeBase child)
		{
			this._child_node = child;
		}

		// Token: 0x04003C81 RID: 15489
		protected AIRunTimeNodeBase _child_node = null;
	}
}
