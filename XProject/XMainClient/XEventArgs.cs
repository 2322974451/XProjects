using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F41 RID: 3905
	internal abstract class XEventArgs
	{
		// Token: 0x0600CFCD RID: 53197 RVA: 0x003037F0 File Offset: 0x003019F0
		public XEventArgs()
		{
			this._token = XSingleton<XCommon>.singleton.UniqueToken;
			this.ManualRecycle = false;
		}

		// Token: 0x0600CFCE RID: 53198 RVA: 0x0030382F File Offset: 0x00301A2F
		public virtual void Recycle()
		{
			this._token = 0L;
			this._firer = null;
			this._depracatedPass = false;
		}

		// Token: 0x0600CFCF RID: 53199 RVA: 0x00303848 File Offset: 0x00301A48
		public virtual XEventArgs Clone()
		{
			return null;
		}

		// Token: 0x17003679 RID: 13945
		// (get) Token: 0x0600CFD0 RID: 53200 RVA: 0x0030385B File Offset: 0x00301A5B
		// (set) Token: 0x0600CFD1 RID: 53201 RVA: 0x00303863 File Offset: 0x00301A63
		public bool ManualRecycle { get; set; }

		// Token: 0x1700367A RID: 13946
		// (get) Token: 0x0600CFD2 RID: 53202 RVA: 0x0030386C File Offset: 0x00301A6C
		// (set) Token: 0x0600CFD3 RID: 53203 RVA: 0x00303884 File Offset: 0x00301A84
		public XObject Firer
		{
			get
			{
				return this._firer;
			}
			set
			{
				this._firer = value;
			}
		}

		// Token: 0x1700367B RID: 13947
		// (get) Token: 0x0600CFD4 RID: 53204 RVA: 0x00303890 File Offset: 0x00301A90
		public XEventDefine ArgsDefine
		{
			get
			{
				return this._eDefine;
			}
		}

		// Token: 0x1700367C RID: 13948
		// (get) Token: 0x0600CFD5 RID: 53205 RVA: 0x003038A8 File Offset: 0x00301AA8
		// (set) Token: 0x0600CFD6 RID: 53206 RVA: 0x003038C0 File Offset: 0x00301AC0
		public long Token
		{
			get
			{
				return this._token;
			}
			set
			{
				this._token = value;
			}
		}

		// Token: 0x1700367D RID: 13949
		// (get) Token: 0x0600CFD7 RID: 53207 RVA: 0x003038CC File Offset: 0x00301ACC
		// (set) Token: 0x0600CFD8 RID: 53208 RVA: 0x003038E4 File Offset: 0x00301AE4
		public bool DepracatedPass
		{
			get
			{
				return this._depracatedPass;
			}
			set
			{
				this._depracatedPass = value;
			}
		}

		// Token: 0x04005DDA RID: 24026
		protected XEventDefine _eDefine = XEventDefine.XEvent_Invalid;

		// Token: 0x04005DDB RID: 24027
		protected long _token = 0L;

		// Token: 0x04005DDC RID: 24028
		protected XObject _firer = null;

		// Token: 0x04005DDD RID: 24029
		protected bool _depracatedPass = false;
	}
}
