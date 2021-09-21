using System;

namespace XUtliPoolLib
{
	// Token: 0x020000F9 RID: 249
	public class FpGoToLevelUp : CVSReader
	{
		// Token: 0x0600065B RID: 1627 RVA: 0x0001EBF4 File Offset: 0x0001CDF4
		protected override void ReadLine(XBinaryReader reader)
		{
			FpGoToLevelUp.RowData rowData = new FpGoToLevelUp.RowData();
			base.Read<uint>(reader, ref rowData.Id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SystemId, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Tips, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.IconName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.StarNum, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.IsRecommond, CVSReader.uintParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0001ECD4 File Offset: 0x0001CED4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FpGoToLevelUp.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000345 RID: 837
		public FpGoToLevelUp.RowData[] Table = null;

		// Token: 0x020002F8 RID: 760
		public class RowData
		{
			// Token: 0x04000AF0 RID: 2800
			public uint Id;

			// Token: 0x04000AF1 RID: 2801
			public string Name;

			// Token: 0x04000AF2 RID: 2802
			public uint SystemId;

			// Token: 0x04000AF3 RID: 2803
			public string Tips;

			// Token: 0x04000AF4 RID: 2804
			public string IconName;

			// Token: 0x04000AF5 RID: 2805
			public uint StarNum;

			// Token: 0x04000AF6 RID: 2806
			public uint IsRecommond;
		}
	}
}
