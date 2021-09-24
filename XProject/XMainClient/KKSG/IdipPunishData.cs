using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IdipPunishData")]
	[Serializable]
	public class IdipPunishData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public int type
		{
			get
			{
				return this._type ?? 0;
			}
			set
			{
				this._type = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new int?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "punishTime", DataFormat = DataFormat.TwosComplement)]
		public int punishTime
		{
			get
			{
				return this._punishTime ?? 0;
			}
			set
			{
				this._punishTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool punishTimeSpecified
		{
			get
			{
				return this._punishTime != null;
			}
			set
			{
				bool flag = value == (this._punishTime == null);
				if (flag)
				{
					this._punishTime = (value ? new int?(this.punishTime) : null);
				}
			}
		}

		private bool ShouldSerializepunishTime()
		{
			return this.punishTimeSpecified;
		}

		private void ResetpunishTime()
		{
			this.punishTimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "banTime", DataFormat = DataFormat.TwosComplement)]
		public int banTime
		{
			get
			{
				return this._banTime ?? 0;
			}
			set
			{
				this._banTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool banTimeSpecified
		{
			get
			{
				return this._banTime != null;
			}
			set
			{
				bool flag = value == (this._banTime == null);
				if (flag)
				{
					this._banTime = (value ? new int?(this.banTime) : null);
				}
			}
		}

		private bool ShouldSerializebanTime()
		{
			return this.banTimeSpecified;
		}

		private void ResetbanTime()
		{
			this.banTimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "reason", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _type;

		private int? _punishTime;

		private int? _banTime;

		private string _reason;

		private IExtension extensionObject;
	}
}
