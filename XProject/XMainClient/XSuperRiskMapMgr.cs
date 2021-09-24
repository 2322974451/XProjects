using System;
using System.Collections.Generic;
using System.IO;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSuperRiskMapMgr : XSingleton<XSuperRiskMapMgr>
	{

		public void Clear()
		{
			this.CurrentMap.Clear();
		}

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

		public void SetPlayerPosDirection(int x, int y, int dir)
		{
			this.CurrentMap.PlayerCoord = new Coordinate(x, y);
			this.CurrentMap.PlayerMoveDirection = (Direction)dir;
		}

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

		private Dictionary<string, XSuperRiskMapStaticInfo> AllMapStaticInfo = new Dictionary<string, XSuperRiskMapStaticInfo>();

		public XSuperRiskMap CurrentMap = new XSuperRiskMap();
	}
}
