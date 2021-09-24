using System;

namespace XUtliPoolLib
{

	public class GuildTransfer : CVSReader
	{

		public GuildTransfer.RowData GetByid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildTransfer.RowData result;
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
			GuildTransfer.RowData rowData = new GuildTransfer.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.sceneid, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.icon, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildTransfer.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GuildTransfer.RowData[] Table = null;

		public class RowData
		{

			public uint id;

			public string name;

			public uint sceneid;

			public string icon;
		}
	}
}
