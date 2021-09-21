using System;

namespace XUtliPoolLib
{
	// Token: 0x020000F3 RID: 243
	public class FlowerRain : CVSReader
	{
		// Token: 0x06000649 RID: 1609 RVA: 0x0001E750 File Offset: 0x0001C950
		protected override void ReadLine(XBinaryReader reader)
		{
			FlowerRain.RowData rowData = new FlowerRain.RowData();
			base.Read<int>(reader, ref rowData.FlowerID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<int>(reader, ref rowData.Count, CVSReader.intParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.EffectPath, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<int>(reader, ref rowData.PlayTime, CVSReader.intParse);
			this.columnno = 3;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x0001E7E4 File Offset: 0x0001C9E4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FlowerRain.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x0400033F RID: 831
		public FlowerRain.RowData[] Table = null;

		// Token: 0x020002F2 RID: 754
		public class RowData
		{
			// Token: 0x04000ADB RID: 2779
			public int FlowerID;

			// Token: 0x04000ADC RID: 2780
			public int Count;

			// Token: 0x04000ADD RID: 2781
			public string EffectPath;

			// Token: 0x04000ADE RID: 2782
			public int PlayTime;
		}
	}
}
