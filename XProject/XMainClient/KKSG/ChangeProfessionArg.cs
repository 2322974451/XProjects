using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000393 RID: 915
	[ProtoContract(Name = "ChangeProfessionArg")]
	[Serializable]
	public class ChangeProfessionArg : IExtensible
	{
		// Token: 0x17000F4F RID: 3919
		// (get) Token: 0x06003184 RID: 12676 RVA: 0x0005F5F8 File Offset: 0x0005D7F8
		// (set) Token: 0x06003185 RID: 12677 RVA: 0x0005F624 File Offset: 0x0005D824
		[ProtoMember(1, IsRequired = false, Name = "pro", DataFormat = DataFormat.TwosComplement)]
		public uint pro
		{
			get
			{
				return this._pro ?? 0U;
			}
			set
			{
				this._pro = new uint?(value);
			}
		}

		// Token: 0x17000F50 RID: 3920
		// (get) Token: 0x06003186 RID: 12678 RVA: 0x0005F634 File Offset: 0x0005D834
		// (set) Token: 0x06003187 RID: 12679 RVA: 0x0005F654 File Offset: 0x0005D854
		[XmlIgnore]
		[Browsable(false)]
		public bool proSpecified
		{
			get
			{
				return this._pro != null;
			}
			set
			{
				bool flag = value == (this._pro == null);
				if (flag)
				{
					this._pro = (value ? new uint?(this.pro) : null);
				}
			}
		}

		// Token: 0x06003188 RID: 12680 RVA: 0x0005F698 File Offset: 0x0005D898
		private bool ShouldSerializepro()
		{
			return this.proSpecified;
		}

		// Token: 0x06003189 RID: 12681 RVA: 0x0005F6B0 File Offset: 0x0005D8B0
		private void Resetpro()
		{
			this.proSpecified = false;
		}

		// Token: 0x0600318A RID: 12682 RVA: 0x0005F6BC File Offset: 0x0005D8BC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C4C RID: 3148
		private uint? _pro;

		// Token: 0x04000C4D RID: 3149
		private IExtension extensionObject;
	}
}
