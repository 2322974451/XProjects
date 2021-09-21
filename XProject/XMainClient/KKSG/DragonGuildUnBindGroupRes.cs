using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004D1 RID: 1233
	[ProtoContract(Name = "DragonGuildUnBindGroupRes")]
	[Serializable]
	public class DragonGuildUnBindGroupRes : IExtensible
	{
		// Token: 0x17001399 RID: 5017
		// (get) Token: 0x06004002 RID: 16386 RVA: 0x00079EE8 File Offset: 0x000780E8
		// (set) Token: 0x06004003 RID: 16387 RVA: 0x00079F14 File Offset: 0x00078114
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

		// Token: 0x1700139A RID: 5018
		// (get) Token: 0x06004004 RID: 16388 RVA: 0x00079F24 File Offset: 0x00078124
		// (set) Token: 0x06004005 RID: 16389 RVA: 0x00079F44 File Offset: 0x00078144
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

		// Token: 0x06004006 RID: 16390 RVA: 0x00079F88 File Offset: 0x00078188
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06004007 RID: 16391 RVA: 0x00079FA0 File Offset: 0x000781A0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x06004008 RID: 16392 RVA: 0x00079FAC File Offset: 0x000781AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FEF RID: 4079
		private ErrorCode? _result;

		// Token: 0x04000FF0 RID: 4080
		private IExtension extensionObject;
	}
}
