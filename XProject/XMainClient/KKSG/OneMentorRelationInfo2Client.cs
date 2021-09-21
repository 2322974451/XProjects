using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006D3 RID: 1747
	[ProtoContract(Name = "OneMentorRelationInfo2Client")]
	[Serializable]
	public class OneMentorRelationInfo2Client : IExtensible
	{
		// Token: 0x170024BB RID: 9403
		// (get) Token: 0x06007408 RID: 29704 RVA: 0x000DE048 File Offset: 0x000DC248
		// (set) Token: 0x06007409 RID: 29705 RVA: 0x000DE060 File Offset: 0x000DC260
		[ProtoMember(1, IsRequired = false, Name = "roleInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleBriefInfo roleInfo
		{
			get
			{
				return this._roleInfo;
			}
			set
			{
				this._roleInfo = value;
			}
		}

		// Token: 0x170024BC RID: 9404
		// (get) Token: 0x0600740A RID: 29706 RVA: 0x000DE06C File Offset: 0x000DC26C
		[ProtoMember(2, Name = "relationlist", DataFormat = DataFormat.Default)]
		public List<MentorRelationStatusData> relationlist
		{
			get
			{
				return this._relationlist;
			}
		}

		// Token: 0x170024BD RID: 9405
		// (get) Token: 0x0600740B RID: 29707 RVA: 0x000DE084 File Offset: 0x000DC284
		// (set) Token: 0x0600740C RID: 29708 RVA: 0x000DE0B0 File Offset: 0x000DC2B0
		[ProtoMember(3, IsRequired = false, Name = "pos", DataFormat = DataFormat.TwosComplement)]
		public int pos
		{
			get
			{
				return this._pos ?? 0;
			}
			set
			{
				this._pos = new int?(value);
			}
		}

		// Token: 0x170024BE RID: 9406
		// (get) Token: 0x0600740D RID: 29709 RVA: 0x000DE0C0 File Offset: 0x000DC2C0
		// (set) Token: 0x0600740E RID: 29710 RVA: 0x000DE0E0 File Offset: 0x000DC2E0
		[XmlIgnore]
		[Browsable(false)]
		public bool posSpecified
		{
			get
			{
				return this._pos != null;
			}
			set
			{
				bool flag = value == (this._pos == null);
				if (flag)
				{
					this._pos = (value ? new int?(this.pos) : null);
				}
			}
		}

		// Token: 0x0600740F RID: 29711 RVA: 0x000DE124 File Offset: 0x000DC324
		private bool ShouldSerializepos()
		{
			return this.posSpecified;
		}

		// Token: 0x06007410 RID: 29712 RVA: 0x000DE13C File Offset: 0x000DC33C
		private void Resetpos()
		{
			this.posSpecified = false;
		}

		// Token: 0x170024BF RID: 9407
		// (get) Token: 0x06007411 RID: 29713 RVA: 0x000DE148 File Offset: 0x000DC348
		[ProtoMember(4, Name = "studentTaskList", DataFormat = DataFormat.Default)]
		public List<OneMentorTaskInfo> studentTaskList
		{
			get
			{
				return this._studentTaskList;
			}
		}

		// Token: 0x170024C0 RID: 9408
		// (get) Token: 0x06007412 RID: 29714 RVA: 0x000DE160 File Offset: 0x000DC360
		// (set) Token: 0x06007413 RID: 29715 RVA: 0x000DE18C File Offset: 0x000DC38C
		[ProtoMember(5, IsRequired = false, Name = "inheritStatus", DataFormat = DataFormat.TwosComplement)]
		public EMentorTaskStatus inheritStatus
		{
			get
			{
				return this._inheritStatus ?? EMentorTaskStatus.EMentorTask_UnComplete;
			}
			set
			{
				this._inheritStatus = new EMentorTaskStatus?(value);
			}
		}

		// Token: 0x170024C1 RID: 9409
		// (get) Token: 0x06007414 RID: 29716 RVA: 0x000DE19C File Offset: 0x000DC39C
		// (set) Token: 0x06007415 RID: 29717 RVA: 0x000DE1BC File Offset: 0x000DC3BC
		[XmlIgnore]
		[Browsable(false)]
		public bool inheritStatusSpecified
		{
			get
			{
				return this._inheritStatus != null;
			}
			set
			{
				bool flag = value == (this._inheritStatus == null);
				if (flag)
				{
					this._inheritStatus = (value ? new EMentorTaskStatus?(this.inheritStatus) : null);
				}
			}
		}

		// Token: 0x06007416 RID: 29718 RVA: 0x000DE200 File Offset: 0x000DC400
		private bool ShouldSerializeinheritStatus()
		{
			return this.inheritStatusSpecified;
		}

		// Token: 0x06007417 RID: 29719 RVA: 0x000DE218 File Offset: 0x000DC418
		private void ResetinheritStatus()
		{
			this.inheritStatusSpecified = false;
		}

		// Token: 0x170024C2 RID: 9410
		// (get) Token: 0x06007418 RID: 29720 RVA: 0x000DE224 File Offset: 0x000DC424
		// (set) Token: 0x06007419 RID: 29721 RVA: 0x000DE251 File Offset: 0x000DC451
		[ProtoMember(6, IsRequired = false, Name = "inheritApplyRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong inheritApplyRoleID
		{
			get
			{
				return this._inheritApplyRoleID ?? 0UL;
			}
			set
			{
				this._inheritApplyRoleID = new ulong?(value);
			}
		}

		// Token: 0x170024C3 RID: 9411
		// (get) Token: 0x0600741A RID: 29722 RVA: 0x000DE260 File Offset: 0x000DC460
		// (set) Token: 0x0600741B RID: 29723 RVA: 0x000DE280 File Offset: 0x000DC480
		[XmlIgnore]
		[Browsable(false)]
		public bool inheritApplyRoleIDSpecified
		{
			get
			{
				return this._inheritApplyRoleID != null;
			}
			set
			{
				bool flag = value == (this._inheritApplyRoleID == null);
				if (flag)
				{
					this._inheritApplyRoleID = (value ? new ulong?(this.inheritApplyRoleID) : null);
				}
			}
		}

		// Token: 0x0600741C RID: 29724 RVA: 0x000DE2C4 File Offset: 0x000DC4C4
		private bool ShouldSerializeinheritApplyRoleID()
		{
			return this.inheritApplyRoleIDSpecified;
		}

		// Token: 0x0600741D RID: 29725 RVA: 0x000DE2DC File Offset: 0x000DC4DC
		private void ResetinheritApplyRoleID()
		{
			this.inheritApplyRoleIDSpecified = false;
		}

		// Token: 0x170024C4 RID: 9412
		// (get) Token: 0x0600741E RID: 29726 RVA: 0x000DE2E8 File Offset: 0x000DC4E8
		// (set) Token: 0x0600741F RID: 29727 RVA: 0x000DE314 File Offset: 0x000DC514
		[ProtoMember(7, IsRequired = false, Name = "curStatus", DataFormat = DataFormat.TwosComplement)]
		public MentorRelationStatus curStatus
		{
			get
			{
				return this._curStatus ?? MentorRelationStatus.MentorRelationIn;
			}
			set
			{
				this._curStatus = new MentorRelationStatus?(value);
			}
		}

		// Token: 0x170024C5 RID: 9413
		// (get) Token: 0x06007420 RID: 29728 RVA: 0x000DE324 File Offset: 0x000DC524
		// (set) Token: 0x06007421 RID: 29729 RVA: 0x000DE344 File Offset: 0x000DC544
		[XmlIgnore]
		[Browsable(false)]
		public bool curStatusSpecified
		{
			get
			{
				return this._curStatus != null;
			}
			set
			{
				bool flag = value == (this._curStatus == null);
				if (flag)
				{
					this._curStatus = (value ? new MentorRelationStatus?(this.curStatus) : null);
				}
			}
		}

		// Token: 0x06007422 RID: 29730 RVA: 0x000DE388 File Offset: 0x000DC588
		private bool ShouldSerializecurStatus()
		{
			return this.curStatusSpecified;
		}

		// Token: 0x06007423 RID: 29731 RVA: 0x000DE3A0 File Offset: 0x000DC5A0
		private void ResetcurStatus()
		{
			this.curStatusSpecified = false;
		}

		// Token: 0x170024C6 RID: 9414
		// (get) Token: 0x06007424 RID: 29732 RVA: 0x000DE3AC File Offset: 0x000DC5AC
		// (set) Token: 0x06007425 RID: 29733 RVA: 0x000DE3D9 File Offset: 0x000DC5D9
		[ProtoMember(8, IsRequired = false, Name = "breakApplyRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong breakApplyRoleID
		{
			get
			{
				return this._breakApplyRoleID ?? 0UL;
			}
			set
			{
				this._breakApplyRoleID = new ulong?(value);
			}
		}

		// Token: 0x170024C7 RID: 9415
		// (get) Token: 0x06007426 RID: 29734 RVA: 0x000DE3E8 File Offset: 0x000DC5E8
		// (set) Token: 0x06007427 RID: 29735 RVA: 0x000DE408 File Offset: 0x000DC608
		[XmlIgnore]
		[Browsable(false)]
		public bool breakApplyRoleIDSpecified
		{
			get
			{
				return this._breakApplyRoleID != null;
			}
			set
			{
				bool flag = value == (this._breakApplyRoleID == null);
				if (flag)
				{
					this._breakApplyRoleID = (value ? new ulong?(this.breakApplyRoleID) : null);
				}
			}
		}

		// Token: 0x06007428 RID: 29736 RVA: 0x000DE44C File Offset: 0x000DC64C
		private bool ShouldSerializebreakApplyRoleID()
		{
			return this.breakApplyRoleIDSpecified;
		}

		// Token: 0x06007429 RID: 29737 RVA: 0x000DE464 File Offset: 0x000DC664
		private void ResetbreakApplyRoleID()
		{
			this.breakApplyRoleIDSpecified = false;
		}

		// Token: 0x0600742A RID: 29738 RVA: 0x000DE470 File Offset: 0x000DC670
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B91 RID: 7057
		private RoleBriefInfo _roleInfo = null;

		// Token: 0x04001B92 RID: 7058
		private readonly List<MentorRelationStatusData> _relationlist = new List<MentorRelationStatusData>();

		// Token: 0x04001B93 RID: 7059
		private int? _pos;

		// Token: 0x04001B94 RID: 7060
		private readonly List<OneMentorTaskInfo> _studentTaskList = new List<OneMentorTaskInfo>();

		// Token: 0x04001B95 RID: 7061
		private EMentorTaskStatus? _inheritStatus;

		// Token: 0x04001B96 RID: 7062
		private ulong? _inheritApplyRoleID;

		// Token: 0x04001B97 RID: 7063
		private MentorRelationStatus? _curStatus;

		// Token: 0x04001B98 RID: 7064
		private ulong? _breakApplyRoleID;

		// Token: 0x04001B99 RID: 7065
		private IExtension extensionObject;
	}
}
