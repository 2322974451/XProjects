// Decompiled with JetBrains decompiler
// Type: XMainClient.XKeyboard
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XKeyboard : XSingleton<XKeyboard>
    {
        private XTouchItem[] _touches = new XTouchItem[XTouch.MultiTouchCount];
        private int _touch_count_this_frame = 0;
        private bool _bAxis = false;
        private float _x = 0.0f;
        private float _y = 0.0f;
        private Vector3 _lastMousePos = Vector3.zero;

        public bool Enabled => XSingleton<XUpdater.XUpdater>.singleton.EditorMode;

        public int touchCount => this._touch_count_this_frame;

        public XKeyboard()
        {
            for (int index = 0; index < XTouch.MultiTouchCount; ++index)
                this._touches[index] = new XTouchItem();
        }

        public XTouchItem GetTouch(int idx) => this._touches[idx];

        public void Update()
        {
            this._touch_count_this_frame = 0;
            this._bAxis = false;
            if (Input.GetMouseButton(0))
            {
                this._touches[this._touch_count_this_frame].faketouch.fingerId = XFastEnumIntEqualityComparer<XFingerId>.ToInt(XFingerId.XCommon_0);
                this._touches[this._touch_count_this_frame].faketouch.position = (Vector2)Input.mousePosition;
                this._touches[this._touch_count_this_frame].faketouch.deltaTime = Time.smoothDeltaTime;
                this._touches[this._touch_count_this_frame].faketouch.deltaPosition = (Vector2)(Input.mousePosition - this._lastMousePos);
                this._touches[this._touch_count_this_frame].faketouch.phase = Input.GetMouseButtonDown(0) ? TouchPhase.Began : ((double)this._touches[this._touch_count_this_frame].faketouch.deltaPosition.sqrMagnitude > 1.0 ? TouchPhase.Moved : TouchPhase.Stationary);
                this._touches[this._touch_count_this_frame].faketouch.tapCount = 1;
                this._touches[this._touch_count_this_frame].Fake = true;
                this._lastMousePos = Input.mousePosition;
                ++this._touch_count_this_frame;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                this._touches[this._touch_count_this_frame].faketouch.fingerId = XFastEnumIntEqualityComparer<XFingerId>.ToInt(XFingerId.XCommon_0);
                this._touches[this._touch_count_this_frame].faketouch.position = (Vector2)Input.mousePosition;
                this._touches[this._touch_count_this_frame].faketouch.deltaTime = Time.smoothDeltaTime;
                this._touches[this._touch_count_this_frame].faketouch.phase = TouchPhase.Ended;
                this._touches[this._touch_count_this_frame].faketouch.tapCount = 1;
                this._touches[this._touch_count_this_frame].Fake = true;
                ++this._touch_count_this_frame;
            }
            this._bAxis = true;
            int num1 = 0;
            int num2 = 0;
            if (Input.GetKey(KeyCode.A))
                --num1;
            if (Input.GetKey(KeyCode.D))
                ++num1;
            if (Input.GetKey(KeyCode.S))
                --num2;
            if (Input.GetKey(KeyCode.W))
                ++num2;
            if (num1 != 0 || (uint)num2 > 0U)
            {
                this._touches[this._touch_count_this_frame].faketouch.fingerId = XFastEnumIntEqualityComparer<XFingerId>.ToInt(XFingerId.XCommon_1);
                this._touches[this._touch_count_this_frame].faketouch.deltaTime = Time.smoothDeltaTime;
                this._touches[this._touch_count_this_frame].faketouch.phase = (double)this._x != 0.0 || (double)this._y != 0.0 ? TouchPhase.Moved : TouchPhase.Began;
                this._touches[this._touch_count_this_frame].faketouch.position = this._touches[this._touch_count_this_frame].faketouch.phase == TouchPhase.Began ? new Vector2(XSingleton<XVirtualTab>.singleton.MaxDistance, XSingleton<XVirtualTab>.singleton.MaxDistance) : (num1 == 0 || num2 == 0 ? new Vector2(XSingleton<XVirtualTab>.singleton.MaxDistance + (float)num1 * XSingleton<XVirtualTab>.singleton.MaxDistance, XSingleton<XVirtualTab>.singleton.MaxDistance + (float)num2 * XSingleton<XVirtualTab>.singleton.MaxDistance) : new Vector2(XSingleton<XVirtualTab>.singleton.MaxDistance + (float)((double)num1 * (double)XSingleton<XVirtualTab>.singleton.MaxDistance * 0.707000017166138), XSingleton<XVirtualTab>.singleton.MaxDistance + (float)((double)num2 * (double)XSingleton<XVirtualTab>.singleton.MaxDistance * 0.707000017166138)));
                this._touches[this._touch_count_this_frame].faketouch.tapCount = 1;
                this._touches[this._touch_count_this_frame].Fake = true;
                ++this._touch_count_this_frame;
            }
            else if ((double)this._x != 0.0 || (double)this._y != 0.0)
            {
                this._touches[this._touch_count_this_frame].faketouch.fingerId = XFastEnumIntEqualityComparer<XFingerId>.ToInt(XFingerId.XCommon_1);
                this._touches[this._touch_count_this_frame].faketouch.position = new Vector2(XSingleton<XVirtualTab>.singleton.MaxDistance, XSingleton<XVirtualTab>.singleton.MaxDistance);
                this._touches[this._touch_count_this_frame].faketouch.deltaTime = Time.smoothDeltaTime;
                this._touches[this._touch_count_this_frame].faketouch.phase = TouchPhase.Ended;
                this._touches[this._touch_count_this_frame].faketouch.tapCount = 1;
                this._touches[this._touch_count_this_frame].Fake = true;
                ++this._touch_count_this_frame;
            }
            this._x = (float)num1;
            this._y = (float)num2;
            if (this._bAxis)
                return;
            this._x = 0.0f;
            this._y = 0.0f;
        }
    }
}
