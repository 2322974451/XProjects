using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200067F RID: 1663
	[ProtoContract(Name = "DragonGuildRecordData")]
	[Serializable]
	public class DragonGuildRecordData : IExtensible
	{
		// Token: 0x170021B8 RID: 8632
		// (get) Token: 0x06006A91 RID: 27281 RVA: 0x000CBCD8 File Offset: 0x000C9ED8
		// (set) Token: 0x06006A92 RID: 27282 RVA: 0x000CBD05 File Offset: 0x000C9F05
		[ProtoMember(1, IsRequired = false, Name = "dragonguildid", DataFormat = DataFormat.TwosComplement)]
		public ulong dragonguildid
		{
			get
			{
				return this._dragonguildid ?? 0UL;
			}
			set
			{
				this._dragonguildid = new ulong?(value);
			}
		}

		// Token: 0x170021B9 RID: 8633
		// (get) Token: 0x06006A93 RID: 27283 RVA: 0x000CBD14 File Offset: 0x000C9F14
		// (set) Token: 0x06006A94 RID: 27284 RVA: 0x000CBD34 File Offset: 0x000C9F34
		[XmlIgnore]
		[Browsable(false)]
		public bool dragonguildidSpecified
		{
			get
			{
				return this._dragonguildid != null;
			}
			set
			{
				bool flag = value == (this._dragonguildid == null);
				if (flag)
				{
					this._dragonguildid = (value ? new ulong?(this.dragonguildid) : null);
				}
			}
		}

		// Token: 0x06006A95 RID: 27285 RVA: 0x000CBD78 File Offset: 0x000C9F78
		private bool ShouldSerializedragonguildid()
		{
			return this.dragonguildidSpecified;
		}

		// Token: 0x06006A96 RID: 27286 RVA: 0x000CBD90 File Offset: 0x000C9F90
		private void Resetdragonguildid()
		{
			this.dragonguildidSpecified = false;
		}

		// Token: 0x170021BA RID: 8634
		// (get) Token: 0x06006A97 RID: 27287 RVA: 0x000CBD9C File Offset: 0x000C9F9C
		// (set) Token: 0x06006A98 RID: 27288 RVA: 0x000CBDC8 File Offset: 0x000C9FC8
		[ProtoMember(2, IsRequired = false, Name = "taked_chest", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170021BB RID: 8635
		// (get) Token: 0x06006A99 RID: 27289 RVA: 0x000CBDD8 File Offset: 0x000C9FD8
		// (set) Token: 0x06006A9A RID: 27290 RVA: 0x000CBDF8 File Offset: 0x000C9FF8
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

		// Token: 0x06006A9B RID: 27291 RVA: 0x000CBE3C File Offset: 0x000CA03C
		private bool ShouldSerializetaked_chest()
		{
			return this.taked_chestSpecified;
		}

		// Token: 0x06006A9C RID: 27292 RVA: 0x000CBE54 File Offset: 0x000CA054
		private void Resettaked_chest()
		{
			this.taked_chestSpecified = false;
		}

		// Token: 0x170021BC RID: 8636
		// (get) Token: 0x06006A9D RID: 27293 RVA: 0x000CBE60 File Offset: 0x000CA060
		// (set) Token: 0x06006A9E RID: 27294 RVA: 0x000CBE8C File Offset: 0x000CA08C
		[ProtoMember(3, IsRequired = false, Name = "chest_redpoint", DataFormat = DataFormat.Default)]
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

		// Token: 0x170021BD RID: 8637
		// (get) Token: 0x06006A9F RID: 27295 RVA: 0x000CBE9C File Offset: 0x000CA09C
		// (set) Token: 0x06006AA0 RID: 27296 RVA: 0x000CBEBC File Offset: 0x000CA0BC
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

		// Token: 0x06006AA1 RID: 27297 RVA: 0x000CBF00 File Offset: 0x000CA100
		private bool ShouldSerializechest_redpoint()
		{
			return this.chest_redpointSpecified;
		}

		// Token: 0x06006AA2 RID: 27298 RVA: 0x000CBF18 File Offset: 0x000CA118
		private void Resetchest_redpoint()
		{
			this.chest_redpointSpecified = false;
		}

		// Token: 0x170021BE RID: 8638
		// (get) Token: 0x06006AA3 RID: 27299 RVA: 0x000CBF24 File Offset: 0x000CA124
		// (set) Token: 0x06006AA4 RID: 27300 RVA: 0x000CBF50 File Offset: 0x000CA150
		[ProtoMember(4, IsRequired = false, Name = "last_update_time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170021BF RID: 8639
		// (get) Token: 0x06006AA5 RID: 27301 RVA: 0x000CBF60 File Offset: 0x000CA160
		// (set) Token: 0x06006AA6 RID: 27302 RVA: 0x000CBF80 File Offset: 0x000CA180
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

		// Token: 0x06006AA7 RID: 27303 RVA: 0x000CBFC4 File Offset: 0x000CA1C4
		private bool ShouldSerializelast_update_time()
		{
			return this.last_update_timeSpecified;
		}

		// Token: 0x06006AA8 RID: 27304 RVA: 0x000CBFDC File Offset: 0x000CA1DC
		private void Resetlast_update_time()
		{
			this.last_update_timeSpecified = false;
		}

		// Token: 0x170021C0 RID: 8640
		// (get) Token: 0x06006AA9 RID: 27305 RVA: 0x000CBFE8 File Offset: 0x000CA1E8
		[ProtoMember(5, Name = "tasks", DataFormat = DataFormat.Default)]
		public List<DragonGuildRoleTaskItem> tasks
		{
			get
			{
				return this._tasks;
			}
		}

		// Token: 0x170021C1 RID: 8641
		// (get) Token: 0x06006AAA RID: 27306 RVA: 0x000CC000 File Offset: 0x000CA200
		[ProtoMember(6, Name = "achivements", DataFormat = DataFormat.Default)]
		public List<DragonGuildRoleTaskItem> achivements
		{
			get
			{
				return this._achivements;
			}
		}

		// Token: 0x170021C2 RID: 8642
		// (get) Token: 0x06006AAB RID: 27307 RVA: 0x000CC018 File Offset: 0x000CA218
		// (set) Token: 0x06006AAC RID: 27308 RVA: 0x000CC044 File Offset: 0x000CA244
		[ProtoMember(7, IsRequired = false, Name = "ReceiveCount", DataFormat = DataFormat.TwosComplement)]
		public uint ReceiveCount
		{
			get
			{
				return this._ReceiveCount ?? 0U;
			}
			set
			{
				this._ReceiveCount = new uint?(value);
			}
		}

		// Token: 0x170021C3 RID: 8643
		// (get) Token: 0x06006AAD RID: 27309 RVA: 0x000CC054 File Offset: 0x000CA254
		// (set) Token: 0x06006AAE RID: 27310 RVA: 0x000CC074 File Offset: 0x000CA274
		[XmlIgnore]
		[Browsable(false)]
		public bool ReceiveCountSpecified
		{
			get
			{
				return this._ReceiveCount != null;
			}
			set
			{
				bool flag = value == (this._ReceiveCount == null);
				if (flag)
				{
					this._ReceiveCount = (value ? new uint?(this.ReceiveCount) : null);
				}
			}
		}

		// Token: 0x06006AAF RID: 27311 RVA: 0x000CC0B8 File Offset: 0x000CA2B8
		private bool ShouldSerializeReceiveCount()
		{
			return this.ReceiveCountSpecified;
		}

		// Token: 0x06006AB0 RID: 27312 RVA: 0x000CC0D0 File Offset: 0x000CA2D0
		private void ResetReceiveCount()
		{
			this.ReceiveCountSpecified = false;
		}

		// Token: 0x170021C4 RID: 8644
		// (get) Token: 0x06006AB1 RID: 27313 RVA: 0x000CC0DC File Offset: 0x000CA2DC
		// (set) Token: 0x06006AB2 RID: 27314 RVA: 0x000CC108 File Offset: 0x000CA308
		[ProtoMember(8, IsRequired = false, Name = "taskRefreshTime", DataFormat = DataFormat.TwosComplement)]
		public uint taskRefreshTime
		{
			get
			{
				return this._taskRefreshTime ?? 0U;
			}
			set
			{
				this._taskRefreshTime = new uint?(value);
			}
		}

		// Token: 0x170021C5 RID: 8645
		// (get) Token: 0x06006AB3 RID: 27315 RVA: 0x000CC118 File Offset: 0x000CA318
		// (set) Token: 0x06006AB4 RID: 27316 RVA: 0x000CC138 File Offset: 0x000CA338
		[XmlIgnore]
		[Browsable(false)]
		public bool taskRefreshTimeSpecified
		{
			get
			{
				return this._taskRefreshTime != null;
			}
			set
			{
				bool flag = value == (this._taskRefreshTime == null);
				if (flag)
				{
					this._taskRefreshTime = (value ? new uint?(this.taskRefreshTime) : null);
				}
			}
		}

		// Token: 0x06006AB5 RID: 27317 RVA: 0x000CC17C File Offset: 0x000CA37C
		private bool ShouldSerializetaskRefreshTime()
		{
			return this.taskRefreshTimeSpecified;
		}

		// Token: 0x06006AB6 RID: 27318 RVA: 0x000CC194 File Offset: 0x000CA394
		private void ResettaskRefreshTime()
		{
			this.taskRefreshTimeSpecified = false;
		}

		// Token: 0x06006AB7 RID: 27319 RVA: 0x000CC1A0 File Offset: 0x000CA3A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019A9 RID: 6569
		private ulong? _dragonguildid;

		// Token: 0x040019AA RID: 6570
		private uint? _taked_chest;

		// Token: 0x040019AB RID: 6571
		private bool? _chest_redpoint;

		// Token: 0x040019AC RID: 6572
		private uint? _last_update_time;

		// Token: 0x040019AD RID: 6573
		private readonly List<DragonGuildRoleTaskItem> _tasks = new List<DragonGuildRoleTaskItem>();

		// Token: 0x040019AE RID: 6574
		private readonly List<DragonGuildRoleTaskItem> _achivements = new List<DragonGuildRoleTaskItem>();

		// Token: 0x040019AF RID: 6575
		private uint? _ReceiveCount;

		// Token: 0x040019B0 RID: 6576
		private uint? _taskRefreshTime;

		// Token: 0x040019B1 RID: 6577
		private IExtension extensionObject;
	}
}
