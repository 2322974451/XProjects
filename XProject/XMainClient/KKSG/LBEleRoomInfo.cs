using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006F9 RID: 1785
	[ProtoContract(Name = "LBEleRoomInfo")]
	[Serializable]
	public class LBEleRoomInfo : IExtensible
	{
		// Token: 0x17002616 RID: 9750
		// (get) Token: 0x06007841 RID: 30785 RVA: 0x000E6094 File Offset: 0x000E4294
		// (set) Token: 0x06007842 RID: 30786 RVA: 0x000E60C0 File Offset: 0x000E42C0
		[ProtoMember(1, IsRequired = false, Name = "roomid", DataFormat = DataFormat.TwosComplement)]
		public uint roomid
		{
			get
			{
				return this._roomid ?? 0U;
			}
			set
			{
				this._roomid = new uint?(value);
			}
		}

		// Token: 0x17002617 RID: 9751
		// (get) Token: 0x06007843 RID: 30787 RVA: 0x000E60D0 File Offset: 0x000E42D0
		// (set) Token: 0x06007844 RID: 30788 RVA: 0x000E60F0 File Offset: 0x000E42F0
		[XmlIgnore]
		[Browsable(false)]
		public bool roomidSpecified
		{
			get
			{
				return this._roomid != null;
			}
			set
			{
				bool flag = value == (this._roomid == null);
				if (flag)
				{
					this._roomid = (value ? new uint?(this.roomid) : null);
				}
			}
		}

		// Token: 0x06007845 RID: 30789 RVA: 0x000E6134 File Offset: 0x000E4334
		private bool ShouldSerializeroomid()
		{
			return this.roomidSpecified;
		}

		// Token: 0x06007846 RID: 30790 RVA: 0x000E614C File Offset: 0x000E434C
		private void Resetroomid()
		{
			this.roomidSpecified = false;
		}

		// Token: 0x17002618 RID: 9752
		// (get) Token: 0x06007847 RID: 30791 RVA: 0x000E6158 File Offset: 0x000E4358
		// (set) Token: 0x06007848 RID: 30792 RVA: 0x000E6170 File Offset: 0x000E4370
		[ProtoMember(2, IsRequired = false, Name = "team1", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LBEleTeamInfo team1
		{
			get
			{
				return this._team1;
			}
			set
			{
				this._team1 = value;
			}
		}

		// Token: 0x17002619 RID: 9753
		// (get) Token: 0x06007849 RID: 30793 RVA: 0x000E617C File Offset: 0x000E437C
		// (set) Token: 0x0600784A RID: 30794 RVA: 0x000E6194 File Offset: 0x000E4394
		[ProtoMember(3, IsRequired = false, Name = "team2", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LBEleTeamInfo team2
		{
			get
			{
				return this._team2;
			}
			set
			{
				this._team2 = value;
			}
		}

		// Token: 0x1700261A RID: 9754
		// (get) Token: 0x0600784B RID: 30795 RVA: 0x000E61A0 File Offset: 0x000E43A0
		// (set) Token: 0x0600784C RID: 30796 RVA: 0x000E61CC File Offset: 0x000E43CC
		[ProtoMember(4, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public LBEleRoomState state
		{
			get
			{
				return this._state ?? LBEleRoomState.LBEleRoomState_Idle;
			}
			set
			{
				this._state = new LBEleRoomState?(value);
			}
		}

		// Token: 0x1700261B RID: 9755
		// (get) Token: 0x0600784D RID: 30797 RVA: 0x000E61DC File Offset: 0x000E43DC
		// (set) Token: 0x0600784E RID: 30798 RVA: 0x000E61FC File Offset: 0x000E43FC
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
					this._state = (value ? new LBEleRoomState?(this.state) : null);
				}
			}
		}

		// Token: 0x0600784F RID: 30799 RVA: 0x000E6240 File Offset: 0x000E4440
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06007850 RID: 30800 RVA: 0x000E6258 File Offset: 0x000E4458
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x1700261C RID: 9756
		// (get) Token: 0x06007851 RID: 30801 RVA: 0x000E6264 File Offset: 0x000E4464
		// (set) Token: 0x06007852 RID: 30802 RVA: 0x000E6291 File Offset: 0x000E4491
		[ProtoMember(5, IsRequired = false, Name = "winleagueid", DataFormat = DataFormat.TwosComplement)]
		public ulong winleagueid
		{
			get
			{
				return this._winleagueid ?? 0UL;
			}
			set
			{
				this._winleagueid = new ulong?(value);
			}
		}

		// Token: 0x1700261D RID: 9757
		// (get) Token: 0x06007853 RID: 30803 RVA: 0x000E62A0 File Offset: 0x000E44A0
		// (set) Token: 0x06007854 RID: 30804 RVA: 0x000E62C0 File Offset: 0x000E44C0
		[XmlIgnore]
		[Browsable(false)]
		public bool winleagueidSpecified
		{
			get
			{
				return this._winleagueid != null;
			}
			set
			{
				bool flag = value == (this._winleagueid == null);
				if (flag)
				{
					this._winleagueid = (value ? new ulong?(this.winleagueid) : null);
				}
			}
		}

		// Token: 0x06007855 RID: 30805 RVA: 0x000E6304 File Offset: 0x000E4504
		private bool ShouldSerializewinleagueid()
		{
			return this.winleagueidSpecified;
		}

		// Token: 0x06007856 RID: 30806 RVA: 0x000E631C File Offset: 0x000E451C
		private void Resetwinleagueid()
		{
			this.winleagueidSpecified = false;
		}

		// Token: 0x1700261E RID: 9758
		// (get) Token: 0x06007857 RID: 30807 RVA: 0x000E6328 File Offset: 0x000E4528
		// (set) Token: 0x06007858 RID: 30808 RVA: 0x000E6354 File Offset: 0x000E4554
		[ProtoMember(6, IsRequired = false, Name = "liveid", DataFormat = DataFormat.TwosComplement)]
		public uint liveid
		{
			get
			{
				return this._liveid ?? 0U;
			}
			set
			{
				this._liveid = new uint?(value);
			}
		}

		// Token: 0x1700261F RID: 9759
		// (get) Token: 0x06007859 RID: 30809 RVA: 0x000E6364 File Offset: 0x000E4564
		// (set) Token: 0x0600785A RID: 30810 RVA: 0x000E6384 File Offset: 0x000E4584
		[XmlIgnore]
		[Browsable(false)]
		public bool liveidSpecified
		{
			get
			{
				return this._liveid != null;
			}
			set
			{
				bool flag = value == (this._liveid == null);
				if (flag)
				{
					this._liveid = (value ? new uint?(this.liveid) : null);
				}
			}
		}

		// Token: 0x0600785B RID: 30811 RVA: 0x000E63C8 File Offset: 0x000E45C8
		private bool ShouldSerializeliveid()
		{
			return this.liveidSpecified;
		}

		// Token: 0x0600785C RID: 30812 RVA: 0x000E63E0 File Offset: 0x000E45E0
		private void Resetliveid()
		{
			this.liveidSpecified = false;
		}

		// Token: 0x0600785D RID: 30813 RVA: 0x000E63EC File Offset: 0x000E45EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C70 RID: 7280
		private uint? _roomid;

		// Token: 0x04001C71 RID: 7281
		private LBEleTeamInfo _team1 = null;

		// Token: 0x04001C72 RID: 7282
		private LBEleTeamInfo _team2 = null;

		// Token: 0x04001C73 RID: 7283
		private LBEleRoomState? _state;

		// Token: 0x04001C74 RID: 7284
		private ulong? _winleagueid;

		// Token: 0x04001C75 RID: 7285
		private uint? _liveid;

		// Token: 0x04001C76 RID: 7286
		private IExtension extensionObject;
	}
}
