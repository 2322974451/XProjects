

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
