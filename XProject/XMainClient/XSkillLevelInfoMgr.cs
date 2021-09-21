using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DCD RID: 3533
	internal class XSkillLevelInfoMgr
	{
		// Token: 0x170033CE RID: 13262
		// (get) Token: 0x0600C066 RID: 49254 RVA: 0x0028AF34 File Offset: 0x00289134
		public XSkillFlags Flags
		{
			get
			{
				return this._Flags;
			}
		}

		// Token: 0x0600C067 RID: 49255 RVA: 0x0028AF4C File Offset: 0x0028914C
		public void SetDefaultLevel(uint level)
		{
			this._DefaultLevel = level;
		}

		// Token: 0x170033CF RID: 13263
		// (get) Token: 0x0600C068 RID: 49256 RVA: 0x0028AF58 File Offset: 0x00289158
		public Dictionary<uint, uint> LearnedSkills
		{
			get
			{
				return this._SkillDicts;
			}
		}

		// Token: 0x0600C069 RID: 49257 RVA: 0x0028AF70 File Offset: 0x00289170
		public void RemoveSkill(uint skillHash)
		{
			this._SkillDicts.Remove(skillHash);
		}

		// Token: 0x0600C06A RID: 49258 RVA: 0x0028AF80 File Offset: 0x00289180
		public uint GetSkillLevel(uint skillHash)
		{
			uint num = 0U;
			bool flag = XEntity.ValideEntity(this._entity) && this._entity.IsTransform;
			uint result;
			if (flag)
			{
				bool canlevelrans = XBattleSkillDocument.m_canlevelrans;
				if (canlevelrans)
				{
					bool flag2 = XBattleSkillDocument.SkillLevelDict.TryGetValue(skillHash, out num);
					if (flag2)
					{
						result = num;
					}
					else
					{
						result = 1U;
					}
				}
				else
				{
					result = 1U;
				}
			}
			else
			{
				bool flag3 = this._LinkedLevels.TryGetValue(skillHash, out num);
				if (flag3)
				{
					result = num;
				}
				else
				{
					result = this.GetSkillOriginalLevel(skillHash);
				}
			}
			return result;
		}

		// Token: 0x0600C06B RID: 49259 RVA: 0x0028B004 File Offset: 0x00289204
		public uint GetSkillOriginalLevel(uint skillHash)
		{
			uint defaultLevel = this._DefaultLevel;
			bool flag = this._SkillDicts.TryGetValue(skillHash, out defaultLevel);
			uint result;
			if (flag)
			{
				result = defaultLevel;
			}
			else
			{
				result = this._DefaultLevel;
			}
			return result;
		}

		// Token: 0x0600C06C RID: 49260 RVA: 0x0028B03C File Offset: 0x0028923C
		public void SetSkillLevel(uint skillHash, uint skillLevel)
		{
			bool flag = this._SkillDicts.ContainsKey(skillHash);
			if (flag)
			{
				this._SkillDicts[skillHash] = skillLevel;
			}
			else
			{
				this._SkillDicts.Add(skillHash, skillLevel);
			}
		}

		// Token: 0x0600C06D RID: 49261 RVA: 0x0028B07C File Offset: 0x0028927C
		public void RefreshSkillFlags()
		{
			this._Flags.Reset();
			foreach (KeyValuePair<uint, uint> keyValuePair in this._SkillDicts)
			{
				SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(keyValuePair.Key, keyValuePair.Value);
				bool flag = skillConfig != null;
				if (flag)
				{
					this._Flags.SetFlag(skillConfig.Flag);
				}
			}
		}

		// Token: 0x0600C06E RID: 49262 RVA: 0x0028B110 File Offset: 0x00289310
		public void Init(List<SkillInfo> skills)
		{
			this._SkillDicts.Clear();
			for (int i = 0; i < skills.Count; i++)
			{
				this.SetSkillLevel(skills[i].skillHash, skills[i].skillLevel);
			}
			this.RefreshSkillFlags();
		}

		// Token: 0x0600C06F RID: 49263 RVA: 0x0028B168 File Offset: 0x00289368
		public void CaskAuraSkills(XEntity entity)
		{
			Dictionary<uint, uint>.Enumerator enumerator = this._SkillDicts.GetEnumerator();
			while (enumerator.MoveNext())
			{
				XSkillEffectMgr singleton = XSingleton<XSkillEffectMgr>.singleton;
				KeyValuePair<uint, uint> keyValuePair = enumerator.Current;
				uint key = keyValuePair.Key;
				keyValuePair = enumerator.Current;
				SkillList.RowData skillConfig = singleton.GetSkillConfig(key, keyValuePair.Value, entity.SkillCasterTypeID);
				bool flag = skillConfig != null && (int)skillConfig.SkillType == XSkillLevelInfoMgr.AuraSkillType;
				if (flag)
				{
					XBuffAddEventArgs @event = XEventPool<XBuffAddEventArgs>.GetEvent();
					@event.xBuffDesc.BuffID = skillConfig.AuraBuffID[0];
					XBuffAddEventArgs xbuffAddEventArgs = @event;
					int buffLevel;
					if (skillConfig.AuraBuffID[1] != 0)
					{
						buffLevel = skillConfig.AuraBuffID[1];
					}
					else
					{
						keyValuePair = enumerator.Current;
						buffLevel = (int)keyValuePair.Value;
					}
					xbuffAddEventArgs.xBuffDesc.BuffLevel = buffLevel;
					@event.Firer = entity;
					@event.xBuffDesc.CasterID = entity.ID;
					XBuffAddEventArgs xbuffAddEventArgs2 = @event;
					keyValuePair = enumerator.Current;
					xbuffAddEventArgs2.xBuffDesc.SkillID = keyValuePair.Key;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
			}
		}

		// Token: 0x0600C070 RID: 49264 RVA: 0x0028B280 File Offset: 0x00289480
		public void RefreshSelfLinkedLevels(XEntity entity)
		{
			this._entity = entity;
			this._LinkedLevels.Clear();
			bool flag = entity == null || entity.Attributes == null || this._entity.Attributes.skillSlot == null;
			if (!flag)
			{
				foreach (uint num in this._SkillDicts.Keys)
				{
					SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(num, 1U, entity.SkillCasterTypeID);
					bool flag2 = skillConfig != null && !string.IsNullOrEmpty(skillConfig.LinkedSkill);
					if (flag2)
					{
						uint skillOriginalLevel = this.GetSkillOriginalLevel(XSingleton<XCommon>.singleton.XHash(skillConfig.LinkedSkill));
						bool flag3 = skillOriginalLevel > 0U;
						if (flag3)
						{
							this._LinkedLevels[num] = skillOriginalLevel;
						}
					}
				}
			}
		}

		// Token: 0x0600C071 RID: 49265 RVA: 0x0028B374 File Offset: 0x00289574
		public void RefreshMobLinkedLevels(XEntity entity, XEntity hoster)
		{
			this._entity = entity;
			this._LinkedLevels.Clear();
			bool flag = entity == null || entity.SkillMgr == null || hoster == null || hoster.Attributes == null || hoster.Attributes.SkillLevelInfo == null;
			if (!flag)
			{
				XSkillMgr skillMgr = entity.SkillMgr;
				XSkillLevelInfoMgr skillLevelInfo = hoster.Attributes.SkillLevelInfo;
				XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(entity.PresentID);
				bool flag2 = byPresentID == null || byPresentID.OtherSkills == null;
				if (!flag2)
				{
					XSkillLevelInfoMgr.g_SkillsHavingEx.Clear();
					for (int i = 0; i < byPresentID.OtherSkills.Length; i++)
					{
						bool flag3 = string.IsNullOrEmpty(byPresentID.OtherSkills[i]) || byPresentID.OtherSkills[i] == "E";
						if (!flag3)
						{
							uint num = XSingleton<XCommon>.singleton.XHash(byPresentID.OtherSkills[i]);
							SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(num, 1U, entity.SkillCasterTypeID);
							bool flag4 = skillConfig == null;
							if (!flag4)
							{
								bool flag5 = !string.IsNullOrEmpty(skillConfig.ExSkillScript);
								if (flag5)
								{
									XSkillLevelInfoMgr.g_SkillsHavingEx.Add(skillConfig);
								}
								else
								{
									this.SetLinkedLevel(num, skillConfig, skillLevelInfo, entity.SkillCasterTypeID);
								}
							}
						}
					}
					for (int j = 0; j < XSkillLevelInfoMgr.g_SkillsHavingEx.Count; j++)
					{
						SkillList.RowData rowData = XSkillLevelInfoMgr.g_SkillsHavingEx[j];
						uint num2 = XSingleton<XCommon>.singleton.XHash(rowData.SkillScript);
						bool flag6 = this.GetSkillLevel(XSingleton<XCommon>.singleton.XHash(rowData.ExSkillScript)) > 0U;
						if (flag6)
						{
							this._LinkedLevels[num2] = 0U;
						}
						else
						{
							this.SetLinkedLevel(num2, rowData, skillLevelInfo, entity.SkillCasterTypeID);
						}
					}
				}
			}
		}

		// Token: 0x0600C072 RID: 49266 RVA: 0x0028B560 File Offset: 0x00289760
		private void SetLinkedLevel(uint skillID, SkillList.RowData rowData, XSkillLevelInfoMgr hosterSkillLevelMgr, uint enemyTempID)
		{
			bool flag = rowData == null || hosterSkillLevelMgr == null || string.IsNullOrEmpty(rowData.LinkedSkill);
			if (!flag)
			{
				uint skillHash = XSingleton<XCommon>.singleton.XHash(rowData.LinkedSkill);
				uint skillLevel = hosterSkillLevelMgr.GetSkillLevel(skillHash);
				bool flag2 = skillLevel == 0U;
				if (flag2)
				{
					this._LinkedLevels[skillID] = 0U;
				}
				else
				{
					uint val = skillLevel;
					uint preSkill = XSingleton<XSkillEffectMgr>.singleton.GetPreSkill(XSingleton<XCommon>.singleton.XHash(rowData.LinkedSkill), enemyTempID);
					bool flag3 = preSkill > 0U;
					if (flag3)
					{
						val = hosterSkillLevelMgr.GetSkillLevel(preSkill);
					}
					this._LinkedLevels[skillID] = Math.Min((uint)rowData.SkillLevel, val);
				}
			}
		}

		// Token: 0x04005062 RID: 20578
		public static int AuraSkillType = 4;

		// Token: 0x04005063 RID: 20579
		private Dictionary<uint, uint> _SkillDicts = new Dictionary<uint, uint>();

		// Token: 0x04005064 RID: 20580
		private Dictionary<uint, uint> _LinkedLevels = new Dictionary<uint, uint>();

		// Token: 0x04005065 RID: 20581
		private uint _DefaultLevel = 1U;

		// Token: 0x04005066 RID: 20582
		private XEntity _entity = null;

		// Token: 0x04005067 RID: 20583
		private XSkillFlags _Flags = new XSkillFlags();

		// Token: 0x04005068 RID: 20584
		private static List<SkillList.RowData> g_SkillsHavingEx = new List<SkillList.RowData>();
	}
}
