using System;

namespace XUtliPoolLib
{
	// Token: 0x02000227 RID: 551
	public class CustomBattleTable : CVSReader
	{
		// Token: 0x06000C4C RID: 3148 RVA: 0x00040934 File Offset: 0x0003EB34
		public CustomBattleTable.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			CustomBattleTable.RowData result;
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

		// Token: 0x06000C4D RID: 3149 RVA: 0x000409A0 File Offset: 0x0003EBA0
		protected override void ReadLine(XBinaryReader reader)
		{
			CustomBattleTable.RowData rowData = new CustomBattleTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 1;
			rowData.create.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.joincount, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.readytimepan, CVSReader.uintParse);
			this.columnno = 4;
			base.ReadArray<uint>(reader, ref rowData.timespan, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.levellimit, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.desc, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.BoxSpriteName, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<int>(reader, ref rowData.ExpID, CVSReader.intParse);
			this.columnno = 11;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C4E RID: 3150 RVA: 0x00040AD0 File Offset: 0x0003ECD0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CustomBattleTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000775 RID: 1909
		public CustomBattleTable.RowData[] Table = null;

		// Token: 0x020003B6 RID: 950
		public class RowData
		{
			// Token: 0x040010A0 RID: 4256
			public uint id;

			// Token: 0x040010A1 RID: 4257
			public uint type;

			// Token: 0x040010A2 RID: 4258
			public SeqListRef<uint> create;

			// Token: 0x040010A3 RID: 4259
			public uint joincount;

			// Token: 0x040010A4 RID: 4260
			public uint readytimepan;

			// Token: 0x040010A5 RID: 4261
			public uint[] timespan;

			// Token: 0x040010A6 RID: 4262
			public uint levellimit;

			// Token: 0x040010A7 RID: 4263
			public string desc;

			// Token: 0x040010A8 RID: 4264
			public string BoxSpriteName;

			// Token: 0x040010A9 RID: 4265
			public int ExpID;
		}
	}
}
