// Decompiled with JetBrains decompiler
// Type: XMainClient.Process_PtcG2C_PositionDebug
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

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
