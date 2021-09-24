using System;

namespace XUtliPoolLib
{

	public class QAConditionTable : CVSReader
	{

		public QAConditionTable.RowData GetByQAType(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			QAConditionTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].QAType == key;
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
			QAConditionTable.RowData rowData = new QAConditionTable.RowData();
			base.Read<int>(reader, ref rowData.QAType, CVSReader.intParse);
			this.columnno = 0;
			rowData.LevelSection.Read(reader, this.m_DataHandler);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new QAConditionTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public QAConditionTable.RowData[] Table = null;

		public class RowData
		{

			public int QAType;

			public SeqListRef<uint> LevelSection;
		}
	}
}
