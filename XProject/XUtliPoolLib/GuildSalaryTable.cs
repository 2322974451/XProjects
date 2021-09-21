using System;

namespace XUtliPoolLib
{
	// Token: 0x02000117 RID: 279
	public class GuildSalaryTable : CVSReader
	{
		// Token: 0x060006CD RID: 1741 RVA: 0x000213B8 File Offset: 0x0001F5B8
		public GuildSalaryTable.RowData GetByGuildLevel(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			GuildSalaryTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].GuildLevel == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x00021424 File Offset: 0x0001F624
		protected override void ReadLine(XBinaryReader reader)
		{
			GuildSalaryTable.RowData rowData = new GuildSalaryTable.RowData();
			base.Read<uint>(reader, ref rowData.GuildLevel, CVSReader.uintParse);
			this.columnno = 0;
			base.ReadArray<uint>(reader, ref rowData.GuildReview, CVSReader.uintParse);
			this.columnno = 1;
			rowData.NumberTransformation.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.PrestigeTransformation.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			rowData.ActiveTransformation.Read(reader, this.m_DataHandler);
			this.columnno = 5;
			rowData.EXPTransformation.Read(reader, this.m_DataHandler);
			this.columnno = 6;
			rowData.SSalary1.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			rowData.SSalary2.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			rowData.SSalary3.Read(reader, this.m_DataHandler);
			this.columnno = 9;
			rowData.SSalary4.Read(reader, this.m_DataHandler);
			this.columnno = 10;
			rowData.SSalary5.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			rowData.ASalary1.Read(reader, this.m_DataHandler);
			this.columnno = 12;
			rowData.ASalary2.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			rowData.ASalary3.Read(reader, this.m_DataHandler);
			this.columnno = 14;
			rowData.ASalary4.Read(reader, this.m_DataHandler);
			this.columnno = 15;
			rowData.ASalary5.Read(reader, this.m_DataHandler);
			this.columnno = 16;
			rowData.BSalary1.Read(reader, this.m_DataHandler);
			this.columnno = 17;
			rowData.BSalary2.Read(reader, this.m_DataHandler);
			this.columnno = 18;
			rowData.BSalary3.Read(reader, this.m_DataHandler);
			this.columnno = 19;
			rowData.BSalary4.Read(reader, this.m_DataHandler);
			this.columnno = 20;
			rowData.BSalary5.Read(reader, this.m_DataHandler);
			this.columnno = 21;
			rowData.CSalary1.Read(reader, this.m_DataHandler);
			this.columnno = 22;
			rowData.CSalary2.Read(reader, this.m_DataHandler);
			this.columnno = 23;
			rowData.CSalary3.Read(reader, this.m_DataHandler);
			this.columnno = 24;
			rowData.CSalary4.Read(reader, this.m_DataHandler);
			this.columnno = 25;
			rowData.CSalary5.Read(reader, this.m_DataHandler);
			this.columnno = 26;
			rowData.DSalary1.Read(reader, this.m_DataHandler);
			this.columnno = 27;
			rowData.DSalary2.Read(reader, this.m_DataHandler);
			this.columnno = 28;
			rowData.DSalary3.Read(reader, this.m_DataHandler);
			this.columnno = 29;
			rowData.DSalary4.Read(reader, this.m_DataHandler);
			this.columnno = 30;
			rowData.DSalary5.Read(reader, this.m_DataHandler);
			this.columnno = 31;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0002178C File Offset: 0x0001F98C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new GuildSalaryTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x04000363 RID: 867
		public GuildSalaryTable.RowData[] Table = null;

		// Token: 0x02000316 RID: 790
		public class RowData
		{
			// Token: 0x04000B8D RID: 2957
			public uint GuildLevel;

			// Token: 0x04000B8E RID: 2958
			public uint[] GuildReview;

			// Token: 0x04000B8F RID: 2959
			public SeqListRef<uint> NumberTransformation;

			// Token: 0x04000B90 RID: 2960
			public SeqListRef<uint> PrestigeTransformation;

			// Token: 0x04000B91 RID: 2961
			public SeqListRef<uint> ActiveTransformation;

			// Token: 0x04000B92 RID: 2962
			public SeqListRef<uint> EXPTransformation;

			// Token: 0x04000B93 RID: 2963
			public SeqListRef<uint> SSalary1;

			// Token: 0x04000B94 RID: 2964
			public SeqListRef<uint> SSalary2;

			// Token: 0x04000B95 RID: 2965
			public SeqListRef<uint> SSalary3;

			// Token: 0x04000B96 RID: 2966
			public SeqListRef<uint> SSalary4;

			// Token: 0x04000B97 RID: 2967
			public SeqListRef<uint> SSalary5;

			// Token: 0x04000B98 RID: 2968
			public SeqListRef<uint> ASalary1;

			// Token: 0x04000B99 RID: 2969
			public SeqListRef<uint> ASalary2;

			// Token: 0x04000B9A RID: 2970
			public SeqListRef<uint> ASalary3;

			// Token: 0x04000B9B RID: 2971
			public SeqListRef<uint> ASalary4;

			// Token: 0x04000B9C RID: 2972
			public SeqListRef<uint> ASalary5;

			// Token: 0x04000B9D RID: 2973
			public SeqListRef<uint> BSalary1;

			// Token: 0x04000B9E RID: 2974
			public SeqListRef<uint> BSalary2;

			// Token: 0x04000B9F RID: 2975
			public SeqListRef<uint> BSalary3;

			// Token: 0x04000BA0 RID: 2976
			public SeqListRef<uint> BSalary4;

			// Token: 0x04000BA1 RID: 2977
			public SeqListRef<uint> BSalary5;

			// Token: 0x04000BA2 RID: 2978
			public SeqListRef<uint> CSalary1;

			// Token: 0x04000BA3 RID: 2979
			public SeqListRef<uint> CSalary2;

			// Token: 0x04000BA4 RID: 2980
			public SeqListRef<uint> CSalary3;

			// Token: 0x04000BA5 RID: 2981
			public SeqListRef<uint> CSalary4;

			// Token: 0x04000BA6 RID: 2982
			public SeqListRef<uint> CSalary5;

			// Token: 0x04000BA7 RID: 2983
			public SeqListRef<uint> DSalary1;

			// Token: 0x04000BA8 RID: 2984
			public SeqListRef<uint> DSalary2;

			// Token: 0x04000BA9 RID: 2985
			public SeqListRef<uint> DSalary3;

			// Token: 0x04000BAA RID: 2986
			public SeqListRef<uint> DSalary4;

			// Token: 0x04000BAB RID: 2987
			public SeqListRef<uint> DSalary5;
		}
	}
}
