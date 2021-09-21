using System;

namespace XUtliPoolLib
{
	// Token: 0x0200013C RID: 316
	public class PayMemberTable : CVSReader
	{
		// Token: 0x0600075B RID: 1883 RVA: 0x00024FF0 File Offset: 0x000231F0
		protected override void ReadLine(XBinaryReader reader)
		{
			PayMemberTable.RowData rowData = new PayMemberTable.RowData();
			base.Read<string>(reader, ref rowData.ParamID, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.ID, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.Price, CVSReader.intParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.Days, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.ChatCount, CVSReader.intParse);
			this.columnno = 7;
			base.Read<int>(reader, ref rowData.FatigueLimit, CVSReader.intParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.AbyssCount, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.ReviveCount, CVSReader.intParse);
			this.columnno = 10;
			base.Read<int>(reader, ref rowData.BossRushCount, CVSReader.intParse);
			this.columnno = 12;
			base.Read<int>(reader, ref rowData.BuyGreenAgateLimit, CVSReader.intParse);
			this.columnno = 13;
			base.ReadArray<int>(reader, ref rowData.CheckinDoubleDays, CVSReader.intParse);
			this.columnno = 14;
			base.Read<int>(reader, ref rowData.SuperRiskCount, CVSReader.intParse);
			this.columnno = 16;
			base.Read<int>(reader, ref rowData.SystemID, CVSReader.intParse);
			this.columnno = 17;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 18;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 19;
			base.Read<string>(reader, ref rowData.Tip, CVSReader.stringParse);
			this.columnno = 20;
			base.Read<string>(reader, ref rowData.Detail, CVSReader.stringParse);
			this.columnno = 22;
			base.Read<string>(reader, ref rowData.BuyNtf, CVSReader.stringParse);
			this.columnno = 23;
			base.ReadArray<int>(reader, ref rowData.CheckinDoubleEvenDays, CVSReader.intParse);
			this.columnno = 24;
			base.Read<string>(reader, ref rowData.ServiceCode, CVSReader.stringParse);
			this.columnno = 25;
			rowData.Value.Read(reader, this.m_DataHandler);
			this.columnno = 26;
			base.Read<int>(reader, ref rowData.AuctionCount, CVSReader.intParse);
			this.columnno = 28;
			rowData.worldBossbuffid.Read(reader, this.m_DataHandler);
			this.columnno = 29;
			rowData.guildBossBuffid.Read(reader, this.m_DataHandler);
			this.columnno = 30;
			base.Read<int>(reader, ref rowData.HeroBattleFree, CVSReader.intParse);
			this.columnno = 31;
			base.Read<uint>(reader, ref rowData.NpcFeeling, CVSReader.uintParse);
			this.columnno = 32;
			base.Read<int>(reader, ref rowData.ShopRefresh, CVSReader.intParse);
			this.columnno = 33;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x00025308 File Offset: 0x00023508
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PayMemberTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000388 RID: 904
		public PayMemberTable.RowData[] Table = null;

		// Token: 0x0200033B RID: 827
		public class RowData
		{
			// Token: 0x04000CB1 RID: 3249
			public string ParamID;

			// Token: 0x04000CB2 RID: 3250
			public int ID;

			// Token: 0x04000CB3 RID: 3251
			public string Name;

			// Token: 0x04000CB4 RID: 3252
			public int Price;

			// Token: 0x04000CB5 RID: 3253
			public int Days;

			// Token: 0x04000CB6 RID: 3254
			public int ChatCount;

			// Token: 0x04000CB7 RID: 3255
			public int FatigueLimit;

			// Token: 0x04000CB8 RID: 3256
			public int AbyssCount;

			// Token: 0x04000CB9 RID: 3257
			public int ReviveCount;

			// Token: 0x04000CBA RID: 3258
			public int BossRushCount;

			// Token: 0x04000CBB RID: 3259
			public int BuyGreenAgateLimit;

			// Token: 0x04000CBC RID: 3260
			public int[] CheckinDoubleDays;

			// Token: 0x04000CBD RID: 3261
			public int SuperRiskCount;

			// Token: 0x04000CBE RID: 3262
			public int SystemID;

			// Token: 0x04000CBF RID: 3263
			public string Icon;

			// Token: 0x04000CC0 RID: 3264
			public string Desc;

			// Token: 0x04000CC1 RID: 3265
			public string Tip;

			// Token: 0x04000CC2 RID: 3266
			public string Detail;

			// Token: 0x04000CC3 RID: 3267
			public string BuyNtf;

			// Token: 0x04000CC4 RID: 3268
			public int[] CheckinDoubleEvenDays;

			// Token: 0x04000CC5 RID: 3269
			public string ServiceCode;

			// Token: 0x04000CC6 RID: 3270
			public SeqRef<uint> Value;

			// Token: 0x04000CC7 RID: 3271
			public int AuctionCount;

			// Token: 0x04000CC8 RID: 3272
			public SeqRef<uint> worldBossbuffid;

			// Token: 0x04000CC9 RID: 3273
			public SeqRef<uint> guildBossBuffid;

			// Token: 0x04000CCA RID: 3274
			public int HeroBattleFree;

			// Token: 0x04000CCB RID: 3275
			public uint NpcFeeling;

			// Token: 0x04000CCC RID: 3276
			public int ShopRefresh;
		}
	}
}
