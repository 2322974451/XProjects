using System;

namespace XUtliPoolLib
{
	// Token: 0x020000FD RID: 253
	public class FriendTable : CVSReader
	{
		// Token: 0x0600066B RID: 1643 RVA: 0x0001F27C File Offset: 0x0001D47C
		public FriendTable.RowData GetBylevel(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FriendTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].level == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0001F2E8 File Offset: 0x0001D4E8
		protected override void ReadLine(XBinaryReader reader)
		{
			FriendTable.RowData rowData = new FriendTable.RowData();
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.teamname, CVSReader.stringParse);
			this.columnno = 2;
			rowData.buf.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.dropid, CVSReader.uintParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0001F37C File Offset: 0x0001D57C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FriendTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000349 RID: 841
		public FriendTable.RowData[] Table = null;

		// Token: 0x020002FC RID: 764
		public class RowData
		{
			// Token: 0x04000B0D RID: 2829
			public uint level;

			// Token: 0x04000B0E RID: 2830
			public string teamname;

			// Token: 0x04000B0F RID: 2831
			public SeqRef<uint> buf;

			// Token: 0x04000B10 RID: 2832
			public uint dropid;
		}
	}
}
