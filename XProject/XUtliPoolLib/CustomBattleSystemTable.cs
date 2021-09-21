using System;

namespace XUtliPoolLib
{
	// Token: 0x02000222 RID: 546
	public class CustomBattleSystemTable : CVSReader
	{
		// Token: 0x06000C3A RID: 3130 RVA: 0x00040350 File Offset: 0x0003E550
		public CustomBattleSystemTable.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			CustomBattleSystemTable.RowData result;
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

		// Token: 0x06000C3B RID: 3131 RVA: 0x000403BC File Offset: 0x0003E5BC
		protected override void ReadLine(XBinaryReader reader)
		{
			CustomBattleSystemTable.RowData rowData = new CustomBattleSystemTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 1;
			rowData.end.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.ticket.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.levellimit, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.desc, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.TitleSpriteName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.IconSpritePath, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.ExpID, CVSReader.intParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C3C RID: 3132 RVA: 0x000404D0 File Offset: 0x0003E6D0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CustomBattleSystemTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000770 RID: 1904
		public CustomBattleSystemTable.RowData[] Table = null;

		// Token: 0x020003B1 RID: 945
		public class RowData
		{
			// Token: 0x04001087 RID: 4231
			public uint id;

			// Token: 0x04001088 RID: 4232
			public uint type;

			// Token: 0x04001089 RID: 4233
			public SeqRef<uint> end;

			// Token: 0x0400108A RID: 4234
			public SeqRef<uint> ticket;

			// Token: 0x0400108B RID: 4235
			public uint levellimit;

			// Token: 0x0400108C RID: 4236
			public string desc;

			// Token: 0x0400108D RID: 4237
			public string TitleSpriteName;

			// Token: 0x0400108E RID: 4238
			public string IconSpritePath;

			// Token: 0x0400108F RID: 4239
			public int ExpID;
		}
	}
}
