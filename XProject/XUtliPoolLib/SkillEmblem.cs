using System;

namespace XUtliPoolLib
{
	// Token: 0x0200016B RID: 363
	public class SkillEmblem : CVSReader
	{
		// Token: 0x06000808 RID: 2056 RVA: 0x00029758 File Offset: 0x00027958
		public SkillEmblem.RowData GetByEmblemID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SkillEmblem.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchEmblemID(key);
			}
			return result;
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x00029790 File Offset: 0x00027990
		private SkillEmblem.RowData BinarySearchEmblemID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			SkillEmblem.RowData rowData;
			SkillEmblem.RowData rowData2;
			SkillEmblem.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.EmblemID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.EmblemID == key;
				if (flag2)
				{
					goto Block_2;
				}
				bool flag3 = num2 - num <= 1;
				if (flag3)
				{
					goto Block_3;
				}
				int num3 = num + (num2 - num) / 2;
				rowData3 = this.Table[num3];
				bool flag4 = rowData3.EmblemID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.EmblemID.CompareTo(key) < 0;
					if (!flag5)
					{
						goto IL_B1;
					}
					num = num3;
				}
				if (num >= num2)
				{
					goto Block_6;
				}
			}
			return rowData;
			Block_2:
			return rowData2;
			Block_3:
			return null;
			IL_B1:
			return rowData3;
			Block_6:
			return null;
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x0002986C File Offset: 0x00027A6C
		protected override void ReadLine(XBinaryReader reader)
		{
			SkillEmblem.RowData rowData = new SkillEmblem.RowData();
			base.Read<uint>(reader, ref rowData.EmblemID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.SkillScript, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<byte>(reader, ref rowData.SkillType, CVSReader.byteParse);
			this.columnno = 2;
			base.Read<byte>(reader, ref rowData.SkillPercent, CVSReader.byteParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.SkillName, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.SkillPPT, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.ExSkillScript, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<string>(reader, ref rowData.OtherSkillScripts, CVSReader.stringParse);
			this.columnno = 8;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x00029968 File Offset: 0x00027B68
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SkillEmblem.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003B7 RID: 951
		public SkillEmblem.RowData[] Table = null;

		// Token: 0x0200036A RID: 874
		public class RowData
		{
			// Token: 0x04000E16 RID: 3606
			public uint EmblemID;

			// Token: 0x04000E17 RID: 3607
			public string SkillScript;

			// Token: 0x04000E18 RID: 3608
			public byte SkillType;

			// Token: 0x04000E19 RID: 3609
			public byte SkillPercent;

			// Token: 0x04000E1A RID: 3610
			public string SkillName;

			// Token: 0x04000E1B RID: 3611
			public uint SkillPPT;

			// Token: 0x04000E1C RID: 3612
			public string ExSkillScript;

			// Token: 0x04000E1D RID: 3613
			public string[] OtherSkillScripts;
		}
	}
}
