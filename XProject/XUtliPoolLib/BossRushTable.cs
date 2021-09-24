using System;

namespace XUtliPoolLib
{

	public class BossRushTable : CVSReader
	{

		public BossRushTable.RowData GetByqniqueid(short key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			BossRushTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchqniqueid(key);
			}
			return result;
		}

		private BossRushTable.RowData BinarySearchqniqueid(short key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			BossRushTable.RowData rowData;
			BossRushTable.RowData rowData2;
			BossRushTable.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.qniqueid == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.qniqueid == key;
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
				bool flag4 = rowData3.qniqueid.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.qniqueid.CompareTo(key) < 0;
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
			BossRushTable.RowData rowData = new BossRushTable.RowData();
			base.Read<int>(reader, ref rowData.bossid, CVSReader.intParse);
			this.columnno = 0;
			base.ReadArray<byte>(reader, ref rowData.bossdifficult, CVSReader.byteParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.bosstip, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<short>(reader, ref rowData.qniqueid, CVSReader.shortParse);
			this.columnno = 10;
			rowData.reward.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BossRushTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public BossRushTable.RowData[] Table = null;

		public class RowData
		{

			public int bossid;

			public byte[] bossdifficult;

			public string bosstip;

			public short qniqueid;

			public SeqListRef<uint> reward;
		}
	}
}
