using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002F5 RID: 757
	[ProtoContract(Name = "StepMoveData")]
	[Serializable]
	public class StepMoveData : IExtensible
	{
		// Token: 0x17000CE5 RID: 3301
		// (get) Token: 0x0600298F RID: 10639 RVA: 0x00050A50 File Offset: 0x0004EC50
		// (set) Token: 0x06002990 RID: 10640 RVA: 0x00050A7D File Offset: 0x0004EC7D
		[ProtoMember(1, IsRequired = false, Name = "EntityID", DataFormat = DataFormat.TwosComplement)]
		public ulong EntityID
		{
			get
			{
				return this._EntityID ?? 0UL;
			}
			set
			{
				this._EntityID = new ulong?(value);
			}
		}

		// Token: 0x17000CE6 RID: 3302
		// (get) Token: 0x06002991 RID: 10641 RVA: 0x00050A8C File Offset: 0x0004EC8C
		// (set) Token: 0x06002992 RID: 10642 RVA: 0x00050AAC File Offset: 0x0004ECAC
		[XmlIgnore]
		[Browsable(false)]
		public bool EntityIDSpecified
		{
			get
			{
				return this._EntityID != null;
			}
			set
			{
				bool flag = value == (this._EntityID == null);
				if (flag)
				{
					this._EntityID = (value ? new ulong?(this.EntityID) : null);
				}
			}
		}

		// Token: 0x06002993 RID: 10643 RVA: 0x00050AF0 File Offset: 0x0004ECF0
		private bool ShouldSerializeEntityID()
		{
			return this.EntityIDSpecified;
		}

		// Token: 0x06002994 RID: 10644 RVA: 0x00050B08 File Offset: 0x0004ED08
		private void ResetEntityID()
		{
			this.EntityIDSpecified = false;
		}

		// Token: 0x17000CE7 RID: 3303
		// (get) Token: 0x06002995 RID: 10645 RVA: 0x00050B14 File Offset: 0x0004ED14
		// (set) Token: 0x06002996 RID: 10646 RVA: 0x00050B40 File Offset: 0x0004ED40
		[ProtoMember(2, IsRequired = false, Name = "PosXZ", DataFormat = DataFormat.TwosComplement)]
		public int PosXZ
		{
			get
			{
				return this._PosXZ ?? 0;
			}
			set
			{
				this._PosXZ = new int?(value);
			}
		}

		// Token: 0x17000CE8 RID: 3304
		// (get) Token: 0x06002997 RID: 10647 RVA: 0x00050B50 File Offset: 0x0004ED50
		// (set) Token: 0x06002998 RID: 10648 RVA: 0x00050B70 File Offset: 0x0004ED70
		[XmlIgnore]
		[Browsable(false)]
		public bool PosXZSpecified
		{
			get
			{
				return this._PosXZ != null;
			}
			set
			{
				bool flag = value == (this._PosXZ == null);
				if (flag)
				{
					this._PosXZ = (value ? new int?(this.PosXZ) : null);
				}
			}
		}

		// Token: 0x06002999 RID: 10649 RVA: 0x00050BB4 File Offset: 0x0004EDB4
		private bool ShouldSerializePosXZ()
		{
			return this.PosXZSpecified;
		}

		// Token: 0x0600299A RID: 10650 RVA: 0x00050BCC File Offset: 0x0004EDCC
		private void ResetPosXZ()
		{
			this.PosXZSpecified = false;
		}

		// Token: 0x17000CE9 RID: 3305
		// (get) Token: 0x0600299B RID: 10651 RVA: 0x00050BD8 File Offset: 0x0004EDD8
		// (set) Token: 0x0600299C RID: 10652 RVA: 0x00050C04 File Offset: 0x0004EE04
		[ProtoMember(3, IsRequired = false, Name = "Stoppage", DataFormat = DataFormat.Default)]
		public bool Stoppage
		{
			get
			{
				return this._Stoppage ?? false;
			}
			set
			{
				this._Stoppage = new bool?(value);
			}
		}

		// Token: 0x17000CEA RID: 3306
		// (get) Token: 0x0600299D RID: 10653 RVA: 0x00050C14 File Offset: 0x0004EE14
		// (set) Token: 0x0600299E RID: 10654 RVA: 0x00050C34 File Offset: 0x0004EE34
		[XmlIgnore]
		[Browsable(false)]
		public bool StoppageSpecified
		{
			get
			{
				return this._Stoppage != null;
			}
			set
			{
				bool flag = value == (this._Stoppage == null);
				if (flag)
				{
					this._Stoppage = (value ? new bool?(this.Stoppage) : null);
				}
			}
		}

		// Token: 0x0600299F RID: 10655 RVA: 0x00050C78 File Offset: 0x0004EE78
		private bool ShouldSerializeStoppage()
		{
			return this.StoppageSpecified;
		}

		// Token: 0x060029A0 RID: 10656 RVA: 0x00050C90 File Offset: 0x0004EE90
		private void ResetStoppage()
		{
			this.StoppageSpecified = false;
		}

		// Token: 0x17000CEB RID: 3307
		// (get) Token: 0x060029A1 RID: 10657 RVA: 0x00050C9C File Offset: 0x0004EE9C
		// (set) Token: 0x060029A2 RID: 10658 RVA: 0x00050CC8 File Offset: 0x0004EEC8
		[ProtoMember(4, IsRequired = false, Name = "Face", DataFormat = DataFormat.TwosComplement)]
		public int Face
		{
			get
			{
				return this._Face ?? 0;
			}
			set
			{
				this._Face = new int?(value);
			}
		}

		// Token: 0x17000CEC RID: 3308
		// (get) Token: 0x060029A3 RID: 10659 RVA: 0x00050CD8 File Offset: 0x0004EED8
		// (set) Token: 0x060029A4 RID: 10660 RVA: 0x00050CF8 File Offset: 0x0004EEF8
		[XmlIgnore]
		[Browsable(false)]
		public bool FaceSpecified
		{
			get
			{
				return this._Face != null;
			}
			set
			{
				bool flag = value == (this._Face == null);
				if (flag)
				{
					this._Face = (value ? new int?(this.Face) : null);
				}
			}
		}

		// Token: 0x060029A5 RID: 10661 RVA: 0x00050D3C File Offset: 0x0004EF3C
		private bool ShouldSerializeFace()
		{
			return this.FaceSpecified;
		}

		// Token: 0x060029A6 RID: 10662 RVA: 0x00050D54 File Offset: 0x0004EF54
		private void ResetFace()
		{
			this.FaceSpecified = false;
		}

		// Token: 0x060029A7 RID: 10663 RVA: 0x00050D60 File Offset: 0x0004EF60
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A53 RID: 2643
		private ulong? _EntityID;

		// Token: 0x04000A54 RID: 2644
		private int? _PosXZ;

		// Token: 0x04000A55 RID: 2645
		private bool? _Stoppage;

		// Token: 0x04000A56 RID: 2646
		private int? _Face;

		// Token: 0x04000A57 RID: 2647
		private IExtension extensionObject;
	}
}
