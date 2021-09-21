using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002AE RID: 686
	[ProtoContract(Name = "ResWarGuildBrief")]
	[Serializable]
	public class ResWarGuildBrief : IExtensible
	{
		// Token: 0x17000BDE RID: 3038
		// (get) Token: 0x0600262E RID: 9774 RVA: 0x0004A548 File Offset: 0x00048748
		// (set) Token: 0x0600262F RID: 9775 RVA: 0x0004A574 File Offset: 0x00048774
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000BDF RID: 3039
		// (get) Token: 0x06002630 RID: 9776 RVA: 0x0004A584 File Offset: 0x00048784
		// (set) Token: 0x06002631 RID: 9777 RVA: 0x0004A5A4 File Offset: 0x000487A4
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x06002632 RID: 9778 RVA: 0x0004A5E8 File Offset: 0x000487E8
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06002633 RID: 9779 RVA: 0x0004A600 File Offset: 0x00048800
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000BE0 RID: 3040
		// (get) Token: 0x06002634 RID: 9780 RVA: 0x0004A60C File Offset: 0x0004880C
		// (set) Token: 0x06002635 RID: 9781 RVA: 0x0004A639 File Offset: 0x00048839
		[ProtoMember(2, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		// Token: 0x17000BE1 RID: 3041
		// (get) Token: 0x06002636 RID: 9782 RVA: 0x0004A648 File Offset: 0x00048848
		// (set) Token: 0x06002637 RID: 9783 RVA: 0x0004A668 File Offset: 0x00048868
		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		// Token: 0x06002638 RID: 9784 RVA: 0x0004A6AC File Offset: 0x000488AC
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x06002639 RID: 9785 RVA: 0x0004A6C4 File Offset: 0x000488C4
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x17000BE2 RID: 3042
		// (get) Token: 0x0600263A RID: 9786 RVA: 0x0004A6D0 File Offset: 0x000488D0
		// (set) Token: 0x0600263B RID: 9787 RVA: 0x0004A6FC File Offset: 0x000488FC
		[ProtoMember(3, IsRequired = false, Name = "cd", DataFormat = DataFormat.TwosComplement)]
		public uint cd
		{
			get
			{
				return this._cd ?? 0U;
			}
			set
			{
				this._cd = new uint?(value);
			}
		}

		// Token: 0x17000BE3 RID: 3043
		// (get) Token: 0x0600263C RID: 9788 RVA: 0x0004A70C File Offset: 0x0004890C
		// (set) Token: 0x0600263D RID: 9789 RVA: 0x0004A72C File Offset: 0x0004892C
		[XmlIgnore]
		[Browsable(false)]
		public bool cdSpecified
		{
			get
			{
				return this._cd != null;
			}
			set
			{
				bool flag = value == (this._cd == null);
				if (flag)
				{
					this._cd = (value ? new uint?(this.cd) : null);
				}
			}
		}

		// Token: 0x0600263E RID: 9790 RVA: 0x0004A770 File Offset: 0x00048970
		private bool ShouldSerializecd()
		{
			return this.cdSpecified;
		}

		// Token: 0x0600263F RID: 9791 RVA: 0x0004A788 File Offset: 0x00048988
		private void Resetcd()
		{
			this.cdSpecified = false;
		}

		// Token: 0x17000BE4 RID: 3044
		// (get) Token: 0x06002640 RID: 9792 RVA: 0x0004A794 File Offset: 0x00048994
		// (set) Token: 0x06002641 RID: 9793 RVA: 0x0004A7C0 File Offset: 0x000489C0
		[ProtoMember(4, IsRequired = false, Name = "cardcd", DataFormat = DataFormat.TwosComplement)]
		public uint cardcd
		{
			get
			{
				return this._cardcd ?? 0U;
			}
			set
			{
				this._cardcd = new uint?(value);
			}
		}

		// Token: 0x17000BE5 RID: 3045
		// (get) Token: 0x06002642 RID: 9794 RVA: 0x0004A7D0 File Offset: 0x000489D0
		// (set) Token: 0x06002643 RID: 9795 RVA: 0x0004A7F0 File Offset: 0x000489F0
		[XmlIgnore]
		[Browsable(false)]
		public bool cardcdSpecified
		{
			get
			{
				return this._cardcd != null;
			}
			set
			{
				bool flag = value == (this._cardcd == null);
				if (flag)
				{
					this._cardcd = (value ? new uint?(this.cardcd) : null);
				}
			}
		}

		// Token: 0x06002644 RID: 9796 RVA: 0x0004A834 File Offset: 0x00048A34
		private bool ShouldSerializecardcd()
		{
			return this.cardcdSpecified;
		}

		// Token: 0x06002645 RID: 9797 RVA: 0x0004A84C File Offset: 0x00048A4C
		private void Resetcardcd()
		{
			this.cardcdSpecified = false;
		}

		// Token: 0x17000BE6 RID: 3046
		// (get) Token: 0x06002646 RID: 9798 RVA: 0x0004A858 File Offset: 0x00048A58
		[ProtoMember(5, Name = "item", DataFormat = DataFormat.Default)]
		public List<GuildBuffItem> item
		{
			get
			{
				return this._item;
			}
		}

		// Token: 0x17000BE7 RID: 3047
		// (get) Token: 0x06002647 RID: 9799 RVA: 0x0004A870 File Offset: 0x00048A70
		[ProtoMember(6, Name = "record", DataFormat = DataFormat.Default)]
		public List<GuildBuffRecord> record
		{
			get
			{
				return this._record;
			}
		}

		// Token: 0x17000BE8 RID: 3048
		// (get) Token: 0x06002648 RID: 9800 RVA: 0x0004A888 File Offset: 0x00048A88
		[ProtoMember(7, Name = "mineid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> mineid
		{
			get
			{
				return this._mineid;
			}
		}

		// Token: 0x17000BE9 RID: 3049
		// (get) Token: 0x06002649 RID: 9801 RVA: 0x0004A8A0 File Offset: 0x00048AA0
		[ProtoMember(8, Name = "chatinfo", DataFormat = DataFormat.Default)]
		public List<ChatInfo> chatinfo
		{
			get
			{
				return this._chatinfo;
			}
		}

		// Token: 0x17000BEA RID: 3050
		// (get) Token: 0x0600264A RID: 9802 RVA: 0x0004A8B8 File Offset: 0x00048AB8
		// (set) Token: 0x0600264B RID: 9803 RVA: 0x0004A8E4 File Offset: 0x00048AE4
		[ProtoMember(9, IsRequired = false, Name = "totalcd", DataFormat = DataFormat.TwosComplement)]
		public uint totalcd
		{
			get
			{
				return this._totalcd ?? 0U;
			}
			set
			{
				this._totalcd = new uint?(value);
			}
		}

		// Token: 0x17000BEB RID: 3051
		// (get) Token: 0x0600264C RID: 9804 RVA: 0x0004A8F4 File Offset: 0x00048AF4
		// (set) Token: 0x0600264D RID: 9805 RVA: 0x0004A914 File Offset: 0x00048B14
		[XmlIgnore]
		[Browsable(false)]
		public bool totalcdSpecified
		{
			get
			{
				return this._totalcd != null;
			}
			set
			{
				bool flag = value == (this._totalcd == null);
				if (flag)
				{
					this._totalcd = (value ? new uint?(this.totalcd) : null);
				}
			}
		}

		// Token: 0x0600264E RID: 9806 RVA: 0x0004A958 File Offset: 0x00048B58
		private bool ShouldSerializetotalcd()
		{
			return this.totalcdSpecified;
		}

		// Token: 0x0600264F RID: 9807 RVA: 0x0004A970 File Offset: 0x00048B70
		private void Resettotalcd()
		{
			this.totalcdSpecified = false;
		}

		// Token: 0x17000BEC RID: 3052
		// (get) Token: 0x06002650 RID: 9808 RVA: 0x0004A97C File Offset: 0x00048B7C
		// (set) Token: 0x06002651 RID: 9809 RVA: 0x0004A9A8 File Offset: 0x00048BA8
		[ProtoMember(10, IsRequired = false, Name = "timecoutdown", DataFormat = DataFormat.TwosComplement)]
		public uint timecoutdown
		{
			get
			{
				return this._timecoutdown ?? 0U;
			}
			set
			{
				this._timecoutdown = new uint?(value);
			}
		}

		// Token: 0x17000BED RID: 3053
		// (get) Token: 0x06002652 RID: 9810 RVA: 0x0004A9B8 File Offset: 0x00048BB8
		// (set) Token: 0x06002653 RID: 9811 RVA: 0x0004A9D8 File Offset: 0x00048BD8
		[XmlIgnore]
		[Browsable(false)]
		public bool timecoutdownSpecified
		{
			get
			{
				return this._timecoutdown != null;
			}
			set
			{
				bool flag = value == (this._timecoutdown == null);
				if (flag)
				{
					this._timecoutdown = (value ? new uint?(this.timecoutdown) : null);
				}
			}
		}

		// Token: 0x06002654 RID: 9812 RVA: 0x0004AA1C File Offset: 0x00048C1C
		private bool ShouldSerializetimecoutdown()
		{
			return this.timecoutdownSpecified;
		}

		// Token: 0x06002655 RID: 9813 RVA: 0x0004AA34 File Offset: 0x00048C34
		private void Resettimecoutdown()
		{
			this.timecoutdownSpecified = false;
		}

		// Token: 0x17000BEE RID: 3054
		// (get) Token: 0x06002656 RID: 9814 RVA: 0x0004AA40 File Offset: 0x00048C40
		// (set) Token: 0x06002657 RID: 9815 RVA: 0x0004AA6C File Offset: 0x00048C6C
		[ProtoMember(11, IsRequired = false, Name = "timetype", DataFormat = DataFormat.TwosComplement)]
		public uint timetype
		{
			get
			{
				return this._timetype ?? 0U;
			}
			set
			{
				this._timetype = new uint?(value);
			}
		}

		// Token: 0x17000BEF RID: 3055
		// (get) Token: 0x06002658 RID: 9816 RVA: 0x0004AA7C File Offset: 0x00048C7C
		// (set) Token: 0x06002659 RID: 9817 RVA: 0x0004AA9C File Offset: 0x00048C9C
		[XmlIgnore]
		[Browsable(false)]
		public bool timetypeSpecified
		{
			get
			{
				return this._timetype != null;
			}
			set
			{
				bool flag = value == (this._timetype == null);
				if (flag)
				{
					this._timetype = (value ? new uint?(this.timetype) : null);
				}
			}
		}

		// Token: 0x0600265A RID: 9818 RVA: 0x0004AAE0 File Offset: 0x00048CE0
		private bool ShouldSerializetimetype()
		{
			return this.timetypeSpecified;
		}

		// Token: 0x0600265B RID: 9819 RVA: 0x0004AAF8 File Offset: 0x00048CF8
		private void Resettimetype()
		{
			this.timetypeSpecified = false;
		}

		// Token: 0x17000BF0 RID: 3056
		// (get) Token: 0x0600265C RID: 9820 RVA: 0x0004AB04 File Offset: 0x00048D04
		// (set) Token: 0x0600265D RID: 9821 RVA: 0x0004AB1C File Offset: 0x00048D1C
		[ProtoMember(12, IsRequired = false, Name = "rankinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ResWarRankSimpleInfo rankinfo
		{
			get
			{
				return this._rankinfo;
			}
			set
			{
				this._rankinfo = value;
			}
		}

		// Token: 0x17000BF1 RID: 3057
		// (get) Token: 0x0600265E RID: 9822 RVA: 0x0004AB28 File Offset: 0x00048D28
		[ProtoMember(13, Name = "buffinfo", DataFormat = DataFormat.Default)]
		public List<GuildBuffSimpleInfo> buffinfo
		{
			get
			{
				return this._buffinfo;
			}
		}

		// Token: 0x17000BF2 RID: 3058
		// (get) Token: 0x0600265F RID: 9823 RVA: 0x0004AB40 File Offset: 0x00048D40
		[ProtoMember(14, Name = "buffid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> buffid
		{
			get
			{
				return this._buffid;
			}
		}

		// Token: 0x06002660 RID: 9824 RVA: 0x0004AB58 File Offset: 0x00048D58
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000977 RID: 2423
		private ErrorCode? _error;

		// Token: 0x04000978 RID: 2424
		private ulong? _guildid;

		// Token: 0x04000979 RID: 2425
		private uint? _cd;

		// Token: 0x0400097A RID: 2426
		private uint? _cardcd;

		// Token: 0x0400097B RID: 2427
		private readonly List<GuildBuffItem> _item = new List<GuildBuffItem>();

		// Token: 0x0400097C RID: 2428
		private readonly List<GuildBuffRecord> _record = new List<GuildBuffRecord>();

		// Token: 0x0400097D RID: 2429
		private readonly List<uint> _mineid = new List<uint>();

		// Token: 0x0400097E RID: 2430
		private readonly List<ChatInfo> _chatinfo = new List<ChatInfo>();

		// Token: 0x0400097F RID: 2431
		private uint? _totalcd;

		// Token: 0x04000980 RID: 2432
		private uint? _timecoutdown;

		// Token: 0x04000981 RID: 2433
		private uint? _timetype;

		// Token: 0x04000982 RID: 2434
		private ResWarRankSimpleInfo _rankinfo = null;

		// Token: 0x04000983 RID: 2435
		private readonly List<GuildBuffSimpleInfo> _buffinfo = new List<GuildBuffSimpleInfo>();

		// Token: 0x04000984 RID: 2436
		private readonly List<uint> _buffid = new List<uint>();

		// Token: 0x04000985 RID: 2437
		private IExtension extensionObject;
	}
}
