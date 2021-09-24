using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayMember")]
	[Serializable]
	public class PayMember : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ID", DataFormat = DataFormat.TwosComplement)]
		public int ID
		{
			get
			{
				return this._ID ?? 0;
			}
			set
			{
				this._ID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool IDSpecified
		{
			get
			{
				return this._ID != null;
			}
			set
			{
				bool flag = value == (this._ID == null);
				if (flag)
				{
					this._ID = (value ? new int?(this.ID) : null);
				}
			}
		}

		private bool ShouldSerializeID()
		{
			return this.IDSpecified;
		}

		private void ResetID()
		{
			this.IDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "ExpireTime", DataFormat = DataFormat.TwosComplement)]
		public int ExpireTime
		{
			get
			{
				return this._ExpireTime ?? 0;
			}
			set
			{
				this._ExpireTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ExpireTimeSpecified
		{
			get
			{
				return this._ExpireTime != null;
			}
			set
			{
				bool flag = value == (this._ExpireTime == null);
				if (flag)
				{
					this._ExpireTime = (value ? new int?(this.ExpireTime) : null);
				}
			}
		}

		private bool ShouldSerializeExpireTime()
		{
			return this.ExpireTimeSpecified;
		}

		private void ResetExpireTime()
		{
			this.ExpireTimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "isClick", DataFormat = DataFormat.Default)]
		public bool isClick
		{
			get
			{
				return this._isClick ?? false;
			}
			set
			{
				this._isClick = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isClickSpecified
		{
			get
			{
				return this._isClick != null;
			}
			set
			{
				bool flag = value == (this._isClick == null);
				if (flag)
				{
					this._isClick = (value ? new bool?(this.isClick) : null);
				}
			}
		}

		private bool ShouldSerializeisClick()
		{
			return this.isClickSpecified;
		}

		private void ResetisClick()
		{
			this.isClickSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _ID;

		private int? _ExpireTime;

		private bool? _isClick;

		private IExtension extensionObject;
	}
}
