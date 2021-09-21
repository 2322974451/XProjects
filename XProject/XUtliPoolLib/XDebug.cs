// Decompiled with JetBrains decompiler
// Type: XUtliPoolLib.XDebug
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnityEngine;

namespace XUtliPoolLib
{
    public class XDebug : XSingleton<XDebug>
    {
        private int _OutputChannels = 0;
        private IPlatform _platform = (IPlatform)null;
        private bool _showTimeStick = true;
        private bool _showLog = true;
        private StringBuilder _buffer = new StringBuilder();
        private XDebug.LayerInfo[] m_LayerInfo = new XDebug.LayerInfo[2]
        {
      new XDebug.LayerInfo(),
      new XDebug.LayerInfo()
        };
        private int m_MaxLayer = 2;
        private bool m_record = false;
        private bool m_recordStart = false;
        private XDebug.RecordChannel m_RecordChannel = XDebug.RecordChannel.ENone;

        public XDebug() => this._OutputChannels = 5;

        public void Init(IPlatform platform, XFileLog log) => this._platform = XSingleton<XUpdater.XUpdater>.singleton.XPlatform;

        public void AddLog(
          string log1,
          string log2 = null,
          string log3 = null,
          string log4 = null,
          string log5 = null,
          string log6 = null,
          XDebugColor color = XDebugColor.XDebug_None)
        {
            if (this._platform == null || this._platform.IsPublish())
                return;
            this.AddLog(XDebugChannel.XDebug_Default, log1, log2, log3, log4, log5, log6, color);
        }

        public void AddLog2(string format, params object[] args)
        {
            if (!this._showLog || this._platform == null || this._platform.IsPublish())
                return;
            this.AddLog(string.Format(format, args));
        }

        public void AddLog(
          XDebugChannel channel,
          string log1,
          string log2 = null,
          string log3 = null,
          string log4 = null,
          string log5 = null,
          string log6 = null,
          XDebugColor color = XDebugColor.XDebug_None)
        {
            if (!this._showLog || this._platform == null || this._platform.IsPublish() || ((XDebugChannel)this._OutputChannels & channel) <= XDebugChannel.XDebug_Invalid)
                return;
            this._buffer.Length = 0;
            this._buffer.Append(log1).Append(log2).Append(log3).Append(log4).Append(log5).Append(log6);
            if (color == XDebugColor.XDebug_Green)
            {
                this._buffer.Insert(0, "<color=green>");
                this._buffer.Append("</color>");
            }
            if (this._showTimeStick)
            {
                if (Thread.CurrentThread.ManagedThreadId == XSingleton<XUpdater.XUpdater>.singleton.ManagedThreadId)
                    this._buffer.Append(" (at Frame: ").Append(Time.frameCount).Append(" sec: ").Append(Time.realtimeSinceStartup.ToString("F3")).Append(')');
                else if (string.IsNullOrEmpty(Thread.CurrentThread.Name))
                    this._buffer.Append(" (from anonymous thread").Append(" with id ").Append(Thread.CurrentThread.ManagedThreadId).Append(")");
                else
                    this._buffer.Append(" (from thread ").Append(Thread.CurrentThread.Name).Append(" with id ").Append(Thread.CurrentThread.ManagedThreadId).Append(")");
            }
            switch (color)
            {
                case XDebugColor.XDebug_Yellow:
                    Debug.LogWarning((object)this._buffer);
                    break;
                case XDebugColor.XDebug_Red:
                    Debug.LogError((object)this._buffer);
                    break;
                default:
                    Debug.Log((object)this._buffer);
                    break;
            }
        }

        public void AddGreenLog(
          string log1,
          string log2 = null,
          string log3 = null,
          string log4 = null,
          string log5 = null,
          string log6 = null)
        {
            if (this._platform == null || this._platform.IsPublish())
                return;
            this.AddLog(XDebugChannel.XDebug_Default, log1, log2, log3, log4, log5, log6, XDebugColor.XDebug_Green);
        }

        public void AddWarningLog(
          string log1,
          string log2 = null,
          string log3 = null,
          string log4 = null,
          string log5 = null,
          string log6 = null)
        {
            if (this._platform == null || this._platform.IsPublish())
                return;
            this.AddLog(XDebugChannel.XDebug_Default, log1, log2, log3, log4, log5, log6, XDebugColor.XDebug_Yellow);
        }

        public void AddWarningLog2(string format, params object[] args)
        {
            if (!this._showLog || this._platform == null || this._platform.IsPublish())
                return;
            this.AddWarningLog(string.Format(format, args));
        }

        public void AddErrorLog2(string format, params object[] args)
        {
            if (!this._showLog || this._platform == null || this._platform.IsPublish())
                return;
            this.AddErrorLog(string.Format(format, args));
        }

        public void AddErrorLog(
          string log1,
          string log2 = null,
          string log3 = null,
          string log4 = null,
          string log5 = null,
          string log6 = null)
        {
            this._buffer.Length = 0;
            if (Thread.CurrentThread.ManagedThreadId == XSingleton<XUpdater.XUpdater>.singleton.ManagedThreadId)
                this._buffer.Append(log1).Append(log2).Append(log3).Append(log4).Append(log5).Append(log6).Append(" (at Frame: ").Append(Time.frameCount).Append(" sec: ").Append(Time.realtimeSinceStartup.ToString("F3")).Append(')');
            else
                this._buffer.Append(log1).Append(log2).Append(log3).Append(log4).Append(log5).Append(log6);
            XFileLog.AddCustomLog("AddErrorLog:  " + (object)this._buffer);
            this.AddLog(XDebugChannel.XDebug_Default, log1, log2, log3, log4, log5, log6, XDebugColor.XDebug_Red);
        }

        public override bool Init() => true;

        public override void Uninit()
        {
        }

        public void BeginProfile(string title)
        {
        }

        public void RegisterGroupProfile(string title)
        {
        }

        public void BeginGroupProfile(string title)
        {
        }

        public void EndProfile()
        {
        }

        public void EndGroupProfile(string title)
        {
        }

        public void InitProfiler()
        {
        }

        public void PrintProfiler()
        {
        }

        public void StartRecord(XDebug.RecordChannel channel)
        {
            this.m_record = true;
            this.m_recordStart = false;
            this.m_RecordChannel = channel;
            switch (this.m_RecordChannel)
            {
                case XDebug.RecordChannel.ENetwork:
                    this.m_LayerInfo[0].Name = "Recv";
                    this.m_LayerInfo[1].Name = "Send";
                    break;
                case XDebug.RecordChannel.EResourceLoad:
                    this.m_LayerInfo[0].Name = "SharedRes";
                    this.m_LayerInfo[1].Name = "Prefab";
                    break;
            }
        }

        public void EndRecord()
        {
            this.m_record = false;
            this.m_recordStart = false;
            this.m_RecordChannel = XDebug.RecordChannel.ENone;
        }

        public void BeginRecord()
        {
            if (!this.m_record)
                return;
            this.m_recordStart = true;
        }

        public void ClearRecord()
        {
            this.m_LayerInfo[0].Clear();
            this.m_LayerInfo[1].Clear();
        }

        public bool EnableRecord() => this.m_recordStart;

        public void AddPoint(
          uint key,
          string name,
          float size,
          int layer,
          XDebug.RecordChannel channel)
        {
            if (!this.m_recordStart || channel != this.m_RecordChannel || layer < 0 || layer >= this.m_MaxLayer)
                return;
            Dictionary<uint, XDebug.SizeInfo> sizeInfoMap = this.m_LayerInfo[layer].SizeInfoMap;
            XDebug.SizeInfo sizeInfo = (XDebug.SizeInfo)null;
            if (!sizeInfoMap.TryGetValue(key, out sizeInfo))
            {
                sizeInfo = new XDebug.SizeInfo();
                sizeInfo.Name = name;
                sizeInfoMap.Add(key, sizeInfo);
            }
            ++sizeInfo.Count;
            sizeInfo.Size += size;
        }

        public void Print()
        {
            float num1 = 0.0f;
            for (int index = 0; index < this.m_MaxLayer; ++index)
            {
                XSingleton<XCommon>.singleton.CleanStringCombine();
                float num2 = 0.0f;
                XDebug.SizeInfo sizeInfo1 = (XDebug.SizeInfo)null;
                XDebug.LayerInfo layerInfo = this.m_LayerInfo[index];
                XSingleton<XCommon>.singleton.AppendString(layerInfo.Name, ":\r\n");
                Dictionary<uint, XDebug.SizeInfo>.Enumerator enumerator = layerInfo.SizeInfoMap.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    XDebug.SizeInfo sizeInfo2 = enumerator.Current.Value;
                    XSingleton<XCommon>.singleton.AppendString(string.Format("Name:{0} Count:{1} Size：{2}\r\n", (object)sizeInfo2.Name, (object)sizeInfo2.Count, (object)sizeInfo2.Size));
                    num1 += sizeInfo2.Size;
                    num2 += sizeInfo2.Size;
                    if (sizeInfo1 == null || (double)sizeInfo1.Size < (double)sizeInfo2.Size)
                        sizeInfo1 = sizeInfo2;
                }
                XSingleton<XDebug>.singleton.AddWarningLog(XSingleton<XCommon>.singleton.GetString());
                if (sizeInfo1 != null)
                    XSingleton<XDebug>.singleton.AddWarningLog2("max name:{0} Count:{1} Size：{2}", (object)sizeInfo1.Name, (object)sizeInfo1.Count, (object)sizeInfo1.Size);
                XSingleton<XDebug>.singleton.AddWarningLog2("total {0} size:{1}", (object)layerInfo.Name, (object)num2);
            }
            XSingleton<XDebug>.singleton.AddWarningLog("total size:", num1.ToString());
        }

        public enum RecordChannel
        {
            ENone,
            ENetwork,
            EResourceLoad,
        }

        public enum RecordLayer
        {
            ELayer0,
            ELayer1,
            ENum,
        }

        public class SizeInfo
        {
            public string Name = "";
            public float Size = 0.0f;
            public int Count = 0;
        }

        public class LayerInfo
        {
            public string Name = "";
            public Dictionary<uint, XDebug.SizeInfo> SizeInfoMap = new Dictionary<uint, XDebug.SizeInfo>();

            public void Clear() => this.SizeInfoMap.Clear();
        }
    }
}
