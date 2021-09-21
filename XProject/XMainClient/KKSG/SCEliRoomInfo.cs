using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200070D RID: 1805
	[ProtoContract(Name = "SCEliRoomInfo")]
	[Serializable]
	public class SCEliRoomInfo : IExtensible
	{
		// Token: 0x170026D7 RID: 9943
		// (get) Token: 0x06007A8D RID: 31373 RVA: 0x000EA490 File Offset: 0x000E8690
		// (set) Token: 0x06007A8E RID: 31374 RVA: 0x000EA4BC File Offset: 0x000E86BC
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

		// Token: 0x170026D8 RID: 9944
		// (get) Token: 0x06007A8F RID: 31375 RVA: 0x000EA4CC File Offset: 0x000E86CC
		// (set) Token: 0x06007A90 RID: 31376 RVA: 0x000EA4EC File Offset: 0x000E86EC
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

		// Token: 0x06007A91 RID: 31377 RVA: 0x000EA530 File Offset: 0x000E8730
		private bool ShouldSerializeroomid()
		{
			return this.roomidSpecified;
		}

		// Token: 0x06007A92 RID: 31378 RVA: 0x000EA548 File Offset: 0x000E8748
		private void Resetroomid()
		{
			this.roomidSpecified = false;
		}

		// Token: 0x170026D9 RID: 9945
		// (get) Token: 0x06007A93 RID: 31379 RVA: 0x000EA554 File Offset: 0x000E8754
		// (set) Token: 0x06007A94 RID: 31380 RVA: 0x000EA56C File Offset: 0x000E876C
		[ProtoMember(2, IsRequired = false, Name = "team1", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SCEliTeamInfo team1
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

		// Token: 0x170026DA RID: 9946
		// (get) Token: 0x06007A95 RID: 31381 RVA: 0x000EA578 File Offset: 0x000E8778
		// (set) Token: 0x06007A96 RID: 31382 RVA: 0x000EA590 File Offset: 0x000E8790
		[ProtoMember(3, IsRequired = false, Name = "team2", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SCEliTeamInfo team2
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

		// Token: 0x170026DB RID: 9947
		// (get) Token: 0x06007A97 RID: 31383 RVA: 0x000EA59C File Offset: 0x000E879C
		// (set) Token: 0x06007A98 RID: 31384 RVA: 0x000EA5C8 File Offset: 0x000E87C8
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

		// Token: 0x170026DC RID: 9948
		// (get) Token: 0x06007A99 RID: 31385 RVA: 0x000EA5D8 File Offset: 0x000E87D8
		// (set) Token: 0x06007A9A RID: 31386 RVA: 0x000EA5F8 File Offset: 0x000E87F8
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

		// Token: 0x06007A9B RID: 31387 RVA: 0x000EA63C File Offset: 0x000E883C
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06007A9C RID: 31388 RVA: 0x000EA654 File Offset: 0x000E8854
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x170026DD RID: 9949
		// (get) Token: 0x06007A9D RID: 31389 RVA: 0x000EA660 File Offset: 0x000E8860
		// (set) Token: 0x06007A9E RID: 31390 RVA: 0x000EA68D File Offset: 0x000E888D
		[ProtoMember(5, IsRequired = false, Name = "win_stid", DataFormat = DataFormat.TwosComplement)]
		public ulong win_stid
		{
			get
			{
				return this._win_stid ?? 0UL;
			}
			set
			{
				this._win_stid = new ulong?(value);
			}
		}

		// Token: 0x170026DE RID: 9950
		// (get) Token: 0x06007A9F RID: 31391 RVA: 0x000EA69C File Offset: 0x000E889C
		// (set) Token: 0x06007AA0 RID: 31392 RVA: 0x000EA6BC File Offset: 0x000E88BC
		[XmlIgnore]
		[Browsable(false)]
		public bool win_stidSpecified
		{
			get
			{
				return this._win_stid != null;
			}
			set
			{
				bool flag = value == (this._win_stid == null);
				if (flag)
				{
					this._win_stid = (value ? new ulong?(this.win_stid) : null);
				}
			}
		}

		// Token: 0x06007AA1 RID: 31393 RVA: 0x000EA700 File Offset: 0x000E8900
		private bool ShouldSerializewin_stid()
		{
			return this.win_stidSpecified;
		}

		// Token: 0x06007AA2 RID: 31394 RVA: 0x000EA718 File Offset: 0x000E8918
		private void Resetwin_stid()
		{
			this.win_stidSpecified = false;
		}

		// Token: 0x170026DF RID: 9951
		// (get) Token: 0x06007AA3 RID: 31395 RVA: 0x000EA724 File Offset: 0x000E8924
		// (set) Token: 0x06007AA4 RID: 31396 RVA: 0x000EA750 File Offset: 0x000E8950
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

		// Token: 0x170026E0 RID: 9952
		// (get) Token: 0x06007AA5 RID: 31397 RVA: 0x000EA760 File Offset: 0x000E8960
		// (set) Token: 0x06007AA6 RID: 31398 RVA: 0x000EA780 File Offset: 0x000E8980
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

		// Token: 0x06007AA7 RID: 31399 RVA: 0x000EA7C4 File Offset: 0x000E89C4
		private bool ShouldSerializeliveid()
		{
			return this.liveidSpecified;
		}

		// Token: 0x06007AA8 RID: 31400 RVA: 0x000EA7DC File Offset: 0x000E89DC
		private void Resetliveid()
		{
			this.liveidSpecified = false;
		}

		// Token: 0x06007AA9 RID: 31401 RVA: 0x000EA7E8 File Offset: 0x000E89E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CF0 RID: 7408
		private uint? _roomid;

		// Token: 0x04001CF1 RID: 7409
		private SCEliTeamInfo _team1 = null;

		// Token: 0x04001CF2 RID: 7410
		private SCEliTeamInfo _team2 = null;

		// Token: 0x04001CF3 RID: 7411
		private LBEleRoomState? _state;

		// Token: 0x04001CF4 RID: 7412
		private ulong? _win_stid;

		// Token: 0x04001CF5 RID: 7413
		private uint? _liveid;

		// Token: 0x04001CF6 RID: 7414
		private IExtension extensionObject;
	}
}
