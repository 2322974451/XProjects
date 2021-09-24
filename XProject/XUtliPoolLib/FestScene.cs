using System;

namespace XUtliPoolLib
{

	public class FestScene : CVSReader
	{

		public FestScene.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FestScene.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].id == key;
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
			FestScene.RowData rowData = new FestScene.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.PicPath, CVSReader.stringParse);
			this.columnno = 4;
			base.ReadArray<uint>(reader, ref rowData.RewardList, CVSReader.uintParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FestScene.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FestScene.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public string PicPath;

			public uint[] RewardList;
		}
	}
}
