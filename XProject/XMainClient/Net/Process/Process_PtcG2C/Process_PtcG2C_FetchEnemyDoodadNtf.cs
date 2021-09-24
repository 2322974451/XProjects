

using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal class Process_PtcG2C_FetchEnemyDoodadNtf
    {
        public static void Process(PtcG2C_FetchEnemyDoodadNtf roPtc)
        {
            Vector3 posid = new Vector3(roPtc.Data.doodadInfo.pos.x, roPtc.Data.doodadInfo.pos.y, roPtc.Data.doodadInfo.pos.z);
            uint maxroll = 0;
            XEntity p = (XEntity)null;
            uint playerroll = 0;
            for (int index = 0; index < roPtc.Data.rollInfos.Count; ++index)
            {
                if (roPtc.Data.rollInfos[index].rollValue > maxroll)
                {
                    maxroll = roPtc.Data.rollInfos[index].rollValue;
                    p = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(roPtc.Data.rollInfos[index].roleID);
                }
                if ((long)roPtc.Data.rollInfos[index].roleID == (long)XSingleton<XEntityMgr>.singleton.Player.ID)
                    playerroll = roPtc.Data.rollInfos[index].rollValue;
                if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_PVP)
                    XDocuments.GetSpecificDocument<XBattleCaptainPVPDocument>(XBattleCaptainPVPDocument.uuID).AddGameInfo(roPtc.Data.rollInfos[index].roleID, roPtc.Data.doodadInfo.id);
                else if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_CASTLE_FIGHT)
                    XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID).OnAddBuff(roPtc.Data.rollInfos[index].roleID, roPtc.Data.doodadInfo.id);
            }
            XSingleton<XLevelDoodadMgr>.singleton.OnDoodadPickedSyncSucc(roPtc.Data.doodadInfo.index, roPtc.Data.doodadInfo.waveid, posid, p, maxroll, playerroll);
        }
    }
}
