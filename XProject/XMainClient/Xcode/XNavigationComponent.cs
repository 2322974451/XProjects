using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XNavigationComponent : XComponent, IEnumerable<Vector3>, IEnumerable
	{

		public override uint ID
		{
			get
			{
				return XNavigationComponent.uuID;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			this._bNav = false;
			base.OnAttachToHost(host);
		}

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

		public void Active()
		{
			this._entity.EngineObject.CallCommand(XNavigationComponent._activeNavCb, this, -1, false);
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_NaviMove, new XComponent.XEventHandler(this.OnNavigation));
		}

		private bool OnNavigation(XEventArgs e)
		{
			XNavigationEventArgs xnavigationEventArgs = e as XNavigationEventArgs;
			this._bCameraFollow = xnavigationEventArgs.CameraFollow;
			this._speed_ratio = xnavigationEventArgs.SpeedRatio;
			this.Navigate(xnavigationEventArgs.Dest);
			return true;
		}

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

		public NavMeshPath Paths
		{
			get
			{
				return this._path;
			}
		}

		public bool IsOnNav
		{
			get
			{
				return this._bNav;
			}
		}

		public bool IsOnLastNode
		{
			get
			{
				return !this._bFoundNext;
			}
		}

		public void Interrupt()
		{
			this._path.ClearCorners();
			this._bNav = false;
		}

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

		private bool TooShort()
		{
			return this._path.corners.Length == 2 && XSingleton<XInput>.singleton.LastNpc != null && (this._path.corners[0] - this._path.corners[1]).magnitude < 2f;
		}

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

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Navgation_Component");

		private NavMeshAgent _nav = null;

		private NavMeshPath _path = new NavMeshPath();

		private Vector3 _destination = Vector3.zero;

		private Vector3 _forward = Vector3.forward;

		private IEnumerator<Vector3> _nodes = null;

		private bool _bFoundNext = false;

		private bool _bCameraFollow = true;

		private bool _bNav = false;

		private float _speed_ratio = 1f;

		private static CommandCallback _activeNavCb = new CommandCallback(XNavigationComponent._ActiveNav);
	}
}
