using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000262 RID: 610
	[ProtoContract(Name = "GuildJoinBindGroupRes")]
	[Serializable]
	public class GuildJoinBindGroupRes : IExtensible
	{
		// Token: 0x17000AA8 RID: 2728
		// (get) Token: 0x06002237 RID: 8759 RVA: 0x00042E68 File Offset: 0x00041068
		// (set) Token: 0x06002238 RID: 8760 RVA: 0x00042E94 File Offset: 0x00041094
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

		// Token: 0x17000AA9 RID: 2729
		// (get) Token: 0x06002239 RID: 8761 RVA: 0x00042EA4 File Offset: 0x000410A4
		// (set) Token: 0x0600223A RID: 8762 RVA: 0x00042EC4 File Offset: 0x000410C4
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

		// Token: 0x0600223B RID: 8763 RVA: 0x00042F08 File Offset: 0x00041108
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600223C RID: 8764 RVA: 0x00042F20 File Offset: 0x00041120
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x0600223D RID: 8765 RVA: 0x00042F2C File Offset: 0x0004112C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400087C RID: 2172
		private ErrorCode? _result;

		// Token: 0x0400087D RID: 2173
		private IExtension extensionObject;
	}
}
