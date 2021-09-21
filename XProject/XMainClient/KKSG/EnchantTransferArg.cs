using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200039D RID: 925
	[ProtoContract(Name = "EnchantTransferArg")]
	[Serializable]
	public class EnchantTransferArg : IExtensible
	{
		// Token: 0x17000F70 RID: 3952
		// (get) Token: 0x060031F9 RID: 12793 RVA: 0x000603A8 File Offset: 0x0005E5A8
		// (set) Token: 0x060031FA RID: 12794 RVA: 0x000603D5 File Offset: 0x0005E5D5
		[ProtoMember(1, IsRequired = false, Name = "originuid", DataFormat = DataFormat.TwosComplement)]
		public ulong originuid
		{
			get
			{
				return this._originuid ?? 0UL;
			}
			set
			{
				this._originuid = new ulong?(value);
			}
		}

		// Token: 0x17000F71 RID: 3953
		// (get) Token: 0x060031FB RID: 12795 RVA: 0x000603E4 File Offset: 0x0005E5E4
		// (set) Token: 0x060031FC RID: 12796 RVA: 0x00060404 File Offset: 0x0005E604
		[XmlIgnore]
		[Browsable(false)]
		public bool originuidSpecified
		{
			get
			{
				return this._originuid != null;
			}
			set
			{
				bool flag = value == (this._originuid == null);
				if (flag)
				{
					this._originuid = (value ? new ulong?(this.originuid) : null);
				}
			}
		}

		// Token: 0x060031FD RID: 12797 RVA: 0x00060448 File Offset: 0x0005E648
		private bool ShouldSerializeoriginuid()
		{
			return this.originuidSpecified;
		}

		// Token: 0x060031FE RID: 12798 RVA: 0x00060460 File Offset: 0x0005E660
		private void Resetoriginuid()
		{
			this.originuidSpecified = false;
		}

		// Token: 0x17000F72 RID: 3954
		// (get) Token: 0x060031FF RID: 12799 RVA: 0x0006046C File Offset: 0x0005E66C
		// (set) Token: 0x06003200 RID: 12800 RVA: 0x00060499 File Offset: 0x0005E699
		[ProtoMember(2, IsRequired = false, Name = "destuid", DataFormat = DataFormat.TwosComplement)]
		public ulong destuid
		{
			get
			{
				return this._destuid ?? 0UL;
			}
			set
			{
				this._destuid = new ulong?(value);
			}
		}

		// Token: 0x17000F73 RID: 3955
		// (get) Token: 0x06003201 RID: 12801 RVA: 0x000604A8 File Offset: 0x0005E6A8
		// (set) Token: 0x06003202 RID: 12802 RVA: 0x000604C8 File Offset: 0x0005E6C8
		[XmlIgnore]
		[Browsable(false)]
		public bool destuidSpecified
		{
			get
			{
				return this._destuid != null;
			}
			set
			{
				bool flag = value == (this._destuid == null);
				if (flag)
				{
					this._destuid = (value ? new ulong?(this.destuid) : null);
				}
			}
		}

		// Token: 0x06003203 RID: 12803 RVA: 0x0006050C File Offset: 0x0005E70C
		private bool ShouldSerializedestuid()
		{
			return this.destuidSpecified;
		}

		// Token: 0x06003204 RID: 12804 RVA: 0x00060524 File Offset: 0x0005E724
		private void Resetdestuid()
		{
			this.destuidSpecified = false;
		}

		// Token: 0x06003205 RID: 12805 RVA: 0x00060530 File Offset: 0x0005E730
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C67 RID: 3175
		private ulong? _originuid;

		// Token: 0x04000C68 RID: 3176
		private ulong? _destuid;

		// Token: 0x04000C69 RID: 3177
		private IExtension extensionObject;
	}
}
