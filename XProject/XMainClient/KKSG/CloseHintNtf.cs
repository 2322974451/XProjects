using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003B6 RID: 950
	[ProtoContract(Name = "CloseHintNtf")]
	[Serializable]
	public class CloseHintNtf : IExtensible
	{
		// Token: 0x17000FA2 RID: 4002
		// (get) Token: 0x060032B4 RID: 12980 RVA: 0x00061794 File Offset: 0x0005F994
		// (set) Token: 0x060032B5 RID: 12981 RVA: 0x000617C0 File Offset: 0x0005F9C0
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

		// Token: 0x17000FA3 RID: 4003
		// (get) Token: 0x060032B6 RID: 12982 RVA: 0x000617D0 File Offset: 0x0005F9D0
		// (set) Token: 0x060032B7 RID: 12983 RVA: 0x000617F0 File Offset: 0x0005F9F0
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

		// Token: 0x060032B8 RID: 12984 RVA: 0x00061834 File Offset: 0x0005FA34
		private bool ShouldSerializesystemid()
		{
			return this.systemidSpecified;
		}

		// Token: 0x060032B9 RID: 12985 RVA: 0x0006184C File Offset: 0x0005FA4C
		private void Resetsystemid()
		{
			this.systemidSpecified = false;
		}

		// Token: 0x060032BA RID: 12986 RVA: 0x00061858 File Offset: 0x0005FA58
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C9E RID: 3230
		private uint? _systemid;

		// Token: 0x04000C9F RID: 3231
		private IExtension extensionObject;
	}
}
