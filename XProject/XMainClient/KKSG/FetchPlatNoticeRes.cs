using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002EA RID: 746
	[ProtoContract(Name = "FetchPlatNoticeRes")]
	[Serializable]
	public class FetchPlatNoticeRes : IExtensible
	{
		// Token: 0x17000CBA RID: 3258
		// (get) Token: 0x06002900 RID: 10496 RVA: 0x0004F9F4 File Offset: 0x0004DBF4
		// (set) Token: 0x06002901 RID: 10497 RVA: 0x0004FA0C File Offset: 0x0004DC0C
		[ProtoMember(1, IsRequired = false, Name = "notice", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PlatNotice notice
		{
			get
			{
				return this._notice;
			}
			set
			{
				this._notice = value;
			}
		}

		// Token: 0x17000CBB RID: 3259
		// (get) Token: 0x06002902 RID: 10498 RVA: 0x0004FA18 File Offset: 0x0004DC18
		// (set) Token: 0x06002903 RID: 10499 RVA: 0x0004FA44 File Offset: 0x0004DC44
		[ProtoMember(2, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17000CBC RID: 3260
		// (get) Token: 0x06002904 RID: 10500 RVA: 0x0004FA54 File Offset: 0x0004DC54
		// (set) Token: 0x06002905 RID: 10501 RVA: 0x0004FA74 File Offset: 0x0004DC74
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
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06002906 RID: 10502 RVA: 0x0004FAB8 File Offset: 0x0004DCB8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002907 RID: 10503 RVA: 0x0004FAD0 File Offset: 0x0004DCD0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000CBD RID: 3261
		// (get) Token: 0x06002908 RID: 10504 RVA: 0x0004FADC File Offset: 0x0004DCDC
		[ProtoMember(3, Name = "data", DataFormat = DataFormat.Default)]
		public List<PlatNotice> data
		{
			get
			{
				return this._data;
			}
		}

		// Token: 0x06002909 RID: 10505 RVA: 0x0004FAF4 File Offset: 0x0004DCF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A30 RID: 2608
		private PlatNotice _notice = null;

		// Token: 0x04000A31 RID: 2609
		private ErrorCode? _result;

		// Token: 0x04000A32 RID: 2610
		private readonly List<PlatNotice> _data = new List<PlatNotice>();

		// Token: 0x04000A33 RID: 2611
		private IExtension extensionObject;
	}
}
