using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CustomBattleGMNotify")]
	[Serializable]
	public class CustomBattleGMNotify : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isgmcreate", DataFormat = DataFormat.Default)]
		public bool isgmcreate
		{
			get
			{
				return this._isgmcreate ?? false;
			}
			set
			{
				this._isgmcreate = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isgmcreateSpecified
		{
			get
			{
				return this._isgmcreate != null;
			}
			set
			{
				bool flag = value == (this._isgmcreate == null);
				if (flag)
				{
					this._isgmcreate = (value ? new bool?(this.isgmcreate) : null);
				}
			}
		}

		private bool ShouldSerializeisgmcreate()
		{
			return this.isgmcreateSpecified;
		}

		private void Resetisgmcreate()
		{
			this.isgmcreateSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "isgmjoin", DataFormat = DataFormat.Default)]
		public bool isgmjoin
		{
			get
			{
				return this._isgmjoin ?? false;
			}
			set
			{
				this._isgmjoin = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isgmjoinSpecified
		{
			get
			{
				return this._isgmjoin != null;
			}
			set
			{
				bool flag = value == (this._isgmjoin == null);
				if (flag)
				{
					this._isgmjoin = (value ? new bool?(this.isgmjoin) : null);
				}
			}
		}

		private bool ShouldSerializeisgmjoin()
		{
			return this.isgmjoinSpecified;
		}

		private void Resetisgmjoin()
		{
			this.isgmjoinSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isgmcreate;

		private bool? _isgmjoin;

		private IExtension extensionObject;
	}
}
