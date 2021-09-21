using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008AB RID: 2219
	internal class XBuffKill : BuffEffect
	{
		// Token: 0x06008645 RID: 34373 RVA: 0x0010E404 File Offset: 0x0010C604
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

		// Token: 0x17002A2F RID: 10799
		// (get) Token: 0x06008646 RID: 34374 RVA: 0x0010E434 File Offset: 0x0010C634
		public override XBuffEffectPrioriy Priority
		{
			get
			{
				return XBuffEffectPrioriy.BEP_Kill;
			}
		}

		// Token: 0x06008647 RID: 34375 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
		}

		// Token: 0x06008648 RID: 34376 RVA: 0x0010E448 File Offset: 0x0010C648
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
