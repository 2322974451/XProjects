using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000411 RID: 1041
	[ProtoContract(Name = "GetGuildPartyReceiveInfoRes")]
	[Serializable]
	public class GetGuildPartyReceiveInfoRes : IExtensible
	{
		// Token: 0x17001108 RID: 4360
		// (get) Token: 0x06003769 RID: 14185 RVA: 0x0006A1E0 File Offset: 0x000683E0
		// (set) Token: 0x0600376A RID: 14186 RVA: 0x0006A20C File Offset: 0x0006840C
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

		// Token: 0x17001109 RID: 4361
		// (get) Token: 0x0600376B RID: 14187 RVA: 0x0006A21C File Offset: 0x0006841C
		// (set) Token: 0x0600376C RID: 14188 RVA: 0x0006A23C File Offset: 0x0006843C
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

		// Token: 0x0600376D RID: 14189 RVA: 0x0006A280 File Offset: 0x00068480
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x0600376E RID: 14190 RVA: 0x0006A298 File Offset: 0x00068498
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x1700110A RID: 4362
		// (get) Token: 0x0600376F RID: 14191 RVA: 0x0006A2A4 File Offset: 0x000684A4
		[ProtoMember(2, Name = "receives", DataFormat = DataFormat.Default)]
		public List<MapIntItem> receives
		{
			get
			{
				return this._receives;
			}
		}

		// Token: 0x06003770 RID: 14192 RVA: 0x0006A2BC File Offset: 0x000684BC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DBB RID: 3515
		private ErrorCode? _result;

		// Token: 0x04000DBC RID: 3516
		private readonly List<MapIntItem> _receives = new List<MapIntItem>();

		// Token: 0x04000DBD RID: 3517
		private IExtension extensionObject;
	}
}
