using System;

namespace XUtliPoolLib
{

	public class PowerPointCoeffTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PowerPointCoeffTable.RowData rowData = new PowerPointCoeffTable.RowData();
			base.Read<int>(reader, ref rowData.AttributeID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Profession, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<double>(reader, ref rowData.Weight, CVSReader.doubleParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PowerPointCoeffTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PowerPointCoeffTable.RowData[] Table = null;

		public class RowData
		{

			public int AttributeID;

			public uint Profession;

			public double Weight;
		}
	}
}
