using System;

namespace XUtliPoolLib
{

	public class BattleFieldPointReward : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			BattleFieldPointReward.RowData rowData = new BattleFieldPointReward.RowData();
			rowData.levelrange.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.point, CVSReader.intParse);
			this.columnno = 1;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.count, CVSReader.uintParse);
			this.columnno = 4;
			rowData.pointseg.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BattleFieldPointReward.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public BattleFieldPointReward.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<int> levelrange;

			public int point;

			public SeqListRef<int> reward;

			public uint id;

			public uint count;

			public SeqRef<uint> pointseg;
		}
	}
}
