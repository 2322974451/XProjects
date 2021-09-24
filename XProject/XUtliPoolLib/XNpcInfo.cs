using System;

namespace XUtliPoolLib
{

	public class XNpcInfo : CVSReader
	{

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

		public XNpcInfo.RowData[] Table = null;

		public class RowData
		{

			public uint ID;

			public string Name;

			public uint PresentID;

			public string Icon;

			public string Portrait;

			public uint SceneID;

			public float[] Position;

			public float[] Rotation;

			public uint RequiredTaskID;

			public string[] Content;

			public int[] FunctionList;

			public uint Gazing;

			public string[] Voice;

			public string[] ShowUp;

			public bool OnlyHead;

			public int LinkSystem;

			public uint NPCType;

			public uint DisappearTask;

			public string SpecialAnim;

			public string SpecialChat;
		}
	}
}
