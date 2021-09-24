

using UnityEngine;
using UnityEngine.AI;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XAIMove : XSingleton<XAIMove>
    {
        private Vector3 _arena_center = Vector3.zero;

        public bool NavToTarget(XEntity host, Vector3 oTargetPos, float speed) => host != null && host.Nav != null && this.NavToPos(host, oTargetPos, speed);

        public bool NavToPos(XEntity host, Vector3 targetpos, float speed)
        {
            if ((double)(host.EngineObject.Position - targetpos).magnitude <= 2.0)
            {
                Vector3 vector3 = host.EngineObject.Position - targetpos;
                vector3.y = 0.0f;
                host.Net.ReportMoveAction(targetpos, speed, stopage_dir: XSingleton<XCommon>.singleton.AngleToFloat(-vector3));
            }
            else if (!NavMesh.SamplePosition(host.EngineObject.Position, out NavMeshHit _, 1f, -1))
            {
                host.Net.ReportMoveAction(targetpos, speed, stopage_dir: XSingleton<XCommon>.singleton.AngleToFloat(targetpos - host.EngineObject.Position));
            }
            else
            {
                XNavigationEventArgs xnavigationEventArgs = XEventPool<XNavigationEventArgs>.GetEvent();
                xnavigationEventArgs.Firer = (XObject)host;
                xnavigationEventArgs.Dest = targetpos;
                xnavigationEventArgs.CameraFollow = false;
                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xnavigationEventArgs);
                if (!host.Nav.IsOnNav)
                {
                    xnavigationEventArgs.Dest = targetpos + (host.EngineObject.Position - targetpos).normalized * 2f;
                    XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xnavigationEventArgs);
                    if (!host.Nav.IsOnNav)
                        host.Net.ReportMoveAction(targetpos, speed, stopage_dir: XSingleton<XCommon>.singleton.AngleToFloat(targetpos - host.EngineObject.Position));
                }
            }
            return true;
        }

        public bool RotateToTarget(XEntity entity, XEntity target)
        {
            Vector3 dir = target.EngineObject.Position - entity.EngineObject.Position;
            float magnitude = dir.magnitude;
            entity.Net.ReportRotateAction(dir);
            return true;
        }

        public bool FindNavPath(XEntity entity) => entity.AI.RefreshNavTarget();

        public bool ActionMove(XEntity entity, Vector3 dir, Vector3 dest, float speed)
        {
            if (entity.Nav != null)
            {
                this.ActionNav(entity, dest, speed);
            }
            else
            {
                if (entity.Fly != null)
                    dest.y = entity.Fly.CurrentHeight + XSingleton<XScene>.singleton.TerrainY(dest);
                entity.Net.ReportMoveAction(dest, speed * entity.AI.MoveSpeed, false, false, false, 0.0f);
                XSecurityStatistics.TryGetStatistics(entity);
            }
            return true;
        }

        public bool ActionNav(XEntity entity, Vector3 dest, float speedRatio = 1f)
        {
            XNavigationEventArgs xnavigationEventArgs = XEventPool<XNavigationEventArgs>.GetEvent();
            xnavigationEventArgs.Firer = (XObject)entity;
            xnavigationEventArgs.Dest = dest;
            xnavigationEventArgs.CameraFollow = false;
            xnavigationEventArgs.SpeedRatio = speedRatio;
            return XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xnavigationEventArgs);
        }

        public bool ActionRotate(XEntity entity, float degree, float speed, int type)
        {
            Vector3 dir = Quaternion.Euler(new Vector3(0.0f, degree, 0.0f)) * (type == 0 ? entity.EngineObject.Forward : Vector3.forward);
            entity.Net.ReportRotateAction(dir, speed);
            return true;
        }

        public bool RotateToTarget(XEntity entity)
        {
            if (entity.AI.Target == null)
                return false;
            entity.Net.ReportRotateAction(entity.AI.Target.EngineObject.Position - entity.EngineObject.Position, entity.Attributes.RotateSpeed);
            return true;
        }

        public bool UpdateNavigation(XEntity entity, int dir, int oldDir)
        {
            Vector3 targetpos = entity.AI.Patrol.GetCurNavigationPoint();
            if (targetpos == Vector3.zero)
                return false;
            if (dir != oldDir)
            {
                entity.AI.Patrol.ToggleNavDir();
                targetpos = entity.AI.Patrol.GetNextNavPos();
            }
            else if ((double)(entity.EngineObject.Position - targetpos).magnitude <= 0.5 || entity.AI.Patrol.IsInNavGap)
            {
                if (entity.AI.Patrol.IsInNavGap)
                {
                    if ((double)(Time.realtimeSinceStartup - entity.AI.Patrol.NavNodeFinishTime) < (double)entity.AI.Patrol.GetCurNavGap())
                        return true;
                    targetpos = entity.AI.Patrol.GetNextNavPos();
                }
                else
                {
                    if ((double)entity.AI.Patrol.GetCurNavGap() > 0.0)
                    {
                        entity.AI.Patrol.NavNodeFinishTime = Time.realtimeSinceStartup;
                        entity.AI.Patrol.IsInNavGap = true;
                        return true;
                    }
                    targetpos = entity.AI.Patrol.GetNextNavPos();
                }
            }
            entity.AI.Patrol.IsInNavGap = false;
            Vector3 pos = entity.EngineObject.Position - targetpos;
            pos.y = 0.0f;
            this.NavToPos(entity, targetpos, entity.AI.MoveSpeed);
            return true;
        }

        public bool IsPointInMap(Vector3 pos) => XSingleton<XScene>.singleton.IsWalkable(pos);
    }
}
