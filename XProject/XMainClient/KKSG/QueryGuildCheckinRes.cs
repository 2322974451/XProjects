using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QueryGuildCheckinRes")]
	[Serializable]
	public class QueryGuildCheckinRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "checkincount", DataFormat = DataFormat.TwosComplement)]
		public uint checkincount
		{
			get
			{
				return this._checkincount ?? 0U;
			}
			set
			{
				this._checkincount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool checkincountSpecified
		{
			get
			{
				return this._checkincount != null;
			}
			set
			{
				bool flag = value == (this._checkincount == null);
				if (flag)
				{
					this._checkincount = (value ? new uint?(this.checkincount) : null);
				}
			}
		}

		private bool ShouldSerializecheckincount()
		{
			return this.checkincountSpecified;
		}

		private void Resetcheckincount()
		{
			this.checkincountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "allcount", DataFormat = DataFormat.TwosComplement)]
		public uint allcount
		{
			get
			{
				return this._allcount ?? 0U;
			}
			set
			{
				this._allcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool allcountSpecified
		{
			get
			{
				return this._allcount != null;
			}
			set
			{
				bool flag = value == (this._allcount == null);
				if (flag)
				{
					this._allcount = (value ? new uint?(this.allcount) : null);
				}
			}
		}

		private bool ShouldSerializeallcount()
		{
			return this.allcountSpecified;
		}

		private void Resetallcount()
		{
			this.allcountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "checkin", DataFormat = DataFormat.TwosComplement)]
		public uint checkin
		{
			get
			{
				return this._checkin ?? 0U;
			}
			set
			{
				this._checkin = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool checkinSpecified
		{
			get
			{
				return this._checkin != null;
			}
			set
			{
				bool flag = value == (this._checkin == null);
				if (flag)
				{
					this._checkin = (value ? new uint?(this.checkin) : null);
				}
			}
		}

		private bool ShouldSerializecheckin()
		{
			return this.checkinSpecified;
		}

		private void Resetcheckin()
		{
			this.checkinSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "boxmask", DataFormat = DataFormat.TwosComplement)]
		public uint boxmask
		{
			get
			{
				return this._boxmask ?? 0U;
			}
			set
			{
				this._boxmask = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool boxmaskSpecified
		{
			get
			{
				return this._boxmask != null;
			}
			set
			{
				bool flag = value == (this._boxmask == null);
				if (flag)
				{
					this._boxmask = (value ? new uint?(this.boxmask) : null);
				}
			}
		}

		private bool ShouldSerializeboxmask()
		{
			return this.boxmaskSpecified;
		}

		private void Resetboxmask()
		{
			this.boxmaskSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _checkincount;

		private uint? _allcount;

		private uint? _checkin;

		private uint? _boxmask;

		private ErrorCode? _errorcode;

		private IExtension extensionObject;
	}
}
