using System;

namespace XUtliPoolLib
{

	public class LevelSealTypeTable : CVSReader
	{

		public LevelSealTypeTable.RowData GetByType(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			LevelSealTypeTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].Type == key;
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
			LevelSealTypeTable.RowData rowData = new LevelSealTypeTable.RowData();
			base.Read<uint>(reader, ref rowData.Type, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Level, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.Time, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.UnlockBossName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.UnlockBossCount, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.NowSealImage, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.NextSealImageL, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<string>(reader, ref rowData.NextSealImageR, CVSReader.stringParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.NextSealImageBig, CVSReader.stringParse);
			this.columnno = 9;
			rowData.ExchangeInfo.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			rowData.CollectAward.Read(reader, this.m_DataHandler);
			this.columnno = 14;
			rowData.PlayerAward.Read(reader, this.m_DataHandler);
			this.columnno = 16;
			base.Read<int>(reader, ref rowData.ApplyStudentLevel, CVSReader.intParse);
			this.columnno = 19;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new LevelSealTypeTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public LevelSealTypeTable.RowData[] Table = null;

		public class RowData
		{

			public uint Type;

			public uint Level;

			public uint Time;

			public string UnlockBossName;

			public uint UnlockBossCount;

			public string NowSealImage;

			public string NextSealImageL;

			public string NextSealImageR;

			public string NextSealImageBig;

			public SeqRef<uint> ExchangeInfo;

			public SeqListRef<uint> CollectAward;

			public SeqListRef<uint> PlayerAward;

			public int ApplyStudentLevel;
		}
	}
}
