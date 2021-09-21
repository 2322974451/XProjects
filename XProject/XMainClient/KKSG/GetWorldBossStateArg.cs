using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000065 RID: 101
	[ProtoContract(Name = "GetWorldBossStateArg")]
	[Serializable]
	public class GetWorldBossStateArg : IExtensible
	{
		// Token: 0x17000235 RID: 565
		// (get) Token: 0x060006CB RID: 1739 RVA: 0x0000FAF0 File Offset: 0x0000DCF0
		// (set) Token: 0x060006CC RID: 1740 RVA: 0x0000FB1C File Offset: 0x0000DD1C
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x060006CD RID: 1741 RVA: 0x0000FB2C File Offset: 0x0000DD2C
		// (set) Token: 0x060006CE RID: 1742 RVA: 0x0000FB4C File Offset: 0x0000DD4C
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0000FB90 File Offset: 0x0000DD90
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x0000FBA8 File Offset: 0x0000DDA8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x0000FBB4 File Offset: 0x0000DDB4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001B8 RID: 440
		private uint? _type;

		// Token: 0x040001B9 RID: 441
		private IExtension extensionObject;
	}
}
