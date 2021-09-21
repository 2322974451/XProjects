using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002D1 RID: 721
	[ProtoContract(Name = "WorldLevel")]
	[Serializable]
	public class WorldLevel : IExtensible
	{
		// Token: 0x17000C60 RID: 3168
		// (get) Token: 0x060027CB RID: 10187 RVA: 0x0004D5B0 File Offset: 0x0004B7B0
		// (set) Token: 0x060027CC RID: 10188 RVA: 0x0004D5DC File Offset: 0x0004B7DC
		[ProtoMember(1, IsRequired = false, Name = "worldLevel", DataFormat = DataFormat.TwosComplement)]
		public uint worldLevel
		{
			get
			{
				return this._worldLevel ?? 0U;
			}
			set
			{
				this._worldLevel = new uint?(value);
			}
		}

		// Token: 0x17000C61 RID: 3169
		// (get) Token: 0x060027CD RID: 10189 RVA: 0x0004D5EC File Offset: 0x0004B7EC
		// (set) Token: 0x060027CE RID: 10190 RVA: 0x0004D60C File Offset: 0x0004B80C
		[XmlIgnore]
		[Browsable(false)]
		public bool worldLevelSpecified
		{
			get
			{
				return this._worldLevel != null;
			}
			set
			{
				bool flag = value == (this._worldLevel == null);
				if (flag)
				{
					this._worldLevel = (value ? new uint?(this.worldLevel) : null);
				}
			}
		}

		// Token: 0x060027CF RID: 10191 RVA: 0x0004D650 File Offset: 0x0004B850
		private bool ShouldSerializeworldLevel()
		{
			return this.worldLevelSpecified;
		}

		// Token: 0x060027D0 RID: 10192 RVA: 0x0004D668 File Offset: 0x0004B868
		private void ResetworldLevel()
		{
			this.worldLevelSpecified = false;
		}

		// Token: 0x060027D1 RID: 10193 RVA: 0x0004D674 File Offset: 0x0004B874
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009E7 RID: 2535
		private uint? _worldLevel;

		// Token: 0x040009E8 RID: 2536
		private IExtension extensionObject;
	}
}
