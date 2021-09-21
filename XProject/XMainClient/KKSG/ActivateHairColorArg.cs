using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200042B RID: 1067
	[ProtoContract(Name = "ActivateHairColorArg")]
	[Serializable]
	public class ActivateHairColorArg : IExtensible
	{
		// Token: 0x1700115C RID: 4444
		// (get) Token: 0x06003883 RID: 14467 RVA: 0x0006C29C File Offset: 0x0006A49C
		// (set) Token: 0x06003884 RID: 14468 RVA: 0x0006C2C8 File Offset: 0x0006A4C8
		[ProtoMember(1, IsRequired = false, Name = "hair_id", DataFormat = DataFormat.TwosComplement)]
		public uint hair_id
		{
			get
			{
				return this._hair_id ?? 0U;
			}
			set
			{
				this._hair_id = new uint?(value);
			}
		}

		// Token: 0x1700115D RID: 4445
		// (get) Token: 0x06003885 RID: 14469 RVA: 0x0006C2D8 File Offset: 0x0006A4D8
		// (set) Token: 0x06003886 RID: 14470 RVA: 0x0006C2F8 File Offset: 0x0006A4F8
		[XmlIgnore]
		[Browsable(false)]
		public bool hair_idSpecified
		{
			get
			{
				return this._hair_id != null;
			}
			set
			{
				bool flag = value == (this._hair_id == null);
				if (flag)
				{
					this._hair_id = (value ? new uint?(this.hair_id) : null);
				}
			}
		}

		// Token: 0x06003887 RID: 14471 RVA: 0x0006C33C File Offset: 0x0006A53C
		private bool ShouldSerializehair_id()
		{
			return this.hair_idSpecified;
		}

		// Token: 0x06003888 RID: 14472 RVA: 0x0006C354 File Offset: 0x0006A554
		private void Resethair_id()
		{
			this.hair_idSpecified = false;
		}

		// Token: 0x1700115E RID: 4446
		// (get) Token: 0x06003889 RID: 14473 RVA: 0x0006C360 File Offset: 0x0006A560
		// (set) Token: 0x0600388A RID: 14474 RVA: 0x0006C38C File Offset: 0x0006A58C
		[ProtoMember(2, IsRequired = false, Name = "hair_color_id", DataFormat = DataFormat.TwosComplement)]
		public uint hair_color_id
		{
			get
			{
				return this._hair_color_id ?? 0U;
			}
			set
			{
				this._hair_color_id = new uint?(value);
			}
		}

		// Token: 0x1700115F RID: 4447
		// (get) Token: 0x0600388B RID: 14475 RVA: 0x0006C39C File Offset: 0x0006A59C
		// (set) Token: 0x0600388C RID: 14476 RVA: 0x0006C3BC File Offset: 0x0006A5BC
		[XmlIgnore]
		[Browsable(false)]
		public bool hair_color_idSpecified
		{
			get
			{
				return this._hair_color_id != null;
			}
			set
			{
				bool flag = value == (this._hair_color_id == null);
				if (flag)
				{
					this._hair_color_id = (value ? new uint?(this.hair_color_id) : null);
				}
			}
		}

		// Token: 0x0600388D RID: 14477 RVA: 0x0006C400 File Offset: 0x0006A600
		private bool ShouldSerializehair_color_id()
		{
			return this.hair_color_idSpecified;
		}

		// Token: 0x0600388E RID: 14478 RVA: 0x0006C418 File Offset: 0x0006A618
		private void Resethair_color_id()
		{
			this.hair_color_idSpecified = false;
		}

		// Token: 0x0600388F RID: 14479 RVA: 0x0006C424 File Offset: 0x0006A624
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E05 RID: 3589
		private uint? _hair_id;

		// Token: 0x04000E06 RID: 3590
		private uint? _hair_color_id;

		// Token: 0x04000E07 RID: 3591
		private IExtension extensionObject;
	}
}
