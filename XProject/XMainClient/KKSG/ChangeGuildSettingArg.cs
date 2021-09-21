using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000092 RID: 146
	[ProtoContract(Name = "ChangeGuildSettingArg")]
	[Serializable]
	public class ChangeGuildSettingArg : IExtensible
	{
		// Token: 0x17000314 RID: 788
		// (get) Token: 0x0600095A RID: 2394 RVA: 0x00014680 File Offset: 0x00012880
		// (set) Token: 0x0600095B RID: 2395 RVA: 0x000146AC File Offset: 0x000128AC
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

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x000146BC File Offset: 0x000128BC
		// (set) Token: 0x0600095D RID: 2397 RVA: 0x000146DC File Offset: 0x000128DC
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

		// Token: 0x0600095E RID: 2398 RVA: 0x00014720 File Offset: 0x00012920
		private bool ShouldSerializeIcon()
		{
			return this.IconSpecified;
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x00014738 File Offset: 0x00012938
		private void ResetIcon()
		{
			this.IconSpecified = false;
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000960 RID: 2400 RVA: 0x00014744 File Offset: 0x00012944
		// (set) Token: 0x06000961 RID: 2401 RVA: 0x00014770 File Offset: 0x00012970
		[ProtoMember(2, IsRequired = false, Name = "powerpoint", DataFormat = DataFormat.TwosComplement)]
		public int powerpoint
		{
			get
			{
				return this._powerpoint ?? 0;
			}
			set
			{
				this._powerpoint = new int?(value);
			}
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x06000962 RID: 2402 RVA: 0x00014780 File Offset: 0x00012980
		// (set) Token: 0x06000963 RID: 2403 RVA: 0x000147A0 File Offset: 0x000129A0
		[XmlIgnore]
		[Browsable(false)]
		public bool powerpointSpecified
		{
			get
			{
				return this._powerpoint != null;
			}
			set
			{
				bool flag = value == (this._powerpoint == null);
				if (flag)
				{
					this._powerpoint = (value ? new int?(this.powerpoint) : null);
				}
			}
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x000147E4 File Offset: 0x000129E4
		private bool ShouldSerializepowerpoint()
		{
			return this.powerpointSpecified;
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x000147FC File Offset: 0x000129FC
		private void Resetpowerpoint()
		{
			this.powerpointSpecified = false;
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06000966 RID: 2406 RVA: 0x00014808 File Offset: 0x00012A08
		// (set) Token: 0x06000967 RID: 2407 RVA: 0x00014834 File Offset: 0x00012A34
		[ProtoMember(3, IsRequired = false, Name = "needapproval", DataFormat = DataFormat.TwosComplement)]
		public int needapproval
		{
			get
			{
				return this._needapproval ?? 0;
			}
			set
			{
				this._needapproval = new int?(value);
			}
		}

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06000968 RID: 2408 RVA: 0x00014844 File Offset: 0x00012A44
		// (set) Token: 0x06000969 RID: 2409 RVA: 0x00014864 File Offset: 0x00012A64
		[XmlIgnore]
		[Browsable(false)]
		public bool needapprovalSpecified
		{
			get
			{
				return this._needapproval != null;
			}
			set
			{
				bool flag = value == (this._needapproval == null);
				if (flag)
				{
					this._needapproval = (value ? new int?(this.needapproval) : null);
				}
			}
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x000148A8 File Offset: 0x00012AA8
		private bool ShouldSerializeneedapproval()
		{
			return this.needapprovalSpecified;
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x000148C0 File Offset: 0x00012AC0
		private void Resetneedapproval()
		{
			this.needapprovalSpecified = false;
		}

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x0600096C RID: 2412 RVA: 0x000148CC File Offset: 0x00012ACC
		// (set) Token: 0x0600096D RID: 2413 RVA: 0x000148ED File Offset: 0x00012AED
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

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x0600096E RID: 2414 RVA: 0x000148F8 File Offset: 0x00012AF8
		// (set) Token: 0x0600096F RID: 2415 RVA: 0x00014914 File Offset: 0x00012B14
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

		// Token: 0x06000970 RID: 2416 RVA: 0x00014944 File Offset: 0x00012B44
		private bool ShouldSerializeannoucement()
		{
			return this.annoucementSpecified;
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0001495C File Offset: 0x00012B5C
		private void Resetannoucement()
		{
			this.annoucementSpecified = false;
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x00014968 File Offset: 0x00012B68
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000270 RID: 624
		private int? _Icon;

		// Token: 0x04000271 RID: 625
		private int? _powerpoint;

		// Token: 0x04000272 RID: 626
		private int? _needapproval;

		// Token: 0x04000273 RID: 627
		private string _annoucement;

		// Token: 0x04000274 RID: 628
		private IExtension extensionObject;
	}
}
