using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffTargetLifeAddAttack : BuffEffect
	{

		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.TargetLifeAddAttack.Count == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffTargetLifeAddAttack(ref rowData.TargetLifeAddAttack));
				result = true;
			}
			return result;
		}

		public XBuffTargetLifeAddAttack(ref SeqListRef<float> reducePecents)
		{
			this.m_Data.SetRange(0.0, 0.0, 1.0, 0.0);
			this.m_Data.Init(ref reducePecents);
		}

		public override XBuffEffectPrioriy Priority
		{
			get
			{
				return XBuffEffectPrioriy.BEP_TargetLifeAddAttack;
			}
		}

		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this._entity = entity;
		}

		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
		}

		public override void OnCastDamage(HurtInfo rawInput, ProjectDamageResult result)
		{
			double hppercent = rawInput.Target.Attributes.HPPercent;
			result.Value *= 1.0 + this.m_Data.GetData(hppercent);
		}

		private XPieceWiseDataMgr m_Data = new XPieceWiseDataMgr();

		private XEntity _entity;
	}
}
