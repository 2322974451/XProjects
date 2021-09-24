using System;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGesture : XSingleton<XGesture>
	{

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

		public bool Working
		{
			get
			{
				return this._finger_id != -1;
			}
		}

		public bool Gestured
		{
			get
			{
				return this._bswype || this._one || this._one_up;
			}
		}

		public bool OneTouch
		{
			get
			{
				return this._one;
			}
		}

		public bool OneUpTouch
		{
			get
			{
				return this._one_up;
			}
		}

		public bool Swype
		{
			get
			{
				return this._bswype;
			}
		}

		public bool LastSwypeUsed
		{
			get
			{
				return this._last_swype_used;
			}
		}

		public float LastSwypeAt
		{
			get
			{
				return this._last_swype_at;
			}
		}

		public float LastSwypeDis
		{
			get
			{
				return this._swype_dis;
			}
		}

		public Vector3 SwypeDirection
		{
			get
			{
				return -this._swypedir;
			}
		}

		public XGesture.SwypeDirectionType SwypeType
		{
			get
			{
				return this._swype_type;
			}
		}

		public Vector3 GesturePosition
		{
			get
			{
				return this._gesturepos;
			}
		}

		public Vector3 TouchPosition
		{
			get
			{
				return this._touchpos;
			}
		}

		public int FingerId
		{
			get
			{
				return this._finger_id;
			}
		}

		public void SwypeCounted()
		{
			this._last_swype_used = true;
		}

		public void ClearOneHit()
		{
			this._one = false;
			this._one_up = false;
		}

		public void OnEnterScene()
		{
			this._bFreeze = false;
			this.Cancel();
		}

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

		public void Cancel()
		{
			this._bTouch = false;
			this._one = false;
			this._bswype = false;
			this._finger_id = -1;
		}

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

		private readonly float _dead_zone = 10f;

		private bool _bTouch = false;

		private int _finger_id = -1;

		private bool _one = false;

		private bool _one_up = false;

		private bool _bswype = false;

		private bool _last_swype_used = false;

		private bool _bFreeze = false;

		private float _last_swype_at = 0f;

		private float _start_at = 0f;

		private float _swype_start_at = 0f;

		private float _swype_dis = 0f;

		private Vector2 _start = Vector2.zero;

		private Vector2 _swype_start = Vector2.zero;

		private Vector2 _double_touch_start = Vector2.zero;

		private Vector2 _end = Vector2.zero;

		private Vector3 _swypedir = Vector3.zero;

		private Vector3 _gesturepos = Vector3.zero;

		private Vector3 _touchpos = Vector3.zero;

		private float _last_touch_down_at = 0f;

		private XGesture.SwypeDirectionType _swype_type;

		public enum SwypeDirectionType
		{

			Left,

			Right
		}

		private enum DoubleTouchPhase
		{

			Preparing,

			Prepared
		}
	}
}
