using System;

namespace XUtliPoolLib
{
	// Token: 0x0200016C RID: 364
	public class SkillList : CVSReader
	{
		// Token: 0x0600080D RID: 2061 RVA: 0x000299A8 File Offset: 0x00027BA8
		protected override void ReadLine(XBinaryReader reader)
		{
			SkillList.RowData rowData = new SkillList.RowData();
			base.Read<string>(reader, ref rowData.SkillScript, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<uint>(reader, ref rowData.SkillScriptHash, CVSReader.uintParse);
			this.columnno = 0;
			base.Read<byte>(reader, ref rowData.SkillLevel, CVSReader.byteParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.ScriptName, CVSReader.stringParse);
			this.columnno = 2;
			rowData.PhysicalRatio.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			rowData.PhysicalFixed.Read(reader, this.m_DataHandler);
			this.columnno = 4;
			base.ReadArray<byte>(reader, ref rowData.AddBuffPoint, CVSReader.byteParse);
			this.columnno = 6;
			rowData.BuffID.Read(reader, this.m_DataHandler);
			this.columnno = 7;
			base.Read<byte>(reader, ref rowData.HpMaxLimit, CVSReader.byteParse);
			this.columnno = 8;
			base.ReadArray<byte>(reader, ref rowData.LevelupCost, CVSReader.byteParse);
			this.columnno = 10;
			base.ReadArray<byte>(reader, ref rowData.UpReqRoleLevel, CVSReader.byteParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.CurrentLevelDescription, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.NextLevelDescription, CVSReader.stringParse);
			this.columnno = 13;
			base.Read<string>(reader, ref rowData.Icon, CVSReader.stringParse);
			this.columnno = 14;
			rowData.MagicRatio.Read(reader, this.m_DataHandler);
			this.columnno = 15;
			rowData.MagicFixed.Read(reader, this.m_DataHandler);
			this.columnno = 16;
			base.Read<byte>(reader, ref rowData.Element, CVSReader.byteParse);
			this.columnno = 17;
			base.Read<int>(reader, ref rowData.Profession, CVSReader.intParse);
			this.columnno = 18;
			base.Read<byte>(reader, ref rowData.SkillType, CVSReader.byteParse);
			this.columnno = 19;
			base.Read<int>(reader, ref rowData.IncreaseSuperArmor, CVSReader.intParse);
			this.columnno = 20;
			base.ReadArray<short>(reader, ref rowData.DecreaseSuperArmor, CVSReader.shortParse);
			this.columnno = 21;
			base.Read<byte>(reader, ref rowData.IsBasicSkill, CVSReader.byteParse);
			this.columnno = 22;
			rowData.CostMP.Read(reader, this.m_DataHandler);
			this.columnno = 23;
			rowData.TipsRatio.Read(reader, this.m_DataHandler);
			this.columnno = 24;
			rowData.TipsFixed.Read(reader, this.m_DataHandler);
			this.columnno = 25;
			base.Read<string>(reader, ref rowData.PreSkill, CVSReader.stringParse);
			this.columnno = 26;
			base.Read<byte>(reader, ref rowData.XPostion, CVSReader.byteParse);
			this.columnno = 27;
			base.Read<short>(reader, ref rowData.YPostion, CVSReader.shortParse);
			this.columnno = 28;
			rowData.StartBuffID.Read(reader, this.m_DataHandler);
			this.columnno = 29;
			rowData.AuraBuffID.Read(reader, this.m_DataHandler);
			this.columnno = 33;
			base.Read<byte>(reader, ref rowData.HpMinLimit, CVSReader.byteParse);
			this.columnno = 34;
			rowData.CDRatio.Read(reader, this.m_DataHandler);
			this.columnno = 35;
			rowData.PvPCDRatio.Read(reader, this.m_DataHandler);
			this.columnno = 36;
			base.Read<uint>(reader, ref rowData.XEntityStatisticsID, CVSReader.uintParse);
			this.columnno = 39;
			base.Read<int>(reader, ref rowData.PvPIncreaseSuperArmor, CVSReader.intParse);
			this.columnno = 40;
			base.ReadArray<float>(reader, ref rowData.PvPDecreaseSuperArmor, CVSReader.floatParse);
			this.columnno = 41;
			rowData.PvPRatio.Read(reader, this.m_DataHandler);
			this.columnno = 42;
			rowData.PvPFixed.Read(reader, this.m_DataHandler);
			this.columnno = 43;
			base.Read<float>(reader, ref rowData.InitCD, CVSReader.floatParse);
			this.columnno = 45;
			base.Read<float>(reader, ref rowData.PvPInitCD, CVSReader.floatParse);
			this.columnno = 46;
			rowData.PvPMagicRatio.Read(reader, this.m_DataHandler);
			this.columnno = 48;
			rowData.PvPMagicFixed.Read(reader, this.m_DataHandler);
			this.columnno = 49;
			base.Read<string>(reader, ref rowData.PreviewScript, CVSReader.stringParse);
			this.columnno = 50;
			base.ReadArray<uint>(reader, ref rowData.MobBuffs, CVSReader.uintParse);
			this.columnno = 51;
			base.Read<string>(reader, ref rowData.Atlas, CVSReader.stringParse);
			this.columnno = 52;
			base.ReadArray<short>(reader, ref rowData.Flag, CVSReader.shortParse);
			this.columnno = 53;
			base.Read<short>(reader, ref rowData.PreSkillPoint, CVSReader.shortParse);
			this.columnno = 54;
			base.Read<string>(reader, ref rowData.SuperIndureAttack, CVSReader.stringParse);
			this.columnno = 55;
			base.Read<string>(reader, ref rowData.SuperIndureDefense, CVSReader.stringParse);
			this.columnno = 56;
			base.Read<string>(reader, ref rowData.ExSkillScript, CVSReader.stringParse);
			this.columnno = 57;
			base.Read<byte>(reader, ref rowData.UnchangableCD, CVSReader.byteParse);
			this.columnno = 58;
			base.Read<float>(reader, ref rowData.EnmityRatio, CVSReader.floatParse);
			this.columnno = 59;
			base.Read<int>(reader, ref rowData.EnmityExtValue, CVSReader.intParse);
			this.columnno = 60;
			rowData.PercentDamage.Read(reader, this.m_DataHandler);
			this.columnno = 61;
			base.Read<string>(reader, ref rowData.LinkedSkill, CVSReader.stringParse);
			this.columnno = 62;
			base.Read<byte>(reader, ref rowData.LinkType, CVSReader.byteParse);
			this.columnno = 63;
			base.Read<float>(reader, ref rowData.RemainingCDNotify, CVSReader.floatParse);
			this.columnno = 64;
			base.Read<int>(reader, ref rowData.StrengthValue, CVSReader.intParse);
			this.columnno = 65;
			base.Read<byte>(reader, ref rowData.UsageCount, CVSReader.byteParse);
			this.columnno = 66;
			base.ReadArray<byte>(reader, ref rowData.ExclusiveMask, CVSReader.byteParse);
			this.columnno = 67;
			base.Read<string>(reader, ref rowData.BindSkill, CVSReader.stringParse);
			this.columnno = 69;
			base.Read<bool>(reader, ref rowData.IsAwake, CVSReader.boolParse);
			this.columnno = 70;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x0002A054 File Offset: 0x00028254
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new SkillList.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003B8 RID: 952
		public SkillList.RowData[] Table = null;

		// Token: 0x0200036B RID: 875
		public class RowData
		{
			// Token: 0x04000E1E RID: 3614
			public string SkillScript;

			// Token: 0x04000E1F RID: 3615
			public uint SkillScriptHash;

			// Token: 0x04000E20 RID: 3616
			public byte SkillLevel;

			// Token: 0x04000E21 RID: 3617
			public string ScriptName;

			// Token: 0x04000E22 RID: 3618
			public SeqListRef<float> PhysicalRatio;

			// Token: 0x04000E23 RID: 3619
			public SeqListRef<float> PhysicalFixed;

			// Token: 0x04000E24 RID: 3620
			public byte[] AddBuffPoint;

			// Token: 0x04000E25 RID: 3621
			public SeqListRef<int> BuffID;

			// Token: 0x04000E26 RID: 3622
			public byte HpMaxLimit;

			// Token: 0x04000E27 RID: 3623
			public byte[] LevelupCost;

			// Token: 0x04000E28 RID: 3624
			public byte[] UpReqRoleLevel;

			// Token: 0x04000E29 RID: 3625
			public string CurrentLevelDescription;

			// Token: 0x04000E2A RID: 3626
			public string NextLevelDescription;

			// Token: 0x04000E2B RID: 3627
			public string Icon;

			// Token: 0x04000E2C RID: 3628
			public SeqListRef<float> MagicRatio;

			// Token: 0x04000E2D RID: 3629
			public SeqListRef<float> MagicFixed;

			// Token: 0x04000E2E RID: 3630
			public byte Element;

			// Token: 0x04000E2F RID: 3631
			public int Profession;

			// Token: 0x04000E30 RID: 3632
			public byte SkillType;

			// Token: 0x04000E31 RID: 3633
			public int IncreaseSuperArmor;

			// Token: 0x04000E32 RID: 3634
			public short[] DecreaseSuperArmor;

			// Token: 0x04000E33 RID: 3635
			public byte IsBasicSkill;

			// Token: 0x04000E34 RID: 3636
			public SeqRef<float> CostMP;

			// Token: 0x04000E35 RID: 3637
			public SeqListRef<float> TipsRatio;

			// Token: 0x04000E36 RID: 3638
			public SeqListRef<float> TipsFixed;

			// Token: 0x04000E37 RID: 3639
			public string PreSkill;

			// Token: 0x04000E38 RID: 3640
			public byte XPostion;

			// Token: 0x04000E39 RID: 3641
			public short YPostion;

			// Token: 0x04000E3A RID: 3642
			public SeqListRef<float> StartBuffID;

			// Token: 0x04000E3B RID: 3643
			public SeqRef<int> AuraBuffID;

			// Token: 0x04000E3C RID: 3644
			public byte HpMinLimit;

			// Token: 0x04000E3D RID: 3645
			public SeqRef<float> CDRatio;

			// Token: 0x04000E3E RID: 3646
			public SeqRef<float> PvPCDRatio;

			// Token: 0x04000E3F RID: 3647
			public uint XEntityStatisticsID;

			// Token: 0x04000E40 RID: 3648
			public int PvPIncreaseSuperArmor;

			// Token: 0x04000E41 RID: 3649
			public float[] PvPDecreaseSuperArmor;

			// Token: 0x04000E42 RID: 3650
			public SeqListRef<float> PvPRatio;

			// Token: 0x04000E43 RID: 3651
			public SeqListRef<float> PvPFixed;

			// Token: 0x04000E44 RID: 3652
			public float InitCD;

			// Token: 0x04000E45 RID: 3653
			public float PvPInitCD;

			// Token: 0x04000E46 RID: 3654
			public SeqListRef<float> PvPMagicRatio;

			// Token: 0x04000E47 RID: 3655
			public SeqListRef<float> PvPMagicFixed;

			// Token: 0x04000E48 RID: 3656
			public string PreviewScript;

			// Token: 0x04000E49 RID: 3657
			public uint[] MobBuffs;

			// Token: 0x04000E4A RID: 3658
			public string Atlas;

			// Token: 0x04000E4B RID: 3659
			public short[] Flag;

			// Token: 0x04000E4C RID: 3660
			public short PreSkillPoint;

			// Token: 0x04000E4D RID: 3661
			public string SuperIndureAttack;

			// Token: 0x04000E4E RID: 3662
			public string SuperIndureDefense;

			// Token: 0x04000E4F RID: 3663
			public string ExSkillScript;

			// Token: 0x04000E50 RID: 3664
			public byte UnchangableCD;

			// Token: 0x04000E51 RID: 3665
			public float EnmityRatio;

			// Token: 0x04000E52 RID: 3666
			public int EnmityExtValue;

			// Token: 0x04000E53 RID: 3667
			public SeqListRef<float> PercentDamage;

			// Token: 0x04000E54 RID: 3668
			public string LinkedSkill;

			// Token: 0x04000E55 RID: 3669
			public byte LinkType;

			// Token: 0x04000E56 RID: 3670
			public float RemainingCDNotify;

			// Token: 0x04000E57 RID: 3671
			public int StrengthValue;

			// Token: 0x04000E58 RID: 3672
			public byte UsageCount;

			// Token: 0x04000E59 RID: 3673
			public byte[] ExclusiveMask;

			// Token: 0x04000E5A RID: 3674
			public string BindSkill;

			// Token: 0x04000E5B RID: 3675
			public bool IsAwake;
		}
	}
}
