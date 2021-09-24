using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLocateTargetComponent : XComponent
	{

		public override uint ID
		{
			get
			{
				return XLocateTargetComponent.uuID;
			}
		}

		public XEntity Target
		{
			get
			{
				return XEntity.ValideEntity(this._last_target) ? this._last_target : (XEntity.ValideEntity(this._last_pre_target) ? this._last_pre_target : null);
			}
		}

		protected override void EventSubscribe()
		{
		}

		public override void Attached()
		{
			this._spectator = (XSingleton<XScene>.singleton.bSpectator && this._entity.IsPlayer);
			this._elapsed.Clear();
			this._angle.Clear();
			this._scene_specified = XSingleton<XSceneMgr>.singleton.SpecifiedTargetLocatedRange(XSingleton<XScene>.singleton.SceneID);
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		public override void Update(float fDeltaT)
		{
			bool flag = this.Target != null;
			int i;
			for (i = 0; i < this._elapsed.Count; i++)
			{
				bool flag2 = Vector3.Angle(this._entity.EngineObject.Forward, XSingleton<XCommon>.singleton.FloatToAngle(this._angle[i])) < XSingleton<XOperationData>.singleton.WithinScope * 0.5f;
				if (flag2)
				{
					List<float> elapsed = this._elapsed;
					int index = i;
					elapsed[index] += fDeltaT;
					bool flag3 = this._elapsed[i] > 0.1f;
					if (flag3)
					{
						bool flag4 = this._last_forward.sqrMagnitude == 0f || Vector3.Angle(this._last_forward, XSingleton<XCommon>.singleton.FloatToAngle(this._angle[i])) > 30f || this._elapsed[i] > 0.5f;
						if (flag4)
						{
							break;
						}
					}
				}
				else
				{
					this._elapsed.RemoveAt(i);
					this._angle.RemoveAt(i);
					i--;
				}
			}
			bool flag5 = i < this._elapsed.Count;
			if (flag5)
			{
				this.Locate(this._entity.EngineObject.Forward, this._entity.EngineObject.Position, true);
				this._elapsed.Clear();
				this._angle.Clear();
			}
			else
			{
				float item = XSingleton<XCommon>.singleton.AngleToFloat(this._entity.EngineObject.Forward);
				bool flag6 = !this._angle.Contains(item);
				if (flag6)
				{
					this._elapsed.Add(0f);
					this._angle.Add(item);
				}
			}
		}

		public XEntity Locate(Vector3 forward, Vector3 pos, bool routine = false)
		{
			bool flag = false;
			XEntity xentity = null;
			bool flag2 = xentity != null && !xentity.IsRole && xentity.Buffs != null && xentity.Buffs.IsBuffStateOn(XBuffType.XBuffType_Immortal);
			if (flag2)
			{
				xentity = null;
			}
			bool flag3 = xentity == null;
			if (flag3)
			{
				xentity = XSkillCore.FindTargetAt(pos, forward, (this._scene_specified > 0f) ? this._scene_specified : XSingleton<XOperationData>.singleton.ProfRangeLong, 0f, (float)(XSingleton<XOperationData>.singleton.ProfScope >> 1), this._spectator ? (this._entity as XPlayer).WatchTo : this._entity, true);
				bool flag4 = xentity != null && !xentity.IsRole && xentity.Buffs != null && xentity.Buffs.IsBuffStateOn(XBuffType.XBuffType_Immortal);
				if (flag4)
				{
					xentity = null;
				}
				bool flag5 = xentity == null;
				if (flag5)
				{
					xentity = ((XSingleton<XOperationData>.singleton.OperationMode == XOperationMode.X25D) ? null : this.AssistLocate(forward, pos));
					bool flag6 = xentity != null && !xentity.IsRole && xentity.Buffs != null && xentity.Buffs.IsBuffStateOn(XBuffType.XBuffType_Immortal);
					if (flag6)
					{
						xentity = null;
					}
					bool flag7 = xentity != null;
					if (flag7)
					{
						flag = true;
					}
					else
					{
						xentity = XSkillCore.FindTargetAt(pos, forward, (this._scene_specified > 0f) ? this._scene_specified : XSingleton<XOperationData>.singleton.ProfRangeAll, 0f, 180f, this._spectator ? (this._entity as XPlayer).WatchTo : this._entity, true);
						bool flag8 = xentity != null;
						if (flag8)
						{
							bool isPuppet = xentity.IsPuppet;
							if (isPuppet)
							{
								xentity = null;
							}
							else
							{
								flag = true;
							}
						}
					}
				}
				else
				{
					flag = true;
				}
			}
			bool flag9 = xentity != null && xentity.IsVisible;
			if (flag9)
			{
				XSingleton<XTutorialHelper>.singleton.MeetEnemy = true;
				bool flag10 = flag;
				if (flag10)
				{
					this.Highlight(null, ref this._last_target, Color.red);
					this.Highlight(xentity, ref this._last_pre_target, Color.black);
				}
				else
				{
					this.Highlight(null, ref this._last_pre_target, Color.black);
					this.Highlight(xentity, ref this._last_target, Color.red);
				}
				this._last_forward = forward;
			}
			else
			{
				xentity = null;
				this.Highlight(null, ref this._last_target, Color.red);
				this.Highlight(null, ref this._last_pre_target, Color.black);
				this._last_forward = Vector3.zero;
			}
			return xentity;
		}

		private XEntity AssistLocate(Vector3 forward, Vector3 pos)
		{
			Vector3 forward2 = XSingleton<XScene>.singleton.GameCamera.CameraTrans.forward;
			forward2.y = 0f;
			forward2.Normalize();
			float num = Vector3.Angle(forward2, forward);
			float num2 = XSingleton<XCommon>.singleton.Clockwise(forward2, forward) ? (-XSingleton<XOperationData>.singleton.AssistAngle) : XSingleton<XOperationData>.singleton.AssistAngle;
			bool flag = num < XSingleton<XOperationData>.singleton.AssistAngle;
			if (flag)
			{
				num = XSingleton<XOperationData>.singleton.AssistAngle;
				Vector3 vector = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(forward2, num2, true);
				forward = Vector3.Reflect(-vector, forward2);
			}
			num += XSingleton<XOperationData>.singleton.AssistAngle;
			num2 = ((num2 > 0f) ? num : (-num)) * 0.5f;
			forward = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(forward, num2, false);
			return XSkillCore.FindTargetAt(pos, forward, (this._scene_specified > 0f) ? this._scene_specified : XSingleton<XOperationData>.singleton.ProfRangeLong, 0f, Mathf.Abs(num2), this._spectator ? (this._entity as XPlayer).WatchTo : this._entity, true);
		}

		private void Highlight(XEntity target, ref XEntity last, Color color)
		{
			bool flag = target != null && target != last;
			if (flag)
			{
				bool flag2 = last != null;
				if (flag2)
				{
				}
				last = target;
			}
			else
			{
				bool flag3 = target == null && last != null;
				if (flag3)
				{
					last = null;
				}
			}
		}

		public override void PostUpdate(float fDeltaT)
		{
			bool flag = !XSingleton<XScene>.singleton.bSpectator && this._entity.IsPlayer;
			if (flag)
			{
				bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag2)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.BattleTargetHandler.ShowTargetFx(XEntity.ValideEntity(this._last_target), this._last_target);
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.BattleTargetHandler.ShowPretargetFx(XEntity.ValideEntity(this._last_pre_target), this._last_pre_target);
				}
				bool flag3 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag3)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.BattleTargetHandler.ShowTargetFx(XEntity.ValideEntity(this._last_target), this._last_target);
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.BattleTargetHandler.ShowPretargetFx(XEntity.ValideEntity(this._last_pre_target), this._last_pre_target);
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XLocateTarget");

		private bool _spectator = false;

		private Vector3 _last_forward = Vector3.zero;

		private XEntity _last_pre_target = null;

		private XEntity _last_target = null;

		private List<float> _elapsed = new List<float>();

		private List<float> _angle = new List<float>();

		private float _scene_specified = 0f;
	}
}
