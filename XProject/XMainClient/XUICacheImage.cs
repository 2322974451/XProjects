using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	public class XUICacheImage : XSingleton<XUICacheImage>
	{

		private ulong mHashURL(string url)
		{
			return (ulong)((long)Mathf.Abs(url.GetHashCode() + DateTime.Now.Month + DateTime.Now.Day));
		}

		public void SetMainIcon(string url)
		{
			this.m_mainHash = this.mHashURL(url);
		}

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

		public void Load(string url, IXUITexture texture, MonoBehaviour mono)
		{
			this.Load(url, texture, mono, null);
		}

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

		private string path = Application.temporaryCachePath + "/ImageCache/";

		public string CacheKey = "CacheDate";

		private ulong m_mainHash = 0UL;

		private Dictionary<ulong, List<Action<bool>>> callbacks;

		private Dictionary<ulong, List<IXUITexture>> textures;
	}
}
