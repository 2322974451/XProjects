using System;

namespace XUtliPoolLib
{

	public class AbyssPartyTypeTable : CVSReader
	{

		public AbyssPartyTypeTable.RowData GetByAbyssPartyId(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			AbyssPartyTypeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].AbyssPartyId == key;
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
			AbyssPartyTypeTable.RowData rowData = new AbyssPartyTypeTable.RowData();
			base.Read<int>(reader, ref rowData.AbyssPartyId, CVSReader.intParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.OpenLevel, CVSReader.intParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.SugLevel, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.PandoraID, CVSReader.intParse);
			this.columnno = 6;
			base.ReadArray<int>(reader, ref rowData.TitanItemID, CVSReader.intParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new AbyssPartyTypeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public AbyssPartyTypeTable.RowData[] Table = null;

		public class RowData
		{

			public int AbyssPartyId;

			public string Name;

			public string Icon;

			public int OpenLevel;

			public string SugLevel;

			public int PandoraID;

			public int[] TitanItemID;
		}
	}
}
