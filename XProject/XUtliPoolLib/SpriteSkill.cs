using System;

namespace XUtliPoolLib
{
	// Token: 0x02000171 RID: 369
	public class SpriteSkill : CVSReader
	{
		// Token: 0x0600081D RID: 2077 RVA: 0x0002A44C File Offset: 0x0002864C
		protected override void ReadLine(XBinaryReader reader)
		{
			SpriteSkill.RowData rowData = new SpriteSkill.RowData();
			base.Read<short>(reader, ref rowData.SkillID, CVSReader.shortParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SkillName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<byte>(reader, ref rowData.SkillQuality, CVSReader.byteParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Tips, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Detail, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<short>(reader, ref rowData.Duration, CVSReader.shortParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.NoticeDetail, CVSReader.stringParse);
			this.columnno = 12;
			rowData.ShowNotice.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			base.Read<string>(reader, ref rowData.Audio, CVSReader.stringParse);
			this.columnno = 14;
			base.Read<string>(reader, ref rowData.Atlas, CVSReader.stringParse);
			this.columnno = 15;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x0002A598 File Offset: 0x00028798
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SpriteSkill.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003BD RID: 957
		public SpriteSkill.RowData[] Table = null;

		// Token: 0x02000370 RID: 880
		public class RowData
		{
			// Token: 0x04000E6C RID: 3692
			public short SkillID;

			// Token: 0x04000E6D RID: 3693
			public string SkillName;

			// Token: 0x04000E6E RID: 3694
			public byte SkillQuality;

			// Token: 0x04000E6F RID: 3695
			public string Tips;

			// Token: 0x04000E70 RID: 3696
			public string Icon;

			// Token: 0x04000E71 RID: 3697
			public string Detail;

			// Token: 0x04000E72 RID: 3698
			public short Duration;

			// Token: 0x04000E73 RID: 3699
			public string NoticeDetail;

			// Token: 0x04000E74 RID: 3700
			public SeqRef<int> ShowNotice;

			// Token: 0x04000E75 RID: 3701
			public string Audio;

			// Token: 0x04000E76 RID: 3702
			public string Atlas;
		}
	}
}
