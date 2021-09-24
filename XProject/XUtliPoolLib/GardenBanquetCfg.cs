using System;

namespace XUtliPoolLib
{

	public class GardenBanquetCfg : CVSReader
	{

		public GardenBanquetCfg.RowData GetByBanquetID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GardenBanquetCfg.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].BanquetID == key;
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
			GardenBanquetCfg.RowData rowData = new GardenBanquetCfg.RowData();
			base.Read<uint>(reader, ref rowData.BanquetID, CVSReader.uintParse);
			this.columnno = 0;
			rowData.Stuffs.Read(reader, this.m_DataHandler);
			this.columnno = 1;
			rowData.BanquetAwards.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.BanquetName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.VoiceOver1Duration, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.VoiceOver2Duration, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.VoiceOver3Duration, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.VoiceOver4Duration, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.VoiceOver1, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.VoiceOver2, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.VoiceOver3, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.VoiceOver4, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.Desc, CVSReader.stringParse);
			this.columnno = 13;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GardenBanquetCfg.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public GardenBanquetCfg.RowData[] Table = null;

		public class RowData
		{

			public uint BanquetID;

			public SeqListRef<uint> Stuffs;

			public SeqListRef<uint> BanquetAwards;

			public string BanquetName;

			public uint VoiceOver1Duration;

			public uint VoiceOver2Duration;

			public uint VoiceOver3Duration;

			public uint VoiceOver4Duration;

			public string VoiceOver1;

			public string VoiceOver2;

			public string VoiceOver3;

			public string VoiceOver4;

			public string Desc;
		}
	}
}
