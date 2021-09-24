using System;

namespace XUtliPoolLib
{

	public class BuffTable : CVSReader
	{

		protected override void ReadLine(XBinaryReader reader)
		{
			BuffTable.RowData rowData = new BuffTable.RowData();
			base.Read<int>(reader, ref rowData.BuffID, CVSReader.intParse);
			this.columnno = 0;
			base.Read<byte>(reader, ref rowData.BuffLevel, CVSReader.byteParse);
			this.columnno = 1;
			base.Read<float>(reader, ref rowData.BuffDuration, CVSReader.floatParse);
			this.columnno = 2;
			rowData.BuffChangeAttribute.Read(reader, this.m_DataHandler);
			this.columnno = 3;
			base.ReadArray<byte>(reader, ref rowData.BuffState, CVSReader.byteParse);
			this.columnno = 4;
			base.Read<byte>(reader, ref rowData.BuffMergeType, CVSReader.byteParse);
			this.columnno = 5;
			base.Read<short>(reader, ref rowData.TargetType, CVSReader.shortParse);
			this.columnno = 6;
			base.Read<string>(reader, ref rowData.BuffIcon, CVSReader.stringParse);
			this.columnno = 7;
			rowData.BuffDOT.Read(reader, this.m_DataHandler);
			this.columnno = 8;
			base.Read<string>(reader, ref rowData.BuffFx, CVSReader.stringParse);
			this.columnno = 9;
			base.Read<string>(reader, ref rowData.BuffDoodadFx, CVSReader.stringParse);
			this.columnno = 10;
			base.Read<string>(reader, ref rowData.BuffName, CVSReader.stringParse);
			this.columnno = 11;
			base.Read<byte>(reader, ref rowData.BuffTriggerCond, CVSReader.byteParse);
			this.columnno = 12;
			base.Read<float>(reader, ref rowData.BuffTriggerRate, CVSReader.floatParse);
			this.columnno = 13;
			base.ReadArray<string>(reader, ref rowData.BuffTriggerParam, CVSReader.stringParse);
			this.columnno = 14;
			rowData.BuffTriggerBuff.Read(reader, this.m_DataHandler);
			this.columnno = 15;
			base.Read<float>(reader, ref rowData.CostModify, CVSReader.floatParse);
			this.columnno = 16;
			base.Read<float>(reader, ref rowData.BuffTriggerCD, CVSReader.floatParse);
			this.columnno = 18;
			rowData.AuraAddBuffID.Read(reader, this.m_DataHandler);
			this.columnno = 19;
			base.Read<bool>(reader, ref rowData.BuffIsVisible, CVSReader.boolParse);
			this.columnno = 20;
			base.Read<string>(reader, ref rowData.BuffEffectFx, CVSReader.stringParse);
			this.columnno = 21;
			base.ReadArray<float>(reader, ref rowData.AuraParams, CVSReader.floatParse);
			this.columnno = 22;
			rowData.DamageReduce.Read(reader, this.m_DataHandler);
			this.columnno = 23;
			base.Read<bool>(reader, ref rowData.DontShowText, CVSReader.boolParse);
			this.columnno = 24;
			base.ReadArray<short>(reader, ref rowData.EffectGroup, CVSReader.shortParse);
			this.columnno = 25;
			rowData.BuffDOTValueFromCaster.Read(reader, this.m_DataHandler);
			this.columnno = 26;
			rowData.ChangeDamage.Read(reader, this.m_DataHandler);
			this.columnno = 27;
			base.Read<byte>(reader, ref rowData.BuffClearType, CVSReader.byteParse);
			this.columnno = 28;
			base.ReadArray<byte>(reader, ref rowData.ClearTypes, CVSReader.byteParse);
			this.columnno = 29;
			base.Read<float>(reader, ref rowData.DamageReflection, CVSReader.floatParse);
			this.columnno = 30;
			base.Read<uint>(reader, ref rowData.MobID, CVSReader.uintParse);
			this.columnno = 31;
			rowData.BuffHP.Read(reader, this.m_DataHandler);
			this.columnno = 32;
			base.Read<byte>(reader, ref rowData.StackMaxCount, CVSReader.byteParse);
			this.columnno = 33;
			base.Read<short>(reader, ref rowData.ChangeFightGroup, CVSReader.shortParse);
			this.columnno = 34;
			base.Read<byte>(reader, ref rowData.BuffTriggerCount, CVSReader.byteParse);
			this.columnno = 35;
			rowData.LifeSteal.Read(reader, this.m_DataHandler);
			this.columnno = 36;
			rowData.ReduceSkillCD.Read(reader, this.m_DataHandler);
			this.columnno = 37;
			base.Read<int>(reader, ref rowData.StateParam, CVSReader.intParse);
			this.columnno = 38;
			base.Read<bool>(reader, ref rowData.IsGlobalTrigger, CVSReader.boolParse);
			this.columnno = 39;
			base.ReadArray<byte>(reader, ref rowData.Tags, CVSReader.byteParse);
			this.columnno = 40;
			base.Read<string>(reader, ref rowData.BuffSpriteFx, CVSReader.stringParse);
			this.columnno = 41;
			base.Read<string>(reader, ref rowData.MiniMapIcon, CVSReader.stringParse);
			this.columnno = 42;
			base.Read<string>(reader, ref rowData.BuffTriggerSkill, CVSReader.stringParse);
			this.columnno = 43;
			rowData.ChangeSkillDamage.Read(reader, this.m_DataHandler);
			this.columnno = 44;
			base.ReadArray<byte>(reader, ref rowData.SceneEffect, CVSReader.byteParse);
			this.columnno = 45;
			rowData.TargetLifeAddAttack.Read(reader, this.m_DataHandler);
			this.columnno = 46;
			rowData.AIEvent.Read(reader, this.m_DataHandler);
			this.columnno = 47;
			base.ReadArray<string>(reader, ref rowData.RelevantSkills, CVSReader.stringParse);
			this.columnno = 48;
			base.Read<bool>(reader, ref rowData.IsTriggerImm, CVSReader.boolParse);
			this.columnno = 49;
			base.ReadArray<float>(reader, ref rowData.Manipulate, CVSReader.floatParse);
			this.columnno = 50;
			rowData.SkillsReplace.Read(reader, this.m_DataHandler);
			this.columnno = 51;
			rowData.SelfLifeAddAttack.Read(reader, this.m_DataHandler);
			this.columnno = 52;
			rowData.ChangeCastDamageByDistance.Read(reader, this.m_DataHandler);
			this.columnno = 53;
			base.Read<short>(reader, ref rowData.Kill, CVSReader.shortParse);
			this.columnno = 54;
			this.Table[this.lineno] = rowData;
			this.columnno = -1;
		}

		protected override void OnClear(int lineCount)
		{
			bool flag = lineCount > 0;
			if (flag)
			{
				this.Table = new BuffTable.RowData[lineCount];
			}
			else
			{
				this.Table = null;
			}
		}

		public BuffTable.RowData[] Table = null;

		public class RowData
		{

			public int BuffID;

			public byte BuffLevel;

			public float BuffDuration;

			public SeqListRef<float> BuffChangeAttribute;

			public byte[] BuffState;

			public byte BuffMergeType;

			public short TargetType;

			public string BuffIcon;

			public SeqListRef<float> BuffDOT;

			public string BuffFx;

			public string BuffDoodadFx;

			public string BuffName;

			public byte BuffTriggerCond;

			public float BuffTriggerRate;

			public string[] BuffTriggerParam;

			public SeqListRef<int> BuffTriggerBuff;

			public float CostModify;

			public float BuffTriggerCD;

			public SeqListRef<int> AuraAddBuffID;

			public bool BuffIsVisible;

			public string BuffEffectFx;

			public float[] AuraParams;

			public SeqListRef<float> DamageReduce;

			public bool DontShowText;

			public short[] EffectGroup;

			public SeqListRef<int> BuffDOTValueFromCaster;

			public SeqRef<float> ChangeDamage;

			public byte BuffClearType;

			public byte[] ClearTypes;

			public float DamageReflection;

			public uint MobID;

			public SeqRef<float> BuffHP;

			public byte StackMaxCount;

			public short ChangeFightGroup;

			public byte BuffTriggerCount;

			public SeqRef<float> LifeSteal;

			public SeqListRef<string> ReduceSkillCD;

			public int StateParam;

			public bool IsGlobalTrigger;

			public byte[] Tags;

			public string BuffSpriteFx;

			public string MiniMapIcon;

			public string BuffTriggerSkill;

			public SeqListRef<string> ChangeSkillDamage;

			public byte[] SceneEffect;

			public SeqListRef<float> TargetLifeAddAttack;

			public SeqRef<string> AIEvent;

			public string[] RelevantSkills;

			public bool IsTriggerImm;

			public float[] Manipulate;

			public SeqListRef<string> SkillsReplace;

			public SeqListRef<float> SelfLifeAddAttack;

			public SeqListRef<float> ChangeCastDamageByDistance;

			public short Kill;
		}
	}
}
