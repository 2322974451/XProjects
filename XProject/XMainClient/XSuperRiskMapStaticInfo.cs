using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XSuperRiskMapStaticInfo
	{

		public int Width { get; set; }

		public int Height { get; set; }

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

		public List<XSuperRiskMapNode> Nodes = new List<XSuperRiskMapNode>();
	}
}
