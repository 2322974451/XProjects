using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200055B RID: 1371
	[ProtoContract(Name = "Get520FestivalRedPacket")]
	[Serializable]
	public class Get520FestivalRedPacket : IExtensible
	{
		// Token: 0x17001568 RID: 5480
		// (get) Token: 0x0600461B RID: 17947 RVA: 0x000852D0 File Offset: 0x000834D0
		// (set) Token: 0x0600461C RID: 17948 RVA: 0x000852FC File Offset: 0x000834FC
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001569 RID: 5481
		// (get) Token: 0x0600461D RID: 17949 RVA: 0x0008530C File Offset: 0x0008350C
		// (set) Token: 0x0600461E RID: 17950 RVA: 0x0008532C File Offset: 0x0008352C
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

		// Token: 0x0600461F RID: 17951 RVA: 0x00085370 File Offset: 0x00083570
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06004620 RID: 17952 RVA: 0x00085388 File Offset: 0x00083588
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x1700156A RID: 5482
		// (get) Token: 0x06004621 RID: 17953 RVA: 0x00085394 File Offset: 0x00083594
		// (set) Token: 0x06004622 RID: 17954 RVA: 0x000853C0 File Offset: 0x000835C0
		[ProtoMember(2, IsRequired = false, Name = "num", DataFormat = DataFormat.TwosComplement)]
		public uint num
		{
			get
			{
				return this._num ?? 0U;
			}
			set
			{
				this._num = new uint?(value);
			}
		}

		// Token: 0x1700156B RID: 5483
		// (get) Token: 0x06004623 RID: 17955 RVA: 0x000853D0 File Offset: 0x000835D0
		// (set) Token: 0x06004624 RID: 17956 RVA: 0x000853F0 File Offset: 0x000835F0
		[XmlIgnore]
		[Browsable(false)]
		public bool numSpecified
		{
			get
			{
				return this._num != null;
			}
			set
			{
				bool flag = value == (this._num == null);
				if (flag)
				{
					this._num = (value ? new uint?(this.num) : null);
				}
			}
		}

		// Token: 0x06004625 RID: 17957 RVA: 0x00085434 File Offset: 0x00083634
		private bool ShouldSerializenum()
		{
			return this.numSpecified;
		}

		// Token: 0x06004626 RID: 17958 RVA: 0x0008544C File Offset: 0x0008364C
		private void Resetnum()
		{
			this.numSpecified = false;
		}

		// Token: 0x1700156C RID: 5484
		// (get) Token: 0x06004627 RID: 17959 RVA: 0x00085458 File Offset: 0x00083658
		// (set) Token: 0x06004628 RID: 17960 RVA: 0x00085479 File Offset: 0x00083679
		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x1700156D RID: 5485
		// (get) Token: 0x06004629 RID: 17961 RVA: 0x00085484 File Offset: 0x00083684
		// (set) Token: 0x0600462A RID: 17962 RVA: 0x000854A0 File Offset: 0x000836A0
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

		// Token: 0x0600462B RID: 17963 RVA: 0x000854D0 File Offset: 0x000836D0
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x0600462C RID: 17964 RVA: 0x000854E8 File Offset: 0x000836E8
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x1700156E RID: 5486
		// (get) Token: 0x0600462D RID: 17965 RVA: 0x000854F4 File Offset: 0x000836F4
		// (set) Token: 0x0600462E RID: 17966 RVA: 0x00085515 File Offset: 0x00083715
		[ProtoMember(4, IsRequired = false, Name = "headpic", DataFormat = DataFormat.Default)]
		public string headpic
		{
			get
			{
				return this._headpic ?? "";
			}
			set
			{
				this._headpic = value;
			}
		}

		// Token: 0x1700156F RID: 5487
		// (get) Token: 0x0600462F RID: 17967 RVA: 0x00085520 File Offset: 0x00083720
		// (set) Token: 0x06004630 RID: 17968 RVA: 0x0008553C File Offset: 0x0008373C
		[XmlIgnore]
		[Browsable(false)]
		public bool headpicSpecified
		{
			get
			{
				return this._headpic != null;
			}
			set
			{
				bool flag = value == (this._headpic == null);
				if (flag)
				{
					this._headpic = (value ? this.headpic : null);
				}
			}
		}

		// Token: 0x06004631 RID: 17969 RVA: 0x0008556C File Offset: 0x0008376C
		private bool ShouldSerializeheadpic()
		{
			return this.headpicSpecified;
		}

		// Token: 0x06004632 RID: 17970 RVA: 0x00085584 File Offset: 0x00083784
		private void Resetheadpic()
		{
			this.headpicSpecified = false;
		}

		// Token: 0x06004633 RID: 17971 RVA: 0x00085590 File Offset: 0x00083790
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400117E RID: 4478
		private uint? _type;

		// Token: 0x0400117F RID: 4479
		private uint? _num;

		// Token: 0x04001180 RID: 4480
		private string _name;

		// Token: 0x04001181 RID: 4481
		private string _headpic;

		// Token: 0x04001182 RID: 4482
		private IExtension extensionObject;
	}
}
