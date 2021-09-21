using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200030C RID: 780
	[ProtoContract(Name = "GetMyApplyStudentInfoArg")]
	[Serializable]
	public class GetMyApplyStudentInfoArg : IExtensible
	{
		// Token: 0x17000D3A RID: 3386
		// (get) Token: 0x06002AB0 RID: 10928 RVA: 0x00052B80 File Offset: 0x00050D80
		// (set) Token: 0x06002AB1 RID: 10929 RVA: 0x00052BAC File Offset: 0x00050DAC
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

		// Token: 0x17000D3B RID: 3387
		// (get) Token: 0x06002AB2 RID: 10930 RVA: 0x00052BBC File Offset: 0x00050DBC
		// (set) Token: 0x06002AB3 RID: 10931 RVA: 0x00052BDC File Offset: 0x00050DDC
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

		// Token: 0x06002AB4 RID: 10932 RVA: 0x00052C20 File Offset: 0x00050E20
		private bool ShouldSerializeisRefresh()
		{
			return this.isRefreshSpecified;
		}

		// Token: 0x06002AB5 RID: 10933 RVA: 0x00052C38 File Offset: 0x00050E38
		private void ResetisRefresh()
		{
			this.isRefreshSpecified = false;
		}

		// Token: 0x06002AB6 RID: 10934 RVA: 0x00052C44 File Offset: 0x00050E44
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A98 RID: 2712
		private bool? _isRefresh;

		// Token: 0x04000A99 RID: 2713
		private IExtension extensionObject;
	}
}
