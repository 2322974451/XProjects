using System;

namespace XUtliPoolLib
{

	public class FirstPassTable : CVSReader
	{

		public FirstPassTable.RowData GetByID(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FirstPassTable.RowData result;
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
			FirstPassTable.RowData rowData = new FirstPassTable.RowData();
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<int>(reader, ref rowData.SceneID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.RewardID, CVSReader.intParse);
			this.columnno = 2;
			rowData.CommendReward.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.SystemId, CVSReader.intParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.Des, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.BgTexName, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.NestType, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.RankTittle, CVSReader.stringParse);
			this.columnno = 9;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FirstPassTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FirstPassTable.RowData[] Table = null;

		public class RowData
		{

			public int ID;

			public int[] SceneID;

			public int RewardID;

			public SeqListRef<int> CommendReward;

			public int SystemId;

			public string Des;

			public string BgTexName;

			public uint NestType;

			public string RankTittle;
		}
	}
}
