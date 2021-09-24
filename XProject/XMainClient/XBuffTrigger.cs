using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal abstract class XBuffTrigger : BuffEffect
	{

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

		public XEntity Entity
		{
			get
			{
				return this._entity;
			}
		}

		public virtual bool CheckTriggerCondition()
		{
			return true;
		}

		protected void _SetTarget(XEntity entity)
		{
			this._Target = entity;
		}

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

		protected virtual void OnTrigger()
		{
		}

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

		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
		}

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

		private float _triggerRate = 0f;

		private bool _bRandomTriggerBuff = false;

		private uint _triggerSkillID = 0U;

		private XTriggerCondition _TriggerCondition = null;

		private XEntity _entity;

		protected XBuff _Buff;

		private XEntity _Target = null;

		private XLocateTargetComponent _locate = null;

		private bool _bSkillTriggered = false;

		protected bool m_bIsTriggerImm = false;
	}
}
