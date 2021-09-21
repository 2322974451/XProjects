using System;

namespace XUtliPoolLib
{
	// Token: 0x020000E2 RID: 226
	public class EnhanceFxTable : CVSReader
	{
		// Token: 0x06000609 RID: 1545 RVA: 0x0001CA5C File Offset: 0x0001AC5C
		protected override void ReadLine(XBinaryReader reader)
		{
			EnhanceFxTable.RowData rowData = new EnhanceFxTable.RowData();
			base.Read<uint>(reader, ref rowData.EnhanceLevel, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<string>(reader, ref rowData.MainWeaponFx, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.ProfID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Tips, CVSReader.stringParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x0001CAF0 File Offset: 0x0001ACF0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new EnhanceFxTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400032E RID: 814
		public EnhanceFxTable.RowData[] Table = null;

		// Token: 0x020002E1 RID: 737
		public class RowData
		{
			// Token: 0x04000A45 RID: 2629
			public uint EnhanceLevel;

			// Token: 0x04000A46 RID: 2630
			public string[] MainWeaponFx;

			// Token: 0x04000A47 RID: 2631
			public uint ProfID;

			// Token: 0x04000A48 RID: 2632
			public string Tips;
		}
	}
}
