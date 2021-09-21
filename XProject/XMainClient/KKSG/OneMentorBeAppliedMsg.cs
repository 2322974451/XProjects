using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006D9 RID: 1753
	[ProtoContract(Name = "OneMentorBeAppliedMsg")]
	[Serializable]
	public class OneMentorBeAppliedMsg : IExtensible
	{
		// Token: 0x170024E4 RID: 9444
		// (get) Token: 0x06007484 RID: 29828 RVA: 0x000DEEE0 File Offset: 0x000DD0E0
		// (set) Token: 0x06007485 RID: 29829 RVA: 0x000DEF0C File Offset: 0x000DD10C
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public MentorMsgApplyType type
		{
			get
			{
				return this._type ?? MentorMsgApplyType.MentorMsgApplyMaster;
			}
			set
			{
				this._type = new MentorMsgApplyType?(value);
			}
		}

		// Token: 0x170024E5 RID: 9445
		// (get) Token: 0x06007486 RID: 29830 RVA: 0x000DEF1C File Offset: 0x000DD11C
		// (set) Token: 0x06007487 RID: 29831 RVA: 0x000DEF3C File Offset: 0x000DD13C
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new MentorMsgApplyType?(this.type) : null);
				}
			}
		}

		// Token: 0x06007488 RID: 29832 RVA: 0x000DEF80 File Offset: 0x000DD180
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06007489 RID: 29833 RVA: 0x000DEF98 File Offset: 0x000DD198
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170024E6 RID: 9446
		// (get) Token: 0x0600748A RID: 29834 RVA: 0x000DEFA4 File Offset: 0x000DD1A4
		// (set) Token: 0x0600748B RID: 29835 RVA: 0x000DEFD0 File Offset: 0x000DD1D0
		[ProtoMember(2, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public int time
		{
			get
			{
				return this._time ?? 0;
			}
			set
			{
				this._time = new int?(value);
			}
		}

		// Token: 0x170024E7 RID: 9447
		// (get) Token: 0x0600748C RID: 29836 RVA: 0x000DEFE0 File Offset: 0x000DD1E0
		// (set) Token: 0x0600748D RID: 29837 RVA: 0x000DF000 File Offset: 0x000DD200
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
					this._time = (value ? new int?(this.time) : null);
				}
			}
		}

		// Token: 0x0600748E RID: 29838 RVA: 0x000DF044 File Offset: 0x000DD244
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x0600748F RID: 29839 RVA: 0x000DF05C File Offset: 0x000DD25C
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x170024E8 RID: 9448
		// (get) Token: 0x06007490 RID: 29840 RVA: 0x000DF068 File Offset: 0x000DD268
		// (set) Token: 0x06007491 RID: 29841 RVA: 0x000DF080 File Offset: 0x000DD280
		[ProtoMember(3, IsRequired = false, Name = "roleBrief", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleBriefInfo roleBrief
		{
			get
			{
				return this._roleBrief;
			}
			set
			{
				this._roleBrief = value;
			}
		}

		// Token: 0x170024E9 RID: 9449
		// (get) Token: 0x06007492 RID: 29842 RVA: 0x000DF08C File Offset: 0x000DD28C
		// (set) Token: 0x06007493 RID: 29843 RVA: 0x000DF0B8 File Offset: 0x000DD2B8
		[ProtoMember(4, IsRequired = false, Name = "reportTaskID", DataFormat = DataFormat.TwosComplement)]
		public int reportTaskID
		{
			get
			{
				return this._reportTaskID ?? 0;
			}
			set
			{
				this._reportTaskID = new int?(value);
			}
		}

		// Token: 0x170024EA RID: 9450
		// (get) Token: 0x06007494 RID: 29844 RVA: 0x000DF0C8 File Offset: 0x000DD2C8
		// (set) Token: 0x06007495 RID: 29845 RVA: 0x000DF0E8 File Offset: 0x000DD2E8
		[XmlIgnore]
		[Browsable(false)]
		public bool reportTaskIDSpecified
		{
			get
			{
				return this._reportTaskID != null;
			}
			set
			{
				bool flag = value == (this._reportTaskID == null);
				if (flag)
				{
					this._reportTaskID = (value ? new int?(this.reportTaskID) : null);
				}
			}
		}

		// Token: 0x06007496 RID: 29846 RVA: 0x000DF12C File Offset: 0x000DD32C
		private bool ShouldSerializereportTaskID()
		{
			return this.reportTaskIDSpecified;
		}

		// Token: 0x06007497 RID: 29847 RVA: 0x000DF144 File Offset: 0x000DD344
		private void ResetreportTaskID()
		{
			this.reportTaskIDSpecified = false;
		}

		// Token: 0x06007498 RID: 29848 RVA: 0x000DF150 File Offset: 0x000DD350
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BAF RID: 7087
		private MentorMsgApplyType? _type;

		// Token: 0x04001BB0 RID: 7088
		private int? _time;

		// Token: 0x04001BB1 RID: 7089
		private RoleBriefInfo _roleBrief = null;

		// Token: 0x04001BB2 RID: 7090
		private int? _reportTaskID;

		// Token: 0x04001BB3 RID: 7091
		private IExtension extensionObject;
	}
}
