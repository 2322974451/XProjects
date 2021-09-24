using System;

namespace XUtliPoolLib
{

	public class FashionComposeSet : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			FashionComposeSet.RowData rowData = new FashionComposeSet.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.LevelSeal, CVSReader.uintParse);
			this.columnno = 1;
			rowData.Time.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			rowData.FashionSet.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionComposeSet.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FashionComposeSet.RowData[] Table = null;

		public class RowData
		{

			public uint Type;

			public uint LevelSeal;

			public SeqRef<string> Time;

			public SeqRef<uint> FashionSet;
		}
	}
}
