using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlatBanAccount")]
	[Serializable]
	public class PlatBanAccount : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "reason", DataFormat = DataFormat.Default)]
		public string reason
		{
			get
			{
				return this._reason ?? "";
			}
			set
			{
				this._reason = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reasonSpecified
		{
			get
			{
				return this._reason != null;
			}
			set
			{
				bool flag = value == (this._reason == null);
				if (flag)
				{
					this._reason = (value ? this.reason : null);
				}
			}
		}

		private bool ShouldSerializereason()
		{
			return this.reasonSpecified;
		}

		private void Resetreason()
		{
			this.reasonSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "endtime", DataFormat = DataFormat.TwosComplement)]
		public uint endtime
		{
			get
			{
				return this._endtime ?? 0U;
			}
			set
			{
				this._endtime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool endtimeSpecified
		{
			get
			{
				return this._endtime != null;
			}
			set
			{
				bool flag = value == (this._endtime == null);
				if (flag)
				{
					this._endtime = (value ? new uint?(this.endtime) : null);
				}
			}
		}

		private bool ShouldSerializeendtime()
		{
			return this.endtimeSpecified;
		}

		private void Resetendtime()
		{
			this.endtimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _reason;

		private uint? _endtime;

		private IExtension extensionObject;
	}
}
