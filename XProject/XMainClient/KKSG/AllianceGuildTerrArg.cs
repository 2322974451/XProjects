using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000349 RID: 841
	[ProtoContract(Name = "AllianceGuildTerrArg")]
	[Serializable]
	public class AllianceGuildTerrArg : IExtensible
	{
		// Token: 0x17000E42 RID: 3650
		// (get) Token: 0x06002DF4 RID: 11764 RVA: 0x00058E44 File Offset: 0x00057044
		// (set) Token: 0x06002DF5 RID: 11765 RVA: 0x00058E70 File Offset: 0x00057070
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

		// Token: 0x17000E43 RID: 3651
		// (get) Token: 0x06002DF6 RID: 11766 RVA: 0x00058E80 File Offset: 0x00057080
		// (set) Token: 0x06002DF7 RID: 11767 RVA: 0x00058EA0 File Offset: 0x000570A0
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

		// Token: 0x06002DF8 RID: 11768 RVA: 0x00058EE4 File Offset: 0x000570E4
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06002DF9 RID: 11769 RVA: 0x00058EFC File Offset: 0x000570FC
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x06002DFA RID: 11770 RVA: 0x00058F08 File Offset: 0x00057108
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B6E RID: 2926
		private uint? _id;

		// Token: 0x04000B6F RID: 2927
		private IExtension extensionObject;
	}
}
