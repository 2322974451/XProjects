using System;

namespace XUtliPoolLib
{

	public class CharacterCommonInfo : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			CharacterCommonInfo.RowData rowData = new CharacterCommonInfo.RowData();
			base.Read<string>(reader, ref rowData.ShowText, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new CharacterCommonInfo.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public CharacterCommonInfo.RowData[] Table = null;

		public class RowData
		{

			public string ShowText;

			public uint Type;
		}
	}
}
