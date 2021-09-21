using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000646 RID: 1606
	[ProtoContract(Name = "AncientTimes")]
	[Serializable]
	public class AncientTimes : IExtensible
	{
		// Token: 0x17001F7A RID: 8058
		// (get) Token: 0x060063D5 RID: 25557 RVA: 0x000BE85C File Offset: 0x000BCA5C
		// (set) Token: 0x060063D6 RID: 25558 RVA: 0x000BE888 File Offset: 0x000BCA88
		[ProtoMember(1, IsRequired = false, Name = "award", DataFormat = DataFormat.TwosComplement)]
		public uint award
		{
			get
			{
				return this._award ?? 0U;
			}
			set
			{
				this._award = new uint?(value);
			}
		}

		// Token: 0x17001F7B RID: 8059
		// (get) Token: 0x060063D7 RID: 25559 RVA: 0x000BE898 File Offset: 0x000BCA98
		// (set) Token: 0x060063D8 RID: 25560 RVA: 0x000BE8B8 File Offset: 0x000BCAB8
		[XmlIgnore]
		[Browsable(false)]
		public bool awardSpecified
		{
			get
			{
				return this._award != null;
			}
			set
			{
				bool flag = value == (this._award == null);
				if (flag)
				{
					this._award = (value ? new uint?(this.award) : null);
				}
			}
		}

		// Token: 0x060063D9 RID: 25561 RVA: 0x000BE8FC File Offset: 0x000BCAFC
		private bool ShouldSerializeaward()
		{
			return this.awardSpecified;
		}

		// Token: 0x060063DA RID: 25562 RVA: 0x000BE914 File Offset: 0x000BCB14
		private void Resetaward()
		{
			this.awardSpecified = false;
		}

		// Token: 0x060063DB RID: 25563 RVA: 0x000BE920 File Offset: 0x000BCB20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001832 RID: 6194
		private uint? _award;

		// Token: 0x04001833 RID: 6195
		private IExtension extensionObject;
	}
}
