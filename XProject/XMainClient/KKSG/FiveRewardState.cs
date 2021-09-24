using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FiveRewardState")]
	[Serializable]
	public class FiveRewardState : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "logindaycount", DataFormat = DataFormat.TwosComplement)]
		public uint logindaycount
		{
			get
			{
				return this._logindaycount ?? 0U;
			}
			set
			{
				this._logindaycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool logindaycountSpecified
		{
			get
			{
				return this._logindaycount != null;
			}
			set
			{
				bool flag = value == (this._logindaycount == null);
				if (flag)
				{
					this._logindaycount = (value ? new uint?(this.logindaycount) : null);
				}
			}
		}

		private bool ShouldSerializelogindaycount()
		{
			return this.logindaycountSpecified;
		}

		private void Resetlogindaycount()
		{
			this.logindaycountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "fivedayRS", DataFormat = DataFormat.TwosComplement)]
		public LoginRewardState fivedayRS
		{
			get
			{
				return this._fivedayRS ?? LoginRewardState.LOGINRS_CANNOT;
			}
			set
			{
				this._fivedayRS = new LoginRewardState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fivedayRSSpecified
		{
			get
			{
				return this._fivedayRS != null;
			}
			set
			{
				bool flag = value == (this._fivedayRS == null);
				if (flag)
				{
					this._fivedayRS = (value ? new LoginRewardState?(this.fivedayRS) : null);
				}
			}
		}

		private bool ShouldSerializefivedayRS()
		{
			return this.fivedayRSSpecified;
		}

		private void ResetfivedayRS()
		{
			this.fivedayRSSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "twodayRS", DataFormat = DataFormat.TwosComplement)]
		public LoginRewardState twodayRS
		{
			get
			{
				return this._twodayRS ?? LoginRewardState.LOGINRS_CANNOT;
			}
			set
			{
				this._twodayRS = new LoginRewardState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool twodayRSSpecified
		{
			get
			{
				return this._twodayRS != null;
			}
			set
			{
				bool flag = value == (this._twodayRS == null);
				if (flag)
				{
					this._twodayRS = (value ? new LoginRewardState?(this.twodayRS) : null);
				}
			}
		}

		private bool ShouldSerializetwodayRS()
		{
			return this.twodayRSSpecified;
		}

		private void ResettwodayRS()
		{
			this.twodayRSSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "threedayRS", DataFormat = DataFormat.TwosComplement)]
		public LoginRewardState threedayRS
		{
			get
			{
				return this._threedayRS ?? LoginRewardState.LOGINRS_CANNOT;
			}
			set
			{
				this._threedayRS = new LoginRewardState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool threedayRSSpecified
		{
			get
			{
				return this._threedayRS != null;
			}
			set
			{
				bool flag = value == (this._threedayRS == null);
				if (flag)
				{
					this._threedayRS = (value ? new LoginRewardState?(this.threedayRS) : null);
				}
			}
		}

		private bool ShouldSerializethreedayRS()
		{
			return this.threedayRSSpecified;
		}

		private void ResetthreedayRS()
		{
			this.threedayRSSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "sevendayRS", DataFormat = DataFormat.TwosComplement)]
		public LoginRewardState sevendayRS
		{
			get
			{
				return this._sevendayRS ?? LoginRewardState.LOGINRS_CANNOT;
			}
			set
			{
				this._sevendayRS = new LoginRewardState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sevendayRSSpecified
		{
			get
			{
				return this._sevendayRS != null;
			}
			set
			{
				bool flag = value == (this._sevendayRS == null);
				if (flag)
				{
					this._sevendayRS = (value ? new LoginRewardState?(this.sevendayRS) : null);
				}
			}
		}

		private bool ShouldSerializesevendayRS()
		{
			return this.sevendayRSSpecified;
		}

		private void ResetsevendayRS()
		{
			this.sevendayRSSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _logindaycount;

		private LoginRewardState? _fivedayRS;

		private LoginRewardState? _twodayRS;

		private LoginRewardState? _threedayRS;

		private LoginRewardState? _sevendayRS;

		private IExtension extensionObject;
	}
}
