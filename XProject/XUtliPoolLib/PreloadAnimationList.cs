using System;

namespace XUtliPoolLib
{

	public class PreloadAnimationList : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			PreloadAnimationList.RowData rowData = new PreloadAnimationList.RowData();
			base.Read<int>(reader, ref rowData.SceneID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.AnimName, CVSReader.stringParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PreloadAnimationList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PreloadAnimationList.RowData[] Table = null;

		public class RowData
		{

			public int SceneID;

			public string AnimName;
		}
	}
}
