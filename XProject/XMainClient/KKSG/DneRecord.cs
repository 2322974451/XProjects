using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DneRecord")]
	[Serializable]
	public class DneRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "dneid", DataFormat = DataFormat.TwosComplement)]
		public uint dneid
		{
			get
			{
				return this._dneid ?? 0U;
			}
			set
			{
				this._dneid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dneidSpecified
		{
			get
			{
				return this._dneid != null;
			}
			set
			{
				bool flag = value == (this._dneid == null);
				if (flag)
				{
					this._dneid = (value ? new uint?(this.dneid) : null);
				}
			}
		}

		private bool ShouldSerializedneid()
		{
			return this.dneidSpecified;
		}

		private void Resetdneid()
		{
			this.dneidSpecified = false;
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

		private uint? _dneid;

		private uint? _count;

		private IExtension extensionObject;
	}
}
