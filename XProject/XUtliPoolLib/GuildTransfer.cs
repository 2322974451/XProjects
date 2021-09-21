using System;

namespace XUtliPoolLib
{
	// Token: 0x02000119 RID: 281
	public class GuildTransfer : CVSReader
	{
		// Token: 0x060006D4 RID: 1748 RVA: 0x0002198C File Offset: 0x0001FB8C
		public GuildTransfer.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildTransfer.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].id == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x000219F8 File Offset: 0x0001FBF8
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildTransfer.RowData rowData = new GuildTransfer.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.sceneid, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x00021A8C File Offset: 0x0001FC8C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildTransfer.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000365 RID: 869
		public GuildTransfer.RowData[] Table = null;

		// Token: 0x02000318 RID: 792
		public class RowData
		{
			// Token: 0x04000BB9 RID: 3001
			public uint id;

			// Token: 0x04000BBA RID: 3002
			public string name;

			// Token: 0x04000BBB RID: 3003
			public uint sceneid;

			// Token: 0x04000BBC RID: 3004
			public string icon;
		}
	}
}
