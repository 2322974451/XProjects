using System;

namespace XUtliPoolLib
{
	// Token: 0x02000111 RID: 273
	public class GuildMineralStorage : CVSReader
	{
		// Token: 0x060006B9 RID: 1721 RVA: 0x00020DD0 File Offset: 0x0001EFD0
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildMineralStorage.RowData rowData = new GuildMineralStorage.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.itemid, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.effect, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.self, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.bufficon, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.buffdescribe, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x00020E98 File Offset: 0x0001F098
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildMineralStorage.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400035D RID: 861
		public GuildMineralStorage.RowData[] Table = null;

		// Token: 0x02000310 RID: 784
		public class RowData
		{
			// Token: 0x04000B74 RID: 2932
			public uint ID;

			// Token: 0x04000B75 RID: 2933
			public uint itemid;

			// Token: 0x04000B76 RID: 2934
			public string effect;

			// Token: 0x04000B77 RID: 2935
			public uint self;

			// Token: 0x04000B78 RID: 2936
			public string bufficon;

			// Token: 0x04000B79 RID: 2937
			public string buffdescribe;
		}
	}
}
