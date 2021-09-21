using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000686 RID: 1670
	[ProtoContract(Name = "FriendGift")]
	[Serializable]
	public class FriendGift : IExtensible
	{
		// Token: 0x17002208 RID: 8712
		// (get) Token: 0x06006B83 RID: 27523 RVA: 0x000CDADC File Offset: 0x000CBCDC
		// (set) Token: 0x06006B84 RID: 27524 RVA: 0x000CDB08 File Offset: 0x000CBD08
		[ProtoMember(1, IsRequired = false, Name = "SendLeft", DataFormat = DataFormat.TwosComplement)]
		public uint SendLeft
		{
			get
			{
				return this._SendLeft ?? 0U;
			}
			set
			{
				this._SendLeft = new uint?(value);
			}
		}

		// Token: 0x17002209 RID: 8713
		// (get) Token: 0x06006B85 RID: 27525 RVA: 0x000CDB18 File Offset: 0x000CBD18
		// (set) Token: 0x06006B86 RID: 27526 RVA: 0x000CDB38 File Offset: 0x000CBD38
		[XmlIgnore]
		[Browsable(false)]
		public bool SendLeftSpecified
		{
			get
			{
				return this._SendLeft != null;
			}
			set
			{
				bool flag = value == (this._SendLeft == null);
				if (flag)
				{
					this._SendLeft = (value ? new uint?(this.SendLeft) : null);
				}
			}
		}

		// Token: 0x06006B87 RID: 27527 RVA: 0x000CDB7C File Offset: 0x000CBD7C
		private bool ShouldSerializeSendLeft()
		{
			return this.SendLeftSpecified;
		}

		// Token: 0x06006B88 RID: 27528 RVA: 0x000CDB94 File Offset: 0x000CBD94
		private void ResetSendLeft()
		{
			this.SendLeftSpecified = false;
		}

		// Token: 0x1700220A RID: 8714
		// (get) Token: 0x06006B89 RID: 27529 RVA: 0x000CDBA0 File Offset: 0x000CBDA0
		// (set) Token: 0x06006B8A RID: 27530 RVA: 0x000CDBCC File Offset: 0x000CBDCC
		[ProtoMember(2, IsRequired = false, Name = "ReceiveLeft", DataFormat = DataFormat.TwosComplement)]
		public uint ReceiveLeft
		{
			get
			{
				return this._ReceiveLeft ?? 0U;
			}
			set
			{
				this._ReceiveLeft = new uint?(value);
			}
		}

		// Token: 0x1700220B RID: 8715
		// (get) Token: 0x06006B8B RID: 27531 RVA: 0x000CDBDC File Offset: 0x000CBDDC
		// (set) Token: 0x06006B8C RID: 27532 RVA: 0x000CDBFC File Offset: 0x000CBDFC
		[XmlIgnore]
		[Browsable(false)]
		public bool ReceiveLeftSpecified
		{
			get
			{
				return this._ReceiveLeft != null;
			}
			set
			{
				bool flag = value == (this._ReceiveLeft == null);
				if (flag)
				{
					this._ReceiveLeft = (value ? new uint?(this.ReceiveLeft) : null);
				}
			}
		}

		// Token: 0x06006B8D RID: 27533 RVA: 0x000CDC40 File Offset: 0x000CBE40
		private bool ShouldSerializeReceiveLeft()
		{
			return this.ReceiveLeftSpecified;
		}

		// Token: 0x06006B8E RID: 27534 RVA: 0x000CDC58 File Offset: 0x000CBE58
		private void ResetReceiveLeft()
		{
			this.ReceiveLeftSpecified = false;
		}

		// Token: 0x06006B8F RID: 27535 RVA: 0x000CDC64 File Offset: 0x000CBE64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019DB RID: 6619
		private uint? _SendLeft;

		// Token: 0x040019DC RID: 6620
		private uint? _ReceiveLeft;

		// Token: 0x040019DD RID: 6621
		private IExtension extensionObject;
	}
}
