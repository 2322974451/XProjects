using System;

namespace XUtliPoolLib
{
	// Token: 0x02000184 RID: 388
	public class XEntityPresentation : CVSReader
	{
		// Token: 0x06000866 RID: 2150 RVA: 0x0002C4E0 File Offset: 0x0002A6E0
		public XEntityPresentation.RowData GetByPresentID(uint key)
		{
			bool flag = this.Table == null || this.Table.Length == 0;
			XEntityPresentation.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.BinarySearchPresentID(key);
			}
			return result;
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x0002C518 File Offset: 0x0002A718
		private XEntityPresentation.RowData BinarySearchPresentID(uint key)
		{
			int num = 0;
			int num2 = this.Table.Length - 1;
			XEntityPresentation.RowData rowData;
			XEntityPresentation.RowData rowData2;
			XEntityPresentation.RowData rowData3;
			for (;;)
			{
				rowData = this.Table[num];
				bool flag = rowData.PresentID == key;
				if (flag)
				{
					break;
				}
				rowData2 = this.Table[num2];
				bool flag2 = rowData2.PresentID == key;
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
				bool flag4 = rowData3.PresentID.CompareTo(key) > 0;
				if (flag4)
				{
					num2 = num3;
				}
				else
				{
					bool flag5 = rowData3.PresentID.CompareTo(key) < 0;
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

		// Token: 0x06000868 RID: 2152 RVA: 0x0002C5F4 File Offset: 0x0002A7F4
		protected override void ReadLine(XBinaryReader reader)
		{
			XEntityPresentation.RowData rowData = new XEntityPresentation.RowData();
			base.Read<string>(reader, ref rowData.Prefab, CVSReader.stringParse);
			this.columnno = 0;
			base.Read<string>(reader, ref rowData.A, CVSReader.stringParse);
			this.columnno = 1;
			base.Read<string>(reader, ref rowData.AA, CVSReader.stringParse);
			this.columnno = 2;
			base.Read<string>(reader, ref rowData.AAA, CVSReader.stringParse);
			this.columnno = 3;
			base.Read<string>(reader, ref rowData.AAAA, CVSReader.stringParse);
			this.columnno = 4;
			base.Read<string>(reader, ref rowData.AAAAA, CVSReader.stringParse);
			this.columnno = 5;
			base.Read<string>(reader, ref rowData.Ultra, CVSReader.stringParse);
			this.columnno = 6;
			base.ReadArray<string>(reader, ref rowData.OtherSkills, CVSReader.stringParse);
			this.columnno = 7;
			base.ReadArray<string>(reader, ref rowData.Hit_f, CVSReader.stringParse);
			this.columnno = 8;
			base.ReadArray<string>(reader, ref rowData.HitFly, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.Idle, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.Walk, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<string>(reader, ref rowData.Run, CVSReader.stringParse);
			this.columnno = 12;
			base.Read<string>(reader, ref rowData.Death, CVSReader.stringParse);
			this.columnno = 13;
			base.Read<string>(reader, ref rowData.Appear, CVSReader.stringParse);
			this.columnno = 14;
			base.ReadArray<string>(reader, ref rowData.Hit_l, CVSReader.stringParse);
			this.columnno = 15;
			base.ReadArray<string>(reader, ref rowData.Hit_r, CVSReader.stringParse);
			this.columnno = 16;
			base.Read<uint>(reader, ref rowData.PresentID, CVSReader.uintParse);
			this.columnno = 17;
			base.ReadArray<string>(reader, ref rowData.HitCurves, CVSReader.stringParse);
			this.columnno = 18;
			base.Read<string>(reader, ref rowData.AnimLocation, CVSReader.stringParse);
			this.columnno = 19;
			base.Read<string>(reader, ref rowData.SkillLocation, CVSReader.stringParse);
			this.columnno = 20;
			base.Read<string>(reader, ref rowData.CurveLocation, CVSReader.stringParse);
			this.columnno = 21;
			base.Read<string>(reader, ref rowData.Avatar, CVSReader.stringParse);
			this.columnno = 22;
			base.ReadArray<string>(reader, ref rowData.DeathCurve, CVSReader.stringParse);
			this.columnno = 23;
			base.ReadArray<float>(reader, ref rowData.HitBackOffsetTimeScale, CVSReader.floatParse);
			this.columnno = 24;
			base.ReadArray<float>(reader, ref rowData.HitFlyOffsetTimeScale, CVSReader.floatParse);
			this.columnno = 25;
			base.Read<float>(reader, ref rowData.Scale, CVSReader.floatParse);
			this.columnno = 26;
			base.Read<string>(reader, ref rowData.BoneSuffix, CVSReader.stringParse);
			this.columnno = 27;
			base.Read<string>(reader, ref rowData.Disappear, CVSReader.stringParse);
			this.columnno = 28;
			base.Read<bool>(reader, ref rowData.Shadow, CVSReader.boolParse);
			this.columnno = 29;
			base.Read<string>(reader, ref rowData.Dash, CVSReader.stringParse);
			this.columnno = 30;
			base.Read<string>(reader, ref rowData.Freeze, CVSReader.stringParse);
			this.columnno = 31;
			base.ReadArray<float>(reader, ref rowData.HitBack_Recover, CVSReader.floatParse);
			this.columnno = 32;
			base.ReadArray<float>(reader, ref rowData.HitFly_Bounce_GetUp, CVSReader.floatParse);
			this.columnno = 33;
			base.Read<float>(reader, ref rowData.BoundRadius, CVSReader.floatParse);
			this.columnno = 34;
			base.Read<float>(reader, ref rowData.BoundHeight, CVSReader.floatParse);
			this.columnno = 35;
			base.Read<string>(reader, ref rowData.AttackIdle, CVSReader.stringParse);
			this.columnno = 36;
			base.Read<string>(reader, ref rowData.AttackWalk, CVSReader.stringParse);
			this.columnno = 37;
			base.Read<string>(reader, ref rowData.AttackRun, CVSReader.stringParse);
			this.columnno = 38;
			base.Read<string>(reader, ref rowData.EnterGame, CVSReader.stringParse);
			this.columnno = 39;
			base.ReadArray<string>(reader, ref rowData.Hit_Roll, CVSReader.stringParse);
			this.columnno = 40;
			base.ReadArray<float>(reader, ref rowData.HitRollOffsetTimeScale, CVSReader.floatParse);
			this.columnno = 41;
			base.Read<float>(reader, ref rowData.HitRoll_Recover, CVSReader.floatParse);
			this.columnno = 42;
			base.Read<bool>(reader, ref rowData.Huge, CVSReader.boolParse);
			this.columnno = 43;
			base.Read<string>(reader, ref rowData.MoveFx, CVSReader.stringParse);
			this.columnno = 44;
			base.Read<string>(reader, ref rowData.FreezeFx, CVSReader.stringParse);
			this.columnno = 45;
			base.Read<string>(reader, ref rowData.HitFx, CVSReader.stringParse);
			this.columnno = 46;
			base.Read<string>(reader, ref rowData.DeathFx, CVSReader.stringParse);
			this.columnno = 47;
			base.Read<string>(reader, ref rowData.SuperArmorRecoverySkill, CVSReader.stringParse);
			this.columnno = 48;
			base.Read<string>(reader, ref rowData.Feeble, CVSReader.stringParse);
			this.columnno = 49;
			base.Read<string>(reader, ref rowData.FeebleFx, CVSReader.stringParse);
			this.columnno = 50;
			base.Read<string>(reader, ref rowData.ArmorBroken, CVSReader.stringParse);
			this.columnno = 51;
			base.Read<string>(reader, ref rowData.RecoveryFX, CVSReader.stringParse);
			this.columnno = 52;
			base.Read<string>(reader, ref rowData.RecoveryHitSlowFX, CVSReader.stringParse);
			this.columnno = 53;
			base.Read<string>(reader, ref rowData.RecoveryHitStopFX, CVSReader.stringParse);
			this.columnno = 54;
			base.Read<string>(reader, ref rowData.FishingIdle, CVSReader.stringParse);
			this.columnno = 55;
			base.Read<string>(reader, ref rowData.FishingCast, CVSReader.stringParse);
			this.columnno = 56;
			base.Read<string>(reader, ref rowData.FishingPull, CVSReader.stringParse);
			this.columnno = 57;
			base.ReadArray<float>(reader, ref rowData.BoundRadiusOffset, CVSReader.floatParse);
			this.columnno = 58;
			rowData.HugeMonsterColliders.Read(reader, this.m_DataHandler);
			this.columnno = 59;
			base.Read<float>(reader, ref rowData.UIAvatarScale, CVSReader.floatParse);
			this.columnno = 60;
			base.Read<float>(reader, ref rowData.UIAvatarAngle, CVSReader.floatParse);
			this.columnno = 61;
			base.Read<string>(reader, ref rowData.FishingWait, CVSReader.stringParse);
			this.columnno = 62;
			base.Read<string>(reader, ref rowData.FishingWin, CVSReader.stringParse);
			this.columnno = 63;
			base.Read<string>(reader, ref rowData.FishingLose, CVSReader.stringParse);
			this.columnno = 64;
			base.Read<string>(reader, ref rowData.Dance, CVSReader.stringParse);
			this.columnno = 65;
			base.ReadArray<string>(reader, ref rowData.AvatarPos, CVSReader.stringParse);
			this.columnno = 66;
			base.Read<string>(reader, ref rowData.InheritActionOne, CVSReader.stringParse);
			this.columnno = 67;
			base.Read<string>(reader, ref rowData.InheritActionTwo, CVSReader.stringParse);
			this.columnno = 68;
			base.Read<string>(reader, ref rowData.Kiss, CVSReader.stringParse);
			this.columnno = 69;
			base.Read<string>(reader, ref rowData.RunLeft, CVSReader.stringParse);
			this.columnno = 70;
			base.Read<string>(reader, ref rowData.RunRight, CVSReader.stringParse);
			this.columnno = 71;
			base.Read<string>(reader, ref rowData.AttackRunLeft, CVSReader.stringParse);
			this.columnno = 72;
			base.Read<string>(reader, ref rowData.AttackRunRight, CVSReader.stringParse);
			this.columnno = 73;
			base.Read<string>(reader, ref rowData.Atlas, CVSReader.stringParse);
			this.columnno = 74;
			base.Read<int>(reader, ref rowData.AngluarSpeed, CVSReader.intParse);
			this.columnno = 75;
			base.Read<byte>(reader, ref rowData.SkillNum, CVSReader.byteParse);
			this.columnno = 76;
			base.Read<string>(reader, ref rowData.Atlas2, CVSReader.stringParse);
			this.columnno = 77;
			base.Read<string>(reader, ref rowData.Avatar2, CVSReader.stringParse);
			this.columnno = 78;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x0002CE6C File Offset: 0x0002B06C
		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new XEntityPresentation.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		// Token: 0x040003D0 RID: 976
		public XEntityPresentation.RowData[] Table = null;

		// Token: 0x02000383 RID: 899
		public class RowData
		{
			// Token: 0x04000F12 RID: 3858
			public string Prefab;

			// Token: 0x04000F13 RID: 3859
			public string A;

			// Token: 0x04000F14 RID: 3860
			public string AA;

			// Token: 0x04000F15 RID: 3861
			public string AAA;

			// Token: 0x04000F16 RID: 3862
			public string AAAA;

			// Token: 0x04000F17 RID: 3863
			public string AAAAA;

			// Token: 0x04000F18 RID: 3864
			public string Ultra;

			// Token: 0x04000F19 RID: 3865
			public string[] OtherSkills;

			// Token: 0x04000F1A RID: 3866
			public string[] Hit_f;

			// Token: 0x04000F1B RID: 3867
			public string[] HitFly;

			// Token: 0x04000F1C RID: 3868
			public string Idle;

			// Token: 0x04000F1D RID: 3869
			public string Walk;

			// Token: 0x04000F1E RID: 3870
			public string Run;

			// Token: 0x04000F1F RID: 3871
			public string Death;

			// Token: 0x04000F20 RID: 3872
			public string Appear;

			// Token: 0x04000F21 RID: 3873
			public string[] Hit_l;

			// Token: 0x04000F22 RID: 3874
			public string[] Hit_r;

			// Token: 0x04000F23 RID: 3875
			public uint PresentID;

			// Token: 0x04000F24 RID: 3876
			public string[] HitCurves;

			// Token: 0x04000F25 RID: 3877
			public string AnimLocation;

			// Token: 0x04000F26 RID: 3878
			public string SkillLocation;

			// Token: 0x04000F27 RID: 3879
			public string CurveLocation;

			// Token: 0x04000F28 RID: 3880
			public string Avatar;

			// Token: 0x04000F29 RID: 3881
			public string[] DeathCurve;

			// Token: 0x04000F2A RID: 3882
			public float[] HitBackOffsetTimeScale;

			// Token: 0x04000F2B RID: 3883
			public float[] HitFlyOffsetTimeScale;

			// Token: 0x04000F2C RID: 3884
			public float Scale;

			// Token: 0x04000F2D RID: 3885
			public string BoneSuffix;

			// Token: 0x04000F2E RID: 3886
			public string Disappear;

			// Token: 0x04000F2F RID: 3887
			public bool Shadow;

			// Token: 0x04000F30 RID: 3888
			public string Dash;

			// Token: 0x04000F31 RID: 3889
			public string Freeze;

			// Token: 0x04000F32 RID: 3890
			public float[] HitBack_Recover;

			// Token: 0x04000F33 RID: 3891
			public float[] HitFly_Bounce_GetUp;

			// Token: 0x04000F34 RID: 3892
			public float BoundRadius;

			// Token: 0x04000F35 RID: 3893
			public float BoundHeight;

			// Token: 0x04000F36 RID: 3894
			public string AttackIdle;

			// Token: 0x04000F37 RID: 3895
			public string AttackWalk;

			// Token: 0x04000F38 RID: 3896
			public string AttackRun;

			// Token: 0x04000F39 RID: 3897
			public string EnterGame;

			// Token: 0x04000F3A RID: 3898
			public string[] Hit_Roll;

			// Token: 0x04000F3B RID: 3899
			public float[] HitRollOffsetTimeScale;

			// Token: 0x04000F3C RID: 3900
			public float HitRoll_Recover;

			// Token: 0x04000F3D RID: 3901
			public bool Huge;

			// Token: 0x04000F3E RID: 3902
			public string MoveFx;

			// Token: 0x04000F3F RID: 3903
			public string FreezeFx;

			// Token: 0x04000F40 RID: 3904
			public string HitFx;

			// Token: 0x04000F41 RID: 3905
			public string DeathFx;

			// Token: 0x04000F42 RID: 3906
			public string SuperArmorRecoverySkill;

			// Token: 0x04000F43 RID: 3907
			public string Feeble;

			// Token: 0x04000F44 RID: 3908
			public string FeebleFx;

			// Token: 0x04000F45 RID: 3909
			public string ArmorBroken;

			// Token: 0x04000F46 RID: 3910
			public string RecoveryFX;

			// Token: 0x04000F47 RID: 3911
			public string RecoveryHitSlowFX;

			// Token: 0x04000F48 RID: 3912
			public string RecoveryHitStopFX;

			// Token: 0x04000F49 RID: 3913
			public string FishingIdle;

			// Token: 0x04000F4A RID: 3914
			public string FishingCast;

			// Token: 0x04000F4B RID: 3915
			public string FishingPull;

			// Token: 0x04000F4C RID: 3916
			public float[] BoundRadiusOffset;

			// Token: 0x04000F4D RID: 3917
			public SeqListRef<float> HugeMonsterColliders;

			// Token: 0x04000F4E RID: 3918
			public float UIAvatarScale;

			// Token: 0x04000F4F RID: 3919
			public float UIAvatarAngle;

			// Token: 0x04000F50 RID: 3920
			public string FishingWait;

			// Token: 0x04000F51 RID: 3921
			public string FishingWin;

			// Token: 0x04000F52 RID: 3922
			public string FishingLose;

			// Token: 0x04000F53 RID: 3923
			public string Dance;

			// Token: 0x04000F54 RID: 3924
			public string[] AvatarPos;

			// Token: 0x04000F55 RID: 3925
			public string InheritActionOne;

			// Token: 0x04000F56 RID: 3926
			public string InheritActionTwo;

			// Token: 0x04000F57 RID: 3927
			public string Kiss;

			// Token: 0x04000F58 RID: 3928
			public string RunLeft;

			// Token: 0x04000F59 RID: 3929
			public string RunRight;

			// Token: 0x04000F5A RID: 3930
			public string AttackRunLeft;

			// Token: 0x04000F5B RID: 3931
			public string AttackRunRight;

			// Token: 0x04000F5C RID: 3932
			public string Atlas;

			// Token: 0x04000F5D RID: 3933
			public int AngluarSpeed;

			// Token: 0x04000F5E RID: 3934
			public byte SkillNum;

			// Token: 0x04000F5F RID: 3935
			public string Atlas2;

			// Token: 0x04000F60 RID: 3936
			public string Avatar2;
		}
	}
}
