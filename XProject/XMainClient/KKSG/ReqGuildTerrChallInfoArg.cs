using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200033D RID: 829
	[ProtoContract(Name = "ReqGuildTerrChallInfoArg")]
	[Serializable]
	public class ReqGuildTerrChallInfoArg : IExtensible
	{
		// Token: 0x17000E25 RID: 3621
		// (get) Token: 0x06002D93 RID: 11667 RVA: 0x00058320 File Offset: 0x00056520
		// (set) Token: 0x06002D94 RID: 11668 RVA: 0x0005834C File Offset: 0x0005654C
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

		// Token: 0x17000E26 RID: 3622
		// (get) Token: 0x06002D95 RID: 11669 RVA: 0x0005835C File Offset: 0x0005655C
		// (set) Token: 0x06002D96 RID: 11670 RVA: 0x0005837C File Offset: 0x0005657C
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

		// Token: 0x06002D97 RID: 11671 RVA: 0x000583C0 File Offset: 0x000565C0
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06002D98 RID: 11672 RVA: 0x000583D8 File Offset: 0x000565D8
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x06002D99 RID: 11673 RVA: 0x000583E4 File Offset: 0x000565E4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B50 RID: 2896
		private uint? _id;

		// Token: 0x04000B51 RID: 2897
		private IExtension extensionObject;
	}
}
