using UnityEngine;
using System.Collections;

public class AndroidStorage {

	static int MegaByte = 1048576; // ByteでMegaByteの値

	static string StorageBlockCount     = "getBlockCount"; // ストレージの全部データーブロック数
	static string StorageBlockSize      = "getBlockSize"; // データーブロックサイズ
	static string StorageBlockAvailable = "getAvailableBlocks"; // ストレージの未利用データーブロック数

	private static AndroidJavaObject statFs;

	/// <summary>
	/// Available storage in Persistent Data directory
	/// </summary>
	public static int AvailableStorageMB() {
		int availableBlocks = GetStatFs().Call<int> (StorageBlockAvailable);
		int blockSize = GetStatFs().Call<int> (StorageBlockSize);
		int freeBytes = availableBlocks * blockSize;
		return freeBytes / MegaByte;
	}

	/// <summary>
	/// Totals storage in Persistent Data directory
	/// </summary>
	public static int TotalStorageMB() {
		int totalBlocks = GetStatFs().Call<int> (StorageBlockCount);
		int blockSize = GetStatFs().Call<int> (StorageBlockSize);
		int totalBytes = totalBlocks * blockSize;
		return totalBytes / MegaByte;
	}

	/// <summary>
	/// Get Android StatFs object instance
	/// </summary>
	static AndroidJavaObject GetStatFs() {
		if (statFs == null) {
			statFs = new AndroidJavaObject ("android.os.StatFs", Application.persistentDataPath);
		}
		return statFs;
	}
}
