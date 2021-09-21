using System;

namespace XUtliPoolLib
{
	// Token: 0x0200025E RID: 606
	public class FashionSynthesis : CVSReader
	{
		// Token: 0x06000D15 RID: 3349 RVA: 0x00045000 File Offset: 0x00043200
		protected override void ReadLine(XBinaryReader reader)
		{
			FashionSynthesis.RowData rowData = new FashionSynthesis.RowData();
			base.Read<uint>(reader, ref rowData.FashionID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.SuccessRate, CVSReader.uintParse);
			this.columnno = 1;
			rowData.ReturnItems.Read(reader, this.m_DataHandler);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.SuitID, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.FashinSynthesisAddSucessRate, CVSReader.uintParse);
			this.columnno = 4;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x000450AC File Offset: 0x000432AC
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new FashionSynthesis.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040007AC RID: 1964
		public FashionSynthesis.RowData[] Table = null;

		// Token: 0x020003ED RID: 1005
		public class RowData
		{
			// Token: 0x040011D2 RID: 4562
			public uint FashionID;

			// Token: 0x040011D3 RID: 4563
			public uint SuccessRate;

			// Token: 0x040011D4 RID: 4564
			public SeqListRef<uint> ReturnItems;

			// Token: 0x040011D5 RID: 4565
			public uint SuitID;

			// Token: 0x040011D6 RID: 4566
			public uint FashinSynthesisAddSucessRate;
		}
	}
}
