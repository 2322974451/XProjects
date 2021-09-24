

using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal class Process_PtcG2C_PositionDebug
    {
        public static void Process(PtcG2C_PositionDebug roPtc)
        {
            for (int index = 0; index < roPtc.Data.positions.Count; ++index)
            {
                PositionCheck position = roPtc.Data.positions[index];
                Vector3 pos = new Vector3(position.position.x, position.position.y, position.position.z);
                Quaternion quaternion = XSingleton<XCommon>.singleton.FloatToQuaternion(position.face);
                ulong uid = position.uid;
                XSyncDebug.DrawDebug(position.uid, pos, quaternion);
            }
        }
    }
}
