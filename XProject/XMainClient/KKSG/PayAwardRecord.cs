using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayAwardRecord")]
	[Serializable]
	public class PayAwardRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public int id
		{
			get
			{
				return this._id ?? 0;
			}
			set
			{
				this._id = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new int?(this.id) : null);
				}
			}
		}

		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		private void Resetid()
		{
			this.idSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "lastGetAwardTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastGetAwardTime
		{
			get
			{
				return this._lastGetAwardTime ?? 0U;
			}
			set
			{
				this._lastGetAwardTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastGetAwardTimeSpecified
		{
			get
			{
				return this._lastGetAwardTime != null;
			}
			set
			{
				bool flag = value == (this._lastGetAwardTime == null);
				if (flag)
				{
					this._lastGetAwardTime = (value ? new uint?(this.lastGetAwardTime) : null);
				}
			}
		}

		private bool ShouldSerializelastGetAwardTime()
		{
			return this.lastGetAwardTimeSpecified;
		}

		private void ResetlastGetAwardTime()
		{
			this.lastGetAwardTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _id;

		private uint? _lastGetAwardTime;

		private IExtension extensionObject;
	}
}
