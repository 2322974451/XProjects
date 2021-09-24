using System;

namespace XUtliPoolLib
{

	public class FriendSysConfigTable : CVSReader
	{

		public FriendSysConfigTable.RowData GetByTabID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FriendSysConfigTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].TabID == key;
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
			FriendSysConfigTable.RowData rowData = new FriendSysConfigTable.RowData();
			base.Read<int>(reader, ref rowData.TabID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<bool>(reader, ref rowData.IsOpen, CVSReader.boolParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.TabName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.NumLabel, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.RButtonLabel, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.LButtonLabel, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.NumLimit, CVSReader.intParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FriendSysConfigTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FriendSysConfigTable.RowData[] Table = null;

		public class RowData
		{

			public int TabID;

			public bool IsOpen;

			public string TabName;

			public string Icon;

			public string NumLabel;

			public string RButtonLabel;

			public string LButtonLabel;

			public int NumLimit;
		}
	}
}
