using System;

namespace XUtliPoolLib
{
	// Token: 0x02000252 RID: 594
	public class DragonGuildTable : CVSReader
	{
		// Token: 0x06000CEC RID: 3308 RVA: 0x0004409C File Offset: 0x0004229C
		public DragonGuildTable.RowData GetBylevel(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DragonGuildTable.RowData result;
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

		// Token: 0x06000CED RID: 3309 RVA: 0x00044108 File Offset: 0x00042308
		protected override void ReadLine(XBinaryReader reader)
		{
			DragonGuildTable.RowData rowData = new DragonGuildTable.RowData();
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 0;
			rowData.buf.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CEE RID: 3310 RVA: 0x00044168 File Offset: 0x00042368
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonGuildTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007A0 RID: 1952
		public DragonGuildTable.RowData[] Table = null;

		// Token: 0x020003E1 RID: 993
		public class RowData
		{
			// Token: 0x04001186 RID: 4486
			public uint level;

			// Token: 0x04001187 RID: 4487
			public SeqRef<int> buf;
		}
	}
}
