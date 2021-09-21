using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000327 RID: 807
	[ProtoContract(Name = "InvFightPara")]
	[Serializable]
	public class InvFightPara : IExtensible
	{
		// Token: 0x17000DCC RID: 3532
		// (get) Token: 0x06002C80 RID: 11392 RVA: 0x0005630C File Offset: 0x0005450C
		// (set) Token: 0x06002C81 RID: 11393 RVA: 0x00056338 File Offset: 0x00054538
		[ProtoMember(1, IsRequired = false, Name = "ntftype", DataFormat = DataFormat.TwosComplement)]
		public InvFightNotifyType ntftype
		{
			get
			{
				return this._ntftype ?? InvFightNotifyType.IFNT_REFUSE_ME;
			}
			set
			{
				this._ntftype = new InvFightNotifyType?(value);
			}
		}

		// Token: 0x17000DCD RID: 3533
		// (get) Token: 0x06002C82 RID: 11394 RVA: 0x00056348 File Offset: 0x00054548
		// (set) Token: 0x06002C83 RID: 11395 RVA: 0x00056368 File Offset: 0x00054568
		[XmlIgnore]
		[Browsable(false)]
		public bool ntftypeSpecified
		{
			get
			{
				return this._ntftype != null;
			}
			set
			{
				bool flag = value == (this._ntftype == null);
				if (flag)
				{
					this._ntftype = (value ? new InvFightNotifyType?(this.ntftype) : null);
				}
			}
		}

		// Token: 0x06002C84 RID: 11396 RVA: 0x000563AC File Offset: 0x000545AC
		private bool ShouldSerializentftype()
		{
			return this.ntftypeSpecified;
		}

		// Token: 0x06002C85 RID: 11397 RVA: 0x000563C4 File Offset: 0x000545C4
		private void Resetntftype()
		{
			this.ntftypeSpecified = false;
		}

		// Token: 0x17000DCE RID: 3534
		// (get) Token: 0x06002C86 RID: 11398 RVA: 0x000563D0 File Offset: 0x000545D0
		// (set) Token: 0x06002C87 RID: 11399 RVA: 0x000563F1 File Offset: 0x000545F1
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x17000DCF RID: 3535
		// (get) Token: 0x06002C88 RID: 11400 RVA: 0x000563FC File Offset: 0x000545FC
		// (set) Token: 0x06002C89 RID: 11401 RVA: 0x00056418 File Offset: 0x00054618
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

		// Token: 0x06002C8A RID: 11402 RVA: 0x00056448 File Offset: 0x00054648
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06002C8B RID: 11403 RVA: 0x00056460 File Offset: 0x00054660
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17000DD0 RID: 3536
		// (get) Token: 0x06002C8C RID: 11404 RVA: 0x0005646C File Offset: 0x0005466C
		// (set) Token: 0x06002C8D RID: 11405 RVA: 0x00056498 File Offset: 0x00054698
		[ProtoMember(3, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x17000DD1 RID: 3537
		// (get) Token: 0x06002C8E RID: 11406 RVA: 0x000564A8 File Offset: 0x000546A8
		// (set) Token: 0x06002C8F RID: 11407 RVA: 0x000564C8 File Offset: 0x000546C8
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x06002C90 RID: 11408 RVA: 0x0005650C File Offset: 0x0005470C
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06002C91 RID: 11409 RVA: 0x00056524 File Offset: 0x00054724
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06002C92 RID: 11410 RVA: 0x00056530 File Offset: 0x00054730
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B03 RID: 2819
		private InvFightNotifyType? _ntftype;

		// Token: 0x04000B04 RID: 2820
		private string _name;

		// Token: 0x04000B05 RID: 2821
		private uint? _count;

		// Token: 0x04000B06 RID: 2822
		private IExtension extensionObject;
	}
}
