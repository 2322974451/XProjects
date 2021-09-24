using System;

namespace XUtliPoolLib
{

	public class DragonNestType : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			DragonNestType.RowData rowData = new DragonNestType.RowData();
			base.Read<uint>(reader, ref rowData.DragonNestType, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.TypeName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TypeBg, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.TypeIcon, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonNestType.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public DragonNestType.RowData[] Table = null;

		public class RowData
		{

			public uint DragonNestType;

			public string TypeName;

			public string TypeBg;

			public string TypeIcon;
		}
	}
}
