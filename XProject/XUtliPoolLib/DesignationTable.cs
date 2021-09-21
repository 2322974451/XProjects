using System;

namespace XUtliPoolLib
{
	// Token: 0x020000DA RID: 218
	public class DesignationTable : CVSReader
	{
		// Token: 0x060005EB RID: 1515 RVA: 0x0001BC30 File Offset: 0x00019E30
		public DesignationTable.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DesignationTable.RowData result;
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

		// Token: 0x060005EC RID: 1516 RVA: 0x0001BC68 File Offset: 0x00019E68
		private DesignationTable.RowData BinarySearchID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			DesignationTable.RowData rowData;
			DesignationTable.RowData rowData2;
			DesignationTable.RowData rowData3;
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

		// Token: 0x060005ED RID: 1517 RVA: 0x0001BD44 File Offset: 0x00019F44
		protected override void ReadLine(XBinaryReader reader)
		{
			DesignationTable.RowData rowData = new DesignationTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Designation, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Explanation, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.CompleteType, CVSReader.intParse);
			this.columnno = 4;
			base.ReadArray<int>(reader, ref rowData.CompleteValue, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.Pragmaticality, CVSReader.intParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.Effect, CVSReader.stringParse);
			this.columnno = 7;
			rowData.Attribute.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.Color, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.GainShowIcon, CVSReader.intParse);
			this.columnno = 10;
			base.Read<int>(reader, ref rowData.SortID, CVSReader.intParse);
			this.columnno = 11;
			rowData.Level.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			base.Read<bool>(reader, ref rowData.ShowInChat, CVSReader.boolParse);
			this.columnno = 13;
			base.Read<int>(reader, ref rowData.Channel, CVSReader.intParse);
			this.columnno = 14;
			base.Read<string>(reader, ref rowData.Atlas, CVSReader.stringParse);
			this.columnno = 15;
			base.Read<bool>(reader, ref rowData.Special, CVSReader.boolParse);
			this.columnno = 16;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x0001BF30 File Offset: 0x0001A130
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DesignationTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000326 RID: 806
		public DesignationTable.RowData[] Table = null;

		// Token: 0x020002D9 RID: 729
		public class RowData
		{
			// Token: 0x040009F9 RID: 2553
			public int ID;

			// Token: 0x040009FA RID: 2554
			public string Designation;

			// Token: 0x040009FB RID: 2555
			public int Type;

			// Token: 0x040009FC RID: 2556
			public string Explanation;

			// Token: 0x040009FD RID: 2557
			public int CompleteType;

			// Token: 0x040009FE RID: 2558
			public int[] CompleteValue;

			// Token: 0x040009FF RID: 2559
			public int Pragmaticality;

			// Token: 0x04000A00 RID: 2560
			public string Effect;

			// Token: 0x04000A01 RID: 2561
			public SeqListRef<uint> Attribute;

			// Token: 0x04000A02 RID: 2562
			public string Color;

			// Token: 0x04000A03 RID: 2563
			public int GainShowIcon;

			// Token: 0x04000A04 RID: 2564
			public int SortID;

			// Token: 0x04000A05 RID: 2565
			public SeqRef<int> Level;

			// Token: 0x04000A06 RID: 2566
			public bool ShowInChat;

			// Token: 0x04000A07 RID: 2567
			public int Channel;

			// Token: 0x04000A08 RID: 2568
			public string Atlas;

			// Token: 0x04000A09 RID: 2569
			public bool Special;
		}
	}
}
