using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000594 RID: 1428
	[ProtoContract(Name = "RewardInfo")]
	[Serializable]
	public class RewardInfo : IExtensible
	{
		// Token: 0x17001766 RID: 5990
		// (get) Token: 0x06004C04 RID: 19460 RVA: 0x00090998 File Offset: 0x0008EB98
		// (set) Token: 0x06004C05 RID: 19461 RVA: 0x000909C5 File Offset: 0x0008EBC5
		[ProtoMember(1, IsRequired = false, Name = "UniqueId", DataFormat = DataFormat.TwosComplement)]
		public ulong UniqueId
		{
			get
			{
				return this._UniqueId ?? 0UL;
			}
			set
			{
				this._UniqueId = new ulong?(value);
			}
		}

		// Token: 0x17001767 RID: 5991
		// (get) Token: 0x06004C06 RID: 19462 RVA: 0x000909D4 File Offset: 0x0008EBD4
		// (set) Token: 0x06004C07 RID: 19463 RVA: 0x000909F4 File Offset: 0x0008EBF4
		[XmlIgnore]
		[Browsable(false)]
		public bool UniqueIdSpecified
		{
			get
			{
				return this._UniqueId != null;
			}
			set
			{
				bool flag = value == (this._UniqueId == null);
				if (flag)
				{
					this._UniqueId = (value ? new ulong?(this.UniqueId) : null);
				}
			}
		}

		// Token: 0x06004C08 RID: 19464 RVA: 0x00090A38 File Offset: 0x0008EC38
		private bool ShouldSerializeUniqueId()
		{
			return this.UniqueIdSpecified;
		}

		// Token: 0x06004C09 RID: 19465 RVA: 0x00090A50 File Offset: 0x0008EC50
		private void ResetUniqueId()
		{
			this.UniqueIdSpecified = false;
		}

		// Token: 0x17001768 RID: 5992
		// (get) Token: 0x06004C0A RID: 19466 RVA: 0x00090A5C File Offset: 0x0008EC5C
		// (set) Token: 0x06004C0B RID: 19467 RVA: 0x00090A88 File Offset: 0x0008EC88
		[ProtoMember(2, IsRequired = false, Name = "Type", DataFormat = DataFormat.TwosComplement)]
		public uint Type
		{
			get
			{
				return this._Type ?? 0U;
			}
			set
			{
				this._Type = new uint?(value);
			}
		}

		// Token: 0x17001769 RID: 5993
		// (get) Token: 0x06004C0C RID: 19468 RVA: 0x00090A98 File Offset: 0x0008EC98
		// (set) Token: 0x06004C0D RID: 19469 RVA: 0x00090AB8 File Offset: 0x0008ECB8
		[XmlIgnore]
		[Browsable(false)]
		public bool TypeSpecified
		{
			get
			{
				return this._Type != null;
			}
			set
			{
				bool flag = value == (this._Type == null);
				if (flag)
				{
					this._Type = (value ? new uint?(this.Type) : null);
				}
			}
		}

		// Token: 0x06004C0E RID: 19470 RVA: 0x00090AFC File Offset: 0x0008ECFC
		private bool ShouldSerializeType()
		{
			return this.TypeSpecified;
		}

		// Token: 0x06004C0F RID: 19471 RVA: 0x00090B14 File Offset: 0x0008ED14
		private void ResetType()
		{
			this.TypeSpecified = false;
		}

		// Token: 0x1700176A RID: 5994
		// (get) Token: 0x06004C10 RID: 19472 RVA: 0x00090B20 File Offset: 0x0008ED20
		// (set) Token: 0x06004C11 RID: 19473 RVA: 0x00090B4C File Offset: 0x0008ED4C
		[ProtoMember(3, IsRequired = false, Name = "SubType", DataFormat = DataFormat.TwosComplement)]
		public uint SubType
		{
			get
			{
				return this._SubType ?? 0U;
			}
			set
			{
				this._SubType = new uint?(value);
			}
		}

		// Token: 0x1700176B RID: 5995
		// (get) Token: 0x06004C12 RID: 19474 RVA: 0x00090B5C File Offset: 0x0008ED5C
		// (set) Token: 0x06004C13 RID: 19475 RVA: 0x00090B7C File Offset: 0x0008ED7C
		[XmlIgnore]
		[Browsable(false)]
		public bool SubTypeSpecified
		{
			get
			{
				return this._SubType != null;
			}
			set
			{
				bool flag = value == (this._SubType == null);
				if (flag)
				{
					this._SubType = (value ? new uint?(this.SubType) : null);
				}
			}
		}

		// Token: 0x06004C14 RID: 19476 RVA: 0x00090BC0 File Offset: 0x0008EDC0
		private bool ShouldSerializeSubType()
		{
			return this.SubTypeSpecified;
		}

		// Token: 0x06004C15 RID: 19477 RVA: 0x00090BD8 File Offset: 0x0008EDD8
		private void ResetSubType()
		{
			this.SubTypeSpecified = false;
		}

		// Token: 0x1700176C RID: 5996
		// (get) Token: 0x06004C16 RID: 19478 RVA: 0x00090BE4 File Offset: 0x0008EDE4
		// (set) Token: 0x06004C17 RID: 19479 RVA: 0x00090C10 File Offset: 0x0008EE10
		[ProtoMember(4, IsRequired = false, Name = "State", DataFormat = DataFormat.TwosComplement)]
		public uint State
		{
			get
			{
				return this._State ?? 0U;
			}
			set
			{
				this._State = new uint?(value);
			}
		}

		// Token: 0x1700176D RID: 5997
		// (get) Token: 0x06004C18 RID: 19480 RVA: 0x00090C20 File Offset: 0x0008EE20
		// (set) Token: 0x06004C19 RID: 19481 RVA: 0x00090C40 File Offset: 0x0008EE40
		[XmlIgnore]
		[Browsable(false)]
		public bool StateSpecified
		{
			get
			{
				return this._State != null;
			}
			set
			{
				bool flag = value == (this._State == null);
				if (flag)
				{
					this._State = (value ? new uint?(this.State) : null);
				}
			}
		}

		// Token: 0x06004C1A RID: 19482 RVA: 0x00090C84 File Offset: 0x0008EE84
		private bool ShouldSerializeState()
		{
			return this.StateSpecified;
		}

		// Token: 0x06004C1B RID: 19483 RVA: 0x00090C9C File Offset: 0x0008EE9C
		private void ResetState()
		{
			this.StateSpecified = false;
		}

		// Token: 0x1700176E RID: 5998
		// (get) Token: 0x06004C1C RID: 19484 RVA: 0x00090CA8 File Offset: 0x0008EEA8
		// (set) Token: 0x06004C1D RID: 19485 RVA: 0x00090CD4 File Offset: 0x0008EED4
		[ProtoMember(5, IsRequired = false, Name = "TimeStamp", DataFormat = DataFormat.TwosComplement)]
		public uint TimeStamp
		{
			get
			{
				return this._TimeStamp ?? 0U;
			}
			set
			{
				this._TimeStamp = new uint?(value);
			}
		}

		// Token: 0x1700176F RID: 5999
		// (get) Token: 0x06004C1E RID: 19486 RVA: 0x00090CE4 File Offset: 0x0008EEE4
		// (set) Token: 0x06004C1F RID: 19487 RVA: 0x00090D04 File Offset: 0x0008EF04
		[XmlIgnore]
		[Browsable(false)]
		public bool TimeStampSpecified
		{
			get
			{
				return this._TimeStamp != null;
			}
			set
			{
				bool flag = value == (this._TimeStamp == null);
				if (flag)
				{
					this._TimeStamp = (value ? new uint?(this.TimeStamp) : null);
				}
			}
		}

		// Token: 0x06004C20 RID: 19488 RVA: 0x00090D48 File Offset: 0x0008EF48
		private bool ShouldSerializeTimeStamp()
		{
			return this.TimeStampSpecified;
		}

		// Token: 0x06004C21 RID: 19489 RVA: 0x00090D60 File Offset: 0x0008EF60
		private void ResetTimeStamp()
		{
			this.TimeStampSpecified = false;
		}

		// Token: 0x17001770 RID: 6000
		// (get) Token: 0x06004C22 RID: 19490 RVA: 0x00090D6C File Offset: 0x0008EF6C
		[ProtoMember(6, Name = "Param", DataFormat = DataFormat.Default)]
		public List<string> Param
		{
			get
			{
				return this._Param;
			}
		}

		// Token: 0x17001771 RID: 6001
		// (get) Token: 0x06004C23 RID: 19491 RVA: 0x00090D84 File Offset: 0x0008EF84
		[ProtoMember(7, Name = "Item", DataFormat = DataFormat.Default)]
		public List<ItemBrief> Item
		{
			get
			{
				return this._Item;
			}
		}

		// Token: 0x17001772 RID: 6002
		// (get) Token: 0x06004C24 RID: 19492 RVA: 0x00090D9C File Offset: 0x0008EF9C
		// (set) Token: 0x06004C25 RID: 19493 RVA: 0x00090DBD File Offset: 0x0008EFBD
		[ProtoMember(8, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x17001773 RID: 6003
		// (get) Token: 0x06004C26 RID: 19494 RVA: 0x00090DC8 File Offset: 0x0008EFC8
		// (set) Token: 0x06004C27 RID: 19495 RVA: 0x00090DE4 File Offset: 0x0008EFE4
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

		// Token: 0x06004C28 RID: 19496 RVA: 0x00090E14 File Offset: 0x0008F014
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06004C29 RID: 19497 RVA: 0x00090E2C File Offset: 0x0008F02C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17001774 RID: 6004
		// (get) Token: 0x06004C2A RID: 19498 RVA: 0x00090E38 File Offset: 0x0008F038
		// (set) Token: 0x06004C2B RID: 19499 RVA: 0x00090E59 File Offset: 0x0008F059
		[ProtoMember(9, IsRequired = false, Name = "comment", DataFormat = DataFormat.Default)]
		public string comment
		{
			get
			{
				return this._comment ?? "";
			}
			set
			{
				this._comment = value;
			}
		}

		// Token: 0x17001775 RID: 6005
		// (get) Token: 0x06004C2C RID: 19500 RVA: 0x00090E64 File Offset: 0x0008F064
		// (set) Token: 0x06004C2D RID: 19501 RVA: 0x00090E80 File Offset: 0x0008F080
		[XmlIgnore]
		[Browsable(false)]
		public bool commentSpecified
		{
			get
			{
				return this._comment != null;
			}
			set
			{
				bool flag = value == (this._comment == null);
				if (flag)
				{
					this._comment = (value ? this.comment : null);
				}
			}
		}

		// Token: 0x06004C2E RID: 19502 RVA: 0x00090EB0 File Offset: 0x0008F0B0
		private bool ShouldSerializecomment()
		{
			return this.commentSpecified;
		}

		// Token: 0x06004C2F RID: 19503 RVA: 0x00090EC8 File Offset: 0x0008F0C8
		private void Resetcomment()
		{
			this.commentSpecified = false;
		}

		// Token: 0x17001776 RID: 6006
		// (get) Token: 0x06004C30 RID: 19504 RVA: 0x00090ED4 File Offset: 0x0008F0D4
		// (set) Token: 0x06004C31 RID: 19505 RVA: 0x00090F00 File Offset: 0x0008F100
		[ProtoMember(10, IsRequired = false, Name = "uniqueday", DataFormat = DataFormat.TwosComplement)]
		public uint uniqueday
		{
			get
			{
				return this._uniqueday ?? 0U;
			}
			set
			{
				this._uniqueday = new uint?(value);
			}
		}

		// Token: 0x17001777 RID: 6007
		// (get) Token: 0x06004C32 RID: 19506 RVA: 0x00090F10 File Offset: 0x0008F110
		// (set) Token: 0x06004C33 RID: 19507 RVA: 0x00090F30 File Offset: 0x0008F130
		[XmlIgnore]
		[Browsable(false)]
		public bool uniquedaySpecified
		{
			get
			{
				return this._uniqueday != null;
			}
			set
			{
				bool flag = value == (this._uniqueday == null);
				if (flag)
				{
					this._uniqueday = (value ? new uint?(this.uniqueday) : null);
				}
			}
		}

		// Token: 0x06004C34 RID: 19508 RVA: 0x00090F74 File Offset: 0x0008F174
		private bool ShouldSerializeuniqueday()
		{
			return this.uniquedaySpecified;
		}

		// Token: 0x06004C35 RID: 19509 RVA: 0x00090F8C File Offset: 0x0008F18C
		private void Resetuniqueday()
		{
			this.uniquedaySpecified = false;
		}

		// Token: 0x17001778 RID: 6008
		// (get) Token: 0x06004C36 RID: 19510 RVA: 0x00090F98 File Offset: 0x0008F198
		// (set) Token: 0x06004C37 RID: 19511 RVA: 0x00090FC4 File Offset: 0x0008F1C4
		[ProtoMember(11, IsRequired = false, Name = "isget", DataFormat = DataFormat.Default)]
		public bool isget
		{
			get
			{
				return this._isget ?? false;
			}
			set
			{
				this._isget = new bool?(value);
			}
		}

		// Token: 0x17001779 RID: 6009
		// (get) Token: 0x06004C38 RID: 19512 RVA: 0x00090FD4 File Offset: 0x0008F1D4
		// (set) Token: 0x06004C39 RID: 19513 RVA: 0x00090FF4 File Offset: 0x0008F1F4
		[XmlIgnore]
		[Browsable(false)]
		public bool isgetSpecified
		{
			get
			{
				return this._isget != null;
			}
			set
			{
				bool flag = value == (this._isget == null);
				if (flag)
				{
					this._isget = (value ? new bool?(this.isget) : null);
				}
			}
		}

		// Token: 0x06004C3A RID: 19514 RVA: 0x00091038 File Offset: 0x0008F238
		private bool ShouldSerializeisget()
		{
			return this.isgetSpecified;
		}

		// Token: 0x06004C3B RID: 19515 RVA: 0x00091050 File Offset: 0x0008F250
		private void Resetisget()
		{
			this.isgetSpecified = false;
		}

		// Token: 0x06004C3C RID: 19516 RVA: 0x0009105C File Offset: 0x0008F25C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012DE RID: 4830
		private ulong? _UniqueId;

		// Token: 0x040012DF RID: 4831
		private uint? _Type;

		// Token: 0x040012E0 RID: 4832
		private uint? _SubType;

		// Token: 0x040012E1 RID: 4833
		private uint? _State;

		// Token: 0x040012E2 RID: 4834
		private uint? _TimeStamp;

		// Token: 0x040012E3 RID: 4835
		private readonly List<string> _Param = new List<string>();

		// Token: 0x040012E4 RID: 4836
		private readonly List<ItemBrief> _Item = new List<ItemBrief>();

		// Token: 0x040012E5 RID: 4837
		private string _name;

		// Token: 0x040012E6 RID: 4838
		private string _comment;

		// Token: 0x040012E7 RID: 4839
		private uint? _uniqueday;

		// Token: 0x040012E8 RID: 4840
		private bool? _isget;

		// Token: 0x040012E9 RID: 4841
		private IExtension extensionObject;
	}
}
