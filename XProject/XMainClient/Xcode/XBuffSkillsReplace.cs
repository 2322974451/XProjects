using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffSkillsReplace : BuffEffect
	{

		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.SkillsReplace.Count == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffSkillsReplace(buff));
				result = true;
			}
			return result;
		}

		public XBuffSkillsReplace(XBuff _Buff)
		{
			this.m_Buff = _Buff;
		}

		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this.m_Entity = entity;
			XBuffSkillsReplace.DoAdd(entity, ref this.m_Buff.BuffInfo.SkillsReplace);
		}

		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			XBuffSkillsReplace.DoRemove(entity, ref this.m_Buff.BuffInfo.SkillsReplace);
		}

		public static void TrySkillsReplace(XEntity entity, UIBuffInfo uibuffInfo, bool bOpen)
		{
			bool flag = uibuffInfo == null || uibuffInfo.buffInfo == null || uibuffInfo.buffInfo.SkillsReplace.Count == 0;
			if (!flag)
			{
				if (bOpen)
				{
					XBuffSkillsReplace.DoAdd(entity, ref uibuffInfo.buffInfo.SkillsReplace);
				}
				else
				{
					XBuffSkillsReplace.DoRemove(entity, ref uibuffInfo.buffInfo.SkillsReplace);
				}
			}
		}

		public static void DoAdd(XEntity entity, ref SeqListRef<string> list)
		{
			bool flag = entity == null || entity.Skill == null;
			if (!flag)
			{
				for (int i = 0; i < list.Count; i++)
				{
					entity.Skill.SetSkillReplace(XSingleton<XCommon>.singleton.XHash(list[i, 0]), XSingleton<XCommon>.singleton.XHash(list[i, 1]));
				}
			}
		}

		public static void DoRemove(XEntity entity, ref SeqListRef<string> list)
		{
			bool flag = entity == null || entity.Skill == null;
			if (!flag)
			{
				for (int i = 0; i < list.Count; i++)
				{
					entity.Skill.SetSkillReplace(XSingleton<XCommon>.singleton.XHash(list[i, 0]), 0U);
				}
			}
		}

		private XBuff m_Buff;

		private XEntity m_Entity;
	}
}
