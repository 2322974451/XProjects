using System;

namespace XUtliPoolLib
{
	// Token: 0x02000118 RID: 280
	public class GuildSkillTable : CVSReader
	{
		// Token: 0x060006D1 RID: 1745 RVA: 0x000217CC File Offset: 0x0001F9CC
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildSkillTable.RowData rowData = new GuildSkillTable.RowData();
			base.Read<uint>(reader, ref rowData.skillid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 2;
			rowData.need.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.rexp, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.glevel, CVSReader.uintParse);
			this.columnno = 5;
			rowData.attribute.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.atlas, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.currentLevelDescription, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.roleLevel, CVSReader.uintParse);
			this.columnno = 10;
			base.ReadArray<uint>(reader, ref rowData.profecssion, CVSReader.uintParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.needtype, CVSReader.uintParse);
			this.columnno = 12;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x0002194C File Offset: 0x0001FB4C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildSkillTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000364 RID: 868
		public GuildSkillTable.RowData[] Table = null;

		// Token: 0x02000317 RID: 791
		public class RowData
		{
			// Token: 0x04000BAC RID: 2988
			public uint skillid;

			// Token: 0x04000BAD RID: 2989
			public string name;

			// Token: 0x04000BAE RID: 2990
			public uint level;

			// Token: 0x04000BAF RID: 2991
			public SeqListRef<uint> need;

			// Token: 0x04000BB0 RID: 2992
			public uint rexp;

			// Token: 0x04000BB1 RID: 2993
			public uint glevel;

			// Token: 0x04000BB2 RID: 2994
			public SeqListRef<uint> attribute;

			// Token: 0x04000BB3 RID: 2995
			public string icon;

			// Token: 0x04000BB4 RID: 2996
			public string atlas;

			// Token: 0x04000BB5 RID: 2997
			public string currentLevelDescription;

			// Token: 0x04000BB6 RID: 2998
			public uint roleLevel;

			// Token: 0x04000BB7 RID: 2999
			public uint[] profecssion;

			// Token: 0x04000BB8 RID: 3000
			public uint needtype;
		}
	}
}
