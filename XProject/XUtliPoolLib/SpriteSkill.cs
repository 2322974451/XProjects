using System;

namespace XUtliPoolLib
{

	public class SpriteSkill : CVSReader
	{

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

		public SpriteSkill.RowData[] Table = null;

		public class RowData
		{

			public short SkillID;

			public string SkillName;

			public byte SkillQuality;

			public string Tips;

			public string Icon;

			public string Detail;

			public short Duration;

			public string NoticeDetail;

			public SeqRef<int> ShowNotice;

			public string Audio;

			public string Atlas;
		}
	}
}
