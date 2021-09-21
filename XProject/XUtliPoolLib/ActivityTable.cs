using System;

namespace XUtliPoolLib
{
	// Token: 0x020000AE RID: 174
	public class ActivityTable : CVSReader
	{
		// Token: 0x0600052E RID: 1326 RVA: 0x00016BE8 File Offset: 0x00014DE8
		public ActivityTable.RowData GetBysortid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ActivityTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].sortid == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x00016C54 File Offset: 0x00014E54
		protected override void ReadLine(XBinaryReader reader)
		{
			ActivityTable.RowData rowData = new ActivityTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.value, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.description, CVSReader.stringParse);
			this.columnno = 7;
			rowData.item.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.sortid, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.random, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.title, CVSReader.stringParse);
			this.columnno = 11;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00016D6C File Offset: 0x00014F6C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ActivityTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002D4 RID: 724
		public ActivityTable.RowData[] Table = null;

		// Token: 0x020002AC RID: 684
		public class RowData
		{
			// Token: 0x040008D7 RID: 2263
			public uint id;

			// Token: 0x040008D8 RID: 2264
			public uint value;

			// Token: 0x040008D9 RID: 2265
			public string name;

			// Token: 0x040008DA RID: 2266
			public string icon;

			// Token: 0x040008DB RID: 2267
			public string description;

			// Token: 0x040008DC RID: 2268
			public SeqListRef<int> item;

			// Token: 0x040008DD RID: 2269
			public uint sortid;

			// Token: 0x040008DE RID: 2270
			public uint random;

			// Token: 0x040008DF RID: 2271
			public string title;
		}
	}
}
