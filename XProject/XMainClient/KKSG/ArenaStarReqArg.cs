using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ArenaStarReqArg")]
	[Serializable]
	public class ArenaStarReqArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "reqtype", DataFormat = DataFormat.TwosComplement)]
		public ArenaStarReqType reqtype
		{
			get
			{
				return this._reqtype ?? ArenaStarReqType.ASRT_ROLEDATA;
			}
			set
			{
				this._reqtype = new ArenaStarReqType?(value);
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
					this._reqtype = (value ? new ArenaStarReqType?(this.reqtype) : null);
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

		[ProtoMember(3, IsRequired = false, Name = "zantype", DataFormat = DataFormat.TwosComplement)]
		public ArenaStarType zantype
		{
			get
			{
				return this._zantype ?? ArenaStarType.AST_PK;
			}
			set
			{
				this._zantype = new ArenaStarType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool zantypeSpecified
		{
			get
			{
				return this._zantype != null;
			}
			set
			{
				bool flag = value == (this._zantype == null);
				if (flag)
				{
					this._zantype = (value ? new ArenaStarType?(this.zantype) : null);
				}
			}
		}

		private bool ShouldSerializezantype()
		{
			return this.zantypeSpecified;
		}

		private void Resetzantype()
		{
			this.zantypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ArenaStarReqType? _reqtype;

		private ulong? _roleid;

		private ArenaStarType? _zantype;

		private IExtension extensionObject;
	}
}
