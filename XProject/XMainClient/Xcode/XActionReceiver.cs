

using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XActionReceiver : XSingleton<XActionReceiver>
    {
        public void OnActionReceived(XEntity entity, StepSyncData data)
        {
            XStateDefine xstateDefine = (XStateDefine)(data.Common >> 12 & 15);
            Vector3 pos = new Vector3((float)(data.PosXZ >> 16) / 100f, 0.0f, (float)(data.PosXZ & (int)ushort.MaxValue) / 100f);
            Vector3 angle = XSingleton<XCommon>.singleton.FloatToAngle((float)(data.Common & 4095));
            uint sequence = (uint)(data.Common >> 16);
            if (xstateDefine != XStateDefine.XState_Skill && entity.Skill != null && entity.Skill.IsCasting())
                entity.Skill.EndSkill(force: true);
            switch (xstateDefine)
            {
                case XStateDefine.XState_Idle:
                    entity.Net.OnIdle();
                    break;
                case XStateDefine.XState_Move:
                    if (entity.Machine.Current != XStateDefine.XState_Move)
                    {
                        entity.Machine.Stop();
                        if ((int)entity.Net.SyncSequence != (int)sequence)
                        {
                            XMoveEventArgs xmoveEventArgs = XEventPool<XMoveEventArgs>.GetEvent();
                            xmoveEventArgs.Speed = (float)data.Velocity / 10f;
                            xmoveEventArgs.Destination = entity.MoveObj.Position;
                            xmoveEventArgs.Inertia = false;
                            xmoveEventArgs.Firer = (XObject)entity;
                            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xmoveEventArgs);
                        }
                    }
                    entity.Net.CorrectMoveSpeed((float)data.Velocity / 10f);
                    break;
                case XStateDefine.XState_Freeze:
                    if (entity.IsPlayer)
                        XSingleton<XActionSender>.singleton.Empty();
                    if ((int)entity.Net.SyncSequence != (int)sequence)
                    {
                        XEntity entity1 = XSingleton<XEntityMgr>.singleton.GetEntity(data.OpposerID);
                        if (entity1 != null)
                        {
                            if (data.FreezedFromHit)
                            {
                                XSkillCore skill = entity1.SkillMgr.GetSkill((uint)data.Skillid);
                                if (skill != null && skill.Soul.Hit != null && skill.Soul.Hit.Count > data.HitIdx)
                                {
                                    XHitData xhitData = skill.Soul.Hit[data.HitIdx];
                                    XFreezeEventArgs xfreezeEventArgs = XEventPool<XFreezeEventArgs>.GetEvent();
                                    xfreezeEventArgs.HitData = xhitData;
                                    xfreezeEventArgs.Dir = Vector3.forward;
                                    xfreezeEventArgs.Firer = (XObject)entity;
                                    XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xfreezeEventArgs);
                                }
                            }
                            else
                            {
                                XFreezeEventArgs xfreezeEventArgs = XEventPool<XFreezeEventArgs>.GetEvent();
                                xfreezeEventArgs.Present = data.PresentInFreezed;
                                xfreezeEventArgs.Dir = Vector3.forward;
                                xfreezeEventArgs.Firer = (XObject)entity;
                                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xfreezeEventArgs);
                            }
                        }
                        break;
                    }
                    break;
                case XStateDefine.XState_BeHit:
                    if (entity.IsPlayer)
                        XSingleton<XActionSender>.singleton.Empty();
                    if ((int)entity.Net.SyncSequence != (int)sequence)
                    {
                        XEntity entity2 = XSingleton<XEntityMgr>.singleton.GetEntity(data.OpposerID);
                        if (entity2 != null)
                        {
                            XSkillCore skill = entity2.SkillMgr.GetSkill((uint)data.Skillid);
                            if (skill != null && skill.Soul.Hit != null && skill.Soul.Hit.Count > data.HitIdx)
                            {
                                entity.Machine.Stop();
                                XHitData xhitData = skill.Soul.Hit[data.HitIdx];
                                entity.Machine.Stop();
                                XBeHitEventArgs xbeHitEventArgs = XEventPool<XBeHitEventArgs>.GetEvent();
                                xbeHitEventArgs.DepracatedPass = true;
                                xbeHitEventArgs.HitDirection = Vector3.forward;
                                xbeHitEventArgs.HitData = xhitData;
                                xbeHitEventArgs.Firer = (XObject)entity;
                                xbeHitEventArgs.HitFrom = entity2;
                                xbeHitEventArgs.Paralyze = (float)data.HitParalyzeFactor / 100f;
                                xbeHitEventArgs.ForceToFlyHit = data.HitForceToFly;
                                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xbeHitEventArgs);
                            }
                        }
                        break;
                    }
                    break;
                case XStateDefine.XState_Death:
                    if (entity.IsPlayer)
                    {
                        XSingleton<XActionSender>.singleton.Empty();
                        break;
                    }
                    break;
                case XStateDefine.XState_Skill:
                    int slot = data.SkillCommon & (int)byte.MaxValue;
                    if (slot == (int)byte.MaxValue)
                        slot = -1;
                    float num1 = (float)(data.SkillCommon >> 8 & (int)byte.MaxValue) / 100f;
                    float speed = (float)(data.SkillCommon >> 16 & (int)byte.MaxValue) / 10f;
                    float num2 = (float)(data.SkillCommon >> 24 & (int)byte.MaxValue) / 100f;
                    if ((int)entity.Net.SyncSequence != (int)sequence)
                    {
                        XEntity target = data.OpposerIDSpecified ? XSingleton<XEntityMgr>.singleton.GetEntity(data.OpposerID) : (XEntity)null;
                        bool flag = false;
                        if (entity.Skill.CurrentSkill is XJAComboSkill currentSkill3 && (currentSkill3.MainCore.Soul.Ja == null || currentSkill3.MainCore.Soul.Ja.Count == 0 ? 0 : (int)XSingleton<XCommon>.singleton.XHash(currentSkill3.MainCore.Soul.Ja[0].Name)) == data.Skillid)
                        {
                            currentSkill3.ReFire((uint)data.Skillid, target, slot, speed, sequence);
                            flag = true;
                        }
                        if (!flag)
                        {
                            entity.Skill.EndSkill(force: true);
                            XAttackEventArgs xattackEventArgs = XEventPool<XAttackEventArgs>.GetEvent();
                            xattackEventArgs.Target = target;
                            xattackEventArgs.Identify = (uint)data.Skillid;
                            xattackEventArgs.Firer = (XObject)entity;
                            xattackEventArgs.Slot = slot;
                            xattackEventArgs.TimeScale = speed;
                            xattackEventArgs.SyncSequence = sequence;
                            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xattackEventArgs);
                        }
                        if ((double)num1 == 0.0)
                        {
                            if (data.Skillid == (int)entity.SkillMgr.GetBrokenIdentity())
                            {
                                XArmorBrokenArgs xarmorBrokenArgs1 = XEventPool<XArmorBrokenArgs>.GetEvent();
                                xarmorBrokenArgs1.Firer = (XObject)entity;
                                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xarmorBrokenArgs1);
                                XArmorBrokenArgs xarmorBrokenArgs2 = XEventPool<XArmorBrokenArgs>.GetEvent();
                                xarmorBrokenArgs2.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
                                xarmorBrokenArgs2.Self = entity;
                                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xarmorBrokenArgs2);
                            }
                            else if (data.Skillid == (int)entity.SkillMgr.GetRecoveryIdentity())
                            {
                                XArmorRecoverArgs xarmorRecoverArgs1 = XEventPool<XArmorRecoverArgs>.GetEvent();
                                xarmorRecoverArgs1.Firer = (XObject)entity;
                                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xarmorRecoverArgs1);
                                XArmorRecoverArgs xarmorRecoverArgs2 = XEventPool<XArmorRecoverArgs>.GetEvent();
                                xarmorRecoverArgs2.Firer = (XObject)XSingleton<XGame>.singleton.Doc;
                                xarmorRecoverArgs2.Self = entity;
                                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xarmorRecoverArgs2);
                            }
                        }
                    }
                    if ((double)num2 > 0.0 && entity.Skill.IsCasting())
                    {
                        entity.Skill.TagTrigger();
                        entity.Skill.CurrentSkill.MultipleDirectionFactorByServer = num2;
                        break;
                    }
                    break;
            }
            if ((uint)xstateDefine > 0U)
                entity.Net.KillIdle();
            entity.IsPassive = data.PassiveSpecified && data.Passive;
            entity.Net.CorrectNet(pos, angle, sequence, entity.Skill != null && entity.Skill.Enabled && entity.Machine != null && entity.Machine.Enabled);
        }

        public void OnMoveReceived(XEntity entity, StepMoveData data)
        {
            Vector3 vector3 = new Vector3((float)(data.PosXZ >> 16) / 100f, 0.0f, (float)(data.PosXZ & (int)ushort.MaxValue) / 100f);
            XMoveEventArgs xmoveEventArgs = XEventPool<XMoveEventArgs>.GetEvent();
            xmoveEventArgs.Speed = entity.Attributes.RunSpeed;
            xmoveEventArgs.Destination = vector3;
            xmoveEventArgs.Inertia = data.Stoppage;
            xmoveEventArgs.Stoppage = data.Stoppage;
            if (data.Stoppage)
                xmoveEventArgs.StopTowards = (float)data.Face / 10f;
            xmoveEventArgs.Firer = (XObject)entity;
            XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xmoveEventArgs);
        }
    }
}
