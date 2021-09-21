using System;

namespace XUtliPoolLib
{
	// Token: 0x0200017F RID: 383
	public class TitleTable : CVSReader
	{
		// Token: 0x06000855 RID: 2133 RVA: 0x0002BDA0 File Offset: 0x00029FA0
		protected override void ReadLine(XBinaryReader reader)
		{
			TitleTable.RowData rowData = new TitleTable.RowData();
			base.Read<uint>(reader, ref rowData.RankID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.RankName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.RankIcon, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.AffectRoute, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.NeedPowerPoint, CVSReader.uintParse);
			this.columnno = 4;
			rowData.NeedItem.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.Attribute.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.RankPath, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.desc, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.BasicProfession, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.RankAtlas, CVSReader.stringParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0002BEEC File Offset: 0x0002A0EC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new TitleTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003CB RID: 971
		public TitleTable.RowData[] Table = null;

		// Token: 0x0200037E RID: 894
		public class RowData
		{
			// Token: 0x04000EE8 RID: 3816
			public uint RankID;

			// Token: 0x04000EE9 RID: 3817
			public string RankName;

			// Token: 0x04000EEA RID: 3818
			public string RankIcon;

			// Token: 0x04000EEB RID: 3819
			public string AffectRoute;

			// Token: 0x04000EEC RID: 3820
			public uint NeedPowerPoint;

			// Token: 0x04000EED RID: 3821
			public SeqListRef<uint> NeedItem;

			// Token: 0x04000EEE RID: 3822
			public SeqListRef<uint> Attribute;

			// Token: 0x04000EEF RID: 3823
			public string RankPath;

			// Token: 0x04000EF0 RID: 3824
			public string desc;

			// Token: 0x04000EF1 RID: 3825
			public uint BasicProfession;

			// Token: 0x04000EF2 RID: 3826
			public string RankAtlas;
		}
	}
}
