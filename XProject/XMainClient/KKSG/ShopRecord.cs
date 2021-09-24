using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ShopRecord")]
	[Serializable]
	public class ShopRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "dayupdate", DataFormat = DataFormat.TwosComplement)]
		public uint dayupdate
		{
			get
			{
				return this._dayupdate ?? 0U;
			}
			set
			{
				this._dayupdate = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dayupdateSpecified
		{
			get
			{
				return this._dayupdate != null;
			}
			set
			{
				bool flag = value == (this._dayupdate == null);
				if (flag)
				{
					this._dayupdate = (value ? new uint?(this.dayupdate) : null);
				}
			}
		}

		private bool ShouldSerializedayupdate()
		{
			return this.dayupdateSpecified;
		}

		private void Resetdayupdate()
		{
			this.dayupdateSpecified = false;
		}

		[ProtoMember(2, Name = "shops", DataFormat = DataFormat.Default)]
		public List<ShopRecordOne> shops
		{
			get
			{
				return this._shops;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "weekupdate", DataFormat = DataFormat.TwosComplement)]
		public uint weekupdate
		{
			get
			{
				return this._weekupdate ?? 0U;
			}
			set
			{
				this._weekupdate = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool weekupdateSpecified
		{
			get
			{
				return this._weekupdate != null;
			}
			set
			{
				bool flag = value == (this._weekupdate == null);
				if (flag)
				{
					this._weekupdate = (value ? new uint?(this.weekupdate) : null);
				}
			}
		}

		private bool ShouldSerializeweekupdate()
		{
			return this.weekupdateSpecified;
		}

		private void Resetweekupdate()
		{
			this.weekupdateSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _dayupdate;

		private readonly List<ShopRecordOne> _shops = new List<ShopRecordOne>();

		private uint? _weekupdate;

		private IExtension extensionObject;
	}
}
