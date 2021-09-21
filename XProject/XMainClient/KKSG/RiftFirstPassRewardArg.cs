using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000529 RID: 1321
	[ProtoContract(Name = "RiftFirstPassRewardArg")]
	[Serializable]
	public class RiftFirstPassRewardArg : IExtensible
	{
		// Token: 0x170014C2 RID: 5314
		// (get) Token: 0x060043E8 RID: 17384 RVA: 0x000812F8 File Offset: 0x0007F4F8
		// (set) Token: 0x060043E9 RID: 17385 RVA: 0x00081324 File Offset: 0x0007F524
		[ProtoMember(1, IsRequired = false, Name = "opType", DataFormat = DataFormat.TwosComplement)]
		public RiftFirstPassOpType opType
		{
			get
			{
				return this._opType ?? RiftFirstPassOpType.Rift_FirstPass_Op_GetInfo;
			}
			set
			{
				this._opType = new RiftFirstPassOpType?(value);
			}
		}

		// Token: 0x170014C3 RID: 5315
		// (get) Token: 0x060043EA RID: 17386 RVA: 0x00081334 File Offset: 0x0007F534
		// (set) Token: 0x060043EB RID: 17387 RVA: 0x00081354 File Offset: 0x0007F554
		[XmlIgnore]
		[Browsable(false)]
		public bool opTypeSpecified
		{
			get
			{
				return this._opType != null;
			}
			set
			{
				bool flag = value == (this._opType == null);
				if (flag)
				{
					this._opType = (value ? new RiftFirstPassOpType?(this.opType) : null);
				}
			}
		}

		// Token: 0x060043EC RID: 17388 RVA: 0x00081398 File Offset: 0x0007F598
		private bool ShouldSerializeopType()
		{
			return this.opTypeSpecified;
		}

		// Token: 0x060043ED RID: 17389 RVA: 0x000813B0 File Offset: 0x0007F5B0
		private void ResetopType()
		{
			this.opTypeSpecified = false;
		}

		// Token: 0x170014C4 RID: 5316
		// (get) Token: 0x060043EE RID: 17390 RVA: 0x000813BC File Offset: 0x0007F5BC
		// (set) Token: 0x060043EF RID: 17391 RVA: 0x000813E8 File Offset: 0x0007F5E8
		[ProtoMember(2, IsRequired = false, Name = "floor", DataFormat = DataFormat.TwosComplement)]
		public uint floor
		{
			get
			{
				return this._floor ?? 0U;
			}
			set
			{
				this._floor = new uint?(value);
			}
		}

		// Token: 0x170014C5 RID: 5317
		// (get) Token: 0x060043F0 RID: 17392 RVA: 0x000813F8 File Offset: 0x0007F5F8
		// (set) Token: 0x060043F1 RID: 17393 RVA: 0x00081418 File Offset: 0x0007F618
		[XmlIgnore]
		[Browsable(false)]
		public bool floorSpecified
		{
			get
			{
				return this._floor != null;
			}
			set
			{
				bool flag = value == (this._floor == null);
				if (flag)
				{
					this._floor = (value ? new uint?(this.floor) : null);
				}
			}
		}

		// Token: 0x060043F2 RID: 17394 RVA: 0x0008145C File Offset: 0x0007F65C
		private bool ShouldSerializefloor()
		{
			return this.floorSpecified;
		}

		// Token: 0x060043F3 RID: 17395 RVA: 0x00081474 File Offset: 0x0007F674
		private void Resetfloor()
		{
			this.floorSpecified = false;
		}

		// Token: 0x060043F4 RID: 17396 RVA: 0x00081480 File Offset: 0x0007F680
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010EF RID: 4335
		private RiftFirstPassOpType? _opType;

		// Token: 0x040010F0 RID: 4336
		private uint? _floor;

		// Token: 0x040010F1 RID: 4337
		private IExtension extensionObject;
	}
}
