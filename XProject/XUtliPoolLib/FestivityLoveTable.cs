using System;

namespace XUtliPoolLib
{

	public class FestivityLoveTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			FestivityLoveTable.RowData rowData = new FestivityLoveTable.RowData();
			base.Read<uint>(reader, ref rowData.LoveScore, CVSReader.uintParse);
			this.columnno = 0;
			rowData.LoveGift.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.GiftIcon, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FestivityLoveTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FestivityLoveTable.RowData[] Table = null;

		public class RowData
		{

			public uint LoveScore;

			public SeqListRef<uint> LoveGift;

			public string GiftIcon;
		}
	}
}
