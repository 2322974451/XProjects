using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RoleExtraInfo")]
	[Serializable]
	public class RoleExtraInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "lastLevelUpTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastLevelUpTime
		{
			get
			{
				return this._lastLevelUpTime ?? 0U;
			}
			set
			{
				this._lastLevelUpTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastLevelUpTimeSpecified
		{
			get
			{
				return this._lastLevelUpTime != null;
			}
			set
			{
				bool flag = value == (this._lastLevelUpTime == null);
				if (flag)
				{
					this._lastLevelUpTime = (value ? new uint?(this.lastLevelUpTime) : null);
				}
			}
		}

		private bool ShouldSerializelastLevelUpTime()
		{
			return this.lastLevelUpTimeSpecified;
		}

		private void ResetlastLevelUpTime()
		{
			this.lastLevelUpTimeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "lastLoginTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastLoginTime
		{
			get
			{
				return this._lastLoginTime ?? 0U;
			}
			set
			{
				this._lastLoginTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastLoginTimeSpecified
		{
			get
			{
				return this._lastLoginTime != null;
			}
			set
			{
				bool flag = value == (this._lastLoginTime == null);
				if (flag)
				{
					this._lastLoginTime = (value ? new uint?(this.lastLoginTime) : null);
				}
			}
		}

		private bool ShouldSerializelastLoginTime()
		{
			return this.lastLoginTimeSpecified;
		}

		private void ResetlastLoginTime()
		{
			this.lastLoginTimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "lastLogoutTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastLogoutTime
		{
			get
			{
				return this._lastLogoutTime ?? 0U;
			}
			set
			{
				this._lastLogoutTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastLogoutTimeSpecified
		{
			get
			{
				return this._lastLogoutTime != null;
			}
			set
			{
				bool flag = value == (this._lastLogoutTime == null);
				if (flag)
				{
					this._lastLogoutTime = (value ? new uint?(this.lastLogoutTime) : null);
				}
			}
		}

		private bool ShouldSerializelastLogoutTime()
		{
			return this.lastLogoutTimeSpecified;
		}

		private void ResetlastLogoutTime()
		{
			this.lastLogoutTimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "loginTimes", DataFormat = DataFormat.TwosComplement)]
		public uint loginTimes
		{
			get
			{
				return this._loginTimes ?? 0U;
			}
			set
			{
				this._loginTimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool loginTimesSpecified
		{
			get
			{
				return this._loginTimes != null;
			}
			set
			{
				bool flag = value == (this._loginTimes == null);
				if (flag)
				{
					this._loginTimes = (value ? new uint?(this.loginTimes) : null);
				}
			}
		}

		private bool ShouldSerializeloginTimes()
		{
			return this.loginTimesSpecified;
		}

		private void ResetloginTimes()
		{
			this.loginTimesSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "lastFatigueRecoverTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastFatigueRecoverTime
		{
			get
			{
				return this._lastFatigueRecoverTime ?? 0U;
			}
			set
			{
				this._lastFatigueRecoverTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastFatigueRecoverTimeSpecified
		{
			get
			{
				return this._lastFatigueRecoverTime != null;
			}
			set
			{
				bool flag = value == (this._lastFatigueRecoverTime == null);
				if (flag)
				{
					this._lastFatigueRecoverTime = (value ? new uint?(this.lastFatigueRecoverTime) : null);
				}
			}
		}

		private bool ShouldSerializelastFatigueRecoverTime()
		{
			return this.lastFatigueRecoverTimeSpecified;
		}

		private void ResetlastFatigueRecoverTime()
		{
			this.lastFatigueRecoverTimeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "fristchannel", DataFormat = DataFormat.Default)]
		public string fristchannel
		{
			get
			{
				return this._fristchannel ?? "";
			}
			set
			{
				this._fristchannel = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fristchannelSpecified
		{
			get
			{
				return this._fristchannel != null;
			}
			set
			{
				bool flag = value == (this._fristchannel == null);
				if (flag)
				{
					this._fristchannel = (value ? this.fristchannel : null);
				}
			}
		}

		private bool ShouldSerializefristchannel()
		{
			return this.fristchannelSpecified;
		}

		private void Resetfristchannel()
		{
			this.fristchannelSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "channelmask", DataFormat = DataFormat.Default)]
		public bool channelmask
		{
			get
			{
				return this._channelmask ?? false;
			}
			set
			{
				this._channelmask = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool channelmaskSpecified
		{
			get
			{
				return this._channelmask != null;
			}
			set
			{
				bool flag = value == (this._channelmask == null);
				if (flag)
				{
					this._channelmask = (value ? new bool?(this.channelmask) : null);
				}
			}
		}

		private bool ShouldSerializechannelmask()
		{
			return this.channelmaskSpecified;
		}

		private void Resetchannelmask()
		{
			this.channelmaskSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _lastLevelUpTime;

		private uint? _lastLoginTime;

		private uint? _lastLogoutTime;

		private uint? _loginTimes;

		private uint? _lastFatigueRecoverTime;

		private string _fristchannel;

		private bool? _channelmask;

		private IExtension extensionObject;
	}
}
