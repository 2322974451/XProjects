using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffChangeFightGroup : BuffEffect
	{

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

		public XBuffChangeFightGroup(XBuff buff, uint fightgroup)
		{
			this.m_FightGroup = fightgroup;
		}

		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this.m_PreservedFightGroup = entity.Attributes.FightGroup;
			entity.Attributes.OnFightGroupChange(this.m_FightGroup);
		}

		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			entity.Attributes.OnFightGroupChange(this.m_PreservedFightGroup);
		}

		private uint m_FightGroup;

		private uint m_PreservedFightGroup;
	}
}
