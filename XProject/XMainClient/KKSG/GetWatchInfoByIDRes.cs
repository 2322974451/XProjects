using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000179 RID: 377
	[ProtoContract(Name = "GetWatchInfoByIDRes")]
	[Serializable]
	public class GetWatchInfoByIDRes : IExtensible
	{
		// Token: 0x17000723 RID: 1827
		// (get) Token: 0x0600168F RID: 5775 RVA: 0x0002D25C File Offset: 0x0002B45C
		// (set) Token: 0x06001690 RID: 5776 RVA: 0x0002D288 File Offset: 0x0002B488
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

		// Token: 0x17000724 RID: 1828
		// (get) Token: 0x06001691 RID: 5777 RVA: 0x0002D298 File Offset: 0x0002B498
		// (set) Token: 0x06001692 RID: 5778 RVA: 0x0002D2B8 File Offset: 0x0002B4B8
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

		// Token: 0x06001693 RID: 5779 RVA: 0x0002D2FC File Offset: 0x0002B4FC
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001694 RID: 5780 RVA: 0x0002D314 File Offset: 0x0002B514
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000725 RID: 1829
		// (get) Token: 0x06001695 RID: 5781 RVA: 0x0002D320 File Offset: 0x0002B520
		// (set) Token: 0x06001696 RID: 5782 RVA: 0x0002D34C File Offset: 0x0002B54C
		[ProtoMember(2, IsRequired = false, Name = "curTime", DataFormat = DataFormat.TwosComplement)]
		public int curTime
		{
			get
			{
				return this._curTime ?? 0;
			}
			set
			{
				this._curTime = new int?(value);
			}
		}

		// Token: 0x17000726 RID: 1830
		// (get) Token: 0x06001697 RID: 5783 RVA: 0x0002D35C File Offset: 0x0002B55C
		// (set) Token: 0x06001698 RID: 5784 RVA: 0x0002D37C File Offset: 0x0002B57C
		[XmlIgnore]
		[Browsable(false)]
		public bool curTimeSpecified
		{
			get
			{
				return this._curTime != null;
			}
			set
			{
				bool flag = value == (this._curTime == null);
				if (flag)
				{
					this._curTime = (value ? new int?(this.curTime) : null);
				}
			}
		}

		// Token: 0x06001699 RID: 5785 RVA: 0x0002D3C0 File Offset: 0x0002B5C0
		private bool ShouldSerializecurTime()
		{
			return this.curTimeSpecified;
		}

		// Token: 0x0600169A RID: 5786 RVA: 0x0002D3D8 File Offset: 0x0002B5D8
		private void ResetcurTime()
		{
			this.curTimeSpecified = false;
		}

		// Token: 0x17000727 RID: 1831
		// (get) Token: 0x0600169B RID: 5787 RVA: 0x0002D3E4 File Offset: 0x0002B5E4
		[ProtoMember(3, Name = "liveRecords", DataFormat = DataFormat.Default)]
		public List<OneLiveRecordInfo> liveRecords
		{
			get
			{
				return this._liveRecords;
			}
		}

		// Token: 0x0600169C RID: 5788 RVA: 0x0002D3FC File Offset: 0x0002B5FC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000599 RID: 1433
		private ErrorCode? _error;

		// Token: 0x0400059A RID: 1434
		private int? _curTime;

		// Token: 0x0400059B RID: 1435
		private readonly List<OneLiveRecordInfo> _liveRecords = new List<OneLiveRecordInfo>();

		// Token: 0x0400059C RID: 1436
		private IExtension extensionObject;
	}
}
