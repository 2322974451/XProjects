using System;

namespace XUtliPoolLib
{

	public class SuperActivity : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			SuperActivity.RowData rowData = new SuperActivity.RowData();
			base.Read<uint>(reader, ref rowData.actid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<string>(reader, ref rowData.childs, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.offset, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.belong, CVSReader.uintParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SuperActivity.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public SuperActivity.RowData[] Table = null;

		public class RowData
		{

			public uint actid;

			public uint id;

			public string[] childs;

			public uint offset;

			public string icon;

			public string name;

			public uint belong;
		}
	}
}
