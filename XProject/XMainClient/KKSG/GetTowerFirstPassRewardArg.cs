using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000232 RID: 562
	[ProtoContract(Name = "GetTowerFirstPassRewardArg")]
	[Serializable]
	public class GetTowerFirstPassRewardArg : IExtensible
	{
		// Token: 0x170009C3 RID: 2499
		// (get) Token: 0x06001F4F RID: 8015 RVA: 0x0003D660 File Offset: 0x0003B860
		// (set) Token: 0x06001F50 RID: 8016 RVA: 0x0003D68C File Offset: 0x0003B88C
		[ProtoMember(1, IsRequired = false, Name = "floor", DataFormat = DataFormat.TwosComplement)]
		public int floor
		{
			get
			{
				return this._floor ?? 0;
			}
			set
			{
				this._floor = new int?(value);
			}
		}

		// Token: 0x170009C4 RID: 2500
		// (get) Token: 0x06001F51 RID: 8017 RVA: 0x0003D69C File Offset: 0x0003B89C
		// (set) Token: 0x06001F52 RID: 8018 RVA: 0x0003D6BC File Offset: 0x0003B8BC
		[XmlIgnore]
		[Browsable(false)]
		public bool floorSpecified
		{
			get
			{
				return this._floor != null;
			}
			set
			{
				bool flag = value == (this._floor == null);
				if (flag)
				{
					this._floor = (value ? new int?(this.floor) : null);
				}
			}
		}

		// Token: 0x06001F53 RID: 8019 RVA: 0x0003D700 File Offset: 0x0003B900
		private bool ShouldSerializefloor()
		{
			return this.floorSpecified;
		}

		// Token: 0x06001F54 RID: 8020 RVA: 0x0003D718 File Offset: 0x0003B918
		private void Resetfloor()
		{
			this.floorSpecified = false;
		}

		// Token: 0x06001F55 RID: 8021 RVA: 0x0003D724 File Offset: 0x0003B924
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007CF RID: 1999
		private int? _floor;

		// Token: 0x040007D0 RID: 2000
		private IExtension extensionObject;
	}
}
