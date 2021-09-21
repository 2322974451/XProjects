using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000A9A RID: 2714
	internal class AIRunTimeNodeAction : AIRunTimeNodeBase
	{
		// Token: 0x0600A4FD RID: 42237 RVA: 0x001CABB6 File Offset: 0x001C8DB6
		public AIRunTimeNodeAction(XmlElement node) : base(node)
		{
			this._type = NodeType.NODE_TYPE_ACTION;
		}
	}
}
