

using UnityEngine;

namespace XMainClient
{
    internal class Process_PtcG2C_MobaSignalBroadcast
    {
        public static void Process(PtcG2C_MobaSignalBroadcast roPtc)
        {
            XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
            Vector3 pos = new Vector3((float)(roPtc.Data.posxz >> 16) / 100f, 0.0f, (float)(roPtc.Data.posxz & (uint)ushort.MaxValue) / 100f);
            specificDocument.OnSignalGet(roPtc.Data.uid, roPtc.Data.type, pos);
        }
    }
}
