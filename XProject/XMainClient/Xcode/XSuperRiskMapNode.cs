using System;

namespace XMainClient
{

	internal class XSuperRiskMapNode
	{

		public Coordinate coord;

		public char group;

		public XSuperRiskMapNode[] neighbour = new XSuperRiskMapNode[4];
	}
}
