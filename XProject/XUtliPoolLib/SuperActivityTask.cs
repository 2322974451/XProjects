using System;

namespace XUtliPoolLib
{

	public class SuperActivityTask : CVSReader
	{

		public SuperActivityTask.RowData GetBytaskid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SuperActivityTask.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchtaskid(key);
			}
			return result;
		}

		private SuperActivityTask.RowData BinarySearchtaskid(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			SuperActivityTask.RowData rowData;
			SuperActivityTask.RowData rowData2;
			SuperActivityTask.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.taskid == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.taskid == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.taskid.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.taskid.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			SuperActivityTask.RowData rowData = new SuperActivityTask.RowData();
			base.Read<uint>(reader, ref rowData.taskid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.title, CVSReader.stringParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.num, CVSReader.uintParse);
			this.columnno = 3;
			rowData.items.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.type, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.belong, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.jump, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.actid, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.cnt, CVSReader.intParse);
			this.columnno = 10;
			base.ReadArray<int>(reader, ref rowData.arg, CVSReader.intParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.tasktype, CVSReader.uintParse);
			this.columnno = 12;
			base.ReadArray<uint>(reader, ref rowData.taskson, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.taskfather, CVSReader.uintParse);
			this.columnno = 14;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SuperActivityTask.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public SuperActivityTask.RowData[] Table = null;

		public class RowData
		{

			public uint taskid;

			public string title;

			public uint[] num;

			public SeqListRef<uint> items;

			public string icon;

			public uint type;

			public uint belong;

			public uint jump;

			public uint actid;

			public int cnt;

			public int[] arg;

			public uint tasktype;

			public uint[] taskson;

			public uint taskfather;
		}
	}
}
