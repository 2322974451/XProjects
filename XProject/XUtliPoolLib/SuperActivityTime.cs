using System;

namespace XUtliPoolLib
{
	// Token: 0x02000177 RID: 375
	public class SuperActivityTime : CVSReader
	{
		// Token: 0x06000835 RID: 2101 RVA: 0x0002B02C File Offset: 0x0002922C
		public SuperActivityTime.RowData GetByactid(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			SuperActivityTime.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.Table.Length; i++)
				{
					bool flag2 = this.Table[i].actid == key;
					if (flag2)
					{
						return this.Table[i];
					}
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x0002B098 File Offset: 0x00029298
		protected override void ReadLine(XBinaryReader reader)
		{
			SuperActivityTime.RowData rowData = new SuperActivityTime.RowData();
			base.Read<uint>(reader, ref rowData.actid, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.systemid, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.starttime, CVSReader.uintParse);
			this.columnno = 3;
			base.Read<uint>(reader, ref rowData.duration, CVSReader.uintParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.rewardtime, CVSReader.uintParse);
			this.columnno = 5;
			base.Read<uint>(reader, ref rowData.pointid, CVSReader.uintParse);
			this.columnno = 6;
			base.Read<uint>(reader, ref rowData.needpoint, CVSReader.uintParse);
			this.columnno = 7;
			base.Read<float>(reader, ref rowData.rate, CVSReader.floatParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.starthour, CVSReader.uintParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.datetype, CVSReader.uintParse);
			this.columnno = 12;
			rowData.timestage.Read(reader, this.m_DataHandler);
			this.columnno = 13;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x0002B1E4 File Offset: 0x000293E4
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SuperActivityTime.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003C3 RID: 963
		public SuperActivityTime.RowData[] Table = null;

		// Token: 0x02000376 RID: 886
		public class RowData
		{
			// Token: 0x04000EAB RID: 3755
			public uint actid;

			// Token: 0x04000EAC RID: 3756
			public uint systemid;

			// Token: 0x04000EAD RID: 3757
			public uint starttime;

			// Token: 0x04000EAE RID: 3758
			public uint duration;

			// Token: 0x04000EAF RID: 3759
			public uint rewardtime;

			// Token: 0x04000EB0 RID: 3760
			public uint pointid;

			// Token: 0x04000EB1 RID: 3761
			public uint needpoint;

			// Token: 0x04000EB2 RID: 3762
			public float rate;

			// Token: 0x04000EB3 RID: 3763
			public uint starthour;

			// Token: 0x04000EB4 RID: 3764
			public uint datetype;

			// Token: 0x04000EB5 RID: 3765
			public SeqListRef<uint> timestage;
		}
	}
}
