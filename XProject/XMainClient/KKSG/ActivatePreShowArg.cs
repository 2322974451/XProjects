using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200050B RID: 1291
	[ProtoContract(Name = "ActivatePreShowArg")]
	[Serializable]
	public class ActivatePreShowArg : IExtensible
	{
		// Token: 0x1700145C RID: 5212
		// (get) Token: 0x0600428C RID: 17036 RVA: 0x0007EAA0 File Offset: 0x0007CCA0
		// (set) Token: 0x0600428D RID: 17037 RVA: 0x0007EACC File Offset: 0x0007CCCC
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x1700145D RID: 5213
		// (get) Token: 0x0600428E RID: 17038 RVA: 0x0007EADC File Offset: 0x0007CCDC
		// (set) Token: 0x0600428F RID: 17039 RVA: 0x0007EAFC File Offset: 0x0007CCFC
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x06004290 RID: 17040 RVA: 0x0007EB40 File Offset: 0x0007CD40
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06004291 RID: 17041 RVA: 0x0007EB58 File Offset: 0x0007CD58
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x06004292 RID: 17042 RVA: 0x0007EB64 File Offset: 0x0007CD64
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001099 RID: 4249
		private uint? _id;

		// Token: 0x0400109A RID: 4250
		private IExtension extensionObject;
	}
}
