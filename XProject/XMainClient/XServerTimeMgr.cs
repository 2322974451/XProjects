using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E9D RID: 3741
	internal class XServerTimeMgr : XSingleton<XServerTimeMgr>
	{
		// Token: 0x0600C78B RID: 51083 RVA: 0x002C8FE4 File Offset: 0x002C71E4
		public XServerTimeMgr()
		{
			this._onTimerStartSyncTime = new XTimerMgr.ElapsedEventHandler(this.OnStartSyncTime);
		}

		// Token: 0x0600C78C RID: 51084 RVA: 0x002C9038 File Offset: 0x002C7238
		public override bool Init()
		{
			this.OnStartSyncTime(null);
			return true;
		}

		// Token: 0x0600C78D RID: 51085 RVA: 0x002C9053 File Offset: 0x002C7253
		public override void Uninit()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
		}

		// Token: 0x0600C78E RID: 51086 RVA: 0x002C9068 File Offset: 0x002C7268
		public long GetDelay()
		{
			return this._TimeDelay;
		}

		// Token: 0x0600C78F RID: 51087 RVA: 0x002C9080 File Offset: 0x002C7280
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

		// Token: 0x0600C790 RID: 51088 RVA: 0x002C90DC File Offset: 0x002C72DC
		public void OnSyncTime(long sendAt, long replayAt)
		{
			double num = (double)(replayAt - sendAt) / 10000.0;
			this._TimeDelay = (long)num;
			this._delay.Data.delay = (uint)this._TimeDelay;
			XSingleton<XClientNetwork>.singleton.Send(this._delay);
			this.Trigger();
		}

		// Token: 0x0600C791 RID: 51089 RVA: 0x002C9134 File Offset: 0x002C7334
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

		// Token: 0x0600C792 RID: 51090 RVA: 0x002C91AA File Offset: 0x002C73AA
		private void Trigger()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._token);
			this._token = XSingleton<XTimerMgr>.singleton.SetGlobalTimer((float)XSingleton<XGlobalConfig>.singleton.PINGInterval, this._onTimerStartSyncTime, null);
		}

		// Token: 0x040057CC RID: 22476
		public static readonly long SyncTimeOut = 2000L;

		// Token: 0x040057CD RID: 22477
		private long _TimeDelay = 0L;

		// Token: 0x040057CE RID: 22478
		private uint _token = 0U;

		// Token: 0x040057CF RID: 22479
		private PtcC2G_DelayNotify _delay = new PtcC2G_DelayNotify();

		// Token: 0x040057D0 RID: 22480
		private XTimerMgr.ElapsedEventHandler _onTimerStartSyncTime = null;

		// Token: 0x040057D1 RID: 22481
		private RpcC2G_SyncTime syncTimeRpc = new RpcC2G_SyncTime();
	}
}
