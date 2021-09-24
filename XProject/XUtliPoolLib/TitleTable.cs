using System;

namespace XUtliPoolLib
{

	public class TitleTable : CVSReader
	{

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

		public TitleTable.RowData[] Table = null;

		public class RowData
		{

			public uint RankID;

			public string RankName;

			public string RankIcon;

			public string AffectRoute;

			public uint NeedPowerPoint;

			public SeqListRef<uint> NeedItem;

			public SeqListRef<uint> Attribute;

			public string RankPath;

			public string desc;

			public uint BasicProfession;

			public string RankAtlas;
		}
	}
}
