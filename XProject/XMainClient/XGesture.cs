using System;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EA4 RID: 3748
	internal class XGesture : XSingleton<XGesture>
	{
		// Token: 0x170034BD RID: 13501
		// (get) Token: 0x0600C7BC RID: 51132 RVA: 0x002CAB5C File Offset: 0x002C8D5C
		// (set) Token: 0x0600C7BD RID: 51133 RVA: 0x002CAB74 File Offset: 0x002C8D74
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

		// Token: 0x170034BE RID: 13502
		// (get) Token: 0x0600C7BE RID: 51134 RVA: 0x002CAB88 File Offset: 0x002C8D88
		public bool Working
		{
			get
			{
				return this._finger_id != -1;
			}
		}

		// Token: 0x170034BF RID: 13503
		// (get) Token: 0x0600C7BF RID: 51135 RVA: 0x002CABA8 File Offset: 0x002C8DA8
		public bool Gestured
		{
			get
			{
				return this._bswype || this._one || this._one_up;
			}
		}

		// Token: 0x170034C0 RID: 13504
		// (get) Token: 0x0600C7C0 RID: 51136 RVA: 0x002CABD4 File Offset: 0x002C8DD4
		public bool OneTouch
		{
			get
			{
				return this._one;
			}
		}

		// Token: 0x170034C1 RID: 13505
		// (get) Token: 0x0600C7C1 RID: 51137 RVA: 0x002CABEC File Offset: 0x002C8DEC
		public bool OneUpTouch
		{
			get
			{
				return this._one_up;
			}
		}

		// Token: 0x170034C2 RID: 13506
		// (get) Token: 0x0600C7C2 RID: 51138 RVA: 0x002CAC04 File Offset: 0x002C8E04
		public bool Swype
		{
			get
			{
				return this._bswype;
			}
		}

		// Token: 0x170034C3 RID: 13507
		// (get) Token: 0x0600C7C3 RID: 51139 RVA: 0x002CAC1C File Offset: 0x002C8E1C
		public bool LastSwypeUsed
		{
			get
			{
				return this._last_swype_used;
			}
		}

		// Token: 0x170034C4 RID: 13508
		// (get) Token: 0x0600C7C4 RID: 51140 RVA: 0x002CAC34 File Offset: 0x002C8E34
		public float LastSwypeAt
		{
			get
			{
				return this._last_swype_at;
			}
		}

		// Token: 0x170034C5 RID: 13509
		// (get) Token: 0x0600C7C5 RID: 51141 RVA: 0x002CAC4C File Offset: 0x002C8E4C
		public float LastSwypeDis
		{
			get
			{
				return this._swype_dis;
			}
		}

		// Token: 0x170034C6 RID: 13510
		// (get) Token: 0x0600C7C6 RID: 51142 RVA: 0x002CAC64 File Offset: 0x002C8E64
		public Vector3 SwypeDirection
		{
			get
			{
				return -this._swypedir;
			}
		}

		// Token: 0x170034C7 RID: 13511
		// (get) Token: 0x0600C7C7 RID: 51143 RVA: 0x002CAC84 File Offset: 0x002C8E84
		public XGesture.SwypeDirectionType SwypeType
		{
			get
			{
				return this._swype_type;
			}
		}

		// Token: 0x170034C8 RID: 13512
		// (get) Token: 0x0600C7C8 RID: 51144 RVA: 0x002CAC9C File Offset: 0x002C8E9C
		public Vector3 GesturePosition
		{
			get
			{
				return this._gesturepos;
			}
		}

		// Token: 0x170034C9 RID: 13513
		// (get) Token: 0x0600C7C9 RID: 51145 RVA: 0x002CACB4 File Offset: 0x002C8EB4
		public Vector3 TouchPosition
		{
			get
			{
				return this._touchpos;
			}
		}

		// Token: 0x170034CA RID: 13514
		// (get) Token: 0x0600C7CA RID: 51146 RVA: 0x002CACCC File Offset: 0x002C8ECC
		public int FingerId
		{
			get
			{
				return this._finger_id;
			}
		}

		// Token: 0x0600C7CB RID: 51147 RVA: 0x002CACE4 File Offset: 0x002C8EE4
		public void SwypeCounted()
		{
			this._last_swype_used = true;
		}

		// Token: 0x0600C7CC RID: 51148 RVA: 0x002CACEE File Offset: 0x002C8EEE
		public void ClearOneHit()
		{
			this._one = false;
			this._one_up = false;
		}

		// Token: 0x0600C7CD RID: 51149 RVA: 0x002CACFF File Offset: 0x002C8EFF
		public void OnEnterScene()
		{
			this._bFreeze = false;
			this.Cancel();
		}

		// Token: 0x0600C7CE RID: 51150 RVA: 0x002CAD10 File Offset: 0x002C8F10
		public void Feed(XTouchItem touch)
		{
			this._one |= this.OneUpdate(touch);
			this._one_up |= this.OneUpUpdate(touch);
			bool flag = (!this._bFreeze || XSingleton<XScene>.singleton.bSpectator) && ((this._finger_id == -1 && touch.FingerId != XSingleton<XVirtualTab>.singleton.FingerId) || this._finger_id == touch.FingerId);
			if (flag)
			{
				bool flag2 = touch.Phase == 0;
				if (flag2)
				{
					this._start = touch.Position;
					this._swype_start = this._start;
					this._start_at = Time.time;
					this._swype_start_at = this._start_at;
					this._bTouch = true;
				}
				bool bTouch = this._bTouch;
				if (bTouch)
				{
					bool flag3 = XTouch.IsActiveTouch(touch);
					if (flag3)
					{
						this._gesturepos = touch.Position;
						this._bswype = this.SwypeUpdate(touch);
						bool bswype = this._bswype;
						if (bswype)
						{
							this._finger_id = touch.FingerId;
						}
					}
					else
					{
						this.Cancel();
					}
				}
			}
		}

		// Token: 0x0600C7CF RID: 51151 RVA: 0x002CAE2E File Offset: 0x002C902E
		public void Cancel()
		{
			this._bTouch = false;
			this._one = false;
			this._bswype = false;
			this._finger_id = -1;
		}

		// Token: 0x0600C7D0 RID: 51152 RVA: 0x002CAE50 File Offset: 0x002C9050
		private bool OneUpdate(XTouchItem touch)
		{
			bool flag = touch.Phase == null && (touch.FingerId == XFastEnumIntEqualityComparer<XFingerId>.ToInt(XFingerId.XCommon_0) || touch.FingerId == XFastEnumIntEqualityComparer<XFingerId>.ToInt(XFingerId.XCommon_1));
			bool result;
			if (flag)
			{
				this._touchpos = touch.Position;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600C7D1 RID: 51153 RVA: 0x002CAEA8 File Offset: 0x002C90A8
		private bool OneUpUpdate(XTouchItem touch)
		{
			bool flag = touch.FingerId != XFastEnumIntEqualityComparer<XFingerId>.ToInt(XFingerId.XCommon_0) && touch.FingerId != XFastEnumIntEqualityComparer<XFingerId>.ToInt(XFingerId.XCommon_1);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = touch.Phase == 0;
				if (flag2)
				{
					bool flag3 = XSingleton<XUpdater.XUpdater>.singleton.EditorMode && touch.FingerId == 1;
					if (flag3)
					{
						return false;
					}
					this._touchpos = touch.Position;
					this._last_touch_down_at = Time.time;
				}
				else
				{
					bool flag4 = touch.Phase == (TouchPhase)4 || touch.Phase == (TouchPhase)3;
					if (flag4)
					{
						float a = Time.time - this._last_touch_down_at;
						bool flag5 = XSingleton<XCommon>.singleton.IsLess(a, 0.5f / Time.timeScale);
						if (flag5)
						{
							Vector2 vector;
							vector.x = this._touchpos.x - touch.Position.x;
							vector.y = this._touchpos.y - touch.Position.y;
							float num = Mathf.Sqrt(Mathf.Pow(vector.x, 2f) + Mathf.Pow(vector.y, 2f));
							bool flag6 = num < this._dead_zone;
							if (flag6)
							{
								this._touchpos = touch.Position;
								return true;
							}
						}
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x0600C7D2 RID: 51154 RVA: 0x002CB018 File Offset: 0x002C9218
		private bool SwypeUpdate(XTouchItem touch)
		{
			TouchPhase phase = touch.Phase;
			bool flag = phase == (TouchPhase)1;
			if (flag)
			{
				this._end = touch.Position;
				Vector2 vector = this._end - this._swype_start;
				float time = Time.time;
				this._swype_dis = Mathf.Sqrt(Mathf.Pow(vector.x, 2f) + Mathf.Pow(vector.y, 2f));
				bool flag2 = this._swype_dis > this._dead_zone;
				if (flag2)
				{
					this._swype_type = (XSingleton<XCommon>.singleton.IsGreater(this._swype_start.x, (float)Screen.width * 0.5f) ? XGesture.SwypeDirectionType.Right : XGesture.SwypeDirectionType.Left);
					this._swype_start = this._end;
					this._swype_start_at = time;
					this._swypedir.x = vector.x;
					this._swypedir.y = 0f;
					this._swypedir.z = vector.y;
					this._swypedir.Normalize();
					this._gesturepos = this._end;
					this._last_swype_at = time;
					this._last_swype_used = false;
					return true;
				}
			}
			return false;
		}

		// Token: 0x040057F3 RID: 22515
		private readonly float _dead_zone = 10f;

		// Token: 0x040057F4 RID: 22516
		private bool _bTouch = false;

		// Token: 0x040057F5 RID: 22517
		private int _finger_id = -1;

		// Token: 0x040057F6 RID: 22518
		private bool _one = false;

		// Token: 0x040057F7 RID: 22519
		private bool _one_up = false;

		// Token: 0x040057F8 RID: 22520
		private bool _bswype = false;

		// Token: 0x040057F9 RID: 22521
		private bool _last_swype_used = false;

		// Token: 0x040057FA RID: 22522
		private bool _bFreeze = false;

		// Token: 0x040057FB RID: 22523
		private float _last_swype_at = 0f;

		// Token: 0x040057FC RID: 22524
		private float _start_at = 0f;

		// Token: 0x040057FD RID: 22525
		private float _swype_start_at = 0f;

		// Token: 0x040057FE RID: 22526
		private float _swype_dis = 0f;

		// Token: 0x040057FF RID: 22527
		private Vector2 _start = Vector2.zero;

		// Token: 0x04005800 RID: 22528
		private Vector2 _swype_start = Vector2.zero;

		// Token: 0x04005801 RID: 22529
		private Vector2 _double_touch_start = Vector2.zero;

		// Token: 0x04005802 RID: 22530
		private Vector2 _end = Vector2.zero;

		// Token: 0x04005803 RID: 22531
		private Vector3 _swypedir = Vector3.zero;

		// Token: 0x04005804 RID: 22532
		private Vector3 _gesturepos = Vector3.zero;

		// Token: 0x04005805 RID: 22533
		private Vector3 _touchpos = Vector3.zero;

		// Token: 0x04005806 RID: 22534
		private float _last_touch_down_at = 0f;

		// Token: 0x04005807 RID: 22535
		private XGesture.SwypeDirectionType _swype_type;

		// Token: 0x020019D5 RID: 6613
		public enum SwypeDirectionType
		{
			// Token: 0x0400801D RID: 32797
			Left,
			// Token: 0x0400801E RID: 32798
			Right
		}

		// Token: 0x020019D6 RID: 6614
		private enum DoubleTouchPhase
		{
			// Token: 0x04008020 RID: 32800
			Preparing,
			// Token: 0x04008021 RID: 32801
			Prepared
		}
	}
}
