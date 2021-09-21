using System;

namespace XUtliPoolLib
{
	// Token: 0x0200012F RID: 303
	public class OpenSystemTable : CVSReader
	{
		// Token: 0x0600072E RID: 1838 RVA: 0x00023E4C File Offset: 0x0002204C
		public OpenSystemTable.RowData GetBySystemID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			OpenSystemTable.RowData result;
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

		// Token: 0x0600072F RID: 1839 RVA: 0x00023E84 File Offset: 0x00022084
		private OpenSystemTable.RowData BinarySearchSystemID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			OpenSystemTable.RowData rowData;
			OpenSystemTable.RowData rowData2;
			OpenSystemTable.RowData rowData3;
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

		// Token: 0x06000730 RID: 1840 RVA: 0x00023F60 File Offset: 0x00022160
		protected override void ReadLine(XBinaryReader reader)
		{
			OpenSystemTable.RowData rowData = new OpenSystemTable.RowData();
			base.Read<int>(reader, ref rowData.PlayerLevel, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.SystemDescription, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.Priority, CVSReader.intParse);
			this.columnno = 6;
			base.ReadArray<int>(reader, ref rowData.TitanItems, CVSReader.intParse);
			this.columnno = 7;
			base.ReadArray<uint>(reader, ref rowData.NoRedPointLevel, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.OpenDay, CVSReader.uintParse);
			this.columnno = 11;
			rowData.BackServerOpenDay.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			base.Read<bool>(reader, ref rowData.InNotice, CVSReader.boolParse);
			this.columnno = 14;
			rowData.NoticeText.Read(reader, this.m_DataHandler);
			this.columnno = 15;
			rowData.NoticeIcon.Read(reader, this.m_DataHandler);
			this.columnno = 16;
			base.ReadArray<string>(reader, ref rowData.NoticeEffect, CVSReader.stringParse);
			this.columnno = 17;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x000240E4 File Offset: 0x000222E4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new OpenSystemTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400037B RID: 891
		public OpenSystemTable.RowData[] Table = null;

		// Token: 0x0200032E RID: 814
		public class RowData
		{
			// Token: 0x04000C55 RID: 3157
			public int PlayerLevel;

			// Token: 0x04000C56 RID: 3158
			public int SystemID;

			// Token: 0x04000C57 RID: 3159
			public string SystemDescription;

			// Token: 0x04000C58 RID: 3160
			public string Icon;

			// Token: 0x04000C59 RID: 3161
			public int Priority;

			// Token: 0x04000C5A RID: 3162
			public int[] TitanItems;

			// Token: 0x04000C5B RID: 3163
			public uint[] NoRedPointLevel;

			// Token: 0x04000C5C RID: 3164
			public uint OpenDay;

			// Token: 0x04000C5D RID: 3165
			public SeqListRef<uint> BackServerOpenDay;

			// Token: 0x04000C5E RID: 3166
			public bool InNotice;

			// Token: 0x04000C5F RID: 3167
			public SeqListRef<string> NoticeText;

			// Token: 0x04000C60 RID: 3168
			public SeqListRef<string> NoticeIcon;

			// Token: 0x04000C61 RID: 3169
			public string[] NoticeEffect;
		}
	}
}
