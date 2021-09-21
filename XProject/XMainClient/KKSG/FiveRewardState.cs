using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000128 RID: 296
	[ProtoContract(Name = "FiveRewardState")]
	[Serializable]
	public class FiveRewardState : IExtensible
	{
		// Token: 0x170005D6 RID: 1494
		// (get) Token: 0x0600123F RID: 4671 RVA: 0x000250F4 File Offset: 0x000232F4
		// (set) Token: 0x06001240 RID: 4672 RVA: 0x00025120 File Offset: 0x00023320
		[ProtoMember(1, IsRequired = false, Name = "logindaycount", DataFormat = DataFormat.TwosComplement)]
		public uint logindaycount
		{
			get
			{
				return this._logindaycount ?? 0U;
			}
			set
			{
				this._logindaycount = new uint?(value);
			}
		}

		// Token: 0x170005D7 RID: 1495
		// (get) Token: 0x06001241 RID: 4673 RVA: 0x00025130 File Offset: 0x00023330
		// (set) Token: 0x06001242 RID: 4674 RVA: 0x00025150 File Offset: 0x00023350
		[XmlIgnore]
		[Browsable(false)]
		public bool logindaycountSpecified
		{
			get
			{
				return this._logindaycount != null;
			}
			set
			{
				bool flag = value == (this._logindaycount == null);
				if (flag)
				{
					this._logindaycount = (value ? new uint?(this.logindaycount) : null);
				}
			}
		}

		// Token: 0x06001243 RID: 4675 RVA: 0x00025194 File Offset: 0x00023394
		private bool ShouldSerializelogindaycount()
		{
			return this.logindaycountSpecified;
		}

		// Token: 0x06001244 RID: 4676 RVA: 0x000251AC File Offset: 0x000233AC
		private void Resetlogindaycount()
		{
			this.logindaycountSpecified = false;
		}

		// Token: 0x170005D8 RID: 1496
		// (get) Token: 0x06001245 RID: 4677 RVA: 0x000251B8 File Offset: 0x000233B8
		// (set) Token: 0x06001246 RID: 4678 RVA: 0x000251E4 File Offset: 0x000233E4
		[ProtoMember(2, IsRequired = false, Name = "fivedayRS", DataFormat = DataFormat.TwosComplement)]
		public LoginRewardState fivedayRS
		{
			get
			{
				return this._fivedayRS ?? LoginRewardState.LOGINRS_CANNOT;
			}
			set
			{
				this._fivedayRS = new LoginRewardState?(value);
			}
		}

		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x06001247 RID: 4679 RVA: 0x000251F4 File Offset: 0x000233F4
		// (set) Token: 0x06001248 RID: 4680 RVA: 0x00025214 File Offset: 0x00023414
		[XmlIgnore]
		[Browsable(false)]
		public bool fivedayRSSpecified
		{
			get
			{
				return this._fivedayRS != null;
			}
			set
			{
				bool flag = value == (this._fivedayRS == null);
				if (flag)
				{
					this._fivedayRS = (value ? new LoginRewardState?(this.fivedayRS) : null);
				}
			}
		}

		// Token: 0x06001249 RID: 4681 RVA: 0x00025258 File Offset: 0x00023458
		private bool ShouldSerializefivedayRS()
		{
			return this.fivedayRSSpecified;
		}

		// Token: 0x0600124A RID: 4682 RVA: 0x00025270 File Offset: 0x00023470
		private void ResetfivedayRS()
		{
			this.fivedayRSSpecified = false;
		}

		// Token: 0x170005DA RID: 1498
		// (get) Token: 0x0600124B RID: 4683 RVA: 0x0002527C File Offset: 0x0002347C
		// (set) Token: 0x0600124C RID: 4684 RVA: 0x000252A8 File Offset: 0x000234A8
		[ProtoMember(3, IsRequired = false, Name = "twodayRS", DataFormat = DataFormat.TwosComplement)]
		public LoginRewardState twodayRS
		{
			get
			{
				return this._twodayRS ?? LoginRewardState.LOGINRS_CANNOT;
			}
			set
			{
				this._twodayRS = new LoginRewardState?(value);
			}
		}

		// Token: 0x170005DB RID: 1499
		// (get) Token: 0x0600124D RID: 4685 RVA: 0x000252B8 File Offset: 0x000234B8
		// (set) Token: 0x0600124E RID: 4686 RVA: 0x000252D8 File Offset: 0x000234D8
		[XmlIgnore]
		[Browsable(false)]
		public bool twodayRSSpecified
		{
			get
			{
				return this._twodayRS != null;
			}
			set
			{
				bool flag = value == (this._twodayRS == null);
				if (flag)
				{
					this._twodayRS = (value ? new LoginRewardState?(this.twodayRS) : null);
				}
			}
		}

		// Token: 0x0600124F RID: 4687 RVA: 0x0002531C File Offset: 0x0002351C
		private bool ShouldSerializetwodayRS()
		{
			return this.twodayRSSpecified;
		}

		// Token: 0x06001250 RID: 4688 RVA: 0x00025334 File Offset: 0x00023534
		private void ResettwodayRS()
		{
			this.twodayRSSpecified = false;
		}

		// Token: 0x170005DC RID: 1500
		// (get) Token: 0x06001251 RID: 4689 RVA: 0x00025340 File Offset: 0x00023540
		// (set) Token: 0x06001252 RID: 4690 RVA: 0x0002536C File Offset: 0x0002356C
		[ProtoMember(4, IsRequired = false, Name = "threedayRS", DataFormat = DataFormat.TwosComplement)]
		public LoginRewardState threedayRS
		{
			get
			{
				return this._threedayRS ?? LoginRewardState.LOGINRS_CANNOT;
			}
			set
			{
				this._threedayRS = new LoginRewardState?(value);
			}
		}

		// Token: 0x170005DD RID: 1501
		// (get) Token: 0x06001253 RID: 4691 RVA: 0x0002537C File Offset: 0x0002357C
		// (set) Token: 0x06001254 RID: 4692 RVA: 0x0002539C File Offset: 0x0002359C
		[XmlIgnore]
		[Browsable(false)]
		public bool threedayRSSpecified
		{
			get
			{
				return this._threedayRS != null;
			}
			set
			{
				bool flag = value == (this._threedayRS == null);
				if (flag)
				{
					this._threedayRS = (value ? new LoginRewardState?(this.threedayRS) : null);
				}
			}
		}

		// Token: 0x06001255 RID: 4693 RVA: 0x000253E0 File Offset: 0x000235E0
		private bool ShouldSerializethreedayRS()
		{
			return this.threedayRSSpecified;
		}

		// Token: 0x06001256 RID: 4694 RVA: 0x000253F8 File Offset: 0x000235F8
		private void ResetthreedayRS()
		{
			this.threedayRSSpecified = false;
		}

		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x06001257 RID: 4695 RVA: 0x00025404 File Offset: 0x00023604
		// (set) Token: 0x06001258 RID: 4696 RVA: 0x00025430 File Offset: 0x00023630
		[ProtoMember(5, IsRequired = false, Name = "sevendayRS", DataFormat = DataFormat.TwosComplement)]
		public LoginRewardState sevendayRS
		{
			get
			{
				return this._sevendayRS ?? LoginRewardState.LOGINRS_CANNOT;
			}
			set
			{
				this._sevendayRS = new LoginRewardState?(value);
			}
		}

		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x06001259 RID: 4697 RVA: 0x00025440 File Offset: 0x00023640
		// (set) Token: 0x0600125A RID: 4698 RVA: 0x00025460 File Offset: 0x00023660
		[XmlIgnore]
		[Browsable(false)]
		public bool sevendayRSSpecified
		{
			get
			{
				return this._sevendayRS != null;
			}
			set
			{
				bool flag = value == (this._sevendayRS == null);
				if (flag)
				{
					this._sevendayRS = (value ? new LoginRewardState?(this.sevendayRS) : null);
				}
			}
		}

		// Token: 0x0600125B RID: 4699 RVA: 0x000254A4 File Offset: 0x000236A4
		private bool ShouldSerializesevendayRS()
		{
			return this.sevendayRSSpecified;
		}

		// Token: 0x0600125C RID: 4700 RVA: 0x000254BC File Offset: 0x000236BC
		private void ResetsevendayRS()
		{
			this.sevendayRSSpecified = false;
		}

		// Token: 0x0600125D RID: 4701 RVA: 0x000254C8 File Offset: 0x000236C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000492 RID: 1170
		private uint? _logindaycount;

		// Token: 0x04000493 RID: 1171
		private LoginRewardState? _fivedayRS;

		// Token: 0x04000494 RID: 1172
		private LoginRewardState? _twodayRS;

		// Token: 0x04000495 RID: 1173
		private LoginRewardState? _threedayRS;

		// Token: 0x04000496 RID: 1174
		private LoginRewardState? _sevendayRS;

		// Token: 0x04000497 RID: 1175
		private IExtension extensionObject;
	}
}
