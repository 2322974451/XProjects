using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002EC RID: 748
	[ProtoContract(Name = "JoinLargeRoomArg")]
	[Serializable]
	public class JoinLargeRoomArg : IExtensible
	{
		// Token: 0x17000CC8 RID: 3272
		// (get) Token: 0x0600292B RID: 10539 RVA: 0x0004FF08 File Offset: 0x0004E108
		// (set) Token: 0x0600292C RID: 10540 RVA: 0x0004FF34 File Offset: 0x0004E134
		[ProtoMember(1, IsRequired = false, Name = "param", DataFormat = DataFormat.TwosComplement)]
		public uint param
		{
			get
			{
				return this._param ?? 0U;
			}
			set
			{
				this._param = new uint?(value);
			}
		}

		// Token: 0x17000CC9 RID: 3273
		// (get) Token: 0x0600292D RID: 10541 RVA: 0x0004FF44 File Offset: 0x0004E144
		// (set) Token: 0x0600292E RID: 10542 RVA: 0x0004FF64 File Offset: 0x0004E164
		[XmlIgnore]
		[Browsable(false)]
		public bool paramSpecified
		{
			get
			{
				return this._param != null;
			}
			set
			{
				bool flag = value == (this._param == null);
				if (flag)
				{
					this._param = (value ? new uint?(this.param) : null);
				}
			}
		}

		// Token: 0x0600292F RID: 10543 RVA: 0x0004FFA8 File Offset: 0x0004E1A8
		private bool ShouldSerializeparam()
		{
			return this.paramSpecified;
		}

		// Token: 0x06002930 RID: 10544 RVA: 0x0004FFC0 File Offset: 0x0004E1C0
		private void Resetparam()
		{
			this.paramSpecified = false;
		}

		// Token: 0x17000CCA RID: 3274
		// (get) Token: 0x06002931 RID: 10545 RVA: 0x0004FFCC File Offset: 0x0004E1CC
		// (set) Token: 0x06002932 RID: 10546 RVA: 0x0004FFF9 File Offset: 0x0004E1F9
		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x17000CCB RID: 3275
		// (get) Token: 0x06002933 RID: 10547 RVA: 0x00050008 File Offset: 0x0004E208
		// (set) Token: 0x06002934 RID: 10548 RVA: 0x00050028 File Offset: 0x0004E228
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06002935 RID: 10549 RVA: 0x0005006C File Offset: 0x0004E26C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06002936 RID: 10550 RVA: 0x00050084 File Offset: 0x0004E284
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17000CCC RID: 3276
		// (get) Token: 0x06002937 RID: 10551 RVA: 0x00050090 File Offset: 0x0004E290
		// (set) Token: 0x06002938 RID: 10552 RVA: 0x000500BC File Offset: 0x0004E2BC
		[ProtoMember(3, IsRequired = false, Name = "plat", DataFormat = DataFormat.TwosComplement)]
		public uint plat
		{
			get
			{
				return this._plat ?? 0U;
			}
			set
			{
				this._plat = new uint?(value);
			}
		}

		// Token: 0x17000CCD RID: 3277
		// (get) Token: 0x06002939 RID: 10553 RVA: 0x000500CC File Offset: 0x0004E2CC
		// (set) Token: 0x0600293A RID: 10554 RVA: 0x000500EC File Offset: 0x0004E2EC
		[XmlIgnore]
		[Browsable(false)]
		public bool platSpecified
		{
			get
			{
				return this._plat != null;
			}
			set
			{
				bool flag = value == (this._plat == null);
				if (flag)
				{
					this._plat = (value ? new uint?(this.plat) : null);
				}
			}
		}

		// Token: 0x0600293B RID: 10555 RVA: 0x00050130 File Offset: 0x0004E330
		private bool ShouldSerializeplat()
		{
			return this.platSpecified;
		}

		// Token: 0x0600293C RID: 10556 RVA: 0x00050148 File Offset: 0x0004E348
		private void Resetplat()
		{
			this.platSpecified = false;
		}

		// Token: 0x17000CCE RID: 3278
		// (get) Token: 0x0600293D RID: 10557 RVA: 0x00050154 File Offset: 0x0004E354
		// (set) Token: 0x0600293E RID: 10558 RVA: 0x00050175 File Offset: 0x0004E375
		[ProtoMember(4, IsRequired = false, Name = "ip", DataFormat = DataFormat.Default)]
		public string ip
		{
			get
			{
				return this._ip ?? "";
			}
			set
			{
				this._ip = value;
			}
		}

		// Token: 0x17000CCF RID: 3279
		// (get) Token: 0x0600293F RID: 10559 RVA: 0x00050180 File Offset: 0x0004E380
		// (set) Token: 0x06002940 RID: 10560 RVA: 0x0005019C File Offset: 0x0004E39C
		[XmlIgnore]
		[Browsable(false)]
		public bool ipSpecified
		{
			get
			{
				return this._ip != null;
			}
			set
			{
				bool flag = value == (this._ip == null);
				if (flag)
				{
					this._ip = (value ? this.ip : null);
				}
			}
		}

		// Token: 0x06002941 RID: 10561 RVA: 0x000501CC File Offset: 0x0004E3CC
		private bool ShouldSerializeip()
		{
			return this.ipSpecified;
		}

		// Token: 0x06002942 RID: 10562 RVA: 0x000501E4 File Offset: 0x0004E3E4
		private void Resetip()
		{
			this.ipSpecified = false;
		}

		// Token: 0x17000CD0 RID: 3280
		// (get) Token: 0x06002943 RID: 10563 RVA: 0x000501F0 File Offset: 0x0004E3F0
		// (set) Token: 0x06002944 RID: 10564 RVA: 0x00050211 File Offset: 0x0004E411
		[ProtoMember(5, IsRequired = false, Name = "acc", DataFormat = DataFormat.Default)]
		public string acc
		{
			get
			{
				return this._acc ?? "";
			}
			set
			{
				this._acc = value;
			}
		}

		// Token: 0x17000CD1 RID: 3281
		// (get) Token: 0x06002945 RID: 10565 RVA: 0x0005021C File Offset: 0x0004E41C
		// (set) Token: 0x06002946 RID: 10566 RVA: 0x00050238 File Offset: 0x0004E438
		[XmlIgnore]
		[Browsable(false)]
		public bool accSpecified
		{
			get
			{
				return this._acc != null;
			}
			set
			{
				bool flag = value == (this._acc == null);
				if (flag)
				{
					this._acc = (value ? this.acc : null);
				}
			}
		}

		// Token: 0x06002947 RID: 10567 RVA: 0x00050268 File Offset: 0x0004E468
		private bool ShouldSerializeacc()
		{
			return this.accSpecified;
		}

		// Token: 0x06002948 RID: 10568 RVA: 0x00050280 File Offset: 0x0004E480
		private void Resetacc()
		{
			this.accSpecified = false;
		}

		// Token: 0x06002949 RID: 10569 RVA: 0x0005028C File Offset: 0x0004E48C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A3A RID: 2618
		private uint? _param;

		// Token: 0x04000A3B RID: 2619
		private ulong? _roleid;

		// Token: 0x04000A3C RID: 2620
		private uint? _plat;

		// Token: 0x04000A3D RID: 2621
		private string _ip;

		// Token: 0x04000A3E RID: 2622
		private string _acc;

		// Token: 0x04000A3F RID: 2623
		private IExtension extensionObject;
	}
}
