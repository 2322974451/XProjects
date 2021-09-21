using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006DA RID: 1754
	[ProtoContract(Name = "MentorBreakApplyInfo")]
	[Serializable]
	public class MentorBreakApplyInfo : IExtensible
	{
		// Token: 0x170024EB RID: 9451
		// (get) Token: 0x0600749A RID: 29850 RVA: 0x000DF170 File Offset: 0x000DD370
		// (set) Token: 0x0600749B RID: 29851 RVA: 0x000DF19C File Offset: 0x000DD39C
		[ProtoMember(1, IsRequired = false, Name = "pos", DataFormat = DataFormat.TwosComplement)]
		public EMentorRelationPosition pos
		{
			get
			{
				return this._pos ?? EMentorRelationPosition.EMentorPosMaster;
			}
			set
			{
				this._pos = new EMentorRelationPosition?(value);
			}
		}

		// Token: 0x170024EC RID: 9452
		// (get) Token: 0x0600749C RID: 29852 RVA: 0x000DF1AC File Offset: 0x000DD3AC
		// (set) Token: 0x0600749D RID: 29853 RVA: 0x000DF1CC File Offset: 0x000DD3CC
		[XmlIgnore]
		[Browsable(false)]
		public bool posSpecified
		{
			get
			{
				return this._pos != null;
			}
			set
			{
				bool flag = value == (this._pos == null);
				if (flag)
				{
					this._pos = (value ? new EMentorRelationPosition?(this.pos) : null);
				}
			}
		}

		// Token: 0x0600749E RID: 29854 RVA: 0x000DF210 File Offset: 0x000DD410
		private bool ShouldSerializepos()
		{
			return this.posSpecified;
		}

		// Token: 0x0600749F RID: 29855 RVA: 0x000DF228 File Offset: 0x000DD428
		private void Resetpos()
		{
			this.posSpecified = false;
		}

		// Token: 0x170024ED RID: 9453
		// (get) Token: 0x060074A0 RID: 29856 RVA: 0x000DF234 File Offset: 0x000DD434
		// (set) Token: 0x060074A1 RID: 29857 RVA: 0x000DF260 File Offset: 0x000DD460
		[ProtoMember(2, IsRequired = false, Name = "breakTime", DataFormat = DataFormat.TwosComplement)]
		public int breakTime
		{
			get
			{
				return this._breakTime ?? 0;
			}
			set
			{
				this._breakTime = new int?(value);
			}
		}

		// Token: 0x170024EE RID: 9454
		// (get) Token: 0x060074A2 RID: 29858 RVA: 0x000DF270 File Offset: 0x000DD470
		// (set) Token: 0x060074A3 RID: 29859 RVA: 0x000DF290 File Offset: 0x000DD490
		[XmlIgnore]
		[Browsable(false)]
		public bool breakTimeSpecified
		{
			get
			{
				return this._breakTime != null;
			}
			set
			{
				bool flag = value == (this._breakTime == null);
				if (flag)
				{
					this._breakTime = (value ? new int?(this.breakTime) : null);
				}
			}
		}

		// Token: 0x060074A4 RID: 29860 RVA: 0x000DF2D4 File Offset: 0x000DD4D4
		private bool ShouldSerializebreakTime()
		{
			return this.breakTimeSpecified;
		}

		// Token: 0x060074A5 RID: 29861 RVA: 0x000DF2EC File Offset: 0x000DD4EC
		private void ResetbreakTime()
		{
			this.breakTimeSpecified = false;
		}

		// Token: 0x170024EF RID: 9455
		// (get) Token: 0x060074A6 RID: 29862 RVA: 0x000DF2F8 File Offset: 0x000DD4F8
		// (set) Token: 0x060074A7 RID: 29863 RVA: 0x000DF325 File Offset: 0x000DD525
		[ProtoMember(3, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170024F0 RID: 9456
		// (get) Token: 0x060074A8 RID: 29864 RVA: 0x000DF334 File Offset: 0x000DD534
		// (set) Token: 0x060074A9 RID: 29865 RVA: 0x000DF354 File Offset: 0x000DD554
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

		// Token: 0x060074AA RID: 29866 RVA: 0x000DF398 File Offset: 0x000DD598
		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		// Token: 0x060074AB RID: 29867 RVA: 0x000DF3B0 File Offset: 0x000DD5B0
		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		// Token: 0x170024F1 RID: 9457
		// (get) Token: 0x060074AC RID: 29868 RVA: 0x000DF3BC File Offset: 0x000DD5BC
		// (set) Token: 0x060074AD RID: 29869 RVA: 0x000DF3DD File Offset: 0x000DD5DD
		[ProtoMember(4, IsRequired = false, Name = "roleName", DataFormat = DataFormat.Default)]
		public string roleName
		{
			get
			{
				return this._roleName ?? "";
			}
			set
			{
				this._roleName = value;
			}
		}

		// Token: 0x170024F2 RID: 9458
		// (get) Token: 0x060074AE RID: 29870 RVA: 0x000DF3E8 File Offset: 0x000DD5E8
		// (set) Token: 0x060074AF RID: 29871 RVA: 0x000DF404 File Offset: 0x000DD604
		[XmlIgnore]
		[Browsable(false)]
		public bool roleNameSpecified
		{
			get
			{
				return this._roleName != null;
			}
			set
			{
				bool flag = value == (this._roleName == null);
				if (flag)
				{
					this._roleName = (value ? this.roleName : null);
				}
			}
		}

		// Token: 0x060074B0 RID: 29872 RVA: 0x000DF434 File Offset: 0x000DD634
		private bool ShouldSerializeroleName()
		{
			return this.roleNameSpecified;
		}

		// Token: 0x060074B1 RID: 29873 RVA: 0x000DF44C File Offset: 0x000DD64C
		private void ResetroleName()
		{
			this.roleNameSpecified = false;
		}

		// Token: 0x060074B2 RID: 29874 RVA: 0x000DF458 File Offset: 0x000DD658
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BB4 RID: 7092
		private EMentorRelationPosition? _pos;

		// Token: 0x04001BB5 RID: 7093
		private int? _breakTime;

		// Token: 0x04001BB6 RID: 7094
		private ulong? _roleID;

		// Token: 0x04001BB7 RID: 7095
		private string _roleName;

		// Token: 0x04001BB8 RID: 7096
		private IExtension extensionObject;
	}
}
