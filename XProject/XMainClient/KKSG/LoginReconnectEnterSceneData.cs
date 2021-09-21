using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000690 RID: 1680
	[ProtoContract(Name = "LoginReconnectEnterSceneData")]
	[Serializable]
	public class LoginReconnectEnterSceneData : IExtensible
	{
		// Token: 0x17002272 RID: 8818
		// (get) Token: 0x06006CD5 RID: 27861 RVA: 0x000D03F8 File Offset: 0x000CE5F8
		// (set) Token: 0x06006CD6 RID: 27862 RVA: 0x000D0410 File Offset: 0x000CE610
		[ProtoMember(1, IsRequired = false, Name = "selfAppearance", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public UnitAppearance selfAppearance
		{
			get
			{
				return this._selfAppearance;
			}
			set
			{
				this._selfAppearance = value;
			}
		}

		// Token: 0x17002273 RID: 8819
		// (get) Token: 0x06006CD7 RID: 27863 RVA: 0x000D041C File Offset: 0x000CE61C
		// (set) Token: 0x06006CD8 RID: 27864 RVA: 0x000D0434 File Offset: 0x000CE634
		[ProtoMember(2, IsRequired = false, Name = "deathinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public DeathInfo deathinfo
		{
			get
			{
				return this._deathinfo;
			}
			set
			{
				this._deathinfo = value;
			}
		}

		// Token: 0x17002274 RID: 8820
		// (get) Token: 0x06006CD9 RID: 27865 RVA: 0x000D0440 File Offset: 0x000CE640
		// (set) Token: 0x06006CDA RID: 27866 RVA: 0x000D046C File Offset: 0x000CE66C
		[ProtoMember(3, IsRequired = false, Name = "isautofight", DataFormat = DataFormat.Default)]
		public bool isautofight
		{
			get
			{
				return this._isautofight ?? false;
			}
			set
			{
				this._isautofight = new bool?(value);
			}
		}

		// Token: 0x17002275 RID: 8821
		// (get) Token: 0x06006CDB RID: 27867 RVA: 0x000D047C File Offset: 0x000CE67C
		// (set) Token: 0x06006CDC RID: 27868 RVA: 0x000D049C File Offset: 0x000CE69C
		[XmlIgnore]
		[Browsable(false)]
		public bool isautofightSpecified
		{
			get
			{
				return this._isautofight != null;
			}
			set
			{
				bool flag = value == (this._isautofight == null);
				if (flag)
				{
					this._isautofight = (value ? new bool?(this.isautofight) : null);
				}
			}
		}

		// Token: 0x06006CDD RID: 27869 RVA: 0x000D04E0 File Offset: 0x000CE6E0
		private bool ShouldSerializeisautofight()
		{
			return this.isautofightSpecified;
		}

		// Token: 0x06006CDE RID: 27870 RVA: 0x000D04F8 File Offset: 0x000CE6F8
		private void Resetisautofight()
		{
			this.isautofightSpecified = false;
		}

		// Token: 0x06006CDF RID: 27871 RVA: 0x000D0504 File Offset: 0x000CE704
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A1A RID: 6682
		private UnitAppearance _selfAppearance = null;

		// Token: 0x04001A1B RID: 6683
		private DeathInfo _deathinfo = null;

		// Token: 0x04001A1C RID: 6684
		private bool? _isautofight;

		// Token: 0x04001A1D RID: 6685
		private IExtension extensionObject;
	}
}
