using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AC8 RID: 2760
	internal class AIRunTimeReturnSuccess : AIRunTimeDecorationNode
	{
		// Token: 0x0600A590 RID: 42384 RVA: 0x001CCABB File Offset: 0x001CACBB
		public AIRunTimeReturnSuccess(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A591 RID: 42385 RVA: 0x001CCAFC File Offset: 0x001CACFC
		public override bool Update(XEntity entity)
		{
			bool flag = this._child_node != null;
			if (flag)
			{
				this._child_node.Update(entity);
			}
			return true;
		}
	}
}
