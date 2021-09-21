using System;

namespace XUtliPoolLib
{
	// Token: 0x0200011A RID: 282
	public class HeroBattleMapCenter : CVSReader
	{
		// Token: 0x060006D8 RID: 1752 RVA: 0x00021ACC File Offset: 0x0001FCCC
		public HeroBattleMapCenter.RowData GetBySceneID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			HeroBattleMapCenter.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SceneID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x00021B38 File Offset: 0x0001FD38
		protected override void ReadLine(XBinaryReader reader)
		{
			HeroBattleMapCenter.RowData rowData = new HeroBattleMapCenter.RowData();
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.CenterType, CVSReader.uintParse);
			this.columnno = 1;
			rowData.Center.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.ReadArray<float>(reader, ref rowData.Param, CVSReader.floatParse);
			this.columnno = 3;
			base.Read<float>(reader, ref rowData.ClientFxScalse, CVSReader.floatParse);
			this.columnno = 4;
			base.ReadArray<string>(reader, ref rowData.OccupantFx, CVSReader.stringParse);
			this.columnno = 5;
			base.ReadArray<string>(reader, ref rowData.MiniMapFx, CVSReader.stringParse);
			this.columnno = 6;
			base.ReadArray<string>(reader, ref rowData.OccSuccessFx, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<string>(reader, ref rowData.OccWinFx, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.MVPCutScene, CVSReader.stringParse);
			this.columnno = 9;
			base.ReadArray<float>(reader, ref rowData.MVPPos, CVSReader.floatParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x00021C84 File Offset: 0x0001FE84
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new HeroBattleMapCenter.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000366 RID: 870
		public HeroBattleMapCenter.RowData[] Table = null;

		// Token: 0x02000319 RID: 793
		public class RowData
		{
			// Token: 0x04000BBD RID: 3005
			public uint SceneID;

			// Token: 0x04000BBE RID: 3006
			public uint CenterType;

			// Token: 0x04000BBF RID: 3007
			public SeqRef<float> Center;

			// Token: 0x04000BC0 RID: 3008
			public float[] Param;

			// Token: 0x04000BC1 RID: 3009
			public float ClientFxScalse;

			// Token: 0x04000BC2 RID: 3010
			public string[] OccupantFx;

			// Token: 0x04000BC3 RID: 3011
			public string[] MiniMapFx;

			// Token: 0x04000BC4 RID: 3012
			public string[] OccSuccessFx;

			// Token: 0x04000BC5 RID: 3013
			public string[] OccWinFx;

			// Token: 0x04000BC6 RID: 3014
			public string MVPCutScene;

			// Token: 0x04000BC7 RID: 3015
			public float[] MVPPos;
		}
	}
}
