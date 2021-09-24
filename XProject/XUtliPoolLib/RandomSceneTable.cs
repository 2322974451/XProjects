using System;

namespace XUtliPoolLib
{

	public class RandomSceneTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			RandomSceneTable.RowData rowData = new RandomSceneTable.RowData();
			base.Read<uint>(reader, ref rowData.RandomID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new RandomSceneTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public RandomSceneTable.RowData[] Table = null;

		public class RowData
		{

			public uint RandomID;

			public uint SceneID;
		}
	}
}
