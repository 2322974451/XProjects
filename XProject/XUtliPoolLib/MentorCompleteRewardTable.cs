using System;

namespace XUtliPoolLib
{

	public class MentorCompleteRewardTable : CVSReader
	{

		public MentorCompleteRewardTable.RowData GetByType(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			MentorCompleteRewardTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Type == key;
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
			MentorCompleteRewardTable.RowData rowData = new MentorCompleteRewardTable.RowData();
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 0;
			rowData.MasterReward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.StudentReward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new MentorCompleteRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public MentorCompleteRewardTable.RowData[] Table = null;

		public class RowData
		{

			public int Type;

			public SeqListRef<int> MasterReward;

			public SeqListRef<int> StudentReward;
		}
	}
}
