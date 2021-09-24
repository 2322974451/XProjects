using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XAIGlobal
	{

		public XEntity Host
		{
			get
			{
				return this._host;
			}
		}

		public void InitAIGlobal(string ainame)
		{
			this._host = XSingleton<XEntityMgr>.singleton.CreateEmpty();
			this._host.AI = (XSingleton<XComponentMgr>.singleton.CreateComponent(this._host, XAIComponent.uuID) as XAIComponent);
			this._host.AI.SetBehaviorTree(ainame);
		}

		public void UnInitAIGlobal()
		{
			bool flag = this._host != null;
			if (flag)
			{
				XSingleton<XEntityMgr>.singleton.DestroyEntity(this._host);
			}
			this._host = null;
		}

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

		public void ClearAllTimer()
		{
			bool flag = this._host != null && this._host.AI != null;
			if (flag)
			{
				this._host.AI.ClearAllTimer();
			}
		}

		private XEntity _host = null;
	}
}
