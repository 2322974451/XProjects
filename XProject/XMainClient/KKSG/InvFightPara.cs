using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "InvFightPara")]
	[Serializable]
	public class InvFightPara : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ntftype", DataFormat = DataFormat.TwosComplement)]
		public InvFightNotifyType ntftype
		{
			get
			{
				return this._ntftype ?? InvFightNotifyType.IFNT_REFUSE_ME;
			}
			set
			{
				this._ntftype = new InvFightNotifyType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ntftypeSpecified
		{
			get
			{
				return this._ntftype != null;
			}
			set
			{
				bool flag = value == (this._ntftype == null);
				if (flag)
				{
					this._ntftype = (value ? new InvFightNotifyType?(this.ntftype) : null);
				}
			}
		}

		private bool ShouldSerializentftype()
		{
			return this.ntftypeSpecified;
		}

		private void Resetntftype()
		{
			this.ntftypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		private void Resetcount()
		{
			this.countSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private InvFightNotifyType? _ntftype;

		private string _name;

		private uint? _count;

		private IExtension extensionObject;
	}
}
