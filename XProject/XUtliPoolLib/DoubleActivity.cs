using System;

namespace XUtliPoolLib
{

	public class DoubleActivity : CVSReader
	{

		public DoubleActivity.RowData GetBySystemId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DoubleActivity.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SystemId == key;
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
			DoubleActivity.RowData rowData = new DoubleActivity.RowData();
			base.Read<uint>(reader, ref rowData.SystemId, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.WeekOpenDays, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.TimeSpan, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.DropMultiple, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.DropItems, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.LimitTimes, CVSReader.uintParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DoubleActivity.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public DoubleActivity.RowData[] Table = null;

		public class RowData
		{

			public uint SystemId;

			public uint[] WeekOpenDays;

			public uint[] TimeSpan;

			public uint DropMultiple;

			public uint DropItems;

			public uint LimitTimes;
		}
	}
}
