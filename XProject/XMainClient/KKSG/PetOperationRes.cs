using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PetOperationRes")]
	[Serializable]
	public class PetOperationRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "followpetid", DataFormat = DataFormat.TwosComplement)]
		public ulong followpetid
		{
			get
			{
				return this._followpetid ?? 0UL;
			}
			set
			{
				this._followpetid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool followpetidSpecified
		{
			get
			{
				return this._followpetid != null;
			}
			set
			{
				bool flag = value == (this._followpetid == null);
				if (flag)
				{
					this._followpetid = (value ? new ulong?(this.followpetid) : null);
				}
			}
		}

		private bool ShouldSerializefollowpetid()
		{
			return this.followpetidSpecified;
		}

		private void Resetfollowpetid()
		{
			this.followpetidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "ismoodup", DataFormat = DataFormat.Default)]
		public bool ismoodup
		{
			get
			{
				return this._ismoodup ?? false;
			}
			set
			{
				this._ismoodup = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ismoodupSpecified
		{
			get
			{
				return this._ismoodup != null;
			}
			set
			{
				bool flag = value == (this._ismoodup == null);
				if (flag)
				{
					this._ismoodup = (value ? new bool?(this.ismoodup) : null);
				}
			}
		}

		private bool ShouldSerializeismoodup()
		{
			return this.ismoodupSpecified;
		}

		private void Resetismoodup()
		{
			this.ismoodupSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "ishuneryup", DataFormat = DataFormat.Default)]
		public bool ishuneryup
		{
			get
			{
				return this._ishuneryup ?? false;
			}
			set
			{
				this._ishuneryup = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ishuneryupSpecified
		{
			get
			{
				return this._ishuneryup != null;
			}
			set
			{
				bool flag = value == (this._ishuneryup == null);
				if (flag)
				{
					this._ishuneryup = (value ? new bool?(this.ishuneryup) : null);
				}
			}
		}

		private bool ShouldSerializeishuneryup()
		{
			return this.ishuneryupSpecified;
		}

		private void Resetishuneryup()
		{
			this.ishuneryupSpecified = false;
		}

		[ProtoMember(5, Name = "invite", DataFormat = DataFormat.Default)]
		public List<PetInviteInfo> invite
		{
			get
			{
				return this._invite;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private ulong? _followpetid;

		private bool? _ismoodup;

		private bool? _ishuneryup;

		private readonly List<PetInviteInfo> _invite = new List<PetInviteInfo>();

		private IExtension extensionObject;
	}
}
