using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200052B RID: 1323
	[ProtoContract(Name = "RiftSceneInfoNtfData")]
	[Serializable]
	public class RiftSceneInfoNtfData : IExtensible
	{
		// Token: 0x170014C9 RID: 5321
		// (get) Token: 0x060043FF RID: 17407 RVA: 0x000815C4 File Offset: 0x0007F7C4
		// (set) Token: 0x06004400 RID: 17408 RVA: 0x000815F0 File Offset: 0x0007F7F0
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

		// Token: 0x170014CA RID: 5322
		// (get) Token: 0x06004401 RID: 17409 RVA: 0x00081600 File Offset: 0x0007F800
		// (set) Token: 0x06004402 RID: 17410 RVA: 0x00081620 File Offset: 0x0007F820
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

		// Token: 0x06004403 RID: 17411 RVA: 0x00081664 File Offset: 0x0007F864
		private bool ShouldSerializefloor()
		{
			return this.floorSpecified;
		}

		// Token: 0x06004404 RID: 17412 RVA: 0x0008167C File Offset: 0x0007F87C
		private void Resetfloor()
		{
			this.floorSpecified = false;
		}

		// Token: 0x170014CB RID: 5323
		// (get) Token: 0x06004405 RID: 17413 RVA: 0x00081688 File Offset: 0x0007F888
		[ProtoMember(2, Name = "buffIDs", DataFormat = DataFormat.Default)]
		public List<Buff> buffIDs
		{
			get
			{
				return this._buffIDs;
			}
		}

		// Token: 0x06004406 RID: 17414 RVA: 0x000816A0 File Offset: 0x0007F8A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010F5 RID: 4341
		private int? _floor;

		// Token: 0x040010F6 RID: 4342
		private readonly List<Buff> _buffIDs = new List<Buff>();

		// Token: 0x040010F7 RID: 4343
		private IExtension extensionObject;
	}
}
