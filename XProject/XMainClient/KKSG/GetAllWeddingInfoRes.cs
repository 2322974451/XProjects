using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000470 RID: 1136
	[ProtoContract(Name = "GetAllWeddingInfoRes")]
	[Serializable]
	public class GetAllWeddingInfoRes : IExtensible
	{
		// Token: 0x1700122C RID: 4652
		// (get) Token: 0x06003B53 RID: 15187 RVA: 0x000715E8 File Offset: 0x0006F7E8
		// (set) Token: 0x06003B54 RID: 15188 RVA: 0x00071614 File Offset: 0x0006F814
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

		// Token: 0x1700122D RID: 4653
		// (get) Token: 0x06003B55 RID: 15189 RVA: 0x00071624 File Offset: 0x0006F824
		// (set) Token: 0x06003B56 RID: 15190 RVA: 0x00071644 File Offset: 0x0006F844
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

		// Token: 0x06003B57 RID: 15191 RVA: 0x00071688 File Offset: 0x0006F888
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06003B58 RID: 15192 RVA: 0x000716A0 File Offset: 0x0006F8A0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700122E RID: 4654
		// (get) Token: 0x06003B59 RID: 15193 RVA: 0x000716AC File Offset: 0x0006F8AC
		[ProtoMember(2, Name = "can_enter", DataFormat = DataFormat.Default)]
		public List<WeddingBrief> can_enter
		{
			get
			{
				return this._can_enter;
			}
		}

		// Token: 0x1700122F RID: 4655
		// (get) Token: 0x06003B5A RID: 15194 RVA: 0x000716C4 File Offset: 0x0006F8C4
		[ProtoMember(3, Name = "can_apply", DataFormat = DataFormat.Default)]
		public List<WeddingBrief> can_apply
		{
			get
			{
				return this._can_apply;
			}
		}

		// Token: 0x17001230 RID: 4656
		// (get) Token: 0x06003B5B RID: 15195 RVA: 0x000716DC File Offset: 0x0006F8DC
		[ProtoMember(4, Name = "is_apply", DataFormat = DataFormat.Default)]
		public List<bool> is_apply
		{
			get
			{
				return this._is_apply;
			}
		}

		// Token: 0x06003B5C RID: 15196 RVA: 0x000716F4 File Offset: 0x0006F8F4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EBE RID: 3774
		private ErrorCode? _result;

		// Token: 0x04000EBF RID: 3775
		private readonly List<WeddingBrief> _can_enter = new List<WeddingBrief>();

		// Token: 0x04000EC0 RID: 3776
		private readonly List<WeddingBrief> _can_apply = new List<WeddingBrief>();

		// Token: 0x04000EC1 RID: 3777
		private readonly List<bool> _is_apply = new List<bool>();

		// Token: 0x04000EC2 RID: 3778
		private IExtension extensionObject;
	}
}
