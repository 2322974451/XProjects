using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LoginRecord")]
	[Serializable]
	public class LoginRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "loginDayCount", DataFormat = DataFormat.TwosComplement)]
		public uint loginDayCount
		{
			get
			{
				return this._loginDayCount ?? 0U;
			}
			set
			{
				this._loginDayCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool loginDayCountSpecified
		{
			get
			{
				return this._loginDayCount != null;
			}
			set
			{
				bool flag = value == (this._loginDayCount == null);
				if (flag)
				{
					this._loginDayCount = (value ? new uint?(this.loginDayCount) : null);
				}
			}
		}

		private bool ShouldSerializeloginDayCount()
		{
			return this.loginDayCountSpecified;
		}

		private void ResetloginDayCount()
		{
			this.loginDayCountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "logindayforloginreward", DataFormat = DataFormat.TwosComplement)]
		public uint logindayforloginreward
		{
			get
			{
				return this._logindayforloginreward ?? 0U;
			}
			set
			{
				this._logindayforloginreward = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool logindayforloginrewardSpecified
		{
			get
			{
				return this._logindayforloginreward != null;
			}
			set
			{
				bool flag = value == (this._logindayforloginreward == null);
				if (flag)
				{
					this._logindayforloginreward = (value ? new uint?(this.logindayforloginreward) : null);
				}
			}
		}

		private bool ShouldSerializelogindayforloginreward()
		{
			return this.logindayforloginrewardSpecified;
		}

		private void Resetlogindayforloginreward()
		{
			this.logindayforloginrewardSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "lastUpdateDay", DataFormat = DataFormat.TwosComplement)]
		public uint lastUpdateDay
		{
			get
			{
				return this._lastUpdateDay ?? 0U;
			}
			set
			{
				this._lastUpdateDay = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastUpdateDaySpecified
		{
			get
			{
				return this._lastUpdateDay != null;
			}
			set
			{
				bool flag = value == (this._lastUpdateDay == null);
				if (flag)
				{
					this._lastUpdateDay = (value ? new uint?(this.lastUpdateDay) : null);
				}
			}
		}

		private bool ShouldSerializelastUpdateDay()
		{
			return this.lastUpdateDaySpecified;
		}

		private void ResetlastUpdateDay()
		{
			this.lastUpdateDaySpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "lrostate", DataFormat = DataFormat.TwosComplement)]
		public int lrostate
		{
			get
			{
				return this._lrostate ?? 0;
			}
			set
			{
				this._lrostate = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lrostateSpecified
		{
			get
			{
				return this._lrostate != null;
			}
			set
			{
				bool flag = value == (this._lrostate == null);
				if (flag)
				{
					this._lrostate = (value ? new int?(this.lrostate) : null);
				}
			}
		}

		private bool ShouldSerializelrostate()
		{
			return this.lrostateSpecified;
		}

		private void Resetlrostate()
		{
			this.lrostateSpecified = false;
		}

		[ProtoMember(5, Name = "loginRewards", DataFormat = DataFormat.Default)]
		public List<LoginReward> loginRewards
		{
			get
			{
				return this._loginRewards;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _loginDayCount;

		private uint? _logindayforloginreward;

		private uint? _lastUpdateDay;

		private int? _lrostate;

		private readonly List<LoginReward> _loginRewards = new List<LoginReward>();

		private IExtension extensionObject;
	}
}
