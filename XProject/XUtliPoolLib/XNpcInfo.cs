using System;

namespace XUtliPoolLib
{
	// Token: 0x02000186 RID: 390
	public class XNpcInfo : CVSReader
	{
		// Token: 0x06000870 RID: 2160 RVA: 0x0002D640 File Offset: 0x0002B840
		public XNpcInfo.RowData GetByNPCID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			XNpcInfo.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchNPCID(key);
			}
			return result;
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x0002D678 File Offset: 0x0002B878
		private XNpcInfo.RowData BinarySearchNPCID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			XNpcInfo.RowData rowData;
			XNpcInfo.RowData rowData2;
			XNpcInfo.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.ID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.ID == key;
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
				bool flag4 = rowData3.ID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.ID.CompareTo(key) < 0;
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

		// Token: 0x06000872 RID: 2162 RVA: 0x0002D754 File Offset: 0x0002B954
		protected override void ReadLine(XBinaryReader reader)
		{
			XNpcInfo.RowData rowData = new XNpcInfo.RowData();
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<uint>(reader, ref rowData.PresentID, CVSReader.uintParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.Portrait, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<uint>(reader, ref rowData.SceneID, CVSReader.uintParse);
			this.columnno = 5;
			base.ReadArray<float>(reader, ref rowData.Position, CVSReader.floatParse);
			this.columnno = 6;
			base.ReadArray<float>(reader, ref rowData.Rotation, CVSReader.floatParse);
			this.columnno = 7;
			base.Read<uint>(reader, ref rowData.RequiredTaskID, CVSReader.uintParse);
			this.columnno = 8;
			base.ReadArray<string>(reader, ref rowData.Content, CVSReader.stringParse);
			this.columnno = 9;
			base.ReadArray<int>(reader, ref rowData.FunctionList, CVSReader.intParse);
			this.columnno = 10;
			base.Read<uint>(reader, ref rowData.Gazing, CVSReader.uintParse);
			this.columnno = 11;
			base.ReadArray<string>(reader, ref rowData.Voice, CVSReader.stringParse);
			this.columnno = 12;
			base.ReadArray<string>(reader, ref rowData.ShowUp, CVSReader.stringParse);
			this.columnno = 13;
			base.Read<bool>(reader, ref rowData.OnlyHead, CVSReader.boolParse);
			this.columnno = 14;
			base.Read<int>(reader, ref rowData.LinkSystem, CVSReader.intParse);
			this.columnno = 15;
			base.Read<uint>(reader, ref rowData.NPCType, CVSReader.uintParse);
			this.columnno = 16;
			base.Read<uint>(reader, ref rowData.DisappearTask, CVSReader.uintParse);
			this.columnno = 17;
			base.Read<string>(reader, ref rowData.SpecialAnim, CVSReader.stringParse);
			this.columnno = 18;
			base.Read<string>(reader, ref rowData.SpecialChat, CVSReader.stringParse);
			this.columnno = 19;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x0002D990 File Offset: 0x0002BB90
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new XNpcInfo.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003D2 RID: 978
		public XNpcInfo.RowData[] Table = null;

		// Token: 0x02000385 RID: 901
		public class RowData
		{
			// Token: 0x04000F9B RID: 3995
			public uint ID;

			// Token: 0x04000F9C RID: 3996
			public string Name;

			// Token: 0x04000F9D RID: 3997
			public uint PresentID;

			// Token: 0x04000F9E RID: 3998
			public string Icon;

			// Token: 0x04000F9F RID: 3999
			public string Portrait;

			// Token: 0x04000FA0 RID: 4000
			public uint SceneID;

			// Token: 0x04000FA1 RID: 4001
			public float[] Position;

			// Token: 0x04000FA2 RID: 4002
			public float[] Rotation;

			// Token: 0x04000FA3 RID: 4003
			public uint RequiredTaskID;

			// Token: 0x04000FA4 RID: 4004
			public string[] Content;

			// Token: 0x04000FA5 RID: 4005
			public int[] FunctionList;

			// Token: 0x04000FA6 RID: 4006
			public uint Gazing;

			// Token: 0x04000FA7 RID: 4007
			public string[] Voice;

			// Token: 0x04000FA8 RID: 4008
			public string[] ShowUp;

			// Token: 0x04000FA9 RID: 4009
			public bool OnlyHead;

			// Token: 0x04000FAA RID: 4010
			public int LinkSystem;

			// Token: 0x04000FAB RID: 4011
			public uint NPCType;

			// Token: 0x04000FAC RID: 4012
			public uint DisappearTask;

			// Token: 0x04000FAD RID: 4013
			public string SpecialAnim;

			// Token: 0x04000FAE RID: 4014
			public string SpecialChat;
		}
	}
}
