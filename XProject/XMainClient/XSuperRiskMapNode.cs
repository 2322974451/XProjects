using System;

namespace XMainClient
{
	// Token: 0x02000B21 RID: 2849
	internal class XSuperRiskMapNode
	{
		// Token: 0x04003DCC RID: 15820
		public Coordinate coord;

		// Token: 0x04003DCD RID: 15821
		public char group;

		// Token: 0x04003DCE RID: 15822
		public XSuperRiskMapNode[] neighbour = new XSuperRiskMapNode[4];
	}
}
