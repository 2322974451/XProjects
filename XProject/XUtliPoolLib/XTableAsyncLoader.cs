// Decompiled with JetBrains decompiler
// Type: XUtliPoolLib.XTableAsyncLoader
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace XUtliPoolLib
{
    public sealed class XTableAsyncLoader
    {
        private bool _executing = false;
        private List<XFileReadAsync> _task_list = new List<XFileReadAsync>();
        private OnLoadedCallback _call_back = (OnLoadedCallback)null;
        private XFileReadAsync currentXfra = (XFileReadAsync)null;
        public static int currentThreadCount = 0;
        public static readonly int AsyncPerTime = 2;

        public bool IsDone
        {
            get
            {
                bool flag = false;
                if (this.currentXfra == null)
                {
                    if (XTableAsyncLoader.currentThreadCount < XTableAsyncLoader.AsyncPerTime)
                        ++XTableAsyncLoader.currentThreadCount;
                    flag = this.InnerExecute();
                }
                else if (this.currentXfra.IsDone)
                {
                    if (XTableAsyncLoader.currentThreadCount < XTableAsyncLoader.AsyncPerTime)
                        ++XTableAsyncLoader.currentThreadCount;
                    XBinaryReader.Return(this.currentXfra.Data);
                    this.currentXfra = (XFileReadAsync)null;
                    flag = this.InnerExecute();
                }
                if (flag)
                {
                    if (this._call_back != null)
                    {
                        this._call_back();
                        this._call_back = (OnLoadedCallback)null;
                    }
                    this._executing = false;
                }
                return flag;
            }
        }

        public void AddTask(string location, CVSReader reader, bool native = false)
        {
            INativePlugin nativePlugin = XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetNativePlugin();
            if (native && nativePlugin != null)
            {
                TextAsset sharedResource = XSingleton<XResourceLoaderMgr>.singleton.GetSharedResource<TextAsset>(location, ".bytes");
                if (!((UnityEngine.Object)sharedResource != (UnityEngine.Object)null))
                    return;
                nativePlugin.InputData((short)0, (short)0, sharedResource.bytes, sharedResource.bytes.Length);
                XSingleton<XResourceLoaderMgr>.singleton.UnSafeDestroyShareResource(location, ".bytes", (UnityEngine.Object)sharedResource);
            }
            else
                this._task_list.Add(new XFileReadAsync()
                {
                    Location = location,
                    Reader = reader
                });
        }

        private bool InnerExecute()
        {
            if (this._task_list.Count <= 0)
                return true;
            if (XTableAsyncLoader.currentThreadCount <= 0)
                return false;
            --XTableAsyncLoader.currentThreadCount;
            this.currentXfra = this._task_list[this._task_list.Count - 1];
            this._task_list.RemoveAt(this._task_list.Count - 1);
            this.ReadFileAsync(this.currentXfra);
            return false;
        }

        public bool Execute(OnLoadedCallback callback = null)
        {
            if (this._executing)
                return false;
            this._call_back = callback;
            this._executing = true;
            this.InnerExecute();
            return true;
        }

        private void ReadFileAsync(XFileReadAsync xfra)
        {
            xfra.Data = XBinaryReader.Get();
            if (!XSingleton<XResourceLoaderMgr>.singleton.ReadText(xfra.Location, ".bytes", xfra.Data, false))
            {
                XResourceLoaderMgr.LoadErrorLog(xfra.Location);
                XBinaryReader.Return(xfra.Data);
                xfra.Data = (XBinaryReader)null;
                xfra.IsDone = true;
                this.currentXfra = (XFileReadAsync)null;
            }
            else
                ThreadPool.QueueUserWorkItem((WaitCallback)(state =>
                {
                    try
                    {
                        if (!xfra.Reader.ReadFile(xfra.Data))
                            XSingleton<XDebug>.singleton.AddErrorLog("in File: ", xfra.Location, xfra.Reader.error);
                    }
                    catch (Exception ex)
                    {
                        XSingleton<XDebug>.singleton.AddErrorLog(ex.Message, " in File: ", xfra.Location, xfra.Reader.error);
                    }
                    xfra.IsDone = true;
                }));
        }
    }
}
