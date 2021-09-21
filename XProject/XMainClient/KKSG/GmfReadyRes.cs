using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000243 RID: 579
	[ProtoContract(Name = "GmfReadyRes")]
	[Serializable]
	public class GmfReadyRes : IExtensible
	{
		// Token: 0x17000A05 RID: 2565
		// (get) Token: 0x06002024 RID: 8228 RVA: 0x0003EF98 File Offset: 0x0003D198
		// (set) Token: 0x06002025 RID: 8229 RVA: 0x0003EFC4 File Offset: 0x0003D1C4
		[ProtoMember(1, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000A06 RID: 2566
		// (get) Token: 0x06002026 RID: 8230 RVA: 0x0003EFD4 File Offset: 0x0003D1D4
		// (set) Token: 0x06002027 RID: 8231 RVA: 0x0003EFF4 File Offset: 0x0003D1F4
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x06002028 RID: 8232 RVA: 0x0003F038 File Offset: 0x0003D238
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06002029 RID: 8233 RVA: 0x0003F050 File Offset: 0x0003D250
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x17000A07 RID: 2567
		// (get) Token: 0x0600202A RID: 8234 RVA: 0x0003F05C File Offset: 0x0003D25C
		// (set) Token: 0x0600202B RID: 8235 RVA: 0x0003F088 File Offset: 0x0003D288
		[ProtoMember(2, IsRequired = false, Name = "cooldown", DataFormat = DataFormat.TwosComplement)]
		public uint cooldown
		{
			get
			{
				return this._cooldown ?? 0U;
			}
			set
			{
				this._cooldown = new uint?(value);
			}
		}

		// Token: 0x17000A08 RID: 2568
		// (get) Token: 0x0600202C RID: 8236 RVA: 0x0003F098 File Offset: 0x0003D298
		// (set) Token: 0x0600202D RID: 8237 RVA: 0x0003F0B8 File Offset: 0x0003D2B8
		[XmlIgnore]
		[Browsable(false)]
		public bool cooldownSpecified
		{
			get
			{
				return this._cooldown != null;
			}
			set
			{
				bool flag = value == (this._cooldown == null);
				if (flag)
				{
					this._cooldown = (value ? new uint?(this.cooldown) : null);
				}
			}
		}

		// Token: 0x0600202E RID: 8238 RVA: 0x0003F0FC File Offset: 0x0003D2FC
		private bool ShouldSerializecooldown()
		{
			return this.cooldownSpecified;
		}

		// Token: 0x0600202F RID: 8239 RVA: 0x0003F114 File Offset: 0x0003D314
		private void Resetcooldown()
		{
			this.cooldownSpecified = false;
		}

		// Token: 0x06002030 RID: 8240 RVA: 0x0003F120 File Offset: 0x0003D320
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000806 RID: 2054
		private ErrorCode? _errcode;

		// Token: 0x04000807 RID: 2055
		private uint? _cooldown;

		// Token: 0x04000808 RID: 2056
		private IExtension extensionObject;
	}
}
