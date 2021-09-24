using System;

namespace XUtliPoolLib
{

	public class FashionHair : CVSReader
	{

		public FashionHair.RowData GetByHairID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FashionHair.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].HairID == key;
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
			FashionHair.RowData rowData = new FashionHair.RowData();
			base.Read<uint>(reader, ref rowData.HairID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.DefaultColorID, CVSReader.uintParse);
			this.columnno = 2;
			base.ReadArray<uint>(reader, ref rowData.UnLookColorID, CVSReader.uintParse);
			this.columnno = 3;
			rowData.Cost.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionHair.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FashionHair.RowData[] Table = null;

		public class RowData
		{

			public uint HairID;

			public uint DefaultColorID;

			public uint[] UnLookColorID;

			public SeqListRef<uint> Cost;
		}
	}
}
