using System;

namespace XUtliPoolLib
{
	// Token: 0x02000180 RID: 384
	public class VIPTable : CVSReader
	{
		// Token: 0x06000858 RID: 2136 RVA: 0x0002BF2C File Offset: 0x0002A12C
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

		// Token: 0x06000859 RID: 2137 RVA: 0x0002BF98 File Offset: 0x0002A198
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

		// Token: 0x0600085A RID: 2138 RVA: 0x0002C138 File Offset: 0x0002A338
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

		// Token: 0x040003CC RID: 972
		public VIPTable.RowData[] Table = null;

		// Token: 0x0200037F RID: 895
		public class RowData
		{
			// Token: 0x04000EF3 RID: 3827
			public int VIP;

			// Token: 0x04000EF4 RID: 3828
			public uint RMB;

			// Token: 0x04000EF5 RID: 3829
			public int BuyGoldTimes;

			// Token: 0x04000EF6 RID: 3830
			public int BuyFatigueTimes;

			// Token: 0x04000EF7 RID: 3831
			public uint AuctionOnSaleMax;

			// Token: 0x04000EF8 RID: 3832
			public int BuyDragonCoinTimes;

			// Token: 0x04000EF9 RID: 3833
			public int ItemID;

			// Token: 0x04000EFA RID: 3834
			public string[] VIPTips;

			// Token: 0x04000EFB RID: 3835
			public uint GoldClickTimes;

			// Token: 0x04000EFC RID: 3836
			public uint EquipMax;

			// Token: 0x04000EFD RID: 3837
			public uint EmblemMax;

			// Token: 0x04000EFE RID: 3838
			public uint BagMax;

			// Token: 0x04000EFF RID: 3839
			public uint ArtifactMax;

			// Token: 0x04000F00 RID: 3840
			public uint InscriptionMax;
		}
	}
}
