// Decompiled with JetBrains decompiler
// Type: XMainClient.XGyroscope
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XGyroscope : XSingleton<XGyroscope>
    {
        private XTouchItem _touches = new XTouchItem();
        private bool _enabled = false;
        private static Vector2 _init_pos = new Vector2((float)Screen.width * 0.55f, (float)Screen.height * 0.55f);
        private static Vector2 _last_pos = XGyroscope._init_pos;
        private static Vector2 _curr_pos = XGyroscope._init_pos;
        private int _touch_count_this_frame = 0;
        private float _frequency = 30f;
        private float _scale = 0.2f;
        private float _deadzone = 0.01f;

        public float Scale => this._scale;

        public float DeadZone => this._deadzone;

        public float Frequency => this._frequency;

        public bool Enabled
        {
            get => this._enabled;
            set
            {
                if (this._enabled != value)
                {
                    this._touch_count_this_frame = 0;
                    this._enabled = value;
                }
                Input.gyro.enabled = this._enabled;
                if (this._enabled)
                {
                    this._scale = XSingleton<XUpdater.XUpdater>.singleton.EditorMode ? 1f : XSingleton<XGlobalConfig>.singleton.GyroScale;
                    this._deadzone = XSingleton<XGlobalConfig>.singleton.GyroDeadZone;
                    this._frequency = XSingleton<XGlobalConfig>.singleton.GyroFrequency;
                    Input.gyro.updateInterval = 1f / this._frequency;
                }
                this.Cancel();
                XSingleton<XGesture>.singleton.Cancel();
            }
        }

        public int touchCount => this._touch_count_this_frame;

        public void OnEnterScene()
        {
            XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
            if (specificDocument == null)
                return;
            this.Enabled = (uint)specificDocument.GetValue(XOptionsDefine.OD_Gyro) > 0U;
        }

        public void Update()
        {
            this._touch_count_this_frame = 0;
            if (!this.GetCurrentPos())
                return;
            this._touches.faketouch.fingerId = XFastEnumIntEqualityComparer<XFingerId>.ToInt(XFingerId.XGyroscope_0);
            this._touches.faketouch.position = XGyroscope._curr_pos;
            this._touches.faketouch.deltaTime = Time.smoothDeltaTime;
            this._touches.faketouch.deltaPosition = XGyroscope._curr_pos - XGyroscope._last_pos;
            this._touches.faketouch.phase = XGyroscope._curr_pos == XGyroscope._init_pos ? TouchPhase.Ended : (XGyroscope._last_pos == XGyroscope._init_pos ? TouchPhase.Began : TouchPhase.Moved);
            this._touches.faketouch.tapCount = 1;
            this._touches.Fake = true;
            XGyroscope._last_pos = XGyroscope._curr_pos;
            ++this._touch_count_this_frame;
        }

        public XTouchItem GetTouch(int idx) => this._touches;

        public void Set(float scale, float times, float deadzone)
        {
            if (!this.Enabled)
                return;
            this._scale = XSingleton<XUpdater.XUpdater>.singleton.EditorMode ? 1f : scale;
            this._deadzone = deadzone;
            this._frequency = times;
            Input.gyro.updateInterval = 1f / this._frequency;
        }

        private bool GetCurrentPos()
        {
            float num1 = 0.0f;
            float num2 = 0.0f;
            if (XSingleton<XUpdater.XUpdater>.singleton.EditorMode)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                    --num1;
                if (Input.GetKey(KeyCode.RightArrow))
                    ++num1;
                if (Input.GetKey(KeyCode.DownArrow))
                    --num2;
                if (Input.GetKey(KeyCode.UpArrow))
                    ++num2;
            }
            else
            {
                Vector3 rotationRateUnbiased = Input.gyro.rotationRateUnbiased;
                rotationRateUnbiased.z = 0.0f;
                if ((double)rotationRateUnbiased.sqrMagnitude < (double)this._deadzone * (double)this._deadzone)
                {
                    num1 = num2 = 0.0f;
                }
                else
                {
                    num1 = (float)-((double)rotationRateUnbiased.y * 57.2957801818848);
                    num2 = rotationRateUnbiased.x * 57.29578f;
                }
            }
            if ((double)num1 != 0.0 || (double)num2 != 0.0)
            {
                XGyroscope._curr_pos = XGyroscope._last_pos + new Vector2(this._scale * num1, this._scale * num2);
                return true;
            }
            if (!(XGyroscope._curr_pos != XGyroscope._init_pos))
                return false;
            XGyroscope._last_pos = XGyroscope._init_pos;
            XGyroscope._curr_pos = XGyroscope._init_pos;
            return true;
        }

        public void Cancel()
        {
            XGyroscope._last_pos = XGyroscope._init_pos;
            XGyroscope._curr_pos = XGyroscope._init_pos;
        }
    }
}
