using System;

namespace XUtliPoolLib
{
	// Token: 0x02000162 RID: 354
	public class RechargeTable : CVSReader
	{
		// Token: 0x060007E4 RID: 2020 RVA: 0x0002800C File Offset: 0x0002620C
		protected override void ReadLine(XBinaryReader reader)
		{
			RechargeTable.RowData rowData = new RechargeTable.RowData();
			base.Read<string>(reader, ref rowData.ParamID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Price, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Diamond, CVSReader.intParse);
			this.columnno = 2;
			rowData.RoleLevels.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.LoginDays.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.ServiceCode, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x00028108 File Offset: 0x00026308
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RechargeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003AE RID: 942
		public RechargeTable.RowData[] Table = null;

		// Token: 0x02000361 RID: 865
		public class RowData
		{
			// Token: 0x04000D83 RID: 3459
			public string ParamID;

			// Token: 0x04000D84 RID: 3460
			public int Price;

			// Token: 0x04000D85 RID: 3461
			public int Diamond;

			// Token: 0x04000D86 RID: 3462
			public SeqListRef<int> RoleLevels;

			// Token: 0x04000D87 RID: 3463
			public SeqListRef<int> LoginDays;

			// Token: 0x04000D88 RID: 3464
			public int SystemID;

			// Token: 0x04000D89 RID: 3465
			public string Name;

			// Token: 0x04000D8A RID: 3466
			public string ServiceCode;
		}
	}
}
