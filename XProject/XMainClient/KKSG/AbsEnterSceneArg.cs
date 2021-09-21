using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003FE RID: 1022
	[ProtoContract(Name = "AbsEnterSceneArg")]
	[Serializable]
	public class AbsEnterSceneArg : IExtensible
	{
		// Token: 0x170010A4 RID: 4260
		// (get) Token: 0x0600361D RID: 13853 RVA: 0x00067A94 File Offset: 0x00065C94
		// (set) Token: 0x0600361E RID: 13854 RVA: 0x00067AC0 File Offset: 0x00065CC0
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

		// Token: 0x170010A5 RID: 4261
		// (get) Token: 0x0600361F RID: 13855 RVA: 0x00067AD0 File Offset: 0x00065CD0
		// (set) Token: 0x06003620 RID: 13856 RVA: 0x00067AF0 File Offset: 0x00065CF0
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

		// Token: 0x06003621 RID: 13857 RVA: 0x00067B34 File Offset: 0x00065D34
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06003622 RID: 13858 RVA: 0x00067B4C File Offset: 0x00065D4C
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x06003623 RID: 13859 RVA: 0x00067B58 File Offset: 0x00065D58
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D74 RID: 3444
		private uint? _id;

		// Token: 0x04000D75 RID: 3445
		private IExtension extensionObject;
	}
}
