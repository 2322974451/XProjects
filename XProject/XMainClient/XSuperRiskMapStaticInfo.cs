using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000B22 RID: 2850
	internal class XSuperRiskMapStaticInfo
	{
		// Token: 0x17003007 RID: 12295
		// (get) Token: 0x0600A750 RID: 42832 RVA: 0x001D91A3 File Offset: 0x001D73A3
		// (set) Token: 0x0600A751 RID: 42833 RVA: 0x001D91AB File Offset: 0x001D73AB
		public int Width { get; set; }

		// Token: 0x17003008 RID: 12296
		// (get) Token: 0x0600A752 RID: 42834 RVA: 0x001D91B4 File Offset: 0x001D73B4
		// (set) Token: 0x0600A753 RID: 42835 RVA: 0x001D91BC File Offset: 0x001D73BC
		public int Height { get; set; }

		// Token: 0x0600A754 RID: 42836 RVA: 0x001D91C8 File Offset: 0x001D73C8
		public XSuperRiskMapNode FindMapNode(Coordinate coord)
		{
			for (int i = 0; i < this.Nodes.Count; i++)
			{
				bool flag = this.Nodes[i].coord.Equals(coord);
				if (flag)
				{
					return this.Nodes[i];
				}
			}
			return null;
		}

		// Token: 0x04003DD1 RID: 15825
		public List<XSuperRiskMapNode> Nodes = new List<XSuperRiskMapNode>();
	}
}
