using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AtlasUpStarRes")]
	[Serializable]
	public class AtlasUpStarRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "groupid", DataFormat = DataFormat.TwosComplement)]
		public uint groupid
		{
			get
			{
				return this._groupid ?? 0U;
			}
			set
			{
				this._groupid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool groupidSpecified
		{
			get
			{
				return this._groupid != null;
			}
			set
			{
				bool flag = value == (this._groupid == null);
				if (flag)
				{
					this._groupid = (value ? new uint?(this.groupid) : null);
				}
			}
		}

		private bool ShouldSerializegroupid()
		{
			return this.groupidSpecified;
		}

		private void Resetgroupid()
		{
			this.groupidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "star", DataFormat = DataFormat.TwosComplement)]
		public uint star
		{
			get
			{
				return this._star ?? 0U;
			}
			set
			{
				this._star = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool starSpecified
		{
			get
			{
				return this._star != null;
			}
			set
			{
				bool flag = value == (this._star == null);
				if (flag)
				{
					this._star = (value ? new uint?(this.star) : null);
				}
			}
		}

		private bool ShouldSerializestar()
		{
			return this.starSpecified;
		}

		private void Resetstar()
		{
			this.starSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private uint? _groupid;

		private uint? _star;

		private IExtension extensionObject;
	}
}
