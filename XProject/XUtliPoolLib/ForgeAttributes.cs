using System;

namespace XUtliPoolLib
{

	public class ForgeAttributes : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			ForgeAttributes.RowData rowData = new ForgeAttributes.RowData();
			base.Read<uint>(reader, ref rowData.EquipID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<byte>(reader, ref rowData.Slot, CVSReader.byteParse);
			this.columnno = 1;
			base.Read<byte>(reader, ref rowData.AttrID, CVSReader.byteParse);
			this.columnno = 2;
			base.Read<byte>(reader, ref rowData.Prob, CVSReader.byteParse);
			this.columnno = 3;
			rowData.Range.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			base.Read<byte>(reader, ref rowData.CanSmelt, CVSReader.byteParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ForgeAttributes.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public ForgeAttributes.RowData[] Table = null;

		public class RowData
		{

			public uint EquipID;

			public byte Slot;

			public byte AttrID;

			public byte Prob;

			public SeqRef<uint> Range;

			public byte CanSmelt;
		}
	}
}
