using System;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EAC RID: 3756
	internal class XVirtualTab : XSingleton<XVirtualTab>
	{
		// Token: 0x170034E9 RID: 13545
		// (get) Token: 0x0600C81A RID: 51226 RVA: 0x002CC6D4 File Offset: 0x002CA8D4
		public int FingerId
		{
			get
			{
				return this._finger_id;
			}
		}

		// Token: 0x170034EA RID: 13546
		// (get) Token: 0x0600C81B RID: 51227 RVA: 0x002CC6EC File Offset: 0x002CA8EC
		// (set) Token: 0x0600C81C RID: 51228 RVA: 0x002CC704 File Offset: 0x002CA904
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

		// Token: 0x170034EB RID: 13547
		// (get) Token: 0x0600C81D RID: 51229 RVA: 0x002CC718 File Offset: 0x002CA918
		public bool Feeding
		{
			get
			{
				return this._bFeeding && !this._bFreeze;
			}
		}

		// Token: 0x170034EC RID: 13548
		// (get) Token: 0x0600C81E RID: 51230 RVA: 0x002CC740 File Offset: 0x002CA940
		public float DeadZone
		{
			get
			{
				return this._dead_zone;
			}
		}

		// Token: 0x170034ED RID: 13549
		// (get) Token: 0x0600C81F RID: 51231 RVA: 0x002CC758 File Offset: 0x002CA958
		public float MaxDistance
		{
			get
			{
				return this._max_distance;
			}
		}

		// Token: 0x170034EE RID: 13550
		// (get) Token: 0x0600C820 RID: 51232 RVA: 0x002CC770 File Offset: 0x002CA970
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

		// Token: 0x170034EF RID: 13551
		// (get) Token: 0x0600C821 RID: 51233 RVA: 0x002CC7DC File Offset: 0x002CA9DC
		public float CentrifugalFactor
		{
			get
			{
				return this._velocity;
			}
		}

		// Token: 0x0600C822 RID: 51234 RVA: 0x002CC7F4 File Offset: 0x002CA9F4
		public void OnEnterScene()
		{
			this._outer_radius = DlgBase<VirtualJoystick, VirtualJoystickBehaviour>.singleton.GetPanelRadius();
			this._inner_radius = DlgBase<VirtualJoystick, VirtualJoystickBehaviour>.singleton.GetJoystickRadius();
			this._max_distance = (XSingleton<XUpdater.XUpdater>.singleton.EditorMode ? 125f : (this._outer_radius + this._inner_radius));
			this.Cancel();
			this._bFreeze = false;
		}

		// Token: 0x0600C823 RID: 51235 RVA: 0x002CC858 File Offset: 0x002CAA58
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

		// Token: 0x0600C824 RID: 51236 RVA: 0x002CC988 File Offset: 0x002CAB88
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

		// Token: 0x0600C825 RID: 51237 RVA: 0x002CC9D8 File Offset: 0x002CABD8
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

		// Token: 0x0600C826 RID: 51238 RVA: 0x002CCBC0 File Offset: 0x002CADC0
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

		// Token: 0x04005858 RID: 22616
		private readonly float _dead_zone = 15f;

		// Token: 0x04005859 RID: 22617
		private int _finger_id = -1;

		// Token: 0x0400585A RID: 22618
		private bool _bTouch = false;

		// Token: 0x0400585B RID: 22619
		private bool _bFeeding = false;

		// Token: 0x0400585C RID: 22620
		private bool _bFreeze = false;

		// Token: 0x0400585D RID: 22621
		private float _max_distance = 75f;

		// Token: 0x0400585E RID: 22622
		private float _velocity = 0f;

		// Token: 0x0400585F RID: 22623
		private float _outer_radius = 0f;

		// Token: 0x04005860 RID: 22624
		private float _inner_radius = 0f;

		// Token: 0x04005861 RID: 22625
		private Vector3 _direction = Vector3.zero;

		// Token: 0x04005862 RID: 22626
		private Vector2 _center = Vector2.zero;

		// Token: 0x04005863 RID: 22627
		private Vector2 _rocker_center = Vector2.zero;

		// Token: 0x04005864 RID: 22628
		private Vector2 _tab_dir = Vector2.up;
	}
}
