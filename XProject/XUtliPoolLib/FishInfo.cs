using System;

namespace XUtliPoolLib
{

	public class FishInfo : CVSReader
	{

		public FishInfo.RowData GetByFishID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			FishInfo.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].FishID == key;
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
			FishInfo.RowData rowData = new FishInfo.RowData();
			base.Read<uint>(reader, ref rowData.FishID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.quality, CVSReader.intParse);
			this.columnno = 2;
			base.Read<bool>(reader, ref rowData.ShowInLevel, CVSReader.boolParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FishInfo.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public FishInfo.RowData[] Table = null;

		public class RowData
		{

			public uint FishID;

			public int quality;

			public bool ShowInLevel;
		}
	}
}
