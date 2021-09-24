using System;

namespace XUtliPoolLib
{

	public class GardenFishConfig : CVSReader
	{

		public GardenFishConfig.RowData GetByFishLeve(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GardenFishConfig.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].FishLeve == key;
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
			GardenFishConfig.RowData rowData = new GardenFishConfig.RowData();
			base.Read<uint>(reader, ref rowData.FishLeve, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.Experience, CVSReader.uintParse);
			this.columnno = 1;
			rowData.FishWeight.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SuccessRate, CVSReader.uintParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GardenFishConfig.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GardenFishConfig.RowData[] Table = null;

		public class RowData
		{

			public uint FishLeve;

			public uint Experience;

			public SeqListRef<int> FishWeight;

			public uint SuccessRate;
		}
	}
}
