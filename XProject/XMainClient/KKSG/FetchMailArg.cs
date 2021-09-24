using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FetchMailArg")]
	[Serializable]
	public class FetchMailArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "page", DataFormat = DataFormat.TwosComplement)]
		public uint page
		{
			get
			{
				return this._page ?? 0U;
			}
			set
			{
				this._page = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pageSpecified
		{
			get
			{
				return this._page != null;
			}
			set
			{
				bool flag = value == (this._page == null);
				if (flag)
				{
					this._page = (value ? new uint?(this.page) : null);
				}
			}
		}

		private bool ShouldSerializepage()
		{
			return this.pageSpecified;
		}

		private void Resetpage()
		{
			this.pageSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
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

		private uint? _page;

		private uint? _count;

		private IExtension extensionObject;
	}
}
