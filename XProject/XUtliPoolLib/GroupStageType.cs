using System;

namespace XUtliPoolLib
{

	public class GroupStageType : CVSReader
	{

		public GroupStageType.RowData GetByStageID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GroupStageType.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].StageID == key;
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
			GroupStageType.RowData rowData = new GroupStageType.RowData();
			base.Read<uint>(reader, ref rowData.StageID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.StageName, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.StagePerent, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.Stage2Expedition, CVSReader.intParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GroupStageType.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GroupStageType.RowData[] Table = null;

		public class RowData
		{

			public uint StageID;

			public string StageName;

			public uint StagePerent;

			public int Stage2Expedition;
		}
	}
}
