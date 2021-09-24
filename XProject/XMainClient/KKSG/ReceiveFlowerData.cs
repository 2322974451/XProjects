using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReceiveFlowerData")]
	[Serializable]
	public class ReceiveFlowerData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
		public int itemID
		{
			get
			{
				return this._itemID ?? 0;
			}
			set
			{
				this._itemID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemIDSpecified
		{
			get
			{
				return this._itemID != null;
			}
			set
			{
				bool flag = value == (this._itemID == null);
				if (flag)
				{
					this._itemID = (value ? new int?(this.itemID) : null);
				}
			}
		}

		private bool ShouldSerializeitemID()
		{
			return this.itemIDSpecified;
		}

		private void ResetitemID()
		{
			this.itemIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "itemCount", DataFormat = DataFormat.TwosComplement)]
		public int itemCount
		{
			get
			{
				return this._itemCount ?? 0;
			}
			set
			{
				this._itemCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool itemCountSpecified
		{
			get
			{
				return this._itemCount != null;
			}
			set
			{
				bool flag = value == (this._itemCount == null);
				if (flag)
				{
					this._itemCount = (value ? new int?(this.itemCount) : null);
				}
			}
		}

		private bool ShouldSerializeitemCount()
		{
			return this.itemCountSpecified;
		}

		private void ResetitemCount()
		{
			this.itemCountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "sendRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong sendRoleID
		{
			get
			{
				return this._sendRoleID ?? 0UL;
			}
			set
			{
				this._sendRoleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sendRoleIDSpecified
		{
			get
			{
				return this._sendRoleID != null;
			}
			set
			{
				bool flag = value == (this._sendRoleID == null);
				if (flag)
				{
					this._sendRoleID = (value ? new ulong?(this.sendRoleID) : null);
				}
			}
		}

		private bool ShouldSerializesendRoleID()
		{
			return this.sendRoleIDSpecified;
		}

		private void ResetsendRoleID()
		{
			this.sendRoleIDSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "sendName", DataFormat = DataFormat.Default)]
		public string sendName
		{
			get
			{
				return this._sendName ?? "";
			}
			set
			{
				this._sendName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sendNameSpecified
		{
			get
			{
				return this._sendName != null;
			}
			set
			{
				bool flag = value == (this._sendName == null);
				if (flag)
				{
					this._sendName = (value ? this.sendName : null);
				}
			}
		}

		private bool ShouldSerializesendName()
		{
			return this.sendNameSpecified;
		}

		private void ResetsendName()
		{
			this.sendNameSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "power", DataFormat = DataFormat.TwosComplement)]
		public int power
		{
			get
			{
				return this._power ?? 0;
			}
			set
			{
				this._power = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool powerSpecified
		{
			get
			{
				return this._power != null;
			}
			set
			{
				bool flag = value == (this._power == null);
				if (flag)
				{
					this._power = (value ? new int?(this.power) : null);
				}
			}
		}

		private bool ShouldSerializepower()
		{
			return this.powerSpecified;
		}

		private void Resetpower()
		{
			this.powerSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public int profession
		{
			get
			{
				return this._profession ?? 0;
			}
			set
			{
				this._profession = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new int?(this.profession) : null);
				}
			}
		}

		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "vip", DataFormat = DataFormat.TwosComplement)]
		public int vip
		{
			get
			{
				return this._vip ?? 0;
			}
			set
			{
				this._vip = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool vipSpecified
		{
			get
			{
				return this._vip != null;
			}
			set
			{
				bool flag = value == (this._vip == null);
				if (flag)
				{
					this._vip = (value ? new int?(this.vip) : null);
				}
			}
		}

		private bool ShouldSerializevip()
		{
			return this.vipSpecified;
		}

		private void Resetvip()
		{
			this.vipSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _itemID;

		private int? _itemCount;

		private ulong? _sendRoleID;

		private string _sendName;

		private int? _power;

		private int? _profession;

		private int? _vip;

		private IExtension extensionObject;
	}
}
