using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "InvFightRes")]
	[Serializable]
	public class InvFightRes : IExtensible
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

		[ProtoMember(2, Name = "roles", DataFormat = DataFormat.Default)]
		public List<InvFightRoleBrief> roles
		{
			get
			{
				return this._roles;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "isPlatFriendOnline", DataFormat = DataFormat.Default)]
		public bool isPlatFriendOnline
		{
			get
			{
				return this._isPlatFriendOnline ?? false;
			}
			set
			{
				this._isPlatFriendOnline = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isPlatFriendOnlineSpecified
		{
			get
			{
				return this._isPlatFriendOnline != null;
			}
			set
			{
				bool flag = value == (this._isPlatFriendOnline == null);
				if (flag)
				{
					this._isPlatFriendOnline = (value ? new bool?(this.isPlatFriendOnline) : null);
				}
			}
		}

		private bool ShouldSerializeisPlatFriendOnline()
		{
			return this.isPlatFriendOnlineSpecified;
		}

		private void ResetisPlatFriendOnline()
		{
			this.isPlatFriendOnlineSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private readonly List<InvFightRoleBrief> _roles = new List<InvFightRoleBrief>();

		private bool? _isPlatFriendOnline;

		private IExtension extensionObject;
	}
}
