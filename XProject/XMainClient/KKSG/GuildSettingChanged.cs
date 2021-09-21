using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000096 RID: 150
	[ProtoContract(Name = "GuildSettingChanged")]
	[Serializable]
	public class GuildSettingChanged : IExtensible
	{
		// Token: 0x17000345 RID: 837
		// (get) Token: 0x060009F3 RID: 2547 RVA: 0x0001593C File Offset: 0x00013B3C
		// (set) Token: 0x060009F4 RID: 2548 RVA: 0x00015968 File Offset: 0x00013B68
		[ProtoMember(1, IsRequired = false, Name = "Icon", DataFormat = DataFormat.TwosComplement)]
		public int Icon
		{
			get
			{
				return this._Icon ?? 0;
			}
			set
			{
				this._Icon = new int?(value);
			}
		}

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x060009F5 RID: 2549 RVA: 0x00015978 File Offset: 0x00013B78
		// (set) Token: 0x060009F6 RID: 2550 RVA: 0x00015998 File Offset: 0x00013B98
		[XmlIgnore]
		[Browsable(false)]
		public bool IconSpecified
		{
			get
			{
				return this._Icon != null;
			}
			set
			{
				bool flag = value == (this._Icon == null);
				if (flag)
				{
					this._Icon = (value ? new int?(this.Icon) : null);
				}
			}
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x000159DC File Offset: 0x00013BDC
		private bool ShouldSerializeIcon()
		{
			return this.IconSpecified;
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x000159F4 File Offset: 0x00013BF4
		private void ResetIcon()
		{
			this.IconSpecified = false;
		}

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x060009F9 RID: 2553 RVA: 0x00015A00 File Offset: 0x00013C00
		// (set) Token: 0x060009FA RID: 2554 RVA: 0x00015A2C File Offset: 0x00013C2C
		[ProtoMember(2, IsRequired = false, Name = "RecuitPPT", DataFormat = DataFormat.TwosComplement)]
		public int RecuitPPT
		{
			get
			{
				return this._RecuitPPT ?? 0;
			}
			set
			{
				this._RecuitPPT = new int?(value);
			}
		}

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x060009FB RID: 2555 RVA: 0x00015A3C File Offset: 0x00013C3C
		// (set) Token: 0x060009FC RID: 2556 RVA: 0x00015A5C File Offset: 0x00013C5C
		[XmlIgnore]
		[Browsable(false)]
		public bool RecuitPPTSpecified
		{
			get
			{
				return this._RecuitPPT != null;
			}
			set
			{
				bool flag = value == (this._RecuitPPT == null);
				if (flag)
				{
					this._RecuitPPT = (value ? new int?(this.RecuitPPT) : null);
				}
			}
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x00015AA0 File Offset: 0x00013CA0
		private bool ShouldSerializeRecuitPPT()
		{
			return this.RecuitPPTSpecified;
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x00015AB8 File Offset: 0x00013CB8
		private void ResetRecuitPPT()
		{
			this.RecuitPPTSpecified = false;
		}

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x060009FF RID: 2559 RVA: 0x00015AC4 File Offset: 0x00013CC4
		// (set) Token: 0x06000A00 RID: 2560 RVA: 0x00015AF0 File Offset: 0x00013CF0
		[ProtoMember(3, IsRequired = false, Name = "needApproval", DataFormat = DataFormat.TwosComplement)]
		public int needApproval
		{
			get
			{
				return this._needApproval ?? 0;
			}
			set
			{
				this._needApproval = new int?(value);
			}
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000A01 RID: 2561 RVA: 0x00015B00 File Offset: 0x00013D00
		// (set) Token: 0x06000A02 RID: 2562 RVA: 0x00015B20 File Offset: 0x00013D20
		[XmlIgnore]
		[Browsable(false)]
		public bool needApprovalSpecified
		{
			get
			{
				return this._needApproval != null;
			}
			set
			{
				bool flag = value == (this._needApproval == null);
				if (flag)
				{
					this._needApproval = (value ? new int?(this.needApproval) : null);
				}
			}
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x00015B64 File Offset: 0x00013D64
		private bool ShouldSerializeneedApproval()
		{
			return this.needApprovalSpecified;
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x00015B7C File Offset: 0x00013D7C
		private void ResetneedApproval()
		{
			this.needApprovalSpecified = false;
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000A05 RID: 2565 RVA: 0x00015B88 File Offset: 0x00013D88
		// (set) Token: 0x06000A06 RID: 2566 RVA: 0x00015BA9 File Offset: 0x00013DA9
		[ProtoMember(4, IsRequired = false, Name = "annoucement", DataFormat = DataFormat.Default)]
		public string annoucement
		{
			get
			{
				return this._annoucement ?? "";
			}
			set
			{
				this._annoucement = value;
			}
		}

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06000A07 RID: 2567 RVA: 0x00015BB4 File Offset: 0x00013DB4
		// (set) Token: 0x06000A08 RID: 2568 RVA: 0x00015BD0 File Offset: 0x00013DD0
		[XmlIgnore]
		[Browsable(false)]
		public bool annoucementSpecified
		{
			get
			{
				return this._annoucement != null;
			}
			set
			{
				bool flag = value == (this._annoucement == null);
				if (flag)
				{
					this._annoucement = (value ? this.annoucement : null);
				}
			}
		}

		// Token: 0x06000A09 RID: 2569 RVA: 0x00015C00 File Offset: 0x00013E00
		private bool ShouldSerializeannoucement()
		{
			return this.annoucementSpecified;
		}

		// Token: 0x06000A0A RID: 2570 RVA: 0x00015C18 File Offset: 0x00013E18
		private void Resetannoucement()
		{
			this.annoucementSpecified = false;
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x00015C24 File Offset: 0x00013E24
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400028D RID: 653
		private int? _Icon;

		// Token: 0x0400028E RID: 654
		private int? _RecuitPPT;

		// Token: 0x0400028F RID: 655
		private int? _needApproval;

		// Token: 0x04000290 RID: 656
		private string _annoucement;

		// Token: 0x04000291 RID: 657
		private IExtension extensionObject;
	}
}
