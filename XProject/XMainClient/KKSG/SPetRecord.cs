using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200057E RID: 1406
	[ProtoContract(Name = "SPetRecord")]
	[Serializable]
	public class SPetRecord : IExtensible
	{
		// Token: 0x1700165E RID: 5726
		// (get) Token: 0x060048DE RID: 18654 RVA: 0x0008A798 File Offset: 0x00088998
		// (set) Token: 0x060048DF RID: 18655 RVA: 0x0008A7C4 File Offset: 0x000889C4
		[ProtoMember(1, IsRequired = false, Name = "touchStartTime", DataFormat = DataFormat.TwosComplement)]
		public uint touchStartTime
		{
			get
			{
				return this._touchStartTime ?? 0U;
			}
			set
			{
				this._touchStartTime = new uint?(value);
			}
		}

		// Token: 0x1700165F RID: 5727
		// (get) Token: 0x060048E0 RID: 18656 RVA: 0x0008A7D4 File Offset: 0x000889D4
		// (set) Token: 0x060048E1 RID: 18657 RVA: 0x0008A7F4 File Offset: 0x000889F4
		[XmlIgnore]
		[Browsable(false)]
		public bool touchStartTimeSpecified
		{
			get
			{
				return this._touchStartTime != null;
			}
			set
			{
				bool flag = value == (this._touchStartTime == null);
				if (flag)
				{
					this._touchStartTime = (value ? new uint?(this.touchStartTime) : null);
				}
			}
		}

		// Token: 0x060048E2 RID: 18658 RVA: 0x0008A838 File Offset: 0x00088A38
		private bool ShouldSerializetouchStartTime()
		{
			return this.touchStartTimeSpecified;
		}

		// Token: 0x060048E3 RID: 18659 RVA: 0x0008A850 File Offset: 0x00088A50
		private void ResettouchStartTime()
		{
			this.touchStartTimeSpecified = false;
		}

		// Token: 0x17001660 RID: 5728
		// (get) Token: 0x060048E4 RID: 18660 RVA: 0x0008A85C File Offset: 0x00088A5C
		// (set) Token: 0x060048E5 RID: 18661 RVA: 0x0008A888 File Offset: 0x00088A88
		[ProtoMember(2, IsRequired = false, Name = "touchHourAttr", DataFormat = DataFormat.TwosComplement)]
		public uint touchHourAttr
		{
			get
			{
				return this._touchHourAttr ?? 0U;
			}
			set
			{
				this._touchHourAttr = new uint?(value);
			}
		}

		// Token: 0x17001661 RID: 5729
		// (get) Token: 0x060048E6 RID: 18662 RVA: 0x0008A898 File Offset: 0x00088A98
		// (set) Token: 0x060048E7 RID: 18663 RVA: 0x0008A8B8 File Offset: 0x00088AB8
		[XmlIgnore]
		[Browsable(false)]
		public bool touchHourAttrSpecified
		{
			get
			{
				return this._touchHourAttr != null;
			}
			set
			{
				bool flag = value == (this._touchHourAttr == null);
				if (flag)
				{
					this._touchHourAttr = (value ? new uint?(this.touchHourAttr) : null);
				}
			}
		}

		// Token: 0x060048E8 RID: 18664 RVA: 0x0008A8FC File Offset: 0x00088AFC
		private bool ShouldSerializetouchHourAttr()
		{
			return this.touchHourAttrSpecified;
		}

		// Token: 0x060048E9 RID: 18665 RVA: 0x0008A914 File Offset: 0x00088B14
		private void ResettouchHourAttr()
		{
			this.touchHourAttrSpecified = false;
		}

		// Token: 0x17001662 RID: 5730
		// (get) Token: 0x060048EA RID: 18666 RVA: 0x0008A920 File Offset: 0x00088B20
		// (set) Token: 0x060048EB RID: 18667 RVA: 0x0008A94C File Offset: 0x00088B4C
		[ProtoMember(3, IsRequired = false, Name = "touchTodayAttr", DataFormat = DataFormat.TwosComplement)]
		public uint touchTodayAttr
		{
			get
			{
				return this._touchTodayAttr ?? 0U;
			}
			set
			{
				this._touchTodayAttr = new uint?(value);
			}
		}

		// Token: 0x17001663 RID: 5731
		// (get) Token: 0x060048EC RID: 18668 RVA: 0x0008A95C File Offset: 0x00088B5C
		// (set) Token: 0x060048ED RID: 18669 RVA: 0x0008A97C File Offset: 0x00088B7C
		[XmlIgnore]
		[Browsable(false)]
		public bool touchTodayAttrSpecified
		{
			get
			{
				return this._touchTodayAttr != null;
			}
			set
			{
				bool flag = value == (this._touchTodayAttr == null);
				if (flag)
				{
					this._touchTodayAttr = (value ? new uint?(this.touchTodayAttr) : null);
				}
			}
		}

		// Token: 0x060048EE RID: 18670 RVA: 0x0008A9C0 File Offset: 0x00088BC0
		private bool ShouldSerializetouchTodayAttr()
		{
			return this.touchTodayAttrSpecified;
		}

		// Token: 0x060048EF RID: 18671 RVA: 0x0008A9D8 File Offset: 0x00088BD8
		private void ResettouchTodayAttr()
		{
			this.touchTodayAttrSpecified = false;
		}

		// Token: 0x17001664 RID: 5732
		// (get) Token: 0x060048F0 RID: 18672 RVA: 0x0008A9E4 File Offset: 0x00088BE4
		// (set) Token: 0x060048F1 RID: 18673 RVA: 0x0008AA10 File Offset: 0x00088C10
		[ProtoMember(4, IsRequired = false, Name = "followStartTime", DataFormat = DataFormat.TwosComplement)]
		public uint followStartTime
		{
			get
			{
				return this._followStartTime ?? 0U;
			}
			set
			{
				this._followStartTime = new uint?(value);
			}
		}

		// Token: 0x17001665 RID: 5733
		// (get) Token: 0x060048F2 RID: 18674 RVA: 0x0008AA20 File Offset: 0x00088C20
		// (set) Token: 0x060048F3 RID: 18675 RVA: 0x0008AA40 File Offset: 0x00088C40
		[XmlIgnore]
		[Browsable(false)]
		public bool followStartTimeSpecified
		{
			get
			{
				return this._followStartTime != null;
			}
			set
			{
				bool flag = value == (this._followStartTime == null);
				if (flag)
				{
					this._followStartTime = (value ? new uint?(this.followStartTime) : null);
				}
			}
		}

		// Token: 0x060048F4 RID: 18676 RVA: 0x0008AA84 File Offset: 0x00088C84
		private bool ShouldSerializefollowStartTime()
		{
			return this.followStartTimeSpecified;
		}

		// Token: 0x060048F5 RID: 18677 RVA: 0x0008AA9C File Offset: 0x00088C9C
		private void ResetfollowStartTime()
		{
			this.followStartTimeSpecified = false;
		}

		// Token: 0x17001666 RID: 5734
		// (get) Token: 0x060048F6 RID: 18678 RVA: 0x0008AAA8 File Offset: 0x00088CA8
		// (set) Token: 0x060048F7 RID: 18679 RVA: 0x0008AAD4 File Offset: 0x00088CD4
		[ProtoMember(5, IsRequired = false, Name = "followTodayAttr", DataFormat = DataFormat.TwosComplement)]
		public uint followTodayAttr
		{
			get
			{
				return this._followTodayAttr ?? 0U;
			}
			set
			{
				this._followTodayAttr = new uint?(value);
			}
		}

		// Token: 0x17001667 RID: 5735
		// (get) Token: 0x060048F8 RID: 18680 RVA: 0x0008AAE4 File Offset: 0x00088CE4
		// (set) Token: 0x060048F9 RID: 18681 RVA: 0x0008AB04 File Offset: 0x00088D04
		[XmlIgnore]
		[Browsable(false)]
		public bool followTodayAttrSpecified
		{
			get
			{
				return this._followTodayAttr != null;
			}
			set
			{
				bool flag = value == (this._followTodayAttr == null);
				if (flag)
				{
					this._followTodayAttr = (value ? new uint?(this.followTodayAttr) : null);
				}
			}
		}

		// Token: 0x060048FA RID: 18682 RVA: 0x0008AB48 File Offset: 0x00088D48
		private bool ShouldSerializefollowTodayAttr()
		{
			return this.followTodayAttrSpecified;
		}

		// Token: 0x060048FB RID: 18683 RVA: 0x0008AB60 File Offset: 0x00088D60
		private void ResetfollowTodayAttr()
		{
			this.followTodayAttrSpecified = false;
		}

		// Token: 0x17001668 RID: 5736
		// (get) Token: 0x060048FC RID: 18684 RVA: 0x0008AB6C File Offset: 0x00088D6C
		// (set) Token: 0x060048FD RID: 18685 RVA: 0x0008AB98 File Offset: 0x00088D98
		[ProtoMember(6, IsRequired = false, Name = "hungryStartTime", DataFormat = DataFormat.TwosComplement)]
		public uint hungryStartTime
		{
			get
			{
				return this._hungryStartTime ?? 0U;
			}
			set
			{
				this._hungryStartTime = new uint?(value);
			}
		}

		// Token: 0x17001669 RID: 5737
		// (get) Token: 0x060048FE RID: 18686 RVA: 0x0008ABA8 File Offset: 0x00088DA8
		// (set) Token: 0x060048FF RID: 18687 RVA: 0x0008ABC8 File Offset: 0x00088DC8
		[XmlIgnore]
		[Browsable(false)]
		public bool hungryStartTimeSpecified
		{
			get
			{
				return this._hungryStartTime != null;
			}
			set
			{
				bool flag = value == (this._hungryStartTime == null);
				if (flag)
				{
					this._hungryStartTime = (value ? new uint?(this.hungryStartTime) : null);
				}
			}
		}

		// Token: 0x06004900 RID: 18688 RVA: 0x0008AC0C File Offset: 0x00088E0C
		private bool ShouldSerializehungryStartTime()
		{
			return this.hungryStartTimeSpecified;
		}

		// Token: 0x06004901 RID: 18689 RVA: 0x0008AC24 File Offset: 0x00088E24
		private void ResethungryStartTime()
		{
			this.hungryStartTimeSpecified = false;
		}

		// Token: 0x1700166A RID: 5738
		// (get) Token: 0x06004902 RID: 18690 RVA: 0x0008AC30 File Offset: 0x00088E30
		// (set) Token: 0x06004903 RID: 18691 RVA: 0x0008AC5C File Offset: 0x00088E5C
		[ProtoMember(7, IsRequired = false, Name = "moodStartTime", DataFormat = DataFormat.TwosComplement)]
		public uint moodStartTime
		{
			get
			{
				return this._moodStartTime ?? 0U;
			}
			set
			{
				this._moodStartTime = new uint?(value);
			}
		}

		// Token: 0x1700166B RID: 5739
		// (get) Token: 0x06004904 RID: 18692 RVA: 0x0008AC6C File Offset: 0x00088E6C
		// (set) Token: 0x06004905 RID: 18693 RVA: 0x0008AC8C File Offset: 0x00088E8C
		[XmlIgnore]
		[Browsable(false)]
		public bool moodStartTimeSpecified
		{
			get
			{
				return this._moodStartTime != null;
			}
			set
			{
				bool flag = value == (this._moodStartTime == null);
				if (flag)
				{
					this._moodStartTime = (value ? new uint?(this.moodStartTime) : null);
				}
			}
		}

		// Token: 0x06004906 RID: 18694 RVA: 0x0008ACD0 File Offset: 0x00088ED0
		private bool ShouldSerializemoodStartTime()
		{
			return this.moodStartTimeSpecified;
		}

		// Token: 0x06004907 RID: 18695 RVA: 0x0008ACE8 File Offset: 0x00088EE8
		private void ResetmoodStartTime()
		{
			this.moodStartTimeSpecified = false;
		}

		// Token: 0x1700166C RID: 5740
		// (get) Token: 0x06004908 RID: 18696 RVA: 0x0008ACF4 File Offset: 0x00088EF4
		// (set) Token: 0x06004909 RID: 18697 RVA: 0x0008AD20 File Offset: 0x00088F20
		[ProtoMember(8, IsRequired = false, Name = "max_level", DataFormat = DataFormat.TwosComplement)]
		public uint max_level
		{
			get
			{
				return this._max_level ?? 0U;
			}
			set
			{
				this._max_level = new uint?(value);
			}
		}

		// Token: 0x1700166D RID: 5741
		// (get) Token: 0x0600490A RID: 18698 RVA: 0x0008AD30 File Offset: 0x00088F30
		// (set) Token: 0x0600490B RID: 18699 RVA: 0x0008AD50 File Offset: 0x00088F50
		[XmlIgnore]
		[Browsable(false)]
		public bool max_levelSpecified
		{
			get
			{
				return this._max_level != null;
			}
			set
			{
				bool flag = value == (this._max_level == null);
				if (flag)
				{
					this._max_level = (value ? new uint?(this.max_level) : null);
				}
			}
		}

		// Token: 0x0600490C RID: 18700 RVA: 0x0008AD94 File Offset: 0x00088F94
		private bool ShouldSerializemax_level()
		{
			return this.max_levelSpecified;
		}

		// Token: 0x0600490D RID: 18701 RVA: 0x0008ADAC File Offset: 0x00088FAC
		private void Resetmax_level()
		{
			this.max_levelSpecified = false;
		}

		// Token: 0x0600490E RID: 18702 RVA: 0x0008ADB8 File Offset: 0x00088FB8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400123A RID: 4666
		private uint? _touchStartTime;

		// Token: 0x0400123B RID: 4667
		private uint? _touchHourAttr;

		// Token: 0x0400123C RID: 4668
		private uint? _touchTodayAttr;

		// Token: 0x0400123D RID: 4669
		private uint? _followStartTime;

		// Token: 0x0400123E RID: 4670
		private uint? _followTodayAttr;

		// Token: 0x0400123F RID: 4671
		private uint? _hungryStartTime;

		// Token: 0x04001240 RID: 4672
		private uint? _moodStartTime;

		// Token: 0x04001241 RID: 4673
		private uint? _max_level;

		// Token: 0x04001242 RID: 4674
		private IExtension extensionObject;
	}
}
