using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003C7 RID: 967
	[ProtoContract(Name = "WorldBossGuildAddAttrRes")]
	[Serializable]
	public class WorldBossGuildAddAttrRes : IExtensible
	{
		// Token: 0x17000FE0 RID: 4064
		// (get) Token: 0x0600338A RID: 13194 RVA: 0x00062F18 File Offset: 0x00061118
		// (set) Token: 0x0600338B RID: 13195 RVA: 0x00062F44 File Offset: 0x00061144
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

		// Token: 0x17000FE1 RID: 4065
		// (get) Token: 0x0600338C RID: 13196 RVA: 0x00062F54 File Offset: 0x00061154
		// (set) Token: 0x0600338D RID: 13197 RVA: 0x00062F74 File Offset: 0x00061174
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

		// Token: 0x0600338E RID: 13198 RVA: 0x00062FB8 File Offset: 0x000611B8
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x0600338F RID: 13199 RVA: 0x00062FD0 File Offset: 0x000611D0
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06003390 RID: 13200 RVA: 0x00062FDC File Offset: 0x000611DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CD0 RID: 3280
		private ErrorCode? _errorcode;

		// Token: 0x04000CD1 RID: 3281
		private IExtension extensionObject;
	}
}
