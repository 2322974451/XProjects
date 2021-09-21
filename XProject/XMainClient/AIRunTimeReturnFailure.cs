using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AC9 RID: 2761
	internal class AIRunTimeReturnFailure : AIRunTimeDecorationNode
	{
		// Token: 0x0600A592 RID: 42386 RVA: 0x001CCABB File Offset: 0x001CACBB
		public AIRunTimeReturnFailure(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A593 RID: 42387 RVA: 0x001CCB2C File Offset: 0x001CAD2C
		public override bool Update(XEntity entity)
		{
			bool flag = this._child_node != null;
			if (flag)
			{
				this._child_node.Update(entity);
			}
			return false;
		}
	}
}
