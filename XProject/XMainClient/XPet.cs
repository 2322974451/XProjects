using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPet
	{

		public bool Canpairride { get; set; }

		public List<XPet.Skill> SkillList
		{
			get
			{
				return this.m_SkillList;
			}
		}

		public List<XPet.Skill> ShowSkillList
		{
			get
			{
				return this.m_ShowSkillList;
			}
		}

		public XPet.Skill ActiveSkill
		{
			get
			{
				return this.m_ActiveSkill;
			}
		}

		public XPet.Skill FindSkill(uint id)
		{
			for (int i = 0; i < this.m_SkillList.Count; i++)
			{
				bool flag = this.m_SkillList[i].id == id;
				if (flag)
				{
					return this.m_SkillList[i];
				}
			}
			return null;
		}

		public void Init(PetSingle data, PetChange change = PetChange.None)
		{
			this.UID = data.uid;
			this.ID = data.petid;
			this.Level = (int)data.level;
			this.Exp = (int)data.exp;
			this.Sex = (PetSex)data.sex;
			this.PPT = data.power;
			this.FullDegree = data.hungry;
			this.Mood = data.mood;
			this.HistoryLevelMAX = (int)data.max_level;
			this.Canpairride = data.canpairride;
			PetInfoTable.RowData petInfo = XPetDocument.GetPetInfo(this.ID);
			bool flag = petInfo != null;
			if (flag)
			{
				this.Name = petInfo.name;
			}
			this.m_SkillList.Clear();
			bool flag2 = data.fixedskills != null;
			if (flag2)
			{
				int num = 0;
				while ((long)num < (long)((ulong)XPet.FIX_SKILL_COUNT_MAX))
				{
					XPet.Skill skill = new XPet.Skill();
					bool flag3 = num < data.fixedskills.Count;
					if (flag3)
					{
						skill.Init(data.fixedskills[num], true);
					}
					else
					{
						PetInfoTable.RowData petInfo2 = XPetDocument.GetPetInfo(this.ID);
						bool flag4 = petInfo2 == null;
						if (flag4)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("PetId:" + this.ID + " No Find", null, null, null, null, null);
						}
						skill.Init(XPetDocument.GetFixSkill(this.ID, num + 1), false);
					}
					this.m_SkillList.Add(skill);
					num++;
				}
			}
			bool flag5 = data.randskills != null;
			if (flag5)
			{
				for (int i = 0; i < data.randskills.Count; i++)
				{
					bool flag6 = (long)i >= (long)((ulong)(XPetSkillHandler.SKILL_MAX - XPet.FIX_SKILL_COUNT_MAX));
					if (flag6)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Random Skill List Count is" + data.randskills.Count, null, null, null, null, null);
						break;
					}
					XPet.Skill skill2 = new XPet.Skill();
					skill2.Init(data.randskills[i], true);
					this.m_SkillList.Add(skill2);
				}
			}
			bool flag7 = change > PetChange.None;
			if (flag7)
			{
				XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
				bool flag8 = change == PetChange.All || change == PetChange.Exp;
				if (flag8)
				{
					bool flag9 = this.showExp != this.Exp || this.showLevel != this.Level;
					if (flag9)
					{
						bool flag10 = this.showLevel != 0 && !specificDocument.IsMaxLevel(this.ID, this.showLevel);
						if (flag10)
						{
							specificDocument.ChangeExp = true;
						}
					}
				}
				bool flag11 = change == PetChange.All || change == PetChange.ExpTransfer;
				if (flag11)
				{
					bool flag12 = this.showFullDegree != this.FullDegree;
					if (flag12)
					{
						bool flag13 = this.showFullDegree < this.FullDegree;
						if (flag13)
						{
							specificDocument.ChangeFullDegree = true;
						}
						else
						{
							this.showFullDegree = this.FullDegree;
						}
					}
				}
				bool flag14 = change == PetChange.ExpTransfer;
				if (flag14)
				{
				}
			}
			else
			{
				this.showExp = this.Exp;
				this.showLevel = this.Level;
				this.showFullDegree = this.FullDegree;
				this.m_ShowSkillList.Clear();
				for (int j = 0; j < this.m_SkillList.Count; j++)
				{
					this.m_ShowSkillList.Add(this.m_SkillList[j]);
				}
			}
		}

		public void Refresh()
		{
			this.showExp = this.Exp;
			this.showLevel = this.Level;
			this.showFullDegree = this.FullDegree;
			this.m_ShowSkillList.Clear();
			for (int i = 0; i < this.m_SkillList.Count; i++)
			{
				this.m_ShowSkillList.Add(this.m_SkillList[i]);
			}
		}

		public static readonly uint FIX_SKILL_COUNT_MAX = 3U;

		public ulong UID;

		public uint ID;

		public int Level;

		public string Name;

		public PetSex Sex;

		public uint PPT;

		public int Exp;

		public uint FullDegree;

		public uint Mood;

		public int HistoryLevelMAX;

		public int showExp;

		public int showLevel;

		public uint showFullDegree;

		private List<XPet.Skill> m_SkillList = new List<XPet.Skill>();

		private List<XPet.Skill> m_ShowSkillList = new List<XPet.Skill>();

		private XPet.Skill m_ActiveSkill = new XPet.Skill();

		public class Skill
		{

			public void Init(uint Id, bool IsOpen = true)
			{
				this.id = Id;
				this.open = IsOpen;
			}

			public uint id;

			public bool open;
		}
	}
}
