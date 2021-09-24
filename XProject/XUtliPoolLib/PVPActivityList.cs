using System;

namespace XUtliPoolLib
{

	public class PVPActivityList : CVSReader
	{

		public PVPActivityList.RowData GetBySysID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PVPActivityList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SysID == key;
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
			PVPActivityList.RowData rowData = new PVPActivityList.RowData();
			base.Read<uint>(reader, ref rowData.SysID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
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
				this.Table = new PVPActivityList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PVPActivityList.RowData[] Table = null;

		public class RowData
		{

			public uint SysID;

			public string Description;

			public string Icon;
		}
	}
}
