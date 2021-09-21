using System;

namespace XUtliPoolLib
{
	// Token: 0x02000165 RID: 357
	public class RiskMapFile : CVSReader
	{
		// Token: 0x060007EE RID: 2030 RVA: 0x00028328 File Offset: 0x00026528
		public RiskMapFile.RowData GetByMapID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			RiskMapFile.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].MapID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x00028394 File Offset: 0x00026594
		protected override void ReadLine(XBinaryReader reader)
		{
			RiskMapFile.RowData rowData = new RiskMapFile.RowData();
			base.Read<int>(reader, ref rowData.MapID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.NeedLevel, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.FileName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.StepSizeX, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.StepSizeY, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.StartUIX, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.StartUIY, CVSReader.intParse);
			this.columnno = 6;
			rowData.BoxPreview.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.MapBgName, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.MapTittleName, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.MapGridBg, CVSReader.stringParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x000284E0 File Offset: 0x000266E0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RiskMapFile.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003B1 RID: 945
		public RiskMapFile.RowData[] Table = null;

		// Token: 0x02000364 RID: 868
		public class RowData
		{
			// Token: 0x04000D91 RID: 3473
			public int MapID;

			// Token: 0x04000D92 RID: 3474
			public int NeedLevel;

			// Token: 0x04000D93 RID: 3475
			public string FileName;

			// Token: 0x04000D94 RID: 3476
			public int StepSizeX;

			// Token: 0x04000D95 RID: 3477
			public int StepSizeY;

			// Token: 0x04000D96 RID: 3478
			public int StartUIX;

			// Token: 0x04000D97 RID: 3479
			public int StartUIY;

			// Token: 0x04000D98 RID: 3480
			public SeqListRef<int> BoxPreview;

			// Token: 0x04000D99 RID: 3481
			public string MapBgName;

			// Token: 0x04000D9A RID: 3482
			public string MapTittleName;

			// Token: 0x04000D9B RID: 3483
			public string MapGridBg;
		}
	}
}
