using System;

namespace XUtliPoolLib
{
	// Token: 0x02000156 RID: 342
	public class PVEAttrModify : CVSReader
	{
		// Token: 0x060007B5 RID: 1973 RVA: 0x000271B8 File Offset: 0x000253B8
		public PVEAttrModify.RowData GetBySceneID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			PVEAttrModify.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchSceneID(key);
			}
			return result;
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x000271F0 File Offset: 0x000253F0
		private PVEAttrModify.RowData BinarySearchSceneID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			PVEAttrModify.RowData rowData;
			PVEAttrModify.RowData rowData2;
			PVEAttrModify.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.SceneID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.SceneID == key;
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
				bool flag4 = rowData3.SceneID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.SceneID.CompareTo(key) < 0;
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

		// Token: 0x060007B7 RID: 1975 RVA: 0x000272CC File Offset: 0x000254CC
		protected override void ReadLine(XBinaryReader reader)
		{
			PVEAttrModify.RowData rowData = new PVEAttrModify.RowData();
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 0;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x00027310 File Offset: 0x00025510
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new PVEAttrModify.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003A2 RID: 930
		public PVEAttrModify.RowData[] Table = null;

		// Token: 0x02000355 RID: 853
		public class RowData
		{
			// Token: 0x04000D5C RID: 3420
			public uint SceneID;
		}
	}
}
