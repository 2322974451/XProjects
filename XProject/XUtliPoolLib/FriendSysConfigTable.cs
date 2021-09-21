using System;

namespace XUtliPoolLib
{
	// Token: 0x020000FC RID: 252
	public class FriendSysConfigTable : CVSReader
	{
		// Token: 0x06000667 RID: 1639 RVA: 0x0001F0D4 File Offset: 0x0001D2D4
		public FriendSysConfigTable.RowData GetByTabID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FriendSysConfigTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].TabID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x0001F140 File Offset: 0x0001D340
		protected override void ReadLine(XBinaryReader reader)
		{
			FriendSysConfigTable.RowData rowData = new FriendSysConfigTable.RowData();
			base.Read<int>(reader, ref rowData.TabID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<bool>(reader, ref rowData.IsOpen, CVSReader.boolParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TabName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.NumLabel, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.RButtonLabel, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.LButtonLabel, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.NumLimit, CVSReader.intParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x0001F23C File Offset: 0x0001D43C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FriendSysConfigTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000348 RID: 840
		public FriendSysConfigTable.RowData[] Table = null;

		// Token: 0x020002FB RID: 763
		public class RowData
		{
			// Token: 0x04000B05 RID: 2821
			public int TabID;

			// Token: 0x04000B06 RID: 2822
			public bool IsOpen;

			// Token: 0x04000B07 RID: 2823
			public string TabName;

			// Token: 0x04000B08 RID: 2824
			public string Icon;

			// Token: 0x04000B09 RID: 2825
			public string NumLabel;

			// Token: 0x04000B0A RID: 2826
			public string RButtonLabel;

			// Token: 0x04000B0B RID: 2827
			public string LButtonLabel;

			// Token: 0x04000B0C RID: 2828
			public int NumLimit;
		}
	}
}
