using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LoginRewardRet")]
	[Serializable]
	public class LoginRewardRet : IExtensible
	{

		[ProtoMember(1, Name = "rewards", DataFormat = DataFormat.Default)]
		public List<LoginReward> rewards
		{
			get
			{
				return this._rewards;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "open", DataFormat = DataFormat.Default)]
		public bool open
		{
			get
			{
				return this._open ?? false;
			}
			set
			{
				this._open = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool openSpecified
		{
			get
			{
				return this._open != null;
			}
			set
			{
				bool flag = value == (this._open == null);
				if (flag)
				{
					this._open = (value ? new bool?(this.open) : null);
				}
			}
		}

		private bool ShouldSerializeopen()
		{
			return this.openSpecified;
		}

		private void Resetopen()
		{
			this.openSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "logindayforreward", DataFormat = DataFormat.TwosComplement)]
		public uint logindayforreward
		{
			get
			{
				return this._logindayforreward ?? 0U;
			}
			set
			{
				this._logindayforreward = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool logindayforrewardSpecified
		{
			get
			{
				return this._logindayforreward != null;
			}
			set
			{
				bool flag = value == (this._logindayforreward == null);
				if (flag)
				{
					this._logindayforreward = (value ? new uint?(this.logindayforreward) : null);
				}
			}
		}

		private bool ShouldSerializelogindayforreward()
		{
			return this.logindayforrewardSpecified;
		}

		private void Resetlogindayforreward()
		{
			this.logindayforrewardSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "sectoday", DataFormat = DataFormat.TwosComplement)]
		public uint sectoday
		{
			get
			{
				return this._sectoday ?? 0U;
			}
			set
			{
				this._sectoday = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sectodaySpecified
		{
			get
			{
				return this._sectoday != null;
			}
			set
			{
				bool flag = value == (this._sectoday == null);
				if (flag)
				{
					this._sectoday = (value ? new uint?(this.sectoday) : null);
				}
			}
		}

		private bool ShouldSerializesectoday()
		{
			return this.sectodaySpecified;
		}

		private void Resetsectoday()
		{
			this.sectodaySpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<LoginReward> _rewards = new List<LoginReward>();

		private bool? _open;

		private uint? _logindayforreward;

		private uint? _sectoday;

		private IExtension extensionObject;
	}
}
