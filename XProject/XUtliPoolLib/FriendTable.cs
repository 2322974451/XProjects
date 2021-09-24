using System;

namespace XUtliPoolLib
{

	public class FriendTable : CVSReader
	{

		public FriendTable.RowData GetBylevel(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FriendTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].level == key;
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
			FriendTable.RowData rowData = new FriendTable.RowData();
			base.Read<uint>(reader, ref rowData.level, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.teamname, CVSReader.stringParse);
			this.columnno = 2;
			rowData.buf.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.dropid, CVSReader.uintParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FriendTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FriendTable.RowData[] Table = null;

		public class RowData
		{

			public uint level;

			public string teamname;

			public SeqRef<uint> buf;

			public uint dropid;
		}
	}
}
