// Decompiled with JetBrains decompiler
// Type: XMainClient.XSirJoystick
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XSirJoystick : XSingleton<XSirJoystick>
    {
        private XTouchItem[] _touches = new XTouchItem[XSirJoystick._touch_count_total_frame];
        private Vector2 _RotatePos = new Vector2((float)Screen.width * 0.75f, (float)Screen.height * 0.5f);
        private Vector2 _RockerPos = new Vector2((float)Screen.width * 0.2f, (float)Screen.height * 0.25f);
        private Vector2 _RotateRangeX = new Vector2((float)Screen.width * 0.5f, (float)Screen.width * 1f);
        private Vector2 _RotateRangeY = new Vector2((float)Screen.height * 0.2f, (float)Screen.height * 0.8f);
        private int _touch_count_this_frame = 0;
        private static int _touch_count_total_frame = 2;
        private float _x = 0.0f;
        private float _y = 0.0f;
        private float _z = 0.0f;
        private float _rz = 0.0f;
        private Vector2 _tempPos;
        private int _RotateStep = 10;

        private IXGameSirControl SirControl => XSingleton<XUpdater.XUpdater>.singleton.GameSirControl;

        public XSirJoystick()
        {
            for (int index = 0; index < XSirJoystick._touch_count_total_frame; ++index)
                this._touches[index] = new XTouchItem();
        }

        public XTouchItem GetTouch(int touch) => this._touches[touch];

        public int touchCount => this._touch_count_this_frame;

        public bool Enabled => this.SirControl != null && this.SirControl.IsConnected();

        public void Update()
        {
            this._touch_count_this_frame = 0;
            this.OnTouch();
            this.UpdateRocker();
            this.UpdateRotate();
        }

        private void OnTouch()
        {
            if (!this.SirControl.GetButton(XGameSirKeyCode.BTN_THUMBL))
                return;
            XSingleton<XScene>.singleton.GameCamera.BackToPlayer();
        }

        private void UpdateRocker()
        {
            float axis = this.SirControl.GetAxis(XGameSirKeyCode.AXIS_X);
            float num = -this.SirControl.GetAxis(XGameSirKeyCode.AXIS_Y);
            if ((double)axis != 0.0 || (double)num != 0.0)
            {
                this._touches[this._touch_count_this_frame].faketouch.fingerId = XFastEnumIntEqualityComparer<XFingerId>.ToInt(XFingerId.XJoystick_1);
                this._touches[this._touch_count_this_frame].faketouch.deltaTime = Time.smoothDeltaTime;
                this._touches[this._touch_count_this_frame].faketouch.phase = (double)this._x != 0.0 || (double)this._y != 0.0 ? TouchPhase.Moved : TouchPhase.Began;
                this._touches[this._touch_count_this_frame].faketouch.position = this._touches[this._touch_count_this_frame].faketouch.phase == TouchPhase.Began ? this._RockerPos : ((double)axis == 0.0 || (double)num == 0.0 ? new Vector2(this._RockerPos.x + axis * XSingleton<XVirtualTab>.singleton.MaxDistance, this._RockerPos.y + num * XSingleton<XVirtualTab>.singleton.MaxDistance) : new Vector2(this._RockerPos.x + (float)((double)axis * (double)XSingleton<XVirtualTab>.singleton.MaxDistance * 0.707000017166138), this._RockerPos.y + (float)((double)num * (double)XSingleton<XVirtualTab>.singleton.MaxDistance * 0.707000017166138)));
                this._touches[this._touch_count_this_frame].faketouch.tapCount = 1;
                this._touches[this._touch_count_this_frame].Fake = true;
                ++this._touch_count_this_frame;
            }
            else if ((double)this._x != 0.0 || (double)this._y != 0.0)
            {
                this._touches[this._touch_count_this_frame].faketouch.fingerId = XFastEnumIntEqualityComparer<XFingerId>.ToInt(XFingerId.XJoystick_1);
                this._touches[this._touch_count_this_frame].faketouch.position = this._RockerPos;
                this._touches[this._touch_count_this_frame].faketouch.deltaTime = Time.smoothDeltaTime;
                this._touches[this._touch_count_this_frame].faketouch.phase = TouchPhase.Ended;
                this._touches[this._touch_count_this_frame].faketouch.tapCount = 1;
                this._touches[this._touch_count_this_frame].Fake = true;
                ++this._touch_count_this_frame;
            }
            this._x = axis;
            this._y = num;
        }

        private void UpdateRotate()
        {
            float axis = this.SirControl.GetAxis(XGameSirKeyCode.AXIS_Z);
            float y = -this.SirControl.GetAxis(XGameSirKeyCode.AXIS_RZ);
            if ((double)axis != 0.0 || (double)y != 0.0)
            {
                this._touches[this._touch_count_this_frame].faketouch.fingerId = XFastEnumIntEqualityComparer<XFingerId>.ToInt(XFingerId.XJoystick_0);
                this._touches[this._touch_count_this_frame].faketouch.deltaTime = Time.smoothDeltaTime;
                this._touches[this._touch_count_this_frame].faketouch.deltaPosition = new Vector2(axis, y);
                if ((double)this._z == 0.0 && (double)this._rz == 0.0)
                {
                    this._touches[this._touch_count_this_frame].faketouch.phase = TouchPhase.Began;
                    this._touches[this._touch_count_this_frame].faketouch.position = this._RotatePos;
                    this._tempPos = this._RotatePos;
                }
                else if ((double)this._touches[this._touch_count_this_frame].faketouch.deltaPosition.sqrMagnitude >= 0.5)
                {
                    this._tempPos += this._touches[this._touch_count_this_frame].faketouch.deltaPosition * (float)this._RotateStep;
                    this._tempPos.x = Mathf.Clamp(this._tempPos.x, this._RotateRangeX.x, this._RotateRangeX.y);
                    this._tempPos.y = Mathf.Clamp(this._tempPos.y, this._RotateRangeY.x, this._RotateRangeY.y);
                    this._touches[this._touch_count_this_frame].faketouch.phase = TouchPhase.Moved;
                    this._touches[this._touch_count_this_frame].faketouch.position = this._tempPos;
                }
                this._touches[this._touch_count_this_frame].faketouch.tapCount = 1;
                this._touches[this._touch_count_this_frame].Fake = true;
                ++this._touch_count_this_frame;
            }
            else if ((double)this._z != 0.0 || (double)this._rz != 0.0)
            {
                this._touches[this._touch_count_this_frame].faketouch.fingerId = XFastEnumIntEqualityComparer<XFingerId>.ToInt(XFingerId.XJoystick_0);
                this._touches[this._touch_count_this_frame].faketouch.position = this._tempPos;
                this._touches[this._touch_count_this_frame].faketouch.deltaTime = Time.smoothDeltaTime;
                this._touches[this._touch_count_this_frame].faketouch.phase = TouchPhase.Ended;
                this._touches[this._touch_count_this_frame].faketouch.tapCount = 1;
                this._touches[this._touch_count_this_frame].Fake = true;
                ++this._touch_count_this_frame;
            }
            this._z = axis;
            this._rz = y;
        }
    }
}
