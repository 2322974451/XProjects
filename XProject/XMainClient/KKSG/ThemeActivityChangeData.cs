using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200049A RID: 1178
	[ProtoContract(Name = "ThemeActivityChangeData")]
	[Serializable]
	public class ThemeActivityChangeData : IExtensible
	{
		// Token: 0x170012D1 RID: 4817
		// (get) Token: 0x06003D64 RID: 15716 RVA: 0x0007530C File Offset: 0x0007350C
		// (set) Token: 0x06003D65 RID: 15717 RVA: 0x00075338 File Offset: 0x00073538
		[ProtoMember(1, IsRequired = false, Name = "ishint", DataFormat = DataFormat.Default)]
		public bool ishint
		{
			get
			{
				return this._ishint ?? false;
			}
			set
			{
				this._ishint = new bool?(value);
			}
		}

		// Token: 0x170012D2 RID: 4818
		// (get) Token: 0x06003D66 RID: 15718 RVA: 0x00075348 File Offset: 0x00073548
		// (set) Token: 0x06003D67 RID: 15719 RVA: 0x00075368 File Offset: 0x00073568
		[XmlIgnore]
		[Browsable(false)]
		public bool ishintSpecified
		{
			get
			{
				return this._ishint != null;
			}
			set
			{
				bool flag = value == (this._ishint == null);
				if (flag)
				{
					this._ishint = (value ? new bool?(this.ishint) : null);
				}
			}
		}

		// Token: 0x06003D68 RID: 15720 RVA: 0x000753AC File Offset: 0x000735AC
		private bool ShouldSerializeishint()
		{
			return this.ishintSpecified;
		}

		// Token: 0x06003D69 RID: 15721 RVA: 0x000753C4 File Offset: 0x000735C4
		private void Resetishint()
		{
			this.ishintSpecified = false;
		}

		// Token: 0x170012D3 RID: 4819
		// (get) Token: 0x06003D6A RID: 15722 RVA: 0x000753D0 File Offset: 0x000735D0
		[ProtoMember(2, Name = "scene", DataFormat = DataFormat.Default)]
		public List<SpFirstCompleteScene> scene
		{
			get
			{
				return this._scene;
			}
		}

		// Token: 0x170012D4 RID: 4820
		// (get) Token: 0x06003D6B RID: 15723 RVA: 0x000753E8 File Offset: 0x000735E8
		// (set) Token: 0x06003D6C RID: 15724 RVA: 0x00075414 File Offset: 0x00073614
		[ProtoMember(3, IsRequired = false, Name = "actid", DataFormat = DataFormat.TwosComplement)]
		public uint actid
		{
			get
			{
				return this._actid ?? 0U;
			}
			set
			{
				this._actid = new uint?(value);
			}
		}

		// Token: 0x170012D5 RID: 4821
		// (get) Token: 0x06003D6D RID: 15725 RVA: 0x00075424 File Offset: 0x00073624
		// (set) Token: 0x06003D6E RID: 15726 RVA: 0x00075444 File Offset: 0x00073644
		[XmlIgnore]
		[Browsable(false)]
		public bool actidSpecified
		{
			get
			{
				return this._actid != null;
			}
			set
			{
				bool flag = value == (this._actid == null);
				if (flag)
				{
					this._actid = (value ? new uint?(this.actid) : null);
				}
			}
		}

		// Token: 0x06003D6F RID: 15727 RVA: 0x00075488 File Offset: 0x00073688
		private bool ShouldSerializeactid()
		{
			return this.actidSpecified;
		}

		// Token: 0x06003D70 RID: 15728 RVA: 0x000754A0 File Offset: 0x000736A0
		private void Resetactid()
		{
			this.actidSpecified = false;
		}

		// Token: 0x06003D71 RID: 15729 RVA: 0x000754AC File Offset: 0x000736AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F49 RID: 3913
		private bool? _ishint;

		// Token: 0x04000F4A RID: 3914
		private readonly List<SpFirstCompleteScene> _scene = new List<SpFirstCompleteScene>();

		// Token: 0x04000F4B RID: 3915
		private uint? _actid;

		// Token: 0x04000F4C RID: 3916
		private IExtension extensionObject;
	}
}
