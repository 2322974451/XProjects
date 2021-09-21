using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003EE RID: 1006
	[ProtoContract(Name = "TalkGuildCampSpriteArg")]
	[Serializable]
	public class TalkGuildCampSpriteArg : IExtensible
	{
		// Token: 0x1700106E RID: 4206
		// (get) Token: 0x0600356B RID: 13675 RVA: 0x000665F8 File Offset: 0x000647F8
		// (set) Token: 0x0600356C RID: 13676 RVA: 0x00066625 File Offset: 0x00064825
		[ProtoMember(1, IsRequired = false, Name = "enemy_id", DataFormat = DataFormat.TwosComplement)]
		public ulong enemy_id
		{
			get
			{
				return this._enemy_id ?? 0UL;
			}
			set
			{
				this._enemy_id = new ulong?(value);
			}
		}

		// Token: 0x1700106F RID: 4207
		// (get) Token: 0x0600356D RID: 13677 RVA: 0x00066634 File Offset: 0x00064834
		// (set) Token: 0x0600356E RID: 13678 RVA: 0x00066654 File Offset: 0x00064854
		[XmlIgnore]
		[Browsable(false)]
		public bool enemy_idSpecified
		{
			get
			{
				return this._enemy_id != null;
			}
			set
			{
				bool flag = value == (this._enemy_id == null);
				if (flag)
				{
					this._enemy_id = (value ? new ulong?(this.enemy_id) : null);
				}
			}
		}

		// Token: 0x0600356F RID: 13679 RVA: 0x00066698 File Offset: 0x00064898
		private bool ShouldSerializeenemy_id()
		{
			return this.enemy_idSpecified;
		}

		// Token: 0x06003570 RID: 13680 RVA: 0x000666B0 File Offset: 0x000648B0
		private void Resetenemy_id()
		{
			this.enemy_idSpecified = false;
		}

		// Token: 0x06003571 RID: 13681 RVA: 0x000666BC File Offset: 0x000648BC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D45 RID: 3397
		private ulong? _enemy_id;

		// Token: 0x04000D46 RID: 3398
		private IExtension extensionObject;
	}
}
