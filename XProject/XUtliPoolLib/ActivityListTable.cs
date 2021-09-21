using System;

namespace XUtliPoolLib
{
	// Token: 0x020000AD RID: 173
	public class ActivityListTable : CVSReader
	{
		// Token: 0x0600052A RID: 1322 RVA: 0x00016A0C File Offset: 0x00014C0C
		public ActivityListTable.RowData GetBySysID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			ActivityListTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SysID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x00016A78 File Offset: 0x00014C78
		protected override void ReadLine(XBinaryReader reader)
		{
			ActivityListTable.RowData rowData = new ActivityListTable.RowData();
			base.Read<uint>(reader, ref rowData.SysID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Tittle, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<string>(reader, ref rowData.TagNames, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			base.ReadArray<string>(reader, ref rowData.TagName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<bool>(reader, ref rowData.HadShop, CVSReader.boolParse);
			this.columnno = 5;
			rowData.DropItems.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Describe, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.SortIndex, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.AtlasPath, CVSReader.stringParse);
			this.columnno = 9;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00016BA8 File Offset: 0x00014DA8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ActivityListTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002D3 RID: 723
		public ActivityListTable.RowData[] Table = null;

		// Token: 0x020002AB RID: 683
		public class RowData
		{
			// Token: 0x040008CD RID: 2253
			public uint SysID;

			// Token: 0x040008CE RID: 2254
			public string Tittle;

			// Token: 0x040008CF RID: 2255
			public string[] TagNames;

			// Token: 0x040008D0 RID: 2256
			public string Icon;

			// Token: 0x040008D1 RID: 2257
			public string[] TagName;

			// Token: 0x040008D2 RID: 2258
			public bool HadShop;

			// Token: 0x040008D3 RID: 2259
			public SeqListRef<uint> DropItems;

			// Token: 0x040008D4 RID: 2260
			public string Describe;

			// Token: 0x040008D5 RID: 2261
			public uint SortIndex;

			// Token: 0x040008D6 RID: 2262
			public string AtlasPath;
		}
	}
}
