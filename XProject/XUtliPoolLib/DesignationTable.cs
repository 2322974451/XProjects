using System;

namespace XUtliPoolLib
{

	public class DesignationTable : CVSReader
	{

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

		public DesignationTable.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public string Designation;

			public int Type;

			public string Explanation;

			public int CompleteType;

			public int[] CompleteValue;

			public int Pragmaticality;

			public string Effect;

			public SeqListRef<uint> Attribute;

			public string Color;

			public int GainShowIcon;

			public int SortID;

			public SeqRef<int> Level;

			public bool ShowInChat;

			public int Channel;

			public string Atlas;

			public bool Special;
		}
	}
}
