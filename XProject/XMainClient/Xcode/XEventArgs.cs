using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal abstract class XEventArgs
	{

		public XEventArgs()
		{
			this._token = XSingleton<XCommon>.singleton.UniqueToken;
			this.ManualRecycle = false;
		}

		public virtual void Recycle()
		{
			this._token = 0L;
			this._firer = null;
			this._depracatedPass = false;
		}

		public virtual XEventArgs Clone()
		{
			return null;
		}

		public bool ManualRecycle { get; set; }

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

		public XEventDefine ArgsDefine
		{
			get
			{
				return this._eDefine;
			}
		}

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

		protected XEventDefine _eDefine = XEventDefine.XEvent_Invalid;

		protected long _token = 0L;

		protected XObject _firer = null;

		protected bool _depracatedPass = false;
	}
}
