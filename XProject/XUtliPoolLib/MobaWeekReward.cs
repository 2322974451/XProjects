using System;

namespace XUtliPoolLib
{

	public class MobaWeekReward : CVSReader
	{

		public MobaWeekReward.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			MobaWeekReward.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].id == key;
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
			MobaWeekReward.RowData rowData = new MobaWeekReward.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.winnum, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.reward, CVSReader.uintParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new MobaWeekReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public MobaWeekReward.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public uint winnum;

			public uint[] reward;
		}
	}
}
