using System;

namespace XUtliPoolLib
{

	public class VIPTable : CVSReader
	{

		public VIPTable.RowData GetByVIP(int key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			VIPTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].VIP == key;
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
			VIPTable.RowData rowData = new VIPTable.RowData();
			base.Read<int>(reader, ref rowData.VIP, CVSReader.intParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.RMB, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<int>(reader, ref rowData.BuyGoldTimes, CVSReader.intParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.BuyFatigueTimes, CVSReader.intParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.AuctionOnSaleMax, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<int>(reader, ref rowData.BuyDragonCoinTimes, CVSReader.intParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.ItemID, CVSReader.intParse);
			this.columnno = 9;
			base.ReadArray<string>(reader, ref rowData.VIPTips, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.GoldClickTimes, CVSReader.uintParse);
			this.columnno = 11;
			base.Read<uint>(reader, ref rowData.EquipMax, CVSReader.uintParse);
			this.columnno = 12;
			base.Read<uint>(reader, ref rowData.EmblemMax, CVSReader.uintParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.BagMax, CVSReader.uintParse);
			this.columnno = 14;
			base.Read<uint>(reader, ref rowData.ArtifactMax, CVSReader.uintParse);
			this.columnno = 15;
			base.Read<uint>(reader, ref rowData.InscriptionMax, CVSReader.uintParse);
			this.columnno = 16;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new VIPTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public VIPTable.RowData[] Table = null;

		public class RowData
		{

			public int VIP;

			public uint RMB;

			public int BuyGoldTimes;

			public int BuyFatigueTimes;

			public uint AuctionOnSaleMax;

			public int BuyDragonCoinTimes;

			public int ItemID;

			public string[] VIPTips;

			public uint GoldClickTimes;

			public uint EquipMax;

			public uint EmblemMax;

			public uint BagMax;

			public uint ArtifactMax;

			public uint InscriptionMax;
		}
	}
}
