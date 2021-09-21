using System;

namespace XUtliPoolLib
{
	// Token: 0x02000255 RID: 597
	public class PrerogativeContent : CVSReader
	{
		// Token: 0x06000CF8 RID: 3320 RVA: 0x00044550 File Offset: 0x00042750
		public PrerogativeContent.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PrerogativeContent.RowData result;
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

		// Token: 0x06000CF9 RID: 3321 RVA: 0x00044588 File Offset: 0x00042788
		private PrerogativeContent.RowData BinarySearchID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			PrerogativeContent.RowData rowData;
			PrerogativeContent.RowData rowData2;
			PrerogativeContent.RowData rowData3;
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

		// Token: 0x06000CFA RID: 3322 RVA: 0x00044664 File Offset: 0x00042864
		protected override void ReadLine(XBinaryReader reader)
		{
			PrerogativeContent.RowData rowData = new PrerogativeContent.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Content, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Normal, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 4;
			rowData.Item.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.HintID, CVSReader.uintParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x00044760 File Offset: 0x00042960
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PrerogativeContent.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007A3 RID: 1955
		public PrerogativeContent.RowData[] Table = null;

		// Token: 0x020003E4 RID: 996
		public class RowData
		{
			// Token: 0x04001199 RID: 4505
			public uint ID;

			// Token: 0x0400119A RID: 4506
			public uint Type;

			// Token: 0x0400119B RID: 4507
			public string Content;

			// Token: 0x0400119C RID: 4508
			public uint Normal;

			// Token: 0x0400119D RID: 4509
			public string Icon;

			// Token: 0x0400119E RID: 4510
			public SeqRef<uint> Item;

			// Token: 0x0400119F RID: 4511
			public string Name;

			// Token: 0x040011A0 RID: 4512
			public uint HintID;
		}
	}
}
