using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000663 RID: 1635
	[ProtoContract(Name = "RolePartnerData")]
	[Serializable]
	public class RolePartnerData : IExtensible
	{
		// Token: 0x1700208C RID: 8332
		// (get) Token: 0x06006711 RID: 26385 RVA: 0x000C4E28 File Offset: 0x000C3028
		// (set) Token: 0x06006712 RID: 26386 RVA: 0x000C4E55 File Offset: 0x000C3055
		[ProtoMember(1, IsRequired = false, Name = "partnerid", DataFormat = DataFormat.TwosComplement)]
		public ulong partnerid
		{
			get
			{
				return this._partnerid ?? 0UL;
			}
			set
			{
				this._partnerid = new ulong?(value);
			}
		}

		// Token: 0x1700208D RID: 8333
		// (get) Token: 0x06006713 RID: 26387 RVA: 0x000C4E64 File Offset: 0x000C3064
		// (set) Token: 0x06006714 RID: 26388 RVA: 0x000C4E84 File Offset: 0x000C3084
		[XmlIgnore]
		[Browsable(false)]
		public bool partneridSpecified
		{
			get
			{
				return this._partnerid != null;
			}
			set
			{
				bool flag = value == (this._partnerid == null);
				if (flag)
				{
					this._partnerid = (value ? new ulong?(this.partnerid) : null);
				}
			}
		}

		// Token: 0x06006715 RID: 26389 RVA: 0x000C4EC8 File Offset: 0x000C30C8
		private bool ShouldSerializepartnerid()
		{
			return this.partneridSpecified;
		}

		// Token: 0x06006716 RID: 26390 RVA: 0x000C4EE0 File Offset: 0x000C30E0
		private void Resetpartnerid()
		{
			this.partneridSpecified = false;
		}

		// Token: 0x1700208E RID: 8334
		// (get) Token: 0x06006717 RID: 26391 RVA: 0x000C4EEC File Offset: 0x000C30EC
		// (set) Token: 0x06006718 RID: 26392 RVA: 0x000C4F18 File Offset: 0x000C3118
		[ProtoMember(2, IsRequired = false, Name = "last_leave_partner_time", DataFormat = DataFormat.TwosComplement)]
		public uint last_leave_partner_time
		{
			get
			{
				return this._last_leave_partner_time ?? 0U;
			}
			set
			{
				this._last_leave_partner_time = new uint?(value);
			}
		}

		// Token: 0x1700208F RID: 8335
		// (get) Token: 0x06006719 RID: 26393 RVA: 0x000C4F28 File Offset: 0x000C3128
		// (set) Token: 0x0600671A RID: 26394 RVA: 0x000C4F48 File Offset: 0x000C3148
		[XmlIgnore]
		[Browsable(false)]
		public bool last_leave_partner_timeSpecified
		{
			get
			{
				return this._last_leave_partner_time != null;
			}
			set
			{
				bool flag = value == (this._last_leave_partner_time == null);
				if (flag)
				{
					this._last_leave_partner_time = (value ? new uint?(this.last_leave_partner_time) : null);
				}
			}
		}

		// Token: 0x0600671B RID: 26395 RVA: 0x000C4F8C File Offset: 0x000C318C
		private bool ShouldSerializelast_leave_partner_time()
		{
			return this.last_leave_partner_timeSpecified;
		}

		// Token: 0x0600671C RID: 26396 RVA: 0x000C4FA4 File Offset: 0x000C31A4
		private void Resetlast_leave_partner_time()
		{
			this.last_leave_partner_timeSpecified = false;
		}

		// Token: 0x17002090 RID: 8336
		// (get) Token: 0x0600671D RID: 26397 RVA: 0x000C4FB0 File Offset: 0x000C31B0
		// (set) Token: 0x0600671E RID: 26398 RVA: 0x000C4FDC File Offset: 0x000C31DC
		[ProtoMember(3, IsRequired = false, Name = "taked_chest", DataFormat = DataFormat.TwosComplement)]
		public uint taked_chest
		{
			get
			{
				return this._taked_chest ?? 0U;
			}
			set
			{
				this._taked_chest = new uint?(value);
			}
		}

		// Token: 0x17002091 RID: 8337
		// (get) Token: 0x0600671F RID: 26399 RVA: 0x000C4FEC File Offset: 0x000C31EC
		// (set) Token: 0x06006720 RID: 26400 RVA: 0x000C500C File Offset: 0x000C320C
		[XmlIgnore]
		[Browsable(false)]
		public bool taked_chestSpecified
		{
			get
			{
				return this._taked_chest != null;
			}
			set
			{
				bool flag = value == (this._taked_chest == null);
				if (flag)
				{
					this._taked_chest = (value ? new uint?(this.taked_chest) : null);
				}
			}
		}

		// Token: 0x06006721 RID: 26401 RVA: 0x000C5050 File Offset: 0x000C3250
		private bool ShouldSerializetaked_chest()
		{
			return this.taked_chestSpecified;
		}

		// Token: 0x06006722 RID: 26402 RVA: 0x000C5068 File Offset: 0x000C3268
		private void Resettaked_chest()
		{
			this.taked_chestSpecified = false;
		}

		// Token: 0x17002092 RID: 8338
		// (get) Token: 0x06006723 RID: 26403 RVA: 0x000C5074 File Offset: 0x000C3274
		// (set) Token: 0x06006724 RID: 26404 RVA: 0x000C50A0 File Offset: 0x000C32A0
		[ProtoMember(4, IsRequired = false, Name = "open_shop_time", DataFormat = DataFormat.TwosComplement)]
		public uint open_shop_time
		{
			get
			{
				return this._open_shop_time ?? 0U;
			}
			set
			{
				this._open_shop_time = new uint?(value);
			}
		}

		// Token: 0x17002093 RID: 8339
		// (get) Token: 0x06006725 RID: 26405 RVA: 0x000C50B0 File Offset: 0x000C32B0
		// (set) Token: 0x06006726 RID: 26406 RVA: 0x000C50D0 File Offset: 0x000C32D0
		[XmlIgnore]
		[Browsable(false)]
		public bool open_shop_timeSpecified
		{
			get
			{
				return this._open_shop_time != null;
			}
			set
			{
				bool flag = value == (this._open_shop_time == null);
				if (flag)
				{
					this._open_shop_time = (value ? new uint?(this.open_shop_time) : null);
				}
			}
		}

		// Token: 0x06006727 RID: 26407 RVA: 0x000C5114 File Offset: 0x000C3314
		private bool ShouldSerializeopen_shop_time()
		{
			return this.open_shop_timeSpecified;
		}

		// Token: 0x06006728 RID: 26408 RVA: 0x000C512C File Offset: 0x000C332C
		private void Resetopen_shop_time()
		{
			this.open_shop_timeSpecified = false;
		}

		// Token: 0x17002094 RID: 8340
		// (get) Token: 0x06006729 RID: 26409 RVA: 0x000C5138 File Offset: 0x000C3338
		// (set) Token: 0x0600672A RID: 26410 RVA: 0x000C5164 File Offset: 0x000C3364
		[ProtoMember(5, IsRequired = false, Name = "apply_leave_time", DataFormat = DataFormat.TwosComplement)]
		public uint apply_leave_time
		{
			get
			{
				return this._apply_leave_time ?? 0U;
			}
			set
			{
				this._apply_leave_time = new uint?(value);
			}
		}

		// Token: 0x17002095 RID: 8341
		// (get) Token: 0x0600672B RID: 26411 RVA: 0x000C5174 File Offset: 0x000C3374
		// (set) Token: 0x0600672C RID: 26412 RVA: 0x000C5194 File Offset: 0x000C3394
		[XmlIgnore]
		[Browsable(false)]
		public bool apply_leave_timeSpecified
		{
			get
			{
				return this._apply_leave_time != null;
			}
			set
			{
				bool flag = value == (this._apply_leave_time == null);
				if (flag)
				{
					this._apply_leave_time = (value ? new uint?(this.apply_leave_time) : null);
				}
			}
		}

		// Token: 0x0600672D RID: 26413 RVA: 0x000C51D8 File Offset: 0x000C33D8
		private bool ShouldSerializeapply_leave_time()
		{
			return this.apply_leave_timeSpecified;
		}

		// Token: 0x0600672E RID: 26414 RVA: 0x000C51F0 File Offset: 0x000C33F0
		private void Resetapply_leave_time()
		{
			this.apply_leave_timeSpecified = false;
		}

		// Token: 0x17002096 RID: 8342
		// (get) Token: 0x0600672F RID: 26415 RVA: 0x000C51FC File Offset: 0x000C33FC
		// (set) Token: 0x06006730 RID: 26416 RVA: 0x000C5228 File Offset: 0x000C3428
		[ProtoMember(6, IsRequired = false, Name = "chest_redpoint", DataFormat = DataFormat.Default)]
		public bool chest_redpoint
		{
			get
			{
				return this._chest_redpoint ?? false;
			}
			set
			{
				this._chest_redpoint = new bool?(value);
			}
		}

		// Token: 0x17002097 RID: 8343
		// (get) Token: 0x06006731 RID: 26417 RVA: 0x000C5238 File Offset: 0x000C3438
		// (set) Token: 0x06006732 RID: 26418 RVA: 0x000C5258 File Offset: 0x000C3458
		[XmlIgnore]
		[Browsable(false)]
		public bool chest_redpointSpecified
		{
			get
			{
				return this._chest_redpoint != null;
			}
			set
			{
				bool flag = value == (this._chest_redpoint == null);
				if (flag)
				{
					this._chest_redpoint = (value ? new bool?(this.chest_redpoint) : null);
				}
			}
		}

		// Token: 0x06006733 RID: 26419 RVA: 0x000C529C File Offset: 0x000C349C
		private bool ShouldSerializechest_redpoint()
		{
			return this.chest_redpointSpecified;
		}

		// Token: 0x06006734 RID: 26420 RVA: 0x000C52B4 File Offset: 0x000C34B4
		private void Resetchest_redpoint()
		{
			this.chest_redpointSpecified = false;
		}

		// Token: 0x17002098 RID: 8344
		// (get) Token: 0x06006735 RID: 26421 RVA: 0x000C52C0 File Offset: 0x000C34C0
		// (set) Token: 0x06006736 RID: 26422 RVA: 0x000C52EC File Offset: 0x000C34EC
		[ProtoMember(7, IsRequired = false, Name = "last_update_time", DataFormat = DataFormat.TwosComplement)]
		public uint last_update_time
		{
			get
			{
				return this._last_update_time ?? 0U;
			}
			set
			{
				this._last_update_time = new uint?(value);
			}
		}

		// Token: 0x17002099 RID: 8345
		// (get) Token: 0x06006737 RID: 26423 RVA: 0x000C52FC File Offset: 0x000C34FC
		// (set) Token: 0x06006738 RID: 26424 RVA: 0x000C531C File Offset: 0x000C351C
		[XmlIgnore]
		[Browsable(false)]
		public bool last_update_timeSpecified
		{
			get
			{
				return this._last_update_time != null;
			}
			set
			{
				bool flag = value == (this._last_update_time == null);
				if (flag)
				{
					this._last_update_time = (value ? new uint?(this.last_update_time) : null);
				}
			}
		}

		// Token: 0x06006739 RID: 26425 RVA: 0x000C5360 File Offset: 0x000C3560
		private bool ShouldSerializelast_update_time()
		{
			return this.last_update_timeSpecified;
		}

		// Token: 0x0600673A RID: 26426 RVA: 0x000C5378 File Offset: 0x000C3578
		private void Resetlast_update_time()
		{
			this.last_update_timeSpecified = false;
		}

		// Token: 0x1700209A RID: 8346
		// (get) Token: 0x0600673B RID: 26427 RVA: 0x000C5384 File Offset: 0x000C3584
		// (set) Token: 0x0600673C RID: 26428 RVA: 0x000C53B0 File Offset: 0x000C35B0
		[ProtoMember(8, IsRequired = false, Name = "compenstateTime", DataFormat = DataFormat.TwosComplement)]
		public uint compenstateTime
		{
			get
			{
				return this._compenstateTime ?? 0U;
			}
			set
			{
				this._compenstateTime = new uint?(value);
			}
		}

		// Token: 0x1700209B RID: 8347
		// (get) Token: 0x0600673D RID: 26429 RVA: 0x000C53C0 File Offset: 0x000C35C0
		// (set) Token: 0x0600673E RID: 26430 RVA: 0x000C53E0 File Offset: 0x000C35E0
		[XmlIgnore]
		[Browsable(false)]
		public bool compenstateTimeSpecified
		{
			get
			{
				return this._compenstateTime != null;
			}
			set
			{
				bool flag = value == (this._compenstateTime == null);
				if (flag)
				{
					this._compenstateTime = (value ? new uint?(this.compenstateTime) : null);
				}
			}
		}

		// Token: 0x0600673F RID: 26431 RVA: 0x000C5424 File Offset: 0x000C3624
		private bool ShouldSerializecompenstateTime()
		{
			return this.compenstateTimeSpecified;
		}

		// Token: 0x06006740 RID: 26432 RVA: 0x000C543C File Offset: 0x000C363C
		private void ResetcompenstateTime()
		{
			this.compenstateTimeSpecified = false;
		}

		// Token: 0x06006741 RID: 26433 RVA: 0x000C5448 File Offset: 0x000C3648
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040018E7 RID: 6375
		private ulong? _partnerid;

		// Token: 0x040018E8 RID: 6376
		private uint? _last_leave_partner_time;

		// Token: 0x040018E9 RID: 6377
		private uint? _taked_chest;

		// Token: 0x040018EA RID: 6378
		private uint? _open_shop_time;

		// Token: 0x040018EB RID: 6379
		private uint? _apply_leave_time;

		// Token: 0x040018EC RID: 6380
		private bool? _chest_redpoint;

		// Token: 0x040018ED RID: 6381
		private uint? _last_update_time;

		// Token: 0x040018EE RID: 6382
		private uint? _compenstateTime;

		// Token: 0x040018EF RID: 6383
		private IExtension extensionObject;
	}
}
