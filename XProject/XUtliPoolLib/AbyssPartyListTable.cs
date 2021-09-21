using System;

namespace XUtliPoolLib
{
	// Token: 0x02000229 RID: 553
	public class AbyssPartyListTable : CVSReader
	{
		// Token: 0x06000C54 RID: 3156 RVA: 0x00040CEC File Offset: 0x0003EEEC
		public AbyssPartyListTable.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			AbyssPartyListTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x00040D58 File Offset: 0x0003EF58
		protected override void ReadLine(XBinaryReader reader)
		{
			AbyssPartyListTable.RowData rowData = new AbyssPartyListTable.RowData();
			base.Read<int>(reader, ref rowData.AbyssPartyId, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Index, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			rowData.Cost.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.SugPPT, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x00040E38 File Offset: 0x0003F038
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AbyssPartyListTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000777 RID: 1911
		public AbyssPartyListTable.RowData[] Table = null;

		// Token: 0x020003B8 RID: 952
		public class RowData
		{
			// Token: 0x040010B4 RID: 4276
			public int AbyssPartyId;

			// Token: 0x040010B5 RID: 4277
			public int Index;

			// Token: 0x040010B6 RID: 4278
			public string Name;

			// Token: 0x040010B7 RID: 4279
			public string Icon;

			// Token: 0x040010B8 RID: 4280
			public SeqRef<int> Cost;

			// Token: 0x040010B9 RID: 4281
			public uint SugPPT;

			// Token: 0x040010BA RID: 4282
			public int ID;
		}
	}
}
