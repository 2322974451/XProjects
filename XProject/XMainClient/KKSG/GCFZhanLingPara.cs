using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GCFZhanLingPara")]
	[Serializable]
	public class GCFZhanLingPara : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "zltype", DataFormat = DataFormat.TwosComplement)]
		public GCFZhanLingType zltype
		{
			get
			{
				return this._zltype ?? GCFZhanLingType.GCFZL_BEGIN;
			}
			set
			{
				this._zltype = new GCFZhanLingType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool zltypeSpecified
		{
			get
			{
				return this._zltype != null;
			}
			set
			{
				bool flag = value == (this._zltype == null);
				if (flag)
				{
					this._zltype = (value ? new GCFZhanLingType?(this.zltype) : null);
				}
			}
		}

		private bool ShouldSerializezltype()
		{
			return this.zltypeSpecified;
		}

		private void Resetzltype()
		{
			this.zltypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "jdtype", DataFormat = DataFormat.TwosComplement)]
		public GCFJvDianType jdtype
		{
			get
			{
				return this._jdtype ?? GCFJvDianType.GCF_JUDIAN_UP;
			}
			set
			{
				this._jdtype = new GCFJvDianType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool jdtypeSpecified
		{
			get
			{
				return this._jdtype != null;
			}
			set
			{
				bool flag = value == (this._jdtype == null);
				if (flag)
				{
					this._jdtype = (value ? new GCFJvDianType?(this.jdtype) : null);
				}
			}
		}

		private bool ShouldSerializejdtype()
		{
			return this.jdtypeSpecified;
		}

		private void Resetjdtype()
		{
			this.jdtypeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private GCFZhanLingType? _zltype;

		private ulong? _roleID;

		private GCFJvDianType? _jdtype;

		private IExtension extensionObject;
	}
}
