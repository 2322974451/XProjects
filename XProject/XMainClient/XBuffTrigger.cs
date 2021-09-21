using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000896 RID: 2198
	internal abstract class XBuffTrigger : BuffEffect
	{
		// Token: 0x060085D3 RID: 34259 RVA: 0x0010C1E4 File Offset: 0x0010A3E4
		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.BuffTriggerCond == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				switch (rowData.BuffTriggerCond)
				{
				case 1:
					buff.AddEffect(new XBuffTriggerByBeHit(buff));
					break;
				case 2:
					buff.AddEffect(new XBuffTriggerByLife(buff));
					break;
				case 3:
					buff.AddEffect(new XBuffTriggerAlways(buff));
					break;
				case 4:
					buff.AddEffect(new XBuffTriggerByHit(buff));
					break;
				case 5:
					buff.AddEffect(new XBuffTriggerByCombo(buff));
					break;
				case 7:
					buff.AddEffect(new XBuffTriggerByDeath(buff));
					break;
				case 8:
					buff.AddEffect(new XBuffTriggerByQTE(buff));
					break;
				case 9:
					buff.AddEffect(new XBuffTriggerWhenRemove(buff));
					break;
				case 10:
					buff.AddEffect(new XBuffTriggerByCastSkill(buff));
					break;
				case 11:
					buff.AddEffect(new XBuffTriggerByStacking(buff));
					break;
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060085D4 RID: 34260 RVA: 0x0010C2E8 File Offset: 0x0010A4E8
		public XBuffTrigger(XBuff buff)
		{
			this._Buff = buff;
			BuffTable.RowData buffInfo = buff.BuffInfo;
			this._triggerRate = buffInfo.BuffTriggerRate;
			bool flag = buffInfo.BuffTriggerBuff.Count > 0;
			if (flag)
			{
				bool flag2 = buffInfo.BuffTriggerBuff[0, 0] == 0 && buffInfo.BuffTriggerBuff[0, 1] == 0;
				if (flag2)
				{
					this._bRandomTriggerBuff = true;
				}
			}
			this.m_bIsTriggerImm = buffInfo.IsTriggerImm;
			this._triggerSkillID = XSingleton<XCommon>.singleton.XHash(buffInfo.BuffTriggerSkill);
			bool flag3 = this._triggerRate == 0f;
			if (flag3)
			{
				this._triggerRate = 1f;
			}
		}

		// Token: 0x17002A2A RID: 10794
		// (get) Token: 0x060085D5 RID: 34261 RVA: 0x0010C3D4 File Offset: 0x0010A5D4
		public XEntity Entity
		{
			get
			{
				return this._entity;
			}
		}

		// Token: 0x060085D6 RID: 34262 RVA: 0x0010C3EC File Offset: 0x0010A5EC
		public virtual bool CheckTriggerCondition()
		{
			return true;
		}

		// Token: 0x060085D7 RID: 34263 RVA: 0x0010C3FF File Offset: 0x0010A5FF
		protected void _SetTarget(XEntity entity)
		{
			this._Target = entity;
		}

		// Token: 0x060085D8 RID: 34264 RVA: 0x0010C40C File Offset: 0x0010A60C
		private void AddTriggerBuff()
		{
			bool flag = this._Buff.BuffInfo.BuffTriggerBuff.Count == 0;
			if (!flag)
			{
				int num = 0;
				int num2 = this._Buff.BuffInfo.BuffTriggerBuff.Count;
				bool bRandomTriggerBuff = this._bRandomTriggerBuff;
				if (bRandomTriggerBuff)
				{
					num = XSingleton<XCommon>.singleton.RandomInt(1, num2);
					num2 = num + 1;
				}
				for (int i = num; i < num2; i++)
				{
					XBuffAddEventArgs @event = XEventPool<XBuffAddEventArgs>.GetEvent();
					@event.xBuffDesc.BuffID = this._Buff.BuffInfo.BuffTriggerBuff[i, 0];
					@event.xBuffDesc.BuffLevel = this._Buff.BuffInfo.BuffTriggerBuff[i, 1];
					@event.xBuffDesc.CasterID = this._Buff.CasterID;
					@event.xBuffDesc.SkillID = this._Buff.SkillID;
					@event.Firer = this._Target;
					@event.xEffectImm = this.m_bIsTriggerImm;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
			}
		}

		// Token: 0x060085D9 RID: 34265 RVA: 0x0010C534 File Offset: 0x0010A734
		private void CastTriggerSkill()
		{
			bool flag = this._triggerSkillID == 0U;
			if (!flag)
			{
				bool flag2 = this.Entity.Net != null;
				if (flag2)
				{
					bool flag3 = this._locate != null;
					if (flag3)
					{
						this.Entity.Net.ReportSkillAction(this._locate.Target, this._triggerSkillID, -1);
					}
					else
					{
						bool flag4 = this.Entity.AI != null;
						if (flag4)
						{
							this.Entity.Net.ReportSkillAction(this.Entity.AI.Target, this._triggerSkillID, -1);
						}
					}
				}
			}
		}

		// Token: 0x060085DA RID: 34266 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnTrigger()
		{
		}

		// Token: 0x060085DB RID: 34267 RVA: 0x0010C5D4 File Offset: 0x0010A7D4
		public void Trigger()
		{
			bool flag = this._TriggerCondition.CanTrigger();
			if (flag)
			{
				bool flag2 = this.CheckTriggerCondition();
				if (flag2)
				{
					float num = XSingleton<XCommon>.singleton.RandomFloat(0f, 1f);
					bool flag3 = num <= this._triggerRate;
					if (flag3)
					{
						this._TriggerCondition.OnTrigger();
						this.OnTrigger();
						this.AddTriggerBuff();
						bool bIsTriggerImm = this.m_bIsTriggerImm;
						if (bIsTriggerImm)
						{
							this.CastTriggerSkill();
						}
						else
						{
							this._bSkillTriggered = true;
						}
					}
					else
					{
						this._TriggerCondition.OnRandFail();
					}
				}
			}
		}

		// Token: 0x060085DC RID: 34268 RVA: 0x0010C66C File Offset: 0x0010A86C
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this._entity = entity;
			this._Target = entity;
			this._triggerRate += pEffectHelper.GetBuffTriggerRate();
			bool isGlobalTrigger = this._Buff.BuffInfo.IsGlobalTrigger;
			if (isGlobalTrigger)
			{
				this._TriggerCondition = entity.Buffs.GetTriggerState(this._Buff.BuffInfo);
			}
			else
			{
				this._TriggerCondition = new XTriggerCondition(this._Buff.BuffInfo);
			}
			this._locate = (this._entity.IsPlayer ? (this._entity.GetXComponent(XLocateTargetComponent.uuID) as XLocateTargetComponent) : null);
			this._bSkillTriggered = false;
		}

		// Token: 0x060085DD RID: 34269 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
		}

		// Token: 0x060085DE RID: 34270 RVA: 0x0010C71C File Offset: 0x0010A91C
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool bSkillTriggered = this._bSkillTriggered;
			if (bSkillTriggered)
			{
				this._bSkillTriggered = false;
				this.CastTriggerSkill();
			}
		}

		// Token: 0x060085DF RID: 34271 RVA: 0x0010C74C File Offset: 0x0010A94C
		protected float _GetTriggerParam(BuffTable.RowData buffInfo, int index)
		{
			bool flag = buffInfo == null || buffInfo.BuffTriggerParam == null || buffInfo.BuffTriggerParam.Length <= index;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				result = float.Parse(buffInfo.BuffTriggerParam[index]);
			}
			return result;
		}

		// Token: 0x060085E0 RID: 34272 RVA: 0x0010C794 File Offset: 0x0010A994
		protected int _GetTriggerParamInt(BuffTable.RowData buffInfo, int index)
		{
			bool flag = buffInfo == null || buffInfo.BuffTriggerParam == null || buffInfo.BuffTriggerParam.Length <= index;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = int.Parse(buffInfo.BuffTriggerParam[index]);
			}
			return result;
		}

		// Token: 0x060085E1 RID: 34273 RVA: 0x0010C7D8 File Offset: 0x0010A9D8
		protected string _GetTriggerParamStr(BuffTable.RowData buffInfo, int index)
		{
			bool flag = buffInfo == null || buffInfo.BuffTriggerParam == null || buffInfo.BuffTriggerParam.Length <= index;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				result = buffInfo.BuffTriggerParam[index];
			}
			return result;
		}

		// Token: 0x0400299F RID: 10655
		private float _triggerRate = 0f;

		// Token: 0x040029A0 RID: 10656
		private bool _bRandomTriggerBuff = false;

		// Token: 0x040029A1 RID: 10657
		private uint _triggerSkillID = 0U;

		// Token: 0x040029A2 RID: 10658
		private XTriggerCondition _TriggerCondition = null;

		// Token: 0x040029A3 RID: 10659
		private XEntity _entity;

		// Token: 0x040029A4 RID: 10660
		protected XBuff _Buff;

		// Token: 0x040029A5 RID: 10661
		private XEntity _Target = null;

		// Token: 0x040029A6 RID: 10662
		private XLocateTargetComponent _locate = null;

		// Token: 0x040029A7 RID: 10663
		private bool _bSkillTriggered = false;

		// Token: 0x040029A8 RID: 10664
		protected bool m_bIsTriggerImm = false;
	}
}
