using System;

namespace XUtliPoolLib
{
	// Token: 0x02000124 RID: 292
	public class JadeTable : CVSReader
	{
		// Token: 0x06000702 RID: 1794 RVA: 0x00022E44 File Offset: 0x00021044
		public JadeTable.RowData GetByJadeID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			JadeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchJadeID(key);
			}
			return result;
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x00022E7C File Offset: 0x0002107C
		private JadeTable.RowData BinarySearchJadeID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			JadeTable.RowData rowData;
			JadeTable.RowData rowData2;
			JadeTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.JadeID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.JadeID == key;
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
				bool flag4 = rowData3.JadeID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.JadeID.CompareTo(key) < 0;
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

		// Token: 0x06000704 RID: 1796 RVA: 0x00022F58 File Offset: 0x00021158
		protected override void ReadLine(XBinaryReader reader)
		{
			JadeTable.RowData rowData = new JadeTable.RowData();
			base.Read<uint>(reader, ref rowData.JadeID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.JadeEquip, CVSReader.uintParse);
			this.columnno = 1;
			rowData.JadeAttributes.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.JadeCompose.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.JadeLevel, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.MosaicPlace, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x00023020 File Offset: 0x00021220
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new JadeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000370 RID: 880
		public JadeTable.RowData[] Table = null;

		// Token: 0x02000323 RID: 803
		public class RowData
		{
			// Token: 0x04000C17 RID: 3095
			public uint JadeID;

			// Token: 0x04000C18 RID: 3096
			public uint JadeEquip;

			// Token: 0x04000C19 RID: 3097
			public SeqListRef<uint> JadeAttributes;

			// Token: 0x04000C1A RID: 3098
			public SeqRef<uint> JadeCompose;

			// Token: 0x04000C1B RID: 3099
			public uint JadeLevel;

			// Token: 0x04000C1C RID: 3100
			public string MosaicPlace;
		}
	}
}
