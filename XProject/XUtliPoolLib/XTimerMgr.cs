

using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{
    public sealed class XTimerMgr : XSingleton<XTimerMgr>
    {
        private uint _token = 0;
        private double _elapsed = 0.0;
        private Queue<XTimerMgr.XTimer> _pool = new Queue<XTimerMgr.XTimer>();
        private XHeap<XTimerMgr.XTimer> _timers = new XHeap<XTimerMgr.XTimer>();
        private Dictionary<uint, XTimerMgr.XTimer> _dict = new Dictionary<uint, XTimerMgr.XTimer>(20);
        private float _intervalTime = 0.0f;
        private float _updateTime = 0.1f;
        private bool _fixedUpdate = false;
        public bool update = true;
        public float updateStartTime = 0.0f;

        public double Elapsed => this._elapsed;

        public bool NeedFixedUpdate => this._fixedUpdate;

        public uint SetTimer(float interval, XTimerMgr.ElapsedEventHandler handler, object param)
        {
            ++this._token;
            if ((double)interval <= 0.0)
            {
                handler(param);
                ++this._token;
            }
            else
            {
                XTimerMgr.XTimer timer = this.GetTimer(this._elapsed + Math.Round((double)interval, 3), (object)handler, param, this._token, false);
                this._timers.PushHeap(timer);
                this._dict.Add(this._token, timer);
            }
            return this._token;
        }

        public uint SetTimer<TEnum>(
          float interval,
          XTimerMgr.ElapsedIDEventHandler handler,
          object param,
          TEnum e)
          where TEnum : struct
        {
            ++this._token;
            int id = XFastEnumIntEqualityComparer<TEnum>.ToInt(e);
            if ((double)interval <= 0.0)
            {
                handler(param, id);
                ++this._token;
            }
            else
            {
                XTimerMgr.XTimer timer = this.GetTimer(this._elapsed + Math.Round((double)interval, 3), (object)handler, param, this._token, false, id);
                this._timers.PushHeap(timer);
                this._dict.Add(this._token, timer);
            }
            return this._token;
        }

        public uint SetGlobalTimer(float interval, XTimerMgr.ElapsedEventHandler handler, object param)
        {
            ++this._token;
            if ((double)interval <= 0.0)
            {
                handler(param);
                ++this._token;
            }
            else
            {
                XTimerMgr.XTimer timer = this.GetTimer(this._elapsed + Math.Round((double)interval, 3), (object)handler, param, this._token, true);
                this._timers.PushHeap(timer);
                this._dict.Add(this._token, timer);
            }
            return this._token;
        }

        public uint SetTimerAccurate(
          float interval,
          XTimerMgr.AccurateElapsedEventHandler handler,
          object param)
        {
            ++this._token;
            if ((double)interval <= 0.0)
            {
                handler(param, 0.0f);
                ++this._token;
            }
            else
            {
                XTimerMgr.XTimer timer = this.GetTimer(this._elapsed + Math.Round((double)interval, 3), (object)handler, param, this._token, false);
                this._timers.PushHeap(timer);
                this._dict.Add(this._token, timer);
            }
            return this._token;
        }

        public void AdjustTimer(float interval, uint token, bool closed = false)
        {
            XTimerMgr.XTimer xtimer = (XTimerMgr.XTimer)null;
            if (!this._dict.TryGetValue(token, out xtimer) || xtimer.IsInPool)
                return;
            double trigger = closed ? this._elapsed - (double)Time.deltaTime * 0.5 + Math.Round((double)interval, 3) : this._elapsed + Math.Round((double)interval, 3);
            double triggerTime = xtimer.TriggerTime;
            xtimer.Refine(trigger);
            this._timers.Adjust(xtimer, triggerTime < xtimer.TriggerTime);
        }

        public void KillTimerAll()
        {
            List<XTimerMgr.XTimer> xtimerList = new List<XTimerMgr.XTimer>();
            foreach (XTimerMgr.XTimer xtimer in this._dict.Values)
            {
                if (!xtimer.IsGlobaled)
                    xtimerList.Add(xtimer);
            }
            for (int index = 0; index < xtimerList.Count; ++index)
                this.KillTimer(xtimerList[index]);
            xtimerList.Clear();
        }

        private void KillTimer(XTimerMgr.XTimer timer)
        {
            if (timer == null)
                return;
            this._timers.PopHeapAt(timer.Here);
            this.Discard(timer);
        }

        public void KillTimer(uint token)
        {
            if (token == 0U)
                return;
            XTimerMgr.XTimer timer = (XTimerMgr.XTimer)null;
            if (!this._dict.TryGetValue(token, out timer))
                return;
            this.KillTimer(timer);
        }

        public double TimeLeft(uint token)
        {
            XTimerMgr.XTimer xtimer = (XTimerMgr.XTimer)null;
            return this._dict.TryGetValue(token, out xtimer) ? xtimer.TimeLeft() : 0.0;
        }

        public void Update(float fDeltaT)
        {
            this._elapsed += (double)fDeltaT;
            this._intervalTime += fDeltaT;
            if ((double)this._intervalTime > (double)this._updateTime)
            {
                this._intervalTime = 0.0f;
                this._fixedUpdate = true;
            }
            this.TriggerTimers();
        }

        public void PostUpdate() => this._fixedUpdate = false;

        private void TriggerTimers()
        {
            while (this._timers.HeapSize > 0)
            {
                float delta = (float)(this._elapsed - this._timers.Peek().TriggerTime);
                if ((double)delta < 0.0)
                    break;
                this.ExecuteTimer(this._timers.PopHeap(), delta);
            }
        }

        private void ExecuteTimer(XTimerMgr.XTimer timer, float delta)
        {
            this.Discard(timer);
            timer.Fire(delta);
        }

        private void Discard(XTimerMgr.XTimer timer)
        {
            if (timer.IsInPool || !this._dict.Remove(timer.Token))
                return;
            timer.IsInPool = true;
            this._pool.Enqueue(timer);
        }

        private XTimerMgr.XTimer GetTimer(
          double trigger,
          object handler,
          object parma,
          uint token,
          bool global,
          int id = -1)
        {
            if (this._pool.Count <= 0)
                return new XTimerMgr.XTimer(trigger, handler, parma, token, global, id);
            XTimerMgr.XTimer xtimer = this._pool.Dequeue();
            xtimer.Refine(trigger, handler, parma, token, global, id);
            return xtimer;
        }

        public override bool Init() => true;

        public override void Uninit()
        {
        }

        public delegate void ElapsedEventHandler(object param);

        public delegate void AccurateElapsedEventHandler(object param, float delay);

        public delegate void ElapsedIDEventHandler(object param, int id);

        private sealed class XTimer : IComparable<XTimerMgr.XTimer>, IHere
        {
            private double _triggerTime;
            private object _param;
            private object _handler;
            private bool _global = false;
            private uint _token = 0;

            public XTimer(
              double trigger,
              object handler,
              object parma,
              uint token,
              bool global,
              int id)
            {
                this.Refine(trigger, handler, parma, token, global, id);
            }

            public void Refine(
              double trigger,
              object handler,
              object parma,
              uint token,
              bool global,
              int id)
            {
                this._triggerTime = trigger;
                this._handler = handler;
                this._param = parma;
                this._global = global;
                this._token = token;
                this.Here = -1;
                this.IsInPool = false;
                this.Id = id;
            }

            public void Refine(double trigger) => this._triggerTime = trigger;

            public double TriggerTime => this._triggerTime;

            public bool IsGlobaled => this._global;

            public bool IsInPool { get; set; }

            public uint Token => this._token;

            public int Here { get; set; }

            public int Id { get; set; }

            public void Fire(float delta)
            {
                if (this._handler is XTimerMgr.AccurateElapsedEventHandler)
                    (this._handler as XTimerMgr.AccurateElapsedEventHandler)(this._param, delta);
                else if (this._handler is XTimerMgr.ElapsedIDEventHandler)
                    (this._handler as XTimerMgr.ElapsedIDEventHandler)(this._param, this.Id);
                else
                    (this._handler as XTimerMgr.ElapsedEventHandler)(this._param);
            }

            public int CompareTo(XTimerMgr.XTimer other) => this._triggerTime == other._triggerTime ? (int)this._token - (int)other.Token : (this._triggerTime < other._triggerTime ? -1 : 1);

            public double TimeLeft() => this._triggerTime - XSingleton<XTimerMgr>.singleton.Elapsed;
        }
    }
}
