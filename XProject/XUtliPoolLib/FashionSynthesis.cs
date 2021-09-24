using System;

namespace XUtliPoolLib
{

	public class FashionSynthesis : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			FashionSynthesis.RowData rowData = new FashionSynthesis.RowData();
			base.Read<uint>(reader, ref rowData.FashionID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.SuccessRate, CVSReader.uintParse);
			this.columnno = 1;
			rowData.ReturnItems.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SuitID, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.FashinSynthesisAddSucessRate, CVSReader.uintParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionSynthesis.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FashionSynthesis.RowData[] Table = null;

		public class RowData
		{

			public uint FashionID;

			public uint SuccessRate;

			public SeqListRef<uint> ReturnItems;

			public uint SuitID;

			public uint FashinSynthesisAddSucessRate;
		}
	}
}
