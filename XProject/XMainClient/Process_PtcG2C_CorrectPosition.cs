// Decompiled with JetBrains decompiler
// Type: XMainClient.Process_PtcG2C_CorrectPosition
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal class Process_PtcG2C_CorrectPosition
    {
        public static void Process(PtcG2C_CorrectPosition roPtc)
        {
            XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(roPtc.Data.uid);
            if (entityConsiderDeath == null)
                return;
            Vector3 pos = new Vector3((float)roPtc.Data.pos_x / 100f, (float)roPtc.Data.pos_y / 100f, (float)roPtc.Data.pos_z / 100f);
            Vector3 angle = XSingleton<XCommon>.singleton.FloatToAngle((float)roPtc.Data.face / 10f);
            entityConsiderDeath.CorrectMe(pos, angle, fade: roPtc.Data.bTransfer);
        }
    }
}
