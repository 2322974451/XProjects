

using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XTouch : XSingleton<XTouch>
    {
        public static int MultiTouchCount = 2;
        private bool _on_screen_save = false;
        private float _screenSave = 0.0f;
        private XTouchItem _touches = new XTouchItem();

        public static bool PointOnUI(Vector3 point)
        {
            RaycastHit hitInfo;
            return Physics.Raycast(XSingleton<XGameUI>.singleton.UICamera.ScreenPointToRay(point), out hitInfo, float.PositiveInfinity, 32) && !hitInfo.collider.CompareTag("ChatUI");
        }

        public static bool IsActiveTouch(XTouchItem touch) => touch.Phase != TouchPhase.Ended && touch.Phase != TouchPhase.Canceled;

        public void Update()
        {
            XSingleton<XGesture>.singleton.ClearOneHit();
            this.UpdateTouch();
        }

        private void UpdateTouch()
        {
            for (int index = 0; index < Input.touchCount && index < XTouch.MultiTouchCount; ++index)
            {
                this._touches.Fake = false;
                this._touches.touch = Input.GetTouch(index);
                this.HandleTouch(this._touches);
            }
            if (XSingleton<XKeyboard>.singleton.Enabled)
            {
                XSingleton<XKeyboard>.singleton.Update();
                for (int idx = 0; idx < XSingleton<XKeyboard>.singleton.touchCount; ++idx)
                    this.HandleTouch(XSingleton<XKeyboard>.singleton.GetTouch(idx));
            }
            if (XSingleton<XSirJoystick>.singleton.Enabled)
            {
                XSingleton<XSirJoystick>.singleton.Update();
                for (int touch = 0; touch < XSingleton<XSirJoystick>.singleton.touchCount; ++touch)
                    this.HandleTouch(XSingleton<XSirJoystick>.singleton.GetTouch(touch));
            }
            if (XSingleton<XGyroscope>.singleton.Enabled)
            {
                XSingleton<XGyroscope>.singleton.Update();
                for (int idx = 0; idx < XSingleton<XGyroscope>.singleton.touchCount; ++idx)
                    this.HandleTouch(XSingleton<XGyroscope>.singleton.GetTouch(idx));
            }
            this.UpdateScreenSave();
        }

        private void UpdateScreenSave()
        {
            if (this._on_screen_save)
            {
                if (Input.touchCount > 0)
                {
                    XSingleton<XUpdater.XUpdater>.singleton.XPlatform.ResetScreenLightness();
                    this._on_screen_save = false;
                    this._screenSave = 0.0f;
                }
            }
            else if (Input.touchCount == 0)
                this._screenSave += Time.unscaledDeltaTime;
            else
                this._screenSave = 0.0f;
            if ((double)this._screenSave <= (double)XSingleton<XGlobalConfig>.singleton.ScreenSaveLimit)
                return;
            this._on_screen_save = true;
            this._screenSave = 0.0f;
            XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SetScreenLightness(XSingleton<XGlobalConfig>.singleton.ScreenSavePercentage);
        }

        private void HandleTouch(XTouchItem touch)
        {
            if (XTouch.PointOnUI((Vector3)touch.Position))
            {
                switch (touch.Phase)
                {
                    case TouchPhase.Began:
                        if (touch.Fake)
                        {
                            touch.faketouch.phase = TouchPhase.Canceled;
                            break;
                        }
                        touch.Convert2FakeTouch(TouchPhase.Canceled);
                        break;
                }
            }
            XSingleton<XVirtualTab>.singleton.Feed(touch);
            XSingleton<XGesture>.singleton.Feed(touch);
        }
    }
}
