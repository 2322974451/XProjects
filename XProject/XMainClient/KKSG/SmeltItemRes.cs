using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000223 RID: 547
	[ProtoContract(Name = "SmeltItemRes")]
	[Serializable]
	public class SmeltItemRes : IExtensible
	{
		// Token: 0x1700099F RID: 2463
		// (get) Token: 0x06001EC5 RID: 7877 RVA: 0x0003C6E0 File Offset: 0x0003A8E0
		// (set) Token: 0x06001EC6 RID: 7878 RVA: 0x0003C70C File Offset: 0x0003A90C
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170009A0 RID: 2464
		// (get) Token: 0x06001EC7 RID: 7879 RVA: 0x0003C71C File Offset: 0x0003A91C
		// (set) Token: 0x06001EC8 RID: 7880 RVA: 0x0003C73C File Offset: 0x0003A93C
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06001EC9 RID: 7881 RVA: 0x0003C780 File Offset: 0x0003A980
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001ECA RID: 7882 RVA: 0x0003C798 File Offset: 0x0003A998
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170009A1 RID: 2465
		// (get) Token: 0x06001ECB RID: 7883 RVA: 0x0003C7A4 File Offset: 0x0003A9A4
		// (set) Token: 0x06001ECC RID: 7884 RVA: 0x0003C7D0 File Offset: 0x0003A9D0
		[ProtoMember(2, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public uint result
		{
			get
			{
				return this._result ?? 0U;
			}
			set
			{
				this._result = new uint?(value);
			}
		}

		// Token: 0x170009A2 RID: 2466
		// (get) Token: 0x06001ECD RID: 7885 RVA: 0x0003C7E0 File Offset: 0x0003A9E0
		// (set) Token: 0x06001ECE RID: 7886 RVA: 0x0003C800 File Offset: 0x0003AA00
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new uint?(this.result) : null);
				}
			}
		}

		// Token: 0x06001ECF RID: 7887 RVA: 0x0003C844 File Offset: 0x0003AA44
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06001ED0 RID: 7888 RVA: 0x0003C85C File Offset: 0x0003AA5C
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06001ED1 RID: 7889 RVA: 0x0003C868 File Offset: 0x0003AA68
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007AE RID: 1966
		private ErrorCode? _errorcode;

		// Token: 0x040007AF RID: 1967
		private uint? _result;

		// Token: 0x040007B0 RID: 1968
		private IExtension extensionObject;
	}
}
