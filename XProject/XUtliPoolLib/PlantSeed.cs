using System;

namespace XUtliPoolLib
{

	public class PlantSeed : CVSReader
	{

		public PlantSeed.RowData GetBySeedID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PlantSeed.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SeedID == key;
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
			PlantSeed.RowData rowData = new PlantSeed.RowData();
			base.Read<uint>(reader, ref rowData.SeedID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SeedName, CVSReader.stringParse);
			this.columnno = 1;
			rowData.PlantID.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.PlantName, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.GrowUpAmount, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.GrowUpAmountPerMinute, CVSReader.uintParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.PredictGrowUpTime, CVSReader.uintParse);
			this.columnno = 10;
			rowData.HarvestPlant.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			rowData.ExtraDropItem.Read(reader, this.m_DataHandler);
			this.columnno = 15;
			base.Read<uint>(reader, ref rowData.IncreaseGrowUpRate, CVSReader.uintParse);
			this.columnno = 17;
			base.Read<uint>(reader, ref rowData.ReduceGrowUpRate, CVSReader.uintParse);
			this.columnno = 18;
			base.Read<uint>(reader, ref rowData.PlantStateCD, CVSReader.uintParse);
			this.columnno = 19;
			base.Read<uint>(reader, ref rowData.BadStateGrowUpRate, CVSReader.uintParse);
			this.columnno = 21;
			rowData.StealAward.Read(reader, this.m_DataHandler);
			this.columnno = 22;
			base.Read<uint>(reader, ref rowData.CanStealMaxTimes, CVSReader.uintParse);
			this.columnno = 27;
			base.Read<uint>(reader, ref rowData.InitUpAmount, CVSReader.uintParse);
			this.columnno = 28;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PlantSeed.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public PlantSeed.RowData[] Table = null;

		public class RowData
		{

			public uint SeedID;

			public string SeedName;

			public SeqRef<int> PlantID;

			public string PlantName;

			public uint GrowUpAmount;

			public uint GrowUpAmountPerMinute;

			public uint PredictGrowUpTime;

			public SeqRef<uint> HarvestPlant;

			public SeqRef<uint> ExtraDropItem;

			public uint IncreaseGrowUpRate;

			public uint ReduceGrowUpRate;

			public uint PlantStateCD;

			public uint BadStateGrowUpRate;

			public SeqRef<int> StealAward;

			public uint CanStealMaxTimes;

			public uint InitUpAmount;
		}
	}
}
