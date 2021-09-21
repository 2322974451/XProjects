using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F2E RID: 3886
	internal sealed class XNavigationComponent : XComponent, IEnumerable<Vector3>, IEnumerable
	{
		// Token: 0x170035E9 RID: 13801
		// (get) Token: 0x0600CDFF RID: 52735 RVA: 0x002FA804 File Offset: 0x002F8A04
		public override uint ID
		{
			get
			{
				return XNavigationComponent.uuID;
			}
		}

		// Token: 0x0600CE00 RID: 52736 RVA: 0x002FA81B File Offset: 0x002F8A1B
		public override void OnAttachToHost(XObject host)
		{
			this._bNav = false;
			base.OnAttachToHost(host);
		}

		// Token: 0x0600CE01 RID: 52737 RVA: 0x002FA830 File Offset: 0x002F8A30
		public override void OnDetachFromHost()
		{
			this.Interrupt();
			bool flag = this._nav != null;
			if (flag)
			{
				UnityEngine.Object.Destroy(this._nav);
			}
			base.OnDetachFromHost();
		}

		// Token: 0x0600CE02 RID: 52738 RVA: 0x002FA868 File Offset: 0x002F8A68
		private static void _ActiveNav(XGameObject gameObject, object o, int commandID)
		{
			XNavigationComponent xnavigationComponent = o as XNavigationComponent;
			bool flag = xnavigationComponent != null;
			if (flag)
			{
				float y = xnavigationComponent.Entity.MoveObj.Position.y;
				xnavigationComponent._nav = xnavigationComponent.Entity.EngineObject.AddComponent<NavMeshAgent>();
				xnavigationComponent._nav.radius = xnavigationComponent.Entity.Radius;
				xnavigationComponent._nav.stoppingDistance = 0.5f;
				xnavigationComponent._nav.autoRepath = false;
				xnavigationComponent._nav.height = xnavigationComponent.Entity.Height;
				xnavigationComponent._nav.areaMask = 1;
				xnavigationComponent._nav.enabled = false;
				xnavigationComponent.Entity.MoveObj.Position = new Vector3(xnavigationComponent.Entity.MoveObj.Position.x, y, xnavigationComponent.Entity.MoveObj.Position.z);
			}
		}

		// Token: 0x0600CE03 RID: 52739 RVA: 0x002FA95D File Offset: 0x002F8B5D
		public void Active()
		{
			this._entity.EngineObject.CallCommand(XNavigationComponent._activeNavCb, this, -1, false);
		}

		// Token: 0x0600CE04 RID: 52740 RVA: 0x002FA979 File Offset: 0x002F8B79
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_NaviMove, new XComponent.XEventHandler(this.OnNavigation));
		}

		// Token: 0x0600CE05 RID: 52741 RVA: 0x002FA994 File Offset: 0x002F8B94
		private bool OnNavigation(XEventArgs e)
		{
			XNavigationEventArgs xnavigationEventArgs = e as XNavigationEventArgs;
			this._bCameraFollow = xnavigationEventArgs.CameraFollow;
			this._speed_ratio = xnavigationEventArgs.SpeedRatio;
			this.Navigate(xnavigationEventArgs.Dest);
			return true;
		}

		// Token: 0x0600CE06 RID: 52742 RVA: 0x002FA9D4 File Offset: 0x002F8BD4
		public override void Update(float fDeltaT)
		{
			bool isOnNav = this.IsOnNav;
			if (isOnNav)
			{
				XStateDefine curState = this._entity.CurState;
				if (curState > XStateDefine.XState_Move)
				{
					this.Interrupt();
				}
				else
				{
					Vector3 position = this._entity.MoveObj.Position;
					position.y = 0f;
					Vector3 destination = this._destination;
					destination.y = 0f;
					Vector3 vector = destination - position;
					float magnitude = vector.magnitude;
					bool flag = magnitude > 0f;
					if (flag)
					{
						bool flag2 = magnitude <= 0.2f;
						if (flag2)
						{
							this.MoveNext();
						}
						else
						{
							float num = Vector3.Angle(vector, this._forward);
							bool flag3 = num >= 90f;
							if (flag3)
							{
								this.MoveNext();
							}
						}
					}
					else
					{
						this.MoveNext();
					}
				}
				bool isOnNav2 = this.IsOnNav;
				if (isOnNav2)
				{
					this._entity.Net.ReportNavAction(XSingleton<XCommon>.singleton.Horizontal(this._destination - this._entity.MoveObj.Position), false, this._speed_ratio);
				}
			}
		}

		// Token: 0x170035EA RID: 13802
		// (get) Token: 0x0600CE07 RID: 52743 RVA: 0x002FAB04 File Offset: 0x002F8D04
		public NavMeshPath Paths
		{
			get
			{
				return this._path;
			}
		}

		// Token: 0x170035EB RID: 13803
		// (get) Token: 0x0600CE08 RID: 52744 RVA: 0x002FAB1C File Offset: 0x002F8D1C
		public bool IsOnNav
		{
			get
			{
				return this._bNav;
			}
		}

		// Token: 0x170035EC RID: 13804
		// (get) Token: 0x0600CE09 RID: 52745 RVA: 0x002FAB34 File Offset: 0x002F8D34
		public bool IsOnLastNode
		{
			get
			{
				return !this._bFoundNext;
			}
		}

		// Token: 0x0600CE0A RID: 52746 RVA: 0x002FAB4F File Offset: 0x002F8D4F
		public void Interrupt()
		{
			this._path.ClearCorners();
			this._bNav = false;
		}

		// Token: 0x0600CE0B RID: 52747 RVA: 0x002FAB68 File Offset: 0x002F8D68
		private void Navigate(Vector3 targetPos)
		{
			bool flag = this._nav == null;
			if (!flag)
			{
				this._path.ClearCorners();
				this._nav.enabled = true;
				this._nav.CalculatePath(targetPos, this._path);
				this._nav.enabled = false;
				this._nodes = (this.TooShort() ? null : this.GetEnumerator());
				this._destination = this._entity.MoveObj.Position;
				this._bFoundNext = (this._nodes != null && this._nodes.MoveNext());
				this._bNav = true;
				this.MoveNext();
			}
		}

		// Token: 0x0600CE0C RID: 52748 RVA: 0x002FAC1C File Offset: 0x002F8E1C
		private bool TooShort()
		{
			return this._path.corners.Length == 2 && XSingleton<XInput>.singleton.LastNpc != null && (this._path.corners[0] - this._path.corners[1]).magnitude < 2f;
		}

		// Token: 0x0600CE0D RID: 52749 RVA: 0x002FAC84 File Offset: 0x002F8E84
		private void MoveNext()
		{
			bool bFoundNext = this._bFoundNext;
			if (bFoundNext)
			{
				Vector3 destination = this._destination;
				this._destination = this._nodes.Current;
				this._bFoundNext = this._nodes.MoveNext();
				bool isPlayer = this._entity.IsPlayer;
				if (isPlayer)
				{
					bool flag = !this._bFoundNext;
					if (flag)
					{
						bool flag2 = XSingleton<XInput>.singleton.LastNpc != null;
						if (flag2)
						{
							Vector3 v = this._entity.MoveObj.Position - this._destination;
							Vector3 vector = XSingleton<XCommon>.singleton.Horizontal(v);
							bool flag3 = v.magnitude < 1f;
							if (flag3)
							{
								this._destination = destination;
							}
							else
							{
								this._destination += vector;
							}
						}
					}
					bool bCameraFollow = this._bCameraFollow;
					if (bCameraFollow)
					{
						XCameraActionEventArgs @event = XEventPool<XCameraActionEventArgs>.GetEvent();
						@event.XRotate = XSingleton<XScene>.singleton.GameCamera.Root_R_X_Default;
						@event.YRotate = XSingleton<XCommon>.singleton.AngleToFloat(XSingleton<XCommon>.singleton.Horizontal(this._nodes.Current - this._entity.MoveObj.Position));
						@event.Firer = XSingleton<XScene>.singleton.GameCamera;
						XSingleton<XEventMgr>.singleton.FireEvent(@event);
					}
				}
				this._forward = XSingleton<XCommon>.singleton.Horizontal(this._destination - this._entity.MoveObj.Position);
				bool flag4 = this._forward.sqrMagnitude == 0f;
				if (flag4)
				{
					this._forward = this._entity.MoveObj.Forward;
				}
			}
			else
			{
				this._bNav = false;
				this._entity.Net.ReportMoveAction(Vector3.zero, (double)XSingleton<XCommon>.singleton.AngleToFloat(this._entity.EngineObject.Forward));
				bool isPlayer2 = this._entity.IsPlayer;
				if (isPlayer2)
				{
					XSingleton<XActionSender>.singleton.Flush(true);
					bool flag5 = XSingleton<XInput>.singleton.LastNpc != null && !XSingleton<UIManager>.singleton.IsUIShowed();
					if (flag5)
					{
						bool onReconnect = XSingleton<XClientNetwork>.singleton.XConnect.OnReconnect;
						if (!onReconnect)
						{
							XNpc npc = XSingleton<XInput>.singleton.LastNpc as XNpc;
							XDramaDocument specificDocument = XDocuments.GetSpecificDocument<XDramaDocument>(XDramaDocument.uuID);
							specificDocument.OnMeetNpc(npc);
						}
					}
				}
			}
		}

		// Token: 0x0600CE0E RID: 52750 RVA: 0x002FAEFB File Offset: 0x002F90FB
		public IEnumerator<Vector3> GetEnumerator()
		{
			int num;
			for (int i = 1; i < this._path.corners.Length; i = num + 1)
			{
				yield return this._path.corners[i];
				num = i;
			}
			yield break;
		}

		// Token: 0x0600CE0F RID: 52751 RVA: 0x002FAF0C File Offset: 0x002F910C
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x04005BCC RID: 23500
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Navgation_Component");

		// Token: 0x04005BCD RID: 23501
		private NavMeshAgent _nav = null;

		// Token: 0x04005BCE RID: 23502
		private NavMeshPath _path = new NavMeshPath();

		// Token: 0x04005BCF RID: 23503
		private Vector3 _destination = Vector3.zero;

		// Token: 0x04005BD0 RID: 23504
		private Vector3 _forward = Vector3.forward;

		// Token: 0x04005BD1 RID: 23505
		private IEnumerator<Vector3> _nodes = null;

		// Token: 0x04005BD2 RID: 23506
		private bool _bFoundNext = false;

		// Token: 0x04005BD3 RID: 23507
		private bool _bCameraFollow = true;

		// Token: 0x04005BD4 RID: 23508
		private bool _bNav = false;

		// Token: 0x04005BD5 RID: 23509
		private float _speed_ratio = 1f;

		// Token: 0x04005BD6 RID: 23510
		private static CommandCallback _activeNavCb = new CommandCallback(XNavigationComponent._ActiveNav);
	}
}
