using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200061C RID: 1564
	[ProtoContract(Name = "ActivateHairColor")]
	[Serializable]
	public class ActivateHairColor : IExtensible
	{
		// Token: 0x17001DEC RID: 7660
		// (get) Token: 0x06005F3C RID: 24380 RVA: 0x000B5A58 File Offset: 0x000B3C58
		// (set) Token: 0x06005F3D RID: 24381 RVA: 0x000B5A84 File Offset: 0x000B3C84
		[ProtoMember(1, IsRequired = false, Name = "hair_id", DataFormat = DataFormat.TwosComplement)]
		public uint hair_id
		{
			get
			{
				return this._hair_id ?? 0U;
			}
			set
			{
				this._hair_id = new uint?(value);
			}
		}

		// Token: 0x17001DED RID: 7661
		// (get) Token: 0x06005F3E RID: 24382 RVA: 0x000B5A94 File Offset: 0x000B3C94
		// (set) Token: 0x06005F3F RID: 24383 RVA: 0x000B5AB4 File Offset: 0x000B3CB4
		[XmlIgnore]
		[Browsable(false)]
		public bool hair_idSpecified
		{
			get
			{
				return this._hair_id != null;
			}
			set
			{
				bool flag = value == (this._hair_id == null);
				if (flag)
				{
					this._hair_id = (value ? new uint?(this.hair_id) : null);
				}
			}
		}

		// Token: 0x06005F40 RID: 24384 RVA: 0x000B5AF8 File Offset: 0x000B3CF8
		private bool ShouldSerializehair_id()
		{
			return this.hair_idSpecified;
		}

		// Token: 0x06005F41 RID: 24385 RVA: 0x000B5B10 File Offset: 0x000B3D10
		private void Resethair_id()
		{
			this.hair_idSpecified = false;
		}

		// Token: 0x17001DEE RID: 7662
		// (get) Token: 0x06005F42 RID: 24386 RVA: 0x000B5B1C File Offset: 0x000B3D1C
		[ProtoMember(2, Name = "hair_color_id", DataFormat = DataFormat.TwosComplement)]
		public List<uint> hair_color_id
		{
			get
			{
				return this._hair_color_id;
			}
		}

		// Token: 0x06005F43 RID: 24387 RVA: 0x000B5B34 File Offset: 0x000B3D34
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001721 RID: 5921
		private uint? _hair_id;

		// Token: 0x04001722 RID: 5922
		private readonly List<uint> _hair_color_id = new List<uint>();

		// Token: 0x04001723 RID: 5923
		private IExtension extensionObject;
	}
}
