using System;

namespace XUtliPoolLib
{
	// Token: 0x02000188 RID: 392
	public class XOptions : CVSReader
	{
		// Token: 0x0600087A RID: 2170 RVA: 0x0002DC20 File Offset: 0x0002BE20
		public XOptions.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			XOptions.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchID(key);
			}
			return result;
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x0002DC58 File Offset: 0x0002BE58
		private XOptions.RowData BinarySearchID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			XOptions.RowData rowData;
			XOptions.RowData rowData2;
			XOptions.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.ID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.ID == key;
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
				bool flag4 = rowData3.ID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.ID.CompareTo(key) < 0;
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

		// Token: 0x0600087C RID: 2172 RVA: 0x0002DD34 File Offset: 0x0002BF34
		protected override void ReadLine(XBinaryReader reader)
		{
			XOptions.RowData rowData = new XOptions.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<int>(reader, ref rowData.Classify, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Sort, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Text, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Range, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Default, CVSReader.stringParse);
			this.columnno = 6;
			base.ReadArray<string>(reader, ref rowData.OptionText, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x0002DE30 File Offset: 0x0002C030
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new XOptions.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003D4 RID: 980
		public XOptions.RowData[] Table = null;

		// Token: 0x02000387 RID: 903
		public class RowData
		{
			// Token: 0x04000FB7 RID: 4023
			public int ID;

			// Token: 0x04000FB8 RID: 4024
			public int[] Classify;

			// Token: 0x04000FB9 RID: 4025
			public int Sort;

			// Token: 0x04000FBA RID: 4026
			public string Text;

			// Token: 0x04000FBB RID: 4027
			public int Type;

			// Token: 0x04000FBC RID: 4028
			public string Range;

			// Token: 0x04000FBD RID: 4029
			public string Default;

			// Token: 0x04000FBE RID: 4030
			public string[] OptionText;
		}
	}
}
