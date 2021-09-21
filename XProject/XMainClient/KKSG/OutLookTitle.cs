using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000574 RID: 1396
	[ProtoContract(Name = "OutLookTitle")]
	[Serializable]
	public class OutLookTitle : IExtensible
	{
		// Token: 0x17001613 RID: 5651
		// (get) Token: 0x06004806 RID: 18438 RVA: 0x00088D0C File Offset: 0x00086F0C
		// (set) Token: 0x06004807 RID: 18439 RVA: 0x00088D38 File Offset: 0x00086F38
		[ProtoMember(1, IsRequired = false, Name = "titleID", DataFormat = DataFormat.TwosComplement)]
		public uint titleID
		{
			get
			{
				return this._titleID ?? 0U;
			}
			set
			{
				this._titleID = new uint?(value);
			}
		}

		// Token: 0x17001614 RID: 5652
		// (get) Token: 0x06004808 RID: 18440 RVA: 0x00088D48 File Offset: 0x00086F48
		// (set) Token: 0x06004809 RID: 18441 RVA: 0x00088D68 File Offset: 0x00086F68
		[XmlIgnore]
		[Browsable(false)]
		public bool titleIDSpecified
		{
			get
			{
				return this._titleID != null;
			}
			set
			{
				bool flag = value == (this._titleID == null);
				if (flag)
				{
					this._titleID = (value ? new uint?(this.titleID) : null);
				}
			}
		}

		// Token: 0x0600480A RID: 18442 RVA: 0x00088DAC File Offset: 0x00086FAC
		private bool ShouldSerializetitleID()
		{
			return this.titleIDSpecified;
		}

		// Token: 0x0600480B RID: 18443 RVA: 0x00088DC4 File Offset: 0x00086FC4
		private void ResettitleID()
		{
			this.titleIDSpecified = false;
		}

		// Token: 0x0600480C RID: 18444 RVA: 0x00088DD0 File Offset: 0x00086FD0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001203 RID: 4611
		private uint? _titleID;

		// Token: 0x04001204 RID: 4612
		private IExtension extensionObject;
	}
}
