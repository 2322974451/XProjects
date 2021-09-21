// Decompiled with JetBrains decompiler
// Type: XMainClient.Process_PtcG2C_MobaSignalBroadcast
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

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
