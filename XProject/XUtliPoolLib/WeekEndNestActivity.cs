using System;

namespace XUtliPoolLib
{

	public class WeekEndNestActivity : CVSReader
	{

		public WeekEndNestActivity.RowData GetByParentTaskId(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			WeekEndNestActivity.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ParentTaskId == key;
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
			WeekEndNestActivity.RowData rowData = new WeekEndNestActivity.RowData();
			rowData.OpenSvrDay.Read(reader, this.m_DataHandler);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.ParentTaskId, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.BgTexName, CVSReader.stringParse);
			this.columnno = 2;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new WeekEndNestActivity.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public WeekEndNestActivity.RowData[] Table = null;

		public class RowData
		{

			public SeqRef<uint> OpenSvrDay;

			public uint ParentTaskId;

			public string BgTexName;
		}
	}
}
