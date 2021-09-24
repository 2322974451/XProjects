using System;

namespace XUtliPoolLib
{

	public class TaJieHelpTab : CVSReader
	{

		public TaJieHelpTab.RowData GetByIndex(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			TaJieHelpTab.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Index == key;
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
			TaJieHelpTab.RowData rowData = new TaJieHelpTab.RowData();
			base.Read<uint>(reader, ref rowData.Index, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.SysID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.IconName, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Des, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 5;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new TaJieHelpTab.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public TaJieHelpTab.RowData[] Table = null;

		public class RowData
		{

			public uint Index;

			public uint[] Type;

			public uint SysID;

			public string IconName;

			public string Des;

			public string Name;
		}
	}
}
