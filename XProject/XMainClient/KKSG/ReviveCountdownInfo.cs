using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReviveCountdownInfo")]
	[Serializable]
	public class ReviveCountdownInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "countdownTime", DataFormat = DataFormat.TwosComplement)]
		public int countdownTime
		{
			get
			{
				return this._countdownTime ?? 0;
			}
			set
			{
				this._countdownTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool countdownTimeSpecified
		{
			get
			{
				return this._countdownTime != null;
			}
			set
			{
				bool flag = value == (this._countdownTime == null);
				if (flag)
				{
					this._countdownTime = (value ? new int?(this.countdownTime) : null);
				}
			}
		}

		private bool ShouldSerializecountdownTime()
		{
			return this.countdownTimeSpecified;
		}

		private void ResetcountdownTime()
		{
			this.countdownTimeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "revivecost", DataFormat = DataFormat.TwosComplement)]
		public uint revivecost
		{
			get
			{
				return this._revivecost ?? 0U;
			}
			set
			{
				this._revivecost = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool revivecostSpecified
		{
			get
			{
				return this._revivecost != null;
			}
			set
			{
				bool flag = value == (this._revivecost == null);
				if (flag)
				{
					this._revivecost = (value ? new uint?(this.revivecost) : null);
				}
			}
		}

		private bool ShouldSerializerevivecost()
		{
			return this.revivecostSpecified;
		}

		private void Resetrevivecost()
		{
			this.revivecostSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "revivecosttype", DataFormat = DataFormat.TwosComplement)]
		public uint revivecosttype
		{
			get
			{
				return this._revivecosttype ?? 0U;
			}
			set
			{
				this._revivecosttype = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool revivecosttypeSpecified
		{
			get
			{
				return this._revivecosttype != null;
			}
			set
			{
				bool flag = value == (this._revivecosttype == null);
				if (flag)
				{
					this._revivecosttype = (value ? new uint?(this.revivecosttype) : null);
				}
			}
		}

		private bool ShouldSerializerevivecosttype()
		{
			return this.revivecosttypeSpecified;
		}

		private void Resetrevivecosttype()
		{
			this.revivecosttypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _countdownTime;

		private uint? _revivecost;

		private uint? _revivecosttype;

		private IExtension extensionObject;
	}
}
