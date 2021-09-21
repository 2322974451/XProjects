using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005CE RID: 1486
	[ProtoContract(Name = "SpecialStageInfo")]
	[Serializable]
	public class SpecialStageInfo : IExtensible
	{
		// Token: 0x170019FE RID: 6654
		// (get) Token: 0x060053F5 RID: 21493 RVA: 0x0009FB9C File Offset: 0x0009DD9C
		// (set) Token: 0x060053F6 RID: 21494 RVA: 0x0009FBC8 File Offset: 0x0009DDC8
		[ProtoMember(1, IsRequired = false, Name = "arenaup", DataFormat = DataFormat.TwosComplement)]
		public uint arenaup
		{
			get
			{
				return this._arenaup ?? 0U;
			}
			set
			{
				this._arenaup = new uint?(value);
			}
		}

		// Token: 0x170019FF RID: 6655
		// (get) Token: 0x060053F7 RID: 21495 RVA: 0x0009FBD8 File Offset: 0x0009DDD8
		// (set) Token: 0x060053F8 RID: 21496 RVA: 0x0009FBF8 File Offset: 0x0009DDF8
		[XmlIgnore]
		[Browsable(false)]
		public bool arenaupSpecified
		{
			get
			{
				return this._arenaup != null;
			}
			set
			{
				bool flag = value == (this._arenaup == null);
				if (flag)
				{
					this._arenaup = (value ? new uint?(this.arenaup) : null);
				}
			}
		}

		// Token: 0x060053F9 RID: 21497 RVA: 0x0009FC3C File Offset: 0x0009DE3C
		private bool ShouldSerializearenaup()
		{
			return this.arenaupSpecified;
		}

		// Token: 0x060053FA RID: 21498 RVA: 0x0009FC54 File Offset: 0x0009DE54
		private void Resetarenaup()
		{
			this.arenaupSpecified = false;
		}

		// Token: 0x17001A00 RID: 6656
		// (get) Token: 0x060053FB RID: 21499 RVA: 0x0009FC60 File Offset: 0x0009DE60
		// (set) Token: 0x060053FC RID: 21500 RVA: 0x0009FC78 File Offset: 0x0009DE78
		[ProtoMember(2, IsRequired = false, Name = "bossrushresult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BossRushResult bossrushresult
		{
			get
			{
				return this._bossrushresult;
			}
			set
			{
				this._bossrushresult = value;
			}
		}

		// Token: 0x17001A01 RID: 6657
		// (get) Token: 0x060053FD RID: 21501 RVA: 0x0009FC84 File Offset: 0x0009DE84
		// (set) Token: 0x060053FE RID: 21502 RVA: 0x0009FCB0 File Offset: 0x0009DEB0
		[ProtoMember(3, IsRequired = false, Name = "arenamissed", DataFormat = DataFormat.Default)]
		public bool arenamissed
		{
			get
			{
				return this._arenamissed ?? false;
			}
			set
			{
				this._arenamissed = new bool?(value);
			}
		}

		// Token: 0x17001A02 RID: 6658
		// (get) Token: 0x060053FF RID: 21503 RVA: 0x0009FCC0 File Offset: 0x0009DEC0
		// (set) Token: 0x06005400 RID: 21504 RVA: 0x0009FCE0 File Offset: 0x0009DEE0
		[XmlIgnore]
		[Browsable(false)]
		public bool arenamissedSpecified
		{
			get
			{
				return this._arenamissed != null;
			}
			set
			{
				bool flag = value == (this._arenamissed == null);
				if (flag)
				{
					this._arenamissed = (value ? new bool?(this.arenamissed) : null);
				}
			}
		}

		// Token: 0x06005401 RID: 21505 RVA: 0x0009FD24 File Offset: 0x0009DF24
		private bool ShouldSerializearenamissed()
		{
			return this.arenamissedSpecified;
		}

		// Token: 0x06005402 RID: 21506 RVA: 0x0009FD3C File Offset: 0x0009DF3C
		private void Resetarenamissed()
		{
			this.arenamissedSpecified = false;
		}

		// Token: 0x06005403 RID: 21507 RVA: 0x0009FD48 File Offset: 0x0009DF48
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400147E RID: 5246
		private uint? _arenaup;

		// Token: 0x0400147F RID: 5247
		private BossRushResult _bossrushresult = null;

		// Token: 0x04001480 RID: 5248
		private bool? _arenamissed;

		// Token: 0x04001481 RID: 5249
		private IExtension extensionObject;
	}
}
