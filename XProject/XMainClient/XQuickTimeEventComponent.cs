using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XQuickTimeEventComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XQuickTimeEventComponent.uuID;
			}
		}

		public bool IsInReservedState()
		{
			return (this._state & 4094UL) > 0UL;
		}

		public bool IsInState(uint state)
		{
			bool flag = state == 0U;
			bool result;
			if (flag)
			{
				result = !this.IsInAnyState();
			}
			else
			{
				bool flag2 = state > XQuickTimeEventComponent.MAXQTE;
				result = (!flag2 && (this._state & 1UL << (int)state) > 0UL);
			}
			return result;
		}

		public bool IsInAnyState()
		{
			return this._state > 0UL;
		}

		public bool IsInIgnorePresentState()
		{
			return this.IsInState(20U) || this.IsInState(12U) || this.IsInState(13U) || this.IsInState(14U) || this.IsInState(15U);
		}

		public List<uint> QTEList
		{
			get
			{
				return this._qte_skills;
			}
		}

		public override void Attached()
		{
			bool isPlayer = this._entity.IsPlayer;
			if (isPlayer)
			{
				this._doc = XDocuments.GetSpecificDocument<XBattleSkillDocument>(XBattleSkillDocument.uuID);
			}
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_QTE, new XComponent.XEventHandler(this.OnQuickTimeEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnJAPassed, new XComponent.XEventHandler(this.OnJAPassed));
		}

		protected bool OnJAPassed(XEventArgs e)
		{
			XSkillJAPassedEventArgs xskillJAPassedEventArgs = e as XSkillJAPassedEventArgs;
			bool flag = xskillJAPassedEventArgs.Slot >= 0;
			if (flag)
			{
				bool flag2 = this._doc != null;
				if (flag2)
				{
					this._doc.Reset(xskillJAPassedEventArgs.Slot);
				}
			}
			return true;
		}

		protected bool OnQuickTimeEvent(XEventArgs e)
		{
			XSkillQTEEventArgs xskillQTEEventArgs = e as XSkillQTEEventArgs;
			bool flag = xskillQTEEventArgs.State == 0U || xskillQTEEventArgs.State > XQuickTimeEventComponent.MAXQTE;
			if (flag)
			{
				this._qte_skills.Clear();
				bool flag2 = this._doc != null;
				if (flag2)
				{
					this._doc.ResetAll(false, false);
				}
				this._state = 0UL;
			}
			else
			{
				bool on = xskillQTEEventArgs.On;
				if (on)
				{
					this._state |= 1UL << (int)xskillQTEEventArgs.State;
					XSkillMgr.XQTEInfo[] array = null;
					int qte = this._entity.SkillMgr.GetQTE(xskillQTEEventArgs.State, out array);
					int i = 0;
					int num = qte;
					while (i < num)
					{
						uint num2 = array[i].skill;
						uint skillLevel = this._entity.Attributes.SkillLevelInfo.GetSkillLevel(array[i].skill);
						SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(array[i].skill, skillLevel, this._entity.SkillCasterTypeID);
						bool flag3 = skillConfig != null && this._entity.SkillMgr.GetSkill(XSingleton<XCommon>.singleton.XHash(skillConfig.ExSkillScript)) != null;
						if (flag3)
						{
							num2 = XSingleton<XCommon>.singleton.XHash(skillConfig.ExSkillScript);
						}
						this._qte_skills.Add(num2);
						bool flag4 = this._doc != null && (long)array[i].key < (long)((ulong)XBattleSkillDocument.Total_skill_slot);
						if (flag4)
						{
							this._doc.UpdateQTE(array[i].key, num2);
						}
						i++;
					}
				}
				else
				{
					this._state &= ~(1UL << (int)xskillQTEEventArgs.State);
					XSkillMgr.XQTEInfo[] array2 = null;
					int qte2 = this._entity.SkillMgr.GetQTE(xskillQTEEventArgs.State, out array2);
					int j = 0;
					int num3 = qte2;
					while (j < num3)
					{
						this._qte_skills.Remove(array2[j].skill);
						uint skillLevel2 = this._entity.Attributes.SkillLevelInfo.GetSkillLevel(array2[j].skill);
						SkillList.RowData skillConfig2 = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(array2[j].skill, skillLevel2, this._entity.SkillCasterTypeID);
						bool flag5 = skillConfig2 != null && this._entity.SkillMgr.GetSkill(XSingleton<XCommon>.singleton.XHash(skillConfig2.ExSkillScript)) != null;
						if (flag5)
						{
							this._qte_skills.Remove(XSingleton<XCommon>.singleton.XHash(skillConfig2.ExSkillScript));
						}
						bool flag6 = this._doc != null && (long)array2[j].key < (long)((ulong)XBattleSkillDocument.Total_skill_slot);
						if (flag6)
						{
							this._doc.Reset(array2[j].key);
						}
						j++;
					}
				}
			}
			return true;
		}

		public void OnSkillCasted(uint id, int slot, bool succeed)
		{
			this._qte_skills.Remove(id);
			bool flag = this._doc != null;
			if (flag)
			{
				this._doc.OnSkillCasted(id, slot, succeed);
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XQuickTimeEventComponent");

		public static uint MAXQTE = 63U;

		private ulong _state = 0UL;

		private XBattleSkillDocument _doc = null;

		private List<uint> _qte_skills = new List<uint>();
	}
}
