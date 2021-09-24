using System;

namespace XUtliPoolLib
{

	public class RiskMapFile : CVSReader
	{

		public RiskMapFile.RowData GetByMapID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			RiskMapFile.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].MapID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			RiskMapFile.RowData rowData = new RiskMapFile.RowData();
			base.Read<int>(reader, ref rowData.MapID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.NeedLevel, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.FileName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.StepSizeX, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.StepSizeY, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.StartUIX, CVSReader.intParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.StartUIY, CVSReader.intParse);
			this.columnno = 6;
			rowData.BoxPreview.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.MapBgName, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.MapTittleName, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.MapGridBg, CVSReader.stringParse);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RiskMapFile.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public RiskMapFile.RowData[] Table = null;

		public class RowData
		{

			public int MapID;

			public int NeedLevel;

			public string FileName;

			public int StepSizeX;

			public int StepSizeY;

			public int StartUIX;

			public int StartUIY;

			public SeqListRef<int> BoxPreview;

			public string MapBgName;

			public string MapTittleName;

			public string MapGridBg;
		}
	}
}
