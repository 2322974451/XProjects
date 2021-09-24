using System;

namespace XUtliPoolLib
{

	public class SkillList : CVSReader
	{

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

		public SkillList.RowData[] Table = null;

		public class RowData
		{

			public string SkillScript;

			public uint SkillScriptHash;

			public byte SkillLevel;

			public string ScriptName;

			public SeqListRef<float> PhysicalRatio;

			public SeqListRef<float> PhysicalFixed;

			public byte[] AddBuffPoint;

			public SeqListRef<int> BuffID;

			public byte HpMaxLimit;

			public byte[] LevelupCost;

			public byte[] UpReqRoleLevel;

			public string CurrentLevelDescription;

			public string NextLevelDescription;

			public string Icon;

			public SeqListRef<float> MagicRatio;

			public SeqListRef<float> MagicFixed;

			public byte Element;

			public int Profession;

			public byte SkillType;

			public int IncreaseSuperArmor;

			public short[] DecreaseSuperArmor;

			public byte IsBasicSkill;

			public SeqRef<float> CostMP;

			public SeqListRef<float> TipsRatio;

			public SeqListRef<float> TipsFixed;

			public string PreSkill;

			public byte XPostion;

			public short YPostion;

			public SeqListRef<float> StartBuffID;

			public SeqRef<int> AuraBuffID;

			public byte HpMinLimit;

			public SeqRef<float> CDRatio;

			public SeqRef<float> PvPCDRatio;

			public uint XEntityStatisticsID;

			public int PvPIncreaseSuperArmor;

			public float[] PvPDecreaseSuperArmor;

			public SeqListRef<float> PvPRatio;

			public SeqListRef<float> PvPFixed;

			public float InitCD;

			public float PvPInitCD;

			public SeqListRef<float> PvPMagicRatio;

			public SeqListRef<float> PvPMagicFixed;

			public string PreviewScript;

			public uint[] MobBuffs;

			public string Atlas;

			public short[] Flag;

			public short PreSkillPoint;

			public string SuperIndureAttack;

			public string SuperIndureDefense;

			public string ExSkillScript;

			public byte UnchangableCD;

			public float EnmityRatio;

			public int EnmityExtValue;

			public SeqListRef<float> PercentDamage;

			public string LinkedSkill;

			public byte LinkType;

			public float RemainingCDNotify;

			public int StrengthValue;

			public byte UsageCount;

			public byte[] ExclusiveMask;

			public string BindSkill;

			public bool IsAwake;
		}
	}
}
