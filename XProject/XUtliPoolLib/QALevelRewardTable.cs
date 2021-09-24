using System;

namespace XUtliPoolLib
{

	public class QALevelRewardTable : CVSReader
	{

		public QALevelRewardTable.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			QALevelRewardTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
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
			QALevelRewardTable.RowData rowData = new QALevelRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.QAType, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.MinLevel, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.MaxLevel, CVSReader.uintParse);
			this.columnno = 3;
			rowData.Reward.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.ExtraReward.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new QALevelRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public QALevelRewardTable.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public uint QAType;

			public uint MinLevel;

			public uint MaxLevel;

			public SeqListRef<uint> Reward;

			public SeqListRef<uint> ExtraReward;
		}
	}
}
