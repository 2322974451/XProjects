using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000688 RID: 1672
	[ProtoContract(Name = "PvpNowUnitData")]
	[Serializable]
	public class PvpNowUnitData : IExtensible
	{
		// Token: 0x17002212 RID: 8722
		// (get) Token: 0x06006BA5 RID: 27557 RVA: 0x000CDE98 File Offset: 0x000CC098
		// (set) Token: 0x06006BA6 RID: 27558 RVA: 0x000CDEC5 File Offset: 0x000CC0C5
		[ProtoMember(1, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x17002213 RID: 8723
		// (get) Token: 0x06006BA7 RID: 27559 RVA: 0x000CDED4 File Offset: 0x000CC0D4
		// (set) Token: 0x06006BA8 RID: 27560 RVA: 0x000CDEF4 File Offset: 0x000CC0F4
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x06006BA9 RID: 27561 RVA: 0x000CDF38 File Offset: 0x000CC138
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06006BAA RID: 27562 RVA: 0x000CDF50 File Offset: 0x000CC150
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x17002214 RID: 8724
		// (get) Token: 0x06006BAB RID: 27563 RVA: 0x000CDF5C File Offset: 0x000CC15C
		// (set) Token: 0x06006BAC RID: 27564 RVA: 0x000CDF7D File Offset: 0x000CC17D
		[ProtoMember(2, IsRequired = false, Name = "roleName", DataFormat = DataFormat.Default)]
		public string roleName
		{
			get
			{
				return this._roleName ?? "";
			}
			set
			{
				this._roleName = value;
			}
		}

		// Token: 0x17002215 RID: 8725
		// (get) Token: 0x06006BAD RID: 27565 RVA: 0x000CDF88 File Offset: 0x000CC188
		// (set) Token: 0x06006BAE RID: 27566 RVA: 0x000CDFA4 File Offset: 0x000CC1A4
		[XmlIgnore]
		[Browsable(false)]
		public bool roleNameSpecified
		{
			get
			{
				return this._roleName != null;
			}
			set
			{
				bool flag = value == (this._roleName == null);
				if (flag)
				{
					this._roleName = (value ? this.roleName : null);
				}
			}
		}

		// Token: 0x06006BAF RID: 27567 RVA: 0x000CDFD4 File Offset: 0x000CC1D4
		private bool ShouldSerializeroleName()
		{
			return this.roleNameSpecified;
		}

		// Token: 0x06006BB0 RID: 27568 RVA: 0x000CDFEC File Offset: 0x000CC1EC
		private void ResetroleName()
		{
			this.roleNameSpecified = false;
		}

		// Token: 0x17002216 RID: 8726
		// (get) Token: 0x06006BB1 RID: 27569 RVA: 0x000CDFF8 File Offset: 0x000CC1F8
		// (set) Token: 0x06006BB2 RID: 27570 RVA: 0x000CE024 File Offset: 0x000CC224
		[ProtoMember(3, IsRequired = false, Name = "roleLevel", DataFormat = DataFormat.TwosComplement)]
		public uint roleLevel
		{
			get
			{
				return this._roleLevel ?? 0U;
			}
			set
			{
				this._roleLevel = new uint?(value);
			}
		}

		// Token: 0x17002217 RID: 8727
		// (get) Token: 0x06006BB3 RID: 27571 RVA: 0x000CE034 File Offset: 0x000CC234
		// (set) Token: 0x06006BB4 RID: 27572 RVA: 0x000CE054 File Offset: 0x000CC254
		[XmlIgnore]
		[Browsable(false)]
		public bool roleLevelSpecified
		{
			get
			{
				return this._roleLevel != null;
			}
			set
			{
				bool flag = value == (this._roleLevel == null);
				if (flag)
				{
					this._roleLevel = (value ? new uint?(this.roleLevel) : null);
				}
			}
		}

		// Token: 0x06006BB5 RID: 27573 RVA: 0x000CE098 File Offset: 0x000CC298
		private bool ShouldSerializeroleLevel()
		{
			return this.roleLevelSpecified;
		}

		// Token: 0x06006BB6 RID: 27574 RVA: 0x000CE0B0 File Offset: 0x000CC2B0
		private void ResetroleLevel()
		{
			this.roleLevelSpecified = false;
		}

		// Token: 0x17002218 RID: 8728
		// (get) Token: 0x06006BB7 RID: 27575 RVA: 0x000CE0BC File Offset: 0x000CC2BC
		// (set) Token: 0x06006BB8 RID: 27576 RVA: 0x000CE0E8 File Offset: 0x000CC2E8
		[ProtoMember(4, IsRequired = false, Name = "roleProfession", DataFormat = DataFormat.TwosComplement)]
		public uint roleProfession
		{
			get
			{
				return this._roleProfession ?? 0U;
			}
			set
			{
				this._roleProfession = new uint?(value);
			}
		}

		// Token: 0x17002219 RID: 8729
		// (get) Token: 0x06006BB9 RID: 27577 RVA: 0x000CE0F8 File Offset: 0x000CC2F8
		// (set) Token: 0x06006BBA RID: 27578 RVA: 0x000CE118 File Offset: 0x000CC318
		[XmlIgnore]
		[Browsable(false)]
		public bool roleProfessionSpecified
		{
			get
			{
				return this._roleProfession != null;
			}
			set
			{
				bool flag = value == (this._roleProfession == null);
				if (flag)
				{
					this._roleProfession = (value ? new uint?(this.roleProfession) : null);
				}
			}
		}

		// Token: 0x06006BBB RID: 27579 RVA: 0x000CE15C File Offset: 0x000CC35C
		private bool ShouldSerializeroleProfession()
		{
			return this.roleProfessionSpecified;
		}

		// Token: 0x06006BBC RID: 27580 RVA: 0x000CE174 File Offset: 0x000CC374
		private void ResetroleProfession()
		{
			this.roleProfessionSpecified = false;
		}

		// Token: 0x1700221A RID: 8730
		// (get) Token: 0x06006BBD RID: 27581 RVA: 0x000CE180 File Offset: 0x000CC380
		// (set) Token: 0x06006BBE RID: 27582 RVA: 0x000CE1AC File Offset: 0x000CC3AC
		[ProtoMember(5, IsRequired = false, Name = "killCount", DataFormat = DataFormat.TwosComplement)]
		public int killCount
		{
			get
			{
				return this._killCount ?? 0;
			}
			set
			{
				this._killCount = new int?(value);
			}
		}

		// Token: 0x1700221B RID: 8731
		// (get) Token: 0x06006BBF RID: 27583 RVA: 0x000CE1BC File Offset: 0x000CC3BC
		// (set) Token: 0x06006BC0 RID: 27584 RVA: 0x000CE1DC File Offset: 0x000CC3DC
		[XmlIgnore]
		[Browsable(false)]
		public bool killCountSpecified
		{
			get
			{
				return this._killCount != null;
			}
			set
			{
				bool flag = value == (this._killCount == null);
				if (flag)
				{
					this._killCount = (value ? new int?(this.killCount) : null);
				}
			}
		}

		// Token: 0x06006BC1 RID: 27585 RVA: 0x000CE220 File Offset: 0x000CC420
		private bool ShouldSerializekillCount()
		{
			return this.killCountSpecified;
		}

		// Token: 0x06006BC2 RID: 27586 RVA: 0x000CE238 File Offset: 0x000CC438
		private void ResetkillCount()
		{
			this.killCountSpecified = false;
		}

		// Token: 0x1700221C RID: 8732
		// (get) Token: 0x06006BC3 RID: 27587 RVA: 0x000CE244 File Offset: 0x000CC444
		// (set) Token: 0x06006BC4 RID: 27588 RVA: 0x000CE270 File Offset: 0x000CC470
		[ProtoMember(6, IsRequired = false, Name = "dieCount", DataFormat = DataFormat.TwosComplement)]
		public int dieCount
		{
			get
			{
				return this._dieCount ?? 0;
			}
			set
			{
				this._dieCount = new int?(value);
			}
		}

		// Token: 0x1700221D RID: 8733
		// (get) Token: 0x06006BC5 RID: 27589 RVA: 0x000CE280 File Offset: 0x000CC480
		// (set) Token: 0x06006BC6 RID: 27590 RVA: 0x000CE2A0 File Offset: 0x000CC4A0
		[XmlIgnore]
		[Browsable(false)]
		public bool dieCountSpecified
		{
			get
			{
				return this._dieCount != null;
			}
			set
			{
				bool flag = value == (this._dieCount == null);
				if (flag)
				{
					this._dieCount = (value ? new int?(this.dieCount) : null);
				}
			}
		}

		// Token: 0x06006BC7 RID: 27591 RVA: 0x000CE2E4 File Offset: 0x000CC4E4
		private bool ShouldSerializedieCount()
		{
			return this.dieCountSpecified;
		}

		// Token: 0x06006BC8 RID: 27592 RVA: 0x000CE2FC File Offset: 0x000CC4FC
		private void ResetdieCount()
		{
			this.dieCountSpecified = false;
		}

		// Token: 0x1700221E RID: 8734
		// (get) Token: 0x06006BC9 RID: 27593 RVA: 0x000CE308 File Offset: 0x000CC508
		// (set) Token: 0x06006BCA RID: 27594 RVA: 0x000CE334 File Offset: 0x000CC534
		[ProtoMember(7, IsRequired = false, Name = "groupid", DataFormat = DataFormat.TwosComplement)]
		public int groupid
		{
			get
			{
				return this._groupid ?? 0;
			}
			set
			{
				this._groupid = new int?(value);
			}
		}

		// Token: 0x1700221F RID: 8735
		// (get) Token: 0x06006BCB RID: 27595 RVA: 0x000CE344 File Offset: 0x000CC544
		// (set) Token: 0x06006BCC RID: 27596 RVA: 0x000CE364 File Offset: 0x000CC564
		[XmlIgnore]
		[Browsable(false)]
		public bool groupidSpecified
		{
			get
			{
				return this._groupid != null;
			}
			set
			{
				bool flag = value == (this._groupid == null);
				if (flag)
				{
					this._groupid = (value ? new int?(this.groupid) : null);
				}
			}
		}

		// Token: 0x06006BCD RID: 27597 RVA: 0x000CE3A8 File Offset: 0x000CC5A8
		private bool ShouldSerializegroupid()
		{
			return this.groupidSpecified;
		}

		// Token: 0x06006BCE RID: 27598 RVA: 0x000CE3C0 File Offset: 0x000CC5C0
		private void Resetgroupid()
		{
			this.groupidSpecified = false;
		}

		// Token: 0x06006BCF RID: 27599 RVA: 0x000CE3CC File Offset: 0x000CC5CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019E2 RID: 6626
		private ulong? _roleID;

		// Token: 0x040019E3 RID: 6627
		private string _roleName;

		// Token: 0x040019E4 RID: 6628
		private uint? _roleLevel;

		// Token: 0x040019E5 RID: 6629
		private uint? _roleProfession;

		// Token: 0x040019E6 RID: 6630
		private int? _killCount;

		// Token: 0x040019E7 RID: 6631
		private int? _dieCount;

		// Token: 0x040019E8 RID: 6632
		private int? _groupid;

		// Token: 0x040019E9 RID: 6633
		private IExtension extensionObject;
	}
}
