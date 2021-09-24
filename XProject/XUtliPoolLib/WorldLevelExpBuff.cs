using System;

namespace XUtliPoolLib
{

	public class WorldLevelExpBuff : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			WorldLevelExpBuff.RowData rowData = new WorldLevelExpBuff.RowData();
			base.Read<uint>(reader, ref rowData.WorldLevel, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Level.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<double>(reader, ref rowData.ExpBuff, CVSReader.doubleParse);
			this.columnno = 2;
			base.Read<double>(reader, ref rowData.BackExpBuff, CVSReader.doubleParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.BackflowLevel, CVSReader.uintParse);
			this.columnno = 4;
			rowData.BackBattleBuff.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new WorldLevelExpBuff.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public WorldLevelExpBuff.RowData[] Table = null;

		public class RowData
		{

			public uint WorldLevel;

			public SeqRef<uint> Level;

			public double ExpBuff;

			public double BackExpBuff;

			public uint BackflowLevel;

			public SeqRef<uint> BackBattleBuff;
		}
	}
}
