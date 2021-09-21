using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003AB RID: 939
	[ProtoContract(Name = "GuildAuctItemTime")]
	[Serializable]
	public class GuildAuctItemTime : IExtensible
	{
		// Token: 0x17000F90 RID: 3984
		// (get) Token: 0x0600326B RID: 12907 RVA: 0x00060FB4 File Offset: 0x0005F1B4
		// (set) Token: 0x0600326C RID: 12908 RVA: 0x00060FE0 File Offset: 0x0005F1E0
		[ProtoMember(1, IsRequired = false, Name = "auct_type", DataFormat = DataFormat.TwosComplement)]
		public uint auct_type
		{
			get
			{
				return this._auct_type ?? 0U;
			}
			set
			{
				this._auct_type = new uint?(value);
			}
		}

		// Token: 0x17000F91 RID: 3985
		// (get) Token: 0x0600326D RID: 12909 RVA: 0x00060FF0 File Offset: 0x0005F1F0
		// (set) Token: 0x0600326E RID: 12910 RVA: 0x00061010 File Offset: 0x0005F210
		[XmlIgnore]
		[Browsable(false)]
		public bool auct_typeSpecified
		{
			get
			{
				return this._auct_type != null;
			}
			set
			{
				bool flag = value == (this._auct_type == null);
				if (flag)
				{
					this._auct_type = (value ? new uint?(this.auct_type) : null);
				}
			}
		}

		// Token: 0x0600326F RID: 12911 RVA: 0x00061054 File Offset: 0x0005F254
		private bool ShouldSerializeauct_type()
		{
			return this.auct_typeSpecified;
		}

		// Token: 0x06003270 RID: 12912 RVA: 0x0006106C File Offset: 0x0005F26C
		private void Resetauct_type()
		{
			this.auct_typeSpecified = false;
		}

		// Token: 0x06003271 RID: 12913 RVA: 0x00061078 File Offset: 0x0005F278
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C89 RID: 3209
		private uint? _auct_type;

		// Token: 0x04000C8A RID: 3210
		private IExtension extensionObject;
	}
}
