using System;

namespace XUtliPoolLib
{

	public class XEntityPresentation : CVSReader
	{

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

		public XEntityPresentation.RowData[] Table = null;

		public class RowData
		{

			public string Prefab;

			public string A;

			public string AA;

			public string AAA;

			public string AAAA;

			public string AAAAA;

			public string Ultra;

			public string[] OtherSkills;

			public string[] Hit_f;

			public string[] HitFly;

			public string Idle;

			public string Walk;

			public string Run;

			public string Death;

			public string Appear;

			public string[] Hit_l;

			public string[] Hit_r;

			public uint PresentID;

			public string[] HitCurves;

			public string AnimLocation;

			public string SkillLocation;

			public string CurveLocation;

			public string Avatar;

			public string[] DeathCurve;

			public float[] HitBackOffsetTimeScale;

			public float[] HitFlyOffsetTimeScale;

			public float Scale;

			public string BoneSuffix;

			public string Disappear;

			public bool Shadow;

			public string Dash;

			public string Freeze;

			public float[] HitBack_Recover;

			public float[] HitFly_Bounce_GetUp;

			public float BoundRadius;

			public float BoundHeight;

			public string AttackIdle;

			public string AttackWalk;

			public string AttackRun;

			public string EnterGame;

			public string[] Hit_Roll;

			public float[] HitRollOffsetTimeScale;

			public float HitRoll_Recover;

			public bool Huge;

			public string MoveFx;

			public string FreezeFx;

			public string HitFx;

			public string DeathFx;

			public string SuperArmorRecoverySkill;

			public string Feeble;

			public string FeebleFx;

			public string ArmorBroken;

			public string RecoveryFX;

			public string RecoveryHitSlowFX;

			public string RecoveryHitStopFX;

			public string FishingIdle;

			public string FishingCast;

			public string FishingPull;

			public float[] BoundRadiusOffset;

			public SeqListRef<float> HugeMonsterColliders;

			public float UIAvatarScale;

			public float UIAvatarAngle;

			public string FishingWait;

			public string FishingWin;

			public string FishingLose;

			public string Dance;

			public string[] AvatarPos;

			public string InheritActionOne;

			public string InheritActionTwo;

			public string Kiss;

			public string RunLeft;

			public string RunRight;

			public string AttackRunLeft;

			public string AttackRunRight;

			public string Atlas;

			public int AngluarSpeed;

			public byte SkillNum;

			public string Atlas2;

			public string Avatar2;
		}
	}
}
