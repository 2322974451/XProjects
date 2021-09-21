using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200017F RID: 383
	[ProtoContract(Name = "ChangeWatchRoleArg")]
	[Serializable]
	public class ChangeWatchRoleArg : IExtensible
	{
		// Token: 0x17000759 RID: 1881
		// (get) Token: 0x06001734 RID: 5940 RVA: 0x0002E678 File Offset: 0x0002C878
		// (set) Token: 0x06001735 RID: 5941 RVA: 0x0002E6A5 File Offset: 0x0002C8A5
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

		// Token: 0x1700075A RID: 1882
		// (get) Token: 0x06001736 RID: 5942 RVA: 0x0002E6B4 File Offset: 0x0002C8B4
		// (set) Token: 0x06001737 RID: 5943 RVA: 0x0002E6D4 File Offset: 0x0002C8D4
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

		// Token: 0x06001738 RID: 5944 RVA: 0x0002E718 File Offset: 0x0002C918
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06001739 RID: 5945 RVA: 0x0002E730 File Offset: 0x0002C930
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x0600173A RID: 5946 RVA: 0x0002E73C File Offset: 0x0002C93C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005BD RID: 1469
		private ulong? _roleID;

		// Token: 0x040005BE RID: 1470
		private IExtension extensionObject;
	}
}
