using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000419 RID: 1049
	[ProtoContract(Name = "GetPlatShareAwardArg")]
	[Serializable]
	public class GetPlatShareAwardArg : IExtensible
	{
		// Token: 0x17001124 RID: 4388
		// (get) Token: 0x060037C9 RID: 14281 RVA: 0x0006AD18 File Offset: 0x00068F18
		// (set) Token: 0x060037CA RID: 14282 RVA: 0x0006AD44 File Offset: 0x00068F44
		[ProtoMember(1, IsRequired = false, Name = "scene_id", DataFormat = DataFormat.TwosComplement)]
		public uint scene_id
		{
			get
			{
				return this._scene_id ?? 0U;
			}
			set
			{
				this._scene_id = new uint?(value);
			}
		}

		// Token: 0x17001125 RID: 4389
		// (get) Token: 0x060037CB RID: 14283 RVA: 0x0006AD54 File Offset: 0x00068F54
		// (set) Token: 0x060037CC RID: 14284 RVA: 0x0006AD74 File Offset: 0x00068F74
		[XmlIgnore]
		[Browsable(false)]
		public bool scene_idSpecified
		{
			get
			{
				return this._scene_id != null;
			}
			set
			{
				bool flag = value == (this._scene_id == null);
				if (flag)
				{
					this._scene_id = (value ? new uint?(this.scene_id) : null);
				}
			}
		}

		// Token: 0x060037CD RID: 14285 RVA: 0x0006ADB8 File Offset: 0x00068FB8
		private bool ShouldSerializescene_id()
		{
			return this.scene_idSpecified;
		}

		// Token: 0x060037CE RID: 14286 RVA: 0x0006ADD0 File Offset: 0x00068FD0
		private void Resetscene_id()
		{
			this.scene_idSpecified = false;
		}

		// Token: 0x060037CF RID: 14287 RVA: 0x0006ADDC File Offset: 0x00068FDC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DD2 RID: 3538
		private uint? _scene_id;

		// Token: 0x04000DD3 RID: 3539
		private IExtension extensionObject;
	}
}
