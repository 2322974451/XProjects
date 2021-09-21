using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000168 RID: 360
	[ProtoContract(Name = "ReceiveFlowerData")]
	[Serializable]
	public class ReceiveFlowerData : IExtensible
	{
		// Token: 0x170006E2 RID: 1762
		// (get) Token: 0x060015AE RID: 5550 RVA: 0x0002B850 File Offset: 0x00029A50
		// (set) Token: 0x060015AF RID: 5551 RVA: 0x0002B87C File Offset: 0x00029A7C
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

		// Token: 0x170006E3 RID: 1763
		// (get) Token: 0x060015B0 RID: 5552 RVA: 0x0002B88C File Offset: 0x00029A8C
		// (set) Token: 0x060015B1 RID: 5553 RVA: 0x0002B8AC File Offset: 0x00029AAC
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

		// Token: 0x060015B2 RID: 5554 RVA: 0x0002B8F0 File Offset: 0x00029AF0
		private bool ShouldSerializeitemID()
		{
			return this.itemIDSpecified;
		}

		// Token: 0x060015B3 RID: 5555 RVA: 0x0002B908 File Offset: 0x00029B08
		private void ResetitemID()
		{
			this.itemIDSpecified = false;
		}

		// Token: 0x170006E4 RID: 1764
		// (get) Token: 0x060015B4 RID: 5556 RVA: 0x0002B914 File Offset: 0x00029B14
		// (set) Token: 0x060015B5 RID: 5557 RVA: 0x0002B940 File Offset: 0x00029B40
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

		// Token: 0x170006E5 RID: 1765
		// (get) Token: 0x060015B6 RID: 5558 RVA: 0x0002B950 File Offset: 0x00029B50
		// (set) Token: 0x060015B7 RID: 5559 RVA: 0x0002B970 File Offset: 0x00029B70
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

		// Token: 0x060015B8 RID: 5560 RVA: 0x0002B9B4 File Offset: 0x00029BB4
		private bool ShouldSerializeitemCount()
		{
			return this.itemCountSpecified;
		}

		// Token: 0x060015B9 RID: 5561 RVA: 0x0002B9CC File Offset: 0x00029BCC
		private void ResetitemCount()
		{
			this.itemCountSpecified = false;
		}

		// Token: 0x170006E6 RID: 1766
		// (get) Token: 0x060015BA RID: 5562 RVA: 0x0002B9D8 File Offset: 0x00029BD8
		// (set) Token: 0x060015BB RID: 5563 RVA: 0x0002BA05 File Offset: 0x00029C05
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

		// Token: 0x170006E7 RID: 1767
		// (get) Token: 0x060015BC RID: 5564 RVA: 0x0002BA14 File Offset: 0x00029C14
		// (set) Token: 0x060015BD RID: 5565 RVA: 0x0002BA34 File Offset: 0x00029C34
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

		// Token: 0x060015BE RID: 5566 RVA: 0x0002BA78 File Offset: 0x00029C78
		private bool ShouldSerializesendRoleID()
		{
			return this.sendRoleIDSpecified;
		}

		// Token: 0x060015BF RID: 5567 RVA: 0x0002BA90 File Offset: 0x00029C90
		private void ResetsendRoleID()
		{
			this.sendRoleIDSpecified = false;
		}

		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x060015C0 RID: 5568 RVA: 0x0002BA9C File Offset: 0x00029C9C
		// (set) Token: 0x060015C1 RID: 5569 RVA: 0x0002BABD File Offset: 0x00029CBD
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

		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x060015C2 RID: 5570 RVA: 0x0002BAC8 File Offset: 0x00029CC8
		// (set) Token: 0x060015C3 RID: 5571 RVA: 0x0002BAE4 File Offset: 0x00029CE4
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

		// Token: 0x060015C4 RID: 5572 RVA: 0x0002BB14 File Offset: 0x00029D14
		private bool ShouldSerializesendName()
		{
			return this.sendNameSpecified;
		}

		// Token: 0x060015C5 RID: 5573 RVA: 0x0002BB2C File Offset: 0x00029D2C
		private void ResetsendName()
		{
			this.sendNameSpecified = false;
		}

		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x060015C6 RID: 5574 RVA: 0x0002BB38 File Offset: 0x00029D38
		// (set) Token: 0x060015C7 RID: 5575 RVA: 0x0002BB64 File Offset: 0x00029D64
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

		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x060015C8 RID: 5576 RVA: 0x0002BB74 File Offset: 0x00029D74
		// (set) Token: 0x060015C9 RID: 5577 RVA: 0x0002BB94 File Offset: 0x00029D94
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

		// Token: 0x060015CA RID: 5578 RVA: 0x0002BBD8 File Offset: 0x00029DD8
		private bool ShouldSerializepower()
		{
			return this.powerSpecified;
		}

		// Token: 0x060015CB RID: 5579 RVA: 0x0002BBF0 File Offset: 0x00029DF0
		private void Resetpower()
		{
			this.powerSpecified = false;
		}

		// Token: 0x170006EC RID: 1772
		// (get) Token: 0x060015CC RID: 5580 RVA: 0x0002BBFC File Offset: 0x00029DFC
		// (set) Token: 0x060015CD RID: 5581 RVA: 0x0002BC28 File Offset: 0x00029E28
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

		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x060015CE RID: 5582 RVA: 0x0002BC38 File Offset: 0x00029E38
		// (set) Token: 0x060015CF RID: 5583 RVA: 0x0002BC58 File Offset: 0x00029E58
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

		// Token: 0x060015D0 RID: 5584 RVA: 0x0002BC9C File Offset: 0x00029E9C
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x060015D1 RID: 5585 RVA: 0x0002BCB4 File Offset: 0x00029EB4
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x170006EE RID: 1774
		// (get) Token: 0x060015D2 RID: 5586 RVA: 0x0002BCC0 File Offset: 0x00029EC0
		// (set) Token: 0x060015D3 RID: 5587 RVA: 0x0002BCEC File Offset: 0x00029EEC
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

		// Token: 0x170006EF RID: 1775
		// (get) Token: 0x060015D4 RID: 5588 RVA: 0x0002BCFC File Offset: 0x00029EFC
		// (set) Token: 0x060015D5 RID: 5589 RVA: 0x0002BD1C File Offset: 0x00029F1C
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

		// Token: 0x060015D6 RID: 5590 RVA: 0x0002BD60 File Offset: 0x00029F60
		private bool ShouldSerializevip()
		{
			return this.vipSpecified;
		}

		// Token: 0x060015D7 RID: 5591 RVA: 0x0002BD78 File Offset: 0x00029F78
		private void Resetvip()
		{
			this.vipSpecified = false;
		}

		// Token: 0x060015D8 RID: 5592 RVA: 0x0002BD84 File Offset: 0x00029F84
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000566 RID: 1382
		private int? _itemID;

		// Token: 0x04000567 RID: 1383
		private int? _itemCount;

		// Token: 0x04000568 RID: 1384
		private ulong? _sendRoleID;

		// Token: 0x04000569 RID: 1385
		private string _sendName;

		// Token: 0x0400056A RID: 1386
		private int? _power;

		// Token: 0x0400056B RID: 1387
		private int? _profession;

		// Token: 0x0400056C RID: 1388
		private int? _vip;

		// Token: 0x0400056D RID: 1389
		private IExtension extensionObject;
	}
}
