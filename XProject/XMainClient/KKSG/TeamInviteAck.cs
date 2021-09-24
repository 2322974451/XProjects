using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamInviteAck")]
	[Serializable]
	public class TeamInviteAck : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "accept", DataFormat = DataFormat.Default)]
		public bool accept
		{
			get
			{
				return this._accept ?? false;
			}
			set
			{
				this._accept = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool acceptSpecified
		{
			get
			{
				return this._accept != null;
			}
			set
			{
				bool flag = value == (this._accept == null);
				if (flag)
				{
					this._accept = (value ? new bool?(this.accept) : null);
				}
			}
		}

		private bool ShouldSerializeaccept()
		{
			return this.acceptSpecified;
		}

		private void Resetaccept()
		{
			this.acceptSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "inviteid", DataFormat = DataFormat.TwosComplement)]
		public uint inviteid
		{
			get
			{
				return this._inviteid ?? 0U;
			}
			set
			{
				this._inviteid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool inviteidSpecified
		{
			get
			{
				return this._inviteid != null;
			}
			set
			{
				bool flag = value == (this._inviteid == null);
				if (flag)
				{
					this._inviteid = (value ? new uint?(this.inviteid) : null);
				}
			}
		}

		private bool ShouldSerializeinviteid()
		{
			return this.inviteidSpecified;
		}

		private void Resetinviteid()
		{
			this.inviteidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "password", DataFormat = DataFormat.Default)]
		public string password
		{
			get
			{
				return this._password ?? "";
			}
			set
			{
				this._password = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool passwordSpecified
		{
			get
			{
				return this._password != null;
			}
			set
			{
				bool flag = value == (this._password == null);
				if (flag)
				{
					this._password = (value ? this.password : null);
				}
			}
		}

		private bool ShouldSerializepassword()
		{
			return this.passwordSpecified;
		}

		private void Resetpassword()
		{
			this.passwordSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _accept;

		private uint? _inviteid;

		private string _password;

		private IExtension extensionObject;
	}
}
