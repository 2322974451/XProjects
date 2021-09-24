using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffKill : BuffEffect
	{

		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.Kill == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffKill());
				result = true;
			}
			return result;
		}

		public override XBuffEffectPrioriy Priority
		{
			get
			{
				return XBuffEffectPrioriy.BEP_Kill;
			}
		}

		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
		}

		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			bool flag = !IsReplaced && !entity.IsDead && !entity.Buffs.bLeavingScene && !entity.Buffs.bDestroying;
			if (flag)
			{
				XSingleton<XDeath>.singleton.DeathDetect(entity, null, true);
			}
		}
	}
}
