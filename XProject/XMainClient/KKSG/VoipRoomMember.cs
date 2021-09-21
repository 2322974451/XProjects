using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200069A RID: 1690
	[ProtoContract(Name = "VoipRoomMember")]
	[Serializable]
	public class VoipRoomMember : IExtensible
	{
		// Token: 0x170022C7 RID: 8903
		// (get) Token: 0x06006DE1 RID: 28129 RVA: 0x000D240C File Offset: 0x000D060C
		// (set) Token: 0x06006DE2 RID: 28130 RVA: 0x000D2438 File Offset: 0x000D0638
		[ProtoMember(1, IsRequired = false, Name = "memberID", DataFormat = DataFormat.TwosComplement)]
		public int memberID
		{
			get
			{
				return this._memberID ?? 0;
			}
			set
			{
				this._memberID = new int?(value);
			}
		}

		// Token: 0x170022C8 RID: 8904
		// (get) Token: 0x06006DE3 RID: 28131 RVA: 0x000D2448 File Offset: 0x000D0648
		// (set) Token: 0x06006DE4 RID: 28132 RVA: 0x000D2468 File Offset: 0x000D0668
		[XmlIgnore]
		[Browsable(false)]
		public bool memberIDSpecified
		{
			get
			{
				return this._memberID != null;
			}
			set
			{
				bool flag = value == (this._memberID == null);
				if (flag)
				{
					this._memberID = (value ? new int?(this.memberID) : null);
				}
			}
		}

		// Token: 0x06006DE5 RID: 28133 RVA: 0x000D24AC File Offset: 0x000D06AC
		private bool ShouldSerializememberID()
		{
			return this.memberIDSpecified;
		}

		// Token: 0x06006DE6 RID: 28134 RVA: 0x000D24C4 File Offset: 0x000D06C4
		private void ResetmemberID()
		{
			this.memberIDSpecified = false;
		}

		// Token: 0x170022C9 RID: 8905
		// (get) Token: 0x06006DE7 RID: 28135 RVA: 0x000D24D0 File Offset: 0x000D06D0
		// (set) Token: 0x06006DE8 RID: 28136 RVA: 0x000D24FD File Offset: 0x000D06FD
		[ProtoMember(2, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170022CA RID: 8906
		// (get) Token: 0x06006DE9 RID: 28137 RVA: 0x000D250C File Offset: 0x000D070C
		// (set) Token: 0x06006DEA RID: 28138 RVA: 0x000D252C File Offset: 0x000D072C
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

		// Token: 0x06006DEB RID: 28139 RVA: 0x000D2570 File Offset: 0x000D0770
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x06006DEC RID: 28140 RVA: 0x000D2588 File Offset: 0x000D0788
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x170022CB RID: 8907
		// (get) Token: 0x06006DED RID: 28141 RVA: 0x000D2594 File Offset: 0x000D0794
		// (set) Token: 0x06006DEE RID: 28142 RVA: 0x000D25B5 File Offset: 0x000D07B5
		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x170022CC RID: 8908
		// (get) Token: 0x06006DEF RID: 28143 RVA: 0x000D25C0 File Offset: 0x000D07C0
		// (set) Token: 0x06006DF0 RID: 28144 RVA: 0x000D25DC File Offset: 0x000D07DC
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06006DF1 RID: 28145 RVA: 0x000D260C File Offset: 0x000D080C
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06006DF2 RID: 28146 RVA: 0x000D2624 File Offset: 0x000D0824
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170022CD RID: 8909
		// (get) Token: 0x06006DF3 RID: 28147 RVA: 0x000D2630 File Offset: 0x000D0830
		// (set) Token: 0x06006DF4 RID: 28148 RVA: 0x000D265C File Offset: 0x000D085C
		[ProtoMember(4, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		// Token: 0x170022CE RID: 8910
		// (get) Token: 0x06006DF5 RID: 28149 RVA: 0x000D266C File Offset: 0x000D086C
		// (set) Token: 0x06006DF6 RID: 28150 RVA: 0x000D268C File Offset: 0x000D088C
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		// Token: 0x06006DF7 RID: 28151 RVA: 0x000D26D0 File Offset: 0x000D08D0
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06006DF8 RID: 28152 RVA: 0x000D26E8 File Offset: 0x000D08E8
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x06006DF9 RID: 28153 RVA: 0x000D26F4 File Offset: 0x000D08F4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A51 RID: 6737
		private int? _memberID;

		// Token: 0x04001A52 RID: 6738
		private ulong? _roleID;

		// Token: 0x04001A53 RID: 6739
		private string _name;

		// Token: 0x04001A54 RID: 6740
		private uint? _state;

		// Token: 0x04001A55 RID: 6741
		private IExtension extensionObject;
	}
}
