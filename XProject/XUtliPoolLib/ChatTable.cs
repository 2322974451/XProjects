using System;

namespace XUtliPoolLib
{
	// Token: 0x020000C6 RID: 198
	public class ChatTable : CVSReader
	{
		// Token: 0x06000585 RID: 1413 RVA: 0x000190D0 File Offset: 0x000172D0
		public ChatTable.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ChatTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].id == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x0001913C File Offset: 0x0001733C
		protected override void ReadLine(XBinaryReader reader)
		{
			ChatTable.RowData rowData = new ChatTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.length, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.sprName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.miniSpr, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00019204 File Offset: 0x00017404
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ChatTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002EC RID: 748
		public ChatTable.RowData[] Table = null;

		// Token: 0x020002C4 RID: 708
		public class RowData
		{
			// Token: 0x04000993 RID: 2451
			public uint id;

			// Token: 0x04000994 RID: 2452
			public uint level;

			// Token: 0x04000995 RID: 2453
			public uint length;

			// Token: 0x04000996 RID: 2454
			public string sprName;

			// Token: 0x04000997 RID: 2455
			public string miniSpr;

			// Token: 0x04000998 RID: 2456
			public string name;
		}
	}
}
