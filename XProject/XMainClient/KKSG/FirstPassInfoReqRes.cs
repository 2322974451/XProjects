using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001DE RID: 478
	[ProtoContract(Name = "FirstPassInfoReqRes")]
	[Serializable]
	public class FirstPassInfoReqRes : IExtensible
	{
		// Token: 0x170008A6 RID: 2214
		// (get) Token: 0x06001B8A RID: 7050 RVA: 0x00036644 File Offset: 0x00034844
		// (set) Token: 0x06001B8B RID: 7051 RVA: 0x00036670 File Offset: 0x00034870
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

		// Token: 0x170008A7 RID: 2215
		// (get) Token: 0x06001B8C RID: 7052 RVA: 0x00036680 File Offset: 0x00034880
		// (set) Token: 0x06001B8D RID: 7053 RVA: 0x000366A0 File Offset: 0x000348A0
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

		// Token: 0x06001B8E RID: 7054 RVA: 0x000366E4 File Offset: 0x000348E4
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x06001B8F RID: 7055 RVA: 0x000366FC File Offset: 0x000348FC
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x170008A8 RID: 2216
		// (get) Token: 0x06001B90 RID: 7056 RVA: 0x00036708 File Offset: 0x00034908
		[ProtoMember(2, Name = "stageInfos", DataFormat = DataFormat.Default)]
		public List<FirstPassStageInfo2Client> stageInfos
		{
			get
			{
				return this._stageInfos;
			}
		}

		// Token: 0x06001B91 RID: 7057 RVA: 0x00036720 File Offset: 0x00034920
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006DC RID: 1756
		private ErrorCode? _error;

		// Token: 0x040006DD RID: 1757
		private readonly List<FirstPassStageInfo2Client> _stageInfos = new List<FirstPassStageInfo2Client>();

		// Token: 0x040006DE RID: 1758
		private IExtension extensionObject;
	}
}
