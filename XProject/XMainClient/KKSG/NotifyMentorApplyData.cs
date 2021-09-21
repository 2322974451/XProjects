using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000316 RID: 790
	[ProtoContract(Name = "NotifyMentorApplyData")]
	[Serializable]
	public class NotifyMentorApplyData : IExtensible
	{
		// Token: 0x17000D69 RID: 3433
		// (get) Token: 0x06002B4B RID: 11083 RVA: 0x00053E08 File Offset: 0x00052008
		// (set) Token: 0x06002B4C RID: 11084 RVA: 0x00053E34 File Offset: 0x00052034
		[ProtoMember(1, IsRequired = false, Name = "pos", DataFormat = DataFormat.TwosComplement)]
		public EMentorRelationPosition pos
		{
			get
			{
				return this._pos ?? EMentorRelationPosition.EMentorPosMaster;
			}
			set
			{
				this._pos = new EMentorRelationPosition?(value);
			}
		}

		// Token: 0x17000D6A RID: 3434
		// (get) Token: 0x06002B4D RID: 11085 RVA: 0x00053E44 File Offset: 0x00052044
		// (set) Token: 0x06002B4E RID: 11086 RVA: 0x00053E64 File Offset: 0x00052064
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
					this._pos = (value ? new EMentorRelationPosition?(this.pos) : null);
				}
			}
		}

		// Token: 0x06002B4F RID: 11087 RVA: 0x00053EA8 File Offset: 0x000520A8
		private bool ShouldSerializepos()
		{
			return this.posSpecified;
		}

		// Token: 0x06002B50 RID: 11088 RVA: 0x00053EC0 File Offset: 0x000520C0
		private void Resetpos()
		{
			this.posSpecified = false;
		}

		// Token: 0x17000D6B RID: 3435
		// (get) Token: 0x06002B51 RID: 11089 RVA: 0x00053ECC File Offset: 0x000520CC
		// (set) Token: 0x06002B52 RID: 11090 RVA: 0x00053EF8 File Offset: 0x000520F8
		[ProtoMember(2, IsRequired = false, Name = "hasInheritOrReportTask", DataFormat = DataFormat.Default)]
		public bool hasInheritOrReportTask
		{
			get
			{
				return this._hasInheritOrReportTask ?? false;
			}
			set
			{
				this._hasInheritOrReportTask = new bool?(value);
			}
		}

		// Token: 0x17000D6C RID: 3436
		// (get) Token: 0x06002B53 RID: 11091 RVA: 0x00053F08 File Offset: 0x00052108
		// (set) Token: 0x06002B54 RID: 11092 RVA: 0x00053F28 File Offset: 0x00052128
		[XmlIgnore]
		[Browsable(false)]
		public bool hasInheritOrReportTaskSpecified
		{
			get
			{
				return this._hasInheritOrReportTask != null;
			}
			set
			{
				bool flag = value == (this._hasInheritOrReportTask == null);
				if (flag)
				{
					this._hasInheritOrReportTask = (value ? new bool?(this.hasInheritOrReportTask) : null);
				}
			}
		}

		// Token: 0x06002B55 RID: 11093 RVA: 0x00053F6C File Offset: 0x0005216C
		private bool ShouldSerializehasInheritOrReportTask()
		{
			return this.hasInheritOrReportTaskSpecified;
		}

		// Token: 0x06002B56 RID: 11094 RVA: 0x00053F84 File Offset: 0x00052184
		private void ResethasInheritOrReportTask()
		{
			this.hasInheritOrReportTaskSpecified = false;
		}

		// Token: 0x17000D6D RID: 3437
		// (get) Token: 0x06002B57 RID: 11095 RVA: 0x00053F90 File Offset: 0x00052190
		// (set) Token: 0x06002B58 RID: 11096 RVA: 0x00053FBC File Offset: 0x000521BC
		[ProtoMember(3, IsRequired = false, Name = "hasMsg", DataFormat = DataFormat.Default)]
		public bool hasMsg
		{
			get
			{
				return this._hasMsg ?? false;
			}
			set
			{
				this._hasMsg = new bool?(value);
			}
		}

		// Token: 0x17000D6E RID: 3438
		// (get) Token: 0x06002B59 RID: 11097 RVA: 0x00053FCC File Offset: 0x000521CC
		// (set) Token: 0x06002B5A RID: 11098 RVA: 0x00053FEC File Offset: 0x000521EC
		[XmlIgnore]
		[Browsable(false)]
		public bool hasMsgSpecified
		{
			get
			{
				return this._hasMsg != null;
			}
			set
			{
				bool flag = value == (this._hasMsg == null);
				if (flag)
				{
					this._hasMsg = (value ? new bool?(this.hasMsg) : null);
				}
			}
		}

		// Token: 0x06002B5B RID: 11099 RVA: 0x00054030 File Offset: 0x00052230
		private bool ShouldSerializehasMsg()
		{
			return this.hasMsgSpecified;
		}

		// Token: 0x06002B5C RID: 11100 RVA: 0x00054048 File Offset: 0x00052248
		private void ResethasMsg()
		{
			this.hasMsgSpecified = false;
		}

		// Token: 0x17000D6F RID: 3439
		// (get) Token: 0x06002B5D RID: 11101 RVA: 0x00054054 File Offset: 0x00052254
		[ProtoMember(4, Name = "appliedBreakInfos", DataFormat = DataFormat.Default)]
		public List<MentorBreakApplyInfo> appliedBreakInfos
		{
			get
			{
				return this._appliedBreakInfos;
			}
		}

		// Token: 0x06002B5E RID: 11102 RVA: 0x0005406C File Offset: 0x0005226C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000ABB RID: 2747
		private EMentorRelationPosition? _pos;

		// Token: 0x04000ABC RID: 2748
		private bool? _hasInheritOrReportTask;

		// Token: 0x04000ABD RID: 2749
		private bool? _hasMsg;

		// Token: 0x04000ABE RID: 2750
		private readonly List<MentorBreakApplyInfo> _appliedBreakInfos = new List<MentorBreakApplyInfo>();

		// Token: 0x04000ABF RID: 2751
		private IExtension extensionObject;
	}
}
