using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200089C RID: 2204
	internal class XBuffMob : BuffEffect
	{
		// Token: 0x060085FA RID: 34298 RVA: 0x0010CCA8 File Offset: 0x0010AEA8
		public static bool TryCreate(BuffTable.RowData rowData, XBuff buff)
		{
			bool flag = rowData.MobID == 0U;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				buff.AddEffect(new XBuffMob(rowData.MobID, buff));
				result = true;
			}
			return result;
		}

		// Token: 0x060085FB RID: 34299 RVA: 0x0010CCDF File Offset: 0x0010AEDF
		public XBuffMob(uint templateID, XBuff buff)
		{
			this._MobTemplateID = templateID;
			this._Buff = buff;
		}

		// Token: 0x060085FC RID: 34300 RVA: 0x0010CD08 File Offset: 0x0010AF08
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			this._entity = entity;
			XEntity entity2 = XSingleton<XEntityMgr>.singleton.GetEntity(this._Buff.CasterID);
			bool flag = XEntity.ValideEntity(entity2);
			if (flag)
			{
				this._Mob = XSingleton<XEntityMgr>.singleton.CreateEntity(this._MobTemplateID, this._entity.EngineObject.Position, this._entity.EngineObject.Rotation, true, (entity2.Attributes != null) ? entity2.Attributes.FightGroup : uint.MaxValue);
				XSingleton<XSkillEffectMgr>.singleton.SetMobProperty(this._Mob, entity2, 0U);
				this._Buff.EffectData.MobID = this._Mob.ID;
				bool isBoss = entity2.IsBoss;
				if (isBoss)
				{
					XSecurityAIInfo xsecurityAIInfo = XSecurityAIInfo.TryGetStatistics(entity2);
					bool flag2 = xsecurityAIInfo != null;
					if (flag2)
					{
						xsecurityAIInfo.OnExternalCallMonster();
					}
				}
			}
		}

		// Token: 0x060085FD RID: 34301 RVA: 0x0010CDE1 File Offset: 0x0010AFE1
		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			XSingleton<XEntityMgr>.singleton.DestroyEntity(this._Mob);
			this._Mob = null;
		}

		// Token: 0x060085FE RID: 34302 RVA: 0x0010CDFC File Offset: 0x0010AFFC
		public override void OnUpdate()
		{
			bool flag = !XEntity.ValideEntity(this._Mob);
			if (flag)
			{
				XBuffRemoveEventArgs @event = XEventPool<XBuffRemoveEventArgs>.GetEvent();
				@event.xBuffID = this._Buff.ID;
				@event.Firer = this._entity;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x040029B5 RID: 10677
		private XEntity _entity;

		// Token: 0x040029B6 RID: 10678
		private XEntity _Mob = null;

		// Token: 0x040029B7 RID: 10679
		private XBuff _Buff;

		// Token: 0x040029B8 RID: 10680
		private uint _MobTemplateID = 0U;
	}
}
