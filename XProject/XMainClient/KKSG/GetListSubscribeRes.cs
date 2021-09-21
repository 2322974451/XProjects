using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200038E RID: 910
	[ProtoContract(Name = "GetListSubscribeRes")]
	[Serializable]
	public class GetListSubscribeRes : IExtensible
	{
		// Token: 0x17000F3F RID: 3903
		// (get) Token: 0x0600314E RID: 12622 RVA: 0x0005EFE0 File Offset: 0x0005D1E0
		// (set) Token: 0x0600314F RID: 12623 RVA: 0x0005F00C File Offset: 0x0005D20C
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000F40 RID: 3904
		// (get) Token: 0x06003150 RID: 12624 RVA: 0x0005F01C File Offset: 0x0005D21C
		// (set) Token: 0x06003151 RID: 12625 RVA: 0x0005F03C File Offset: 0x0005D23C
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

		// Token: 0x06003152 RID: 12626 RVA: 0x0005F080 File Offset: 0x0005D280
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003153 RID: 12627 RVA: 0x0005F098 File Offset: 0x0005D298
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000F41 RID: 3905
		// (get) Token: 0x06003154 RID: 12628 RVA: 0x0005F0A4 File Offset: 0x0005D2A4
		[ProtoMember(2, Name = "list", DataFormat = DataFormat.Default)]
		public List<SubScribe> list
		{
			get
			{
				return this._list;
			}
		}

		// Token: 0x17000F42 RID: 3906
		// (get) Token: 0x06003155 RID: 12629 RVA: 0x0005F0BC File Offset: 0x0005D2BC
		// (set) Token: 0x06003156 RID: 12630 RVA: 0x0005F0E8 File Offset: 0x0005D2E8
		[ProtoMember(3, IsRequired = false, Name = "more", DataFormat = DataFormat.Default)]
		public bool more
		{
			get
			{
				return this._more ?? false;
			}
			set
			{
				this._more = new bool?(value);
			}
		}

		// Token: 0x17000F43 RID: 3907
		// (get) Token: 0x06003157 RID: 12631 RVA: 0x0005F0F8 File Offset: 0x0005D2F8
		// (set) Token: 0x06003158 RID: 12632 RVA: 0x0005F118 File Offset: 0x0005D318
		[XmlIgnore]
		[Browsable(false)]
		public bool moreSpecified
		{
			get
			{
				return this._more != null;
			}
			set
			{
				bool flag = value == (this._more == null);
				if (flag)
				{
					this._more = (value ? new bool?(this.more) : null);
				}
			}
		}

		// Token: 0x06003159 RID: 12633 RVA: 0x0005F15C File Offset: 0x0005D35C
		private bool ShouldSerializemore()
		{
			return this.moreSpecified;
		}

		// Token: 0x0600315A RID: 12634 RVA: 0x0005F174 File Offset: 0x0005D374
		private void Resetmore()
		{
			this.moreSpecified = false;
		}

		// Token: 0x0600315B RID: 12635 RVA: 0x0005F180 File Offset: 0x0005D380
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C3E RID: 3134
		private ErrorCode? _result;

		// Token: 0x04000C3F RID: 3135
		private readonly List<SubScribe> _list = new List<SubScribe>();

		// Token: 0x04000C40 RID: 3136
		private bool? _more;

		// Token: 0x04000C41 RID: 3137
		private IExtension extensionObject;
	}
}
