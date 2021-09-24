using System;

namespace XUtliPoolLib
{

	public class PrerogativeContent : CVSReader
	{

		public PrerogativeContent.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PrerogativeContent.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchID(key);
			}
			return result;
		}

		private PrerogativeContent.RowData BinarySearchID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			PrerogativeContent.RowData rowData;
			PrerogativeContent.RowData rowData2;
			PrerogativeContent.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.ID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.ID == key;
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
				bool flag4 = rowData3.ID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.ID.CompareTo(key) < 0;
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
			PrerogativeContent.RowData rowData = new PrerogativeContent.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Content, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.Normal, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 4;
			rowData.Item.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.HintID, CVSReader.uintParse);
			this.columnno = 7;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PrerogativeContent.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PrerogativeContent.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public uint Type;

			public string Content;

			public uint Normal;

			public string Icon;

			public SeqRef<uint> Item;

			public string Name;

			public uint HintID;
		}
	}
}
