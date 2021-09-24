using System;

namespace XUtliPoolLib
{

	public class GameCommunityTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			GameCommunityTable.RowData rowData = new GameCommunityTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.ButtonName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<bool>(reader, ref rowData.QQ, CVSReader.boolParse);
			this.columnno = 2;
			base.Read<bool>(reader, ref rowData.WX, CVSReader.boolParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.OpenLevel, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.SysID, CVSReader.intParse);
			this.columnno = 5;
			base.Read<bool>(reader, ref rowData.YK, CVSReader.boolParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GameCommunityTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GameCommunityTable.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public string ButtonName;

			public bool QQ;

			public bool WX;

			public int OpenLevel;

			public int SysID;

			public bool YK;
		}
	}
}
