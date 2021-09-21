// Decompiled with JetBrains decompiler
// Type: XMainClient.X3DTouchMgr
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using MiniJSON;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class X3DTouchMgr : XSingleton<X3DTouchMgr>
    {
        private float _last_touch_time = 0.0f;
        private float _pointx = 0.0f;
        private float _pointy = 0.0f;

        public void OnProcess3DTouch(string msg = "")
        {
            if ((double)Time.time - (double)this._last_touch_time < 1.0)
                return;
            this._last_touch_time = Time.time;
            if (XSingleton<XChatIFlyMgr>.singleton.IsRecording() || XSingleton<XChatApolloMgr>.singleton.IsInRecordingState || !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Photo))
                return;
            XSingleton<XDebug>.singleton.AddLog("The dict: ", msg);
            if (!string.IsNullOrEmpty(msg) && Json.Deserialize(msg) is Dictionary<string, object> dictionary1 && dictionary1.ContainsKey("data") && dictionary1["data"] is Dictionary<string, object> dictionary2)
            {
                if (dictionary2.ContainsKey("index_x") && dictionary2["index_x"] != null)
                    float.TryParse(dictionary2["index_x"].ToString(), out this._pointx);
                if (dictionary2.ContainsKey("index_y") && dictionary2["index_y"] != null)
                    float.TryParse(dictionary2["index_y"].ToString(), out this._pointy);
                float num = 2f;
                if (Screen.height == 1080 && Screen.width == 1920)
                    num = 2.6f;
                this._pointx *= num;
                this._pointy = (float)Screen.height - this._pointy * num;
            }
            XSingleton<XDebug>.singleton.AddLog("Process 3d touch");
            if (XSingleton<XSceneMgr>.singleton.IsPVPScene() || XSingleton<XSceneMgr>.singleton.IsPVEScene())
            {
                if (XSingleton<XScene>.singleton.GameCamera == null || XSingleton<XEntityMgr>.singleton.Player == null)
                    return;
                Vector2 vector2 = new Vector2(this._pointx, this._pointy);
                XSingleton<XDebug>.singleton.AddLog("Touch screen pos: ", vector2.x.ToString(), ", y:", vector2.y.ToString());
                XSingleton<XDebug>.singleton.AddLog("Is touch on ui: ", XTouch.PointOnUI((Vector3)vector2).ToString());
                if (!XTouch.PointOnUI((Vector3)vector2) && (!XSingleton<XVirtualTab>.singleton.Feeding || (double)vector2.x > (double)(Screen.width / 2)) && !XSingleton<XScene>.singleton.GameCamera.BackToPlayer())
                    XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_CAMERA_ROT"), "fece00");
            }
            else
            {
                switch (XSingleton<XScene>.singleton.SceneType)
                {
                    case SceneType.SCENE_HALL:
                    case SceneType.SCENE_GUILD_HALL:
                    case SceneType.SCENE_FAMILYGARDEN:
                    case SceneType.SCENE_LEISURE:
                        this.OnProcessScreenShot(msg);
                        break;
                }
            }
        }

        private void OnProcessScreenShot(string msg)
        {
            if (XSingleton<XVirtualTab>.singleton.Feeding && (double)this._pointx <= (double)(Screen.width / 2) || DlgBase<GuildTerritoryMainDlg, GuildTerritoryMainBehaviour>.singleton.IsLoaded() && DlgBase<GuildTerritoryMainDlg, GuildTerritoryMainBehaviour>.singleton.IsVisible() || DlgBase<SuperRiskDlg, SuperRiskDlgBehaviour>.singleton.IsLoaded() && DlgBase<SuperRiskDlg, SuperRiskDlgBehaviour>.singleton.IsVisible() || DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.IsLoaded() && DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.IsVisible() || DlgBase<XTeamView, TabDlgBehaviour>.singleton.IsLoaded() && DlgBase<XTeamView, TabDlgBehaviour>.singleton.IsVisible())
                return;
            if (DlgBase<SevenLoginDlg, SevenLoginBehaviour>.singleton.IsLoaded() && DlgBase<SevenLoginDlg, SevenLoginBehaviour>.singleton.IsVisible())
                DlgBase<SevenLoginDlg, SevenLoginBehaviour>.singleton.SetVisible(false, true);
            if (DlgBase<XOptionsView, XOptionsBehaviour>.singleton.IsLoaded() && DlgBase<XOptionsView, XOptionsBehaviour>.singleton.IsVisible())
                DlgBase<XOptionsView, XOptionsBehaviour>.singleton.SetVisible(false, true);
            if (DlgBase<TitleDlg, TitleDlgBehaviour>.singleton.IsLoaded() && DlgBase<TitleDlg, TitleDlgBehaviour>.singleton.IsVisible())
                DlgBase<TitleDlg, TitleDlgBehaviour>.singleton.SetVisibleWithAnimation(false, (DlgBase<TitleDlg, TitleDlgBehaviour>.OnAnimationOver)null);
            if (DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.IsLoaded() && DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.IsVisible())
                DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.SetVisible(false, true);
            if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsLoaded() && DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible() && DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.fakeShow)
            {
                DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.SetVisible(true, true);
                DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.ShowMainView();
            }
            else
            {
                if (!DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.IsInReadyScreenShowView())
                    return;
                DlgBase<ScreenShotShareView, ScreenShotShareBehaviour>.singleton.IOS3DTouchScreenShot();
            }
        }

        private void OnCameraStraightForward()
        {
        }
    }
}
