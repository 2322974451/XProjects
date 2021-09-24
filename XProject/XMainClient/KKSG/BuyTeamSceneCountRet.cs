using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BuyTeamSceneCountRet")]
	[Serializable]
	public class BuyTeamSceneCountRet : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "maxcount", DataFormat = DataFormat.TwosComplement)]
		public uint maxcount
		{
			get
			{
				return this._maxcount ?? 0U;
			}
			set
			{
				this._maxcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxcountSpecified
		{
			get
			{
				return this._maxcount != null;
			}
			set
			{
				bool flag = value == (this._maxcount == null);
				if (flag)
				{
					this._maxcount = (value ? new uint?(this.maxcount) : null);
				}
			}
		}

		private bool ShouldSerializemaxcount()
		{
			return this.maxcountSpecified;
		}

		private void Resetmaxcount()
		{
			this.maxcountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "buycount", DataFormat = DataFormat.TwosComplement)]
		public uint buycount
		{
			get
			{
				return this._buycount ?? 0U;
			}
			set
			{
				this._buycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buycountSpecified
		{
			get
			{
				return this._buycount != null;
			}
			set
			{
				bool flag = value == (this._buycount == null);
				if (flag)
				{
					this._buycount = (value ? new uint?(this.buycount) : null);
				}
			}
		}

		private bool ShouldSerializebuycount()
		{
			return this.buycountSpecified;
		}

		private void Resetbuycount()
		{
			this.buycountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "entercount", DataFormat = DataFormat.TwosComplement)]
		public uint entercount
		{
			get
			{
				return this._entercount ?? 0U;
			}
			set
			{
				this._entercount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool entercountSpecified
		{
			get
			{
				return this._entercount != null;
			}
			set
			{
				bool flag = value == (this._entercount == null);
				if (flag)
				{
					this._entercount = (value ? new uint?(this.entercount) : null);
				}
			}
		}

		private bool ShouldSerializeentercount()
		{
			return this.entercountSpecified;
		}

		private void Resetentercount()
		{
			this.entercountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _maxcount;

		private uint? _buycount;

		private uint? _entercount;

		private ErrorCode? _errcode;

		private IExtension extensionObject;
	}
}
