using System;

namespace XUtliPoolLib
{

	public class SystemHelpTable : CVSReader
	{

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

		public SystemHelpTable.RowData[] Table = null;

		public class RowData
		{

			public int SystemID;

			public string[] SystemHelp;
		}
	}
}
