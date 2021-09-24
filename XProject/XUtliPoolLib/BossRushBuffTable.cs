using System;

namespace XUtliPoolLib
{

	public class BossRushBuffTable : CVSReader
	{

		public BossRushBuffTable.RowData GetByBossRushBuffID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			BossRushBuffTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].BossRushBuffID == key;
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
			BossRushBuffTable.RowData rowData = new BossRushBuffTable.RowData();
			base.Read<int>(reader, ref rowData.BossRushBuffID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<float>(reader, ref rowData.RewardBuff, CVSReader.floatParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.Quality, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Comment, CVSReader.stringParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BossRushBuffTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public BossRushBuffTable.RowData[] Table = null;

		public class RowData
		{

			public int BossRushBuffID;

			public float RewardBuff;

			public string icon;

			public int Quality;

			public string Comment;
		}
	}
}
