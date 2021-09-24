using System;

namespace XUtliPoolLib
{

	public class ChestList : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			ChestList.RowData rowData = new ChestList.RowData();
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.DropID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.Profession, CVSReader.intParse);
			this.columnno = 5;
			base.Read<bool>(reader, ref rowData.MultiOpen, CVSReader.boolParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ChestList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ChestList.RowData[] Table = null;

		public class RowData
		{

			public int ItemID;

			public uint[] DropID;

			public int Profession;

			public bool MultiOpen;
		}
	}
}
