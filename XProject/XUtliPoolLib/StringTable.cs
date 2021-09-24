using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{

	public class StringTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			uint key = 0U;
			string value = "";
			base.Read<uint>(reader, ref key, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref value, CVSReader.stringParse);
			this.columnno = 1;
			this.Table[key] = value;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			this.Table.Clear();
		}

		public Dictionary<uint, string> Table = new Dictionary<uint, string>();

		public class RowData
		{

			public string Enum;

			public string Text;
		}
	}
}
