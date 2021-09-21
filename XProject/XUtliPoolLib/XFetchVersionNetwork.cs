// Decompiled with JetBrains decompiler
// Type: XUtliPoolLib.XFetchVersionNetwork
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace XUtliPoolLib
{
    public class XFetchVersionNetwork
    {
        private Socket m_oSocket;
        private XFetchVersionNetwork.SocketState m_nState;
        private static byte[] m_oRecvBuff;
        private int m_nCurrRecvLen;
        public static int TotalRecvBytes;
        private AsyncCallback m_RecvCb = (AsyncCallback)null;
        private AsyncCallback m_ConnectCb = (AsyncCallback)null;
        public bool m_bRecvMsg = true;
        public bool m_bPause = false;
        public int m_nPauseRecvLen = 0;
        private AddressFamily m_NetworkType = AddressFamily.InterNetwork;

        public XFetchVersionNetwork()
        {
            this.m_oSocket = (Socket)null;
            this.m_nState = XFetchVersionNetwork.SocketState.State_Closed;
            XFetchVersionNetwork.m_oRecvBuff = (byte[])null;
            this.m_nCurrRecvLen = 0;
            this.m_RecvCb = new AsyncCallback(this.RecvCallback);
            this.m_ConnectCb = new AsyncCallback(this.OnConnect);
        }

        private void GetNetworkType()
        {
            try
            {
                this.m_NetworkType = Dns.GetHostAddresses(XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetLoginServer("QQ").Substring(0, XSingleton<XUpdater.XUpdater>.singleton.XPlatform.GetLoginServer("QQ").LastIndexOf(':')))[0].AddressFamily;
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddWarningLog(ex.Message);
            }
        }

        public bool Init()
        {
            this.GetNetworkType();
            try
            {
                this.m_nState = XFetchVersionNetwork.SocketState.State_Closed;
                this.m_oSocket = new Socket(this.m_NetworkType, SocketType.Stream, ProtocolType.Tcp);
                this.m_oSocket.NoDelay = true;
                if (XFetchVersionNetwork.m_oRecvBuff == null)
                    XFetchVersionNetwork.m_oRecvBuff = new byte[512];
                this.m_nCurrRecvLen = 0;
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddWarningLog(ex.Message, "new Socket Error!");
                return false;
            }
            return true;
        }

        public void UnInit() => this.Close();

        private void OnConnect(IAsyncResult iar)
        {
            try
            {
                if (this.m_nState == XFetchVersionNetwork.SocketState.State_Closed)
                    return;
                Socket asyncState = (Socket)iar.AsyncState;
                asyncState.EndConnect(iar);
                this.SetState(XFetchVersionNetwork.SocketState.State_Connected);
                asyncState.BeginReceive(XFetchVersionNetwork.m_oRecvBuff, this.m_nCurrRecvLen, XFetchVersionNetwork.m_oRecvBuff.Length - this.m_nCurrRecvLen, SocketFlags.None, this.m_RecvCb, (object)asyncState);
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddWarningLog(ex.Message);
                this.SetState(XFetchVersionNetwork.SocketState.State_Closed);
                this.Close();
            }
        }

        public bool Connect(string host, int port)
        {
            try
            {
                this.SetState(XFetchVersionNetwork.SocketState.State_Connecting);
                this.m_oSocket.BeginConnect(host, port, this.m_ConnectCb, (object)this.m_oSocket);
                return true;
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddWarningLog(ex.Message);
                return false;
            }
        }

        public void Close()
        {
            this.m_nState = XFetchVersionNetwork.SocketState.State_Closed;
            if (this.m_oSocket == null)
                return;
            try
            {
                this.m_oSocket.Close();
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddWarningLog(ex.Message);
            }
            this.m_oSocket = (Socket)null;
        }

        public Socket GetSocket() => this.m_oSocket;

        public bool IsClosed() => this.m_nState == XFetchVersionNetwork.SocketState.State_Closed;

        private void SetState(XFetchVersionNetwork.SocketState nState) => this.m_nState = nState;

        public void RecvCallback(IAsyncResult ar)
        {
            try
            {
                if (this.m_nState == XFetchVersionNetwork.SocketState.State_Closed)
                    return;
                Socket asyncState = (Socket)ar.AsyncState;
                int num = asyncState.EndReceive(ar);
                if (num > 0)
                {
                    XFetchVersionNetwork.TotalRecvBytes += num;
                    this.m_nCurrRecvLen += num;
                    if (this.DetectPacket())
                        return;
                    if (this.m_nCurrRecvLen == XFetchVersionNetwork.m_oRecvBuff.Length)
                        XSingleton<XDebug>.singleton.AddWarningLog("RecvCallback error ! m_nCurrRecvLen == m_oRecvBuff.Length");
                    asyncState.BeginReceive(XFetchVersionNetwork.m_oRecvBuff, this.m_nCurrRecvLen, XFetchVersionNetwork.m_oRecvBuff.Length - this.m_nCurrRecvLen, SocketFlags.None, this.m_RecvCb, (object)asyncState);
                }
                else if (num == 0)
                {
                    XSingleton<XDebug>.singleton.AddWarningLog("Close socket normally");
                    this.Close();
                }
                else
                {
                    XSingleton<XDebug>.singleton.AddWarningLog("Close socket, recv error!");
                    this.Close();
                }
            }
            catch (ObjectDisposedException ex)
            {
            }
            catch (SocketException ex)
            {
                XSingleton<XDebug>.singleton.AddWarningLog(ex.Message);
                this.Close();
            }
            catch (Exception ex)
            {
                XSingleton<XDebug>.singleton.AddWarningLog(ex.Message);
                this.Close();
            }
        }

        public bool DetectPacket()
        {
            if (this.m_nCurrRecvLen > 0)
            {
                int length = this.BreakPacket(XFetchVersionNetwork.m_oRecvBuff, 0, this.m_nCurrRecvLen);
                if (length != 0 && this.m_bRecvMsg)
                {
                    byte[] bytes = new byte[length];
                    Array.Copy((Array)XFetchVersionNetwork.m_oRecvBuff, 0, (Array)bytes, 0, length);
                    XSingleton<XUpdater.XUpdater>.singleton.SetServerVersion(Encoding.UTF8.GetString(bytes, 4, length - 4));
                    return true;
                }
            }
            return false;
        }

        public int BreakPacket(byte[] data, int index, int len)
        {
            if (len < 4)
                return 0;
            int int32 = BitConverter.ToInt32(data, index);
            return len < 4 + int32 ? 0 : int32 + 4;
        }

        public enum SocketState
        {
            State_Closed,
            State_Connecting,
            State_Connected,
        }
    }
}
