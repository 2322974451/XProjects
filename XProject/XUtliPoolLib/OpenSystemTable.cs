using System;

namespace XUtliPoolLib
{

	public class OpenSystemTable : CVSReader
	{

		public OpenSystemTable.RowData GetBySystemID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			OpenSystemTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchSystemID(key);
			}
			return result;
		}

		private OpenSystemTable.RowData BinarySearchSystemID(int key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			OpenSystemTable.RowData rowData;
			OpenSystemTable.RowData rowData2;
			OpenSystemTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.SystemID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.SystemID == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.SystemID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.SystemID.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		protected override void ReadLine(XBinaryReader reader)
		{
			OpenSystemTable.RowData rowData = new OpenSystemTable.RowData();
			base.Read<int>(reader, ref rowData.PlayerLevel, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.SystemDescription, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.Priority, CVSReader.intParse);
			this.columnno = 6;
			base.ReadArray<int>(reader, ref rowData.TitanItems, CVSReader.intParse);
			this.columnno = 7;
			base.ReadArray<uint>(reader, ref rowData.NoRedPointLevel, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.OpenDay, CVSReader.uintParse);
			this.columnno = 11;
			rowData.BackServerOpenDay.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			base.Read<bool>(reader, ref rowData.InNotice, CVSReader.boolParse);
			this.columnno = 14;
			rowData.NoticeText.Read(reader, this.m_DataHandler);
			this.columnno = 15;
			rowData.NoticeIcon.Read(reader, this.m_DataHandler);
			this.columnno = 16;
			base.ReadArray<string>(reader, ref rowData.NoticeEffect, CVSReader.stringParse);
			this.columnno = 17;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new OpenSystemTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public OpenSystemTable.RowData[] Table = null;

		public class RowData
		{

			public int PlayerLevel;

			public int SystemID;

			public string SystemDescription;

			public string Icon;

			public int Priority;

			public int[] TitanItems;

			public uint[] NoRedPointLevel;

			public uint OpenDay;

			public SeqListRef<uint> BackServerOpenDay;

			public bool InNotice;

			public SeqListRef<string> NoticeText;

			public SeqListRef<string> NoticeIcon;

			public string[] NoticeEffect;
		}
	}
}
