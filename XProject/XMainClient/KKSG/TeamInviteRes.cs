using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamInviteRes")]
	[Serializable]
	public class TeamInviteRes : IExtensible
	{

		[ProtoMember(1, Name = "friend", DataFormat = DataFormat.Default)]
		public List<TeamInvRoleInfo> friend
		{
			get
			{
				return this._friend;
			}
		}

		[ProtoMember(2, Name = "guild", DataFormat = DataFormat.Default)]
		public List<TeamInvRoleInfo> guild
		{
			get
			{
				return this._guild;
			}
		}

		[ProtoMember(3, Name = "rec", DataFormat = DataFormat.Default)]
		public List<TeamInvRoleInfo> rec
		{
			get
			{
				return this._rec;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<TeamInvRoleInfo> _friend = new List<TeamInvRoleInfo>();

		private readonly List<TeamInvRoleInfo> _guild = new List<TeamInvRoleInfo>();

		private readonly List<TeamInvRoleInfo> _rec = new List<TeamInvRoleInfo>();

		private ErrorCode? _errcode;

		private IExtension extensionObject;
	}
}
