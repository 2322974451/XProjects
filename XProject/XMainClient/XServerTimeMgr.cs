using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XServerTimeMgr : XSingleton<XServerTimeMgr>
	{

		public XServerTimeMgr()
		{
			this._onTimerStartSyncTime = new XTimerMgr.ElapsedEventHandler(this.OnStartSyncTime);
		}

		public override bool Init()
		{
			this.OnStartSyncTime(null);
			return true;
		}

		public override void Uninit()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
		}

		public long GetDelay()
		{
			return this._TimeDelay;
		}

		private void OnStartSyncTime(object param)
		{
			bool flag = XSingleton<XClientNetwork>.singleton.XLoginStep == XLoginStep.Playing;
			if (flag)
			{
				this.syncTimeRpc.oArg.time = DateTime.Now.Ticks;
				XSingleton<XClientNetwork>.singleton.Send(this.syncTimeRpc);
			}
			else
			{
				this.Trigger();
			}
		}

		public void OnSyncTime(long sendAt, long replayAt)
		{
			double num = (double)(replayAt - sendAt) / 10000.0;
			this._TimeDelay = (long)num;
			this._delay.Data.delay = (uint)this._TimeDelay;
			XSingleton<XClientNetwork>.singleton.Send(this._delay);
			this.Trigger();
		}

		public void OnSyncTimeout()
		{
			XSingleton<XDebug>.singleton.AddLog("Ping time out!", null, null, null, null, null, XDebugColor.XDebug_None);
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.World && XSingleton<XClientNetwork>.singleton.IsConnected() && !XSingleton<XClientNetwork>.singleton.XConnect.OnReconnect && !Rpc.OnRpcDelay;
			if (flag)
			{
			}
			this._TimeDelay = XServerTimeMgr.SyncTimeOut;
			this.Trigger();
		}

		private void Trigger()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
			this._token = XSingleton<XTimerMgr>.singleton.SetGlobalTimer((float)XSingleton<XGlobalConfig>.singleton.PINGInterval, this._onTimerStartSyncTime, null);
		}

		public static readonly long SyncTimeOut = 2000L;

		private long _TimeDelay = 0L;

		private uint _token = 0U;

		private PtcC2G_DelayNotify _delay = new PtcC2G_DelayNotify();

		private XTimerMgr.ElapsedEventHandler _onTimerStartSyncTime = null;

		private RpcC2G_SyncTime syncTimeRpc = new RpcC2G_SyncTime();
	}
}
