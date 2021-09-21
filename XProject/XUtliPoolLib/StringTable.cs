using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x02000174 RID: 372
	public class StringTable : CVSReader
	{
		// Token: 0x0600082A RID: 2090 RVA: 0x0002ABA0 File Offset: 0x00028DA0
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

		// Token: 0x0600082B RID: 2091 RVA: 0x0002ABF7 File Offset: 0x00028DF7
		protected override void OnClear(int lineCount)
		{
			this.Table.Clear();
		}

		// Token: 0x040003C0 RID: 960
		public Dictionary<uint, string> Table = new Dictionary<uint, string>();

		// Token: 0x02000373 RID: 883
		public class RowData
		{
			// Token: 0x04000E94 RID: 3732
			public string Enum;

			// Token: 0x04000E95 RID: 3733
			public string Text;
		}
	}
}
