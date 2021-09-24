using System;

namespace XUtliPoolLib
{

	public class HeroBattleExperienceHero : CVSReader
	{

		public HeroBattleExperienceHero.RowData GetByItemID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			HeroBattleExperienceHero.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].ItemID == key;
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
			HeroBattleExperienceHero.RowData rowData = new HeroBattleExperienceHero.RowData();
			base.Read<uint>(reader, ref rowData.ItemID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.HeroID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.LastTime, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.ShowTime, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new HeroBattleExperienceHero.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public HeroBattleExperienceHero.RowData[] Table = null;

		public class RowData
		{

			public uint ItemID;

			public uint HeroID;

			public uint LastTime;

			public string ShowTime;
		}
	}
}
