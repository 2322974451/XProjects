using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PayMemberRecord")]
	[Serializable]
	public class PayMemberRecord : IExtensible
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

		[ProtoMember(4, IsRequired = false, Name = "buttonStatus", DataFormat = DataFormat.TwosComplement)]
		public int buttonStatus
		{
			get
			{
				return this._buttonStatus ?? 0;
			}
			set
			{
				this._buttonStatus = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool buttonStatusSpecified
		{
			get
			{
				return this._buttonStatus != null;
			}
			set
			{
				bool flag = value == (this._buttonStatus == null);
				if (flag)
				{
					this._buttonStatus = (value ? new int?(this.buttonStatus) : null);
				}
			}
		}

		private bool ShouldSerializebuttonStatus()
		{
			return this.buttonStatusSpecified;
		}

		private void ResetbuttonStatus()
		{
			this.buttonStatusSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "lastDragonFlowerTime", DataFormat = DataFormat.TwosComplement)]
		public int lastDragonFlowerTime
		{
			get
			{
				return this._lastDragonFlowerTime ?? 0;
			}
			set
			{
				this._lastDragonFlowerTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastDragonFlowerTimeSpecified
		{
			get
			{
				return this._lastDragonFlowerTime != null;
			}
			set
			{
				bool flag = value == (this._lastDragonFlowerTime == null);
				if (flag)
				{
					this._lastDragonFlowerTime = (value ? new int?(this.lastDragonFlowerTime) : null);
				}
			}
		}

		private bool ShouldSerializelastDragonFlowerTime()
		{
			return this.lastDragonFlowerTimeSpecified;
		}

		private void ResetlastDragonFlowerTime()
		{
			this.lastDragonFlowerTimeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "isNotifyExpire", DataFormat = DataFormat.Default)]
		public bool isNotifyExpire
		{
			get
			{
				return this._isNotifyExpire ?? false;
			}
			set
			{
				this._isNotifyExpire = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isNotifyExpireSpecified
		{
			get
			{
				return this._isNotifyExpire != null;
			}
			set
			{
				bool flag = value == (this._isNotifyExpire == null);
				if (flag)
				{
					this._isNotifyExpire = (value ? new bool?(this.isNotifyExpire) : null);
				}
			}
		}

		private bool ShouldSerializeisNotifyExpire()
		{
			return this.isNotifyExpireSpecified;
		}

		private void ResetisNotifyExpire()
		{
			this.isNotifyExpireSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "begintime", DataFormat = DataFormat.TwosComplement)]
		public int begintime
		{
			get
			{
				return this._begintime ?? 0;
			}
			set
			{
				this._begintime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool begintimeSpecified
		{
			get
			{
				return this._begintime != null;
			}
			set
			{
				bool flag = value == (this._begintime == null);
				if (flag)
				{
					this._begintime = (value ? new int?(this.begintime) : null);
				}
			}
		}

		private bool ShouldSerializebegintime()
		{
			return this.begintimeSpecified;
		}

		private void Resetbegintime()
		{
			this.begintimeSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "isNotifyExpireSoon", DataFormat = DataFormat.Default)]
		public bool isNotifyExpireSoon
		{
			get
			{
				return this._isNotifyExpireSoon ?? false;
			}
			set
			{
				this._isNotifyExpireSoon = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isNotifyExpireSoonSpecified
		{
			get
			{
				return this._isNotifyExpireSoon != null;
			}
			set
			{
				bool flag = value == (this._isNotifyExpireSoon == null);
				if (flag)
				{
					this._isNotifyExpireSoon = (value ? new bool?(this.isNotifyExpireSoon) : null);
				}
			}
		}

		private bool ShouldSerializeisNotifyExpireSoon()
		{
			return this.isNotifyExpireSoonSpecified;
		}

		private void ResetisNotifyExpireSoon()
		{
			this.isNotifyExpireSoonSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _ID;

		private int? _ExpireTime;

		private bool? _isClick;

		private int? _buttonStatus;

		private int? _lastDragonFlowerTime;

		private bool? _isNotifyExpire;

		private int? _begintime;

		private bool? _isNotifyExpireSoon;

		private IExtension extensionObject;
	}
}
