using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildBonusBriefInfo")]
	[Serializable]
	public class GuildBonusBriefInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "bonusID", DataFormat = DataFormat.TwosComplement)]
		public uint bonusID
		{
			get
			{
				return this._bonusID ?? 0U;
			}
			set
			{
				this._bonusID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bonusIDSpecified
		{
			get
			{
				return this._bonusID != null;
			}
			set
			{
				bool flag = value == (this._bonusID == null);
				if (flag)
				{
					this._bonusID = (value ? new uint?(this.bonusID) : null);
				}
			}
		}

		private bool ShouldSerializebonusID()
		{
			return this.bonusIDSpecified;
		}

		private void ResetbonusID()
		{
			this.bonusIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "sendTime", DataFormat = DataFormat.TwosComplement)]
		public int sendTime
		{
			get
			{
				return this._sendTime ?? 0;
			}
			set
			{
				this._sendTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sendTimeSpecified
		{
			get
			{
				return this._sendTime != null;
			}
			set
			{
				bool flag = value == (this._sendTime == null);
				if (flag)
				{
					this._sendTime = (value ? new int?(this.sendTime) : null);
				}
			}
		}

		private bool ShouldSerializesendTime()
		{
			return this.sendTimeSpecified;
		}

		private void ResetsendTime()
		{
			this.sendTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _bonusID;

		private int? _sendTime;

		private IExtension extensionObject;
	}
}
