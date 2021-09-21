using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000207 RID: 519
	[ProtoContract(Name = "DERankRes")]
	[Serializable]
	public class DERankRes : IExtensible
	{
		// Token: 0x17000933 RID: 2355
		// (get) Token: 0x06001D5D RID: 7517 RVA: 0x00039CA4 File Offset: 0x00037EA4
		[ProtoMember(1, Name = "ranks", DataFormat = DataFormat.Default)]
		public List<DERank> ranks
		{
			get
			{
				return this._ranks;
			}
		}

		// Token: 0x17000934 RID: 2356
		// (get) Token: 0x06001D5E RID: 7518 RVA: 0x00039CBC File Offset: 0x00037EBC
		// (set) Token: 0x06001D5F RID: 7519 RVA: 0x00039CE8 File Offset: 0x00037EE8
		[ProtoMember(2, IsRequired = false, Name = "rewardlefttime", DataFormat = DataFormat.TwosComplement)]
		public uint rewardlefttime
		{
			get
			{
				return this._rewardlefttime ?? 0U;
			}
			set
			{
				this._rewardlefttime = new uint?(value);
			}
		}

		// Token: 0x17000935 RID: 2357
		// (get) Token: 0x06001D60 RID: 7520 RVA: 0x00039CF8 File Offset: 0x00037EF8
		// (set) Token: 0x06001D61 RID: 7521 RVA: 0x00039D18 File Offset: 0x00037F18
		[XmlIgnore]
		[Browsable(false)]
		public bool rewardlefttimeSpecified
		{
			get
			{
				return this._rewardlefttime != null;
			}
			set
			{
				bool flag = value == (this._rewardlefttime == null);
				if (flag)
				{
					this._rewardlefttime = (value ? new uint?(this.rewardlefttime) : null);
				}
			}
		}

		// Token: 0x06001D62 RID: 7522 RVA: 0x00039D5C File Offset: 0x00037F5C
		private bool ShouldSerializerewardlefttime()
		{
			return this.rewardlefttimeSpecified;
		}

		// Token: 0x06001D63 RID: 7523 RVA: 0x00039D74 File Offset: 0x00037F74
		private void Resetrewardlefttime()
		{
			this.rewardlefttimeSpecified = false;
		}

		// Token: 0x17000936 RID: 2358
		// (get) Token: 0x06001D64 RID: 7524 RVA: 0x00039D80 File Offset: 0x00037F80
		// (set) Token: 0x06001D65 RID: 7525 RVA: 0x00039DAC File Offset: 0x00037FAC
		[ProtoMember(3, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000937 RID: 2359
		// (get) Token: 0x06001D66 RID: 7526 RVA: 0x00039DBC File Offset: 0x00037FBC
		// (set) Token: 0x06001D67 RID: 7527 RVA: 0x00039DDC File Offset: 0x00037FDC
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

		// Token: 0x06001D68 RID: 7528 RVA: 0x00039E20 File Offset: 0x00038020
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x06001D69 RID: 7529 RVA: 0x00039E38 File Offset: 0x00038038
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x06001D6A RID: 7530 RVA: 0x00039E44 File Offset: 0x00038044
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000756 RID: 1878
		private readonly List<DERank> _ranks = new List<DERank>();

		// Token: 0x04000757 RID: 1879
		private uint? _rewardlefttime;

		// Token: 0x04000758 RID: 1880
		private ErrorCode? _errcode;

		// Token: 0x04000759 RID: 1881
		private IExtension extensionObject;
	}
}
