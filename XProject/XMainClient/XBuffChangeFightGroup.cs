using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200089D RID: 2205
	internal class XBuffChangeFightGroup : BuffEffect
	{
		// Token: 0x060085FF RID: 34303 RVA: 0x0010CE50 File Offset: 0x0010B050
		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.ChangeFightGroup == -1;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffChangeFightGroup(buff, (uint)rowData.ChangeFightGroup));
				result = true;
			}
			return result;
		}

		// Token: 0x06008600 RID: 34304 RVA: 0x0010CE87 File Offset: 0x0010B087
		public XBuffChangeFightGroup(XBuff buff, uint fightgroup)
		{
			this.m_FightGroup = fightgroup;
		}

		// Token: 0x06008601 RID: 34305 RVA: 0x0010CE98 File Offset: 0x0010B098
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this.m_PreservedFightGroup = entity.Attributes.FightGroup;
			entity.Attributes.OnFightGroupChange(this.m_FightGroup);
		}

		// Token: 0x06008602 RID: 34306 RVA: 0x0010CEBE File Offset: 0x0010B0BE
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			entity.Attributes.OnFightGroupChange(this.m_PreservedFightGroup);
		}

		// Token: 0x040029B9 RID: 10681
		private uint m_FightGroup;

		// Token: 0x040029BA RID: 10682
		private uint m_PreservedFightGroup;
	}
}
