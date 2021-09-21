using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005A9 RID: 1449
	[ProtoContract(Name = "ChatParamSpectate")]
	[Serializable]
	public class ChatParamSpectate : IExtensible
	{
		// Token: 0x17001838 RID: 6200
		// (get) Token: 0x06004E7F RID: 20095 RVA: 0x000954B8 File Offset: 0x000936B8
		// (set) Token: 0x06004E80 RID: 20096 RVA: 0x000954E4 File Offset: 0x000936E4
		[ProtoMember(1, IsRequired = false, Name = "liveid", DataFormat = DataFormat.TwosComplement)]
		public uint liveid
		{
			get
			{
				return this._liveid ?? 0U;
			}
			set
			{
				this._liveid = new uint?(value);
			}
		}

		// Token: 0x17001839 RID: 6201
		// (get) Token: 0x06004E81 RID: 20097 RVA: 0x000954F4 File Offset: 0x000936F4
		// (set) Token: 0x06004E82 RID: 20098 RVA: 0x00095514 File Offset: 0x00093714
		[XmlIgnore]
		[Browsable(false)]
		public bool liveidSpecified
		{
			get
			{
				return this._liveid != null;
			}
			set
			{
				bool flag = value == (this._liveid == null);
				if (flag)
				{
					this._liveid = (value ? new uint?(this.liveid) : null);
				}
			}
		}

		// Token: 0x06004E83 RID: 20099 RVA: 0x00095558 File Offset: 0x00093758
		private bool ShouldSerializeliveid()
		{
			return this.liveidSpecified;
		}

		// Token: 0x06004E84 RID: 20100 RVA: 0x00095570 File Offset: 0x00093770
		private void Resetliveid()
		{
			this.liveidSpecified = false;
		}

		// Token: 0x1700183A RID: 6202
		// (get) Token: 0x06004E85 RID: 20101 RVA: 0x0009557C File Offset: 0x0009377C
		// (set) Token: 0x06004E86 RID: 20102 RVA: 0x000955A8 File Offset: 0x000937A8
		[ProtoMember(2, IsRequired = false, Name = "livetype", DataFormat = DataFormat.TwosComplement)]
		public uint livetype
		{
			get
			{
				return this._livetype ?? 0U;
			}
			set
			{
				this._livetype = new uint?(value);
			}
		}

		// Token: 0x1700183B RID: 6203
		// (get) Token: 0x06004E87 RID: 20103 RVA: 0x000955B8 File Offset: 0x000937B8
		// (set) Token: 0x06004E88 RID: 20104 RVA: 0x000955D8 File Offset: 0x000937D8
		[XmlIgnore]
		[Browsable(false)]
		public bool livetypeSpecified
		{
			get
			{
				return this._livetype != null;
			}
			set
			{
				bool flag = value == (this._livetype == null);
				if (flag)
				{
					this._livetype = (value ? new uint?(this.livetype) : null);
				}
			}
		}

		// Token: 0x06004E89 RID: 20105 RVA: 0x0009561C File Offset: 0x0009381C
		private bool ShouldSerializelivetype()
		{
			return this.livetypeSpecified;
		}

		// Token: 0x06004E8A RID: 20106 RVA: 0x00095634 File Offset: 0x00093834
		private void Resetlivetype()
		{
			this.livetypeSpecified = false;
		}

		// Token: 0x06004E8B RID: 20107 RVA: 0x00095640 File Offset: 0x00093840
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400136A RID: 4970
		private uint? _liveid;

		// Token: 0x0400136B RID: 4971
		private uint? _livetype;

		// Token: 0x0400136C RID: 4972
		private IExtension extensionObject;
	}
}
