using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002AA RID: 682
	[ProtoContract(Name = "SendGuildBonusNtfData")]
	[Serializable]
	public class SendGuildBonusNtfData : IExtensible
	{
		// Token: 0x17000BCE RID: 3022
		// (get) Token: 0x060025FA RID: 9722 RVA: 0x00049EBC File Offset: 0x000480BC
		// (set) Token: 0x060025FB RID: 9723 RVA: 0x00049EE8 File Offset: 0x000480E8
		[ProtoMember(1, IsRequired = false, Name = "hasLeftSend", DataFormat = DataFormat.Default)]
		public bool hasLeftSend
		{
			get
			{
				return this._hasLeftSend ?? false;
			}
			set
			{
				this._hasLeftSend = new bool?(value);
			}
		}

		// Token: 0x17000BCF RID: 3023
		// (get) Token: 0x060025FC RID: 9724 RVA: 0x00049EF8 File Offset: 0x000480F8
		// (set) Token: 0x060025FD RID: 9725 RVA: 0x00049F18 File Offset: 0x00048118
		[XmlIgnore]
		[Browsable(false)]
		public bool hasLeftSendSpecified
		{
			get
			{
				return this._hasLeftSend != null;
			}
			set
			{
				bool flag = value == (this._hasLeftSend == null);
				if (flag)
				{
					this._hasLeftSend = (value ? new bool?(this.hasLeftSend) : null);
				}
			}
		}

		// Token: 0x060025FE RID: 9726 RVA: 0x00049F5C File Offset: 0x0004815C
		private bool ShouldSerializehasLeftSend()
		{
			return this.hasLeftSendSpecified;
		}

		// Token: 0x060025FF RID: 9727 RVA: 0x00049F74 File Offset: 0x00048174
		private void ResethasLeftSend()
		{
			this.hasLeftSendSpecified = false;
		}

		// Token: 0x06002600 RID: 9728 RVA: 0x00049F80 File Offset: 0x00048180
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400096A RID: 2410
		private bool? _hasLeftSend;

		// Token: 0x0400096B RID: 2411
		private IExtension extensionObject;
	}
}
