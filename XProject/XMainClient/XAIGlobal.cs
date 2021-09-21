using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AFD RID: 2813
	internal sealed class XAIGlobal
	{
		// Token: 0x17002FF1 RID: 12273
		// (get) Token: 0x0600A5FA RID: 42490 RVA: 0x001CF95C File Offset: 0x001CDB5C
		public XEntity Host
		{
			get
			{
				return this._host;
			}
		}

		// Token: 0x0600A5FB RID: 42491 RVA: 0x001CF974 File Offset: 0x001CDB74
		public void InitAIGlobal(string ainame)
		{
			this._host = XSingleton<XEntityMgr>.singleton.CreateEmpty();
			this._host.AI = (XSingleton<XComponentMgr>.singleton.CreateComponent(this._host, XAIComponent.uuID) as XAIComponent);
			this._host.AI.SetBehaviorTree(ainame);
		}

		// Token: 0x0600A5FC RID: 42492 RVA: 0x001CF9CC File Offset: 0x001CDBCC
		public void UnInitAIGlobal()
		{
			bool flag = this._host != null;
			if (flag)
			{
				XSingleton<XEntityMgr>.singleton.DestroyEntity(this._host);
			}
			this._host = null;
		}

		// Token: 0x0600A5FD RID: 42493 RVA: 0x001CFA00 File Offset: 0x001CDC00
		public void SendAIMsg(string msg, float time = 0f, int typeid = 0, int argid = 0)
		{
			bool flag = this._host == null || this._host.AI == null;
			if (!flag)
			{
				XAIEventArgs @event = XEventPool<XAIEventArgs>.GetEvent();
				@event.DepracatedPass = false;
				@event.Firer = this._host;
				@event.EventType = 1;
				@event.EventArg = msg;
				@event.SkillId = argid;
				@event.TypeId = typeid;
				uint item = XSingleton<XEventMgr>.singleton.FireEvent(@event, (time > 0f) ? time : 0.05f);
				this._host.AI.TimerToken.Add(item);
			}
		}

		// Token: 0x0600A5FE RID: 42494 RVA: 0x001CFA98 File Offset: 0x001CDC98
		public void ClearAllTimer()
		{
			bool flag = this._host != null && this._host.AI != null;
			if (flag)
			{
				this._host.AI.ClearAllTimer();
			}
		}

		// Token: 0x04003D02 RID: 15618
		private XEntity _host = null;
	}
}
