using System;

namespace XUtliPoolLib
{
	// Token: 0x02000123 RID: 291
	public class ItemUseButtonList : CVSReader
	{
		// Token: 0x060006FF RID: 1791 RVA: 0x00022D70 File Offset: 0x00020F70
		protected override void ReadLine(XBinaryReader reader)
		{
			ItemUseButtonList.RowData rowData = new ItemUseButtonList.RowData();
			base.Read<uint>(reader, ref rowData.ItemID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ButtonName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SystemID, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.TypeID, CVSReader.uintParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x00022E04 File Offset: 0x00021004
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ItemUseButtonList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400036F RID: 879
		public ItemUseButtonList.RowData[] Table = null;

		// Token: 0x02000322 RID: 802
		public class RowData
		{
			// Token: 0x04000C13 RID: 3091
			public uint ItemID;

			// Token: 0x04000C14 RID: 3092
			public string ButtonName;

			// Token: 0x04000C15 RID: 3093
			public uint SystemID;

			// Token: 0x04000C16 RID: 3094
			public uint TypeID;
		}
	}
}
