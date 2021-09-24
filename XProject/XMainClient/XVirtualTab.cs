using System;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XVirtualTab : XSingleton<XVirtualTab>
	{

		public int FingerId
		{
			get
			{
				return this._finger_id;
			}
		}

		public bool Freezed
		{
			get
			{
				return this._bFreeze;
			}
			set
			{
				this._bFreeze = value;
				this.Cancel();
			}
		}

		public bool Feeding
		{
			get
			{
				return this._bFeeding && !this._bFreeze;
			}
		}

		public float DeadZone
		{
			get
			{
				return this._dead_zone;
			}
		}

		public float MaxDistance
		{
			get
			{
				return this._max_distance;
			}
		}

		public Vector3 Direction
		{
			get
			{
				bool flag = XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.Buffs.IsBuffStateOn(XBuffType.XBuffType_Puzzled);
				Vector3 result;
				if (flag)
				{
					result = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(this._direction, (float)XSingleton<XEntityMgr>.singleton.Player.Buffs.GetStateParam(XBuffType.XBuffType_Puzzled), true);
				}
				else
				{
					result = this._direction;
				}
				return result;
			}
		}

		public float CentrifugalFactor
		{
			get
			{
				return this._velocity;
			}
		}

		public void OnEnterScene()
		{
			this._outer_radius = DlgBase<VirtualJoystick, VirtualJoystickBehaviour>.singleton.GetPanelRadius();
			this._inner_radius = DlgBase<VirtualJoystick, VirtualJoystickBehaviour>.singleton.GetJoystickRadius();
			this._max_distance = (XSingleton<XUpdater.XUpdater>.singleton.EditorMode ? 125f : (this._outer_radius + this._inner_radius));
			this.Cancel();
			this._bFreeze = false;
		}

		public void Feed(XTouchItem touch)
		{
			bool flag = !this._bFreeze && ((this._finger_id == -1 && touch.FingerId != XSingleton<XGesture>.singleton.FingerId) || this._finger_id == touch.FingerId);
			if (flag)
			{
				bool bFeeding = this._bFeeding;
				if (bFeeding)
				{
					bool flag2 = XTouch.IsActiveTouch(touch);
					if (flag2)
					{
						this.CalcMove(touch, false);
					}
					else
					{
						this.Cancel();
					}
				}
				else
				{
					bool bTouch = this._bTouch;
					if (bTouch)
					{
						bool flag3 = XTouch.IsActiveTouch(touch);
						if (flag3)
						{
							bool flag4 = (touch.Position - this._center).sqrMagnitude > this._dead_zone * this._dead_zone;
							if (flag4)
							{
								this._bFeeding = true;
								this.CalcMove(touch, true);
							}
						}
						else
						{
							this.Cancel();
						}
					}
					else
					{
						bool flag5 = touch.Phase == null && touch.Position.x < (float)Screen.width * 0.5f;
						if (flag5)
						{
							this._bTouch = true;
							this._center = touch.Position;
							this._finger_id = touch.FingerId;
						}
					}
				}
			}
		}

		public void Cancel()
		{
			bool bTouch = this._bTouch;
			if (bTouch)
			{
				this._bTouch = false;
				this._bFeeding = false;
				this._center = Vector2.zero;
				this._finger_id = -1;
				DlgBase<VirtualJoystick, VirtualJoystickBehaviour>.singleton.ShowPanel(false, default(Vector2));
			}
		}

		private void CalcMove(XTouchItem touch, bool newly)
		{
			this.TabCulling();
			Vector2 vector = touch.Position - this._center;
			bool flag = !newly && XSingleton<XUpdater.XUpdater>.singleton.EditorMode && touch.FingerId == 1;
			if (flag)
			{
				float num = 480f * Time.deltaTime;
				float num2 = Vector2.Angle(this._tab_dir, vector);
				bool flag2 = num2 > num;
				if (flag2)
				{
					bool flag3 = XSingleton<XCommon>.singleton.Clockwise(this._tab_dir, vector);
					this._tab_dir = XSingleton<XCommon>.singleton.HorizontalRotateVetor2(this._tab_dir, flag3 ? num : (-num), false);
					bool flag4 = XSingleton<XCommon>.singleton.Clockwise(this._tab_dir, vector);
					bool flag5 = flag3 != flag4;
					if (flag5)
					{
						this._tab_dir = vector;
					}
				}
				else
				{
					this._tab_dir = vector;
				}
			}
			else
			{
				this._tab_dir = vector;
			}
			float num3 = this._tab_dir.magnitude;
			bool flag6 = num3 > this._max_distance;
			if (flag6)
			{
				num3 = this._max_distance;
				this.TabCulling();
			}
			this._velocity = 1f;
			float num4 = Vector2.Angle(Vector2.up, this._tab_dir);
			bool flag7 = XSingleton<XCommon>.singleton.Clockwise(Vector2.up, this._tab_dir);
			bool flag8 = XSingleton<XScene>.singleton.GameCamera == null || XSingleton<XScene>.singleton.GameCamera.CameraTrans == null;
			if (!flag8)
			{
				Vector3 forward = XSingleton<XScene>.singleton.GameCamera.CameraTrans.forward;
				forward.y = 0f;
				forward.Normalize();
				this._direction = XSingleton<XCommon>.singleton.HorizontalRotateVetor3(forward, flag7 ? num4 : (-num4), true);
				DlgBase<VirtualJoystick, VirtualJoystickBehaviour>.singleton.ShowPanel(true, this._center);
				DlgBase<VirtualJoystick, VirtualJoystickBehaviour>.singleton.SetJoystickPos(num3, (flag7 ? num4 : (360f - num4)) - 90f);
			}
		}

		private void TabCulling()
		{
			bool flag = this._center.x - this._max_distance < 0f;
			if (flag)
			{
				this._center.x = this._max_distance;
			}
			bool flag2 = this._center.y - this._max_distance < 0f;
			if (flag2)
			{
				this._center.y = this._max_distance;
			}
			bool flag3 = this._center.x + this._max_distance > (float)Screen.width;
			if (flag3)
			{
				this._center.x = (float)Screen.width - this._max_distance;
			}
			bool flag4 = this._center.y + this._max_distance > (float)Screen.height;
			if (flag4)
			{
				this._center.y = (float)Screen.height - this._max_distance;
			}
		}

		private readonly float _dead_zone = 15f;

		private int _finger_id = -1;

		private bool _bTouch = false;

		private bool _bFeeding = false;

		private bool _bFreeze = false;

		private float _max_distance = 75f;

		private float _velocity = 0f;

		private float _outer_radius = 0f;

		private float _inner_radius = 0f;

		private Vector3 _direction = Vector3.zero;

		private Vector2 _center = Vector2.zero;

		private Vector2 _rocker_center = Vector2.zero;

		private Vector2 _tab_dir = Vector2.up;
	}
}
