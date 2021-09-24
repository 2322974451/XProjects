using System;

namespace XUtliPoolLib
{

	public class LiveTable : CVSReader
	{

		public LiveTable.RowData GetBySceneType(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			LiveTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SceneType == key;
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
			LiveTable.RowData rowData = new LiveTable.RowData();
			base.Read<int>(reader, ref rowData.Type, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.SceneType, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.ShowWatch, CVSReader.intParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.ShowPraise, CVSReader.intParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new LiveTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public LiveTable.RowData[] Table = null;

		public class RowData
		{

			public int Type;

			public int SceneType;

			public int ShowWatch;

			public int ShowPraise;
		}
	}
}
