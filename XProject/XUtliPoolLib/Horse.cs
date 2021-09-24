using System;

namespace XUtliPoolLib
{

	public class Horse : CVSReader
	{

		public Horse.RowData GetBysceneid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			Horse.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].sceneid == key;
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
			Horse.RowData rowData = new Horse.RowData();
			base.Read<uint>(reader, ref rowData.sceneid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Laps, CVSReader.uintParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new Horse.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public Horse.RowData[] Table = null;

		public class RowData
		{

			public uint sceneid;

			public uint Laps;
		}
	}
}
