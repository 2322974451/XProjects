using System;

namespace XUtliPoolLib
{
	// Token: 0x02000158 RID: 344
	public class PVPActivityList : CVSReader
	{
		// Token: 0x060007BD RID: 1981 RVA: 0x000273F0 File Offset: 0x000255F0
		public PVPActivityList.RowData GetBySysID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PVPActivityList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SysID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0002745C File Offset: 0x0002565C
		protected override void ReadLine(XBinaryReader reader)
		{
			PVPActivityList.RowData rowData = new PVPActivityList.RowData();
			base.Read<uint>(reader, ref rowData.SysID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x000274D4 File Offset: 0x000256D4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PVPActivityList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003A4 RID: 932
		public PVPActivityList.RowData[] Table = null;

		// Token: 0x02000357 RID: 855
		public class RowData
		{
			// Token: 0x04000D5F RID: 3423
			public uint SysID;

			// Token: 0x04000D60 RID: 3424
			public string Description;

			// Token: 0x04000D61 RID: 3425
			public string Icon;
		}
	}
}
