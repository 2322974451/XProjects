using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002D3 RID: 723
	[ProtoContract(Name = "DailyTaskAskHelpRes")]
	[Serializable]
	public class DailyTaskAskHelpRes : IExtensible
	{
		// Token: 0x17000C66 RID: 3174
		// (get) Token: 0x060027E1 RID: 10209 RVA: 0x0004D83C File Offset: 0x0004BA3C
		// (set) Token: 0x060027E2 RID: 10210 RVA: 0x0004D868 File Offset: 0x0004BA68
		[ProtoMember(1, IsRequired = false, Name = "code", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode code
		{
			get
			{
				return this._code ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._code = new ErrorCode?(value);
			}
		}

		// Token: 0x17000C67 RID: 3175
		// (get) Token: 0x060027E3 RID: 10211 RVA: 0x0004D878 File Offset: 0x0004BA78
		// (set) Token: 0x060027E4 RID: 10212 RVA: 0x0004D898 File Offset: 0x0004BA98
		[XmlIgnore]
		[Browsable(false)]
		public bool codeSpecified
		{
			get
			{
				return this._code != null;
			}
			set
			{
				bool flag = value == (this._code == null);
				if (flag)
				{
					this._code = (value ? new ErrorCode?(this.code) : null);
				}
			}
		}

		// Token: 0x060027E5 RID: 10213 RVA: 0x0004D8DC File Offset: 0x0004BADC
		private bool ShouldSerializecode()
		{
			return this.codeSpecified;
		}

		// Token: 0x060027E6 RID: 10214 RVA: 0x0004D8F4 File Offset: 0x0004BAF4
		private void Resetcode()
		{
			this.codeSpecified = false;
		}

		// Token: 0x17000C68 RID: 3176
		// (get) Token: 0x060027E7 RID: 10215 RVA: 0x0004D900 File Offset: 0x0004BB00
		// (set) Token: 0x060027E8 RID: 10216 RVA: 0x0004D92C File Offset: 0x0004BB2C
		[ProtoMember(2, IsRequired = false, Name = "ask_uid", DataFormat = DataFormat.TwosComplement)]
		public uint ask_uid
		{
			get
			{
				return this._ask_uid ?? 0U;
			}
			set
			{
				this._ask_uid = new uint?(value);
			}
		}

		// Token: 0x17000C69 RID: 3177
		// (get) Token: 0x060027E9 RID: 10217 RVA: 0x0004D93C File Offset: 0x0004BB3C
		// (set) Token: 0x060027EA RID: 10218 RVA: 0x0004D95C File Offset: 0x0004BB5C
		[XmlIgnore]
		[Browsable(false)]
		public bool ask_uidSpecified
		{
			get
			{
				return this._ask_uid != null;
			}
			set
			{
				bool flag = value == (this._ask_uid == null);
				if (flag)
				{
					this._ask_uid = (value ? new uint?(this.ask_uid) : null);
				}
			}
		}

		// Token: 0x060027EB RID: 10219 RVA: 0x0004D9A0 File Offset: 0x0004BBA0
		private bool ShouldSerializeask_uid()
		{
			return this.ask_uidSpecified;
		}

		// Token: 0x060027EC RID: 10220 RVA: 0x0004D9B8 File Offset: 0x0004BBB8
		private void Resetask_uid()
		{
			this.ask_uidSpecified = false;
		}

		// Token: 0x060027ED RID: 10221 RVA: 0x0004D9C4 File Offset: 0x0004BBC4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009EC RID: 2540
		private ErrorCode? _code;

		// Token: 0x040009ED RID: 2541
		private uint? _ask_uid;

		// Token: 0x040009EE RID: 2542
		private IExtension extensionObject;
	}
}
