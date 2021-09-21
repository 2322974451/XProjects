using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001A9 RID: 425
	[ProtoContract(Name = "WorldBossStateNtf")]
	[Serializable]
	public class WorldBossStateNtf : IExtensible
	{
		// Token: 0x170007EA RID: 2026
		// (get) Token: 0x06001919 RID: 6425 RVA: 0x00031DC4 File Offset: 0x0002FFC4
		// (set) Token: 0x0600191A RID: 6426 RVA: 0x00031DF0 File Offset: 0x0002FFF0
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public WorldBossState state
		{
			get
			{
				return this._state ?? WorldBossState.WorldBoss_BeginPre;
			}
			set
			{
				this._state = new WorldBossState?(value);
			}
		}

		// Token: 0x170007EB RID: 2027
		// (get) Token: 0x0600191B RID: 6427 RVA: 0x00031E00 File Offset: 0x00030000
		// (set) Token: 0x0600191C RID: 6428 RVA: 0x00031E20 File Offset: 0x00030020
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new WorldBossState?(this.state) : null);
				}
			}
		}

		// Token: 0x0600191D RID: 6429 RVA: 0x00031E64 File Offset: 0x00030064
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x0600191E RID: 6430 RVA: 0x00031E7C File Offset: 0x0003007C
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x170007EC RID: 2028
		// (get) Token: 0x0600191F RID: 6431 RVA: 0x00031E88 File Offset: 0x00030088
		// (set) Token: 0x06001920 RID: 6432 RVA: 0x00031EB4 File Offset: 0x000300B4
		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x170007ED RID: 2029
		// (get) Token: 0x06001921 RID: 6433 RVA: 0x00031EC4 File Offset: 0x000300C4
		// (set) Token: 0x06001922 RID: 6434 RVA: 0x00031EE4 File Offset: 0x000300E4
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x06001923 RID: 6435 RVA: 0x00031F28 File Offset: 0x00030128
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06001924 RID: 6436 RVA: 0x00031F40 File Offset: 0x00030140
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x170007EE RID: 2030
		// (get) Token: 0x06001925 RID: 6437 RVA: 0x00031F4C File Offset: 0x0003014C
		// (set) Token: 0x06001926 RID: 6438 RVA: 0x00031F78 File Offset: 0x00030178
		[ProtoMember(3, IsRequired = false, Name = "iswin", DataFormat = DataFormat.Default)]
		public bool iswin
		{
			get
			{
				return this._iswin ?? false;
			}
			set
			{
				this._iswin = new bool?(value);
			}
		}

		// Token: 0x170007EF RID: 2031
		// (get) Token: 0x06001927 RID: 6439 RVA: 0x00031F88 File Offset: 0x00030188
		// (set) Token: 0x06001928 RID: 6440 RVA: 0x00031FA8 File Offset: 0x000301A8
		[XmlIgnore]
		[Browsable(false)]
		public bool iswinSpecified
		{
			get
			{
				return this._iswin != null;
			}
			set
			{
				bool flag = value == (this._iswin == null);
				if (flag)
				{
					this._iswin = (value ? new bool?(this.iswin) : null);
				}
			}
		}

		// Token: 0x06001929 RID: 6441 RVA: 0x00031FEC File Offset: 0x000301EC
		private bool ShouldSerializeiswin()
		{
			return this.iswinSpecified;
		}

		// Token: 0x0600192A RID: 6442 RVA: 0x00032004 File Offset: 0x00030204
		private void Resetiswin()
		{
			this.iswinSpecified = false;
		}

		// Token: 0x0600192B RID: 6443 RVA: 0x00032010 File Offset: 0x00030210
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400063C RID: 1596
		private WorldBossState? _state;

		// Token: 0x0400063D RID: 1597
		private uint? _time;

		// Token: 0x0400063E RID: 1598
		private bool? _iswin;

		// Token: 0x0400063F RID: 1599
		private IExtension extensionObject;
	}
}
