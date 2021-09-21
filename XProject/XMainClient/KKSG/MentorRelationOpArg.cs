using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000314 RID: 788
	[ProtoContract(Name = "MentorRelationOpArg")]
	[Serializable]
	public class MentorRelationOpArg : IExtensible
	{
		// Token: 0x17000D5F RID: 3423
		// (get) Token: 0x06002B29 RID: 11049 RVA: 0x000539E0 File Offset: 0x00051BE0
		// (set) Token: 0x06002B2A RID: 11050 RVA: 0x00053A0C File Offset: 0x00051C0C
		[ProtoMember(1, IsRequired = false, Name = "operation", DataFormat = DataFormat.TwosComplement)]
		public MentorRelationOpType operation
		{
			get
			{
				return this._operation ?? MentorRelationOpType.MentorRelationOp_ApplyMaster;
			}
			set
			{
				this._operation = new MentorRelationOpType?(value);
			}
		}

		// Token: 0x17000D60 RID: 3424
		// (get) Token: 0x06002B2B RID: 11051 RVA: 0x00053A1C File Offset: 0x00051C1C
		// (set) Token: 0x06002B2C RID: 11052 RVA: 0x00053A3C File Offset: 0x00051C3C
		[XmlIgnore]
		[Browsable(false)]
		public bool operationSpecified
		{
			get
			{
				return this._operation != null;
			}
			set
			{
				bool flag = value == (this._operation == null);
				if (flag)
				{
					this._operation = (value ? new MentorRelationOpType?(this.operation) : null);
				}
			}
		}

		// Token: 0x06002B2D RID: 11053 RVA: 0x00053A80 File Offset: 0x00051C80
		private bool ShouldSerializeoperation()
		{
			return this.operationSpecified;
		}

		// Token: 0x06002B2E RID: 11054 RVA: 0x00053A98 File Offset: 0x00051C98
		private void Resetoperation()
		{
			this.operationSpecified = false;
		}

		// Token: 0x17000D61 RID: 3425
		// (get) Token: 0x06002B2F RID: 11055 RVA: 0x00053AA4 File Offset: 0x00051CA4
		// (set) Token: 0x06002B30 RID: 11056 RVA: 0x00053AD1 File Offset: 0x00051CD1
		[ProtoMember(2, IsRequired = false, Name = "destRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong destRoleID
		{
			get
			{
				return this._destRoleID ?? 0UL;
			}
			set
			{
				this._destRoleID = new ulong?(value);
			}
		}

		// Token: 0x17000D62 RID: 3426
		// (get) Token: 0x06002B31 RID: 11057 RVA: 0x00053AE0 File Offset: 0x00051CE0
		// (set) Token: 0x06002B32 RID: 11058 RVA: 0x00053B00 File Offset: 0x00051D00
		[XmlIgnore]
		[Browsable(false)]
		public bool destRoleIDSpecified
		{
			get
			{
				return this._destRoleID != null;
			}
			set
			{
				bool flag = value == (this._destRoleID == null);
				if (flag)
				{
					this._destRoleID = (value ? new ulong?(this.destRoleID) : null);
				}
			}
		}

		// Token: 0x06002B33 RID: 11059 RVA: 0x00053B44 File Offset: 0x00051D44
		private bool ShouldSerializedestRoleID()
		{
			return this.destRoleIDSpecified;
		}

		// Token: 0x06002B34 RID: 11060 RVA: 0x00053B5C File Offset: 0x00051D5C
		private void ResetdestRoleID()
		{
			this.destRoleIDSpecified = false;
		}

		// Token: 0x17000D63 RID: 3427
		// (get) Token: 0x06002B35 RID: 11061 RVA: 0x00053B68 File Offset: 0x00051D68
		// (set) Token: 0x06002B36 RID: 11062 RVA: 0x00053B94 File Offset: 0x00051D94
		[ProtoMember(3, IsRequired = false, Name = "reportTaskID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000D64 RID: 3428
		// (get) Token: 0x06002B37 RID: 11063 RVA: 0x00053BA4 File Offset: 0x00051DA4
		// (set) Token: 0x06002B38 RID: 11064 RVA: 0x00053BC4 File Offset: 0x00051DC4
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

		// Token: 0x06002B39 RID: 11065 RVA: 0x00053C08 File Offset: 0x00051E08
		private bool ShouldSerializereportTaskID()
		{
			return this.reportTaskIDSpecified;
		}

		// Token: 0x06002B3A RID: 11066 RVA: 0x00053C20 File Offset: 0x00051E20
		private void ResetreportTaskID()
		{
			this.reportTaskIDSpecified = false;
		}

		// Token: 0x06002B3B RID: 11067 RVA: 0x00053C2C File Offset: 0x00051E2C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AB4 RID: 2740
		private MentorRelationOpType? _operation;

		// Token: 0x04000AB5 RID: 2741
		private ulong? _destRoleID;

		// Token: 0x04000AB6 RID: 2742
		private int? _reportTaskID;

		// Token: 0x04000AB7 RID: 2743
		private IExtension extensionObject;
	}
}
