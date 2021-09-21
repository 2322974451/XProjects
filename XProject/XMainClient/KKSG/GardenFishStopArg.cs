using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002F3 RID: 755
	[ProtoContract(Name = "GardenFishStopArg")]
	[Serializable]
	public class GardenFishStopArg : IExtensible
	{
		// Token: 0x17000CE1 RID: 3297
		// (get) Token: 0x0600297F RID: 10623 RVA: 0x00050888 File Offset: 0x0004EA88
		// (set) Token: 0x06002980 RID: 10624 RVA: 0x000508B5 File Offset: 0x0004EAB5
		[ProtoMember(1, IsRequired = false, Name = "garden_id", DataFormat = DataFormat.TwosComplement)]
		public ulong garden_id
		{
			get
			{
				return this._garden_id ?? 0UL;
			}
			set
			{
				this._garden_id = new ulong?(value);
			}
		}

		// Token: 0x17000CE2 RID: 3298
		// (get) Token: 0x06002981 RID: 10625 RVA: 0x000508C4 File Offset: 0x0004EAC4
		// (set) Token: 0x06002982 RID: 10626 RVA: 0x000508E4 File Offset: 0x0004EAE4
		[XmlIgnore]
		[Browsable(false)]
		public bool garden_idSpecified
		{
			get
			{
				return this._garden_id != null;
			}
			set
			{
				bool flag = value == (this._garden_id == null);
				if (flag)
				{
					this._garden_id = (value ? new ulong?(this.garden_id) : null);
				}
			}
		}

		// Token: 0x06002983 RID: 10627 RVA: 0x00050928 File Offset: 0x0004EB28
		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		// Token: 0x06002984 RID: 10628 RVA: 0x00050940 File Offset: 0x0004EB40
		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		// Token: 0x06002985 RID: 10629 RVA: 0x0005094C File Offset: 0x0004EB4C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A4F RID: 2639
		private ulong? _garden_id;

		// Token: 0x04000A50 RID: 2640
		private IExtension extensionObject;
	}
}
