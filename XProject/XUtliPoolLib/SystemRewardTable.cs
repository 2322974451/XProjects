using System;

namespace XUtliPoolLib
{

	public class SystemRewardTable : CVSReader
	{

		public SystemRewardTable.RowData GetByType(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SystemRewardTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Type == key;
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
			SystemRewardTable.RowData rowData = new SystemRewardTable.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SubType, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Sort, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Remark, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SystemRewardTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public SystemRewardTable.RowData[] Table = null;

		public class RowData
		{

			public uint Type;

			public string Name;

			public uint SubType;

			public uint Sort;

			public string Remark;
		}
	}
}
