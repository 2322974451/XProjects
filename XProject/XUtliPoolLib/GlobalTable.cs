using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x02000101 RID: 257
	public class GlobalTable : CVSReader
	{
		// Token: 0x0600067A RID: 1658 RVA: 0x0001F848 File Offset: 0x0001DA48
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

		// Token: 0x0600067B RID: 1659 RVA: 0x0001F89F File Offset: 0x0001DA9F
		protected override void OnClear(int lineCount)
		{
			this.Table.Clear();
		}

		// Token: 0x0400034D RID: 845
		public Dictionary<uint, string> Table = new Dictionary<uint, string>();

		// Token: 0x02000300 RID: 768
		public class RowData
		{
			// Token: 0x04000B29 RID: 2857
			public string Name;

			// Token: 0x04000B2A RID: 2858
			public string Value;
		}
	}
}
