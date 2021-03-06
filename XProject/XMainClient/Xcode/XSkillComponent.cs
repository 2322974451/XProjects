using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSkillComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XSkillComponent.uuID;
			}
		}

		public bool IsSkillReplaced
		{
			get
			{
				return this._skill_replaced_by_typeid > 0U;
			}
		}

		public uint ReplacedByTypeID
		{
			get
			{
				return this._skill_replaced_by_typeid;
			}
		}

		public XSkillMgr SkillMgr
		{
			get
			{
				return this._skill_mgr;
			}
		}

		public uint[] ReplacedSlot
		{
			get
			{
				return this._replaced_skill_slot;
			}
		}

		public List<XEntity> SkillMobs
		{
			get
			{
				return this._skill_mobs;
			}
		}

		public bool HasSkillReplaced
		{
			get
			{
				return this._skills_replace_dic != null && this._skills_replace_dic.Count != 0;
			}
		}

		public XSkillCore TryGetSkillReplace(uint skillID, XSkillCore soul)
		{
			bool flag = this._skills_replace_dic == null;
			XSkillCore result;
			if (flag)
			{
				result = soul;
			}
			else
			{
				uint id;
				bool flag2 = this._skills_replace_dic.TryGetValue(skillID, out id);
				if (flag2)
				{
					XSkillCore skill = this._entity.SkillMgr.GetSkill(id);
					bool flag3 = skill != null;
					if (flag3)
					{
						return skill;
					}
				}
				result = soul;
			}
			return result;
		}

		public void SetSkillReplace(uint from, uint to)
		{
			bool flag = to == 0U;
			if (flag)
			{
				bool flag2 = this._skills_replace_dic != null;
				if (flag2)
				{
					this._skills_replace_dic.Remove(from);
				}
			}
			else
			{
				bool flag3 = this._skills_replace_dic == null;
				if (flag3)
				{
					this._skills_replace_dic = DictionaryPool<uint, uint>.Get();
				}
				this._skills_replace_dic[from] = to;
			}
		}

		public bool AddSkillMob(XEntity e)
		{
			bool result = false;
			bool flag = this._skill_mobs == null;
			if (flag)
			{
				this._skill_mobs = ListPool<XEntity>.Get();
			}
			bool flag2 = e != null && !this._skill_mobs.Contains(e);
			if (flag2)
			{
				this._skill_mobs.Add(e);
				bool syncMode = XSingleton<XGame>.singleton.SyncMode;
				if (syncMode)
				{
					result = true;
				}
				else
				{
					XOthersAttributes xothersAttributes = e.Attributes as XOthersAttributes;
					bool flag3 = xothersAttributes != null && xothersAttributes.SummonGroup > 0 && xothersAttributes.SummonGroup < XSingleton<XGlobalConfig>.singleton.EntitySummonGroupLimit.Length;
					if (flag3)
					{
						int num = XSingleton<XGlobalConfig>.singleton.EntitySummonGroupLimit[xothersAttributes.SummonGroup];
						int num2 = 0;
						XEntity xentity = null;
						for (int i = 0; i < this._skill_mobs.Count; i++)
						{
							bool flag4 = !XEntity.ValideEntity(this._skill_mobs[i]);
							if (!flag4)
							{
								XOthersAttributes xothersAttributes2 = this._skill_mobs[i].Attributes as XOthersAttributes;
								bool flag5 = xothersAttributes2 != null && xothersAttributes2.SummonGroup == xothersAttributes.SummonGroup;
								if (flag5)
								{
									bool flag6 = num2 == 0;
									if (flag6)
									{
										xentity = this._skill_mobs[i];
									}
									num2++;
								}
							}
						}
						bool flag7 = num2 > num;
						if (flag7)
						{
							result = (e != xentity);
							XSingleton<XEntityMgr>.singleton.DestroyEntity(xentity);
						}
						else
						{
							result = true;
						}
					}
					else
					{
						result = true;
					}
				}
			}
			return result;
		}

		public void RemoveSkillMob(XEntity e)
		{
			bool flag = this._skill_mobs != null;
			if (flag)
			{
				this._skill_mobs.Remove(e);
			}
		}

		public override void Update(float fDeltaT)
		{
			bool flag = this._skill == null;
			if (!flag)
			{
				bool flag2 = !this._skill.Update(fDeltaT);
				if (flag2)
				{
					this.EndSkill(false, false);
				}
			}
		}

		public override void PostUpdate(float fDeltaT)
		{
			bool flag = this._trigger != null;
			if (flag)
			{
				bool flag2 = this._trigger != "EndSkill";
				if (flag2)
				{
					bool flag3 = this.IsCasting();
					if (flag3)
					{
						this._skill.AnimInit = true;
						bool flag4 = this._entity.Ator != null;
						if (flag4)
						{
							this._entity.Ator.speed = 1f;
						}
						this._skill.TriggerAnim();
					}
				}
				else
				{
					bool flag5 = this._entity.Ator != null;
					if (flag5)
					{
						this._entity.Ator.SetTrigger(this._trigger);
					}
				}
				this._trigger = null;
			}
		}

		public void TagTrigger()
		{
			this._trigger = XSkillComponent.TriggerTag;
		}

		public XSkill CurrentSkill
		{
			get
			{
				return this._skill;
			}
		}

		public bool CanPerformAction(XStateDefine state, XActionArgs e)
		{
			bool flag = this.CurrentSkill == null;
			return flag || this.CurrentSkill.CanPerformAction(state, e.Token);
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_Attack, new XComponent.XEventHandler(this.OnAttack));
			base.RegisterEvent(XEventDefine.XEvent_StrengthPresevedOff, new XComponent.XEventHandler(this.OnPresevedStrengthStop));
			base.RegisterEvent(XEventDefine.XEvent_RealDead, new XComponent.XEventHandler(this.OnRealDead));
			base.RegisterEvent(XEventDefine.XEvent_Move_Mob, new XComponent.XEventHandler(this.OnMoveMob));
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._skill_mgr = XSingleton<XSkillFactory>.singleton.CreateSkillMgr(this._entity);
		}

		public override void Attached()
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage != EXStage.Hall;
			if (flag)
			{
				this._qte = (this._entity.GetXComponent(XQuickTimeEventComponent.uuID) as XQuickTimeEventComponent);
				bool flag2 = !XSingleton<XScene>.singleton.IsMustTransform || (this._entity.IsEnemy && this._entity.Transformee == null);
				if (flag2)
				{
					this._locate = (this._entity.IsPlayer ? (this._entity.GetXComponent(XLocateTargetComponent.uuID) as XLocateTargetComponent) : null);
					bool flag3 = XEntity.ValideEntity(this._entity.MobbedBy) && this._entity.Attributes.SkillLevelInfo != null;
					if (flag3)
					{
						this._entity.Attributes.SkillLevelInfo.RefreshMobLinkedLevels(this._entity, this._entity.MobbedBy);
					}
					this.AttachSkill();
				}
			}
		}

		public override void OnDetachFromHost()
		{
			this.EndSkill(true, true);
			bool flag = this._skill_mgr != null;
			if (flag)
			{
				XSingleton<XSkillFactory>.singleton.ReturnSkillMgr(this._skill_mgr);
				this._skill_mgr = null;
			}
			this._skill = null;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timer_token);
			this._timer_token = 0U;
			this._locate = null;
			this._qte = null;
			this._trigger = null;
			bool flag2 = this._skill_mobs != null;
			if (flag2)
			{
				ListPool<XEntity>.Release(this._skill_mobs);
				this._skill_mobs = null;
			}
			bool flag3 = this._skills_replace_dic != null;
			if (flag3)
			{
				DictionaryPool<uint, uint>.Release(this._skills_replace_dic);
				this._skills_replace_dic = null;
			}
			base.OnDetachFromHost();
		}

		public bool IsCasting()
		{
			return this._skill != null && this._skill.Casting;
		}

		public bool IsOverResults()
		{
			bool flag = this.IsCasting();
			bool result2;
			if (flag)
			{
				List<XResultData> result = this._skill.Core.Soul.Result;
				result2 = (result != null && result.Count > 0 && result[result.Count - 1].At < this.CurrentSkill.TimeElapsed);
			}
			else
			{
				result2 = true;
			}
			return result2;
		}

		protected bool OnPresevedStrengthStop(XEventArgs e)
		{
			bool flag = this.IsCasting() && this.CurrentSkill.MainCore.PreservedStrength > 0 && this.CurrentSkill.TimeElapsed < this.CurrentSkill.MainCore.Soul.Logical.PreservedEndAt;
			if (flag)
			{
				this.EndSkill(true, false);
				XStrengthPresevationOffArgs @event = XEventPool<XStrengthPresevationOffArgs>.GetEvent();
				@event.Host = this._entity;
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
			return true;
		}

		protected virtual bool OnAttack(XEventArgs e)
		{
			XAttackEventArgs xattackEventArgs = e as XAttackEventArgs;
			uint identify = xattackEventArgs.Identify;
			XSkillCore xskillCore = this._entity.SkillMgr.GetSkill(identify);
			bool flag = xskillCore == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = !XSingleton<XGame>.singleton.SyncMode;
				if (flag2)
				{
					xskillCore = this.PhysicalAttackAdaptor(xskillCore);
				}
				bool flag3 = xskillCore == null;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Skill ", identify.ToString(), " Physical-Adapter error.", null, null, null);
					result = false;
				}
				else
				{
					bool flag4 = !XSingleton<XGame>.singleton.SyncMode;
					if (flag4)
					{
						xskillCore = this.TryGetSkillReplace(xskillCore.ID, xskillCore);
					}
					XEntity target = this.SelectedTarget(xattackEventArgs, xskillCore);
					bool flag5 = this._entity.QTE != null && this._entity.QTE.QTEList.Contains(xskillCore.ID);
					bool flag6 = false;
					bool flag7 = xskillCore != null && (xattackEventArgs.Demonstration || XSingleton<XGame>.singleton.SyncMode || (xskillCore.CooledDown && (flag5 || (xskillCore.CanCast(e.Token) && (this._skill == null || !this._skill.Casting || this._skill.MainCore.CanReplacedBy(xskillCore))))));
					if (flag7)
					{
						XSkill carrier = this._entity.SkillMgr.GetCarrier(xskillCore.CarrierID);
						bool flag8 = this.FireSkill(carrier, target, xskillCore, xattackEventArgs);
						if (flag8)
						{
							flag6 = true;
						}
					}
					bool flag9 = flag5 || xskillCore.Soul.TypeToken == 0;
					if (flag9)
					{
						bool flag10 = this._qte != null;
						if (flag10)
						{
							this._qte.OnSkillCasted(xskillCore.ID, xattackEventArgs.Slot, flag6);
						}
					}
					result = flag6;
				}
			}
			return result;
		}

		protected virtual bool OnRealDead(XEventArgs e)
		{
			this.EndSkill(false, true);
			return true;
		}

		protected virtual bool FireSkill(XSkill newOne, XEntity target, XSkillCore core, XAttackEventArgs args)
		{
			bool flag = this._skill != null;
			if (flag)
			{
				this.EndSkill(false, false);
			}
			this._skill = newOne;
			bool flag2 = this._skill != null && this._skill.Fire(target, core, args);
			bool result;
			if (flag2)
			{
				this.TagTrigger();
				bool multipleAttackSupported = this._skill.MainCore.Soul.MultipleAttackSupported;
				if (multipleAttackSupported)
				{
					this._entity.OverrideAnimClip(XSkillData.MultipleAttackOverrideMap[0], this._skill.MainCore.Soul.ClipName, false, false);
					this._entity.OverrideAnimClip(XSkillData.MultipleAttackOverrideMap[1], this._skill.MainCore.Soul.ClipName + "_right_forward", false, false);
					this._entity.OverrideAnimClip(XSkillData.MultipleAttackOverrideMap[2], this._skill.MainCore.Soul.ClipName + "_right", false, false);
					this._entity.OverrideAnimClip(XSkillData.MultipleAttackOverrideMap[3], this._skill.MainCore.Soul.ClipName + "_right_back", false, false);
					this._entity.OverrideAnimClip(XSkillData.MultipleAttackOverrideMap[4], this._skill.MainCore.Soul.ClipName + "_left_forward", false, false);
					this._entity.OverrideAnimClip(XSkillData.MultipleAttackOverrideMap[5], this._skill.MainCore.Soul.ClipName + "_left", false, false);
					this._entity.OverrideAnimClip(XSkillData.MultipleAttackOverrideMap[6], this._skill.MainCore.Soul.ClipName + "_left_back", false, false);
					this._entity.OverrideAnimClip(XSkillData.MultipleAttackOverrideMap[7], this._skill.MainCore.Soul.ClipName + "_back", false, false);
				}
				else
				{
					switch (this._skill.MainCore.Soul.TypeToken)
					{
					case 0:
						this._entity.OverrideAnimClip(XSkillData.JaOverrideMap[core.Soul.SkillPosition], this._skill.MainCore.Soul.ClipName, false, false);
						break;
					case 1:
						this._entity.OverrideAnimClip("Art", this._skill.AnimClipName, false, false);
						break;
					case 3:
						for (int i = 0; i < this._skill.MainCore.Soul.Combined.Count; i++)
						{
							XSkillCore skill = this._entity.SkillMgr.GetSkill(XSingleton<XCommon>.singleton.XHash(this._skill.MainCore.Soul.Combined[i].Name));
							this._entity.OverrideAnimClip(XSkillData.CombinedOverrideMap[i], skill.Soul.ClipName, false, false);
						}
						break;
					}
				}
				result = true;
			}
			else
			{
				bool flag3 = this._skill != null && this._skill.Casting;
				if (!flag3)
				{
					this._skill = null;
				}
				result = false;
			}
			return result;
		}

		private bool OnMoveMob(XEventArgs e)
		{
			bool flag = this._skill_mobs != null && this._host.EngineObject != null;
			if (flag)
			{
				for (int i = 0; i < this._skill_mobs.Count; i++)
				{
					bool flag2 = this._skill_mobs[i].Skill != null;
					if (flag2)
					{
						this._skill_mobs[i].Skill.EndSkill(false, false);
					}
					Vector3 vector = this._host.EngineObject.Rotation * ((XSingleton<XGlobalConfig>.singleton.MobMovePos.Length > i) ? XSingleton<XGlobalConfig>.singleton.MobMovePos[i] : Vector3.zero);
					bool flag3 = this._skill_mobs[i].Net != null && this._skill_mobs[i].Machine != null && this._skill_mobs[i].Machine.Current == XStateDefine.XState_Move;
					if (flag3)
					{
						this._skill_mobs[i].Net.ReportMoveAction(Vector3.zero, 0.0);
					}
					this._skill_mobs[i].CorrectMe(this._host.EngineObject.Position + vector, this._host.EngineObject.Forward, false, false);
				}
			}
			return true;
		}

		public void ReAttachSkill(XEntityPresentation.RowData template, uint typeid)
		{
			XSingleton<XBulletMgr>.singleton.ClearBullets(this._entity.ID);
			bool flag = this._skill_mgr != null;
			if (flag)
			{
				this._skill_mgr.Uninitialize();
			}
			this._skill_mgr.Initialize(this._entity);
			bool flag2 = template == null;
			if (flag2)
			{
				bool isSkillReplaced = this.IsSkillReplaced;
				if (isSkillReplaced)
				{
					bool flag3 = !XSingleton<XScene>.singleton.IsMustTransform;
					if (flag3)
					{
						this.AttachSkill();
					}
				}
			}
			else
			{
				this._skill_replaced_by_typeid = typeid;
				string skillprefix = "SkillPackage/" + template.SkillLocation;
				bool flag4 = !string.IsNullOrEmpty(template.A);
				if (flag4)
				{
					this._entity.SkillMgr.AttachPhysicalSkill(XSingleton<XSkillFactory>.singleton.Build(skillprefix, template.A, this._entity));
				}
				bool flag5 = !string.IsNullOrEmpty(template.AA);
				if (flag5)
				{
					this._entity.SkillMgr.AttachSkill(XSingleton<XSkillFactory>.singleton.Build(skillprefix, template.AA, this._entity), false);
				}
				bool flag6 = !string.IsNullOrEmpty(template.AAA);
				if (flag6)
				{
					this._entity.SkillMgr.AttachSkill(XSingleton<XSkillFactory>.singleton.Build(skillprefix, template.AAA, this._entity), false);
				}
				bool flag7 = !string.IsNullOrEmpty(template.AAAA);
				if (flag7)
				{
					this._entity.SkillMgr.AttachSkill(XSingleton<XSkillFactory>.singleton.Build(skillprefix, template.AAAA, this._entity), false);
				}
				bool flag8 = !string.IsNullOrEmpty(template.AAAAA);
				if (flag8)
				{
					this._entity.SkillMgr.AttachSkill(XSingleton<XSkillFactory>.singleton.Build(skillprefix, template.AAAAA, this._entity), false);
				}
				bool flag9 = !string.IsNullOrEmpty(template.Ultra);
				if (flag9)
				{
					this._entity.SkillMgr.AttachUltraSkill(XSingleton<XSkillFactory>.singleton.Build(skillprefix, template.Ultra, this._entity));
				}
				bool flag10 = !string.IsNullOrEmpty(template.Appear);
				if (flag10)
				{
					this._entity.SkillMgr.AttachAppearSkill(XSingleton<XSkillFactory>.singleton.Build(skillprefix, template.Appear, this._entity));
				}
				bool flag11 = !string.IsNullOrEmpty(template.Disappear);
				if (flag11)
				{
					this._entity.SkillMgr.AttachDisappearSkill(XSingleton<XSkillFactory>.singleton.Build(skillprefix, template.Disappear, this._entity));
				}
				bool flag12 = !string.IsNullOrEmpty(template.Dash);
				if (flag12)
				{
					this._entity.SkillMgr.AttachDashSkill(XSingleton<XSkillFactory>.singleton.Build(skillprefix, template.Dash, this._entity));
				}
				bool flag13 = !string.IsNullOrEmpty(template.SuperArmorRecoverySkill);
				if (flag13)
				{
					this._entity.SkillMgr.AttachRecoverySkill(XSingleton<XSkillFactory>.singleton.Build(skillprefix, template.SuperArmorRecoverySkill, this._entity));
				}
				bool flag14 = !string.IsNullOrEmpty(template.ArmorBroken);
				if (flag14)
				{
					this._entity.SkillMgr.AttachBrokenSkill(XSingleton<XSkillFactory>.singleton.Build(skillprefix, template.ArmorBroken, this._entity));
				}
				bool flag15 = template.OtherSkills != null && template.OtherSkills.Length != 0;
				if (flag15)
				{
					int i = 0;
					int num = template.OtherSkills.Length;
					while (i < num)
					{
						bool flag16 = !string.IsNullOrEmpty(template.OtherSkills[i]) && template.OtherSkills[i] != "E";
						if (flag16)
						{
							this._entity.SkillMgr.AttachSkill(XSingleton<XSkillFactory>.singleton.Build(skillprefix, template.OtherSkills[i], this._entity), true);
						}
						i++;
					}
				}
				else
				{
					bool isRole = this._entity.IsRole;
					if (isRole)
					{
						for (int j = 0; j < this._entity.Attributes.skillSlot.Length; j++)
						{
							bool flag17 = this._entity.Attributes.skillSlot[j] == 0U;
							if (!flag17)
							{
								SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(this._entity.Attributes.skillSlot[j], 0U);
								bool flag18 = skillConfig == null;
								if (flag18)
								{
									XSingleton<XDebug>.singleton.AddErrorLog("Skill: ", this._entity.Attributes.skillSlot[j].ToString(), " is not found in SkillList", null, null, null);
								}
								else
								{
									this.OtherAttachFilter(skillConfig, this._entity.Attributes.skillSlot[j]);
								}
							}
						}
						Dictionary<uint, uint>.Enumerator enumerator = this._entity.Attributes.SkillLevelInfo.LearnedSkills.GetEnumerator();
						while (enumerator.MoveNext())
						{
							XSkillEffectMgr singleton = XSingleton<XSkillEffectMgr>.singleton;
							KeyValuePair<uint, uint> keyValuePair = enumerator.Current;
							SkillList.RowData skillConfig2 = singleton.GetSkillConfig(keyValuePair.Key, 0U);
							bool flag19 = skillConfig2 == null;
							if (flag19)
							{
								XDebug singleton2 = XSingleton<XDebug>.singleton;
								string log = "Skill: ";
								keyValuePair = enumerator.Current;
								singleton2.AddErrorLog(log, keyValuePair.Key.ToString(), " is not found in SkillList", null, null, null);
							}
							else
							{
								bool flag20 = (int)skillConfig2.SkillType == XFastEnumIntEqualityComparer<SkillTypeEnum>.ToInt(SkillTypeEnum.Skill_Help) || skillConfig2.IsBasicSkill > 0;
								if (flag20)
								{
									SkillList.RowData data = skillConfig2;
									keyValuePair = enumerator.Current;
									this.OtherAttachFilter(data, keyValuePair.Key);
								}
							}
						}
					}
				}
				this._entity.SkillMgr.StatisticsPhysicalSkill();
				bool isPlayer = this._entity.IsPlayer;
				if (isPlayer)
				{
					List<uint> list = ListPool<uint>.Get();
					list.Add(this._entity.SkillMgr.GetPhysicalIdentity());
					list.Add(this._entity.SkillMgr.GetDashIdentity());
					bool flag21 = template.OtherSkills != null && template.OtherSkills.Length != 0;
					if (flag21)
					{
						int num2 = template.OtherSkills.Length;
						int num3 = 2;
						while ((long)num3 < (long)((ulong)XBattleSkillDocument.Total_skill_slot))
						{
							bool flag22 = num3 - 2 < num2 && !string.IsNullOrEmpty(template.OtherSkills[num3 - 2]) && template.OtherSkills[num3 - 2] != "E";
							if (flag22)
							{
								list.Add(XSingleton<XCommon>.singleton.XHash(template.OtherSkills[num3 - 2]));
							}
							else
							{
								list.Add(0U);
							}
							num3++;
						}
					}
					else
					{
						int num4 = 2;
						while ((long)num4 < (long)((ulong)XBattleSkillDocument.Total_skill_slot))
						{
							list.Add(this._entity.Attributes.skillSlot[num4]);
							num4++;
						}
					}
					this._replaced_skill_slot = list.ToArray();
					ListPool<uint>.Release(list);
					bool flag23 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler != null;
					if (flag23)
					{
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.SetButtonNum((int)template.SkillNum);
					}
				}
			}
		}

		public void AttachSkill()
		{
			this._skill_replaced_by_typeid = 0U;
			this._replaced_skill_slot = null;
			bool isRole = this._entity.IsRole;
			if (isRole)
			{
				for (int i = 0; i < this._entity.Attributes.skillSlot.Length; i++)
				{
					bool flag = this._entity.Attributes.skillSlot[i] == 0U;
					if (!flag)
					{
						SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(this._entity.Attributes.skillSlot[i], 0U);
						bool flag2 = skillConfig == null;
						if (flag2)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("Skill: ", this._entity.Attributes.skillSlot[i].ToString(), " is not found in SkillList", null, null, null);
						}
						else
						{
							this.AttachFilter(skillConfig, this._entity.Attributes.skillSlot[i]);
						}
					}
				}
				Dictionary<uint, uint>.Enumerator enumerator = this._entity.Attributes.SkillLevelInfo.LearnedSkills.GetEnumerator();
				while (enumerator.MoveNext())
				{
					XSkillEffectMgr singleton = XSingleton<XSkillEffectMgr>.singleton;
					KeyValuePair<uint, uint> keyValuePair = enumerator.Current;
					SkillList.RowData skillConfig2 = singleton.GetSkillConfig(keyValuePair.Key, 0U);
					bool flag3 = skillConfig2 == null;
					if (flag3)
					{
						XDebug singleton2 = XSingleton<XDebug>.singleton;
						string log = "Skill: ";
						keyValuePair = enumerator.Current;
						singleton2.AddErrorLog(log, keyValuePair.Key.ToString(), " is not found in SkillList", null, null, null);
					}
					else
					{
						bool flag4 = (int)skillConfig2.SkillType == XFastEnumIntEqualityComparer<SkillTypeEnum>.ToInt(SkillTypeEnum.Skill_Help) || skillConfig2.IsBasicSkill > 0;
						if (flag4)
						{
							SkillList.RowData data = skillConfig2;
							keyValuePair = enumerator.Current;
							this.AttachFilter(data, keyValuePair.Key);
						}
					}
				}
			}
			else
			{
				bool flag5 = !string.IsNullOrEmpty(this._entity.Present.PresentLib.A);
				if (flag5)
				{
					this._entity.SkillMgr.AttachPhysicalSkill(XSingleton<XSkillFactory>.singleton.Build(this._entity.Present.SkillPrefix, this._entity.Present.PresentLib.A, this._entity));
				}
				bool flag6 = !string.IsNullOrEmpty(this._entity.Present.PresentLib.AA);
				if (flag6)
				{
					this._entity.SkillMgr.AttachSkill(XSingleton<XSkillFactory>.singleton.Build(this._entity.Present.SkillPrefix, this._entity.Present.PresentLib.AA, this._entity), false);
				}
				bool flag7 = !string.IsNullOrEmpty(this._entity.Present.PresentLib.AAA);
				if (flag7)
				{
					this._entity.SkillMgr.AttachSkill(XSingleton<XSkillFactory>.singleton.Build(this._entity.Present.SkillPrefix, this._entity.Present.PresentLib.AAA, this._entity), false);
				}
				bool flag8 = !string.IsNullOrEmpty(this._entity.Present.PresentLib.AAAA);
				if (flag8)
				{
					this._entity.SkillMgr.AttachSkill(XSingleton<XSkillFactory>.singleton.Build(this._entity.Present.SkillPrefix, this._entity.Present.PresentLib.AAAA, this._entity), false);
				}
				bool flag9 = !string.IsNullOrEmpty(this._entity.Present.PresentLib.AAAAA);
				if (flag9)
				{
					this._entity.SkillMgr.AttachSkill(XSingleton<XSkillFactory>.singleton.Build(this._entity.Present.SkillPrefix, this._entity.Present.PresentLib.AAAAA, this._entity), false);
				}
				bool flag10 = !string.IsNullOrEmpty(this._entity.Present.PresentLib.Ultra);
				if (flag10)
				{
					this._entity.SkillMgr.AttachUltraSkill(XSingleton<XSkillFactory>.singleton.Build(this._entity.Present.SkillPrefix, this._entity.Present.PresentLib.Ultra, this._entity));
				}
				bool flag11 = !string.IsNullOrEmpty(this._entity.Present.PresentLib.Appear);
				if (flag11)
				{
					this._entity.SkillMgr.AttachAppearSkill(XSingleton<XSkillFactory>.singleton.Build(this._entity.Present.SkillPrefix, this._entity.Present.PresentLib.Appear, this._entity));
				}
				bool flag12 = !string.IsNullOrEmpty(this._entity.Present.PresentLib.Disappear);
				if (flag12)
				{
					this._entity.SkillMgr.AttachDisappearSkill(XSingleton<XSkillFactory>.singleton.Build(this._entity.Present.SkillPrefix, this._entity.Present.PresentLib.Disappear, this._entity));
				}
				bool flag13 = !string.IsNullOrEmpty(this._entity.Present.PresentLib.Dash);
				if (flag13)
				{
					this._entity.SkillMgr.AttachDashSkill(XSingleton<XSkillFactory>.singleton.Build(this._entity.Present.SkillPrefix, this._entity.Present.PresentLib.Dash, this._entity));
				}
				bool flag14 = !string.IsNullOrEmpty(this._entity.Present.PresentLib.SuperArmorRecoverySkill);
				if (flag14)
				{
					this._entity.SkillMgr.AttachRecoverySkill(XSingleton<XSkillFactory>.singleton.Build(this._entity.Present.SkillPrefix, this._entity.Present.PresentLib.SuperArmorRecoverySkill, this._entity));
				}
				bool flag15 = !string.IsNullOrEmpty(this._entity.Present.PresentLib.ArmorBroken);
				if (flag15)
				{
					this._entity.SkillMgr.AttachBrokenSkill(XSingleton<XSkillFactory>.singleton.Build(this._entity.Present.SkillPrefix, this._entity.Present.PresentLib.ArmorBroken, this._entity));
				}
				bool flag16 = this._entity.Present.PresentLib.OtherSkills != null;
				if (flag16)
				{
					int j = 0;
					int num = this._entity.Present.PresentLib.OtherSkills.Length;
					while (j < num)
					{
						bool flag17 = !string.IsNullOrEmpty(this._entity.Present.PresentLib.OtherSkills[j]) && this._entity.Present.PresentLib.OtherSkills[j] != "E";
						if (flag17)
						{
							this._entity.SkillMgr.AttachSkill(XSingleton<XSkillFactory>.singleton.Build(this._entity.Present.SkillPrefix, this._entity.Present.PresentLib.OtherSkills[j], this._entity), true);
						}
						j++;
					}
				}
			}
			this._entity.SkillMgr.StatisticsPhysicalSkill();
			bool isPlayer = this._entity.IsPlayer;
			if (isPlayer)
			{
			}
		}

		public void EndSkill(bool cleanUp = false, bool force = false)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			if (syncMode)
			{
				bool isPlayer = this._entity.IsPlayer;
				if (isPlayer)
				{
					this._entity.Net.LastReqSkill = 0U;
				}
				bool flag = !force && this._skill != null && !this._skill.DemonstrationMode;
				if (flag)
				{
					return;
				}
			}
			this.InnerEnd(cleanUp);
		}

		private void InnerEnd(bool cleanUp)
		{
			bool flag = this._skill != null;
			if (flag)
			{
				this._skill.Cease(cleanUp);
				this._skill = null;
				this._trigger = "EndSkill";
			}
		}

		private XEntity SelectedTarget(XAttackEventArgs args, XSkillCore soul)
		{
			bool syncMode = XSingleton<XGame>.singleton.SyncMode;
			XEntity result;
			if (syncMode)
			{
				result = args.Target;
			}
			else
			{
				bool flag = args.Target == null;
				if (flag)
				{
					result = ((this._locate == null) ? null : this._locate.Locate(this._entity.EngineObject.Forward, this._entity.EngineObject.Position, false));
				}
				else
				{
					result = args.Target;
				}
			}
			return result;
		}

		private XSkillCore PhysicalAttackAdaptor(XSkillCore soul)
		{
			bool flag = this._entity.IsPlayer && soul.Soul.Logical.Association;
			if (flag)
			{
				bool feeding = XSingleton<XVirtualTab>.singleton.Feeding;
				if (feeding)
				{
					bool flag2 = !soul.Soul.Logical.MoveType;
					if (flag2)
					{
						soul = this._entity.SkillMgr.GetSkill(XSingleton<XCommon>.singleton.XHash(soul.Soul.Logical.Association_Skill));
					}
				}
				else
				{
					bool moveType = soul.Soul.Logical.MoveType;
					if (moveType)
					{
						soul = this._entity.SkillMgr.GetSkill(XSingleton<XCommon>.singleton.XHash(soul.Soul.Logical.Association_Skill));
					}
				}
			}
			return soul;
		}

		private void AttachFilter(SkillList.RowData data, uint id)
		{
			XSkillCore core = XSingleton<XSkillFactory>.singleton.Build(this._entity.Present.SkillPrefix, data.SkillScript, this._entity);
			XSkillData.PreLoad = (this._entity.IsPlayer && !XSingleton<XScene>.singleton.IsMustTransform);
			bool flag = this._entity.SkillMgr.GetPhysicalIdentity() == 0U && XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.A) == id;
			if (flag)
			{
				this._entity.SkillMgr.AttachPhysicalSkill(core);
			}
			else
			{
				bool flag2 = this._entity.SkillMgr.GetUltraIdentity() == 0U && XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.Ultra) == id;
				if (flag2)
				{
					this._entity.SkillMgr.AttachUltraSkill(core);
				}
				else
				{
					bool flag3 = this._entity.SkillMgr.GetAppearIdentity() == 0U && XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.Appear) == id;
					if (flag3)
					{
						this._entity.SkillMgr.AttachAppearSkill(core);
					}
					else
					{
						bool flag4 = this._entity.SkillMgr.GetDisappearIdentity() == 0U && XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.Disappear) == id;
						if (flag4)
						{
							this._entity.SkillMgr.AttachDisappearSkill(core);
						}
						else
						{
							bool flag5 = this._entity.SkillMgr.GetDashIdentity() == 0U && XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.Dash) == id;
							if (flag5)
							{
								this._entity.SkillMgr.AttachDashSkill(core);
							}
							else
							{
								bool flag6 = this._entity.SkillMgr.GetRecoveryIdentity() == 0U && XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.SuperArmorRecoverySkill) == id;
								if (flag6)
								{
									this._entity.SkillMgr.AttachRecoverySkill(core);
								}
								else
								{
									bool flag7 = this._entity.SkillMgr.GetBrokenIdentity() == 0U && XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.ArmorBroken) == id;
									if (flag7)
									{
										this._entity.SkillMgr.AttachRecoverySkill(core);
									}
									else
									{
										bool flag8 = XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.AA) == id;
										if (flag8)
										{
											this._entity.SkillMgr.AttachSkill(core, false);
										}
										else
										{
											bool flag9 = XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.AAA) == id;
											if (flag9)
											{
												this._entity.SkillMgr.AttachSkill(core, false);
											}
											else
											{
												bool flag10 = XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.AAAA) == id;
												if (flag10)
												{
													this._entity.SkillMgr.AttachSkill(core, false);
												}
												else
												{
													bool flag11 = XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.AAAAA) == id;
													if (flag11)
													{
														this._entity.SkillMgr.AttachSkill(core, false);
													}
													else
													{
														this._entity.SkillMgr.AttachSkill(core, true);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			XSkillData.PreLoad = false;
		}

		private void OtherAttachFilter(SkillList.RowData data, uint id)
		{
			bool flag = XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.A) == id;
			if (!flag)
			{
				bool flag2 = XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.Ultra) == id;
				if (!flag2)
				{
					bool flag3 = XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.Appear) == id;
					if (!flag3)
					{
						bool flag4 = XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.Disappear) == id;
						if (!flag4)
						{
							bool flag5 = XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.Dash) == id;
							if (!flag5)
							{
								bool flag6 = XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.SuperArmorRecoverySkill) == id;
								if (!flag6)
								{
									bool flag7 = XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.ArmorBroken) == id;
									if (!flag7)
									{
										bool flag8 = XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.AA) == id;
										if (!flag8)
										{
											bool flag9 = XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.AAA) == id;
											if (!flag9)
											{
												bool flag10 = XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.AAAA) == id;
												if (!flag10)
												{
													bool flag11 = XSingleton<XCommon>.singleton.XHash(this._entity.Present.PresentLib.AAAAA) == id;
													if (!flag11)
													{
														XSkillCore core = XSingleton<XSkillFactory>.singleton.Build(this._entity.Present.SkillPrefix, data.SkillScript, this._entity);
														this._entity.SkillMgr.AttachSkill(core, true);
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Skill");

		public static readonly string TriggerTag = "";

		private XSkill _skill = null;

		private XSkillMgr _skill_mgr = null;

		private uint _timer_token = 0U;

		private uint _skill_replaced_by_typeid = 0U;

		private XLocateTargetComponent _locate = null;

		private XQuickTimeEventComponent _qte = null;

		private string _trigger = null;

		private uint[] _replaced_skill_slot = null;

		private List<XEntity> _skill_mobs = null;

		private Dictionary<uint, uint> _skills_replace_dic = null;
	}
}
