using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001D6 RID: 470
	[ProtoContract(Name = "ChooseRollReqArg")]
	[Serializable]
	public class ChooseRollReqArg : IExtensible
	{
		// Token: 0x17000891 RID: 2193
		// (get) Token: 0x06001B3C RID: 6972 RVA: 0x00035D64 File Offset: 0x00033F64
		// (set) Token: 0x06001B3D RID: 6973 RVA: 0x00035D90 File Offset: 0x00033F90
		[ProtoMember(1, IsRequired = false, Name = "chooseType", DataFormat = DataFormat.TwosComplement)]
		public int chooseType
		{
			get
			{
				return this._chooseType ?? 0;
			}
			set
			{
				this._chooseType = new int?(value);
			}
		}

		// Token: 0x17000892 RID: 2194
		// (get) Token: 0x06001B3E RID: 6974 RVA: 0x00035DA0 File Offset: 0x00033FA0
		// (set) Token: 0x06001B3F RID: 6975 RVA: 0x00035DC0 File Offset: 0x00033FC0
		[XmlIgnore]
		[Browsable(false)]
		public bool chooseTypeSpecified
		{
			get
			{
				return this._chooseType != null;
			}
			set
			{
				bool flag = value == (this._chooseType == null);
				if (flag)
				{
					this._chooseType = (value ? new int?(this.chooseType) : null);
				}
			}
		}

		// Token: 0x06001B40 RID: 6976 RVA: 0x00035E04 File Offset: 0x00034004
		private bool ShouldSerializechooseType()
		{
			return this.chooseTypeSpecified;
		}

		// Token: 0x06001B41 RID: 6977 RVA: 0x00035E1C File Offset: 0x0003401C
		private void ResetchooseType()
		{
			this.chooseTypeSpecified = false;
		}

		// Token: 0x17000893 RID: 2195
		// (get) Token: 0x06001B42 RID: 6978 RVA: 0x00035E28 File Offset: 0x00034028
		// (set) Token: 0x06001B43 RID: 6979 RVA: 0x00035E40 File Offset: 0x00034040
		[ProtoMember(2, IsRequired = false, Name = "info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public EnemyDoodadInfo info
		{
			get
			{
				return this._info;
			}
			set
			{
				this._info = value;
			}
		}

		// Token: 0x06001B44 RID: 6980 RVA: 0x00035E4C File Offset: 0x0003404C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006C9 RID: 1737
		private int? _chooseType;

		// Token: 0x040006CA RID: 1738
		private EnemyDoodadInfo _info = null;

		// Token: 0x040006CB RID: 1739
		private IExtension extensionObject;
	}
}
