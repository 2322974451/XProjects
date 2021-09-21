using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200030E RID: 782
	[ProtoContract(Name = "GetMyApplyMasterInfoArg")]
	[Serializable]
	public class GetMyApplyMasterInfoArg : IExtensible
	{
		// Token: 0x17000D41 RID: 3393
		// (get) Token: 0x06002AC7 RID: 10951 RVA: 0x00052E38 File Offset: 0x00051038
		// (set) Token: 0x06002AC8 RID: 10952 RVA: 0x00052E64 File Offset: 0x00051064
		[ProtoMember(1, IsRequired = false, Name = "isRefresh", DataFormat = DataFormat.Default)]
		public bool isRefresh
		{
			get
			{
				return this._isRefresh ?? false;
			}
			set
			{
				this._isRefresh = new bool?(value);
			}
		}

		// Token: 0x17000D42 RID: 3394
		// (get) Token: 0x06002AC9 RID: 10953 RVA: 0x00052E74 File Offset: 0x00051074
		// (set) Token: 0x06002ACA RID: 10954 RVA: 0x00052E94 File Offset: 0x00051094
		[XmlIgnore]
		[Browsable(false)]
		public bool isRefreshSpecified
		{
			get
			{
				return this._isRefresh != null;
			}
			set
			{
				bool flag = value == (this._isRefresh == null);
				if (flag)
				{
					this._isRefresh = (value ? new bool?(this.isRefresh) : null);
				}
			}
		}

		// Token: 0x06002ACB RID: 10955 RVA: 0x00052ED8 File Offset: 0x000510D8
		private bool ShouldSerializeisRefresh()
		{
			return this.isRefreshSpecified;
		}

		// Token: 0x06002ACC RID: 10956 RVA: 0x00052EF0 File Offset: 0x000510F0
		private void ResetisRefresh()
		{
			this.isRefreshSpecified = false;
		}

		// Token: 0x06002ACD RID: 10957 RVA: 0x00052EFC File Offset: 0x000510FC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A9E RID: 2718
		private bool? _isRefresh;

		// Token: 0x04000A9F RID: 2719
		private IExtension extensionObject;
	}
}
