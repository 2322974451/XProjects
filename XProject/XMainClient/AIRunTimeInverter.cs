using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AC7 RID: 2759
	internal class AIRunTimeInverter : AIRunTimeDecorationNode
	{
		// Token: 0x0600A58E RID: 42382 RVA: 0x001CCABB File Offset: 0x001CACBB
		public AIRunTimeInverter(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A58F RID: 42383 RVA: 0x001CCAC8 File Offset: 0x001CACC8
		public override bool Update(XEntity entity)
		{
			bool flag = this._child_node != null;
			return flag && !this._child_node.Update(entity);
		}
	}
}
