using System;

namespace XUtliPoolLib
{

	public class HeroBattleTips : CVSReader
	{

		public HeroBattleTips.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			HeroBattleTips.RowData result;
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
			HeroBattleTips.RowData rowData = new HeroBattleTips.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.tips, CVSReader.stringParse);
			this.columnno = 1;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new HeroBattleTips.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public HeroBattleTips.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public string tips;
		}
	}
}
