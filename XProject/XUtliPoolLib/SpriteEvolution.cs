using System;

namespace XUtliPoolLib
{

	public class SpriteEvolution : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			SpriteEvolution.RowData rowData = new SpriteEvolution.RowData();
			base.Read<uint>(reader, ref rowData.SpriteID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<byte>(reader, ref rowData.Quality, CVSReader.byteParse);
			this.columnno = 1;
			base.Read<byte>(reader, ref rowData.EvolutionLevel, CVSReader.byteParse);
			this.columnno = 2;
			base.Read<byte>(reader, ref rowData.LevelLimit, CVSReader.byteParse);
			this.columnno = 3;
			rowData.EvolutionCost.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.TrainExp.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.ResetTrainCost.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SpriteEvolution.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public SpriteEvolution.RowData[] Table = null;

		public class RowData
		{

			public uint SpriteID;

			public byte Quality;

			public byte EvolutionLevel;

			public byte LevelLimit;

			public SeqRef<uint> EvolutionCost;

			public SeqRef<uint> TrainExp;

			public SeqListRef<uint> ResetTrainCost;
		}
	}
}
