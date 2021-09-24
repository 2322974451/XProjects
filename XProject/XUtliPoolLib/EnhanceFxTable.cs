using System;

namespace XUtliPoolLib
{

	public class EnhanceFxTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			EnhanceFxTable.RowData rowData = new EnhanceFxTable.RowData();
			base.Read<uint>(reader, ref rowData.EnhanceLevel, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<string>(reader, ref rowData.MainWeaponFx, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.ProfID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Tips, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EnhanceFxTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public EnhanceFxTable.RowData[] Table = null;

		public class RowData
		{

			public uint EnhanceLevel;

			public string[] MainWeaponFx;

			public uint ProfID;

			public string Tips;
		}
	}
}
