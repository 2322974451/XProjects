using System;

namespace XUtliPoolLib
{

	public class MarriageLevel : CVSReader
	{

		public MarriageLevel.RowData GetByLevel(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			MarriageLevel.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Level == key;
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
			MarriageLevel.RowData rowData = new MarriageLevel.RowData();
			base.Read<int>(reader, ref rowData.Level, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.NeedIntimacyValue, CVSReader.intParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.PrerogativeID, CVSReader.uintParse);
			this.columnno = 2;
			rowData.PrerogativeItems.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.PrivilegeBuffs.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.BuffIcon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 6;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new MarriageLevel.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public MarriageLevel.RowData[] Table = null;

		public class RowData
		{

			public int Level;

			public int NeedIntimacyValue;

			public uint PrerogativeID;

			public SeqRef<uint> PrerogativeItems;

			public SeqRef<uint> PrivilegeBuffs;

			public string BuffIcon;

			public string Desc;
		}
	}
}
