using System;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_SkillResult
	{

		public static void Process(PtcG2C_SkillResult roPtc)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(roPtc.Data.FirerID);
			bool flag = entity == null;
			if (!flag)
			{
				bool bulletIDSpecified = roPtc.Data.BulletIDSpecified;
				if (bulletIDSpecified)
				{
					XBulletMgr.KeyOfBullet id = new XBulletMgr.KeyOfBullet(entity.ID, roPtc.Data.BulletID, roPtc.Data.BulletExtraIDSpecified ? roPtc.Data.BulletExtraID : 0UL);
					XBullet bullet = XSingleton<XBulletMgr>.singleton.GetBullet(id);
					bool flag2 = bullet == null;
					if (flag2)
					{
						XSingleton<XBulletMgr>.singleton.Cache(id);
					}
					else
					{
						bullet.OnResult(null);
					}
				}
				for (int i = 0; i < roPtc.Data.TargetList.Count; i++)
				{
					XEntity entity2 = XSingleton<XEntityMgr>.singleton.GetEntity(roPtc.Data.TargetList[i].UnitID);
					bool flag3 = !XEntity.ValideEntity(entity2);
					if (!flag3)
					{
						TargetHurtInfo targetHurtInfo = roPtc.Data.TargetList[i];
						ProjectDamageResult data = XDataPool<ProjectDamageResult>.GetData();
						data.Accept = true;
						data.Result = (ProjectResultType)targetHurtInfo.Result.Result;
						data.Value = targetHurtInfo.Result.Value;
						data.Flag = targetHurtInfo.Result.Flag;
						data.Type = (DamageType)targetHurtInfo.Result.DamageType;
						data.ElementType = (DamageElement)targetHurtInfo.Result.ElementType;
						data.IsTargetDead = targetHurtInfo.Result.IsTargetDead;
						data.Caster = roPtc.Data.FirerID;
						data.ComboCount = targetHurtInfo.Result.ComboCount;
						XSkillCore skill = entity.SkillMgr.GetSkill(roPtc.Data.SkillID);
						bool flag4 = skill == null || skill.Soul.Hit.Count <= (int)roPtc.Data.PIndex;
						if (flag4)
						{
							bool flag5 = skill == null;
							if (flag5)
							{
								XSingleton<XDebug>.singleton.AddErrorLog("skill ", roPtc.Data.SkillID.ToString(), " is not found by ", entity.Name, null, null);
							}
							else
							{
								XSingleton<XDebug>.singleton.AddErrorLog("skill ", skill.Soul.Name, "'s hit point is not matched by ", entity.Name, null, null);
							}
						}
						else
						{
							XSkill.SkillResult_TakeEffect(entity, entity2, data, skill.Soul.Hit[(int)roPtc.Data.PIndex], Vector3.forward, XStrickenResponse.Cease, true, 1f, Vector3.zero);
						}
					}
				}
			}
		}
	}
}
