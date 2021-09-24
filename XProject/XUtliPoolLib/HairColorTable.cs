using System;

namespace XUtliPoolLib
{

	public class HairColorTable : CVSReader
	{

		public HairColorTable.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			HairColorTable.RowData result;
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
			HairColorTable.RowData rowData = new HairColorTable.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<float>(reader, ref rowData.Color, CVSReader.floatParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new HairColorTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public HairColorTable.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public float[] Color;

			public string Name;

			public string Icon;
		}
	}
}
