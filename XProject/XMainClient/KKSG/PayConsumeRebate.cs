using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000627 RID: 1575
	[ProtoContract(Name = "PayConsumeRebate")]
	[Serializable]
	public class PayConsumeRebate : IExtensible
	{
		// Token: 0x17001E60 RID: 7776
		// (get) Token: 0x06006090 RID: 24720 RVA: 0x000B82BC File Offset: 0x000B64BC
		// (set) Token: 0x06006091 RID: 24721 RVA: 0x000B82E8 File Offset: 0x000B64E8
		[ProtoMember(1, IsRequired = false, Name = "consumenum", DataFormat = DataFormat.TwosComplement)]
		public uint consumenum
		{
			get
			{
				return this._consumenum ?? 0U;
			}
			set
			{
				this._consumenum = new uint?(value);
			}
		}

		// Token: 0x17001E61 RID: 7777
		// (get) Token: 0x06006092 RID: 24722 RVA: 0x000B82F8 File Offset: 0x000B64F8
		// (set) Token: 0x06006093 RID: 24723 RVA: 0x000B8318 File Offset: 0x000B6518
		[XmlIgnore]
		[Browsable(false)]
		public bool consumenumSpecified
		{
			get
			{
				return this._consumenum != null;
			}
			set
			{
				bool flag = value == (this._consumenum == null);
				if (flag)
				{
					this._consumenum = (value ? new uint?(this.consumenum) : null);
				}
			}
		}

		// Token: 0x06006094 RID: 24724 RVA: 0x000B835C File Offset: 0x000B655C
		private bool ShouldSerializeconsumenum()
		{
			return this.consumenumSpecified;
		}

		// Token: 0x06006095 RID: 24725 RVA: 0x000B8374 File Offset: 0x000B6574
		private void Resetconsumenum()
		{
			this.consumenumSpecified = false;
		}

		// Token: 0x17001E62 RID: 7778
		// (get) Token: 0x06006096 RID: 24726 RVA: 0x000B8380 File Offset: 0x000B6580
		// (set) Token: 0x06006097 RID: 24727 RVA: 0x000B83AC File Offset: 0x000B65AC
		[ProtoMember(2, IsRequired = false, Name = "lastconsumetime", DataFormat = DataFormat.TwosComplement)]
		public uint lastconsumetime
		{
			get
			{
				return this._lastconsumetime ?? 0U;
			}
			set
			{
				this._lastconsumetime = new uint?(value);
			}
		}

		// Token: 0x17001E63 RID: 7779
		// (get) Token: 0x06006098 RID: 24728 RVA: 0x000B83BC File Offset: 0x000B65BC
		// (set) Token: 0x06006099 RID: 24729 RVA: 0x000B83DC File Offset: 0x000B65DC
		[XmlIgnore]
		[Browsable(false)]
		public bool lastconsumetimeSpecified
		{
			get
			{
				return this._lastconsumetime != null;
			}
			set
			{
				bool flag = value == (this._lastconsumetime == null);
				if (flag)
				{
					this._lastconsumetime = (value ? new uint?(this.lastconsumetime) : null);
				}
			}
		}

		// Token: 0x0600609A RID: 24730 RVA: 0x000B8420 File Offset: 0x000B6620
		private bool ShouldSerializelastconsumetime()
		{
			return this.lastconsumetimeSpecified;
		}

		// Token: 0x0600609B RID: 24731 RVA: 0x000B8438 File Offset: 0x000B6638
		private void Resetlastconsumetime()
		{
			this.lastconsumetimeSpecified = false;
		}

		// Token: 0x17001E64 RID: 7780
		// (get) Token: 0x0600609C RID: 24732 RVA: 0x000B8444 File Offset: 0x000B6644
		// (set) Token: 0x0600609D RID: 24733 RVA: 0x000B8470 File Offset: 0x000B6670
		[ProtoMember(3, IsRequired = false, Name = "rate", DataFormat = DataFormat.TwosComplement)]
		public uint rate
		{
			get
			{
				return this._rate ?? 0U;
			}
			set
			{
				this._rate = new uint?(value);
			}
		}

		// Token: 0x17001E65 RID: 7781
		// (get) Token: 0x0600609E RID: 24734 RVA: 0x000B8480 File Offset: 0x000B6680
		// (set) Token: 0x0600609F RID: 24735 RVA: 0x000B84A0 File Offset: 0x000B66A0
		[XmlIgnore]
		[Browsable(false)]
		public bool rateSpecified
		{
			get
			{
				return this._rate != null;
			}
			set
			{
				bool flag = value == (this._rate == null);
				if (flag)
				{
					this._rate = (value ? new uint?(this.rate) : null);
				}
			}
		}

		// Token: 0x060060A0 RID: 24736 RVA: 0x000B84E4 File Offset: 0x000B66E4
		private bool ShouldSerializerate()
		{
			return this.rateSpecified;
		}

		// Token: 0x060060A1 RID: 24737 RVA: 0x000B84FC File Offset: 0x000B66FC
		private void Resetrate()
		{
			this.rateSpecified = false;
		}

		// Token: 0x060060A2 RID: 24738 RVA: 0x000B8508 File Offset: 0x000B6708
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001770 RID: 6000
		private uint? _consumenum;

		// Token: 0x04001771 RID: 6001
		private uint? _lastconsumetime;

		// Token: 0x04001772 RID: 6002
		private uint? _rate;

		// Token: 0x04001773 RID: 6003
		private IExtension extensionObject;
	}
}
