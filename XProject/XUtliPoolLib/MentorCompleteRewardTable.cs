using System;

namespace XUtliPoolLib
{
	// Token: 0x02000129 RID: 297
	public class MentorCompleteRewardTable : CVSReader
	{
		// Token: 0x06000715 RID: 1813 RVA: 0x00023540 File Offset: 0x00021740
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

		// Token: 0x06000716 RID: 1814 RVA: 0x000235AC File Offset: 0x000217AC
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

		// Token: 0x06000717 RID: 1815 RVA: 0x00023624 File Offset: 0x00021824
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

		// Token: 0x04000375 RID: 885
		public MentorCompleteRewardTable.RowData[] Table = null;

		// Token: 0x02000328 RID: 808
		public class RowData
		{
			// Token: 0x04000C34 RID: 3124
			public int Type;

			// Token: 0x04000C35 RID: 3125
			public SeqListRef<int> MasterReward;

			// Token: 0x04000C36 RID: 3126
			public SeqListRef<int> StudentReward;
		}
	}
}
