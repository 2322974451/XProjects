using System;

namespace XUtliPoolLib
{

	public class XEntityStatistics : CVSReader
	{

		public XEntityStatistics.RowData GetByID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			XEntityStatistics.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchID(key);
			}
			return result;
		}

		private XEntityStatistics.RowData BinarySearchID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			XEntityStatistics.RowData rowData;
			XEntityStatistics.RowData rowData2;
			XEntityStatistics.RowData rowData3;
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
			XEntityStatistics.RowData rowData = new XEntityStatistics.RowData();
			base.Read<string>(reader, ref rowData.Name, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.PresentID, CVSReader.uintParse);
			this.columnno = 1;
			base.Read<float>(reader, ref rowData.WalkSpeed, CVSReader.floatParse);
			this.columnno = 2;
			base.Read<float>(reader, ref rowData.RunSpeed, CVSReader.floatParse);
			this.columnno = 3;
			base.ReadArray<float>(reader, ref rowData.FloatHeight, CVSReader.floatParse);
			this.columnno = 4;
			base.Read<float>(reader, ref rowData.RotateSpeed, CVSReader.floatParse);
			this.columnno = 5;
			base.Read<float>(reader, ref rowData.MaxHP, CVSReader.floatParse);
			this.columnno = 6;
			base.Read<float>(reader, ref rowData.AttackProb, CVSReader.floatParse);
			this.columnno = 7;
			base.Read<float>(reader, ref rowData.Sight, CVSReader.floatParse);
			this.columnno = 8;
			base.Read<byte>(reader, ref rowData.Type, CVSReader.byteParse);
			this.columnno = 9;
			base.Read<uint>(reader, ref rowData.ID, CVSReader.uintParse);
			this.columnno = 10;
			rowData.InBornBuff.Read(reader, this.m_DataHandler);
			this.columnno = 11;
			base.Read<float>(reader, ref rowData.AttackBase, CVSReader.floatParse);
			this.columnno = 12;
			base.Read<bool>(reader, ref rowData.IsWander, CVSReader.boolParse);
			this.columnno = 13;
			base.Read<bool>(reader, ref rowData.Block, CVSReader.boolParse);
			this.columnno = 14;
			base.Read<float>(reader, ref rowData.AIStartTime, CVSReader.floatParse);
			this.columnno = 15;
			base.Read<float>(reader, ref rowData.AIActionGap, CVSReader.floatParse);
			this.columnno = 16;
			base.Read<short>(reader, ref rowData.FashionTemplate, CVSReader.shortParse);
			this.columnno = 17;
			base.Read<int>(reader, ref rowData.MaxSuperArmor, CVSReader.intParse);
			this.columnno = 18;
			base.Read<bool>(reader, ref rowData.IsFixedInCD, CVSReader.boolParse);
			this.columnno = 19;
			base.Read<uint>(reader, ref rowData.HpSection, CVSReader.uintParse);
			this.columnno = 20;
			base.Read<bool>(reader, ref rowData.EndShow, CVSReader.boolParse);
			this.columnno = 21;
			base.Read<bool>(reader, ref rowData.Highlight, CVSReader.boolParse);
			this.columnno = 22;
			base.Read<float>(reader, ref rowData.MagicAttackBase, CVSReader.floatParse);
			this.columnno = 23;
			base.Read<byte>(reader, ref rowData.UseMyMesh, CVSReader.byteParse);
			this.columnno = 24;
			rowData.ExtraReward.Read(reader, this.m_DataHandler);
			this.columnno = 25;
			base.Read<float>(reader, ref rowData.FightTogetherDis, CVSReader.floatParse);
			this.columnno = 26;
			base.Read<short>(reader, ref rowData.aihit, CVSReader.shortParse);
			this.columnno = 27;
			base.Read<double>(reader, ref rowData.SuperArmorRecoveryValue, CVSReader.doubleParse);
			this.columnno = 28;
			base.Read<double>(reader, ref rowData.SuperArmorRecoveryMax, CVSReader.doubleParse);
			this.columnno = 29;
			rowData.SuperArmorBrokenBuff.Read(reader, this.m_DataHandler);
			this.columnno = 30;
			base.Read<bool>(reader, ref rowData.WeakStatus, CVSReader.boolParse);
			this.columnno = 31;
			base.Read<short>(reader, ref rowData.InitEnmity, CVSReader.shortParse);
			this.columnno = 32;
			base.Read<bool>(reader, ref rowData.AlwaysHpBar, CVSReader.boolParse);
			this.columnno = 33;
			base.Read<string>(reader, ref rowData.AiBehavior, CVSReader.stringParse);
			this.columnno = 34;
			base.Read<short>(reader, ref rowData.Fightgroup, CVSReader.shortParse);
			this.columnno = 35;
			base.Read<bool>(reader, ref rowData.SoloShow, CVSReader.boolParse);
			this.columnno = 36;
			base.Read<bool>(reader, ref rowData.UsingGeneralCutscene, CVSReader.boolParse);
			this.columnno = 37;
			base.Read<bool>(reader, ref rowData.HideName, CVSReader.boolParse);
			this.columnno = 38;
			base.Read<float>(reader, ref rowData.AttackSpeed, CVSReader.floatParse);
			this.columnno = 39;
			base.Read<float>(reader, ref rowData.ratioleft, CVSReader.floatParse);
			this.columnno = 40;
			base.Read<float>(reader, ref rowData.ratioright, CVSReader.floatParse);
			this.columnno = 41;
			base.Read<float>(reader, ref rowData.ratioidle, CVSReader.floatParse);
			this.columnno = 42;
			base.Read<float>(reader, ref rowData.ratiodistance, CVSReader.floatParse);
			this.columnno = 43;
			base.Read<float>(reader, ref rowData.ratioskill, CVSReader.floatParse);
			this.columnno = 44;
			base.Read<float>(reader, ref rowData.ratioexp, CVSReader.floatParse);
			this.columnno = 45;
			base.Read<float>(reader, ref rowData.SkillCD, CVSReader.floatParse);
			this.columnno = 46;
			base.Read<bool>(reader, ref rowData.BeLocked, CVSReader.boolParse);
			this.columnno = 47;
			rowData.navigation.Read(reader, this.m_DataHandler);
			this.columnno = 48;
			base.Read<byte>(reader, ref rowData.IsNavPingpong, CVSReader.byteParse);
			this.columnno = 49;
			base.Read<bool>(reader, ref rowData.HideInMiniMap, CVSReader.boolParse);
			this.columnno = 50;
			base.Read<byte>(reader, ref rowData.Fov, CVSReader.byteParse);
			this.columnno = 51;
			base.Read<byte>(reader, ref rowData.SummonGroup, CVSReader.byteParse);
			this.columnno = 53;
			base.Read<bool>(reader, ref rowData.SameBillBoard, CVSReader.boolParse);
			this.columnno = 54;
			base.Read<bool>(reader, ref rowData.DynamicBlock, CVSReader.boolParse);
			this.columnno = 57;
			base.ReadArray<byte>(reader, ref rowData.Tag, CVSReader.byteParse);
			this.columnno = 58;
			base.ReadArray<uint>(reader, ref rowData.HellDrop, CVSReader.uintParse);
			this.columnno = 64;
			base.Read<short>(reader, ref rowData.LinkCombo, CVSReader.shortParse);
			this.columnno = 65;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new XEntityStatistics.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public XEntityStatistics.RowData[] Table = null;

		public class RowData
		{

			public string Name;

			public uint PresentID;

			public float WalkSpeed;

			public float RunSpeed;

			public float[] FloatHeight;

			public float RotateSpeed;

			public float MaxHP;

			public float AttackProb;

			public float Sight;

			public byte Type;

			public uint ID;

			public SeqListRef<int> InBornBuff;

			public float AttackBase;

			public bool IsWander;

			public bool Block;

			public float AIStartTime;

			public float AIActionGap;

			public short FashionTemplate;

			public int MaxSuperArmor;

			public bool IsFixedInCD;

			public uint HpSection;

			public bool EndShow;

			public bool Highlight;

			public float MagicAttackBase;

			public byte UseMyMesh;

			public SeqRef<uint> ExtraReward;

			public float FightTogetherDis;

			public short aihit;

			public double SuperArmorRecoveryValue;

			public double SuperArmorRecoveryMax;

			public SeqRef<int> SuperArmorBrokenBuff;

			public bool WeakStatus;

			public short InitEnmity;

			public bool AlwaysHpBar;

			public string AiBehavior;

			public short Fightgroup;

			public bool SoloShow;

			public bool UsingGeneralCutscene;

			public bool HideName;

			public float AttackSpeed;

			public float ratioleft;

			public float ratioright;

			public float ratioidle;

			public float ratiodistance;

			public float ratioskill;

			public float ratioexp;

			public float SkillCD;

			public bool BeLocked;

			public SeqListRef<float> navigation;

			public byte IsNavPingpong;

			public bool HideInMiniMap;

			public byte Fov;

			public byte SummonGroup;

			public bool SameBillBoard;

			public bool DynamicBlock;

			public byte[] Tag;

			public uint[] HellDrop;

			public short LinkCombo;
		}
	}
}
