using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009A2 RID: 2466
	internal class XPet
	{
		// Token: 0x17002CED RID: 11501
		// (get) Token: 0x06009481 RID: 38017 RVA: 0x0015EFA1 File Offset: 0x0015D1A1
		// (set) Token: 0x06009482 RID: 38018 RVA: 0x0015EFA9 File Offset: 0x0015D1A9
		public bool Canpairride { get; set; }

		// Token: 0x17002CEE RID: 11502
		// (get) Token: 0x06009483 RID: 38019 RVA: 0x0015EFB4 File Offset: 0x0015D1B4
		public List<XPet.Skill> SkillList
		{
			get
			{
				return this.m_SkillList;
			}
		}

		// Token: 0x17002CEF RID: 11503
		// (get) Token: 0x06009484 RID: 38020 RVA: 0x0015EFCC File Offset: 0x0015D1CC
		public List<XPet.Skill> ShowSkillList
		{
			get
			{
				return this.m_ShowSkillList;
			}
		}

		// Token: 0x17002CF0 RID: 11504
		// (get) Token: 0x06009485 RID: 38021 RVA: 0x0015EFE4 File Offset: 0x0015D1E4
		public XPet.Skill ActiveSkill
		{
			get
			{
				return this.m_ActiveSkill;
			}
		}

		// Token: 0x06009486 RID: 38022 RVA: 0x0015EFFC File Offset: 0x0015D1FC
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

		// Token: 0x06009487 RID: 38023 RVA: 0x0015F054 File Offset: 0x0015D254
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

		// Token: 0x06009488 RID: 38024 RVA: 0x0015F3E0 File Offset: 0x0015D5E0
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

		// Token: 0x0400321F RID: 12831
		public static readonly uint FIX_SKILL_COUNT_MAX = 3U;

		// Token: 0x04003220 RID: 12832
		public ulong UID;

		// Token: 0x04003221 RID: 12833
		public uint ID;

		// Token: 0x04003222 RID: 12834
		public int Level;

		// Token: 0x04003223 RID: 12835
		public string Name;

		// Token: 0x04003224 RID: 12836
		public PetSex Sex;

		// Token: 0x04003225 RID: 12837
		public uint PPT;

		// Token: 0x04003226 RID: 12838
		public int Exp;

		// Token: 0x04003227 RID: 12839
		public uint FullDegree;

		// Token: 0x04003228 RID: 12840
		public uint Mood;

		// Token: 0x04003229 RID: 12841
		public int HistoryLevelMAX;

		// Token: 0x0400322A RID: 12842
		public int showExp;

		// Token: 0x0400322B RID: 12843
		public int showLevel;

		// Token: 0x0400322C RID: 12844
		public uint showFullDegree;

		// Token: 0x0400322E RID: 12846
		private List<XPet.Skill> m_SkillList = new List<XPet.Skill>();

		// Token: 0x0400322F RID: 12847
		private List<XPet.Skill> m_ShowSkillList = new List<XPet.Skill>();

		// Token: 0x04003230 RID: 12848
		private XPet.Skill m_ActiveSkill = new XPet.Skill();

		// Token: 0x0200196C RID: 6508
		public class Skill
		{
			// Token: 0x06010FF3 RID: 69619 RVA: 0x00452E60 File Offset: 0x00451060
			public void Init(uint Id, bool IsOpen = true)
			{
				this.id = Id;
				this.open = IsOpen;
			}

			// Token: 0x04007E22 RID: 32290
			public uint id;

			// Token: 0x04007E23 RID: 32291
			public bool open;
		}
	}
}
