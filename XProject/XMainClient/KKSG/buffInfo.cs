using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "buffInfo")]
	[Serializable]
	public class buffInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "addbuff", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BuffInfo addbuff
		{
			get
			{
				return this._addbuff;
			}
			set
			{
				this._addbuff = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "removebuff", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BuffInfo removebuff
		{
			get
			{
				return this._removebuff;
			}
			set
			{
				this._removebuff = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "updatebuff", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BuffInfo updatebuff
		{
			get
			{
				return this._updatebuff;
			}
			set
			{
				this._updatebuff = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "allbuffsinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public AllBuffsInfo allbuffsinfo
		{
			get
			{
				return this._allbuffsinfo;
			}
			set
			{
				this._allbuffsinfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uid;

		private BuffInfo _addbuff = null;

		private BuffInfo _removebuff = null;

		private BuffInfo _updatebuff = null;

		private AllBuffsInfo _allbuffsinfo = null;

		private IExtension extensionObject;
	}
}
