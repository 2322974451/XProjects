// Decompiled with JetBrains decompiler
// Type: XUtliPoolLib.IXNGUI
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using System;
using UnityEngine;

namespace XUtliPoolLib
{
    public interface IXNGUI : IXInterface
    {
        bool XNGUIEnable();

        GameObject XNGUICreate(string locate);

        GameObject XPrefabCreate(string locate);

        bool XNGUIDestory(UnityEngine.Object o);

        T XNGUIResource<T>(string locate, bool ignore_null) where T : UnityEngine.Object;

        AssetBundleRequest XNGUISharedResourceAsync<T>(
          string locate,
          bool ignore_null = false)
          where T : UnityEngine.Object;

        bool XNGUIIsDecompress();

        bool XNGUIDecompressStreamAssets(Action<float> percent);

        string XNGUIGetDecompressProgress();

        bool XNGUIDecompressZipBytes(string zipFile, byte[] stream);

        void XNGUIWWW(Action<string> errorinfo);
    }
}
