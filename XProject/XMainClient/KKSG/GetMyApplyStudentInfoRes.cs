using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200030D RID: 781
	[ProtoContract(Name = "GetMyApplyStudentInfoRes")]
	[Serializable]
	public class GetMyApplyStudentInfoRes : IExtensible
	{
		// Token: 0x17000D3C RID: 3388
		// (get) Token: 0x06002AB8 RID: 10936 RVA: 0x00052C78 File Offset: 0x00050E78
		// (set) Token: 0x06002AB9 RID: 10937 RVA: 0x00052CA4 File Offset: 0x00050EA4
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

		// Token: 0x17000D3D RID: 3389
		// (get) Token: 0x06002ABA RID: 10938 RVA: 0x00052CB4 File Offset: 0x00050EB4
		// (set) Token: 0x06002ABB RID: 10939 RVA: 0x00052CD4 File Offset: 0x00050ED4
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

		// Token: 0x06002ABC RID: 10940 RVA: 0x00052D18 File Offset: 0x00050F18
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06002ABD RID: 10941 RVA: 0x00052D30 File Offset: 0x00050F30
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000D3E RID: 3390
		// (get) Token: 0x06002ABE RID: 10942 RVA: 0x00052D3C File Offset: 0x00050F3C
		[ProtoMember(2, Name = "canApplyList", DataFormat = DataFormat.Default)]
		public List<OneMentorApplyStudentShow> canApplyList
		{
			get
			{
				return this._canApplyList;
			}
		}

		// Token: 0x17000D3F RID: 3391
		// (get) Token: 0x06002ABF RID: 10943 RVA: 0x00052D54 File Offset: 0x00050F54
		// (set) Token: 0x06002AC0 RID: 10944 RVA: 0x00052D80 File Offset: 0x00050F80
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

		// Token: 0x17000D40 RID: 3392
		// (get) Token: 0x06002AC1 RID: 10945 RVA: 0x00052D90 File Offset: 0x00050F90
		// (set) Token: 0x06002AC2 RID: 10946 RVA: 0x00052DB0 File Offset: 0x00050FB0
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

		// Token: 0x06002AC3 RID: 10947 RVA: 0x00052DF4 File Offset: 0x00050FF4
		private bool ShouldSerializeleftRefreshTime()
		{
			return this.leftRefreshTimeSpecified;
		}

		// Token: 0x06002AC4 RID: 10948 RVA: 0x00052E0C File Offset: 0x0005100C
		private void ResetleftRefreshTime()
		{
			this.leftRefreshTimeSpecified = false;
		}

		// Token: 0x06002AC5 RID: 10949 RVA: 0x00052E18 File Offset: 0x00051018
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A9A RID: 2714
		private ErrorCode? _error;

		// Token: 0x04000A9B RID: 2715
		private readonly List<OneMentorApplyStudentShow> _canApplyList = new List<OneMentorApplyStudentShow>();

		// Token: 0x04000A9C RID: 2716
		private int? _leftRefreshTime;

		// Token: 0x04000A9D RID: 2717
		private IExtension extensionObject;
	}
}
