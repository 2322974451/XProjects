using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000565 RID: 1381
	[ProtoContract(Name = "ItemJadeSingle")]
	[Serializable]
	public class ItemJadeSingle : IExtensible
	{
		// Token: 0x170015BA RID: 5562
		// (get) Token: 0x06004708 RID: 18184 RVA: 0x00086F58 File Offset: 0x00085158
		// (set) Token: 0x06004709 RID: 18185 RVA: 0x00086F84 File Offset: 0x00085184
		[ProtoMember(1, IsRequired = false, Name = "SlotPos", DataFormat = DataFormat.TwosComplement)]
		public uint SlotPos
		{
			get
			{
				return this._SlotPos ?? 0U;
			}
			set
			{
				this._SlotPos = new uint?(value);
			}
		}

		// Token: 0x170015BB RID: 5563
		// (get) Token: 0x0600470A RID: 18186 RVA: 0x00086F94 File Offset: 0x00085194
		// (set) Token: 0x0600470B RID: 18187 RVA: 0x00086FB4 File Offset: 0x000851B4
		[XmlIgnore]
		[Browsable(false)]
		public bool SlotPosSpecified
		{
			get
			{
				return this._SlotPos != null;
			}
			set
			{
				bool flag = value == (this._SlotPos == null);
				if (flag)
				{
					this._SlotPos = (value ? new uint?(this.SlotPos) : null);
				}
			}
		}

		// Token: 0x0600470C RID: 18188 RVA: 0x00086FF8 File Offset: 0x000851F8
		private bool ShouldSerializeSlotPos()
		{
			return this.SlotPosSpecified;
		}

		// Token: 0x0600470D RID: 18189 RVA: 0x00087010 File Offset: 0x00085210
		private void ResetSlotPos()
		{
			this.SlotPosSpecified = false;
		}

		// Token: 0x170015BC RID: 5564
		// (get) Token: 0x0600470E RID: 18190 RVA: 0x0008701C File Offset: 0x0008521C
		// (set) Token: 0x0600470F RID: 18191 RVA: 0x00087048 File Offset: 0x00085248
		[ProtoMember(2, IsRequired = false, Name = "ItemId", DataFormat = DataFormat.TwosComplement)]
		public uint ItemId
		{
			get
			{
				return this._ItemId ?? 0U;
			}
			set
			{
				this._ItemId = new uint?(value);
			}
		}

		// Token: 0x170015BD RID: 5565
		// (get) Token: 0x06004710 RID: 18192 RVA: 0x00087058 File Offset: 0x00085258
		// (set) Token: 0x06004711 RID: 18193 RVA: 0x00087078 File Offset: 0x00085278
		[XmlIgnore]
		[Browsable(false)]
		public bool ItemIdSpecified
		{
			get
			{
				return this._ItemId != null;
			}
			set
			{
				bool flag = value == (this._ItemId == null);
				if (flag)
				{
					this._ItemId = (value ? new uint?(this.ItemId) : null);
				}
			}
		}

		// Token: 0x06004712 RID: 18194 RVA: 0x000870BC File Offset: 0x000852BC
		private bool ShouldSerializeItemId()
		{
			return this.ItemIdSpecified;
		}

		// Token: 0x06004713 RID: 18195 RVA: 0x000870D4 File Offset: 0x000852D4
		private void ResetItemId()
		{
			this.ItemIdSpecified = false;
		}

		// Token: 0x170015BE RID: 5566
		// (get) Token: 0x06004714 RID: 18196 RVA: 0x000870E0 File Offset: 0x000852E0
		[ProtoMember(3, Name = "AttrId", DataFormat = DataFormat.TwosComplement)]
		public List<uint> AttrId
		{
			get
			{
				return this._AttrId;
			}
		}

		// Token: 0x170015BF RID: 5567
		// (get) Token: 0x06004715 RID: 18197 RVA: 0x000870F8 File Offset: 0x000852F8
		[ProtoMember(4, Name = "AttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<uint> AttrValue
		{
			get
			{
				return this._AttrValue;
			}
		}

		// Token: 0x06004716 RID: 18198 RVA: 0x00087110 File Offset: 0x00085310
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011BA RID: 4538
		private uint? _SlotPos;

		// Token: 0x040011BB RID: 4539
		private uint? _ItemId;

		// Token: 0x040011BC RID: 4540
		private readonly List<uint> _AttrId = new List<uint>();

		// Token: 0x040011BD RID: 4541
		private readonly List<uint> _AttrValue = new List<uint>();

		// Token: 0x040011BE RID: 4542
		private IExtension extensionObject;
	}
}
