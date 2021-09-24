using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LoadAccountData")]
	[Serializable]
	public class LoadAccountData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "account", DataFormat = DataFormat.Default)]
		public string account
		{
			get
			{
				return this._account ?? "";
			}
			set
			{
				this._account = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool accountSpecified
		{
			get
			{
				return this._account != null;
			}
			set
			{
				bool flag = value == (this._account == null);
				if (flag)
				{
					this._account = (value ? this.account : null);
				}
			}
		}

		private bool ShouldSerializeaccount()
		{
			return this.accountSpecified;
		}

		private void Resetaccount()
		{
			this.accountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "role1", DataFormat = DataFormat.Default)]
		public byte[] role1
		{
			get
			{
				return this._role1 ?? null;
			}
			set
			{
				this._role1 = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool role1Specified
		{
			get
			{
				return this._role1 != null;
			}
			set
			{
				bool flag = value == (this._role1 == null);
				if (flag)
				{
					this._role1 = (value ? this.role1 : null);
				}
			}
		}

		private bool ShouldSerializerole1()
		{
			return this.role1Specified;
		}

		private void Resetrole1()
		{
			this.role1Specified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "role2", DataFormat = DataFormat.Default)]
		public byte[] role2
		{
			get
			{
				return this._role2 ?? null;
			}
			set
			{
				this._role2 = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool role2Specified
		{
			get
			{
				return this._role2 != null;
			}
			set
			{
				bool flag = value == (this._role2 == null);
				if (flag)
				{
					this._role2 = (value ? this.role2 : null);
				}
			}
		}

		private bool ShouldSerializerole2()
		{
			return this.role2Specified;
		}

		private void Resetrole2()
		{
			this.role2Specified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "role3", DataFormat = DataFormat.Default)]
		public byte[] role3
		{
			get
			{
				return this._role3 ?? null;
			}
			set
			{
				this._role3 = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool role3Specified
		{
			get
			{
				return this._role3 != null;
			}
			set
			{
				bool flag = value == (this._role3 == null);
				if (flag)
				{
					this._role3 = (value ? this.role3 : null);
				}
			}
		}

		private bool ShouldSerializerole3()
		{
			return this.role3Specified;
		}

		private void Resetrole3()
		{
			this.role3Specified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "role4", DataFormat = DataFormat.Default)]
		public byte[] role4
		{
			get
			{
				return this._role4 ?? null;
			}
			set
			{
				this._role4 = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool role4Specified
		{
			get
			{
				return this._role4 != null;
			}
			set
			{
				bool flag = value == (this._role4 == null);
				if (flag)
				{
					this._role4 = (value ? this.role4 : null);
				}
			}
		}

		private bool ShouldSerializerole4()
		{
			return this.role4Specified;
		}

		private void Resetrole4()
		{
			this.role4Specified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "selectSlot", DataFormat = DataFormat.TwosComplement)]
		public uint selectSlot
		{
			get
			{
				return this._selectSlot ?? 0U;
			}
			set
			{
				this._selectSlot = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool selectSlotSpecified
		{
			get
			{
				return this._selectSlot != null;
			}
			set
			{
				bool flag = value == (this._selectSlot == null);
				if (flag)
				{
					this._selectSlot = (value ? new uint?(this.selectSlot) : null);
				}
			}
		}

		private bool ShouldSerializeselectSlot()
		{
			return this.selectSlotSpecified;
		}

		private void ResetselectSlot()
		{
			this.selectSlotSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "role5", DataFormat = DataFormat.Default)]
		public byte[] role5
		{
			get
			{
				return this._role5 ?? null;
			}
			set
			{
				this._role5 = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool role5Specified
		{
			get
			{
				return this._role5 != null;
			}
			set
			{
				bool flag = value == (this._role5 == null);
				if (flag)
				{
					this._role5 = (value ? this.role5 : null);
				}
			}
		}

		private bool ShouldSerializerole5()
		{
			return this.role5Specified;
		}

		private void Resetrole5()
		{
			this.role5Specified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "role6", DataFormat = DataFormat.Default)]
		public byte[] role6
		{
			get
			{
				return this._role6 ?? null;
			}
			set
			{
				this._role6 = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool role6Specified
		{
			get
			{
				return this._role6 != null;
			}
			set
			{
				bool flag = value == (this._role6 == null);
				if (flag)
				{
					this._role6 = (value ? this.role6 : null);
				}
			}
		}

		private bool ShouldSerializerole6()
		{
			return this.role6Specified;
		}

		private void Resetrole6()
		{
			this.role6Specified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "role7", DataFormat = DataFormat.Default)]
		public byte[] role7
		{
			get
			{
				return this._role7 ?? null;
			}
			set
			{
				this._role7 = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool role7Specified
		{
			get
			{
				return this._role7 != null;
			}
			set
			{
				bool flag = value == (this._role7 == null);
				if (flag)
				{
					this._role7 = (value ? this.role7 : null);
				}
			}
		}

		private bool ShouldSerializerole7()
		{
			return this.role7Specified;
		}

		private void Resetrole7()
		{
			this.role7Specified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "role8", DataFormat = DataFormat.Default)]
		public byte[] role8
		{
			get
			{
				return this._role8 ?? null;
			}
			set
			{
				this._role8 = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool role8Specified
		{
			get
			{
				return this._role8 != null;
			}
			set
			{
				bool flag = value == (this._role8 == null);
				if (flag)
				{
					this._role8 = (value ? this.role8 : null);
				}
			}
		}

		private bool ShouldSerializerole8()
		{
			return this.role8Specified;
		}

		private void Resetrole8()
		{
			this.role8Specified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "role9", DataFormat = DataFormat.Default)]
		public byte[] role9
		{
			get
			{
				return this._role9 ?? null;
			}
			set
			{
				this._role9 = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool role9Specified
		{
			get
			{
				return this._role9 != null;
			}
			set
			{
				bool flag = value == (this._role9 == null);
				if (flag)
				{
					this._role9 = (value ? this.role9 : null);
				}
			}
		}

		private bool ShouldSerializerole9()
		{
			return this.role9Specified;
		}

		private void Resetrole9()
		{
			this.role9Specified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _account;

		private byte[] _role1;

		private byte[] _role2;

		private byte[] _role3;

		private byte[] _role4;

		private uint? _selectSlot;

		private byte[] _role5;

		private byte[] _role6;

		private byte[] _role7;

		private byte[] _role8;

		private byte[] _role9;

		private IExtension extensionObject;
	}
}
