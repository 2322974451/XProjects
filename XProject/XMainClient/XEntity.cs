using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DC1 RID: 3521
	internal abstract class XEntity : XObject
	{
		// Token: 0x1700336C RID: 13164
		// (get) Token: 0x0600BECC RID: 48844 RVA: 0x0027E55C File Offset: 0x0027C75C
		public bool IsVisible
		{
			get
			{
				return this._isVisible;
			}
		}

		// Token: 0x1700336D RID: 13165
		// (get) Token: 0x0600BECD RID: 48845 RVA: 0x0027E574 File Offset: 0x0027C774
		public XMount Mount
		{
			get
			{
				return this._mount;
			}
		}

		// Token: 0x1700336E RID: 13166
		// (get) Token: 0x0600BECE RID: 48846 RVA: 0x0027E58C File Offset: 0x0027C78C
		public List<XAffiliate> Affiliates
		{
			get
			{
				return this._affiliates;
			}
		}

		// Token: 0x1700336F RID: 13167
		// (get) Token: 0x0600BECF RID: 48847 RVA: 0x0027E5A4 File Offset: 0x0027C7A4
		// (set) Token: 0x0600BED0 RID: 48848 RVA: 0x0027E5BC File Offset: 0x0027C7BC
		public XNavigationComponent Nav
		{
			get
			{
				return this._nav;
			}
			set
			{
				this._nav = value;
			}
		}

		// Token: 0x17003370 RID: 13168
		// (get) Token: 0x0600BED1 RID: 48849 RVA: 0x0027E5C8 File Offset: 0x0027C7C8
		public virtual XAttributes Attributes
		{
			get
			{
				return this._attr;
			}
		}

		// Token: 0x17003371 RID: 13169
		// (get) Token: 0x0600BED2 RID: 48850 RVA: 0x0027E5E0 File Offset: 0x0027C7E0
		public XStateMachine Machine
		{
			get
			{
				return this._machine;
			}
		}

		// Token: 0x17003372 RID: 13170
		// (get) Token: 0x0600BED3 RID: 48851 RVA: 0x0027E5F8 File Offset: 0x0027C7F8
		public XSkillComponent Skill
		{
			get
			{
				return this._skill;
			}
		}

		// Token: 0x17003373 RID: 13171
		// (get) Token: 0x0600BED4 RID: 48852 RVA: 0x0027E610 File Offset: 0x0027C810
		public XPresentComponent Present
		{
			get
			{
				return this._present;
			}
		}

		// Token: 0x17003374 RID: 13172
		// (get) Token: 0x0600BED5 RID: 48853 RVA: 0x0027E628 File Offset: 0x0027C828
		public XBuffComponent Buffs
		{
			get
			{
				return this._buff;
			}
		}

		// Token: 0x17003375 RID: 13173
		// (get) Token: 0x0600BED6 RID: 48854 RVA: 0x0027E640 File Offset: 0x0027C840
		public XNetComponent Net
		{
			get
			{
				return this._net;
			}
		}

		// Token: 0x17003376 RID: 13174
		// (get) Token: 0x0600BED7 RID: 48855 RVA: 0x0027E658 File Offset: 0x0027C858
		public XRotationComponent Rotate
		{
			get
			{
				return this._rotate;
			}
		}

		// Token: 0x17003377 RID: 13175
		// (get) Token: 0x0600BED8 RID: 48856 RVA: 0x0027E670 File Offset: 0x0027C870
		public XSkillMgr SkillMgr
		{
			get
			{
				return (this.Skill != null) ? this.Skill.SkillMgr : null;
			}
		}

		// Token: 0x17003378 RID: 13176
		// (get) Token: 0x0600BED9 RID: 48857 RVA: 0x0027E698 File Offset: 0x0027C898
		public XBeHitComponent BeHit
		{
			get
			{
				return this._behit;
			}
		}

		// Token: 0x17003379 RID: 13177
		// (get) Token: 0x0600BEDA RID: 48858 RVA: 0x0027E6B0 File Offset: 0x0027C8B0
		public XDeathComponent Death
		{
			get
			{
				return this._death;
			}
		}

		// Token: 0x1700337A RID: 13178
		// (get) Token: 0x0600BEDB RID: 48859 RVA: 0x0027E6C8 File Offset: 0x0027C8C8
		public XEquipComponent Equipment
		{
			get
			{
				return this._equip;
			}
		}

		// Token: 0x1700337B RID: 13179
		// (get) Token: 0x0600BEDC RID: 48860 RVA: 0x0027E6E0 File Offset: 0x0027C8E0
		public XFlyComponent Fly
		{
			get
			{
				return this._fly;
			}
		}

		// Token: 0x1700337C RID: 13180
		// (get) Token: 0x0600BEDD RID: 48861 RVA: 0x0027E6F8 File Offset: 0x0027C8F8
		public XQuickTimeEventComponent QTE
		{
			get
			{
				return this._qte;
			}
		}

		// Token: 0x1700337D RID: 13181
		// (get) Token: 0x0600BEDE RID: 48862 RVA: 0x0027E710 File Offset: 0x0027C910
		// (set) Token: 0x0600BEDF RID: 48863 RVA: 0x0027E728 File Offset: 0x0027C928
		public XRenderComponent Renderer
		{
			get
			{
				return this._render;
			}
			set
			{
				this._render = value;
			}
		}

		// Token: 0x1700337E RID: 13182
		// (get) Token: 0x0600BEE0 RID: 48864 RVA: 0x0027E734 File Offset: 0x0027C934
		public XAudioComponent Audio
		{
			get
			{
				return this._audio;
			}
		}

		// Token: 0x1700337F RID: 13183
		// (get) Token: 0x0600BEE1 RID: 48865 RVA: 0x0027E74C File Offset: 0x0027C94C
		// (set) Token: 0x0600BEE2 RID: 48866 RVA: 0x0027E764 File Offset: 0x0027C964
		public XBillboardComponent BillBoard
		{
			get
			{
				return this._billboard;
			}
			set
			{
				this._billboard = value;
			}
		}

		// Token: 0x17003380 RID: 13184
		// (get) Token: 0x0600BEE3 RID: 48867 RVA: 0x0027E770 File Offset: 0x0027C970
		// (set) Token: 0x0600BEE4 RID: 48868 RVA: 0x0027E788 File Offset: 0x0027C988
		public XAIComponent AI
		{
			get
			{
				return this._ai;
			}
			set
			{
				this._ai = value;
			}
		}

		// Token: 0x17003381 RID: 13185
		// (get) Token: 0x0600BEE5 RID: 48869 RVA: 0x0027E794 File Offset: 0x0027C994
		// (set) Token: 0x0600BEE6 RID: 48870 RVA: 0x0027E7AC File Offset: 0x0027C9AC
		public uint ServerSpecialState
		{
			get
			{
				return this._server_special_state;
			}
			set
			{
				this._server_special_state = value;
			}
		}

		// Token: 0x17003382 RID: 13186
		// (get) Token: 0x0600BEE7 RID: 48871 RVA: 0x0027E7B8 File Offset: 0x0027C9B8
		public virtual bool IsFighting
		{
			get
			{
				bool flag = this._ai != null;
				return flag && this._ai.IsFighting;
			}
		}

		// Token: 0x17003383 RID: 13187
		// (get) Token: 0x0600BEE8 RID: 48872 RVA: 0x0027E7E8 File Offset: 0x0027C9E8
		public virtual bool HasAI
		{
			get
			{
				return this._ai != null;
			}
		}

		// Token: 0x17003384 RID: 13188
		// (get) Token: 0x0600BEE9 RID: 48873 RVA: 0x0027E803 File Offset: 0x0027CA03
		// (set) Token: 0x0600BEEA RID: 48874 RVA: 0x0027E80B File Offset: 0x0027CA0B
		public bool CanSelected { get; set; }

		// Token: 0x17003385 RID: 13189
		// (get) Token: 0x0600BEEB RID: 48875 RVA: 0x0027E814 File Offset: 0x0027CA14
		// (set) Token: 0x0600BEEC RID: 48876 RVA: 0x0027E82C File Offset: 0x0027CA2C
		public bool IsPassive
		{
			get
			{
				return this._passive;
			}
			set
			{
				this._passive = value;
			}
		}

		// Token: 0x17003386 RID: 13190
		// (get) Token: 0x0600BEED RID: 48877 RVA: 0x0027E838 File Offset: 0x0027CA38
		public bool IsClientPredicted
		{
			get
			{
				return this._client_predicted && !this._passive;
			}
		}

		// Token: 0x17003387 RID: 13191
		// (get) Token: 0x0600BEEE RID: 48878 RVA: 0x0027E860 File Offset: 0x0027CA60
		public bool IsNavigating
		{
			get
			{
				return this._nav != null && this._nav.IsOnNav;
			}
		}

		// Token: 0x17003388 RID: 13192
		// (get) Token: 0x0600BEEF RID: 48879 RVA: 0x0027E888 File Offset: 0x0027CA88
		// (set) Token: 0x0600BEF0 RID: 48880 RVA: 0x0027E8A0 File Offset: 0x0027CAA0
		public bool IsServerFighting
		{
			get
			{
				return this._server_fighting;
			}
			set
			{
				this._server_fighting = value;
			}
		}

		// Token: 0x17003389 RID: 13193
		// (get) Token: 0x0600BEF1 RID: 48881 RVA: 0x0027E8AC File Offset: 0x0027CAAC
		// (set) Token: 0x0600BEF2 RID: 48882 RVA: 0x0027E8C4 File Offset: 0x0027CAC4
		public bool IsDisappear
		{
			get
			{
				return this._bDisappear;
			}
			set
			{
				this._bDisappear = value;
			}
		}

		// Token: 0x1700338A RID: 13194
		// (get) Token: 0x0600BEF3 RID: 48883 RVA: 0x0027E8D0 File Offset: 0x0027CAD0
		public bool IsTransform
		{
			get
			{
				return XEntity.ValideEntity(this._transformer);
			}
		}

		// Token: 0x1700338B RID: 13195
		// (get) Token: 0x0600BEF4 RID: 48884 RVA: 0x0027E8F0 File Offset: 0x0027CAF0
		public XEntity Transformer
		{
			get
			{
				return this._transformer;
			}
		}

		// Token: 0x1700338C RID: 13196
		// (get) Token: 0x0600BEF5 RID: 48885 RVA: 0x0027E908 File Offset: 0x0027CB08
		public XEntity Transformee
		{
			get
			{
				return this._transformee;
			}
		}

		// Token: 0x1700338D RID: 13197
		// (get) Token: 0x0600BEF6 RID: 48886 RVA: 0x0027E920 File Offset: 0x0027CB20
		public XEntity RealEntity
		{
			get
			{
				return this.IsTransform ? this._transformer : this;
			}
		}

		// Token: 0x1700338E RID: 13198
		// (get) Token: 0x0600BEF7 RID: 48887 RVA: 0x0027E944 File Offset: 0x0027CB44
		public bool CachedSpecialStateFromServer
		{
			get
			{
				return this._last_special_state_from_server > 0UL;
			}
		}

		// Token: 0x1700338F RID: 13199
		// (get) Token: 0x0600BEF8 RID: 48888 RVA: 0x0027E960 File Offset: 0x0027CB60
		public float Height
		{
			get
			{
				return this._height;
			}
		}

		// Token: 0x17003390 RID: 13200
		// (get) Token: 0x0600BEF9 RID: 48889 RVA: 0x0027E978 File Offset: 0x0027CB78
		public float Radius
		{
			get
			{
				return this._radius;
			}
		}

		// Token: 0x17003391 RID: 13201
		// (get) Token: 0x0600BEFA RID: 48890 RVA: 0x0027E990 File Offset: 0x0027CB90
		public Vector3 RadiusCenter
		{
			get
			{
				return this._xobject.Position + this._xobject.Rotation * (this._present.RadiusOffset * this._scale);
			}
		}

		// Token: 0x0600BEFB RID: 48891 RVA: 0x0027E9D8 File Offset: 0x0027CBD8
		public Vector3 HugeMonsterColliderCenter(int idx)
		{
			SeqListRef<float> hugeMonsterColliders = this.Present.PresentLib.HugeMonsterColliders;
			return this.EngineObject.Position + this.EngineObject.Rotation * (new Vector3(hugeMonsterColliders[idx, 0], 0f, hugeMonsterColliders[idx, 1]) * this._scale);
		}

		// Token: 0x17003392 RID: 13202
		// (get) Token: 0x0600BEFC RID: 48892 RVA: 0x0027EA44 File Offset: 0x0027CC44
		public XAnimator Ator
		{
			get
			{
				return this.IsTransform ? this._transformer.Ator : ((this._xobject != null) ? this._xobject.Ator : null);
			}
		}

		// Token: 0x17003393 RID: 13203
		// (get) Token: 0x0600BEFD RID: 48893 RVA: 0x0027EA84 File Offset: 0x0027CC84
		public int DefaultLayer
		{
			get
			{
				return this._layer;
			}
		}

		// Token: 0x17003394 RID: 13204
		// (get) Token: 0x0600BEFE RID: 48894 RVA: 0x0027EA9C File Offset: 0x0027CC9C
		public bool StandOn
		{
			get
			{
				return this._bStandOn;
			}
		}

		// Token: 0x17003395 RID: 13205
		// (get) Token: 0x0600BEFF RID: 48895 RVA: 0x0027EAB4 File Offset: 0x0027CCB4
		public bool IsMounted
		{
			get
			{
				return this._mount != null;
			}
		}

		// Token: 0x17003396 RID: 13206
		// (get) Token: 0x0600BF00 RID: 48896 RVA: 0x0027EAD0 File Offset: 0x0027CCD0
		public bool IsCopilotMounted
		{
			get
			{
				return this.IsMounted && this._is_mount_copilot;
			}
		}

		// Token: 0x17003397 RID: 13207
		// (get) Token: 0x0600BF01 RID: 48897 RVA: 0x0027EAF4 File Offset: 0x0027CCF4
		public bool GravityDisabled
		{
			get
			{
				return this._gravity_disabled;
			}
		}

		// Token: 0x0600BF02 RID: 48898 RVA: 0x0027EB0C File Offset: 0x0027CD0C
		public void DisableGravity()
		{
			this._gravity_disabled = true;
		}

		// Token: 0x17003398 RID: 13208
		// (get) Token: 0x0600BF03 RID: 48899 RVA: 0x0027EB18 File Offset: 0x0027CD18
		public int EntityType
		{
			get
			{
				return XFastEnumIntEqualityComparer<XEntity.EnitityType>.ToInt(this._eEntity_Type);
			}
		}

		// Token: 0x17003399 RID: 13209
		// (get) Token: 0x0600BF04 RID: 48900 RVA: 0x0027EB38 File Offset: 0x0027CD38
		public bool IsPlayer
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Player) > (XEntity.EnitityType)0;
			}
		}

		// Token: 0x1700339A RID: 13210
		// (get) Token: 0x0600BF05 RID: 48901 RVA: 0x0027EB58 File Offset: 0x0027CD58
		public bool IsRole
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Role) > (XEntity.EnitityType)0;
			}
		}

		// Token: 0x1700339B RID: 13211
		// (get) Token: 0x0600BF06 RID: 48902 RVA: 0x0027EB78 File Offset: 0x0027CD78
		public bool IsOpposer
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Opposer) > (XEntity.EnitityType)0;
			}
		}

		// Token: 0x1700339C RID: 13212
		// (get) Token: 0x0600BF07 RID: 48903 RVA: 0x0027EB98 File Offset: 0x0027CD98
		public bool IsEnemy
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Enemy) > (XEntity.EnitityType)0;
			}
		}

		// Token: 0x1700339D RID: 13213
		// (get) Token: 0x0600BF08 RID: 48904 RVA: 0x0027EBB8 File Offset: 0x0027CDB8
		public bool IsPuppet
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Puppet) > (XEntity.EnitityType)0;
			}
		}

		// Token: 0x1700339E RID: 13214
		// (get) Token: 0x0600BF09 RID: 48905 RVA: 0x0027EBD8 File Offset: 0x0027CDD8
		public bool IsBoss
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Boss) > (XEntity.EnitityType)0;
			}
		}

		// Token: 0x1700339F RID: 13215
		// (get) Token: 0x0600BF0A RID: 48906 RVA: 0x0027EBF8 File Offset: 0x0027CDF8
		public bool IsElite
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Elite) > (XEntity.EnitityType)0;
			}
		}

		// Token: 0x170033A0 RID: 13216
		// (get) Token: 0x0600BF0B RID: 48907 RVA: 0x0027EC1C File Offset: 0x0027CE1C
		public bool IsNpc
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Npc) > (XEntity.EnitityType)0;
			}
		}

		// Token: 0x170033A1 RID: 13217
		// (get) Token: 0x0600BF0C RID: 48908 RVA: 0x0027EC40 File Offset: 0x0027CE40
		public bool IsDummy
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Dummy) > (XEntity.EnitityType)0;
			}
		}

		// Token: 0x170033A2 RID: 13218
		// (get) Token: 0x0600BF0D RID: 48909 RVA: 0x0027EC64 File Offset: 0x0027CE64
		public bool IsSubstance
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Substance) > (XEntity.EnitityType)0;
			}
		}

		// Token: 0x170033A3 RID: 13219
		// (get) Token: 0x0600BF0E RID: 48910 RVA: 0x0027EC88 File Offset: 0x0027CE88
		public bool IsEmpty
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Empty) > (XEntity.EnitityType)0;
			}
		}

		// Token: 0x170033A4 RID: 13220
		// (get) Token: 0x0600BF0F RID: 48911 RVA: 0x0027ECAC File Offset: 0x0027CEAC
		public bool IsAffiliate
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Affiliate) > (XEntity.EnitityType)0;
			}
		}

		// Token: 0x170033A5 RID: 13221
		// (get) Token: 0x0600BF10 RID: 48912 RVA: 0x0027ECD0 File Offset: 0x0027CED0
		public bool IsMountee
		{
			get
			{
				return (this._eEntity_Type & XEntity.EnitityType.Entity_Mount) > (XEntity.EnitityType)0;
			}
		}

		// Token: 0x170033A6 RID: 13222
		// (get) Token: 0x0600BF11 RID: 48913 RVA: 0x0027ECF4 File Offset: 0x0027CEF4
		public bool IsMainViewEntity
		{
			get
			{
				return this.IsPlayer || (XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.WatchTo == this);
			}
		}

		// Token: 0x0600BF12 RID: 48914 RVA: 0x0027ED34 File Offset: 0x0027CF34
		public static bool IsSameType(XEntity lhs, XEntity rhs)
		{
			return lhs._eEntity_Type == rhs._eEntity_Type;
		}

		// Token: 0x170033A7 RID: 13223
		// (get) Token: 0x0600BF13 RID: 48915 RVA: 0x0027ED54 File Offset: 0x0027CF54
		public bool IsDead
		{
			get
			{
				return this._attr == null || this._attr.IsDead;
			}
		}

		// Token: 0x170033A8 RID: 13224
		// (get) Token: 0x0600BF14 RID: 48916 RVA: 0x0027ED7C File Offset: 0x0027CF7C
		// (set) Token: 0x0600BF15 RID: 48917 RVA: 0x0027ED94 File Offset: 0x0027CF94
		public float Scale
		{
			get
			{
				return this._scale;
			}
			set
			{
				this._scale = value;
				bool flag = this._present != null;
				if (flag)
				{
					this._height = this._present.PresentLib.BoundHeight;
					this._radius = this._present.PresentLib.BoundRadius;
				}
				this._height *= this._scale;
				this._radius *= this._scale;
			}
		}

		// Token: 0x170033A9 RID: 13225
		// (get) Token: 0x0600BF16 RID: 48918 RVA: 0x0027EE0C File Offset: 0x0027D00C
		public string Name
		{
			get
			{
				return (this._attr == null) ? "NULL" : this._attr.Name;
			}
		}

		// Token: 0x170033AA RID: 13226
		// (get) Token: 0x0600BF17 RID: 48919 RVA: 0x0027EE38 File Offset: 0x0027D038
		public virtual uint TypeID
		{
			get
			{
				return (this._attr == null) ? 0U : this._attr.TypeID;
			}
		}

		// Token: 0x170033AB RID: 13227
		// (get) Token: 0x0600BF18 RID: 48920 RVA: 0x0027EE60 File Offset: 0x0027D060
		public virtual uint PresentID
		{
			get
			{
				return (this._attr == null) ? 0U : this._attr.PresentID;
			}
		}

		// Token: 0x170033AC RID: 13228
		// (get) Token: 0x0600BF19 RID: 48921 RVA: 0x0027EE88 File Offset: 0x0027D088
		public virtual uint PowerPoint
		{
			get
			{
				return (this._attr == null) ? 0U : ((uint)this._attr.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Total));
			}
		}

		// Token: 0x170033AD RID: 13229
		// (get) Token: 0x0600BF1A RID: 48922 RVA: 0x0027EEB8 File Offset: 0x0027D0B8
		public virtual uint SkillCasterTypeID
		{
			get
			{
				return (this._attr == null) ? 0U : this._attr.TypeID;
			}
		}

		// Token: 0x170033AE RID: 13230
		// (get) Token: 0x0600BF1B RID: 48923 RVA: 0x0027EEE0 File Offset: 0x0027D0E0
		// (set) Token: 0x0600BF1C RID: 48924 RVA: 0x0027EEF8 File Offset: 0x0027D0F8
		public int Wave
		{
			get
			{
				return this._wave;
			}
			set
			{
				this._wave = value;
			}
		}

		// Token: 0x170033AF RID: 13231
		// (get) Token: 0x0600BF1D RID: 48925 RVA: 0x0027EF04 File Offset: 0x0027D104
		// (set) Token: 0x0600BF1E RID: 48926 RVA: 0x0027EF1C File Offset: 0x0027D11C
		public float CreateTime
		{
			get
			{
				return this._create_time;
			}
			set
			{
				this._create_time = value;
			}
		}

		// Token: 0x170033B0 RID: 13232
		// (get) Token: 0x0600BF1F RID: 48927 RVA: 0x0027EF28 File Offset: 0x0027D128
		public override XGameObject EngineObject
		{
			get
			{
				return this._xobject;
			}
		}

		// Token: 0x170033B1 RID: 13233
		// (get) Token: 0x0600BF20 RID: 48928 RVA: 0x0027EF40 File Offset: 0x0027D140
		public XGameObject MoveObj
		{
			get
			{
				return this.IsMounted ? this._mount.EngineObject : this.EngineObject;
			}
		}

		// Token: 0x170033B2 RID: 13234
		// (get) Token: 0x0600BF21 RID: 48929 RVA: 0x0027EF70 File Offset: 0x0027D170
		public virtual string Prefab
		{
			get
			{
				return (this._attr == null) ? string.Empty : this._attr.Prefab;
			}
		}

		// Token: 0x170033B3 RID: 13235
		// (get) Token: 0x0600BF22 RID: 48930 RVA: 0x0027EF9C File Offset: 0x0027D19C
		public XStateDefine CurState
		{
			get
			{
				return this._machine.Current;
			}
		}

		// Token: 0x170033B4 RID: 13236
		// (get) Token: 0x0600BF23 RID: 48931 RVA: 0x0027EFBC File Offset: 0x0027D1BC
		public long ActionToken
		{
			get
			{
				return this._machine.ActionToken;
			}
		}

		// Token: 0x170033B5 RID: 13237
		// (get) Token: 0x0600BF24 RID: 48932 RVA: 0x0027EFD9 File Offset: 0x0027D1D9
		// (set) Token: 0x0600BF25 RID: 48933 RVA: 0x0027EFE1 File Offset: 0x0027D1E1
		public XEntity MobbedBy { get; set; }

		// Token: 0x170033B6 RID: 13238
		// (get) Token: 0x0600BF26 RID: 48934 RVA: 0x0027EFEA File Offset: 0x0027D1EA
		// (set) Token: 0x0600BF27 RID: 48935 RVA: 0x0027EFF2 File Offset: 0x0027D1F2
		public bool LifewithinMobbedSkill { get; set; }

		// Token: 0x170033B7 RID: 13239
		// (get) Token: 0x0600BF28 RID: 48936 RVA: 0x0027EFFB File Offset: 0x0027D1FB
		// (set) Token: 0x0600BF29 RID: 48937 RVA: 0x0027F003 File Offset: 0x0027D203
		public bool MobShieldable { get; set; }

		// Token: 0x170033B8 RID: 13240
		// (get) Token: 0x0600BF2A RID: 48938 RVA: 0x0027F00C File Offset: 0x0027D20C
		// (set) Token: 0x0600BF2B RID: 48939 RVA: 0x0027F030 File Offset: 0x0027D230
		public bool MobShield
		{
			get
			{
				return this.MobbedBy != null && this._mob_shield;
			}
			set
			{
				bool flag = this.MobbedBy == null;
				if (!flag)
				{
					bool flag2 = this._mob_shield != value;
					if (flag2)
					{
						this._mob_shield = value;
						this.OnHide(this._mob_shield, BillBoardHideType.Filter);
					}
				}
			}
		}

		// Token: 0x0600BF2C RID: 48940 RVA: 0x0027F074 File Offset: 0x0027D274
		public XEntity()
		{
			this._translationCb = new XTimerMgr.ElapsedEventHandler(this.Translation);
			this._endSlowMotionCb = new XTimerMgr.ElapsedEventHandler(this.EndSlowMotion);
			this.CanSelected = true;
		}

		// Token: 0x0600BF2D RID: 48941 RVA: 0x0027F23C File Offset: 0x0027D43C
		public float SubDelay(float t)
		{
			bool isPlayer = this.IsPlayer;
			float result;
			if (isPlayer)
			{
				float num = (float)XSingleton<XServerTimeMgr>.singleton.GetDelay() / 1000f;
				result = ((num > 0.15f) ? (t - 0.15f) : (t - num));
			}
			else
			{
				result = t;
			}
			return result;
		}

		// Token: 0x0600BF2E RID: 48942 RVA: 0x0027F284 File Offset: 0x0027D484
		public float GetDelay()
		{
			return (float)XSingleton<XServerTimeMgr>.singleton.GetDelay() / 1000f;
		}

		// Token: 0x0600BF2F RID: 48943 RVA: 0x0027F2A8 File Offset: 0x0027D4A8
		public static bool ValideEntity(XEntity e)
		{
			return e != null && !e.IsDead && !e.Deprecated && !e.Destroying;
		}

		// Token: 0x0600BF30 RID: 48944 RVA: 0x0027F2DC File Offset: 0x0027D4DC
		public override void OnCreated()
		{
			XFightGroupDocument.OnCalcFightGroup(this);
			base.OnCreated();
			XOnEntityCreatedArgs @event = XEventPool<XOnEntityCreatedArgs>.GetEvent();
			@event.entity = this;
			@event.Firer = XSingleton<XGame>.singleton.Doc;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			this._TryCreateHUDComponent();
			bool flag = this.IsRole && !this.IsPlayer;
			if (flag)
			{
				switch (this.Attributes.Outlook.state.type)
				{
				case OutLookStateType.OutLook_Sit:
					this.PlaySpecifiedAnimation(XHomeCookAndPartyDocument.Doc.GetHomeFeastAction(this.Attributes.BasicTypeID % 10U));
					break;
				case OutLookStateType.OutLook_Dance:
					this.PlaySpecifiedAnimation(XDanceDocument.Doc.GetDanceAction(this.PresentID, this.Attributes.Outlook.state.param));
					break;
				case OutLookStateType.OutLook_RidePet:
					XPetDocument.TryMount(true, this, this.Attributes.Outlook.state.param, true);
					break;
				case OutLookStateType.OutLook_Inherit:
					XGuildInheritDocument.TryInInherit(this);
					break;
				case OutLookStateType.OutLook_RidePetCopilot:
				{
					XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(this.Attributes.Outlook.state.paramother);
					bool flag2 = entity != null;
					if (flag2)
					{
						XPetDocument.TryMountCopilot(true, this, entity, true);
					}
					break;
				}
				}
			}
			bool flag3 = XSingleton<XCutScene>.singleton.IsPlaying && XSingleton<XCutScene>.singleton.IsExcludeNewBorn;
			if (flag3)
			{
				XSingleton<XEntityMgr>.singleton.Puppets(this, true, true);
			}
			else
			{
				bool flag4 = !this.IsPlayer;
				if (flag4)
				{
					bool flag5 = this._attr != null && this._attr.SoloShow;
					if (flag5)
					{
						XOthersAttributes xothersAttributes = this._attr as XOthersAttributes;
						bool flag6 = xothersAttributes == null || !xothersAttributes.GeneralCutScene;
						if (flag6)
						{
							XSingleton<XScene>.singleton.GameCamera.TrySolo();
						}
					}
					else
					{
						XSingleton<XScene>.singleton.GameCamera.TrySolo();
					}
					bool flag7 = this._present != null;
					if (flag7)
					{
						this._present.ShowUp();
					}
				}
				else
				{
					XSingleton<XEntityMgr>.singleton.Puppets(this, false, false);
				}
			}
			bool flag8 = !this.IsPlayer;
			if (flag8)
			{
				bool flag9 = this._nav != null;
				if (flag9)
				{
					this._nav.Active();
				}
				bool flag10 = this._ai != null;
				if (flag10)
				{
					this._ai.Active();
				}
			}
			bool flag11 = !this.IsNpc;
			if (flag11)
			{
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XGravityComponent.uuID);
			}
			this.SetCollisionLayer(this._layer);
			bool flag12 = !this.IsPlayer;
			if (flag12)
			{
				XSecurityStatistics xsecurityStatistics = XSecurityStatistics.TryGetStatistics(this);
				bool flag13 = xsecurityStatistics != null;
				if (flag13)
				{
					xsecurityStatistics.OnStart();
				}
			}
			bool flag14 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_WORLDBOSS || XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_GUILD_BOSS;
			if (flag14)
			{
				bool isBoss = this.IsBoss;
				if (isBoss)
				{
					this.IsServerFighting = true;
				}
			}
			this.InitChildAtor();
		}

		// Token: 0x0600BF31 RID: 48945 RVA: 0x0027F5F0 File Offset: 0x0027D7F0
		public override void OnDestroy()
		{
			bool flag = this._next_timer_token > 0U;
			if (flag)
			{
				this.Translation(this);
			}
			bool flag2 = this._xobject == null;
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("XEntity Destory error", this.Name, null, null, null, null);
			}
			else
			{
				this._xobject.SetParent(null);
				bool flag3 = this.Nav != null;
				if (flag3)
				{
					base.DetachComponent(XNavigationComponent.uuID);
				}
				bool flag4 = this.MobbedBy != null && !this.MobbedBy.Deprecated && this.MobbedBy.Skill != null;
				if (flag4)
				{
					this.MobbedBy.Skill.RemoveSkillMob(this);
				}
				this.MobbedBy = null;
				bool isMounted = this.IsMounted;
				if (isMounted)
				{
					bool isCopilotMounted = this.IsCopilotMounted;
					if (isCopilotMounted)
					{
						this._mount.UnMountEntity(this);
					}
					else
					{
						this._mount.UnMountAll();
						this._mount.OnDestroy();
						this._mount = null;
					}
				}
				bool isTransform = this.IsTransform;
				if (isTransform)
				{
					XSingleton<XEntityMgr>.singleton.DestroyImmediate(this._transformer);
					this._transformer = null;
				}
				XFightGroupDocument.OnDecalcFightGroup(this);
				base.OnDestroy();
			}
		}

		// Token: 0x0600BF32 RID: 48946 RVA: 0x0027F72C File Offset: 0x0027D92C
		public bool HasComeOnPresent()
		{
			return this.SkillMgr != null && this.SkillMgr.GetAppearIdentity() != 0U && (!this.IsRole || XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID).ShowUp);
		}

		// Token: 0x0600BF33 RID: 48947 RVA: 0x0027F77C File Offset: 0x0027D97C
		public void DestroyAffiliate(XAffiliate affiliate)
		{
			for (int i = 0; i < this._affiliates.Count; i++)
			{
				bool flag = this._affiliates[i] == affiliate;
				if (flag)
				{
					affiliate.OnDestroy();
					this._affiliates.RemoveAt(i);
					break;
				}
			}
		}

		// Token: 0x0600BF34 RID: 48948 RVA: 0x0027F7D0 File Offset: 0x0027D9D0
		public void TriggerDeath(XEntity killer)
		{
			bool flag = this._attr != null && this._attr.IsDead;
			if (!flag)
			{
				this._attr.IsDead = true;
				XRealDeadEventArgs @event = XEventPool<XRealDeadEventArgs>.GetEvent();
				@event.Firer = this;
				@event.Killer = killer;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				@event = XEventPool<XRealDeadEventArgs>.GetEvent();
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				@event.Killer = killer;
				@event.TheDead = this;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				XSingleton<XLevelStatistics>.singleton.OnMonsterDie(this);
			}
		}

		// Token: 0x0600BF35 RID: 48949 RVA: 0x0027F868 File Offset: 0x0027DA68
		public void UpdateSpecialStateFromServer(uint specialstate, uint mask)
		{
			this._server_special_state = specialstate;
			bool flag = ((ulong)mask & (ulong)(1L << (XFastEnumIntEqualityComparer<UnitSpecialState>.ToInt(UnitSpecialState.Unit_Puppet) & 31))) > 0UL;
			if (flag)
			{
				bool freezed = ((ulong)specialstate & (ulong)(1L << (XFastEnumIntEqualityComparer<UnitSpecialState>.ToInt(UnitSpecialState.Unit_Puppet) & 31))) > 0UL;
				bool isPlayer = this.IsPlayer;
				if (isPlayer)
				{
					bool flag2 = mask == uint.MaxValue;
					if (flag2)
					{
						XSingleton<XInput>.singleton.UnFreezed();
					}
					XSingleton<XInput>.singleton.Freezed = freezed;
				}
			}
			bool flag3 = ((ulong)mask & (ulong)(1L << (XFastEnumIntEqualityComparer<UnitSpecialState>.ToInt(UnitSpecialState.Unit_Invisible) & 31))) > 0UL;
			if (flag3)
			{
				bool flag4 = ((ulong)specialstate & (ulong)(1L << (XFastEnumIntEqualityComparer<UnitSpecialState>.ToInt(UnitSpecialState.Unit_Invisible) & 31))) > 0UL;
				this.RendererToggle(!flag4);
			}
		}

		// Token: 0x0600BF36 RID: 48950 RVA: 0x0027F914 File Offset: 0x0027DB14
		public XQTEState GetQTESpecificPhase()
		{
			XStateDefine xstateDefine = this.Machine.Current;
			XQTEState result;
			if (xstateDefine != XStateDefine.XState_Freeze)
			{
				if (xstateDefine != XStateDefine.XState_BeHit)
				{
					result = XQTEState.QTE_None;
				}
				else
				{
					result = this._behit.GetQTESpecificPhase();
				}
			}
			else
			{
				result = XQTEState.QTE_HitFreeze;
			}
			return result;
		}

		// Token: 0x0600BF37 RID: 48951 RVA: 0x0027F952 File Offset: 0x0027DB52
		public void ApplyMove(Vector3 movement)
		{
			this._movement += movement;
		}

		// Token: 0x0600BF38 RID: 48952 RVA: 0x0027F967 File Offset: 0x0027DB67
		public void ApplyMove(float x, float y, float z)
		{
			this._movement.x = this._movement.x + x;
			this._movement.z = this._movement.z + z;
			this._movement.y = this._movement.y + y;
		}

		// Token: 0x0600BF39 RID: 48953 RVA: 0x0027F99C File Offset: 0x0027DB9C
		public void LookTo(Vector3 forward)
		{
			bool flag = this.MoveObj != null;
			if (flag)
			{
				this.MoveObj.Forward = forward;
			}
			bool flag2 = this.Rotate != null;
			if (flag2)
			{
				this.Rotate.Cancel();
			}
		}

		// Token: 0x0600BF3A RID: 48954 RVA: 0x0027F9E0 File Offset: 0x0027DBE0
		protected virtual void PositionTo(Vector3 pos)
		{
			bool flag = this.MoveObj != null;
			if (flag)
			{
				this.MoveObj.Position = pos;
			}
			bool flag2 = this.MoveObj != null;
			if (flag2)
			{
				this.MoveObj.Move(Vector3.down);
			}
			bool flag3 = this._net != null;
			if (flag3)
			{
				this._net.CorrectNet(pos);
			}
			bool flag4 = this.IsPlayer && XSingleton<XScene>.singleton.GameCamera.Wall != null;
			if (flag4)
			{
				XSingleton<XScene>.singleton.GameCamera.Wall.EndEffect();
				XSingleton<XScene>.singleton.GameCamera.Wall.TargetY = XSingleton<XScene>.singleton.GameCamera.Root_R_Y;
			}
		}

		// Token: 0x0600BF3B RID: 48955 RVA: 0x0027FA9C File Offset: 0x0027DC9C
		public virtual void CorrectMe(Vector3 pos, Vector3 face, bool reconnected = false, bool fade = false)
		{
			pos.y = XSingleton<XScene>.singleton.TerrainY(pos) + ((this.MoveObj != null && this.MoveObj.EnableCC) ? 0.25f : 0.05f);
			bool flag = this._nav != null;
			if (flag)
			{
				this._nav.Interrupt();
			}
			if (reconnected)
			{
				this.LookTo(face);
				this.PositionTo(pos);
			}
			else
			{
				bool flag2 = this.IsPlayer || (XSingleton<XScene>.singleton.bSpectator && this == XSingleton<XEntityMgr>.singleton.Player.WatchTo);
				if (flag2)
				{
					bool isPlayer = this.IsPlayer;
					if (isPlayer)
					{
						XSingleton<XEntityMgr>.singleton.Idled(this);
					}
					if (fade)
					{
						this._net.Pause = true;
						this._next_pos = pos;
						this._next_face = face;
						XAutoFade.FadeOut2In(1f, 0.5f);
						bool isPlayer2 = this.IsPlayer;
						if (isPlayer2)
						{
							XSingleton<XInput>.singleton.Freezed = true;
							XSingleton<XAIGeneralMgr>.singleton.EnablePlayerAI(false);
						}
						bool flag3 = this._next_timer_token > 0U;
						if (flag3)
						{
							XSingleton<XTimerMgr>.singleton.KillTimer(this._next_timer_token);
							bool isPlayer3 = this.IsPlayer;
							if (isPlayer3)
							{
								XSingleton<XInput>.singleton.Freezed = false;
								XSingleton<XAIGeneralMgr>.singleton.EnablePlayerAI(true);
							}
						}
						this._next_timer_token = XSingleton<XTimerMgr>.singleton.SetTimer(0.47f, this._translationCb, null);
					}
					else
					{
						this.LookTo(face);
						this.PositionTo(pos);
					}
				}
				else
				{
					this.LookTo(face);
					this.PositionTo(pos);
				}
			}
		}

		// Token: 0x0600BF3C RID: 48956 RVA: 0x0027FC4C File Offset: 0x0027DE4C
		public virtual void OnTransform(uint to)
		{
			bool destroying = base.Destroying;
			if (!destroying)
			{
				bool flag = this.Machine != null;
				if (flag)
				{
					this.Machine.OnAnimationOverrided();
				}
				bool flag2 = this.Skill != null && this.Skill.IsCasting();
				if (flag2)
				{
					this.Skill.EndSkill(true, true);
				}
				else
				{
					bool flag3 = this.Machine != null;
					if (flag3)
					{
						this.Machine.ForceToDefaultState(false);
					}
				}
				this.TransformFigture(to);
				this.TransformSkill(to);
			}
		}

		// Token: 0x0600BF3D RID: 48957 RVA: 0x0027FCD4 File Offset: 0x0027DED4
		private void TransformFigture(uint to)
		{
			bool flag = this.IsTransform && this._transformer.TypeID == to;
			if (!flag)
			{
				bool flag2 = this._equip != null && !this._equip.IsVisible;
				if (!flag2)
				{
					bool isTransform = this.IsTransform;
					bool isDisappear;
					if (isTransform)
					{
						isDisappear = this._transformer.IsDisappear;
						XRenderComponent.OnTransform(this._transformer, this, false);
						bool isMustTransform = XSingleton<XScene>.singleton.IsMustTransform;
						if (isMustTransform)
						{
							this.EngineObject.ClearTransformPhysic();
						}
						bool flag3 = this._transformer._present != null;
						if (flag3)
						{
							this._transformer._present.OnTransform(this, false);
						}
						this._transformer.SetCollisionLayer(this._transformer.DefaultLayer);
						this._transformer.EngineObject.SetRenderLayer(this._transformer.DefaultLayer);
						XSingleton<XEntityMgr>.singleton.DestroyImmediate(this._transformer);
						this._transformer = null;
					}
					else
					{
						bool flag4 = to == 0U;
						if (flag4)
						{
							return;
						}
						isDisappear = this.IsDisappear;
					}
					bool flag5 = to > 0U;
					if (flag5)
					{
						this._transformer = XSingleton<XEntityMgr>.singleton.CreateTransform(to, this._xobject.Position, this._xobject.Rotation, false, this, (uint)XFastEnumIntEqualityComparer<FightGroupType>.ToInt(FightGroupType.FightNeutral));
						bool flag6 = this._transformer != null;
						if (flag6)
						{
							this.InnerRendererToggle(false);
							bool flag7 = this.IsMounted && !this.IsCopilotMounted;
							if (flag7)
							{
								this.Mount.RendererToggle(false);
							}
							this._transformer.RendererToggle(!isDisappear);
							this._transformer.IsDisappear = isDisappear;
							bool flag8 = this._transformer.Ator != null;
							if (flag8)
							{
								this._transformer.Ator.speed = 1f;
							}
							XRenderComponent.OnTransform(this, this._transformer, true);
							bool isMustTransform2 = XSingleton<XScene>.singleton.IsMustTransform;
							if (isMustTransform2)
							{
								this.EngineObject.TransformPhysic(this._transformer.EngineObject);
							}
							this._transformer.SetCollisionLayer(this.DefaultLayer);
							this._transformer.EngineObject.SetRenderLayer(this.DefaultLayer);
							bool flag9 = this._transformer._present != null;
							if (flag9)
							{
								this._transformer._present.OnTransform(this, true);
							}
						}
					}
					else
					{
						this.RendererToggle(!isDisappear);
						this.IsDisappear = isDisappear;
						bool flag10 = this.Ator != null;
						if (flag10)
						{
							this.Ator.speed = 1f;
						}
						bool flag11 = !this.IsDisappear && this.Ator != null;
						if (flag11)
						{
							this.Ator.SetTrigger("EndSkill");
						}
					}
				}
			}
		}

		// Token: 0x0600BF3E RID: 48958 RVA: 0x0027FFB0 File Offset: 0x0027E1B0
		private void TransformSkill(uint to)
		{
			bool flag = this._skill != null;
			if (flag)
			{
				XEntityPresentation.RowData template = null;
				bool flag2 = to == 0U;
				if (flag2)
				{
					template = null;
				}
				else
				{
					bool isTransform = this.IsTransform;
					if (isTransform)
					{
						template = this._transformer.Present.PresentLib;
					}
					else
					{
						XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(to);
						bool flag3 = byID != null;
						if (flag3)
						{
							template = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byID.PresentID);
						}
					}
				}
				this._skill.ReAttachSkill(template, to);
			}
		}

		// Token: 0x0600BF3F RID: 48959 RVA: 0x00280040 File Offset: 0x0027E240
		public void OnTransform(XEntity transformee)
		{
			this._transformee = transformee;
		}

		// Token: 0x0600BF40 RID: 48960 RVA: 0x0028004C File Offset: 0x0027E24C
		private static void OnScale(XEntity entity, uint scaleParam)
		{
			float num = 1f;
			bool flag = scaleParam == 0U;
			if (flag)
			{
				entity.Scale = entity.Present.PresentLib.Scale;
				Vector3 localScale = Vector3.one * entity.Scale;
				entity.EngineObject.LocalScale = localScale;
			}
			else
			{
				num = scaleParam * 0.001f;
				entity.Scale = entity.Present.PresentLib.Scale * num;
				Vector3 localScale2 = Vector3.one * entity.Scale;
				entity.EngineObject.LocalScale = localScale2;
				num *= 1.5f;
			}
			bool isPlayer = entity.IsPlayer;
			if (isPlayer)
			{
				XSingleton<XCustomShadowMgr>.singleton.SetShadowScale(num);
			}
		}

		// Token: 0x0600BF41 RID: 48961 RVA: 0x00280108 File Offset: 0x0027E308
		public void OnScale(uint scaleParam)
		{
			XEntity.OnScale(this, scaleParam);
			bool isTransform = this.IsTransform;
			if (isTransform)
			{
				XEntity.OnScale(this._transformer, scaleParam);
			}
		}

		// Token: 0x0600BF42 RID: 48962 RVA: 0x00280138 File Offset: 0x0027E338
		private void Translation(object o)
		{
			this._next_timer_token = 0U;
			this._net.Pause = false;
			bool isPlayer = this.IsPlayer;
			if (isPlayer)
			{
				XSingleton<XInput>.singleton.Freezed = false;
			}
			bool flag = o == this;
			if (!flag)
			{
				bool flag2 = this.MoveObj != null;
				if (flag2)
				{
					this.LookTo(this._next_face);
					XSingleton<XScene>.singleton.GameCamera.YRotateEx(XSingleton<XCommon>.singleton.AngleToFloat(this.MoveObj.Forward));
					this.PositionTo(this._next_pos);
					bool isPlayer2 = this.IsPlayer;
					if (isPlayer2)
					{
						XSingleton<XAIGeneralMgr>.singleton.EnablePlayerAI(true);
					}
				}
			}
		}

		// Token: 0x0600BF43 RID: 48963 RVA: 0x002801E0 File Offset: 0x0027E3E0
		public void DyingCloseUp()
		{
			bool flag = !XSingleton<XCutScene>.singleton.IsPlaying && !this.Present.PresentLib.Huge;
			if (flag)
			{
				bool flag2 = XSingleton<XScene>.singleton.GameCamera.Solo != null;
				if (flag2)
				{
					XSingleton<XScene>.singleton.GameCamera.Solo.Stop();
				}
				XCameraMotionData xcameraMotionData = new XCameraMotionData();
				xcameraMotionData.AutoSync_At_Begin = true;
				xcameraMotionData.Coordinate = CameraMotionSpace.World;
				xcameraMotionData.Follow_Position = false;
				xcameraMotionData.LookAt_Target = false;
				xcameraMotionData.At = 0f;
				xcameraMotionData.Motion = ((this.Height > 2f) ? "Animation/Main_Camera/Main_Camera_die_bigguy" : "Animation/Main_Camera/Main_Camera_die");
				XCameraMotionEventArgs @event = XEventPool<XCameraMotionEventArgs>.GetEvent();
				@event.Motion = xcameraMotionData;
				@event.Target = this;
				@event.Trigger = "ToEffect";
				@event.Firer = XSingleton<XScene>.singleton.GameCamera;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				this.BeginSlowMotion(0.3f, 1f, true);
			}
		}

		// Token: 0x0600BF44 RID: 48964 RVA: 0x002802E0 File Offset: 0x0027E4E0
		public virtual void Dying()
		{
			XOthersAttributes xothersAttributes = this.Attributes as XOthersAttributes;
			bool flag = xothersAttributes != null && xothersAttributes.EndShow;
			if (flag)
			{
				this.DyingCloseUp();
			}
		}

		// Token: 0x0600BF45 RID: 48965 RVA: 0x00280313 File Offset: 0x0027E513
		public virtual void Died()
		{
			XSingleton<XEntityMgr>.singleton.DestroyEntity(this);
		}

		// Token: 0x0600BF46 RID: 48966 RVA: 0x00280324 File Offset: 0x0027E524
		public bool Initilize(XGameObject o, XAttributes attr, bool transform)
		{
			this._layer = o.Layer;
			base.AttachComponent(attr);
			this._attr = attr;
			this._using_cc_move = this.IsPlayer;
			this._xobject = o;
			this._xobject.UID = this.ID;
			this._xobject.Name = this.ID.ToString();
			this._client_predicted = XSingleton<XScene>.singleton.IsViewGridScene;
			int flag = transform ? XFastEnumIntEqualityComparer<XEntity.InitFlag>.ToInt(XEntity.InitFlag.Entity_Transform) : 0;
			bool result = this.Initilize(flag);
			bool isPlayer = this.IsPlayer;
			if (isPlayer)
			{
				this._xobject.EnableCC = true;
				this._xobject.EnableBC = false;
			}
			else
			{
				this._xobject.EnableCC = false;
				this._xobject.EnableBC = true;
			}
			return result;
		}

		// Token: 0x0600BF47 RID: 48967 RVA: 0x002803FC File Offset: 0x0027E5FC
		public override void Uninitilize()
		{
			bool flag = this._skill != null;
			if (flag)
			{
				bool flag2 = this._skill.IsCasting();
				if (flag2)
				{
					this._skill.EndSkill(false, false);
				}
			}
			bool flag3 = this._machine != null;
			if (flag3)
			{
				this._machine.ForceToDefaultState(false);
			}
			string text = (this._attr != null) ? this._attr.Prefab : null;
			base.Uninitilize();
			bool flag4 = this._childAtor != null;
			if (flag4)
			{
				this._childAtor.enabled = false;
				Transform transform = this._xobject.Find("");
				bool flag5 = transform != null;
				if (flag5)
				{
					XSingleton<XCommon>.singleton.EnableParticle(transform.gameObject, false);
				}
				this._childAtor = null;
			}
			bool flag6 = this._xobject != null;
			if (flag6)
			{
				XGameObject.DestroyXGameObject(this._xobject);
				this._xobject = null;
			}
		}

		// Token: 0x0600BF48 RID: 48968 RVA: 0x002804F0 File Offset: 0x0027E6F0
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			this._gravity_disabled = false;
			bool flag = this.IsMounted && this.IsCopilotMounted;
			if (flag)
			{
				this.EngineObject.Update();
			}
			else
			{
				this.Move();
			}
			this._movement.y = 0f;
			bool flag2 = !XSingleton<XGame>.singleton.SyncMode || this.IsSubstance;
			if (flag2)
			{
				this.SetDynamicLayer(this._movement.sqrMagnitude);
			}
			this._movement = Vector3.zero;
			this._server_movement = Vector3.zero;
			this.UpdateMoveTracker();
			this.MoveObj.Update();
		}

		// Token: 0x0600BF49 RID: 48969 RVA: 0x0028059C File Offset: 0x0027E79C
		public override void PostUpdate(float fDeltaT)
		{
			base.PostUpdate(fDeltaT);
			bool isTransform = this.IsTransform;
			if (isTransform)
			{
				this.Transformer.PostUpdate(fDeltaT);
			}
			bool flag = this.IsMounted && !this.IsCopilotMounted;
			if (flag)
			{
				this._mount.PostUpdate(fDeltaT);
			}
			for (int i = 0; i < this._affiliates.Count; i++)
			{
				this._affiliates[i].PostUpdate(fDeltaT);
			}
		}

		// Token: 0x0600BF4A RID: 48970 RVA: 0x00280621 File Offset: 0x0027E821
		public void OverrideAnimClip(string motion, string clipname, bool shortPath, bool force = false)
		{
			this.OverrideAnimClip(motion, clipname, shortPath, null, force);
		}

		// Token: 0x0600BF4B RID: 48971 RVA: 0x00280634 File Offset: 0x0027E834
		public void OverrideAnimClip(string motion, string clipname, bool shortPath, OverrideAnimCallback overrideAnim, bool force = false)
		{
			bool flag = string.IsNullOrEmpty(clipname);
			if (!flag)
			{
				bool flag2 = this.Ator != null;
				if (flag2)
				{
					if (shortPath)
					{
						XPresentComponent xpresentComponent = this.IsTransform ? this.Transformer.Present : this.Present;
						clipname = xpresentComponent.ActionPrefix + clipname;
					}
					this.Ator.OverrideAnim(motion, clipname, overrideAnim, force);
				}
			}
		}

		// Token: 0x0600BF4C RID: 48972 RVA: 0x002806A0 File Offset: 0x0027E8A0
		private static void AnimLoadCallback(XAnimationClip clip)
		{
			XEntity.m_AnimLength = ((clip != null) ? clip.length : -1f);
			XEntity.m_xclip = clip;
		}

		// Token: 0x0600BF4D RID: 48973 RVA: 0x002806C4 File Offset: 0x0027E8C4
		public float OverrideAnimClipGetLength(string motion, string clipname, bool shortPath)
		{
			XEntity.m_AnimLength = -1f;
			bool flag = string.IsNullOrEmpty(clipname);
			float animLength;
			if (flag)
			{
				animLength = XEntity.m_AnimLength;
			}
			else
			{
				bool flag2 = this.Ator != null;
				if (flag2)
				{
					if (shortPath)
					{
						XPresentComponent xpresentComponent = this.IsTransform ? this.Transformer.Present : this.Present;
						clipname = xpresentComponent.ActionPrefix + clipname;
					}
					this.Ator.OverrideAnim(motion, clipname, XEntity.m_AnimLoadCb, false);
				}
				animLength = XEntity.m_AnimLength;
			}
			return animLength;
		}

		// Token: 0x0600BF4E RID: 48974 RVA: 0x00280750 File Offset: 0x0027E950
		public void OverrideAnimClipGetClip(string motion, string clipname, bool shortPath, bool forceOverride, out XAnimationClip outClip)
		{
			XEntity.m_AnimLength = -1f;
			XEntity.m_xclip = null;
			bool flag = string.IsNullOrEmpty(clipname);
			if (flag)
			{
				outClip = null;
			}
			else
			{
				bool flag2 = this.Ator != null;
				if (flag2)
				{
					if (shortPath)
					{
						XPresentComponent xpresentComponent = this.IsTransform ? this.Transformer.Present : this.Present;
						clipname = xpresentComponent.ActionPrefix + clipname;
					}
					this.Ator.OverrideAnim(motion, clipname, XEntity.m_AnimLoadCb, forceOverride);
				}
				outClip = XEntity.m_xclip;
				XEntity.m_xclip = null;
			}
		}

		// Token: 0x0600BF4F RID: 48975 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void PlaySpecifiedAnimation(string anim)
		{
		}

		// Token: 0x0600BF50 RID: 48976 RVA: 0x002807E4 File Offset: 0x0027E9E4
		public void SetCollisionLayer(int layer)
		{
			bool flag = this._xobject != null && this._xobject.Layer != layer;
			if (flag)
			{
				this._xobject.Layer = layer;
				bool flag2 = this.IsMounted && !this.IsCopilotMounted;
				if (flag2)
				{
					this._mount.SetCollisionLayer(layer);
				}
			}
			bool flag3 = layer == XPlayer.PlayerLayer;
			if (flag3)
			{
				this._xobject.EnableCC = true;
				this._xobject.EnableBC = false;
			}
			else
			{
				this._xobject.EnableCC = false;
				this._xobject.EnableBC = true;
			}
		}

		// Token: 0x0600BF51 RID: 48977 RVA: 0x0028088C File Offset: 0x0027EA8C
		public void BeginSlowMotion(float factor, float duration, bool withcameraeffect = false)
		{
			XSingleton<XShell>.singleton.TimeMagic(factor);
			bool flag = this._slow_motion_token > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._slow_motion_token);
			}
			this._slow_motion_token = XSingleton<XTimerMgr>.singleton.SetTimer(duration, this._endSlowMotionCb, withcameraeffect ? this : null);
		}

		// Token: 0x0600BF52 RID: 48978 RVA: 0x002808E4 File Offset: 0x0027EAE4
		protected void StickOnGround(float outy)
		{
			float num = 0f;
			bool flag = outy > 0f;
			if (flag)
			{
				num = outy;
			}
			else
			{
				bool flag2 = !XSingleton<XScene>.singleton.TryGetTerrainY(this.MoveObj.Position, out num);
				if (flag2)
				{
					return;
				}
			}
			bool flag3 = this.MoveObj.Position.y <= num;
			if (flag3)
			{
				Vector3 position = this.MoveObj.Position;
				position.y = num + 0.01f;
				this.MoveObj.Position = position;
				this._bStandOn = (this._fly == null || this._behit.LaidOnGround());
			}
		}

		// Token: 0x0600BF53 RID: 48979 RVA: 0x0028098C File Offset: 0x0027EB8C
		protected virtual void Move()
		{
			bool flag = !this._machine.State.SyncPredicted;
			if (flag)
			{
				this._movement.x = this._server_movement.x;
				this._movement.z = this._server_movement.z;
			}
			bool flag2 = this._movement.x != 0f || this._movement.z != 0f || this._movement.y > 0f || !this._bStandOn;
			if (flag2)
			{
				Vector3 vector = this.MoveObj.Position + this._movement;
				float num = 0f;
				bool flag3 = XSingleton<XScene>.singleton.TryGetTerrainY(vector, out num);
				if (flag3)
				{
					bool flag4 = num < 0f;
					if (flag4)
					{
						bool syncPredicted = this._machine.State.SyncPredicted;
						if (syncPredicted)
						{
							this._bStandOn = false;
							float num2 = XSingleton<XScene>.singleton.TerrainY(this.MoveObj.Position);
							bool flag5 = vector.y < num2;
							if (flag5)
							{
								vector.y = num2;
							}
						}
						else
						{
							bool flag6 = !this.IsPlayer;
							if (flag6)
							{
								vector.y = this.MoveObj.Position.y;
								this.MoveObj.Position = vector;
								this._bStandOn = true;
							}
						}
					}
					else
					{
						bool using_cc_move = this._using_cc_move;
						if (using_cc_move)
						{
							Vector3 position = this.MoveObj.Position;
							this._bStandOn = this.ControllerMove(this.MoveObj);
							bool flag7 = !XSingleton<XScene>.singleton.TryGetTerrainY(this.MoveObj.Position, out num) || num < 0f;
							if (flag7)
							{
								this.MoveObj.Position = position;
							}
							else
							{
								bool bStandOn = this._bStandOn;
								if (bStandOn)
								{
									bool flag8 = this.MoveObj.Position.y < num && num - this.MoveObj.Position.y > 0.05f;
									if (flag8)
									{
										this._bStandOn = false;
									}
								}
								else
								{
									num = -1f;
								}
							}
						}
						else
						{
							bool flag9 = !this._machine.State.SyncPredicted || XSingleton<XScene>.singleton.CheckDynamicBlock(this.MoveObj.Position, vector);
							if (flag9)
							{
								this.MoveObj.Position = vector;
								this._bStandOn = false;
							}
						}
					}
					bool flag10 = !this._bStandOn;
					if (flag10)
					{
						vector.x = this.MoveObj.Position.x;
						vector.z = this.MoveObj.Position.z;
						this.MoveObj.Position = vector;
						this.StickOnGround(num);
					}
					bool flag11 = this.EngineObject != this.MoveObj;
					if (flag11)
					{
						this.EngineObject.SyncPos();
					}
				}
			}
		}

		// Token: 0x0600BF54 RID: 48980 RVA: 0x00280C8C File Offset: 0x0027EE8C
		protected bool ControllerMove(XGameObject moveObj)
		{
			Vector3 position = moveObj.Position;
			CollisionFlags collisionFlags = moveObj.Move(this._movement);
			bool flag = XSingleton<XScene>.singleton.CheckDynamicBlock(position, moveObj.Position);
			bool result;
			if (flag)
			{
				result = ((collisionFlags & (CollisionFlags)4) != null && (this._fly == null || this._behit.LaidOnGround()));
			}
			else
			{
				this.MoveObj.Position = position;
				result = this._bStandOn;
			}
			return result;
		}

		// Token: 0x0600BF55 RID: 48981 RVA: 0x00280CFC File Offset: 0x0027EEFC
		public void SyncServerMove(Vector3 delta)
		{
			delta.y = 0f;
			bool flag = delta.sqrMagnitude < XCommon.XEps * XCommon.XEps;
			if (flag)
			{
				this._server_movement = Vector3.zero;
			}
			else
			{
				this._server_movement = delta;
			}
		}

		// Token: 0x0600BF56 RID: 48982 RVA: 0x00280D44 File Offset: 0x0027EF44
		private void SetDynamicLayer(float dis)
		{
			bool flag = this._skill != null && this._skill.IsCasting();
			if (flag)
			{
				bool flag2 = !XSingleton<XGame>.singleton.SyncMode;
				if (flag2)
				{
					this._skill.CurrentSkill.UpdateCollisionLayer(dis / Time.deltaTime);
				}
			}
			else
			{
				bool flag3 = this._machine != null;
				if (flag3)
				{
					this._machine.UpdateCollisionLayer();
				}
			}
		}

		// Token: 0x0600BF57 RID: 48983 RVA: 0x00280DB4 File Offset: 0x0027EFB4
		private void EndSlowMotion(object o)
		{
			XSingleton<XShell>.singleton.TimeMagicBack();
			this._slow_motion_token = 0U;
			bool flag = o != null;
			if (flag)
			{
				XCameraMotionEndEventArgs @event = XEventPool<XCameraMotionEndEventArgs>.GetEvent();
				@event.Target = this;
				@event.Firer = XSingleton<XScene>.singleton.GameCamera;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x0600BF58 RID: 48984 RVA: 0x00280E08 File Offset: 0x0027F008
		private void UpdateMoveTracker()
		{
			bool isTransform = this.IsTransform;
			if (isTransform)
			{
				this.Transformer.MoveObj.Position = this.MoveObj.Position;
				this.Transformer.MoveObj.Rotation = this.MoveObj.Rotation;
			}
			bool bSpectator = XSingleton<XScene>.singleton.bSpectator;
			if (bSpectator)
			{
				this.UpdateWatcher();
			}
		}

		// Token: 0x0600BF59 RID: 48985 RVA: 0x00280E74 File Offset: 0x0027F074
		public void OnMount(XMount mount, bool copilot)
		{
			bool flag = this.IsMounted && !this.IsCopilotMounted;
			if (flag)
			{
				this._mount.OnDestroy();
			}
			this._mount = mount;
			this._is_mount_copilot = copilot;
			bool flag2 = this._xobject != null;
			if (flag2)
			{
				bool isPlayer = this.IsPlayer;
				if (isPlayer)
				{
					this._xobject.EnableBC = false;
					this._xobject.EnableCC = !this.IsMounted;
				}
				else
				{
					this._xobject.EnableBC = !this.IsMounted;
					this._xobject.EnableCC = false;
				}
			}
			bool isMounted = this.IsMounted;
			if (isMounted)
			{
				XOnMountedEventArgs @event = XEventPool<XOnMountedEventArgs>.GetEvent();
				@event.Firer = this;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				bool isPlayer2 = this.IsPlayer;
				if (isPlayer2)
				{
					XOnMountedEventArgs event2 = XEventPool<XOnMountedEventArgs>.GetEvent();
					event2.Firer = XSingleton<XGame>.singleton.Doc;
					XSingleton<XEventMgr>.singleton.FireEvent(event2);
				}
			}
			else
			{
				XOnUnMountedEventArgs event3 = XEventPool<XOnUnMountedEventArgs>.GetEvent();
				event3.Firer = this;
				XSingleton<XEventMgr>.singleton.FireEvent(event3);
				bool isPlayer3 = this.IsPlayer;
				if (isPlayer3)
				{
					XOnUnMountedEventArgs event4 = XEventPool<XOnUnMountedEventArgs>.GetEvent();
					event4.Firer = XSingleton<XGame>.singleton.Doc;
					XSingleton<XEventMgr>.singleton.FireEvent(event4);
				}
			}
			for (int i = 0; i < this.Affiliates.Count; i++)
			{
				this.Affiliates[i].OnMount();
			}
			this._bStandOn = false;
		}

		// Token: 0x0600BF5A RID: 48986 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void UpdateWatcher()
		{
		}

		// Token: 0x0600BF5B RID: 48987 RVA: 0x00281008 File Offset: 0x0027F208
		private void _TryCreateHUDComponent()
		{
			bool flag = base.GetXComponent(XHUDComponent.uuID) == null;
			if (flag)
			{
				bool flag2 = !this.IsNpc;
				if (flag2)
				{
					XSingleton<XComponentMgr>.singleton.CreateComponent(this, XHUDComponent.uuID);
				}
			}
		}

		// Token: 0x0600BF5C RID: 48988 RVA: 0x00281048 File Offset: 0x0027F248
		public virtual bool ProcessRealTimeShadow()
		{
			bool flag = this._equip != null;
			bool result;
			if (flag)
			{
				bool flag2 = ((this._transformee != null) ? this._transformee.IsPlayer : this.IsPlayer) && XQualitySetting._CastShadow;
				this._equip.EnableRealTimeShadow(flag2);
				result = flag2;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600BF5D RID: 48989 RVA: 0x002810A0 File Offset: 0x0027F2A0
		public virtual bool CastFakeShadow()
		{
			return false;
		}

		// Token: 0x0600BF5E RID: 48990 RVA: 0x002810B4 File Offset: 0x0027F2B4
		public void RendererToggle(bool enabled)
		{
			bool isTransform = this.IsTransform;
			if (isTransform)
			{
				this.Transformer.RendererToggle(enabled);
				bool flag = this.Transformer.IsMounted && !this.Transformer.IsCopilotMounted && this.Transformer.Mount.EngineObject != null;
				if (flag)
				{
					this.Transformer.Mount.RendererToggle(enabled);
				}
				this.Transformer.IsDisappear = !enabled;
			}
			else
			{
				this.InnerRendererToggle(enabled);
				bool flag2 = this.IsMounted && !this.IsCopilotMounted && this.Mount.EngineObject != null;
				if (flag2)
				{
					this.Mount.RendererToggle(enabled);
				}
				this.IsDisappear = !enabled;
			}
		}

		// Token: 0x0600BF5F RID: 48991 RVA: 0x0028117C File Offset: 0x0027F37C
		private void InnerRendererToggle(bool enabled)
		{
			bool flag = this._equip != null;
			if (flag)
			{
				this._equip.EnableRender(enabled);
			}
			else
			{
				bool flag2 = this is XMount;
				if (flag2)
				{
					XMount xmount = this as XMount;
					xmount.SetActive(enabled);
				}
				else
				{
					bool flag3 = this._xobject != null;
					if (flag3)
					{
						this._xobject.SetActive(enabled, "");
					}
				}
			}
			this.ShowEntityEffect(enabled, BillBoardHideType.InnerRenderer);
		}

		// Token: 0x0600BF60 RID: 48992 RVA: 0x002811F4 File Offset: 0x0027F3F4
		private static void _InitChildAtor(XGameObject gameObject, object o, int commandID)
		{
			XEntity xentity = o as XEntity;
			bool flag = xentity != null;
			if (flag)
			{
				Transform transform = gameObject.Find("");
				bool flag2 = transform != null;
				if (flag2)
				{
					xentity._childAtor = transform.GetComponentInChildren<Animator>();
					bool flag3 = xentity._childAtor != null;
					if (flag3)
					{
						bool flag4 = xentity.Ator.IsSame(xentity._childAtor);
						if (flag4)
						{
							xentity._childAtor = null;
						}
						else
						{
							xentity._childAtor.enabled = true;
							bool flag5 = xentity._childAtor.runtimeAnimatorController != null;
							if (flag5)
							{
								xentity._childAtor.Play(xentity._childAtor.runtimeAnimatorController.name, -1, 0f);
							}
							XSingleton<XCommon>.singleton.EnableParticle(transform.gameObject, true);
						}
					}
				}
			}
		}

		// Token: 0x0600BF61 RID: 48993 RVA: 0x002812CC File Offset: 0x0027F4CC
		public void InitChildAtor()
		{
			bool enableAtor = XStateMachine._EnableAtor;
			if (enableAtor)
			{
				this.EngineObject.CallCommand(XEntity._initChildAtorCb, this, -1, false);
			}
		}

		// Token: 0x0600BF62 RID: 48994 RVA: 0x002812F8 File Offset: 0x0027F4F8
		private void ShowEntityEffect(bool show, BillBoardHideType billboardType)
		{
			XBillboardShowCtrlEventArgs @event = XEventPool<XBillboardShowCtrlEventArgs>.GetEvent();
			@event.show = show;
			@event.type = billboardType;
			@event.Firer = ((this.Transformee == null) ? this : this.Transformee);
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
			XFootFxComponent xfootFxComponent = base.GetXComponent(XFootFxComponent.uuID) as XFootFxComponent;
			bool flag = xfootFxComponent != null;
			if (flag)
			{
				xfootFxComponent.SetActive(show);
			}
			XShadowComponent xshadowComponent = base.GetXComponent(XShadowComponent.uuID) as XShadowComponent;
			bool flag2 = xshadowComponent != null;
			if (flag2)
			{
				xshadowComponent.SetActive(show);
			}
		}

		// Token: 0x0600BF63 RID: 48995 RVA: 0x00281388 File Offset: 0x0027F588
		public void OnFade(bool fadeIn, float time, bool isVisibleAfterFadeout, BillBoardHideType billboardType)
		{
			XEntity realEntity = this.RealEntity;
			if (fadeIn)
			{
				this._isVisible = true;
				this.ShowEntityEffect(true, billboardType);
			}
			else
			{
				this._isVisible = isVisibleAfterFadeout;
				bool flag = !this._isVisible;
				if (flag)
				{
					this.ShowEntityEffect(false, billboardType);
				}
			}
			XRenderComponent.OnFade(realEntity, fadeIn, time, isVisibleAfterFadeout);
		}

		// Token: 0x0600BF64 RID: 48996 RVA: 0x002813E4 File Offset: 0x0027F5E4
		public void OnHide(bool hide, BillBoardHideType billboardType)
		{
			this._isVisible = !hide;
			XEntity realEntity = this.RealEntity;
			realEntity.ShowEntityEffect(this._isVisible, billboardType);
			XRenderComponent.OnHide(realEntity, hide);
		}

		// Token: 0x0600BF65 RID: 48997 RVA: 0x0028141C File Offset: 0x0027F61C
		public static bool FilterFx(Vector3 pos, float dis)
		{
			bool filterFx = XSingleton<XScene>.singleton.FilterFx;
			if (filterFx)
			{
				Vector3 position = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position;
				float num = (pos.x - position.x) * (pos.x - position.x) + (pos.z - position.z) * (pos.z - position.z);
				bool flag = num > dis;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BF66 RID: 48998 RVA: 0x0028149C File Offset: 0x0027F69C
		public static bool FilterFx(XEntity e, float dis)
		{
			bool flag = XSingleton<XScene>.singleton.FilterFx && !e.IsPlayer && !(e is XDummy);
			if (flag)
			{
				Vector3 position = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position;
				Vector3 position2 = e.EngineObject.Position;
				float num = (position2.x - position.x) * (position2.x - position.x) + (position2.z - position.z) * (position2.z - position.z);
				bool flag2 = num > dis;
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x04004E0C RID: 19980
		protected bool _client_predicted = false;

		// Token: 0x04004E0D RID: 19981
		protected bool _passive = false;

		// Token: 0x04004E0E RID: 19982
		protected bool _using_cc_move = false;

		// Token: 0x04004E0F RID: 19983
		protected XPresentComponent _present = null;

		// Token: 0x04004E10 RID: 19984
		protected XStateMachine _machine = null;

		// Token: 0x04004E11 RID: 19985
		protected XSkillComponent _skill = null;

		// Token: 0x04004E12 RID: 19986
		protected XBuffComponent _buff = null;

		// Token: 0x04004E13 RID: 19987
		protected XNetComponent _net = null;

		// Token: 0x04004E14 RID: 19988
		protected XRotationComponent _rotate = null;

		// Token: 0x04004E15 RID: 19989
		protected XBeHitComponent _behit = null;

		// Token: 0x04004E16 RID: 19990
		protected XDeathComponent _death = null;

		// Token: 0x04004E17 RID: 19991
		protected XNavigationComponent _nav = null;

		// Token: 0x04004E18 RID: 19992
		protected XEquipComponent _equip = null;

		// Token: 0x04004E19 RID: 19993
		protected XRenderComponent _render = null;

		// Token: 0x04004E1A RID: 19994
		protected XFlyComponent _fly = null;

		// Token: 0x04004E1B RID: 19995
		protected XAIComponent _ai = null;

		// Token: 0x04004E1C RID: 19996
		protected XQuickTimeEventComponent _qte = null;

		// Token: 0x04004E1D RID: 19997
		protected XAudioComponent _audio = null;

		// Token: 0x04004E1E RID: 19998
		protected XBillboardComponent _billboard = null;

		// Token: 0x04004E1F RID: 19999
		protected float _airthreshold = 0.1f;

		// Token: 0x04004E20 RID: 20000
		protected float _height = 0f;

		// Token: 0x04004E21 RID: 20001
		protected float _radius = 0f;

		// Token: 0x04004E22 RID: 20002
		protected float _scale = 1f;

		// Token: 0x04004E23 RID: 20003
		protected bool _bStandOn = false;

		// Token: 0x04004E24 RID: 20004
		protected bool _bDisappear = false;

		// Token: 0x04004E25 RID: 20005
		protected bool _gravity_disabled = false;

		// Token: 0x04004E26 RID: 20006
		private bool _mob_shield = false;

		// Token: 0x04004E27 RID: 20007
		protected XEntity.EnitityType _eEntity_Type = XEntity.EnitityType.Entity_None;

		// Token: 0x04004E28 RID: 20008
		protected int _layer = 0;

		// Token: 0x04004E29 RID: 20009
		private int _wave = -1;

		// Token: 0x04004E2A RID: 20010
		private float _create_time = 0f;

		// Token: 0x04004E2B RID: 20011
		private uint _slow_motion_token = 0U;

		// Token: 0x04004E2C RID: 20012
		private bool _server_fighting = false;

		// Token: 0x04004E2D RID: 20013
		private Vector3 _next_pos = Vector3.zero;

		// Token: 0x04004E2E RID: 20014
		private Vector3 _next_face = Vector3.zero;

		// Token: 0x04004E2F RID: 20015
		private uint _next_timer_token = 0U;

		// Token: 0x04004E30 RID: 20016
		private uint _server_special_state = 0U;

		// Token: 0x04004E31 RID: 20017
		private ulong _last_special_state_from_server = 0UL;

		// Token: 0x04004E32 RID: 20018
		protected Vector3 _movement = Vector3.zero;

		// Token: 0x04004E33 RID: 20019
		protected Vector3 _server_movement = Vector3.zero;

		// Token: 0x04004E34 RID: 20020
		protected XGameObject _xobject = null;

		// Token: 0x04004E35 RID: 20021
		protected XEntity _transformer = null;

		// Token: 0x04004E36 RID: 20022
		protected XEntity _transformee = null;

		// Token: 0x04004E37 RID: 20023
		protected XMount _mount = null;

		// Token: 0x04004E38 RID: 20024
		protected bool _is_mount_copilot = false;

		// Token: 0x04004E39 RID: 20025
		protected Animator _childAtor = null;

		// Token: 0x04004E3A RID: 20026
		private static CommandCallback _initChildAtorCb = new CommandCallback(XEntity._InitChildAtor);

		// Token: 0x04004E3B RID: 20027
		protected bool _isVisible = true;

		// Token: 0x04004E3C RID: 20028
		private List<XAffiliate> _affiliates = new List<XAffiliate>();

		// Token: 0x04004E3D RID: 20029
		private XTimerMgr.ElapsedEventHandler _translationCb = null;

		// Token: 0x04004E3E RID: 20030
		private XTimerMgr.ElapsedEventHandler _endSlowMotionCb = null;

		// Token: 0x04004E43 RID: 20035
		private static float m_AnimLength = -1f;

		// Token: 0x04004E44 RID: 20036
		private static XAnimationClip m_xclip = null;

		// Token: 0x04004E45 RID: 20037
		private static OverrideAnimCallback m_AnimLoadCb = new OverrideAnimCallback(XEntity.AnimLoadCallback);

		// Token: 0x020019C4 RID: 6596
		protected enum EnitityType
		{
			// Token: 0x04007FD2 RID: 32722
			Entity_None = 1,
			// Token: 0x04007FD3 RID: 32723
			Entity_Role,
			// Token: 0x04007FD4 RID: 32724
			Entity_Player = 4,
			// Token: 0x04007FD5 RID: 32725
			Entity_Enemy = 8,
			// Token: 0x04007FD6 RID: 32726
			Entity_Opposer = 16,
			// Token: 0x04007FD7 RID: 32727
			Entity_Boss = 32,
			// Token: 0x04007FD8 RID: 32728
			Entity_Puppet = 64,
			// Token: 0x04007FD9 RID: 32729
			Entity_Elite = 128,
			// Token: 0x04007FDA RID: 32730
			Entity_Npc = 256,
			// Token: 0x04007FDB RID: 32731
			Entity_Dummy = 512,
			// Token: 0x04007FDC RID: 32732
			Entity_Empty = 1024,
			// Token: 0x04007FDD RID: 32733
			Entity_Substance = 2048,
			// Token: 0x04007FDE RID: 32734
			Entity_Temp = 4096,
			// Token: 0x04007FDF RID: 32735
			Entity_Affiliate = 8192,
			// Token: 0x04007FE0 RID: 32736
			Entity_Mount = 16384
		}

		// Token: 0x020019C5 RID: 6597
		protected enum InitFlag
		{
			// Token: 0x04007FE2 RID: 32738
			Entity_Transform = 1
		}
	}
}
