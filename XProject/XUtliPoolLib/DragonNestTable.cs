using System;

namespace XUtliPoolLib
{

	public class DragonNestTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			DragonNestTable.RowData rowData = new DragonNestTable.RowData();
			base.Read<uint>(reader, ref rowData.DragonNestID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.DragonNestType, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.DragonNestDifficulty, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.DragonNestWave, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.DragonNestPosX, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.DragonNestPosY, CVSReader.intParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.DragonNestIcon, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.SuggestAttr, CVSReader.stringParse);
			this.columnno = 7;
			rowData.WeakInfo.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			base.ReadArray<string>(reader, ref rowData.WeakTip1, CVSReader.stringParse);
			this.columnno = 9;
			base.ReadArray<string>(reader, ref rowData.WeakTip2, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.WeakNotPassTip1, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.WeakNotPassTip2, CVSReader.stringParse);
			this.columnno = 12;
			base.ReadArray<int>(reader, ref rowData.WeakPercent, CVSReader.intParse);
			this.columnno = 13;
			base.ReadArray<uint>(reader, ref rowData.WeakCombat, CVSReader.uintParse);
			this.columnno = 14;
			rowData.WeakInfoEx.Read(reader, this.m_DataHandler);
			this.columnno = 15;
			base.ReadArray<string>(reader, ref rowData.WeakTip1EX, CVSReader.stringParse);
			this.columnno = 16;
			base.ReadArray<string>(reader, ref rowData.WeakTip2EX, CVSReader.stringParse);
			this.columnno = 17;
			base.ReadArray<int>(reader, ref rowData.WeakPercentEX, CVSReader.intParse);
			this.columnno = 18;
			base.ReadArray<uint>(reader, ref rowData.WeakCombatEX, CVSReader.uintParse);
			this.columnno = 19;
			base.Read<string>(reader, ref rowData.DragonNestAtlas, CVSReader.stringParse);
			this.columnno = 20;
			base.Read<int>(reader, ref rowData.MaxDragonDropLevel, CVSReader.intParse);
			this.columnno = 21;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonNestTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public DragonNestTable.RowData[] Table = null;

		public class RowData
		{

			public uint DragonNestID;

			public uint DragonNestType;

			public uint DragonNestDifficulty;

			public uint DragonNestWave;

			public int DragonNestPosX;

			public int DragonNestPosY;

			public string DragonNestIcon;

			public string SuggestAttr;

			public SeqListRef<uint> WeakInfo;

			public string[] WeakTip1;

			public string[] WeakTip2;

			public string WeakNotPassTip1;

			public string WeakNotPassTip2;

			public int[] WeakPercent;

			public uint[] WeakCombat;

			public SeqListRef<uint> WeakInfoEx;

			public string[] WeakTip1EX;

			public string[] WeakTip2EX;

			public int[] WeakPercentEX;

			public uint[] WeakCombatEX;

			public string DragonNestAtlas;

			public int MaxDragonDropLevel;
		}
	}
}
