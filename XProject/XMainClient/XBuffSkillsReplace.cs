using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008A9 RID: 2217
	internal class XBuffSkillsReplace : BuffEffect
	{
		// Token: 0x0600863B RID: 34363 RVA: 0x0010E1DC File Offset: 0x0010C3DC
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

		// Token: 0x0600863C RID: 34364 RVA: 0x0010E212 File Offset: 0x0010C412
		public XBuffSkillsReplace(XBuff _Buff)
		{
			this.m_Buff = _Buff;
		}

		// Token: 0x0600863D RID: 34365 RVA: 0x0010E223 File Offset: 0x0010C423
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this.m_Entity = entity;
			XBuffSkillsReplace.DoAdd(entity, ref this.m_Buff.BuffInfo.SkillsReplace);
		}

		// Token: 0x0600863E RID: 34366 RVA: 0x0010E244 File Offset: 0x0010C444
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			XBuffSkillsReplace.DoRemove(entity, ref this.m_Buff.BuffInfo.SkillsReplace);
		}

		// Token: 0x0600863F RID: 34367 RVA: 0x0010E260 File Offset: 0x0010C460
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

		// Token: 0x06008640 RID: 34368 RVA: 0x0010E2C0 File Offset: 0x0010C4C0
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

		// Token: 0x06008641 RID: 34369 RVA: 0x0010E32C File Offset: 0x0010C52C
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

		// Token: 0x040029DB RID: 10715
		private XBuff m_Buff;

		// Token: 0x040029DC RID: 10716
		private XEntity m_Entity;
	}
}
