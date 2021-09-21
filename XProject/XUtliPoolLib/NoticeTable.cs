using System;

namespace XUtliPoolLib
{
	// Token: 0x0200012D RID: 301
	public class NoticeTable : CVSReader
	{
		// Token: 0x06000725 RID: 1829 RVA: 0x00023B28 File Offset: 0x00021D28
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

		// Token: 0x06000726 RID: 1830 RVA: 0x00023B60 File Offset: 0x00021D60
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

		// Token: 0x06000727 RID: 1831 RVA: 0x00023C3C File Offset: 0x00021E3C
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

		// Token: 0x06000728 RID: 1832 RVA: 0x00023CE8 File Offset: 0x00021EE8
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

		// Token: 0x04000379 RID: 889
		public NoticeTable.RowData[] Table = null;

		// Token: 0x0200032C RID: 812
		public class RowData
		{
			// Token: 0x04000C4D RID: 3149
			public uint id;

			// Token: 0x04000C4E RID: 3150
			public int channel;

			// Token: 0x04000C4F RID: 3151
			public string info;

			// Token: 0x04000C50 RID: 3152
			public uint linkparam;

			// Token: 0x04000C51 RID: 3153
			public string linkcontent;
		}
	}
}
