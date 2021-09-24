using System;

namespace XUtliPoolLib
{

	public class OnlineRewardTable : CVSReader
	{

		public OnlineRewardTable.RowData GetBytime(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			OnlineRewardTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].time == key;
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
			OnlineRewardTable.RowData rowData = new OnlineRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.time, CVSReader.uintParse);
			this.columnno = 0;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.RewardTip, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new OnlineRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public OnlineRewardTable.RowData[] Table = null;

		public class RowData
		{

			public uint time;

			public SeqListRef<uint> reward;

			public string RewardTip;
		}
	}
}
