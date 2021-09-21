using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000D8 RID: 216
	[ProtoContract(Name = "TeamInviteAck")]
	[Serializable]
	public class TeamInviteAck : IExtensible
	{
		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06000DED RID: 3565 RVA: 0x0001CF84 File Offset: 0x0001B184
		// (set) Token: 0x06000DEE RID: 3566 RVA: 0x0001CFB0 File Offset: 0x0001B1B0
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

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06000DEF RID: 3567 RVA: 0x0001CFC0 File Offset: 0x0001B1C0
		// (set) Token: 0x06000DF0 RID: 3568 RVA: 0x0001CFE0 File Offset: 0x0001B1E0
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

		// Token: 0x06000DF1 RID: 3569 RVA: 0x0001D024 File Offset: 0x0001B224
		private bool ShouldSerializeaccept()
		{
			return this.acceptSpecified;
		}

		// Token: 0x06000DF2 RID: 3570 RVA: 0x0001D03C File Offset: 0x0001B23C
		private void Resetaccept()
		{
			this.acceptSpecified = false;
		}

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06000DF3 RID: 3571 RVA: 0x0001D048 File Offset: 0x0001B248
		// (set) Token: 0x06000DF4 RID: 3572 RVA: 0x0001D074 File Offset: 0x0001B274
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

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x06000DF5 RID: 3573 RVA: 0x0001D084 File Offset: 0x0001B284
		// (set) Token: 0x06000DF6 RID: 3574 RVA: 0x0001D0A4 File Offset: 0x0001B2A4
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

		// Token: 0x06000DF7 RID: 3575 RVA: 0x0001D0E8 File Offset: 0x0001B2E8
		private bool ShouldSerializeinviteid()
		{
			return this.inviteidSpecified;
		}

		// Token: 0x06000DF8 RID: 3576 RVA: 0x0001D100 File Offset: 0x0001B300
		private void Resetinviteid()
		{
			this.inviteidSpecified = false;
		}

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x06000DF9 RID: 3577 RVA: 0x0001D10C File Offset: 0x0001B30C
		// (set) Token: 0x06000DFA RID: 3578 RVA: 0x0001D12D File Offset: 0x0001B32D
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

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x06000DFB RID: 3579 RVA: 0x0001D138 File Offset: 0x0001B338
		// (set) Token: 0x06000DFC RID: 3580 RVA: 0x0001D154 File Offset: 0x0001B354
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

		// Token: 0x06000DFD RID: 3581 RVA: 0x0001D184 File Offset: 0x0001B384
		private bool ShouldSerializepassword()
		{
			return this.passwordSpecified;
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x0001D19C File Offset: 0x0001B39C
		private void Resetpassword()
		{
			this.passwordSpecified = false;
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x0001D1A8 File Offset: 0x0001B3A8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000380 RID: 896
		private bool? _accept;

		// Token: 0x04000381 RID: 897
		private uint? _inviteid;

		// Token: 0x04000382 RID: 898
		private string _password;

		// Token: 0x04000383 RID: 899
		private IExtension extensionObject;
	}
}
