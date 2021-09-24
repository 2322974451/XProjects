using System;

namespace XUtliPoolLib
{

	public class NoticeTable : CVSReader
	{

		public NoticeTable.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			NoticeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchid(key);
			}
			return result;
		}

		private NoticeTable.RowData BinarySearchid(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			NoticeTable.RowData rowData;
			NoticeTable.RowData rowData2;
			NoticeTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.id == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.id == key;
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
				bool flag4 = rowData3.id.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.id.CompareTo(key) < 0;
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
			NoticeTable.RowData rowData = new NoticeTable.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.channel, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.info, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.linkparam, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.linkcontent, CVSReader.stringParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new NoticeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public NoticeTable.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public int channel;

			public string info;

			public uint linkparam;

			public string linkcontent;
		}
	}
}
