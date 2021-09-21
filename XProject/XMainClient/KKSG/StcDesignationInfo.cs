using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005E5 RID: 1509
	[ProtoContract(Name = "StcDesignationInfo")]
	[Serializable]
	public class StcDesignationInfo : IExtensible
	{
		// Token: 0x17001B4C RID: 6988
		// (get) Token: 0x060057DA RID: 22490 RVA: 0x000A7598 File Offset: 0x000A5798
		// (set) Token: 0x060057DB RID: 22491 RVA: 0x000A75C4 File Offset: 0x000A57C4
		[ProtoMember(1, IsRequired = false, Name = "designationID", DataFormat = DataFormat.TwosComplement)]
		public uint designationID
		{
			get
			{
				return this._designationID ?? 0U;
			}
			set
			{
				this._designationID = new uint?(value);
			}
		}

		// Token: 0x17001B4D RID: 6989
		// (get) Token: 0x060057DC RID: 22492 RVA: 0x000A75D4 File Offset: 0x000A57D4
		// (set) Token: 0x060057DD RID: 22493 RVA: 0x000A75F4 File Offset: 0x000A57F4
		[XmlIgnore]
		[Browsable(false)]
		public bool designationIDSpecified
		{
			get
			{
				return this._designationID != null;
			}
			set
			{
				bool flag = value == (this._designationID == null);
				if (flag)
				{
					this._designationID = (value ? new uint?(this.designationID) : null);
				}
			}
		}

		// Token: 0x060057DE RID: 22494 RVA: 0x000A7638 File Offset: 0x000A5838
		private bool ShouldSerializedesignationID()
		{
			return this.designationIDSpecified;
		}

		// Token: 0x060057DF RID: 22495 RVA: 0x000A7650 File Offset: 0x000A5850
		private void ResetdesignationID()
		{
			this.designationIDSpecified = false;
		}

		// Token: 0x17001B4E RID: 6990
		// (get) Token: 0x060057E0 RID: 22496 RVA: 0x000A765C File Offset: 0x000A585C
		// (set) Token: 0x060057E1 RID: 22497 RVA: 0x000A7688 File Offset: 0x000A5888
		[ProtoMember(2, IsRequired = false, Name = "isNew", DataFormat = DataFormat.Default)]
		public bool isNew
		{
			get
			{
				return this._isNew ?? false;
			}
			set
			{
				this._isNew = new bool?(value);
			}
		}

		// Token: 0x17001B4F RID: 6991
		// (get) Token: 0x060057E2 RID: 22498 RVA: 0x000A7698 File Offset: 0x000A5898
		// (set) Token: 0x060057E3 RID: 22499 RVA: 0x000A76B8 File Offset: 0x000A58B8
		[XmlIgnore]
		[Browsable(false)]
		public bool isNewSpecified
		{
			get
			{
				return this._isNew != null;
			}
			set
			{
				bool flag = value == (this._isNew == null);
				if (flag)
				{
					this._isNew = (value ? new bool?(this.isNew) : null);
				}
			}
		}

		// Token: 0x060057E4 RID: 22500 RVA: 0x000A76FC File Offset: 0x000A58FC
		private bool ShouldSerializeisNew()
		{
			return this.isNewSpecified;
		}

		// Token: 0x060057E5 RID: 22501 RVA: 0x000A7714 File Offset: 0x000A5914
		private void ResetisNew()
		{
			this.isNewSpecified = false;
		}

		// Token: 0x17001B50 RID: 6992
		// (get) Token: 0x060057E6 RID: 22502 RVA: 0x000A7720 File Offset: 0x000A5920
		// (set) Token: 0x060057E7 RID: 22503 RVA: 0x000A774C File Offset: 0x000A594C
		[ProtoMember(3, IsRequired = false, Name = "reachTimestamp", DataFormat = DataFormat.TwosComplement)]
		public uint reachTimestamp
		{
			get
			{
				return this._reachTimestamp ?? 0U;
			}
			set
			{
				this._reachTimestamp = new uint?(value);
			}
		}

		// Token: 0x17001B51 RID: 6993
		// (get) Token: 0x060057E8 RID: 22504 RVA: 0x000A775C File Offset: 0x000A595C
		// (set) Token: 0x060057E9 RID: 22505 RVA: 0x000A777C File Offset: 0x000A597C
		[XmlIgnore]
		[Browsable(false)]
		public bool reachTimestampSpecified
		{
			get
			{
				return this._reachTimestamp != null;
			}
			set
			{
				bool flag = value == (this._reachTimestamp == null);
				if (flag)
				{
					this._reachTimestamp = (value ? new uint?(this.reachTimestamp) : null);
				}
			}
		}

		// Token: 0x060057EA RID: 22506 RVA: 0x000A77C0 File Offset: 0x000A59C0
		private bool ShouldSerializereachTimestamp()
		{
			return this.reachTimestampSpecified;
		}

		// Token: 0x060057EB RID: 22507 RVA: 0x000A77D8 File Offset: 0x000A59D8
		private void ResetreachTimestamp()
		{
			this.reachTimestampSpecified = false;
		}

		// Token: 0x17001B52 RID: 6994
		// (get) Token: 0x060057EC RID: 22508 RVA: 0x000A77E4 File Offset: 0x000A59E4
		// (set) Token: 0x060057ED RID: 22509 RVA: 0x000A7805 File Offset: 0x000A5A05
		[ProtoMember(4, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17001B53 RID: 6995
		// (get) Token: 0x060057EE RID: 22510 RVA: 0x000A7810 File Offset: 0x000A5A10
		// (set) Token: 0x060057EF RID: 22511 RVA: 0x000A782C File Offset: 0x000A5A2C
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x060057F0 RID: 22512 RVA: 0x000A785C File Offset: 0x000A5A5C
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060057F1 RID: 22513 RVA: 0x000A7874 File Offset: 0x000A5A74
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17001B54 RID: 6996
		// (get) Token: 0x060057F2 RID: 22514 RVA: 0x000A7880 File Offset: 0x000A5A80
		// (set) Token: 0x060057F3 RID: 22515 RVA: 0x000A78AC File Offset: 0x000A5AAC
		[ProtoMember(5, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x17001B55 RID: 6997
		// (get) Token: 0x060057F4 RID: 22516 RVA: 0x000A78BC File Offset: 0x000A5ABC
		// (set) Token: 0x060057F5 RID: 22517 RVA: 0x000A78DC File Offset: 0x000A5ADC
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x060057F6 RID: 22518 RVA: 0x000A7920 File Offset: 0x000A5B20
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060057F7 RID: 22519 RVA: 0x000A7938 File Offset: 0x000A5B38
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x060057F8 RID: 22520 RVA: 0x000A7944 File Offset: 0x000A5B44
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400154D RID: 5453
		private uint? _designationID;

		// Token: 0x0400154E RID: 5454
		private bool? _isNew;

		// Token: 0x0400154F RID: 5455
		private uint? _reachTimestamp;

		// Token: 0x04001550 RID: 5456
		private string _name;

		// Token: 0x04001551 RID: 5457
		private uint? _type;

		// Token: 0x04001552 RID: 5458
		private IExtension extensionObject;
	}
}
