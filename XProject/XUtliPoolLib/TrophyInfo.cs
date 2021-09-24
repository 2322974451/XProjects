using System;

namespace XUtliPoolLib
{

	public class TrophyInfo : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			TrophyInfo.RowData rowData = new TrophyInfo.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 1;
			rowData.TrophyScore.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Third, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.ThirdPara, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.Second, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.SecondPara, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.First, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.FirstPara, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.ThirdDesc, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.SecondDesc, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.FirstDesc, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 13;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new TrophyInfo.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public TrophyInfo.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public uint SceneID;

			public SeqRef<uint> TrophyScore;

			public uint Third;

			public uint ThirdPara;

			public uint Second;

			public uint SecondPara;

			public uint First;

			public uint FirstPara;

			public string Name;

			public string ThirdDesc;

			public string SecondDesc;

			public string FirstDesc;

			public string Icon;
		}
	}
}
