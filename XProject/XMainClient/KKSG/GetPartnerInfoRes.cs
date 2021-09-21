using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000306 RID: 774
	[ProtoContract(Name = "GetPartnerInfoRes")]
	[Serializable]
	public class GetPartnerInfoRes : IExtensible
	{
		// Token: 0x17000D19 RID: 3353
		// (get) Token: 0x06002A46 RID: 10822 RVA: 0x00051F24 File Offset: 0x00050124
		// (set) Token: 0x06002A47 RID: 10823 RVA: 0x00051F51 File Offset: 0x00050151
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public ulong id
		{
			get
			{
				return this._id ?? 0UL;
			}
			set
			{
				this._id = new ulong?(value);
			}
		}

		// Token: 0x17000D1A RID: 3354
		// (get) Token: 0x06002A48 RID: 10824 RVA: 0x00051F60 File Offset: 0x00050160
		// (set) Token: 0x06002A49 RID: 10825 RVA: 0x00051F80 File Offset: 0x00050180
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new ulong?(this.id) : null);
				}
			}
		}

		// Token: 0x06002A4A RID: 10826 RVA: 0x00051FC4 File Offset: 0x000501C4
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06002A4B RID: 10827 RVA: 0x00051FDC File Offset: 0x000501DC
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17000D1B RID: 3355
		// (get) Token: 0x06002A4C RID: 10828 RVA: 0x00051FE8 File Offset: 0x000501E8
		[ProtoMember(2, Name = "memberids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> memberids
		{
			get
			{
				return this._memberids;
			}
		}

		// Token: 0x17000D1C RID: 3356
		// (get) Token: 0x06002A4D RID: 10829 RVA: 0x00052000 File Offset: 0x00050200
		// (set) Token: 0x06002A4E RID: 10830 RVA: 0x0005202C File Offset: 0x0005022C
		[ProtoMember(3, IsRequired = false, Name = "degree", DataFormat = DataFormat.TwosComplement)]
		public uint degree
		{
			get
			{
				return this._degree ?? 0U;
			}
			set
			{
				this._degree = new uint?(value);
			}
		}

		// Token: 0x17000D1D RID: 3357
		// (get) Token: 0x06002A4F RID: 10831 RVA: 0x0005203C File Offset: 0x0005023C
		// (set) Token: 0x06002A50 RID: 10832 RVA: 0x0005205C File Offset: 0x0005025C
		[XmlIgnore]
		[Browsable(false)]
		public bool degreeSpecified
		{
			get
			{
				return this._degree != null;
			}
			set
			{
				bool flag = value == (this._degree == null);
				if (flag)
				{
					this._degree = (value ? new uint?(this.degree) : null);
				}
			}
		}

		// Token: 0x06002A51 RID: 10833 RVA: 0x000520A0 File Offset: 0x000502A0
		private bool ShouldSerializedegree()
		{
			return this.degreeSpecified;
		}

		// Token: 0x06002A52 RID: 10834 RVA: 0x000520B8 File Offset: 0x000502B8
		private void Resetdegree()
		{
			this.degreeSpecified = false;
		}

		// Token: 0x17000D1E RID: 3358
		// (get) Token: 0x06002A53 RID: 10835 RVA: 0x000520C4 File Offset: 0x000502C4
		// (set) Token: 0x06002A54 RID: 10836 RVA: 0x000520F0 File Offset: 0x000502F0
		[ProtoMember(4, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x17000D1F RID: 3359
		// (get) Token: 0x06002A55 RID: 10837 RVA: 0x00052100 File Offset: 0x00050300
		// (set) Token: 0x06002A56 RID: 10838 RVA: 0x00052120 File Offset: 0x00050320
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x06002A57 RID: 10839 RVA: 0x00052164 File Offset: 0x00050364
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06002A58 RID: 10840 RVA: 0x0005217C File Offset: 0x0005037C
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17000D20 RID: 3360
		// (get) Token: 0x06002A59 RID: 10841 RVA: 0x00052188 File Offset: 0x00050388
		// (set) Token: 0x06002A5A RID: 10842 RVA: 0x000521B4 File Offset: 0x000503B4
		[ProtoMember(5, IsRequired = false, Name = "last_leave_time", DataFormat = DataFormat.TwosComplement)]
		public uint last_leave_time
		{
			get
			{
				return this._last_leave_time ?? 0U;
			}
			set
			{
				this._last_leave_time = new uint?(value);
			}
		}

		// Token: 0x17000D21 RID: 3361
		// (get) Token: 0x06002A5B RID: 10843 RVA: 0x000521C4 File Offset: 0x000503C4
		// (set) Token: 0x06002A5C RID: 10844 RVA: 0x000521E4 File Offset: 0x000503E4
		[XmlIgnore]
		[Browsable(false)]
		public bool last_leave_timeSpecified
		{
			get
			{
				return this._last_leave_time != null;
			}
			set
			{
				bool flag = value == (this._last_leave_time == null);
				if (flag)
				{
					this._last_leave_time = (value ? new uint?(this.last_leave_time) : null);
				}
			}
		}

		// Token: 0x06002A5D RID: 10845 RVA: 0x00052228 File Offset: 0x00050428
		private bool ShouldSerializelast_leave_time()
		{
			return this.last_leave_timeSpecified;
		}

		// Token: 0x06002A5E RID: 10846 RVA: 0x00052240 File Offset: 0x00050440
		private void Resetlast_leave_time()
		{
			this.last_leave_timeSpecified = false;
		}

		// Token: 0x17000D22 RID: 3362
		// (get) Token: 0x06002A5F RID: 10847 RVA: 0x0005224C File Offset: 0x0005044C
		// (set) Token: 0x06002A60 RID: 10848 RVA: 0x00052278 File Offset: 0x00050478
		[ProtoMember(6, IsRequired = false, Name = "shop_redpoint", DataFormat = DataFormat.Default)]
		public bool shop_redpoint
		{
			get
			{
				return this._shop_redpoint ?? false;
			}
			set
			{
				this._shop_redpoint = new bool?(value);
			}
		}

		// Token: 0x17000D23 RID: 3363
		// (get) Token: 0x06002A61 RID: 10849 RVA: 0x00052288 File Offset: 0x00050488
		// (set) Token: 0x06002A62 RID: 10850 RVA: 0x000522A8 File Offset: 0x000504A8
		[XmlIgnore]
		[Browsable(false)]
		public bool shop_redpointSpecified
		{
			get
			{
				return this._shop_redpoint != null;
			}
			set
			{
				bool flag = value == (this._shop_redpoint == null);
				if (flag)
				{
					this._shop_redpoint = (value ? new bool?(this.shop_redpoint) : null);
				}
			}
		}

		// Token: 0x06002A63 RID: 10851 RVA: 0x000522EC File Offset: 0x000504EC
		private bool ShouldSerializeshop_redpoint()
		{
			return this.shop_redpointSpecified;
		}

		// Token: 0x06002A64 RID: 10852 RVA: 0x00052304 File Offset: 0x00050504
		private void Resetshop_redpoint()
		{
			this.shop_redpointSpecified = false;
		}

		// Token: 0x17000D24 RID: 3364
		// (get) Token: 0x06002A65 RID: 10853 RVA: 0x00052310 File Offset: 0x00050510
		// (set) Token: 0x06002A66 RID: 10854 RVA: 0x0005233C File Offset: 0x0005053C
		[ProtoMember(7, IsRequired = false, Name = "liveness_redpoint", DataFormat = DataFormat.Default)]
		public bool liveness_redpoint
		{
			get
			{
				return this._liveness_redpoint ?? false;
			}
			set
			{
				this._liveness_redpoint = new bool?(value);
			}
		}

		// Token: 0x17000D25 RID: 3365
		// (get) Token: 0x06002A67 RID: 10855 RVA: 0x0005234C File Offset: 0x0005054C
		// (set) Token: 0x06002A68 RID: 10856 RVA: 0x0005236C File Offset: 0x0005056C
		[XmlIgnore]
		[Browsable(false)]
		public bool liveness_redpointSpecified
		{
			get
			{
				return this._liveness_redpoint != null;
			}
			set
			{
				bool flag = value == (this._liveness_redpoint == null);
				if (flag)
				{
					this._liveness_redpoint = (value ? new bool?(this.liveness_redpoint) : null);
				}
			}
		}

		// Token: 0x06002A69 RID: 10857 RVA: 0x000523B0 File Offset: 0x000505B0
		private bool ShouldSerializeliveness_redpoint()
		{
			return this.liveness_redpointSpecified;
		}

		// Token: 0x06002A6A RID: 10858 RVA: 0x000523C8 File Offset: 0x000505C8
		private void Resetliveness_redpoint()
		{
			this.liveness_redpointSpecified = false;
		}

		// Token: 0x06002A6B RID: 10859 RVA: 0x000523D4 File Offset: 0x000505D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A80 RID: 2688
		private ulong? _id;

		// Token: 0x04000A81 RID: 2689
		private readonly List<ulong> _memberids = new List<ulong>();

		// Token: 0x04000A82 RID: 2690
		private uint? _degree;

		// Token: 0x04000A83 RID: 2691
		private uint? _level;

		// Token: 0x04000A84 RID: 2692
		private uint? _last_leave_time;

		// Token: 0x04000A85 RID: 2693
		private bool? _shop_redpoint;

		// Token: 0x04000A86 RID: 2694
		private bool? _liveness_redpoint;

		// Token: 0x04000A87 RID: 2695
		private IExtension extensionObject;
	}
}
