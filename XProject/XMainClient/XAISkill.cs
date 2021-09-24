using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAISkill : XSingleton<XAISkill>
	{

		public XAISkill()
		{
			bool inited = this._inited;
			if (!inited)
			{
				for (int i = 0; i < 8; i++)
				{
					SkillCombo.RowData rowData = XArenaDocument.SkillComboTable.Table[i];
					List<string> list = new List<string>();
					bool flag = rowData.nextskill0 != "";
					if (flag)
					{
						list.Add(rowData.nextskill0);
					}
					bool flag2 = rowData.nextskill1 != "";
					if (flag2)
					{
						list.Add(rowData.nextskill1);
					}
					bool flag3 = rowData.nextskill2 != "";
					if (flag3)
					{
						list.Add(rowData.nextskill2);
					}
					bool flag4 = rowData.nextskill3 != "";
					if (flag4)
					{
						list.Add(rowData.nextskill3);
					}
					bool flag5 = rowData.nextskill4 != "";
					if (flag5)
					{
						list.Add(rowData.nextskill4);
					}
					this._start_skills[i] = list;
				}
				for (int j = 16; j < XArenaDocument.SkillComboTable.Table.Length; j++)
				{
					SkillCombo.RowData rowData2 = XArenaDocument.SkillComboTable.Table[j];
					List<string> list2 = new List<string>();
					bool flag6 = rowData2.nextskill0 != "";
					if (flag6)
					{
						list2.Add(rowData2.nextskill0);
					}
					bool flag7 = rowData2.nextskill1 != "";
					if (flag7)
					{
						list2.Add(rowData2.nextskill1);
					}
					bool flag8 = rowData2.nextskill2 != "";
					if (flag8)
					{
						list2.Add(rowData2.nextskill2);
					}
					bool flag9 = rowData2.nextskill3 != "";
					if (flag9)
					{
						list2.Add(rowData2.nextskill3);
					}
					bool flag10 = rowData2.nextskill4 != "";
					if (flag10)
					{
						list2.Add(rowData2.nextskill4);
					}
					this._next_skills[rowData2.skillname] = list2;
				}
				this._inited = true;
			}
		}

		public List<string> GetStartSkill(int profIndex)
		{
			bool flag = this._start_skills.ContainsKey(profIndex);
			List<string> result;
			if (flag)
			{
				result = this._start_skills[profIndex];
			}
			else
			{
				result = null;
			}
			return result;
		}

		public List<string> GetNextSkill(string skillname)
		{
			bool flag = this._next_skills.ContainsKey(skillname);
			List<string> result;
			if (flag)
			{
				result = this._next_skills[skillname];
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int GetProfIndex(XEntity entity)
		{
			int num = (int)(entity.Attributes.TypeID % 10U - 1U);
			int num2 = (int)(entity.Attributes.TypeID / 10U - 1U);
			bool flag = entity.Attributes.TypeID >= 1000U || entity.Attributes.TypeID <= 10U;
			int result;
			if (flag)
			{
				result = num * 2 + XSingleton<XCommon>.singleton.RandomInt(0, 2);
			}
			else
			{
				result = num * 2 + num2;
			}
			return result;
		}

		public bool TryCastPhysicalSkill(XEntity host, XEntity target)
		{
			bool flag = host == null || target == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				Vector3 position = target.EngineObject.Position;
				Vector3 position2 = host.EngineObject.Position;
				XSkillCore physicalSkill = host.SkillMgr.GetPhysicalSkill();
				bool flag2 = physicalSkill != null;
				if (flag2)
				{
					host.Net.ReportSkillAction(target, physicalSkill.ID, -1);
					XSecurityAIInfo xsecurityAIInfo = XSecurityAIInfo.TryGetStatistics(host);
					bool flag3 = xsecurityAIInfo != null;
					if (flag3)
					{
						bool flag4 = !host.IsPlayer && !host.IsRole;
						if (flag4)
						{
							xsecurityAIInfo.OnPhysicalAttack();
						}
					}
				}
				result = true;
			}
			return result;
		}

		public bool TryCastInstallSkill(XEntity host, XEntity target)
		{
			return false;
		}

		public bool TryCastLearnedSkill(XEntity host, XEntity target)
		{
			return false;
		}

		private bool CastSkill(XEntity host, XEntity target, uint skillid)
		{
			bool flag = host == null || target == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				Vector3 position = target.EngineObject.Position;
				Vector3 position2 = host.EngineObject.Position;
				float magnitude = (position - position2).magnitude;
				XSkillCore physicalSkill = host.SkillMgr.GetPhysicalSkill();
				bool flag2 = physicalSkill.ID == skillid;
				if (flag2)
				{
					bool flag3 = XSingleton<XCommon>.singleton.IsLess(magnitude, physicalSkill.CastRangeUpper) && XSingleton<XCommon>.singleton.IsGreater(magnitude, physicalSkill.CastRangeLower);
					if (flag3)
					{
						host.Net.ReportSkillAction(target, physicalSkill.ID, -1);
					}
					result = false;
				}
				else
				{
					for (int i = 0; i < host.SkillMgr.SkillOrder.Count; i++)
					{
						XSkillCore xskillCore = host.SkillMgr.SkillOrder[i] as XSkillCore;
						bool flag4 = xskillCore == null || xskillCore.ID != skillid;
						if (!flag4)
						{
							bool flag5 = host.SkillMgr.IsCooledDown(xskillCore) && xskillCore.ID != host.SkillMgr.GetRecoveryIdentity();
							if (flag5)
							{
								bool flag6 = XSingleton<XCommon>.singleton.IsLess(magnitude, xskillCore.CastRangeUpper) && XSingleton<XCommon>.singleton.IsGreater(magnitude, xskillCore.CastRangeLower);
								if (flag6)
								{
									host.Net.ReportSkillAction(target, xskillCore.ID, -1);
								}
							}
						}
					}
					result = false;
				}
			}
			return result;
		}

		public bool CastQTESkill(XEntity entity)
		{
			bool flag = entity.QTE == null || !entity.QTE.IsInAnyState();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				List<uint> qtelist = entity.QTE.QTEList;
				bool flag2 = qtelist.Count == 0;
				if (flag2)
				{
					result = false;
				}
				else
				{
					int num = XSingleton<XCommon>.singleton.RandomInt(0, qtelist.Count);
					for (int i = 0; i < qtelist.Count; i++)
					{
						uint num2 = qtelist[(i + num) % qtelist.Count];
						bool flag3 = false;
						for (int j = 0; j < entity.QTE.QTEList.Count; j++)
						{
							bool flag4 = entity.QTE.QTEList[j] == num2;
							if (flag4)
							{
								flag3 = true;
								break;
							}
						}
						bool flag5 = !flag3;
						if (!flag5)
						{
							bool flag6 = entity.SkillMgr.IsCooledDown(num2);
							if (flag6)
							{
								entity.Net.ReportSkillAction(null, num2, -1);
							}
						}
					}
					result = false;
				}
			}
			return result;
		}

		public bool CastDashSkill(XEntity entity)
		{
			uint dashIdentity = entity.SkillMgr.GetDashIdentity();
			bool flag = dashIdentity == 0U || !entity.SkillMgr.IsCooledDown(dashIdentity);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				entity.Net.ReportSkillAction(null, dashIdentity, 1);
				result = true;
			}
			return result;
		}

		public uint GetNextComboSkill(XEntity entity, uint skillid)
		{
			Vector3 position = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position;
			Vector3 position2 = entity.EngineObject.Position;
			float magnitude = (position - position2).magnitude;
			string text = "";
			int num = -1;
			for (int i = 0; i < entity.SkillMgr.SkillOrder.Count; i++)
			{
				XSkillCore xskillCore = entity.SkillMgr.SkillOrder[i] as XSkillCore;
				bool flag = xskillCore != null && xskillCore.ID == skillid;
				if (flag)
				{
					text = xskillCore.Soul.Name;
					break;
				}
			}
			bool flag2 = text == "";
			if (flag2)
			{
				XSkillCore physicalSkill = entity.SkillMgr.GetPhysicalSkill();
				bool flag3 = physicalSkill.ID == skillid;
				if (flag3)
				{
					text = physicalSkill.Soul.Name;
				}
			}
			for (int j = 0; j < XArenaDocument.SkillComboTable.Table.Length; j++)
			{
				bool flag4 = XArenaDocument.SkillComboTable.Table[j].skillname == text;
				if (flag4)
				{
					num = j;
					break;
				}
			}
			bool flag5 = num == -1;
			uint result;
			if (flag5)
			{
				result = 0U;
			}
			else
			{
				List<XSkillCore> list = new List<XSkillCore>();
				List<string> nextSkill = this.GetNextSkill(text);
				bool flag6 = nextSkill != null;
				if (flag6)
				{
					for (int k = 0; k < nextSkill.Count; k++)
					{
						for (int l = 0; l < entity.SkillMgr.SkillOrder.Count; l++)
						{
							XSkillCore xskillCore2 = entity.SkillMgr.SkillOrder[l] as XSkillCore;
							bool flag7 = xskillCore2 != null && xskillCore2.Soul.Name == nextSkill[k];
							if (flag7)
							{
								list.Add(xskillCore2);
								break;
							}
						}
						XSkillCore physicalSkill2 = entity.SkillMgr.GetPhysicalSkill();
						bool flag8 = physicalSkill2.Soul.Name == nextSkill[k];
						if (flag8)
						{
							list.Add(physicalSkill2);
						}
					}
				}
				bool flag9 = list.Count == 0;
				if (flag9)
				{
					result = 0U;
				}
				else
				{
					int num2 = XSingleton<XCommon>.singleton.RandomInt(0, list.Count);
					for (int m = 0; m < list.Count; m++)
					{
						XSkillCore xskillCore3 = list[(m + num2) % list.Count];
						bool flag10 = entity.SkillMgr.IsCooledDown(xskillCore3);
						if (flag10)
						{
							bool flag11 = XSingleton<XCommon>.singleton.IsLess(magnitude, xskillCore3.CastRangeUpper) && XSingleton<XCommon>.singleton.IsGreater(magnitude, xskillCore3.CastRangeLower);
							if (flag11)
							{
								return xskillCore3.ID;
							}
						}
					}
					result = 0U;
				}
			}
			return result;
		}

		public bool IsSkillCooledDown(GameObject go, uint skillid)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(go.transform.name));
			bool flag = entity == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = entity.SkillMgr.IsCooledDown(skillid);
				result = flag2;
			}
			return result;
		}

		public bool CastStartSkill(XEntity host, XEntity target)
		{
			int profIndex = this.GetProfIndex(host);
			List<string> startSkill = this.GetStartSkill(profIndex);
			List<XSkillCore> list = new List<XSkillCore>();
			for (int i = 0; i < startSkill.Count; i++)
			{
				bool flag = host.SkillMgr.GetPhysicalSkill().Soul.Name == startSkill[i];
				if (flag)
				{
					list.Add(host.SkillMgr.GetPhysicalSkill());
					break;
				}
				for (int j = 0; j < host.SkillMgr.SkillOrder.Count; j++)
				{
					XSkillCore xskillCore = host.SkillMgr.SkillOrder[j] as XSkillCore;
					bool flag2 = xskillCore != null && xskillCore.Soul.Name == startSkill[i];
					if (flag2)
					{
						list.Add(xskillCore);
						break;
					}
				}
			}
			Vector3 position = target.EngineObject.Position;
			Vector3 position2 = host.EngineObject.Position;
			float magnitude = (position - position2).magnitude;
			int num = XSingleton<XCommon>.singleton.RandomInt(0, list.Count);
			for (int k = 0; k < list.Count; k++)
			{
				XSkillCore xskillCore2 = list[(k + num) % list.Count];
				bool flag3 = host.SkillMgr.IsCooledDown(xskillCore2);
				if (flag3)
				{
					bool flag4 = XSingleton<XCommon>.singleton.IsLess(magnitude, xskillCore2.CastRangeUpper) && XSingleton<XCommon>.singleton.IsGreater(magnitude, xskillCore2.CastRangeLower);
					if (flag4)
					{
						host.Net.ReportSkillAction(target, xskillCore2.ID, -1);
					}
				}
			}
			return false;
		}

		public bool ResetSkillSelect(XEntity host, FilterSkillArg skillarg)
		{
			bool mAIArgUseInstall = skillarg.mAIArgUseInstall;
			host.AI.ClearCanCastSkill();
			for (int i = 0; i < host.SkillMgr.SkillOrder.Count; i++)
			{
				XSkillCore xskillCore = host.SkillMgr.SkillOrder[i] as XSkillCore;
				bool flag = xskillCore != null;
				if (flag)
				{
					SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(xskillCore.ID, 1U);
					int num = (int)((skillConfig != null) ? skillConfig.SkillType : 0);
					bool flag2 = true;
					bool flag3 = host.MobbedBy != null;
					if (flag3)
					{
						bool flag4 = host.AI.IsLinkSkillCannotCast(xskillCore.ID);
						if (flag4)
						{
							flag2 = false;
						}
					}
					bool flag5 = xskillCore.ID != host.SkillMgr.GetRecoveryIdentity() && xskillCore.ID != host.SkillMgr.GetBrokenIdentity() && xskillCore.ID != host.SkillMgr.GetDashIdentity() && num != 5 && flag2;
					if (flag5)
					{
						host.AI.AddCanCastSkill(xskillCore);
					}
				}
			}
			bool flag6 = host.IsPlayer && mAIArgUseInstall;
			if (flag6)
			{
				this.SelectInstallSkill(host);
			}
			bool flag7 = skillarg.mAIArgMaxSkillNum != 0;
			if (flag7)
			{
				int num2 = Math.Abs(skillarg.mAIArgMaxSkillNum);
				bool flag8 = num2 < host.AI.CanCastSkillCount;
				if (flag8)
				{
					bool flag9 = skillarg.mAIArgMaxSkillNum < 0;
					if (flag9)
					{
						host.AI.RemoveCanCastSkillRange(num2, host.AI.CanCastSkillCount - num2);
					}
					else
					{
						bool flag10 = host.AI.RangeSkillCount == 0;
						if (flag10)
						{
							for (int j = 0; j < num2; j++)
							{
								int index = XSingleton<XCommon>.singleton.RandomInt(0, host.AI.CanCastSkillCount);
								host.AI.AddRangeSkill(host.AI.GetCanCastSkill(index));
								host.AI.RemoveCanCastSkillAt(index);
							}
						}
						host.AI.CopyRange2CanCast();
					}
				}
			}
			return true;
		}

		public bool SelectInstallSkill(XEntity host)
		{
			bool isPlayer = host.IsPlayer;
			if (isPlayer)
			{
				List<XSkillCore> list = ListPool<XSkillCore>.Get();
				for (int i = 0; i < (host.Attributes as XPlayerAttributes).skillSlot.Length; i++)
				{
					bool flag = false;
					uint num = (host.Attributes as XPlayerAttributes).skillSlot[i];
					for (int j = 0; j < host.AI.CanCastSkillCount; j++)
					{
						bool flag2 = host.AI.GetCanCastSkill(j).ID == num;
						if (flag2)
						{
							flag = true;
							break;
						}
					}
					bool flag3 = !flag;
					if (!flag3)
					{
						bool flag4 = num > 0U;
						if (flag4)
						{
							XSkillCore skill = host.SkillMgr.GetSkill(num);
							bool flag5 = skill != null;
							if (flag5)
							{
								list.Add(skill);
							}
						}
					}
				}
				host.AI.Copy2CanCastSkill(list);
				ListPool<XSkillCore>.Release(list);
			}
			bool flag6 = host.AI.CanCastSkillCount == 0;
			return !flag6;
		}

		public bool SelectMPOKSkill(XEntity host)
		{
			List<XSkillCore> list = ListPool<XSkillCore>.Get();
			float num = (float)host.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentMP_Basic);
			for (int i = 0; i < host.AI.CanCastSkillCount; i++)
			{
				XSkillCore canCastSkill = host.AI.GetCanCastSkill(i);
				uint skillHash = XSingleton<XCommon>.singleton.XHash(canCastSkill.Soul.Name);
				uint level = canCastSkill.Level;
				int skillType = XSingleton<XSkillEffectMgr>.singleton.GetSkillType(canCastSkill.ID);
				float skillCostMP = XSingleton<XSkillEffectMgr>.singleton.GetSkillCostMP(skillHash, level, host.SkillCasterTypeID);
				bool flag = skillCostMP <= num && skillCostMP >= 0f && skillType == 1;
				if (flag)
				{
					list.Add(canCastSkill);
				}
			}
			host.AI.Copy2CanCastSkill(list);
			ListPool<XSkillCore>.Release(list);
			bool flag2 = host.AI.CanCastSkillCount == 0;
			return !flag2;
		}

		public bool SelectSkillByName(XEntity host, string name)
		{
			List<XSkillCore> list = ListPool<XSkillCore>.Get();
			for (int i = 0; i < host.AI.CanCastSkillCount; i++)
			{
				XSkillCore canCastSkill = host.AI.GetCanCastSkill(i);
				bool flag = canCastSkill.Soul.Name == name;
				if (flag)
				{
					list.Add(canCastSkill);
				}
			}
			host.AI.Copy2CanCastSkill(list);
			ListPool<XSkillCore>.Release(list);
			bool flag2 = host.AI.CanCastSkillCount == 0;
			return !flag2;
		}

		public bool SelectComboSkill(XEntity host, int skilltype, string startname)
		{
			bool result = true;
			string comboSkill = host.AI.ComboSkill;
			List<XSkillCore> toRelease = ListPool<XSkillCore>.Get();
			bool flag = skilltype == 0;
			if (flag)
			{
				int profIndex = this.GetProfIndex(host);
				List<string> startSkill = this.GetStartSkill(profIndex);
				bool flag2 = !string.IsNullOrEmpty(startname);
				if (flag2)
				{
					startSkill.Clear();
					startSkill.Add(startname);
				}
				List<XSkillCore> list = ListPool<XSkillCore>.Get();
				for (int i = 0; i < startSkill.Count; i++)
				{
					string b = startSkill[i];
					bool flag3 = host.SkillMgr.GetPhysicalSkill().Soul.Name == b;
					if (flag3)
					{
						list.Add(host.SkillMgr.GetPhysicalSkill());
						break;
					}
					for (int j = 0; j < host.AI.CanCastSkillCount; j++)
					{
						XSkillCore canCastSkill = host.AI.GetCanCastSkill(j);
						bool flag4 = canCastSkill.Soul.Name == b;
						if (flag4)
						{
							list.Add(canCastSkill);
							break;
						}
					}
				}
				host.AI.Copy2CanCastSkill(list);
				ListPool<XSkillCore>.Release(list);
			}
			else
			{
				List<XSkillCore> list2 = ListPool<XSkillCore>.Get();
				List<string> nextSkill = this.GetNextSkill(comboSkill);
				bool flag5 = nextSkill != null;
				if (flag5)
				{
					for (int k = 0; k < nextSkill.Count; k++)
					{
						string b2 = nextSkill[k];
						for (int l = 0; l < host.AI.CanCastSkillCount; l++)
						{
							XSkillCore canCastSkill2 = host.AI.GetCanCastSkill(l);
							bool flag6 = canCastSkill2.Soul.Name == b2;
							if (flag6)
							{
								list2.Add(canCastSkill2);
								break;
							}
						}
						XSkillCore physicalSkill = host.SkillMgr.GetPhysicalSkill();
						bool flag7 = physicalSkill.Soul.Name == b2;
						if (flag7)
						{
							list2.Add(physicalSkill);
						}
					}
				}
				host.AI.Copy2CanCastSkill(list2);
				bool flag8 = list2.Count == 0;
				if (flag8)
				{
					host.AI.ComboSkill = "";
					result = false;
				}
				ListPool<XSkillCore>.Release(list2);
			}
			ListPool<XSkillCore>.Release(toRelease);
			return result;
		}

		public bool SelectSkillByHP(XEntity host)
		{
			List<XSkillCore> list = ListPool<XSkillCore>.Get();
			for (int i = 0; i < host.AI.CanCastSkillCount; i++)
			{
				XSkillCore canCastSkill = host.AI.GetCanCastSkill(i);
				int skillHpMaxLimit = XSingleton<XSkillEffectMgr>.singleton.GetSkillHpMaxLimit(canCastSkill.Soul.Name, 1U, host.SkillCasterTypeID);
				int skillHpMinLimit = XSingleton<XSkillEffectMgr>.singleton.GetSkillHpMinLimit(canCastSkill.Soul.Name, 1U, host.SkillCasterTypeID);
				int num = (int)(100.0 * host.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic) / host.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total));
				bool flag = (skillHpMaxLimit == 0 || num <= skillHpMaxLimit) && (skillHpMinLimit == 0 || num >= skillHpMinLimit);
				if (flag)
				{
					list.Add(canCastSkill);
				}
			}
			host.AI.Copy2CanCastSkill(list);
			ListPool<XSkillCore>.Release(list);
			bool flag2 = host.AI.CanCastSkillCount == 0;
			return !flag2;
		}

		public bool SelectSkillByCoolDown(XEntity host)
		{
			List<XSkillCore> list = ListPool<XSkillCore>.Get();
			for (int i = 0; i < host.AI.CanCastSkillCount; i++)
			{
				XSkillCore canCastSkill = host.AI.GetCanCastSkill(i);
				bool flag = host.SkillMgr.IsCooledDown(canCastSkill);
				if (flag)
				{
					list.Add(canCastSkill);
				}
			}
			host.AI.Copy2CanCastSkill(list);
			ListPool<XSkillCore>.Release(list);
			bool flag2 = host.AI.CanCastSkillCount == 0;
			return !flag2;
		}

		public bool SelectSkillByAttackField(XEntity host, XEntity target, bool detectall)
		{
			List<XSkillCore> list = ListPool<XSkillCore>.Get();
			for (int i = 0; i < host.AI.CanCastSkillCount; i++)
			{
				XSkillCore canCastSkill = host.AI.GetCanCastSkill(i);
				bool flag = target == null;
				if (flag)
				{
					bool flag2 = !canCastSkill.Soul.NeedTarget;
					if (flag2)
					{
						list.Add(canCastSkill);
					}
				}
				else
				{
					bool flag3 = canCastSkill.IsInAttckField(host.EngineObject.Position, target.EngineObject.Position - host.EngineObject.Position, target);
					if (flag3)
					{
						list.Add(canCastSkill);
					}
				}
			}
			host.AI.Copy2CanCastSkill(list);
			ListPool<XSkillCore>.Release(list);
			bool flag4 = host.AI.CanCastSkillCount == 0;
			return !flag4;
		}

		public bool SelectSkillByCombo(XEntity host, int skilltype, string skillname)
		{
			return this.SelectComboSkill(host, skilltype, skillname);
		}

		public bool SelectSkill(XEntity host, XEntity target, FilterSkillArg skillarg)
		{
			this.ResetSkillSelect(host, skillarg);
			bool flag = !skillarg.mAIArgUseCoolDown;
			if (flag)
			{
				host.AI.IgnoreSkillCD = true;
			}
			else
			{
				host.AI.IgnoreSkillCD = false;
			}
			bool flag2 = skillarg.mAIArgUseMP && !this.SelectMPOKSkill(host);
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				bool flag3 = skillarg.mAIArgUseName && !this.SelectSkillByName(host, skillarg.mAIArgSkillName);
				if (flag3)
				{
					result = false;
				}
				else
				{
					bool flag4 = skillarg.mAIArgUseHP && !this.SelectSkillByHP(host);
					if (flag4)
					{
						result = false;
					}
					else
					{
						bool flag5 = skillarg.mAIArgUseCoolDown && !this.SelectSkillByCoolDown(host);
						if (flag5)
						{
							result = false;
						}
						else
						{
							bool flag6 = skillarg.mAIArgUseAttackField && !this.SelectSkillByAttackField(host, target, skillarg.mAIArgDetectAllPlayInAttackField);
							if (flag6)
							{
								result = false;
							}
							else
							{
								bool flag7 = skillarg.mAIArgUseCombo && !this.SelectSkillByCombo(host, skillarg.mAIArgSkillType, skillarg.mAIArgSkillName);
								if (flag7)
								{
									result = false;
								}
								else
								{
									bool flag8 = host.AI.CanCastSkillCount == 0;
									result = !flag8;
								}
							}
						}
					}
				}
			}
			return result;
		}

		public bool DoSelectInOrder(XEntity host)
		{
			bool flag = host.AI.CanCastSkillCount == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XSkillCore canCastSkill = host.AI.GetCanCastSkill(0);
				host.AI.ClearCanCastSkill();
				host.AI.AddCanCastSkill(canCastSkill);
				result = true;
			}
			return result;
		}

		public bool DoSelectRandom(XEntity host)
		{
			bool flag = host.AI.CanCastSkillCount == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XSkillCore canCastSkill = host.AI.GetCanCastSkill(XSingleton<XCommon>.singleton.RandomInt(0, host.AI.CanCastSkillCount));
				host.AI.ClearCanCastSkill();
				host.AI.AddCanCastSkill(canCastSkill);
				result = true;
			}
			return result;
		}

		public bool DoCastSkill(XEntity host, XEntity target)
		{
			bool flag = host.AI.CanCastSkillCount == 0;
			bool result;
			if (flag)
			{
				host.AI.ComboSkill = "";
				result = false;
			}
			else
			{
				XSkillCore canCastSkill = host.AI.GetCanCastSkill(0);
				bool ignoreSkillCD = host.AI.IgnoreSkillCD;
				if (ignoreSkillCD)
				{
					host.SkillMgr.CoolDown(canCastSkill.ID);
				}
				host.AI.ComboSkill = canCastSkill.Soul.Name;
				host.Net.ReportSkillAction(target, canCastSkill.ID, -1);
				XSecurityAIInfo xsecurityAIInfo = XSecurityAIInfo.TryGetStatistics(host);
				bool flag2 = xsecurityAIInfo != null;
				if (flag2)
				{
					bool flag3 = !host.IsPlayer && !host.IsRole;
					if (flag3)
					{
						xsecurityAIInfo.OnSkillAttack();
					}
				}
				result = true;
			}
			return result;
		}

		public bool StopCastingSkill(XEntity host)
		{
			host.Skill.EndSkill(false, false);
			return true;
		}

		private Dictionary<int, List<string>> _start_skills = new Dictionary<int, List<string>>();

		private Dictionary<string, List<string>> _next_skills = new Dictionary<string, List<string>>();

		private bool _inited = false;
	}
}
