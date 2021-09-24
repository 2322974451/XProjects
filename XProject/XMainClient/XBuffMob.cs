using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffMob : BuffEffect
	{

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

		public XBuffMob(uint templateID, XBuff buff)
		{
			this._MobTemplateID = templateID;
			this._Buff = buff;
		}

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

		public override void OnRemove(XEntity entity, bool IsReplaced)
		{
			XSingleton<XEntityMgr>.singleton.DestroyEntity(this._Mob);
			this._Mob = null;
		}

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

		private XEntity _entity;

		private XEntity _Mob = null;

		private XBuff _Buff;

		private uint _MobTemplateID = 0U;
	}
}
