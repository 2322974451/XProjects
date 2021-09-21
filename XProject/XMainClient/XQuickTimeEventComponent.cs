using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FC5 RID: 4037
	internal class XQuickTimeEventComponent : XComponent
	{
		// Token: 0x170036B5 RID: 14005
		// (get) Token: 0x0600D1E6 RID: 53734 RVA: 0x0030D600 File Offset: 0x0030B800
		public override uint ID
		{
			get
			{
				return XQuickTimeEventComponent.uuID;
			}
		}

		// Token: 0x0600D1E7 RID: 53735 RVA: 0x0030D618 File Offset: 0x0030B818
		public bool IsInReservedState()
		{
			return (this._state & 4094UL) > 0UL;
		}

		// Token: 0x0600D1E8 RID: 53736 RVA: 0x0030D63C File Offset: 0x0030B83C
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

		// Token: 0x0600D1E9 RID: 53737 RVA: 0x0030D684 File Offset: 0x0030B884
		public bool IsInAnyState()
		{
			return this._state > 0UL;
		}

		// Token: 0x0600D1EA RID: 53738 RVA: 0x0030D6A0 File Offset: 0x0030B8A0
		public bool IsInIgnorePresentState()
		{
			return this.IsInState(20U) || this.IsInState(12U) || this.IsInState(13U) || this.IsInState(14U) || this.IsInState(15U);
		}

		// Token: 0x170036B6 RID: 14006
		// (get) Token: 0x0600D1EB RID: 53739 RVA: 0x0030D6E8 File Offset: 0x0030B8E8
		public List<uint> QTEList
		{
			get
			{
				return this._qte_skills;
			}
		}

		// Token: 0x0600D1EC RID: 53740 RVA: 0x0030D700 File Offset: 0x0030B900
		public override void Attached()
		{
			bool isPlayer = this._entity.IsPlayer;
			if (isPlayer)
			{
				this._doc = XDocuments.GetSpecificDocument<XBattleSkillDocument>(XBattleSkillDocument.uuID);
			}
		}

		// Token: 0x0600D1ED RID: 53741 RVA: 0x0030D72D File Offset: 0x0030B92D
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_QTE, new XComponent.XEventHandler(this.OnQuickTimeEvent));
			base.RegisterEvent(XEventDefine.XEvent_OnJAPassed, new XComponent.XEventHandler(this.OnJAPassed));
		}

		// Token: 0x0600D1EE RID: 53742 RVA: 0x0030D75C File Offset: 0x0030B95C
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

		// Token: 0x0600D1EF RID: 53743 RVA: 0x0030D7A8 File Offset: 0x0030B9A8
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

		// Token: 0x0600D1F0 RID: 53744 RVA: 0x0030DAD0 File Offset: 0x0030BCD0
		public void OnSkillCasted(uint id, int slot, bool succeed)
		{
			this._qte_skills.Remove(id);
			bool flag = this._doc != null;
			if (flag)
			{
				this._doc.OnSkillCasted(id, slot, succeed);
			}
		}

		// Token: 0x04005F3B RID: 24379
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XQuickTimeEventComponent");

		// Token: 0x04005F3C RID: 24380
		public static uint MAXQTE = 63U;

		// Token: 0x04005F3D RID: 24381
		private ulong _state = 0UL;

		// Token: 0x04005F3E RID: 24382
		private XBattleSkillDocument _doc = null;

		// Token: 0x04005F3F RID: 24383
		private List<uint> _qte_skills = new List<uint>();
	}
}
