using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200030F RID: 783
	[ProtoContract(Name = "GetMyApplyMasterInfoRes")]
	[Serializable]
	public class GetMyApplyMasterInfoRes : IExtensible
	{
		// Token: 0x17000D43 RID: 3395
		// (get) Token: 0x06002ACF RID: 10959 RVA: 0x00052F30 File Offset: 0x00051130
		// (set) Token: 0x06002AD0 RID: 10960 RVA: 0x00052F5C File Offset: 0x0005115C
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

		// Token: 0x17000D44 RID: 3396
		// (get) Token: 0x06002AD1 RID: 10961 RVA: 0x00052F6C File Offset: 0x0005116C
		// (set) Token: 0x06002AD2 RID: 10962 RVA: 0x00052F8C File Offset: 0x0005118C
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

		// Token: 0x06002AD3 RID: 10963 RVA: 0x00052FD0 File Offset: 0x000511D0
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06002AD4 RID: 10964 RVA: 0x00052FE8 File Offset: 0x000511E8
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000D45 RID: 3397
		// (get) Token: 0x06002AD5 RID: 10965 RVA: 0x00052FF4 File Offset: 0x000511F4
		[ProtoMember(2, Name = "canApplyMasters", DataFormat = DataFormat.Default)]
		public List<OneMentorApplyMasterShow> canApplyMasters
		{
			get
			{
				return this._canApplyMasters;
			}
		}

		// Token: 0x17000D46 RID: 3398
		// (get) Token: 0x06002AD6 RID: 10966 RVA: 0x0005300C File Offset: 0x0005120C
		// (set) Token: 0x06002AD7 RID: 10967 RVA: 0x00053038 File Offset: 0x00051238
		[ProtoMember(3, IsRequired = false, Name = "leftRefreshTime", DataFormat = DataFormat.TwosComplement)]
		public int leftRefreshTime
		{
			get
			{
				return this._leftRefreshTime ?? 0;
			}
			set
			{
				this._leftRefreshTime = new int?(value);
			}
		}

		// Token: 0x17000D47 RID: 3399
		// (get) Token: 0x06002AD8 RID: 10968 RVA: 0x00053048 File Offset: 0x00051248
		// (set) Token: 0x06002AD9 RID: 10969 RVA: 0x00053068 File Offset: 0x00051268
		[XmlIgnore]
		[Browsable(false)]
		public bool leftRefreshTimeSpecified
		{
			get
			{
				return this._leftRefreshTime != null;
			}
			set
			{
				bool flag = value == (this._leftRefreshTime == null);
				if (flag)
				{
					this._leftRefreshTime = (value ? new int?(this.leftRefreshTime) : null);
				}
			}
		}

		// Token: 0x06002ADA RID: 10970 RVA: 0x000530AC File Offset: 0x000512AC
		private bool ShouldSerializeleftRefreshTime()
		{
			return this.leftRefreshTimeSpecified;
		}

		// Token: 0x06002ADB RID: 10971 RVA: 0x000530C4 File Offset: 0x000512C4
		private void ResetleftRefreshTime()
		{
			this.leftRefreshTimeSpecified = false;
		}

		// Token: 0x06002ADC RID: 10972 RVA: 0x000530D0 File Offset: 0x000512D0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AA0 RID: 2720
		private ErrorCode? _error;

		// Token: 0x04000AA1 RID: 2721
		private readonly List<OneMentorApplyMasterShow> _canApplyMasters = new List<OneMentorApplyMasterShow>();

		// Token: 0x04000AA2 RID: 2722
		private int? _leftRefreshTime;

		// Token: 0x04000AA3 RID: 2723
		private IExtension extensionObject;
	}
}
