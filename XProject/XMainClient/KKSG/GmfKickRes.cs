using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000247 RID: 583
	[ProtoContract(Name = "GmfKickRes")]
	[Serializable]
	public class GmfKickRes : IExtensible
	{
		// Token: 0x17000A11 RID: 2577
		// (get) Token: 0x0600204C RID: 8268 RVA: 0x0003F43C File Offset: 0x0003D63C
		// (set) Token: 0x0600204D RID: 8269 RVA: 0x0003F468 File Offset: 0x0003D668
		[ProtoMember(1, IsRequired = false, Name = "cooldowntime", DataFormat = DataFormat.TwosComplement)]
		public uint cooldowntime
		{
			get
			{
				return this._cooldowntime ?? 0U;
			}
			set
			{
				this._cooldowntime = new uint?(value);
			}
		}

		// Token: 0x17000A12 RID: 2578
		// (get) Token: 0x0600204E RID: 8270 RVA: 0x0003F478 File Offset: 0x0003D678
		// (set) Token: 0x0600204F RID: 8271 RVA: 0x0003F498 File Offset: 0x0003D698
		[XmlIgnore]
		[Browsable(false)]
		public bool cooldowntimeSpecified
		{
			get
			{
				return this._cooldowntime != null;
			}
			set
			{
				bool flag = value == (this._cooldowntime == null);
				if (flag)
				{
					this._cooldowntime = (value ? new uint?(this.cooldowntime) : null);
				}
			}
		}

		// Token: 0x06002050 RID: 8272 RVA: 0x0003F4DC File Offset: 0x0003D6DC
		private bool ShouldSerializecooldowntime()
		{
			return this.cooldowntimeSpecified;
		}

		// Token: 0x06002051 RID: 8273 RVA: 0x0003F4F4 File Offset: 0x0003D6F4
		private void Resetcooldowntime()
		{
			this.cooldowntimeSpecified = false;
		}

		// Token: 0x17000A13 RID: 2579
		// (get) Token: 0x06002052 RID: 8274 RVA: 0x0003F500 File Offset: 0x0003D700
		// (set) Token: 0x06002053 RID: 8275 RVA: 0x0003F52C File Offset: 0x0003D72C
		[ProtoMember(2, IsRequired = false, Name = "leaderkick", DataFormat = DataFormat.TwosComplement)]
		public int leaderkick
		{
			get
			{
				return this._leaderkick ?? 0;
			}
			set
			{
				this._leaderkick = new int?(value);
			}
		}

		// Token: 0x17000A14 RID: 2580
		// (get) Token: 0x06002054 RID: 8276 RVA: 0x0003F53C File Offset: 0x0003D73C
		// (set) Token: 0x06002055 RID: 8277 RVA: 0x0003F55C File Offset: 0x0003D75C
		[XmlIgnore]
		[Browsable(false)]
		public bool leaderkickSpecified
		{
			get
			{
				return this._leaderkick != null;
			}
			set
			{
				bool flag = value == (this._leaderkick == null);
				if (flag)
				{
					this._leaderkick = (value ? new int?(this.leaderkick) : null);
				}
			}
		}

		// Token: 0x06002056 RID: 8278 RVA: 0x0003F5A0 File Offset: 0x0003D7A0
		private bool ShouldSerializeleaderkick()
		{
			return this.leaderkickSpecified;
		}

		// Token: 0x06002057 RID: 8279 RVA: 0x0003F5B8 File Offset: 0x0003D7B8
		private void Resetleaderkick()
		{
			this.leaderkickSpecified = false;
		}

		// Token: 0x17000A15 RID: 2581
		// (get) Token: 0x06002058 RID: 8280 RVA: 0x0003F5C4 File Offset: 0x0003D7C4
		// (set) Token: 0x06002059 RID: 8281 RVA: 0x0003F5E5 File Offset: 0x0003D7E5
		[ProtoMember(3, IsRequired = false, Name = "kickname", DataFormat = DataFormat.Default)]
		public string kickname
		{
			get
			{
				return this._kickname ?? "";
			}
			set
			{
				this._kickname = value;
			}
		}

		// Token: 0x17000A16 RID: 2582
		// (get) Token: 0x0600205A RID: 8282 RVA: 0x0003F5F0 File Offset: 0x0003D7F0
		// (set) Token: 0x0600205B RID: 8283 RVA: 0x0003F60C File Offset: 0x0003D80C
		[XmlIgnore]
		[Browsable(false)]
		public bool kicknameSpecified
		{
			get
			{
				return this._kickname != null;
			}
			set
			{
				bool flag = value == (this._kickname == null);
				if (flag)
				{
					this._kickname = (value ? this.kickname : null);
				}
			}
		}

		// Token: 0x0600205C RID: 8284 RVA: 0x0003F63C File Offset: 0x0003D83C
		private bool ShouldSerializekickname()
		{
			return this.kicknameSpecified;
		}

		// Token: 0x0600205D RID: 8285 RVA: 0x0003F654 File Offset: 0x0003D854
		private void Resetkickname()
		{
			this.kicknameSpecified = false;
		}

		// Token: 0x0600205E RID: 8286 RVA: 0x0003F660 File Offset: 0x0003D860
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000811 RID: 2065
		private uint? _cooldowntime;

		// Token: 0x04000812 RID: 2066
		private int? _leaderkick;

		// Token: 0x04000813 RID: 2067
		private string _kickname;

		// Token: 0x04000814 RID: 2068
		private IExtension extensionObject;
	}
}
