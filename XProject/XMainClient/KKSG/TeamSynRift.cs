using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200059B RID: 1435
	[ProtoContract(Name = "TeamSynRift")]
	[Serializable]
	public class TeamSynRift : IExtensible
	{
		// Token: 0x170017AC RID: 6060
		// (get) Token: 0x06004CDB RID: 19675 RVA: 0x00092338 File Offset: 0x00090538
		// (set) Token: 0x06004CDC RID: 19676 RVA: 0x00092364 File Offset: 0x00090564
		[ProtoMember(1, IsRequired = false, Name = "riftid", DataFormat = DataFormat.TwosComplement)]
		public uint riftid
		{
			get
			{
				return this._riftid ?? 0U;
			}
			set
			{
				this._riftid = new uint?(value);
			}
		}

		// Token: 0x170017AD RID: 6061
		// (get) Token: 0x06004CDD RID: 19677 RVA: 0x00092374 File Offset: 0x00090574
		// (set) Token: 0x06004CDE RID: 19678 RVA: 0x00092394 File Offset: 0x00090594
		[XmlIgnore]
		[Browsable(false)]
		public bool riftidSpecified
		{
			get
			{
				return this._riftid != null;
			}
			set
			{
				bool flag = value == (this._riftid == null);
				if (flag)
				{
					this._riftid = (value ? new uint?(this.riftid) : null);
				}
			}
		}

		// Token: 0x06004CDF RID: 19679 RVA: 0x000923D8 File Offset: 0x000905D8
		private bool ShouldSerializeriftid()
		{
			return this.riftidSpecified;
		}

		// Token: 0x06004CE0 RID: 19680 RVA: 0x000923F0 File Offset: 0x000905F0
		private void Resetriftid()
		{
			this.riftidSpecified = false;
		}

		// Token: 0x170017AE RID: 6062
		// (get) Token: 0x06004CE1 RID: 19681 RVA: 0x000923FC File Offset: 0x000905FC
		// (set) Token: 0x06004CE2 RID: 19682 RVA: 0x00092414 File Offset: 0x00090614
		[ProtoMember(2, IsRequired = false, Name = "floorinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GlobalRiftFloorInfo floorinfo
		{
			get
			{
				return this._floorinfo;
			}
			set
			{
				this._floorinfo = value;
			}
		}

		// Token: 0x06004CE3 RID: 19683 RVA: 0x00092420 File Offset: 0x00090620
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400130B RID: 4875
		private uint? _riftid;

		// Token: 0x0400130C RID: 4876
		private GlobalRiftFloorInfo _floorinfo = null;

		// Token: 0x0400130D RID: 4877
		private IExtension extensionObject;
	}
}
