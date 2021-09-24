using System;

namespace XUtliPoolLib
{

	public class MobaSignalTable : CVSReader
	{

		public MobaSignalTable.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			MobaSignalTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ID == key;
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
			MobaSignalTable.RowData rowData = new MobaSignalTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Text, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Effect, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Audio, CVSReader.stringParse);
			this.columnno = 4;
			base.ReadArray<int>(reader, ref rowData.SceneType, CVSReader.intParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new MobaSignalTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public MobaSignalTable.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public string Text;

			public string Icon;

			public string Effect;

			public string Audio;

			public int[] SceneType;
		}
	}
}
