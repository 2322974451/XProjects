using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002A7 RID: 679
	[ProtoContract(Name = "GetGuildBonusSendListRes")]
	[Serializable]
	public class GetGuildBonusSendListRes : IExtensible
	{
		// Token: 0x17000BC7 RID: 3015
		// (get) Token: 0x060025E1 RID: 9697 RVA: 0x00049BF8 File Offset: 0x00047DF8
		// (set) Token: 0x060025E2 RID: 9698 RVA: 0x00049C24 File Offset: 0x00047E24
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000BC8 RID: 3016
		// (get) Token: 0x060025E3 RID: 9699 RVA: 0x00049C34 File Offset: 0x00047E34
		// (set) Token: 0x060025E4 RID: 9700 RVA: 0x00049C54 File Offset: 0x00047E54
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x060025E5 RID: 9701 RVA: 0x00049C98 File Offset: 0x00047E98
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x060025E6 RID: 9702 RVA: 0x00049CB0 File Offset: 0x00047EB0
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x17000BC9 RID: 3017
		// (get) Token: 0x060025E7 RID: 9703 RVA: 0x00049CBC File Offset: 0x00047EBC
		[ProtoMember(2, Name = "sendList", DataFormat = DataFormat.Default)]
		public List<GuildBonusAppear> sendList
		{
			get
			{
				return this._sendList;
			}
		}

		// Token: 0x060025E8 RID: 9704 RVA: 0x00049CD4 File Offset: 0x00047ED4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000963 RID: 2403
		private ErrorCode? _error;

		// Token: 0x04000964 RID: 2404
		private readonly List<GuildBonusAppear> _sendList = new List<GuildBonusAppear>();

		// Token: 0x04000965 RID: 2405
		private IExtension extensionObject;
	}
}
