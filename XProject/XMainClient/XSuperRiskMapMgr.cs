using System;
using System.Collections.Generic;
using System.IO;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B26 RID: 2854
	internal class XSuperRiskMapMgr : XSingleton<XSuperRiskMapMgr>
	{
		// Token: 0x0600A761 RID: 42849 RVA: 0x001D94B9 File Offset: 0x001D76B9
		public void Clear()
		{
			this.CurrentMap.Clear();
		}

		// Token: 0x0600A762 RID: 42850 RVA: 0x001D94C8 File Offset: 0x001D76C8
		public void SetCurrentMap(string MapID)
		{
			this.CurrentMap.Clear();
			bool flag = this.AllMapStaticInfo.ContainsKey(MapID);
			if (flag)
			{
				this.CurrentMap.StaticInfo = this.AllMapStaticInfo[MapID];
			}
			else
			{
				XSuperRiskMapStaticInfo xsuperRiskMapStaticInfo = this.ReadMapConfig(MapID);
				bool flag2 = xsuperRiskMapStaticInfo != null;
				if (flag2)
				{
					this.AllMapStaticInfo.Add(MapID, xsuperRiskMapStaticInfo);
					this.CurrentMap.StaticInfo = this.AllMapStaticInfo[MapID];
				}
			}
		}

		// Token: 0x0600A763 RID: 42851 RVA: 0x001D9546 File Offset: 0x001D7746
		public void SetPlayerPosDirection(int x, int y, int dir)
		{
			this.CurrentMap.PlayerCoord = new Coordinate(x, y);
			this.CurrentMap.PlayerMoveDirection = (Direction)dir;
		}

		// Token: 0x0600A764 RID: 42852 RVA: 0x001D9568 File Offset: 0x001D7768
		protected XSuperRiskMapStaticInfo ReadMapConfig(string MapID)
		{
			XSuperRiskMapStaticInfo xsuperRiskMapStaticInfo = new XSuperRiskMapStaticInfo();
			Stream stream = XSingleton<XResourceLoaderMgr>.singleton.ReadText("Table/SuperRisk/" + MapID, ".txt", true);
			StreamReader streamReader = new StreamReader(stream);
			int num = 0;
			int width = 0;
			string text;
			while ((text = streamReader.ReadLine()) != null)
			{
				width = text.Length;
				for (int i = 0; i < text.Length; i++)
				{
					bool flag = text[i] == '0' || text[i] == ' ';
					if (!flag)
					{
						XSuperRiskMapNode xsuperRiskMapNode = new XSuperRiskMapNode
						{
							coord = new Coordinate(i, num)
						};
						xsuperRiskMapNode.group = text[i];
						bool flag2 = i > 0;
						if (flag2)
						{
							XSuperRiskMapNode xsuperRiskMapNode2 = xsuperRiskMapStaticInfo.FindMapNode(new Coordinate(i - 1, num));
							bool flag3 = xsuperRiskMapNode2 != null;
							if (flag3)
							{
								xsuperRiskMapNode2.neighbour[0] = xsuperRiskMapNode;
								xsuperRiskMapNode.neighbour[2] = xsuperRiskMapNode2;
							}
						}
						bool flag4 = num > 0;
						if (flag4)
						{
							XSuperRiskMapNode xsuperRiskMapNode3 = xsuperRiskMapStaticInfo.FindMapNode(new Coordinate(i, num - 1));
							bool flag5 = xsuperRiskMapNode3 != null;
							if (flag5)
							{
								xsuperRiskMapNode3.neighbour[1] = xsuperRiskMapNode;
								xsuperRiskMapNode.neighbour[3] = xsuperRiskMapNode3;
							}
						}
						xsuperRiskMapStaticInfo.Nodes.Add(xsuperRiskMapNode);
					}
				}
				num++;
			}
			xsuperRiskMapStaticInfo.Width = width;
			xsuperRiskMapStaticInfo.Height = num;
			XSingleton<XResourceLoaderMgr>.singleton.ClearStream(stream);
			return xsuperRiskMapStaticInfo;
		}

		// Token: 0x04003DDA RID: 15834
		private Dictionary<string, XSuperRiskMapStaticInfo> AllMapStaticInfo = new Dictionary<string, XSuperRiskMapStaticInfo>();

		// Token: 0x04003DDB RID: 15835
		public XSuperRiskMap CurrentMap = new XSuperRiskMap();
	}
}
