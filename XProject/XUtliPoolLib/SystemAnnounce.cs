using System;

namespace XUtliPoolLib
{

	public class SystemAnnounce : CVSReader
	{

		public SystemAnnounce.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SystemAnnounce.RowData result;
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
			SystemAnnounce.RowData rowData = new SystemAnnounce.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.SystemDescription, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.OpenAnnounceLevel, CVSReader.intParse);
			this.columnno = 3;
			base.ReadArray<string>(reader, ref rowData.AnnounceDesc, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.AnnounceIcon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.TextSpriteName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.IconName, CVSReader.stringParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SystemAnnounce.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public SystemAnnounce.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public int SystemID;

			public string SystemDescription;

			public int OpenAnnounceLevel;

			public string[] AnnounceDesc;

			public string AnnounceIcon;

			public string TextSpriteName;

			public string IconName;
		}
	}
}
