using System;

namespace XUtliPoolLib
{

	public class PayMemberTable : CVSReader
	{

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

		public PayMemberTable.RowData[] Table = null;

		public class RowData
		{

			public string ParamID;

			public int ID;

			public string Name;

			public int Price;

			public int Days;

			public int ChatCount;

			public int FatigueLimit;

			public int AbyssCount;

			public int ReviveCount;

			public int BossRushCount;

			public int BuyGreenAgateLimit;

			public int[] CheckinDoubleDays;

			public int SuperRiskCount;

			public int SystemID;

			public string Icon;

			public string Desc;

			public string Tip;

			public string Detail;

			public string BuyNtf;

			public int[] CheckinDoubleEvenDays;

			public string ServiceCode;

			public SeqRef<uint> Value;

			public int AuctionCount;

			public SeqRef<uint> worldBossbuffid;

			public SeqRef<uint> guildBossBuffid;

			public int HeroBattleFree;

			public uint NpcFeeling;

			public int ShopRefresh;
		}
	}
}
