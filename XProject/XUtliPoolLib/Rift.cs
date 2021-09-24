using System;

namespace XUtliPoolLib
{

	public class Rift : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			Rift.RowData rowData = new Rift.RowData();
			base.Read<int>(reader, ref rowData.id, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.floor, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.attack, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.hp, CVSReader.intParse);
			this.columnno = 3;
			rowData.weekfirstpass.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.weekcommonpass.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.buffcounts, CVSReader.intParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.RecommendPower, CVSReader.uintParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new Rift.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public Rift.RowData[] Table = null;

		public class RowData
		{

			public int id;

			public int floor;

			public int attack;

			public int hp;

			public SeqListRef<uint> weekfirstpass;

			public SeqListRef<uint> weekcommonpass;

			public int buffcounts;

			public uint RecommendPower;
		}
	}
}
