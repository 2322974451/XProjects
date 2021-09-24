using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IdipPunishInfo")]
	[Serializable]
	public class IdipPunishInfo : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "endTime", DataFormat = DataFormat.TwosComplement)]
		public int endTime
		{
			get
			{
				return this._endTime ?? 0;
			}
			set
			{
				this._endTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool endTimeSpecified
		{
			get
			{
				return this._endTime != null;
			}
			set
			{
				bool flag = value == (this._endTime == null);
				if (flag)
				{
					this._endTime = (value ? new int?(this.endTime) : null);
				}
			}
		}

		private bool ShouldSerializeendTime()
		{
			return this.endTimeSpecified;
		}

		private void ResetendTime()
		{
			this.endTimeSpecified = false;
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

		[ProtoMember(4, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public int leftTime
		{
			get
			{
				return this._leftTime ?? 0;
			}
			set
			{
				this._leftTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new int?(this.leftTime) : null);
				}
			}
		}

		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _type;

		private int? _endTime;

		private int? _banTime;

		private int? _leftTime;

		private IExtension extensionObject;
	}
}
