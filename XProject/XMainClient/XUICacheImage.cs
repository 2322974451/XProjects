using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E7A RID: 3706
	public class XUICacheImage : XSingleton<XUICacheImage>
	{
		// Token: 0x0600C665 RID: 50789 RVA: 0x002BEA44 File Offset: 0x002BCC44
		private ulong mHashURL(string url)
		{
			return (ulong)((long)Mathf.Abs(url.GetHashCode() + DateTime.Now.Month + DateTime.Now.Day));
		}

		// Token: 0x0600C666 RID: 50790 RVA: 0x002BEA7E File Offset: 0x002BCC7E
		public void SetMainIcon(string url)
		{
			this.m_mainHash = this.mHashURL(url);
		}

		// Token: 0x0600C667 RID: 50791 RVA: 0x002BEA90 File Offset: 0x002BCC90
		private void CheckCleanOldRes()
		{
			int num = DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day;
			int @int = PlayerPrefs.GetInt(this.CacheKey, 0);
			bool flag = num != @int;
			if (flag)
			{
				try
				{
					bool flag2 = Directory.Exists(this.path);
					if (flag2)
					{
						Directory.Delete(this.path, true);
					}
				}
				catch
				{
				}
				PlayerPrefs.SetInt(this.CacheKey, num);
			}
		}

		// Token: 0x0600C668 RID: 50792 RVA: 0x002BEB28 File Offset: 0x002BCD28
		private bool OnLoad(string url, IXUITexture texture, Action<bool> cb)
		{
			bool flag = this.callbacks == null;
			if (flag)
			{
				this.callbacks = new Dictionary<ulong, List<Action<bool>>>();
			}
			bool flag2 = this.textures == null;
			if (flag2)
			{
				this.textures = new Dictionary<ulong, List<IXUITexture>>();
			}
			ulong num = this.mHashURL(url);
			bool flag3 = cb != null;
			if (flag3)
			{
				bool flag4 = !this.callbacks.ContainsKey(num);
				if (flag4)
				{
					this.callbacks[num] = new List<Action<bool>>();
				}
				this.callbacks[num].Add(cb);
			}
			texture.ID = num;
			bool flag5 = this.textures.ContainsKey(num);
			bool flag6 = !flag5;
			if (flag6)
			{
				this.textures[num] = new List<IXUITexture>();
			}
			bool flag7 = !this.textures[num].Contains(texture);
			if (flag7)
			{
				this.textures[num].Add(texture);
			}
			return flag5;
		}

		// Token: 0x0600C669 RID: 50793 RVA: 0x002BEC20 File Offset: 0x002BCE20
		private void Dispacher(string url, bool succ, Texture2D img, ulong oldTexID)
		{
			ulong num = this.mHashURL(url);
			bool flag = this.textures.ContainsKey(num);
			if (flag)
			{
				List<IXUITexture> list = this.textures[num];
				for (int i = 0; i < list.Count; i++)
				{
					IXUITexture ixuitexture = list[i];
					bool flag2 = ixuitexture != null && !ixuitexture.Equals(null) && ixuitexture.gameObject != null;
					if (flag2)
					{
						bool flag3 = img == null || img.Equals(null) || !succ || list[i].ID != num;
						if (flag3)
						{
							ixuitexture.SetVisible(false);
							ixuitexture.SetRuntimeTex(null, oldTexID != this.m_mainHash);
							ixuitexture.ID = 0UL;
						}
						else
						{
							ixuitexture.SetVisible(true);
							ixuitexture.SetRuntimeTex(img, oldTexID != this.m_mainHash);
						}
					}
				}
				bool flag4 = this.callbacks.ContainsKey(num);
				if (flag4)
				{
					List<Action<bool>> list2 = this.callbacks[num];
					for (int j = 0; j < list2.Count; j++)
					{
						list2[j](succ);
					}
					this.callbacks.Remove(num);
				}
				this.textures.Remove(num);
			}
		}

		// Token: 0x0600C66A RID: 50794 RVA: 0x002BED91 File Offset: 0x002BCF91
		public void Load(string url, IXUITexture texture, MonoBehaviour mono)
		{
			this.Load(url, texture, mono, null);
		}

		// Token: 0x0600C66B RID: 50795 RVA: 0x002BEDA0 File Offset: 0x002BCFA0
		public void Load(string url, IXUITexture texture, MonoBehaviour mono, Action<bool> cb)
		{
			bool flag = mono == null || string.IsNullOrEmpty(url);
			if (flag)
			{
				texture.SetVisible(false);
				texture.SetRuntimeTex(null, texture.ID != this.m_mainHash);
				texture.ID = 0UL;
			}
			else
			{
				bool flag2 = texture.ID == this.mHashURL(url);
				if (!flag2)
				{
					this.CheckCleanOldRes();
					ulong id = texture.ID;
					bool flag3 = this.OnLoad(url, texture, cb);
					if (!flag3)
					{
						bool flag4 = !File.Exists(this.path + this.mHashURL(url));
						if (flag4)
						{
							mono.StartCoroutine(this.DownloadImage(url, id));
						}
						else
						{
							mono.StartCoroutine(this.LoadLocalImage(url, id));
						}
					}
				}
			}
		}

		// Token: 0x0600C66C RID: 50796 RVA: 0x002BEE6D File Offset: 0x002BD06D
		private IEnumerator DownloadImage(string url, ulong oldTexID)
		{
			bool flag = !Directory.Exists(this.path);
			if (flag)
			{
				try
				{
					Directory.CreateDirectory(this.path);
				}
				catch (Exception ex)
				{
					Exception e = ex;
					XSingleton<XDebug>.singleton.AddLog("write directory failed!", e.Message, null, null, null, null, XDebugColor.XDebug_None);
				}
			}
			WWW www = new WWW(url);
			yield return null;
			while (!www.isDone)
			{
				yield return www;
			}
			bool flag2 = string.IsNullOrEmpty(url) || !string.IsNullOrEmpty(www.error);
			if (flag2)
			{
				this.Dispacher(url, false, null, oldTexID);
				www.Dispose();
				www = null;
			}
			else
			{
				Texture2D image = www.texture;
				byte[] pngData = image.EncodeToJPG();
				bool flag3 = image.width == 8 && image.height == 8;
				if (flag3)
				{
					this.Dispacher(url, false, null, oldTexID);
				}
				else
				{
					bool flag4 = image.width == 8 && image.height == 8;
					if (flag4)
					{
						this.Dispacher(url, false, null, oldTexID);
					}
					else
					{
						try
						{
							File.WriteAllBytes(this.path + this.mHashURL(url), pngData);
						}
						catch (Exception ex)
						{
							Exception e2 = ex;
							XSingleton<XDebug>.singleton.AddLog("write file local failed!", e2.Message, null, null, null, null, XDebugColor.XDebug_None);
						}
						this.Dispacher(url, true, image, oldTexID);
					}
					www.Dispose();
					www = null;
				}
				image = null;
				pngData = null;
			}
			yield break;
		}

		// Token: 0x0600C66D RID: 50797 RVA: 0x002BEE8A File Offset: 0x002BD08A
		private IEnumerator LoadLocalImage(string url, ulong oldTexID)
		{
			bool flag = string.IsNullOrEmpty(url);
			if (flag)
			{
				this.Dispacher(url, false, null, oldTexID);
			}
			else
			{
				string filePath = "file:///" + this.path + this.mHashURL(url);
				WWW www = new WWW(filePath);
				yield return www;
				Texture2D image = www.texture;
				bool flag2 = image.height == 8 && image.width == 8;
				if (flag2)
				{
					this.Dispacher(url, false, null, oldTexID);
				}
				else
				{
					this.Dispacher(url, true, image, oldTexID);
				}
				www.Dispose();
				www = null;
				filePath = null;
				www = null;
				image = null;
			}
			yield break;
		}

		// Token: 0x0400570A RID: 22282
		private string path = Application.temporaryCachePath + "/ImageCache/";

		// Token: 0x0400570B RID: 22283
		public string CacheKey = "CacheDate";

		// Token: 0x0400570C RID: 22284
		private ulong m_mainHash = 0UL;

		// Token: 0x0400570D RID: 22285
		private Dictionary<ulong, List<Action<bool>>> callbacks;

		// Token: 0x0400570E RID: 22286
		private Dictionary<ulong, List<IXUITexture>> textures;
	}
}
