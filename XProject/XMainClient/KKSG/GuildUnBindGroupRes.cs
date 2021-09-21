using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000264 RID: 612
	[ProtoContract(Name = "GuildUnBindGroupRes")]
	[Serializable]
	public class GuildUnBindGroupRes : IExtensible
	{
		// Token: 0x17000AAC RID: 2732
		// (get) Token: 0x06002247 RID: 8775 RVA: 0x00043008 File Offset: 0x00041208
		// (set) Token: 0x06002248 RID: 8776 RVA: 0x00043034 File Offset: 0x00041234
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

		// Token: 0x17000AAD RID: 2733
		// (get) Token: 0x06002249 RID: 8777 RVA: 0x00043044 File Offset: 0x00041244
		// (set) Token: 0x0600224A RID: 8778 RVA: 0x00043064 File Offset: 0x00041264
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

		// Token: 0x0600224B RID: 8779 RVA: 0x000430A8 File Offset: 0x000412A8
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600224C RID: 8780 RVA: 0x000430C0 File Offset: 0x000412C0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600224D RID: 8781 RVA: 0x000430CC File Offset: 0x000412CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000880 RID: 2176
		private ErrorCode? _result;

		// Token: 0x04000881 RID: 2177
		private IExtension extensionObject;
	}
}
