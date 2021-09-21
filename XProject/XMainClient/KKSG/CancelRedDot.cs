using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000395 RID: 917
	[ProtoContract(Name = "CancelRedDot")]
	[Serializable]
	public class CancelRedDot : IExtensible
	{
		// Token: 0x17000F53 RID: 3923
		// (get) Token: 0x06003194 RID: 12692 RVA: 0x0005F7C0 File Offset: 0x0005D9C0
		// (set) Token: 0x06003195 RID: 12693 RVA: 0x0005F7EC File Offset: 0x0005D9EC
		[ProtoMember(1, IsRequired = false, Name = "systemid", DataFormat = DataFormat.TwosComplement)]
		public uint systemid
		{
			get
			{
				return this._systemid ?? 0U;
			}
			set
			{
				this._systemid = new uint?(value);
			}
		}

		// Token: 0x17000F54 RID: 3924
		// (get) Token: 0x06003196 RID: 12694 RVA: 0x0005F7FC File Offset: 0x0005D9FC
		// (set) Token: 0x06003197 RID: 12695 RVA: 0x0005F81C File Offset: 0x0005DA1C
		[XmlIgnore]
		[Browsable(false)]
		public bool systemidSpecified
		{
			get
			{
				return this._systemid != null;
			}
			set
			{
				bool flag = value == (this._systemid == null);
				if (flag)
				{
					this._systemid = (value ? new uint?(this.systemid) : null);
				}
			}
		}

		// Token: 0x06003198 RID: 12696 RVA: 0x0005F860 File Offset: 0x0005DA60
		private bool ShouldSerializesystemid()
		{
			return this.systemidSpecified;
		}

		// Token: 0x06003199 RID: 12697 RVA: 0x0005F878 File Offset: 0x0005DA78
		private void Resetsystemid()
		{
			this.systemidSpecified = false;
		}

		// Token: 0x0600319A RID: 12698 RVA: 0x0005F884 File Offset: 0x0005DA84
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C50 RID: 3152
		private uint? _systemid;

		// Token: 0x04000C51 RID: 3153
		private IExtension extensionObject;
	}
}
