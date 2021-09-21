using System;

namespace XUtliPoolLib
{
	// Token: 0x02000189 RID: 393
	public class XQTEStatusTable : CVSReader
	{
		// Token: 0x0600087F RID: 2175 RVA: 0x0002DE70 File Offset: 0x0002C070
		public XQTEStatusTable.RowData GetByValue(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			XQTEStatusTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Value == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x0002DEDC File Offset: 0x0002C0DC
		protected override void ReadLine(XBinaryReader reader)
		{
			XQTEStatusTable.RowData rowData = new XQTEStatusTable.RowData();
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Value, CVSReader.uintParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x0002DF3C File Offset: 0x0002C13C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new XQTEStatusTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003D5 RID: 981
		public XQTEStatusTable.RowData[] Table = null;

		// Token: 0x02000388 RID: 904
		public class RowData
		{
			// Token: 0x04000FBF RID: 4031
			public string Name;

			// Token: 0x04000FC0 RID: 4032
			public uint Value;
		}
	}
}
