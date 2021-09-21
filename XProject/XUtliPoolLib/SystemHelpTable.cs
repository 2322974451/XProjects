using System;

namespace XUtliPoolLib
{
	// Token: 0x0200017A RID: 378
	public class SystemHelpTable : CVSReader
	{
		// Token: 0x06000840 RID: 2112 RVA: 0x0002B484 File Offset: 0x00029684
		public SystemHelpTable.RowData GetBySystemID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SystemHelpTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchSystemID(key);
			}
			return result;
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x0002B4BC File Offset: 0x000296BC
		private SystemHelpTable.RowData BinarySearchSystemID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			SystemHelpTable.RowData rowData;
			SystemHelpTable.RowData rowData2;
			SystemHelpTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.SystemID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.SystemID == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.SystemID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.SystemID.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x0002B598 File Offset: 0x00029798
		protected override void ReadLine(XBinaryReader reader)
		{
			SystemHelpTable.RowData rowData = new SystemHelpTable.RowData();
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<string>(reader, ref rowData.SystemHelp, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x0002B5F8 File Offset: 0x000297F8
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SystemHelpTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003C6 RID: 966
		public SystemHelpTable.RowData[] Table = null;

		// Token: 0x02000379 RID: 889
		public class RowData
		{
			// Token: 0x04000EC1 RID: 3777
			public int SystemID;

			// Token: 0x04000EC2 RID: 3778
			public string[] SystemHelp;
		}
	}
}
