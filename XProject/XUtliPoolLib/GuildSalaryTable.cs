using System;

namespace XUtliPoolLib
{

	public class GuildSalaryTable : CVSReader
	{

		public GuildSalaryTable.RowData GetByGuildLevel(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildSalaryTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].GuildLevel == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			GuildSalaryTable.RowData rowData = new GuildSalaryTable.RowData();
			base.Read<uint>(reader, ref rowData.GuildLevel, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.GuildReview, CVSReader.uintParse);
			this.columnno = 1;
			rowData.NumberTransformation.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.PrestigeTransformation.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.ActiveTransformation.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.EXPTransformation.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			rowData.SSalary1.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			rowData.SSalary2.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			rowData.SSalary3.Read(reader, this.m_DataHandler);
			this.columnno = 9;
			rowData.SSalary4.Read(reader, this.m_DataHandler);
			this.columnno = 10;
			rowData.SSalary5.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			rowData.ASalary1.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			rowData.ASalary2.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			rowData.ASalary3.Read(reader, this.m_DataHandler);
			this.columnno = 14;
			rowData.ASalary4.Read(reader, this.m_DataHandler);
			this.columnno = 15;
			rowData.ASalary5.Read(reader, this.m_DataHandler);
			this.columnno = 16;
			rowData.BSalary1.Read(reader, this.m_DataHandler);
			this.columnno = 17;
			rowData.BSalary2.Read(reader, this.m_DataHandler);
			this.columnno = 18;
			rowData.BSalary3.Read(reader, this.m_DataHandler);
			this.columnno = 19;
			rowData.BSalary4.Read(reader, this.m_DataHandler);
			this.columnno = 20;
			rowData.BSalary5.Read(reader, this.m_DataHandler);
			this.columnno = 21;
			rowData.CSalary1.Read(reader, this.m_DataHandler);
			this.columnno = 22;
			rowData.CSalary2.Read(reader, this.m_DataHandler);
			this.columnno = 23;
			rowData.CSalary3.Read(reader, this.m_DataHandler);
			this.columnno = 24;
			rowData.CSalary4.Read(reader, this.m_DataHandler);
			this.columnno = 25;
			rowData.CSalary5.Read(reader, this.m_DataHandler);
			this.columnno = 26;
			rowData.DSalary1.Read(reader, this.m_DataHandler);
			this.columnno = 27;
			rowData.DSalary2.Read(reader, this.m_DataHandler);
			this.columnno = 28;
			rowData.DSalary3.Read(reader, this.m_DataHandler);
			this.columnno = 29;
			rowData.DSalary4.Read(reader, this.m_DataHandler);
			this.columnno = 30;
			rowData.DSalary5.Read(reader, this.m_DataHandler);
			this.columnno = 31;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildSalaryTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildSalaryTable.RowData[] Table = null;

		public class RowData
		{

			public uint GuildLevel;

			public uint[] GuildReview;

			public SeqListRef<uint> NumberTransformation;

			public SeqListRef<uint> PrestigeTransformation;

			public SeqListRef<uint> ActiveTransformation;

			public SeqListRef<uint> EXPTransformation;

			public SeqListRef<uint> SSalary1;

			public SeqListRef<uint> SSalary2;

			public SeqListRef<uint> SSalary3;

			public SeqListRef<uint> SSalary4;

			public SeqListRef<uint> SSalary5;

			public SeqListRef<uint> ASalary1;

			public SeqListRef<uint> ASalary2;

			public SeqListRef<uint> ASalary3;

			public SeqListRef<uint> ASalary4;

			public SeqListRef<uint> ASalary5;

			public SeqListRef<uint> BSalary1;

			public SeqListRef<uint> BSalary2;

			public SeqListRef<uint> BSalary3;

			public SeqListRef<uint> BSalary4;

			public SeqListRef<uint> BSalary5;

			public SeqListRef<uint> CSalary1;

			public SeqListRef<uint> CSalary2;

			public SeqListRef<uint> CSalary3;

			public SeqListRef<uint> CSalary4;

			public SeqListRef<uint> CSalary5;

			public SeqListRef<uint> DSalary1;

			public SeqListRef<uint> DSalary2;

			public SeqListRef<uint> DSalary3;

			public SeqListRef<uint> DSalary4;

			public SeqListRef<uint> DSalary5;
		}
	}
}
