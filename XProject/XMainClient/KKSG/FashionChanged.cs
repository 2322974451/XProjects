using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200003F RID: 63
	[ProtoContract(Name = "FashionChanged")]
	[Serializable]
	public class FashionChanged : IExtensible
	{
		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x0000AE70 File Offset: 0x00009070
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x0000AE9D File Offset: 0x0000909D
		[ProtoMember(1, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x0000AEAC File Offset: 0x000090AC
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x0000AECC File Offset: 0x000090CC
		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0000AF10 File Offset: 0x00009110
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0000AF28 File Offset: 0x00009128
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x0000AF34 File Offset: 0x00009134
		[ProtoMember(2, Name = "position", DataFormat = DataFormat.TwosComplement)]
		public List<uint> position
		{
			get
			{
				return this._position;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000450 RID: 1104 RVA: 0x0000AF4C File Offset: 0x0000914C
		[ProtoMember(3, Name = "newItemID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> newItemID
		{
			get
			{
				return this._newItemID;
			}
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0000AF64 File Offset: 0x00009164
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400011F RID: 287
		private ulong? _roleID;

		// Token: 0x04000120 RID: 288
		private readonly List<uint> _position = new List<uint>();

		// Token: 0x04000121 RID: 289
		private readonly List<uint> _newItemID = new List<uint>();

		// Token: 0x04000122 RID: 290
		private IExtension extensionObject;
	}
}
