using System;

namespace XUtliPoolLib
{
	// Token: 0x02000271 RID: 625
	public class JadeSealTable : CVSReader
	{
		// Token: 0x06000D55 RID: 3413 RVA: 0x00046664 File Offset: 0x00044864
		protected override void ReadLine(XBinaryReader reader)
		{
			JadeSealTable.RowData rowData = new JadeSealTable.RowData();
			base.Read<uint>(reader, ref rowData.SealID, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.SealJob, CVSReader.uintParse);
			this.columnno = 1;
			base.ReadArray<uint>(reader, ref rowData.SealEquip, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SealNum, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.SealName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.SealLevel, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.SealQuality, CVSReader.uintParse);
			this.columnno = 6;
			rowData.SealAttributes.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			base.ReadArray<uint>(reader, ref rowData.SealSuit, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.SealWeight, CVSReader.uintParse);
			this.columnno = 9;
			rowData.SealBuff.Read(reader, this.m_DataHandler);
			this.columnno = 10;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D56 RID: 3414 RVA: 0x000467B0 File Offset: 0x000449B0
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new JadeSealTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007BF RID: 1983
		public JadeSealTable.RowData[] Table = null;

		// Token: 0x02000400 RID: 1024
		public class RowData
		{
			// Token: 0x04001241 RID: 4673
			public uint SealID;

			// Token: 0x04001242 RID: 4674
			public uint[] SealJob;

			// Token: 0x04001243 RID: 4675
			public uint[] SealEquip;

			// Token: 0x04001244 RID: 4676
			public uint SealNum;

			// Token: 0x04001245 RID: 4677
			public string SealName;

			// Token: 0x04001246 RID: 4678
			public uint SealLevel;

			// Token: 0x04001247 RID: 4679
			public uint SealQuality;

			// Token: 0x04001248 RID: 4680
			public SeqListRef<uint> SealAttributes;

			// Token: 0x04001249 RID: 4681
			public uint[] SealSuit;

			// Token: 0x0400124A RID: 4682
			public uint SealWeight;

			// Token: 0x0400124B RID: 4683
			public SeqListRef<uint> SealBuff;
		}
	}
}
