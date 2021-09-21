using System;

namespace XUtliPoolLib
{
	// Token: 0x0200026C RID: 620
	public class GuildHall : CVSReader
	{
		// Token: 0x06000D44 RID: 3396 RVA: 0x00046000 File Offset: 0x00044200
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildHall.RowData rowData = new GuildHall.RowData();
			base.Read<uint>(reader, ref rowData.skillid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.updateneed, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.dailyneed, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.glevel, CVSReader.uintParse);
			this.columnno = 5;
			rowData.buffid.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.atlas, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.currentLevelDescription, CVSReader.stringParse);
			this.columnno = 9;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x00046130 File Offset: 0x00044330
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildHall.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007BA RID: 1978
		public GuildHall.RowData[] Table = null;

		// Token: 0x020003FB RID: 1019
		public class RowData
		{
			// Token: 0x0400121F RID: 4639
			public uint skillid;

			// Token: 0x04001220 RID: 4640
			public string name;

			// Token: 0x04001221 RID: 4641
			public uint level;

			// Token: 0x04001222 RID: 4642
			public uint updateneed;

			// Token: 0x04001223 RID: 4643
			public uint dailyneed;

			// Token: 0x04001224 RID: 4644
			public uint glevel;

			// Token: 0x04001225 RID: 4645
			public SeqRef<uint> buffid;

			// Token: 0x04001226 RID: 4646
			public string icon;

			// Token: 0x04001227 RID: 4647
			public string atlas;

			// Token: 0x04001228 RID: 4648
			public string currentLevelDescription;
		}
	}
}
