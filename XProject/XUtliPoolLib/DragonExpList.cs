using System;

namespace XUtliPoolLib
{
	// Token: 0x020000DB RID: 219
	public class DragonExpList : CVSReader
	{
		// Token: 0x060005F0 RID: 1520 RVA: 0x0001BF70 File Offset: 0x0001A170
		public DragonExpList.RowData GetBySceneID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			DragonExpList.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].SceneID == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x0001BFDC File Offset: 0x0001A1DC
		protected override void ReadLine(XBinaryReader reader)
		{
			DragonExpList.RowData rowData = new DragonExpList.RowData();
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Description, CVSReader.stringParse);
			this.columnno = 1;
			rowData.WinReward.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.ResName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.BuffIcon, CVSReader.stringParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.BuffDes, CVSReader.stringParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.BossID, CVSReader.uintParse);
			this.columnno = 8;
			base.Read<uint>(reader, ref rowData.SealLevel, CVSReader.uintParse);
			this.columnno = 9;
			rowData.ChapterID.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.WinHit, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<float>(reader, ref rowData.LimitPos, CVSReader.floatParse);
			this.columnno = 13;
			base.ReadArray<float>(reader, ref rowData.SnapPos, CVSReader.floatParse);
			this.columnno = 14;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x0001C144 File Offset: 0x0001A344
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new DragonExpList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000327 RID: 807
		public DragonExpList.RowData[] Table = null;

		// Token: 0x020002DA RID: 730
		public class RowData
		{
			// Token: 0x04000A0A RID: 2570
			public uint SceneID;

			// Token: 0x04000A0B RID: 2571
			public string Description;

			// Token: 0x04000A0C RID: 2572
			public SeqListRef<uint> WinReward;

			// Token: 0x04000A0D RID: 2573
			public string ResName;

			// Token: 0x04000A0E RID: 2574
			public string BuffIcon;

			// Token: 0x04000A0F RID: 2575
			public string BuffDes;

			// Token: 0x04000A10 RID: 2576
			public uint BossID;

			// Token: 0x04000A11 RID: 2577
			public uint SealLevel;

			// Token: 0x04000A12 RID: 2578
			public SeqRef<uint> ChapterID;

			// Token: 0x04000A13 RID: 2579
			public string WinHit;

			// Token: 0x04000A14 RID: 2580
			public float LimitPos;

			// Token: 0x04000A15 RID: 2581
			public float[] SnapPos;
		}
	}
}
