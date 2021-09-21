using System;

namespace XUtliPoolLib
{
	// Token: 0x02000185 RID: 389
	public class XEntityStatistics : CVSReader
	{
		// Token: 0x0600086B RID: 2155 RVA: 0x0002CEAC File Offset: 0x0002B0AC
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

		// Token: 0x0600086C RID: 2156 RVA: 0x0002CEE4 File Offset: 0x0002B0E4
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

		// Token: 0x0600086D RID: 2157 RVA: 0x0002CFC0 File Offset: 0x0002B1C0
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

		// Token: 0x0600086E RID: 2158 RVA: 0x0002D600 File Offset: 0x0002B800
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

		// Token: 0x040003D1 RID: 977
		public XEntityStatistics.RowData[] Table = null;

		// Token: 0x02000384 RID: 900
		public class RowData
		{
			// Token: 0x04000F61 RID: 3937
			public string Name;

			// Token: 0x04000F62 RID: 3938
			public uint PresentID;

			// Token: 0x04000F63 RID: 3939
			public float WalkSpeed;

			// Token: 0x04000F64 RID: 3940
			public float RunSpeed;

			// Token: 0x04000F65 RID: 3941
			public float[] FloatHeight;

			// Token: 0x04000F66 RID: 3942
			public float RotateSpeed;

			// Token: 0x04000F67 RID: 3943
			public float MaxHP;

			// Token: 0x04000F68 RID: 3944
			public float AttackProb;

			// Token: 0x04000F69 RID: 3945
			public float Sight;

			// Token: 0x04000F6A RID: 3946
			public byte Type;

			// Token: 0x04000F6B RID: 3947
			public uint ID;

			// Token: 0x04000F6C RID: 3948
			public SeqListRef<int> InBornBuff;

			// Token: 0x04000F6D RID: 3949
			public float AttackBase;

			// Token: 0x04000F6E RID: 3950
			public bool IsWander;

			// Token: 0x04000F6F RID: 3951
			public bool Block;

			// Token: 0x04000F70 RID: 3952
			public float AIStartTime;

			// Token: 0x04000F71 RID: 3953
			public float AIActionGap;

			// Token: 0x04000F72 RID: 3954
			public short FashionTemplate;

			// Token: 0x04000F73 RID: 3955
			public int MaxSuperArmor;

			// Token: 0x04000F74 RID: 3956
			public bool IsFixedInCD;

			// Token: 0x04000F75 RID: 3957
			public uint HpSection;

			// Token: 0x04000F76 RID: 3958
			public bool EndShow;

			// Token: 0x04000F77 RID: 3959
			public bool Highlight;

			// Token: 0x04000F78 RID: 3960
			public float MagicAttackBase;

			// Token: 0x04000F79 RID: 3961
			public byte UseMyMesh;

			// Token: 0x04000F7A RID: 3962
			public SeqRef<uint> ExtraReward;

			// Token: 0x04000F7B RID: 3963
			public float FightTogetherDis;

			// Token: 0x04000F7C RID: 3964
			public short aihit;

			// Token: 0x04000F7D RID: 3965
			public double SuperArmorRecoveryValue;

			// Token: 0x04000F7E RID: 3966
			public double SuperArmorRecoveryMax;

			// Token: 0x04000F7F RID: 3967
			public SeqRef<int> SuperArmorBrokenBuff;

			// Token: 0x04000F80 RID: 3968
			public bool WeakStatus;

			// Token: 0x04000F81 RID: 3969
			public short InitEnmity;

			// Token: 0x04000F82 RID: 3970
			public bool AlwaysHpBar;

			// Token: 0x04000F83 RID: 3971
			public string AiBehavior;

			// Token: 0x04000F84 RID: 3972
			public short Fightgroup;

			// Token: 0x04000F85 RID: 3973
			public bool SoloShow;

			// Token: 0x04000F86 RID: 3974
			public bool UsingGeneralCutscene;

			// Token: 0x04000F87 RID: 3975
			public bool HideName;

			// Token: 0x04000F88 RID: 3976
			public float AttackSpeed;

			// Token: 0x04000F89 RID: 3977
			public float ratioleft;

			// Token: 0x04000F8A RID: 3978
			public float ratioright;

			// Token: 0x04000F8B RID: 3979
			public float ratioidle;

			// Token: 0x04000F8C RID: 3980
			public float ratiodistance;

			// Token: 0x04000F8D RID: 3981
			public float ratioskill;

			// Token: 0x04000F8E RID: 3982
			public float ratioexp;

			// Token: 0x04000F8F RID: 3983
			public float SkillCD;

			// Token: 0x04000F90 RID: 3984
			public bool BeLocked;

			// Token: 0x04000F91 RID: 3985
			public SeqListRef<float> navigation;

			// Token: 0x04000F92 RID: 3986
			public byte IsNavPingpong;

			// Token: 0x04000F93 RID: 3987
			public bool HideInMiniMap;

			// Token: 0x04000F94 RID: 3988
			public byte Fov;

			// Token: 0x04000F95 RID: 3989
			public byte SummonGroup;

			// Token: 0x04000F96 RID: 3990
			public bool SameBillBoard;

			// Token: 0x04000F97 RID: 3991
			public bool DynamicBlock;

			// Token: 0x04000F98 RID: 3992
			public byte[] Tag;

			// Token: 0x04000F99 RID: 3993
			public uint[] HellDrop;

			// Token: 0x04000F9A RID: 3994
			public short LinkCombo;
		}
	}
}
