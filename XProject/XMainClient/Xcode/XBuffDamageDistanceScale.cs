using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffDamageDistanceScale : BuffEffect
	{

		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.ChangeCastDamageByDistance.Count == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffDamageDistanceScale(buff));
				result = true;
			}
			return result;
		}

		public XBuffDamageDistanceScale(XBuff buff)
		{
			this._buff = buff;
			BuffTable.RowData buffInfo = buff.BuffInfo;
			this.m_Data.SetRange(0.0, 0.0, 10000.0, 0.0);
			this.m_Data.Init(ref buffInfo.ChangeCastDamageByDistance);
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
			bool flag = rawInput.SkillID == 0U;
			if (!flag)
			{
				bool flag2 = this._entity == null || rawInput.Target == null;
				if (!flag2)
				{
					double x = (double)Vector3.Distance(this._entity.MoveObj.Position, rawInput.Target.MoveObj.Position);
					result.Value *= 1.0 + this.m_Data.GetData(x);
				}
			}
		}

		private XBuff _buff = null;

		private XEntity _entity;

		private XPieceWiseDataMgr m_Data = new XPieceWiseDataMgr();
	}
}
