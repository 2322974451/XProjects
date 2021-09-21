using System;

namespace XUtliPoolLib
{
	// Token: 0x020000FE RID: 254
	public class GameCommunityTable : CVSReader
	{
		// Token: 0x0600066F RID: 1647 RVA: 0x0001F3BC File Offset: 0x0001D5BC
		protected override void ReadLine(XBinaryReader reader)
		{
			GameCommunityTable.RowData rowData = new GameCommunityTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ButtonName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<bool>(reader, ref rowData.QQ, CVSReader.boolParse);
			this.columnno = 2;
			base.Read<bool>(reader, ref rowData.WX, CVSReader.boolParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.OpenLevel, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.SysID, CVSReader.intParse);
			this.columnno = 5;
			base.Read<bool>(reader, ref rowData.YK, CVSReader.boolParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x0001F49C File Offset: 0x0001D69C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GameCommunityTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400034A RID: 842
		public GameCommunityTable.RowData[] Table = null;

		// Token: 0x020002FD RID: 765
		public class RowData
		{
			// Token: 0x04000B11 RID: 2833
			public int ID;

			// Token: 0x04000B12 RID: 2834
			public string ButtonName;

			// Token: 0x04000B13 RID: 2835
			public bool QQ;

			// Token: 0x04000B14 RID: 2836
			public bool WX;

			// Token: 0x04000B15 RID: 2837
			public int OpenLevel;

			// Token: 0x04000B16 RID: 2838
			public int SysID;

			// Token: 0x04000B17 RID: 2839
			public bool YK;
		}
	}
}
