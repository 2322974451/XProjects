using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffReduceDamage : BuffEffect
	{

		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.DamageReduce.Count == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffReduceDamage(ref rowData.DamageReduce, rowData.BuffID));
				result = true;
			}
			return result;
		}

		public XBuffReduceDamage(ref SeqListRef<float> reducePecents, int buffID)
		{
			this._buffID = buffID;
			this.m_Data.SetRange(0.0, 1.0, 1.0, 0.0);
			this.m_Data.Init(ref reducePecents);
		}

		public override XBuffEffectPrioriy Priority
		{
			get
			{
				return XBuffEffectPrioriy.BEP_ReduceDamage;
			}
		}

		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this._entity = entity;
		}

		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
		}

		public override void OnAttributeChanged(XAttrChangeEventArgs e)
		{
			bool flag = e.AttrKey == XAttributeDefine.XAttr_CurrentHP_Basic;
			if (flag)
			{
				bool flag2 = this.m_Data.GetData(this._entity.Attributes.HPPercent) < 1E-06;
				if (flag2)
				{
					XBuffRemoveEventArgs @event = XEventPool<XBuffRemoveEventArgs>.GetEvent();
					@event.xBuffID = this._buffID;
					@event.Firer = this._entity;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
					XSingleton<XDebug>.singleton.AddGreenLog("delete reduce damage buff", null, null, null, null, null);
				}
			}
		}

		public override void OnBuffEffect(HurtInfo rawInput, ProjectDamageResult result)
		{
			int num = (int)result.Value;
			double hppercent = rawInput.Target.Attributes.HPPercent;
			result.Value *= 1.0 - this.m_Data.GetData(hppercent);
			int num2 = (int)result.Value;
		}

		private int _buffID;

		private XPieceWiseDataMgr m_Data = new XPieceWiseDataMgr();

		private XEntity _entity;
	}
}
