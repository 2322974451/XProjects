using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000379 RID: 889
	[ProtoContract(Name = "HeroBattleCanUseHeroData")]
	[Serializable]
	public class HeroBattleCanUseHeroData : IExtensible
	{
		// Token: 0x17000F06 RID: 3846
		// (get) Token: 0x06003087 RID: 12423 RVA: 0x0005D9E8 File Offset: 0x0005BBE8
		[ProtoMember(1, Name = "havehero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> havehero
		{
			get
			{
				return this._havehero;
			}
		}

		// Token: 0x17000F07 RID: 3847
		// (get) Token: 0x06003088 RID: 12424 RVA: 0x0005DA00 File Offset: 0x0005BC00
		[ProtoMember(2, Name = "freehero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> freehero
		{
			get
			{
				return this._freehero;
			}
		}

		// Token: 0x17000F08 RID: 3848
		// (get) Token: 0x06003089 RID: 12425 RVA: 0x0005DA18 File Offset: 0x0005BC18
		[ProtoMember(3, Name = "experiencehero", DataFormat = DataFormat.TwosComplement)]
		public List<uint> experiencehero
		{
			get
			{
				return this._experiencehero;
			}
		}

		// Token: 0x17000F09 RID: 3849
		// (get) Token: 0x0600308A RID: 12426 RVA: 0x0005DA30 File Offset: 0x0005BC30
		// (set) Token: 0x0600308B RID: 12427 RVA: 0x0005DA5C File Offset: 0x0005BC5C
		[ProtoMember(4, IsRequired = false, Name = "leftChooseTime", DataFormat = DataFormat.TwosComplement)]
		public uint leftChooseTime
		{
			get
			{
				return this._leftChooseTime ?? 0U;
			}
			set
			{
				this._leftChooseTime = new uint?(value);
			}
		}

		// Token: 0x17000F0A RID: 3850
		// (get) Token: 0x0600308C RID: 12428 RVA: 0x0005DA6C File Offset: 0x0005BC6C
		// (set) Token: 0x0600308D RID: 12429 RVA: 0x0005DA8C File Offset: 0x0005BC8C
		[XmlIgnore]
		[Browsable(false)]
		public bool leftChooseTimeSpecified
		{
			get
			{
				return this._leftChooseTime != null;
			}
			set
			{
				bool flag = value == (this._leftChooseTime == null);
				if (flag)
				{
					this._leftChooseTime = (value ? new uint?(this.leftChooseTime) : null);
				}
			}
		}

		// Token: 0x0600308E RID: 12430 RVA: 0x0005DAD0 File Offset: 0x0005BCD0
		private bool ShouldSerializeleftChooseTime()
		{
			return this.leftChooseTimeSpecified;
		}

		// Token: 0x0600308F RID: 12431 RVA: 0x0005DAE8 File Offset: 0x0005BCE8
		private void ResetleftChooseTime()
		{
			this.leftChooseTimeSpecified = false;
		}

		// Token: 0x06003090 RID: 12432 RVA: 0x0005DAF4 File Offset: 0x0005BCF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C07 RID: 3079
		private readonly List<uint> _havehero = new List<uint>();

		// Token: 0x04000C08 RID: 3080
		private readonly List<uint> _freehero = new List<uint>();

		// Token: 0x04000C09 RID: 3081
		private readonly List<uint> _experiencehero = new List<uint>();

		// Token: 0x04000C0A RID: 3082
		private uint? _leftChooseTime;

		// Token: 0x04000C0B RID: 3083
		private IExtension extensionObject;
	}
}
