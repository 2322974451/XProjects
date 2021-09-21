// Decompiled with JetBrains decompiler
// Type: XMainClient.heromvp
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class heromvp
    {
        private static uint _token = 0;
        private static XActor _actor = (XActor)null;
        private static bool _started = false;
        private static Vector3 _pos = Vector3.zero;

        public static bool Do(List<XActor> actors)
        {
            if (!heromvp._started)
            {
                heromvp._started = true;
                heromvp.Start();
            }
            else if (!XSingleton<XCutScene>.singleton.IsPlaying)
            {
                heromvp._started = false;
                heromvp.End();
            }
            return true;
        }

        private static void Start()
        {
            DlgBase<HeroBattleMVPDlg, HeroBattleMVPBehaviour>.singleton.SetVisible(true, true);
            XHeroBattleDocument specificDocument1 = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
            HeroBattleMapCenter.RowData bySceneId = specificDocument1.HeroBattleMapReader.GetBySceneID(XSingleton<XScene>.singleton.SceneID);
            Vector3 vector3 = Vector3.one;
            float angle = 0.0f;
            if (bySceneId != null && bySceneId.MVPPos.Length >= 4)
            {
                vector3 = new Vector3(bySceneId.MVPPos[0], bySceneId.MVPPos[1], bySceneId.MVPPos[2]);
                angle = bySceneId.MVPPos[3];
            }
            heromvp._pos = vector3;
            heromvp._pos.y = XSingleton<XScene>.singleton.TerrainY(heromvp._pos);
            XLevelRewardDocument specificDocument2 = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
            XLevelRewardDocument.HeroBattleData heroBattleData = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE ? specificDocument2.HeroData : specificDocument2.MobaData;
            OverWatchTable.RowData byHeroId = specificDocument1.OverWatchReader.GetByHeroID(heroBattleData.MvpHeroID);
            if (byHeroId == null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("MvpHeroID error! ID = ", heroBattleData.MvpHeroID.ToString());
            }
            else
            {
                uint presentId = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(byHeroId.StatisticsID[0]).PresentID;
                XEntityPresentation.RowData byPresentId = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(presentId);
                if (byPresentId == null)
                {
                    XSingleton<XDebug>.singleton.AddErrorLog("MvpHeroID error! ID = ", presentId.ToString());
                }
                else
                {
                    string str = "Animation/" + byPresentId.AnimLocation;
                    heromvp._actor = new XActor("Prefabs/" + byPresentId.Prefab, heromvp._pos, XSingleton<XCommon>.singleton.FloatToQuaternion(angle), str + byHeroId.CutSceneAniamtion);
                    heromvp._actor.Initilize(0);
                    heromvp._actor.GetCurrentAnimLength(new OverrideAnimCallback(heromvp.AnimLoadCallback));
                }
            }
        }

        private static void AnimLoadCallback(XAnimationClip clip)
        {
            float interval = (Object)clip != (Object)null ? clip.length : 0.0f;
            if ((double)interval > 0.0)
                heromvp._token = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(heromvp.Idled), (object)null);
            else
                heromvp.Idled((object)null);
        }

        private static void Idled(object o)
        {
            if (heromvp._actor == null)
                return;
            XHeroBattleDocument specificDocument1 = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
            XLevelRewardDocument specificDocument2 = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
            XLevelRewardDocument.HeroBattleData heroBattleData = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE ? specificDocument2.HeroData : specificDocument2.MobaData;
            OverWatchTable.RowData byHeroId = specificDocument1.OverWatchReader.GetByHeroID(heroBattleData.MvpHeroID);
            if (byHeroId == null)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("MvpHeroID error! ID = ", heroBattleData.MvpHeroID.ToString());
            }
            else
            {
                uint presentId = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(byHeroId.StatisticsID[0]).PresentID;
                XEntityPresentation.RowData byPresentId = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(presentId);
                if (byPresentId == null)
                {
                    XSingleton<XDebug>.singleton.AddErrorLog("MvpHeroID error! ID = ", presentId.ToString());
                }
                else
                {
                    if (string.IsNullOrEmpty(byHeroId.CutSceneIdleAni))
                        return;
                    string str = "Animation/" + byPresentId.AnimLocation;
                    heromvp._actor.OverrideAnim(str + byHeroId.CutSceneIdleAni);
                }
            }
        }

        private static void End()
        {
            XSingleton<XTimerMgr>.singleton.KillTimer(heromvp._token);
            DlgBase<HeroBattleMVPDlg, HeroBattleMVPBehaviour>.singleton.SetVisible(false, true);
            if (heromvp._actor == null)
                return;
            heromvp._actor.Uninitilize();
            heromvp._actor = (XActor)null;
        }
    }
}
