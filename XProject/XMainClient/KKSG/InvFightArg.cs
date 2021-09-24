using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "InvFightArg")]
	[Serializable]
	public class InvFightArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "reqtype", DataFormat = DataFormat.TwosComplement)]
		public InvFightReqType reqtype
		{
			get
			{
				return this._reqtype ?? InvFightReqType.IFRT_INV_ONE;
			}
			set
			{
				this._reqtype = new InvFightReqType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reqtypeSpecified
		{
			get
			{
				return this._reqtype != null;
			}
			set
			{
				bool flag = value == (this._reqtype == null);
				if (flag)
				{
					this._reqtype = (value ? new InvFightReqType?(this.reqtype) : null);
				}
			}
		}

		private bool ShouldSerializereqtype()
		{
			return this.reqtypeSpecified;
		}

		private void Resetreqtype()
		{
			this.reqtypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "invid", DataFormat = DataFormat.TwosComplement)]
		public ulong invid
		{
			get
			{
				return this._invid ?? 0UL;
			}
			set
			{
				this._invid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool invidSpecified
		{
			get
			{
				return this._invid != null;
			}
			set
			{
				bool flag = value == (this._invid == null);
				if (flag)
				{
					this._invid = (value ? new ulong?(this.invid) : null);
				}
			}
		}

		private bool ShouldSerializeinvid()
		{
			return this.invidSpecified;
		}

		private void Resetinvid()
		{
			this.invidSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "iscross", DataFormat = DataFormat.Default)]
		public bool iscross
		{
			get
			{
				return this._iscross ?? false;
			}
			set
			{
				this._iscross = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool iscrossSpecified
		{
			get
			{
				return this._iscross != null;
			}
			set
			{
				bool flag = value == (this._iscross == null);
				if (flag)
				{
					this._iscross = (value ? new bool?(this.iscross) : null);
				}
			}
		}

		private bool ShouldSerializeiscross()
		{
			return this.iscrossSpecified;
		}

		private void Resetiscross()
		{
			this.iscrossSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "account", DataFormat = DataFormat.Default)]
		public string account
		{
			get
			{
				return this._account ?? "";
			}
			set
			{
				this._account = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool accountSpecified
		{
			get
			{
				return this._account != null;
			}
			set
			{
				bool flag = value == (this._account == null);
				if (flag)
				{
					this._account = (value ? this.account : null);
				}
			}
		}

		private bool ShouldSerializeaccount()
		{
			return this.accountSpecified;
		}

		private void Resetaccount()
		{
			this.accountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private InvFightReqType? _reqtype;

		private ulong? _roleid;

		private ulong? _invid;

		private bool? _iscross;

		private string _account;

		private IExtension extensionObject;
	}
}
