using System;

namespace XUtliPoolLib
{
	// Token: 0x020000C5 RID: 197
	public class ChatOpen : CVSReader
	{
		// Token: 0x06000582 RID: 1410 RVA: 0x00018ED8 File Offset: 0x000170D8
		protected override void ReadLine(XBinaryReader reader)
		{
			ChatOpen.RowData rowData = new ChatOpen.RowData();
			base.Read<uint>(reader, ref rowData.id, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<int>(reader, ref rowData.opens, CVSReader.intParse);
			this.columnno = 2;
			base.Read<uint>(reader, ref rowData.friends, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<int>(reader, ref rowData.posX, CVSReader.intParse);
			this.columnno = 4;
			base.Read<int>(reader, ref rowData.posY, CVSReader.intParse);
			this.columnno = 5;
			base.Read<float>(reader, ref rowData.alpha, CVSReader.floatParse);
			this.columnno = 6;
			base.Read<int>(reader, ref rowData.pivot, CVSReader.intParse);
			this.columnno = 7;
			base.Read<float>(reader, ref rowData.scale, CVSReader.floatParse);
			this.columnno = 8;
			base.Read<int>(reader, ref rowData.fade, CVSReader.intParse);
			this.columnno = 9;
			base.Read<int>(reader, ref rowData.real, CVSReader.intParse);
			this.columnno = 10;
			base.Read<int>(reader, ref rowData.radioX, CVSReader.intParse);
			this.columnno = 11;
			base.Read<int>(reader, ref rowData.radioY, CVSReader.intParse);
			this.columnno = 12;
			base.Read<int>(reader, ref rowData.battle, CVSReader.intParse);
			this.columnno = 13;
			base.Read<uint>(reader, ref rowData.sceneid, CVSReader.uintParse);
			this.columnno = 14;
			base.Read<int>(reader, ref rowData.max, CVSReader.intParse);
			this.columnno = 15;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x00019090 File Offset: 0x00017290
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new ChatOpen.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040002EB RID: 747
		public ChatOpen.RowData[] Table = null;

		// Token: 0x020002C3 RID: 707
		public class RowData
		{
			// Token: 0x04000984 RID: 2436
			public uint id;

			// Token: 0x04000985 RID: 2437
			public int[] opens;

			// Token: 0x04000986 RID: 2438
			public uint friends;

			// Token: 0x04000987 RID: 2439
			public int posX;

			// Token: 0x04000988 RID: 2440
			public int posY;

			// Token: 0x04000989 RID: 2441
			public float alpha;

			// Token: 0x0400098A RID: 2442
			public int pivot;

			// Token: 0x0400098B RID: 2443
			public float scale;

			// Token: 0x0400098C RID: 2444
			public int fade;

			// Token: 0x0400098D RID: 2445
			public int real;

			// Token: 0x0400098E RID: 2446
			public int radioX;

			// Token: 0x0400098F RID: 2447
			public int radioY;

			// Token: 0x04000990 RID: 2448
			public int battle;

			// Token: 0x04000991 RID: 2449
			public uint sceneid;

			// Token: 0x04000992 RID: 2450
			public int max;
		}
	}
}
