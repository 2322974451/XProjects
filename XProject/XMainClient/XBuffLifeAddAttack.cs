using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffLifeAddAttack : BuffEffect
	{

		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.SelfLifeAddAttack.Count == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffLifeAddAttack(buff));
				result = true;
			}
			return result;
		}

		public XBuffLifeAddAttack(XBuff buff)
		{
			this._buff = buff;
			BuffTable.RowData buffInfo = buff.BuffInfo;
			this.m_Data.SetRange(0.0, 0.0, 1.0, 0.0);
			this.m_Data.Init(ref buffInfo.SelfLifeAddAttack);
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
			double hppercent = this._entity.Attributes.HPPercent;
			result.Value *= 1.0 + this.m_Data.GetData(hppercent);
		}

		private XBuff _buff = null;

		private XEntity _entity;

		private XPieceWiseDataMgr m_Data = new XPieceWiseDataMgr();
	}
}
