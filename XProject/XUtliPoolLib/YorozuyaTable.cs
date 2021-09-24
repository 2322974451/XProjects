using System;

namespace XUtliPoolLib
{

	public class YorozuyaTable : CVSReader
	{

		public YorozuyaTable.RowData GetByID(byte key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			YorozuyaTable.RowData result;
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
			YorozuyaTable.RowData rowData = new YorozuyaTable.RowData();
			base.Read<byte>(reader, ref rowData.ID, CVSReader.byteParse);
			this.columnno = 0;
			rowData.SceneIDs.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.IconName, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<byte>(reader, ref rowData.IsOpen, CVSReader.byteParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new YorozuyaTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public YorozuyaTable.RowData[] Table = null;

		public class RowData
		{

			public byte ID;

			public SeqListRef<uint> SceneIDs;

			public string IconName;

			public string Name;

			public byte IsOpen;
		}
	}
}
