using UnityEngine;
using System;
using System.Runtime.InteropServices;

/// <summary>
/// デバイスストレージ関連のユーティリティー
/// </summary>
public class StorageUtil {

	const int ExceptionStorageSize = -1; // 不具合が発生する時の値

	#if UNITY_IOS || UNITY_IPHONE
	[DllImport("__Internal")]
	private static extern int _iOSStorage_AvailableMb();
	[DllImport("__Internal")]
	private static extern int _iOSStorage_TotalMb();
	#endif

	/// <summary>
	/// Get the total storage size in MB
	/// </summary>
	public static int GetTotalStorageMB() {
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			return AndroidStorage.TotalStorageMB();
		} else { // Editor等
			return ExceptionStorageSize;
		}
		#elif UNITY_IOS || UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			return _iOSStorage_TotalMb();
		} else { // Editor等
			return ExceptionStorageSize;
		}
		#endif
		throw new NotSupportedException(); // 不具合
	}

	/// <summary>
	/// Get the available storage size in MB
	/// </summary>
	public static int GetAvailableStorageMB() {
		#if UNITY_ANDROID
		if (Application.platform == RuntimePlatform.Android) {
			return AndroidStorage.AvailableStorageMB();
		} else { // Editor等
			return ExceptionStorageSize;
		}
		#elif UNITY_IOS || UNITY_IPHONE
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			return _iOSStorage_AvailableMb();
		} else { // Editor等
			return ExceptionStorageSize;
		}
		#endif
		throw new NotSupportedException(); // 不具合
	}
}
