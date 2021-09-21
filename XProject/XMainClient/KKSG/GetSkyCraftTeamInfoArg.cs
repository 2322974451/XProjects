using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003E6 RID: 998
	[ProtoContract(Name = "GetSkyCraftTeamInfoArg")]
	[Serializable]
	public class GetSkyCraftTeamInfoArg : IExtensible
	{
		// Token: 0x17001059 RID: 4185
		// (get) Token: 0x06003521 RID: 13601 RVA: 0x00065D88 File Offset: 0x00063F88
		// (set) Token: 0x06003522 RID: 13602 RVA: 0x00065DB5 File Offset: 0x00063FB5
		[ProtoMember(1, IsRequired = false, Name = "stid", DataFormat = DataFormat.TwosComplement)]
		public ulong stid
		{
			get
			{
				return this._stid ?? 0UL;
			}
			set
			{
				this._stid = new ulong?(value);
			}
		}

		// Token: 0x1700105A RID: 4186
		// (get) Token: 0x06003523 RID: 13603 RVA: 0x00065DC4 File Offset: 0x00063FC4
		// (set) Token: 0x06003524 RID: 13604 RVA: 0x00065DE4 File Offset: 0x00063FE4
		[XmlIgnore]
		[Browsable(false)]
		public bool stidSpecified
		{
			get
			{
				return this._stid != null;
			}
			set
			{
				bool flag = value == (this._stid == null);
				if (flag)
				{
					this._stid = (value ? new ulong?(this.stid) : null);
				}
			}
		}

		// Token: 0x06003525 RID: 13605 RVA: 0x00065E28 File Offset: 0x00064028
		private bool ShouldSerializestid()
		{
			return this.stidSpecified;
		}

		// Token: 0x06003526 RID: 13606 RVA: 0x00065E40 File Offset: 0x00064040
		private void Resetstid()
		{
			this.stidSpecified = false;
		}

		// Token: 0x06003527 RID: 13607 RVA: 0x00065E4C File Offset: 0x0006404C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D31 RID: 3377
		private ulong? _stid;

		// Token: 0x04000D32 RID: 3378
		private IExtension extensionObject;
	}
}
