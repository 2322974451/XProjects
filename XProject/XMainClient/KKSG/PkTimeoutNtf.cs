using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000DC RID: 220
	[ProtoContract(Name = "PkTimeoutNtf")]
	[Serializable]
	public class PkTimeoutNtf : IExtensible
	{
		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06000E16 RID: 3606 RVA: 0x0001D408 File Offset: 0x0001B608
		// (set) Token: 0x06000E17 RID: 3607 RVA: 0x0001D434 File Offset: 0x0001B634
		[ProtoMember(1, IsRequired = false, Name = "timeout", DataFormat = DataFormat.TwosComplement)]
		public uint timeout
		{
			get
			{
				return this._timeout ?? 0U;
			}
			set
			{
				this._timeout = new uint?(value);
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06000E18 RID: 3608 RVA: 0x0001D444 File Offset: 0x0001B644
		// (set) Token: 0x06000E19 RID: 3609 RVA: 0x0001D464 File Offset: 0x0001B664
		[XmlIgnore]
		[Browsable(false)]
		public bool timeoutSpecified
		{
			get
			{
				return this._timeout != null;
			}
			set
			{
				bool flag = value == (this._timeout == null);
				if (flag)
				{
					this._timeout = (value ? new uint?(this.timeout) : null);
				}
			}
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x0001D4A8 File Offset: 0x0001B6A8
		private bool ShouldSerializetimeout()
		{
			return this.timeoutSpecified;
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x0001D4C0 File Offset: 0x0001B6C0
		private void Resettimeout()
		{
			this.timeoutSpecified = false;
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x0001D4CC File Offset: 0x0001B6CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400038B RID: 907
		private uint? _timeout;

		// Token: 0x0400038C RID: 908
		private IExtension extensionObject;
	}
}
