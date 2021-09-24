using System;

namespace XUtliPoolLib
{

	public class SpectateLevelRewardConfig : CVSReader
	{

		public SpectateLevelRewardConfig.RowData GetBySceneType(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SpectateLevelRewardConfig.RowData result;
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
			SpectateLevelRewardConfig.RowData rowData = new SpectateLevelRewardConfig.RowData();
			base.Read<int>(reader, ref rowData.SceneType, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<int>(reader, ref rowData.DataConfig, CVSReader.intParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SpectateLevelRewardConfig.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public SpectateLevelRewardConfig.RowData[] Table = null;

		public class RowData
		{

			public int SceneType;

			public int[] DataConfig;
		}
	}
}
